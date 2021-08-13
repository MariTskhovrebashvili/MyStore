using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Store.Models;
using Store.Permissions;
using Store.Repositories;

namespace Store.App
{
    public partial class UserGroupEdit : EditForm<UserGroups, UserGroupsRepository>, IUserGroupsForm
    {
        public UserGroupEdit() : base (new UserGroupsRepository())
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

        public UserPermissions GroupId => FormTools.LoadPermissions(this);

        public bool Admin => adminBox.Checked;

        public bool Cashier => cashierBox.Checked;

        public bool Manager => managerBox.Checked;

        public bool SupplyManager => supllyManagerBox.Checked;

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(UserGroupsList))
                Abort();

            UserGroups model = _repository.Get(listForm.GetSelectedId());
            LoadModel(model);

            void LoadModel(UserGroups model)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.Id });
                idBox.SelectedIndex = 0;
                idBox.Enabled = false;
                adminBox.Checked = ((int)model.GroupId & 1) == 1 ? true : false;
                cashierBox.Checked = (((int)model.GroupId >> 1) & 1) == 1 ? true : false;
                managerBox.Checked = (((int)model.GroupId >> 2) & 1) == 1 ? true : false;
                supllyManagerBox.Checked = (((int)model.GroupId >> 3) & 1) == 1 ? true : false;
            }
        }

        protected override UserGroups ReadModel()
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
