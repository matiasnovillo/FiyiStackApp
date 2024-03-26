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
            try
            {
                InitializeComponent();

                txtNewPassword.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            }
            catch (Exception ex)
            {
                Failure failure = new()
                {
                    Active = true,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    Message = ex.Message, 
                    StackTrace = ex.StackTrace,
                    Source = ex.Source,
                };
                failure.Add();
            }
        }

        private void btnEditPassword_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnEditUserData_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Failure failure = new()
                {
                    Active = true,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    Source = ex.Source,
                };
                failure.Add();
            }
        }
    }
}
