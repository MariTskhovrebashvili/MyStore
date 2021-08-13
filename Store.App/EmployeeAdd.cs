using System;
using System.Windows.Forms;
using Store.Models;
using Store.Repositories;

namespace Store.App
{
    public partial class EmployeeAdd : AddForm<Employee, EmployeeRepository>, IEmployeeForm
    {
        public EmployeeAdd() : base(new EmployeeRepository())
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
                return addressTxt.Text;
            }
        }

        public DateTime? StartJob
        {
            get
            {
                return Convert.ToDateTime(dateBox.Text);
            }
        }

        protected override Employee LoadModel() => FormTools.ReadInputModel(this);

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
