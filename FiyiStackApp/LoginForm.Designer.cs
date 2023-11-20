
namespace FiyiStackApp
{
    partial class LoginForm
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
            this.txtFantasyNameOrEmail = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.picErrorForPassword = new System.Windows.Forms.PictureBox();
            this.picErrorForFantasyNameOrEmail = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.PictureBox();
            this.picProfilePicture = new System.Windows.Forms.PictureBox();
            this.btnSeePassword = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.chbRememberMe = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForFantasyNameOrEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFantasyNameOrEmail
            // 
            this.txtFantasyNameOrEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.txtFantasyNameOrEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFantasyNameOrEmail.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasyNameOrEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.txtFantasyNameOrEmail.Location = new System.Drawing.Point(77, 297);
            this.txtFantasyNameOrEmail.MaxLength = 100;
            this.txtFantasyNameOrEmail.Name = "txtFantasyNameOrEmail";
            this.txtFantasyNameOrEmail.Size = new System.Drawing.Size(249, 26);
            this.txtFantasyNameOrEmail.TabIndex = 1;
            this.txtFantasyNameOrEmail.BackColorChanged += new System.EventHandler(this.txtUserName_BackColorChanged);
            this.txtFantasyNameOrEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFantasyNameOrEmail_KeyDown);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.labelUserName.Location = new System.Drawing.Point(73, 273);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(198, 27);
            this.labelUserName.TabIndex = 2;
            this.labelUserName.Text = "User name or Email";
            // 
            // labelUserPassword
            // 
            this.labelUserPassword.AutoSize = true;
            this.labelUserPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.labelUserPassword.Location = new System.Drawing.Point(73, 349);
            this.labelUserPassword.Name = "labelUserPassword";
            this.labelUserPassword.Size = new System.Drawing.Size(103, 27);
            this.labelUserPassword.TabIndex = 3;
            this.labelUserPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.txtPassword.Location = new System.Drawing.Point(77, 373);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(249, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.BackColorChanged += new System.EventHandler(this.txtUserPassword_BackColorChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.lblMessage.Location = new System.Drawing.Point(76, 513);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(116, 23);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "[lblMessage]";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picErrorForPassword
            // 
            this.picErrorForPassword.Image = global::FiyiStackApp.Properties.Resources.Cancel;
            this.picErrorForPassword.Location = new System.Drawing.Point(275, 350);
            this.picErrorForPassword.Name = "picErrorForPassword";
            this.picErrorForPassword.Size = new System.Drawing.Size(20, 20);
            this.picErrorForPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picErrorForPassword.TabIndex = 12;
            this.picErrorForPassword.TabStop = false;
            this.picErrorForPassword.Visible = false;
            // 
            // picErrorForFantasyNameOrEmail
            // 
            this.picErrorForFantasyNameOrEmail.Image = global::FiyiStackApp.Properties.Resources.Cancel;
            this.picErrorForFantasyNameOrEmail.Location = new System.Drawing.Point(306, 273);
            this.picErrorForFantasyNameOrEmail.Name = "picErrorForFantasyNameOrEmail";
            this.picErrorForFantasyNameOrEmail.Size = new System.Drawing.Size(20, 20);
            this.picErrorForFantasyNameOrEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picErrorForFantasyNameOrEmail.TabIndex = 11;
            this.picErrorForFantasyNameOrEmail.TabStop = false;
            this.picErrorForFantasyNameOrEmail.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Image = global::FiyiStackApp.Properties.Resources.btnLogin;
            this.btnLogin.Location = new System.Drawing.Point(150, 459);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 40);
            this.btnLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnLogin.TabIndex = 8;
            this.btnLogin.TabStop = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.btnLogin_Paint);
            // 
            // picProfilePicture
            // 
            this.picProfilePicture.Image = global::FiyiStackApp.Properties.Resources.User;
            this.picProfilePicture.Location = new System.Drawing.Point(328, 577);
            this.picProfilePicture.Name = "picProfilePicture";
            this.picProfilePicture.Size = new System.Drawing.Size(60, 60);
            this.picProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfilePicture.TabIndex = 6;
            this.picProfilePicture.TabStop = false;
            this.picProfilePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.picProfilePicture_Paint);
            // 
            // btnSeePassword
            // 
            this.btnSeePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeePassword.Image = global::FiyiStackApp.Properties.Resources.See;
            this.btnSeePassword.Location = new System.Drawing.Point(301, 345);
            this.btnSeePassword.Name = "btnSeePassword";
            this.btnSeePassword.Size = new System.Drawing.Size(25, 25);
            this.btnSeePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSeePassword.TabIndex = 5;
            this.btnSeePassword.TabStop = false;
            this.btnSeePassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSee_MouseDown);
            this.btnSeePassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSee_MouseUp);
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.picLogo.Image = global::FiyiStackApp.Properties.Resources.FiyiStackImageOnlyBlack1;
            this.picLogo.Location = new System.Drawing.Point(108, 30);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.Tag = "Logo";
            this.picLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogo_Paint);
            // 
            // chbRememberMe
            // 
            this.chbRememberMe.AutoSize = true;
            this.chbRememberMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chbRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbRememberMe.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.chbRememberMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.chbRememberMe.Location = new System.Drawing.Point(77, 400);
            this.chbRememberMe.Name = "chbRememberMe";
            this.chbRememberMe.Size = new System.Drawing.Size(175, 31);
            this.chbRememberMe.TabIndex = 15;
            this.chbRememberMe.Text = "Remember me";
            this.chbRememberMe.UseVisualStyleBackColor = true;
            this.chbRememberMe.CheckedChanged += new System.EventHandler(this.chbRememberMe_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(48)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(400, 552);
            this.Controls.Add(this.chbRememberMe);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.picErrorForPassword);
            this.Controls.Add(this.picErrorForFantasyNameOrEmail);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.picProfilePicture);
            this.Controls.Add(this.btnSeePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelUserPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.txtFantasyNameOrEmail);
            this.Controls.Add(this.picLogo);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiyiStack - Login";
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForFantasyNameOrEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.TextBox txtFantasyNameOrEmail;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox btnSeePassword;
        private System.Windows.Forms.PictureBox picProfilePicture;
        private System.Windows.Forms.PictureBox btnLogin;
        private System.Windows.Forms.PictureBox picErrorForFantasyNameOrEmail;
        private System.Windows.Forms.PictureBox picErrorForPassword;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox chbRememberMe;
    }
}