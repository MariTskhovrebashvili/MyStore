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
    public partial class ProductDetailsList : ListForm<ProductDetails, ProductDetailsRepository>
    {
        public ProductDetailsList() : base(new ProductDetailsRepository())
        {
            InitializeComponent();
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = null;
            EditFunction = null;
            DeleteFunction = null;
            base.ListForm_Load(sender, e);
        }
    }
}
