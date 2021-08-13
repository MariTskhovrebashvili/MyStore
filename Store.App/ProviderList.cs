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
    public partial class ProviderList : ListForm<Provider, ProviderRepository>
    {
        public ProviderList() : base(new ProviderRepository())
        {
            InitializeComponent();
            AddPermission = 13;
            EditPermission = 23;
            DeletePermission = 33;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuProviderAdd_Click;
            EditFunction = (MdiParent as MainForm).mnuProviderEdit_Click;
            DeleteFunction = (MdiParent as MainForm).mnuProviderDelete_Click;
            base.ListForm_Load(sender, e);
        }
    }
}
