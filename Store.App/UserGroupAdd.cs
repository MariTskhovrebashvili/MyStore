using System;
using System.Windows.Forms;
using Store.Models;
using Store.Permissions;
using Store.Repositories;
using System.Data;

namespace Store.App
{
    public partial class UserGroupAdd : AddForm<UserGroups, UserGroupsRepository>, IUserGroupsForm
    {
        public UserGroupAdd() : base(new UserGroupsRepository())
        {
            InitializeComponent();
            LoadUsers();
        }

        public int Id
        {
            get
            {
                return (userBox.SelectedItem as ComboBoxItem).Id;
            }
        }

        public UserPermissions GroupId
        {
            get
            {
                return FormTools.LoadPermissions(this);
            }
        }

        public bool Admin => adminBox.Checked;

        public bool Cashier => cashierBox.Checked;

        public bool Manager => managerBox.Checked;

        public bool SupplyManager => supllyManagerBox.Checked;

        protected void LoadUsers()
        {
            foreach (DataRow row in _repository.GetRelatedData()[0].Rows)
            {
                userBox.Items.Add(new ComboBoxItem() { Id = (int)row["Id"], Name = row["Username"].ToString() });
            }
        }

        protected override UserGroups LoadModel()
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
