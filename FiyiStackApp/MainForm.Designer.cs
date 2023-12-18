
namespace FiyiStackApp
{
    partial class MainForm
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
            this.lblMessageDockedBottom = new System.Windows.Forms.Label();
            this.chbRememberMe = new System.Windows.Forms.CheckBox();
            this.MenuStripDockedTop = new System.Windows.Forms.MenuStrip();
            this.PanelDockedLeft = new System.Windows.Forms.Panel();
            this.PanelDockedCenter = new System.Windows.Forms.Panel();
            this.picImageLogin = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picErrorForPassword = new System.Windows.Forms.PictureBox();
            this.btnSeePassword = new System.Windows.Forms.PictureBox();
            this.picErrorForFantasyNameOrEmail = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.PictureBox();
            this.PanelLogin = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.PanelProject = new System.Windows.Forms.Panel();
            this.PanelDockedCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImageLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForFantasyNameOrEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            this.PanelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFantasyNameOrEmail
            // 
            this.txtFantasyNameOrEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.txtFantasyNameOrEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFantasyNameOrEmail.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFantasyNameOrEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.txtFantasyNameOrEmail.Location = new System.Drawing.Point(23, 352);
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
            this.labelUserName.Location = new System.Drawing.Point(19, 328);
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
            this.labelUserPassword.Location = new System.Drawing.Point(19, 404);
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
            this.txtPassword.Location = new System.Drawing.Point(23, 428);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(249, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.BackColorChanged += new System.EventHandler(this.txtUserPassword_BackColorChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblMessageDockedBottom
            // 
            this.lblMessageDockedBottom.AutoSize = true;
            this.lblMessageDockedBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessageDockedBottom.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageDockedBottom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.lblMessageDockedBottom.Location = new System.Drawing.Point(0, 809);
            this.lblMessageDockedBottom.Name = "lblMessageDockedBottom";
            this.lblMessageDockedBottom.Size = new System.Drawing.Size(116, 23);
            this.lblMessageDockedBottom.TabIndex = 13;
            this.lblMessageDockedBottom.Text = "[lblMessage]";
            this.lblMessageDockedBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbRememberMe
            // 
            this.chbRememberMe.AutoSize = true;
            this.chbRememberMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chbRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbRememberMe.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.chbRememberMe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.chbRememberMe.Location = new System.Drawing.Point(23, 455);
            this.chbRememberMe.Name = "chbRememberMe";
            this.chbRememberMe.Size = new System.Drawing.Size(175, 31);
            this.chbRememberMe.TabIndex = 15;
            this.chbRememberMe.Text = "Remember me";
            this.chbRememberMe.UseVisualStyleBackColor = true;
            this.chbRememberMe.CheckedChanged += new System.EventHandler(this.chbRememberMe_CheckedChanged);
            // 
            // MenuStripDockedTop
            // 
            this.MenuStripDockedTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStripDockedTop.Location = new System.Drawing.Point(0, 0);
            this.MenuStripDockedTop.Name = "MenuStripDockedTop";
            this.MenuStripDockedTop.Size = new System.Drawing.Size(1367, 24);
            this.MenuStripDockedTop.TabIndex = 16;
            this.MenuStripDockedTop.Text = "menuStrip1";
            // 
            // PanelDockedLeft
            // 
            this.PanelDockedLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelDockedLeft.Location = new System.Drawing.Point(0, 24);
            this.PanelDockedLeft.Name = "PanelDockedLeft";
            this.PanelDockedLeft.Size = new System.Drawing.Size(154, 785);
            this.PanelDockedLeft.TabIndex = 17;
            // 
            // PanelDockedCenter
            // 
            this.PanelDockedCenter.Controls.Add(this.PanelProject);
            this.PanelDockedCenter.Controls.Add(this.lblSubtitle);
            this.PanelDockedCenter.Controls.Add(this.lblTitle);
            this.PanelDockedCenter.Controls.Add(this.PanelLogin);
            this.PanelDockedCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDockedCenter.Location = new System.Drawing.Point(154, 24);
            this.PanelDockedCenter.Name = "PanelDockedCenter";
            this.PanelDockedCenter.Size = new System.Drawing.Size(1213, 785);
            this.PanelDockedCenter.TabIndex = 19;
            // 
            // picImageLogin
            // 
            this.picImageLogin.Image = global::FiyiStackApp.Properties.Resources.ImageLogin;
            this.picImageLogin.InitialImage = null;
            this.picImageLogin.Location = new System.Drawing.Point(290, 18);
            this.picImageLogin.Name = "picImageLogin";
            this.picImageLogin.Size = new System.Drawing.Size(884, 587);
            this.picImageLogin.TabIndex = 16;
            this.picImageLogin.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.picLogo.Image = global::FiyiStackApp.Properties.Resources.FiyiStackImageOnlyBlack1;
            this.picLogo.Location = new System.Drawing.Point(72, 70);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.Tag = "Logo";
            this.picLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.picLogo_Paint);
            // 
            // picErrorForPassword
            // 
            this.picErrorForPassword.Image = global::FiyiStackApp.Properties.Resources.Cancel;
            this.picErrorForPassword.Location = new System.Drawing.Point(221, 405);
            this.picErrorForPassword.Name = "picErrorForPassword";
            this.picErrorForPassword.Size = new System.Drawing.Size(20, 20);
            this.picErrorForPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picErrorForPassword.TabIndex = 12;
            this.picErrorForPassword.TabStop = false;
            this.picErrorForPassword.Visible = false;
            // 
            // btnSeePassword
            // 
            this.btnSeePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeePassword.Image = global::FiyiStackApp.Properties.Resources.See;
            this.btnSeePassword.Location = new System.Drawing.Point(247, 400);
            this.btnSeePassword.Name = "btnSeePassword";
            this.btnSeePassword.Size = new System.Drawing.Size(25, 25);
            this.btnSeePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSeePassword.TabIndex = 5;
            this.btnSeePassword.TabStop = false;
            this.btnSeePassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSee_MouseDown);
            this.btnSeePassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSee_MouseUp);
            // 
            // picErrorForFantasyNameOrEmail
            // 
            this.picErrorForFantasyNameOrEmail.Image = global::FiyiStackApp.Properties.Resources.Cancel;
            this.picErrorForFantasyNameOrEmail.Location = new System.Drawing.Point(252, 328);
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
            this.btnLogin.Location = new System.Drawing.Point(152, 511);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 40);
            this.btnLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnLogin.TabIndex = 8;
            this.btnLogin.TabStop = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.btnLogin_Paint);
            // 
            // PanelLogin
            // 
            this.PanelLogin.Controls.Add(this.picImageLogin);
            this.PanelLogin.Controls.Add(this.picLogo);
            this.PanelLogin.Controls.Add(this.txtFantasyNameOrEmail);
            this.PanelLogin.Controls.Add(this.labelUserName);
            this.PanelLogin.Controls.Add(this.chbRememberMe);
            this.PanelLogin.Controls.Add(this.labelUserPassword);
            this.PanelLogin.Controls.Add(this.txtPassword);
            this.PanelLogin.Controls.Add(this.picErrorForPassword);
            this.PanelLogin.Controls.Add(this.btnSeePassword);
            this.PanelLogin.Controls.Add(this.picErrorForFantasyNameOrEmail);
            this.PanelLogin.Controls.Add(this.btnLogin);
            this.PanelLogin.Location = new System.Drawing.Point(1014, 184);
            this.PanelLogin.Name = "PanelLogin";
            this.PanelLogin.Size = new System.Drawing.Size(1195, 624);
            this.PanelLogin.TabIndex = 17;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.lblTitle.Location = new System.Drawing.Point(32, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 63);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "lblTitle";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.lblSubtitle.Location = new System.Drawing.Point(36, 69);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(123, 34);
            this.lblSubtitle.TabIndex = 19;
            this.lblSubtitle.Text = "lblSubtitle";
            // 
            // PanelProject
            // 
            this.PanelProject.Location = new System.Drawing.Point(782, 485);
            this.PanelProject.Name = "PanelProject";
            this.PanelProject.Size = new System.Drawing.Size(1494, 780);
            this.PanelProject.TabIndex = 20;
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(48)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1367, 832);
            this.Controls.Add(this.PanelDockedCenter);
            this.Controls.Add(this.PanelDockedLeft);
            this.Controls.Add(this.lblMessageDockedBottom);
            this.Controls.Add(this.MenuStripDockedTop);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStripDockedTop;
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "LoginForm";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiyiStack - Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanelDockedCenter.ResumeLayout(false);
            this.PanelDockedCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImageLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSeePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForFantasyNameOrEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            this.PanelLogin.ResumeLayout(false);
            this.PanelLogin.PerformLayout();
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
        private System.Windows.Forms.PictureBox btnLogin;
        private System.Windows.Forms.PictureBox picErrorForFantasyNameOrEmail;
        private System.Windows.Forms.PictureBox picErrorForPassword;
        private System.Windows.Forms.Label lblMessageDockedBottom;
        private System.Windows.Forms.CheckBox chbRememberMe;
        private MenuStrip MenuStripDockedTop;
        private Panel PanelDockedLeft;
        private Panel PanelDockedCenter;
        private PictureBox picImageLogin;
        private Panel PanelLogin;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel PanelProject;
    }
}