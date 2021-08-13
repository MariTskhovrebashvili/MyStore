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
    public partial class EmployeeEdit : EditForm<Employee, EmployeeRepository>, IEmployeeForm
    {
        public EmployeeEdit() : base (new EmployeeRepository())
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

        public string FirstName
        {
            get
            {
                return nameTxt.Text;
            }
        }

        public string LastName
        {
            get
            {
                return lastnameTxt.Text;
            }
        }

        public string PersonalId
        {
            get
            {
                return personalTxt.Text;
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

        public string HomeAddress
        {
            get
            {
                return adressTxt.Text;
            }
        }

        public DateTime? StartJob
        {
            get
            {
                return Convert.ToDateTime(dateBox.Text);
            }
        }

        protected override void LoadSelectedModel()
        {
            IListForm listForm = (Owner as MainForm).ActiveMdiChild as IListForm;

            if (listForm == null || listForm.GetType() != typeof(Employee))
                Abort();

            Employee model = _repository.Get(listForm.GetSelectedId());
            LoadModel(model);

            void LoadModel(Employee model)
            {
                idBox.Items.Add(new ComboBoxItem() { Id = model.Id });
                nameTxt.Text = model.FirstName;
                lastnameTxt.Text = model.LastName;
                personalTxt.Text = model.PersonalId;
                phoneTxt.Text = model.Phone;
                emailTxt.Text = model.Email;
                adressTxt.Text = model.HomeAddress;
                dateBox.Text = model.StartJob.ToString();
            }
        }

        protected override Employee ReadModel()
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
