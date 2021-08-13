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
    public partial class SellList : ListForm<Sell, SellRepository>
    {
        SellDetailsRepository _sellDetailsRepository;

        public SellList() : base(new SellRepository())
        {
            InitializeComponent();
            AddPermission = 18;
            _sellDetailsRepository = new SellDetailsRepository();
            GridView.RowHeaderMouseDoubleClick += RowClick;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuSellAdd_Click;
            EditFunction = null;
            DeleteFunction = null;
            base.ListForm_Load(sender, e);
        }

        protected void RowClick(object sender, EventArgs e)
        {
            SellDetailsList sellDetailsList = new SellDetailsList((int)GetSelectedId()["Id"]);
            sellDetailsList.ShowDialog();
        }
    }
}
