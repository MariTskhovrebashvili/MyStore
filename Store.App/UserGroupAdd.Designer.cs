
namespace Store.App
{
    partial class UserGroupAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGroupAdd));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.adminBox = new System.Windows.Forms.CheckBox();
            this.cashierBox = new System.Windows.Forms.CheckBox();
            this.managerBox = new System.Windows.Forms.CheckBox();
            this.supllyManagerBox = new System.Windows.Forms.CheckBox();
            this.addBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // userBox
            // 
            this.userBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(147, 55);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(167, 23);
            this.userBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "User";
            // 
            // adminBox
            // 
            this.adminBox.AutoSize = true;
            this.adminBox.Location = new System.Drawing.Point(40, 151);
            this.adminBox.Name = "adminBox";
            this.adminBox.Size = new System.Drawing.Size(62, 19);
            this.adminBox.TabIndex = 3;
            this.adminBox.Text = "Admin";
            this.adminBox.UseVisualStyleBackColor = true;
            // 
            // cashierBox
            // 
            this.cashierBox.AutoSize = true;
            this.cashierBox.Location = new System.Drawing.Point(40, 188);
            this.cashierBox.Name = "cashierBox";
            this.cashierBox.Size = new System.Drawing.Size(65, 19);
            this.cashierBox.TabIndex = 4;
            this.cashierBox.Text = "Cashier";
            this.cashierBox.UseVisualStyleBackColor = true;
            // 
            // managerBox
            // 
            this.managerBox.AutoSize = true;
            this.managerBox.Location = new System.Drawing.Point(215, 151);
            this.managerBox.Name = "managerBox";
            this.managerBox.Size = new System.Drawing.Size(73, 19);
            this.managerBox.TabIndex = 5;
            this.managerBox.Text = "Manager";
            this.managerBox.UseVisualStyleBackColor = true;
            // 
            // supllyManagerBox
            // 
            this.supllyManagerBox.AutoSize = true;
            this.supllyManagerBox.Location = new System.Drawing.Point(215, 188);
            this.supllyManagerBox.Name = "supllyManagerBox";
            this.supllyManagerBox.Size = new System.Drawing.Size(112, 19);
            this.supllyManagerBox.TabIndex = 6;
            this.supllyManagerBox.Text = "Supply Manager";
            this.supllyManagerBox.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(121, 234);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(103, 23);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // UserGroupAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 269);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.supllyManagerBox);
            this.Controls.Add(this.managerBox);
            this.Controls.Add(this.cashierBox);
            this.Controls.Add(this.adminBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserGroupAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add User Permission";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox userBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox adminBox;
        private System.Windows.Forms.CheckBox cashierBox;
        private System.Windows.Forms.CheckBox managerBox;
        private System.Windows.Forms.CheckBox supllyManagerBox;
        private System.Windows.Forms.Button addBtn;
    }
}