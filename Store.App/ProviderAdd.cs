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
    public partial class ProviderAdd : AddForm<Provider, ProviderRepository>, IProviderForm
    {
        public ProviderAdd() : base (new ProviderRepository())
        {
            InitializeComponent();
        }

        public int Id
        {
            get
            {
                return default;
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

        public string ProviderName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        string IProviderForm.Location
        {
            get
            {
                return locationTxt.Text;
            }
        }

        protected override Provider LoadModel()
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
