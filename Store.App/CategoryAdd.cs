using System;
using System.Windows.Forms;
using Store.Models;
using Store.Repositories;

namespace Store.App
{
    public partial class CategoryAdd : AddForm<Category, CategoryRepository>, ICategoryForm
    {
        public CategoryAdd() : base(new CategoryRepository()) 
        {
            InitializeComponent();
        }

        public int Id
        {
            get
            {
                return default;
            }
        }

        public string CategoryName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        protected override Category LoadModel()
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
