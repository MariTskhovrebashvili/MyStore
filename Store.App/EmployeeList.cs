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
    public partial class EmployeeList : ListForm<Employee, EmployeeRepository>
    {
        public EmployeeList() : base(new EmployeeRepository())
        {
            InitializeComponent();
            AddPermission = 11;
            EditPermission = 21;
            DeletePermission = 31;
        }

        protected override void ListForm_Load(object sender, EventArgs e)
        {
            AddFunction = (MdiParent as MainForm).mnuEmployeeAdd_Click;
            EditFunction = (MdiParent as MainForm).mnuEmployeeEdit_Click;
            DeleteFunction = (MdiParent as MainForm).mnuEmployeeDelete_Click;
            base.ListForm_Load(sender, e);
        }
    }
}
