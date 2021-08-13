using Store.Models;
using Store.Repositories;
using System;
using Store.Permissions;
using System.Windows.Forms;
using System.Data;

namespace Store.App
{
    public static class FormTools
    {
        public static void ShowError(string header, string text)
        {
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string header, string text)
        {
            MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static UserPermissions LoadPermissions(IUserGroupsForm form)
        {
            int permission = 0;

            if (form.Admin)
                permission += 1;
            if (form.Cashier)
                permission += 2;
            if (form.Manager)
                permission += 4;
            if (form.SupplyManager)
                permission += 8;

            return (UserPermissions)permission;
        }

        public static Employee ReadInputModel(IEmployeeForm form) 
        {
            return new Employee()
            {
                Id = form.Id,
                FirstName = form.FirstName,
                LastName = form.LastName,
                PersonalId = form.PersonalId,
                Phone = form.Phone,
                Email = form.Email,
                HomeAddress = form.HomeAddress,
                StartJob = form.StartJob
            };
        }

        public static User ReadInputModel(IUserForm form)
        {
            return new User()
            {
                Id = form.Id,
                Username = form.Username,
                Password = form.Password
            };
        }

        public static UserGroups ReadInputModel(IUserGroupsForm form)
        {
            return new UserGroups()
            {
                Id = form.Id,
                GroupId = form.GroupId
            };
        }

        public static Category ReadInputModel(ICategoryForm form)
        {
            return new Category()
            {
                Id = form.Id,
                Name = form.CategoryName
            };
        }

        public static Product ReadInputModel(IProductForm form)
        {
            return new Product()
            {
                Id = form.Id,
                CategoryId = form.CategoryId,
                Name = form.ProductionName,
                Price = form.Price
            };
        }

        public static Provider ReadInputModel(IProviderForm form)
        {
            return new Provider()
            {
                Id = form.Id,
                Name = form.ProviderName,
                Phone = form.Phone,
                Email = form.Email,
                Location = form.Location
            };
        }

        public static void LoadRelatedData(ProductRepository repository, ComboBox comboBox)
        {
            foreach (DataRow row in repository.GetRelatedData()[0].Rows)
                comboBox.Items.Add(new ComboBoxItem() { Id = (int)row["Id"], Name = row["Name"].ToString() });
        }

        public static void LoadRelatedData(UserRepository repository, ComboBox comboBox)
        {
            foreach (DataRow row in repository.GetRelatedData()[0].Rows)
                comboBox.Items.Add(new ComboBoxItem() { Id = (int)row["Id"], Name = $"{row["Firstname"]} {row["Lastname"]}" });
        }

        public static int DeleteSelectedRow(DataGridView gridView)
        {
            if (gridView.SelectedRows.Count == 0 || gridView.Rows.Count == 0)
            {
                FormTools.ShowInfo("Ops", "Choose row to delete");
                return -1;
            }

            int row = gridView.SelectedRows[0].Index;
            gridView.Rows.RemoveAt(row);
            return row;
        }
    }
}
