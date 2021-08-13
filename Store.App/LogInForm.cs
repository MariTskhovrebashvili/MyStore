using System;
using Store.Repositories;
using System.Windows.Forms;

namespace Store.App
{
	public partial class LogInForm : Form
	{
		private readonly UserRepository _userRepository;

		public LogInForm()
		{
			InitializeComponent();
			_userRepository = new UserRepository();
			Valid = false;
			txtPassword.PasswordChar = '*';

#if DEBUG
			txtUsername.Text = "Admin";
			txtPassword.Text = "Admin1234";
#endif
		}

		public bool Valid { get; private set; }

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox.Checked == true)
				txtPassword.PasswordChar = '\0';
			else
				txtPassword.PasswordChar = '*';
		}

		private void logBtn_Click(object sender, EventArgs e)
		{
			(string username, string password) = ReadInput();
			try
			{
				LocalStorage.UserId = _userRepository.LogIn(username, password);
				if (LocalStorage.UserId > 0)
				{
					Valid = true;
					LocalStorage.UserPermissions = _userRepository.GetUserPermissions(LocalStorage.UserId);
					LocalStorage.UserName = username;
					(Owner as MainForm).StatusStripText = username;
					Close();
				}
				else
				{
					throw new Exception("Invalid Creditals");
				}
			}
			catch
			{
				FormTools.ShowInfo("Ops", "Invalid Username or Password");
			}
		}

		private (string, string) ReadInput()
		{
			return (txtUsername.Text, txtPassword.Text);
		}

		private void LogInForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				logBtn_Click(sender, e);
		}
	}
}
