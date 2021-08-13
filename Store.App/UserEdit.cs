using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Store.Models;
using Store.Repositories;


namespace Store.App
{
    public partial class UserEdit : EditForm<User, UserRepository>, IUserForm
    {
        public UserEdit() : base(new UserRepository())
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

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(UserList))
                Abort();

            User model = _repository.Get(listForm.GetSelectedId());
            LoadModel(model);

            void LoadModel(User model)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.Id });
                idBox.SelectedIndex = 0;
                idBox.Enabled = false;
                userTxt.Text = model.Username;
            }
        }

        protected override User ReadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Edit();
                Close();
            }
            catch(Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
