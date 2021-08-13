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
    public partial class UserDelete : DeleteForm<User, UserRepository>, IUserForm
    {
        public UserDelete() : base(new UserRepository())
        {
            InitializeComponent();
        }

        public int Id
        {
            get
            {
                return (idBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public string Username => default;

        public string Password => default;

        protected override User LoadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(UserList))
                Abort();

            idBox.Items.Add(new ComboBoxItem() { Id = (int)listForm.GetSelectedId()["Id"] });
            idBox.SelectedIndex = 0;
            idBox.Enabled = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
