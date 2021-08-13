using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Store.Models;
using Store.Repositories;

namespace Store.App
{
    public partial class SellAdd : AddForm<Sell, SellRepository>
    {
        protected SellDetailsRepository _sellDetailsRepository;
        protected DataTable _table;
        protected List<SellDetails> _sellDetails;

        public SellAdd() : base(new SellRepository())
        {
            InitializeComponent();
            LoadUser();
            _sellDetailsRepository = new SellDetailsRepository();
            _table = GenerateTable();
            _sellDetails = new List<SellDetails>();
            gridView.ContextMenuStrip = productStrip;
        }

        protected override Sell LoadModel()
        {
            return new Sell()
            {
                UserId = Convert.ToInt32((userBox.SelectedItem as ComboBoxItem).Id),
                SellDate = Convert.ToDateTime(datePicker.Text)
            };
        }

        protected void LoadUser()
        {
            userBox.Items.Add(new ComboBoxItem() { Id = LocalStorage.UserId, Name = LocalStorage.UserName });
            userBox.SelectedIndex = 0;
            userBox.Enabled = false;
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            SellDetailsAdd sellDetailsAdd = new SellDetailsAdd(_sellDetailsRepository);
            sellDetailsAdd.ShowDialog();
            if (sellDetailsAdd.Model != null)
            {
                SellDetails model = sellDetailsAdd.Model;
                if(_sellDetails.Exists(x => x.ProductId == model.ProductId))
                {
                    FormTools.ShowInfo("Ops", "Product already added");
                    return;
                }

                _sellDetails.Add(model);
                _table.Rows.Add(new object[] { sellDetailsAdd.GetProductName(), model.Quantity, model.UnitPrice, model.Discount });
                TableChanged();
            }
        }

        protected DataTable GenerateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price");
            table.Columns.Add("Discount");

            return table;
        }

        protected void TableChanged()
        {
            gridView.DataSource = _table;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var returnedValues = _repository.Insert(LocalStorage.UserId, LoadModel(), null, false);
                LoadOrderDetailId(returnedValues.lastReturn);
                _sellDetailsRepository.InsertMany(LocalStorage.UserId, _sellDetails, returnedValues.dbTransaction, true);
                Close();
            }
            catch(ArgumentException ex)
            {
                _repository.AbortFlow();
                FormTools.ShowError("Ops", ex.Message);
            }
            catch (Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void LoadOrderDetailId(int id)
        {
            foreach (SellDetails item in _sellDetails)
                item.Id = id;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count == 0 || gridView.Rows.Count == 0)
            {
                FormTools.ShowInfo("Ops", "Choose row to delete");
                return;
            }

            int row = gridView.SelectedRows[0].Index;
            SellDetailsAdd orderDetailsAdd = new SellDetailsAdd(_sellDetailsRepository, _sellDetails[row]);
            orderDetailsAdd.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = FormTools.DeleteSelectedRow(gridView);

            if (index >= 0)
                _sellDetails.RemoveAt(index);
        }
    }
}
