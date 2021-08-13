using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Store.Repositories;
using Store.Models;

namespace Store.App
{
    public partial class CategoryList : ListForm<Category, CategoryRepository>
    {
        public CategoryList() : base(new CategoryRepository())
        {
            InitializeComponent();
            AddPermission = 14;
            EditPermission = 24;
            DeletePermission = 34;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuCategoryAdd_Click;
            EditFunction = (MdiParent as MainForm).mnuCategoryEdit_Click;
            DeleteFunction = (MdiParent as MainForm).mnuCategoryDelete_Click;
            base.ListForm_Load(sender, e);
        }
    }
}
