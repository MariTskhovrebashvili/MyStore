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
    public partial class OrderList : ListForm<Order, OrderRepository>
    {
        public OrderList() : base(new OrderRepository())
        {
            InitializeComponent();
            AddPermission = 15;
            GridView.RowHeaderMouseDoubleClick += RowClick;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuOrderAdd_Click;
            EditFunction = null;
            DeleteFunction = null;
            base.ListForm_Load(sender, e);
        }

        protected void RowClick(object sender, EventArgs e)
        {
            OrderDetailsList sellDetailsList = new OrderDetailsList((int)GetSelectedId()["Id"]);
            sellDetailsList.ShowDialog();
        }
    }
}
