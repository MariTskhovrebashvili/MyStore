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
    public partial class ProviderEdit : EditForm<Provider, ProviderRepository>, IProviderForm
    {
        public ProviderEdit() : base(new ProviderRepository())
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

        public string ProviderName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        public string Phone
        {
            get
            {
                return phoneTxt.Text;
            }
        }

        public string Email
        {
            get
            {
                return emailTxt.Text;
            }
        }

        string IProviderForm.Location
        {
            get
            {
                return locationTxt.Text;
            }
        }

        protected override Provider ReadModel()
        {
            return FormTools.ReadInputModel(this);
        }

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(ProviderList))
                Abort();

            Provider model = _repository.Get(listForm.GetSelectedId());
            LoadModel(model);

            void LoadModel(Provider model)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.Id });
                idBox.SelectedIndex = 0;
                idBox.Enabled = false;
                nameTxt.Text = model.Name;
                phoneTxt.Text = model.Phone;
                emailTxt.Text = model.Email;
                locationTxt.Text = model.Location;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Edit();
                Close();
            }
            catch (Exception ex)
            {
                FormTools.ShowError("Ops", ex.Message);
            }
        }
    }
}
