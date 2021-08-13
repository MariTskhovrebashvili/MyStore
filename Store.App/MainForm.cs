using Store.Models;
using Store.Repositories;
using System;
using System.Windows.Forms;
using FormExtensions;

namespace Store.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Properties

        public string StatusStripText
        {
            get
            {
                return toolStripStatusLabel.Text;
            }
            set
            {
                toolStripStatusLabel.Text = value;
            }
        }

        #endregion

        #region WindowsAppearence

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuCloseAll_Click(object sender, EventArgs e)
        {
            while (MdiChildren.Length > 0)
                MdiChildren[0].Close();
        }

        #endregion

        #region About&Help

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        #endregion

        #region Lists

        private void OpenChildForm<TModel, TRepo>(ListForm<TModel, TRepo> listForm) where TModel : BaseModel<int>, new() where TRepo : BaseRepository<TModel, int>
        {
            if (WindowExists(listForm))
            {
                FormTools.ShowInfo("Ops", "Window is already opend");
                return;
            }

            listForm.MdiParent = this;
            listForm.Show();
        }

        private void mnuEmployeesList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeList());
        }

        private void mnuUsersList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserList());
        }

        private void mnuUserGroupsList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserGroupsList());
        }

        private void mnuCategoriesList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CategoryList());
        }

        private void mnuProductsList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductList());
        }

        private void mnuProductDetailsList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductDetailsList());
        }

        private void mnuOrderList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderList());
        }

        private void mnuOrderDetailsList_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuSellList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SellList());
        }

        private void mnuSellDetailsList_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuProviderList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProviderList());
        }

        private bool WindowExists<TModel, TRepo>(ListForm<TModel, TRepo> listForm) where TModel : BaseModel<int>, new() where TRepo : BaseRepository<TModel, int>
        {
            for (int i = 0; i < MdiChildren.Length; i++)
                if (MdiChildren[i].GetType() == listForm.GetType())
                    return true;

            return false;
        }

        #endregion

        #region Add

        private void CallAddDialog<TModel, TRepo>(AddForm<TModel, TRepo> addForm) where TModel : BaseModel<int>, new() where TRepo : BaseRepository<TModel, int>
        {
            addForm.ShowDialog();
            RefreshList();
        }

        public void mnuEmployeeAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new EmployeeAdd());
        }

        public void mnuUserAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new UserAdd());
        }

        public void mnuUserGroupAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new UserGroupAdd());
        }

        public void mnuCategoryAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new CategoryAdd());
        }

        public void mnuProductAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new ProductAdd());
        }

        public void mnuProviderAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new ProviderAdd());
        }

        public void mnuOrderAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new OrderAdd());
        }

        public void mnuSellAdd_Click(object sender, EventArgs e)
        {
            CallAddDialog(new SellAdd());
        }

        #endregion

        #region Edit

        private void CallEditDialog<TModel, TRepo>(EditForm<TModel, TRepo> editForm) where TModel : BaseModel<int>, new() where TRepo : BaseRepository<TModel, int>
        {
            editForm.Owner = this;
            editForm.ShowDialog();
            RefreshList();
        }

        public void mnuEmployeeEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new EmployeeEdit());
        }

        public void mnuUserEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new UserEdit());
        }

        public void mnuUserGroupEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new UserGroupEdit());
        }

        public void mnuCategoryEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new CategoryEdit());
        }

        public void mnuProductEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new ProductEdit());
        }

        public void mnuProviderEdit_Click(object sender, EventArgs e)
        {
            CallEditDialog(new ProviderEdit());
        }

        #endregion

        #region Delete

        private void CallDeleteDialog<TModel, TRepo>(DeleteForm<TModel, TRepo> deleteForm) where TModel : BaseModel<int>, new() where TRepo : BaseRepository<TModel, int>
        {
            deleteForm.Owner = this;
            deleteForm.ShowDialog();
            RefreshList();
        }

        public void mnuEmployeeDelete_Click(object sender, EventArgs e)
        {
            CallDeleteDialog(new EmployeeDelete());
        }

        public void mnuUserDelete_Click(object sender, EventArgs e)
        {
            CallDeleteDialog(new UserDelete());
        }

        public void mnuCategoryDelete_Click(object sender, EventArgs e)
        {
            
        }

        public void mnuProductDelete_Click(object sender, EventArgs e)
        {
            
        }

        public void mnuProviderDelete_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ToolStripFunctions

        private void GlobalAdd_Click(object sender, EventArgs e)
        {
            IListForm form = (IListForm)ActiveMdiChild;
            if (form == null)
            {
                FormTools.ShowInfo("Ops", "First you should open list window !");
                return;
            }

            form.AddFunction(sender, e);
        }

        #endregion

        #region User Logging

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogInForm logIn = new LogInForm();
            logIn.Owner = this;
            logIn.ShowDialog();
            if (!logIn.Valid)
                Close();
            else
                this.RenderControlsByPermission(LocalStorage.UserPermissions, ',');
        }

        private void logOutLbl_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        #endregion

        #region Tools

        private void RefreshList()
        {
            foreach (IListForm form in MdiChildren)
                form.RefreshData();
        }

        #endregion
    }
}
