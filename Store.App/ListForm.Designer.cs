using Store.Models;
using Store.Repositories;


namespace Store.App
{
	abstract partial class ListForm<TModel, TRepo> where TModel : BaseModel<int>, new() where TRepo : BaseRepository<TModel, int>
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(642, 364);
            this.dataGridView.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMnuAdd,
            this.contextMnuEdit,
            this.contextMnuDelete});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 92);
            // 
            // contextMnuAdd
            // 
            this.contextMnuAdd.Name = "contextMnuAdd";
            this.contextMnuAdd.Size = new System.Drawing.Size(180, 22);
            this.contextMnuAdd.Text = "Add";
            this.contextMnuAdd.Click += new System.EventHandler(this.contextMnuAdd_Click);
            // 
            // contextMnuEdit
            // 
            this.contextMnuEdit.Name = "contextMnuEdit";
            this.contextMnuEdit.Size = new System.Drawing.Size(180, 22);
            this.contextMnuEdit.Text = "Edit";
            this.contextMnuEdit.Click += new System.EventHandler(this.contextMnuEdit_Click);
            // 
            // contextMnuDelete
            // 
            this.contextMnuDelete.Name = "contextMnuDelete";
            this.contextMnuDelete.Size = new System.Drawing.Size(180, 22);
            this.contextMnuDelete.Text = "Delete";
            this.contextMnuDelete.Click += new System.EventHandler(this.contextMnuDelete_Click);
            // 
            // ListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 364);
            this.Controls.Add(this.dataGridView);
            this.Name = "ListForm";
            this.Text = "ListFrom";
            this.Load += new System.EventHandler(this.ListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem contextMnuAdd;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem contextMnuEdit;
        private System.Windows.Forms.ToolStripMenuItem contextMnuDelete;
    }
}