using System;
using System.Windows.Forms;
using Store.Models;
using Store.Repositories;
using System.Data;

namespace Store.App
{
    public partial class ProductAdd : AddForm<Product, ProductRepository>, IProductForm
    {
        public ProductAdd() : base(new ProductRepository())
        {
            InitializeComponent();
            FormTools.LoadRelatedData(_repository, categoryBox);
        }

        public int Id
        {
            get
            {
                return default;
            }
        }

        public int CategoryId
        {
            get
            {
                return (categoryBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public decimal Price
        {
            get
            {
                return Convert.ToDecimal(priceTxt.Text);
            }
        }

        public string ProductionName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        protected override Product LoadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
