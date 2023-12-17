namespace FiyiStackApp
{
    partial class ChangeUserData
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
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.labelChangePassword = new System.Windows.Forms.Label();
            this.btnEditUserData = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewEmail = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditUserData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtNewPassword.Location = new System.Drawing.Point(47, 64);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.MaxLength = 100;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(332, 26);
            this.txtNewPassword.TabIndex = 6;
            // 
            // labelChangePassword
            // 
            this.labelChangePassword.AutoSize = true;
            this.labelChangePassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelChangePassword.Location = new System.Drawing.Point(42, 33);
            this.labelChangePassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChangePassword.Name = "labelChangePassword";
            this.labelChangePassword.Size = new System.Drawing.Size(153, 27);
            this.labelChangePassword.TabIndex = 7;
            this.labelChangePassword.Text = "New password";
            // 
            // btnEditUserData
            // 
            this.btnEditUserData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUserData.Image = global::FiyiStackApp.Properties.Resources.btnEdit;
            this.btnEditUserData.Location = new System.Drawing.Point(219, 277);
            this.btnEditUserData.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditUserData.Name = "btnEditUserData";
            this.btnEditUserData.Size = new System.Drawing.Size(160, 49);
            this.btnEditUserData.TabIndex = 8;
            this.btnEditUserData.TabStop = false;
            this.btnEditUserData.Click += new System.EventHandler(this.btnEditUserData_Click);
            this.btnEditUserData.Paint += new System.Windows.Forms.PaintEventHandler(this.btnEditPassword_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label1.Location = new System.Drawing.Point(42, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "New user name";
            // 
            // txtNewUserName
            // 
            this.txtNewUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtNewUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewUserName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtNewUserName.Location = new System.Drawing.Point(47, 141);
            this.txtNewUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewUserName.MaxLength = 100;
            this.txtNewUserName.Name = "txtNewUserName";
            this.txtNewUserName.Size = new System.Drawing.Size(332, 26);
            this.txtNewUserName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label2.Location = new System.Drawing.Point(42, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 12;
            this.label2.Text = "New email";
            // 
            // txtNewEmail
            // 
            this.txtNewEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtNewEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewEmail.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtNewEmail.Location = new System.Drawing.Point(47, 220);
            this.txtNewEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewEmail.MaxLength = 100;
            this.txtNewEmail.Name = "txtNewEmail";
            this.txtNewEmail.Size = new System.Drawing.Size(332, 26);
            this.txtNewEmail.TabIndex = 11;
            // 
            // ChangeUserData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(48)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(427, 339);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewUserName);
            this.Controls.Add(this.btnEditUserData);
            this.Controls.Add(this.labelChangePassword);
            this.Controls.Add(this.txtNewPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeUserData";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change user data";
            ((System.ComponentModel.ISupportInitialize)(this.btnEditUserData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtNewPassword;
        private Label labelChangePassword;
        private PictureBox btnEditUserData;
        private Label label1;
        private TextBox txtNewUserName;
        private Label label2;
        private TextBox txtNewEmail;
    }
}