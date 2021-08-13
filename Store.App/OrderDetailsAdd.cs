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
    public partial class OrderDetailsAdd : Form
    {
        protected OrderDetailsRepository _repository;

        public OrderDetailsAdd(OrderDetailsRepository repository, OrderDetails model = null)
        {
            InitializeComponent();
            sellPriceTxt.Enabled = false;
            _repository = repository;
            LoadProducts();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            if (model != null) LoadModel(model);
        }

        public OrderDetails Model { get; protected set; }

        public ComboBoxDetailedItem GetProductName()
        {
            return productBox.SelectedItem as ComboBoxDetailedItem;
        }

        protected void LoadProducts()
        {
            foreach (DataRow row in _repository.GetRelatedData()[0].Rows)
                productBox.Items.Add(new ComboBoxDetailedItem() { Id = (int)row["Id"], Name = row["Name"].ToString(), Price = Convert.ToDecimal(row["Price"]) });
        }

        protected void ReadInput()
        {
            if (Convert.ToDecimal(priceTxt.Text) > Convert.ToDecimal(sellPriceTxt.Text))
                throw new Exception("You pay more than it costs");

            OrderDetails model = new()
            {
                ProductId = (productBox.SelectedItem as ComboBoxDetailedItem).Id,
                Quantity = Convert.ToInt32(quantityTxt.Text),
                UnitPrice = Convert.ToDecimal(priceTxt.Text),
                Valid = Convert.ToDateTime(validDate.Text),
                ProvideDate = DateTime.Now
            };
            Model = model;
        }

        protected void LoadModel(OrderDetails model)
        {
            foreach (ComboBoxDetailedItem item in productBox.Items)
            {
                if (item.Id == model.ProductId)
                {
                    productBox.SelectedItem = item;
                    break;
                } 
            }

            priceTxt.Text = model.UnitPrice.ToString();
            quantityTxt.Text = model.Quantity.ToString();
            validDate.Text = model.Valid.ToString();
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sellPriceTxt.Text = _repository.GetProductPriceById((productBox.SelectedItem as ComboBoxDetailedItem).Id).ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ReadInput();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
