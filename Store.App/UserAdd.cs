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
    public partial class UserAdd : AddForm<User, UserRepository>, IUserForm
    {
        public UserAdd() : base(new UserRepository())
        {
            InitializeComponent();
            FormTools.LoadRelatedData(_repository, employeeBox);
        }

        public int Id
        {
            get
            {
                return (employeeBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public string Username
        {
            get
            {
                return userTxt.Text;
            }
        }

        public string Password
        {
            get
            {
                return passwordTxt.Text;
            }
        }

        protected override User LoadModel()
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
