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
    public partial class UserList : ListForm<User, UserRepository>
    {
        public UserList() : base(new UserRepository())
        {
            InitializeComponent();
            AddPermission = 12;
            EditPermission = 22;
            DeletePermission = 32;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuUserAdd_Click;
            EditFunction = (MdiParent as MainForm).mnuUserEdit_Click;
            DeleteFunction = (MdiParent as MainForm).mnuUserDelete_Click;
            base.ListForm_Load(sender, e);
        }
    }
}
