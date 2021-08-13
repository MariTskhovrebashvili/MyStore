using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.App
{
    public abstract partial class EditForm<TModel, TRepo> : Form
    {
        protected TRepo _repository;

        public EditForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected virtual void Edit()
        {
            TModel model = ReadModel();
            _repository.Update(LocalStorage.UserId, model);
            if (model.Id == LocalStorage.UserId)
                Application.Restart();
        }

        protected virtual void Abort()
        {
            FormTools.ShowInfo("Ops", "You should choose relevant List Window");
            Close();
        }

        protected abstract TModel ReadModel();

        protected abstract void LoadSelectedModel();

        private void EditForm_Load(object sender, EventArgs e)
        {
            LoadSelectedModel();
        }
    }
}
