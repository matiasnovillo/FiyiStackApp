using FiyiStackApp.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiyiStackApp
{
    public partial class ChangeUserData : Form
    {
        public ChangeUserData()
        {
            InitializeComponent();

            txtNewPassword.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
        }

        private void btnEditPassword_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnEditUserData_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim() != "" || txtNewUserName.Text.Trim() != "" || txtNewEmail.Text.Trim() != "")
            {
                User LoggedUser = Program.WinFormConfigurationComponent.UserLogged;
                LoggedUser.ChangeUserDataByUserId(LoggedUser.UserId, 
                    FiyiStack.Library.NET.Security.EncodeString(txtNewPassword.Text),
                    txtNewUserName.Text,
                    txtNewEmail.Text);
            }
            this.Close();
        }
    }
}
