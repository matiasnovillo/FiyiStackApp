using System;
using System.Drawing;
using System.Windows.Forms;
using FiyiStackApp.Models.Core;
using FiyiStack.Library.NET;
using System.Net;
using System.IO;
using FiyiStackApp.Properties;
using System.Timers;

namespace FiyiStackApp
{
    public partial class MainForm : Form
    {
        User _User;
        bool Loading = false;

        public MainForm()
        {
            InitializeComponent();
            //Basic
            Loading = true;
            lblMessageDockedBottom.Text = "";

            //Set border radius to TextBoxes
            Color BlackColorPlus1 = (Color)new ColorConverter().ConvertFromString("#20262D");
            txtFantasyNameOrEmail.BackColor = BlackColorPlus1;
            txtPassword.BackColor = BlackColorPlus1;

            if (Program.WinFormConfigurationComponent.RememberMe)//Remembered user
            {
                txtFantasyNameOrEmail.Text = Program.WinFormConfigurationComponent.FantasyNameOrEmailFromLocalDB;
                chbRememberMe.Checked = true;
                txtFantasyNameOrEmail.TabIndex = 1;
                txtPassword.TabIndex = 0;

            }
            else//Not remembered user
            {
                txtFantasyNameOrEmail.Text = "";
                chbRememberMe.Checked = false;
                txtFantasyNameOrEmail.TabIndex = 0;
                txtPassword.TabIndex = 1;
            }
            Loading = false;

            //Basico
            PanelLogin.Location = new Point(6, 106);
            PanelProject.Location = new Point(6, 106);
            lblTitle.Text = "Bienvenido a FiyiStack. El generador de código";
            lblSubtitle.Text = "Más de 5.000 lineas de código por tabla. Y sigue creciendo";

            HideAllPanelsExcept(PanelLogin);
        }

        private void HideAllPanelsExcept(Panel Panel)
        {
            PanelLogin.Hide();
            PanelProject.Hide();

            Panel.Show();
        }

        private void Login()
        {
            try
            {
                //Validate
                bool validationok = true;
                if (txtFantasyNameOrEmail.Text == "") { picErrorForFantasyNameOrEmail.Visible = true; validationok = false; }
                if (txtPassword.Text == "") { picErrorForPassword.Visible = true; validationok = false; }

                if (validationok)
                {
                    //Initialization
                    Cursor = Cursors.WaitCursor;
                    lblMessageDockedBottom.Text = "Trying login";
                    picErrorForFantasyNameOrEmail.Visible = false;

                    _User = new User(txtFantasyNameOrEmail.Text, txtFantasyNameOrEmail.Text, Security.EncodeString(txtPassword.Text));

                    if (_User.UserId == 0)//User not found
                    {
                        picErrorForFantasyNameOrEmail.Visible = true;
                        picErrorForPassword.Visible = true;
                        lblMessageDockedBottom.Text = "User not found";
                    }
                    else//User found
                    {
                        Converter.CopyObjectProperties(_User, Program.WinFormConfigurationComponent.UserLogged);

                        if (Program.WinFormConfigurationComponent.RememberMe)
                        {
                            Program.WinFormConfigurationComponent.FantasyNameOrEmailFromLocalDB = _User.FantasyName;
                        }
                        lblMessageDockedBottom.Text = "User found. Entering";
                        
                        Program.WinFormConfigurationComponent.timer = new System.Timers.Timer(600000);
                        Program.WinFormConfigurationComponent.timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
                        Program.WinFormConfigurationComponent.timer.Start();

                        this.Hide();
                        ProjectForm ProjectForm = new ProjectForm();
                        ProjectForm.ShowDialog();
                        this.Dispose();
                    }

                    //Finalization
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex) 
            {
                lblMessageDockedBottom.Text = ex.Message;
                Cursor = Cursors.Default; 
                Console.WriteLine(ex.Message); 
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Program.WinFormConfigurationComponent.timer.Stop();
            MessageBox.Show("Time elapsed. For security reasons you have been logged out.", "FiyiStack - Account control", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        #region Secondary Configuration
        private void txtUserName_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtUserPassword_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnSee_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            btnSeePassword.Visible = false;
        }

        private void btnSee_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnSeePassword.Visible = true;
        }

        private void picProfilePicture_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 50, 50);
        }

        private void picRememberMe_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 20, 20);
        }

        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void picLogo_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 20, 20);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //Code for Enter button
            {
                Login();
            }
        }

        private void txtFantasyNameOrEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //Code for Enter button
            {
                Login();
            }
        }

        private void chbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading == false)
            {
                if (Program.WinFormConfigurationComponent.RememberMe)//Not remember user
                {
                    Program.WinFormConfigurationComponent.RememberMe = false;
                    Program.WinFormConfigurationComponent.FantasyNameOrEmailFromLocalDB = "";
                    if (File.Exists("ProfilePicture.png"))
                    {
                        try
                        {
                            File.Delete("ProfilePicture.png");
                        }
                        catch (Exception) { }
                    }
                }
                else//Remember user
                {
                    Program.WinFormConfigurationComponent.RememberMe = true;
                } 
            }
        }
        #endregion
    }
}
