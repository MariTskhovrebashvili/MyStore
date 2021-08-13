using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Store.Models;
using Store.Repositories;

namespace Store.App
{
    public partial class OrderAdd : AddForm<Order, OrderRepository>
    {
        protected OrderDetailsRepository _orderDetailsRepository;
        protected DataTable _table;
        protected List<OrderDetails> _orderDetails;

        public OrderAdd() : base(new OrderRepository())
        {
            InitializeComponent();
            _orderDetailsRepository = new OrderDetailsRepository();
            LoadProvider();
            LoadUser();
            _table = GenerateTable();
            _orderDetails = new List<OrderDetails>();
            gridView.ContextMenuStrip = productStrip;
        }

        protected void LoadProvider()
        {
            foreach (DataRow row in _repository.GetRelatedData()[0].Rows)
                providerBox.Items.Add(new ComboBoxItem() { Id = (int)row["Id"], Name = row["Name"].ToString() });
        }

        protected void LoadUser()
        {
            userBox.Items.Add(new ComboBoxItem() { Id = LocalStorage.UserId, Name = LocalStorage.UserName });
            userBox.SelectedIndex = 0;
            userBox.Enabled = false;
        }

        protected override Order LoadModel()
        {
            return new Order()
            {
                UserId = (userBox.SelectedItem as ComboBoxItem).Id,
                ProviderId = (userBox.SelectedItem as ComboBoxItem).Id,
                OrderDate = Convert.ToDateTime(dateBox.Text),
                RequiredDate = Convert.ToDateTime(dateBox.Text)
            };
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            OrderDetailsAdd orderDetailsAdd = new OrderDetailsAdd(_orderDetailsRepository);
            orderDetailsAdd.ShowDialog();
            if (orderDetailsAdd.Model != null)
            {
                OrderDetails model = orderDetailsAdd.Model;

                if (_orderDetails.Exists(x => x.ProductId == model.ProductId))
                {
                    FormTools.ShowInfo("Ops", "Product already added");
                    return;
                }

                _orderDetails.Add(orderDetailsAdd.Model);
                _table.Rows.Add(new object[] { orderDetailsAdd.GetProductName().Name, model.Quantity, model.UnitPrice, model.Valid });
                TableChanged();
            }
        }

        protected DataTable GenerateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price");
            table.Columns.Add("Valid");

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
                _orderDetailsRepository.InsertMany(LocalStorage.UserId, _orderDetails, returnedValues.dbTransaction, true);
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }

        private void LoadOrderDetailId(int id)
        {
            foreach (OrderDetails item in _orderDetails)
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
            OrderDetailsAdd orderDetailsAdd = new OrderDetailsAdd(_orderDetailsRepository, _orderDetails[row]);
            orderDetailsAdd.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = FormTools.DeleteSelectedRow(gridView);

            if(index >= 0)
                _orderDetails.RemoveAt(index);
        }
    }
}
