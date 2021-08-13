using FormExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Store.App
{
    public abstract partial class ListForm<TModel, TRepo> : Form, IListForm
    {
        protected DataTable _table;
        protected TRepo _repository;

        public ListForm(TRepo repository)
        {
            InitializeComponent();
            _repository = repository;
            AddPermission = DeletePermission = EditPermission = 100;
        }

        public DataTable Table
        {
            get
            {
                return _table;
            }
            protected set
            {
                _table = value;
                dataGridView.DataSource = _table;
                dataGridView.Columns["Id"].Visible = false;
            }
        }

        protected DataGridView GridView
        {
            get
            {
                return dataGridView;
            }
        }

        public int AddPermission
        {
            get
            {
                return (int)contextMnuAdd.Tag;
            }
            protected set
            {
                contextMnuAdd.Tag = value;
            }
        }

        public int EditPermission
        {
            get
            {
                return (int)contextMnuEdit.Tag;
            }
            protected set
            {
                contextMnuEdit.Tag = value;
            }
        }

        public int DeletePermission
        {
            get
            {
                return (int)contextMnuDelete.Tag;
            }
            protected set
            {
                contextMnuDelete.Tag = value;
            }
        }

        public virtual IDictionary<string, object> GetSelectedId()
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            int rowNum = dataGridView.SelectedRows[0].Index;
            values.Add("Id", dataGridView.Rows[rowNum].Cells["Id"].Value);

            return values;
        }

        public virtual void RefreshData()
        {
            Table = _repository.GetData();
        }

        public Action<object, EventArgs> AddFunction { get; set; }

        public Action<object, EventArgs> EditFunction { get; set; }

        public Action<object, EventArgs> DeleteFunction { get; set; }

        protected virtual void ListForm_Load(object sender, EventArgs e)
        {
            contextMenuStrip.RenderToolStripByPermission(LocalStorage.UserPermissions, '\t');
            RefreshData();
        }

        private void contextMnuAdd_Click(object sender, EventArgs e)
        {
            AddFunction(sender, e);
        }

        private void contextMnuEdit_Click(object sender, EventArgs e)
        {
            EditFunction(sender, e);
        }

        private void contextMnuDelete_Click(object sender, EventArgs e)
        {
            DeleteFunction(sender, e);
        }
    }
}
