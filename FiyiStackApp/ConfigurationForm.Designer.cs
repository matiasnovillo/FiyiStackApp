
namespace FiyiStackApp
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.PanelDatabaseConfiguration = new System.Windows.Forms.Panel();
            this.chbclonedConfigurationDeleteTable = new System.Windows.Forms.CheckBox();
            this.chbclonedConfigurationDeleteField = new System.Windows.Forms.CheckBox();
            this.chbclonedConfigurationDeleteStoredProcedure = new System.Windows.Forms.CheckBox();
            this.chbclonedConfigurationAddAuditingFieldsToNewTable = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.labelPathFiles = new System.Windows.Forms.Label();
            this.PanelPathFilesConfiguration = new System.Windows.Forms.Panel();
            this.ListViewFrontEndFilesGenerators = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListViewBackEndFilesGenerators = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chbclonedConfigurationDeleteFiles = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picStep2PathFiles = new System.Windows.Forms.PictureBox();
            this.picStep1Databases = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.PanelDatabaseConfiguration.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.PanelPathFilesConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStep2PathFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep1Databases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelDatabaseConfiguration
            // 
            this.PanelDatabaseConfiguration.Controls.Add(this.chbclonedConfigurationDeleteTable);
            this.PanelDatabaseConfiguration.Controls.Add(this.chbclonedConfigurationDeleteField);
            this.PanelDatabaseConfiguration.Controls.Add(this.chbclonedConfigurationDeleteStoredProcedure);
            this.PanelDatabaseConfiguration.Controls.Add(this.chbclonedConfigurationAddAuditingFieldsToNewTable);
            this.PanelDatabaseConfiguration.Controls.Add(this.label17);
            this.PanelDatabaseConfiguration.Controls.Add(this.label14);
            this.PanelDatabaseConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PanelDatabaseConfiguration.Location = new System.Drawing.Point(787, 490);
            this.PanelDatabaseConfiguration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelDatabaseConfiguration.Name = "PanelDatabaseConfiguration";
            this.PanelDatabaseConfiguration.Size = new System.Drawing.Size(565, 428);
            this.PanelDatabaseConfiguration.TabIndex = 93;
            // 
            // chbclonedConfigurationDeleteTable
            // 
            this.chbclonedConfigurationDeleteTable.AutoSize = true;
            this.chbclonedConfigurationDeleteTable.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.chbclonedConfigurationDeleteTable.Location = new System.Drawing.Point(0, 119);
            this.chbclonedConfigurationDeleteTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chbclonedConfigurationDeleteTable.Name = "chbclonedConfigurationDeleteTable";
            this.chbclonedConfigurationDeleteTable.Size = new System.Drawing.Size(154, 29);
            this.chbclonedConfigurationDeleteTable.TabIndex = 115;
            this.chbclonedConfigurationDeleteTable.Text = "Delete tables";
            this.chbclonedConfigurationDeleteTable.UseVisualStyleBackColor = true;
            // 
            // chbclonedConfigurationDeleteField
            // 
            this.chbclonedConfigurationDeleteField.AutoSize = true;
            this.chbclonedConfigurationDeleteField.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.chbclonedConfigurationDeleteField.Location = new System.Drawing.Point(0, 150);
            this.chbclonedConfigurationDeleteField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chbclonedConfigurationDeleteField.Name = "chbclonedConfigurationDeleteField";
            this.chbclonedConfigurationDeleteField.Size = new System.Drawing.Size(148, 29);
            this.chbclonedConfigurationDeleteField.TabIndex = 114;
            this.chbclonedConfigurationDeleteField.Text = "Delete fields";
            this.chbclonedConfigurationDeleteField.UseVisualStyleBackColor = true;
            // 
            // chbclonedConfigurationDeleteStoredProcedure
            // 
            this.chbclonedConfigurationDeleteStoredProcedure.AutoSize = true;
            this.chbclonedConfigurationDeleteStoredProcedure.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.chbclonedConfigurationDeleteStoredProcedure.Location = new System.Drawing.Point(0, 180);
            this.chbclonedConfigurationDeleteStoredProcedure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chbclonedConfigurationDeleteStoredProcedure.Name = "chbclonedConfigurationDeleteStoredProcedure";
            this.chbclonedConfigurationDeleteStoredProcedure.Size = new System.Drawing.Size(266, 29);
            this.chbclonedConfigurationDeleteStoredProcedure.TabIndex = 112;
            this.chbclonedConfigurationDeleteStoredProcedure.Text = "Delete stored procedures";
            this.chbclonedConfigurationDeleteStoredProcedure.UseVisualStyleBackColor = true;
            // 
            // chbclonedConfigurationAddAuditingFieldsToNewTable
            // 
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.AutoSize = true;
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.Location = new System.Drawing.Point(0, 23);
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.Name = "chbclonedConfigurationAddAuditingFieldsToNewTable";
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.Size = new System.Drawing.Size(208, 29);
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.TabIndex = 111;
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.Text = "Add auditing fields";
            this.chbclonedConfigurationAddAuditingFieldsToNewTable.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label17.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.label17.Location = new System.Drawing.Point(-5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(252, 26);
            this.label17.TabIndex = 110;
            this.label17.Text = "During creation of tables";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.label14.Location = new System.Drawing.Point(-5, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(330, 26);
            this.label14.TabIndex = 109;
            this.label14.Text = "During replacements in database";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label26.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.label26.Location = new System.Drawing.Point(-4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(147, 26);
            this.label26.TabIndex = 177;
            this.label26.Text = "Back-end files";
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 996);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1364, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 94;
            this.StatusStrip.Click += new System.EventHandler(this.StatusStrip_Click);
            // 
            // ToolStatusLabel
            // 
            this.ToolStatusLabel.Name = "ToolStatusLabel";
            this.ToolStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDataBase.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelDataBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelDataBase.Location = new System.Drawing.Point(65, 15);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(155, 36);
            this.labelDataBase.TabIndex = 101;
            this.labelDataBase.Text = "Databases";
            this.labelDataBase.Click += new System.EventHandler(this.labelDataBase_Click);
            // 
            // labelPathFiles
            // 
            this.labelPathFiles.AutoSize = true;
            this.labelPathFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPathFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelPathFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelPathFiles.Location = new System.Drawing.Point(65, 65);
            this.labelPathFiles.Name = "labelPathFiles";
            this.labelPathFiles.Size = new System.Drawing.Size(141, 36);
            this.labelPathFiles.TabIndex = 102;
            this.labelPathFiles.Text = "Path files";
            this.labelPathFiles.Click += new System.EventHandler(this.labelBackEnd_Click);
            // 
            // PanelPathFilesConfiguration
            // 
            this.PanelPathFilesConfiguration.Controls.Add(this.ListViewFrontEndFilesGenerators);
            this.PanelPathFilesConfiguration.Controls.Add(this.ListViewBackEndFilesGenerators);
            this.PanelPathFilesConfiguration.Controls.Add(this.chbclonedConfigurationDeleteFiles);
            this.PanelPathFilesConfiguration.Controls.Add(this.label4);
            this.PanelPathFilesConfiguration.Controls.Add(this.label3);
            this.PanelPathFilesConfiguration.Controls.Add(this.label26);
            this.PanelPathFilesConfiguration.Location = new System.Drawing.Point(648, 12);
            this.PanelPathFilesConfiguration.Name = "PanelPathFilesConfiguration";
            this.PanelPathFilesConfiguration.Size = new System.Drawing.Size(686, 442);
            this.PanelPathFilesConfiguration.TabIndex = 162;
            // 
            // ListViewFrontEndFilesGenerators
            // 
            this.ListViewFrontEndFilesGenerators.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewFrontEndFilesGenerators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ListViewFrontEndFilesGenerators.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewFrontEndFilesGenerators.CheckBoxes = true;
            this.ListViewFrontEndFilesGenerators.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ListViewFrontEndFilesGenerators.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListViewFrontEndFilesGenerators.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.ListViewFrontEndFilesGenerators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.ListViewFrontEndFilesGenerators.FullRowSelect = true;
            this.ListViewFrontEndFilesGenerators.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewFrontEndFilesGenerators.HideSelection = false;
            this.ListViewFrontEndFilesGenerators.Location = new System.Drawing.Point(1, 226);
            this.ListViewFrontEndFilesGenerators.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewFrontEndFilesGenerators.MultiSelect = false;
            this.ListViewFrontEndFilesGenerators.Name = "ListViewFrontEndFilesGenerators";
            this.ListViewFrontEndFilesGenerators.ShowGroups = false;
            this.ListViewFrontEndFilesGenerators.ShowItemToolTips = true;
            this.ListViewFrontEndFilesGenerators.Size = new System.Drawing.Size(661, 138);
            this.ListViewFrontEndFilesGenerators.TabIndex = 160;
            this.ListViewFrontEndFilesGenerators.TileSize = new System.Drawing.Size(50, 50);
            this.ListViewFrontEndFilesGenerators.UseCompatibleStateImageBehavior = false;
            this.ListViewFrontEndFilesGenerators.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // ListViewBackEndFilesGenerators
            // 
            this.ListViewBackEndFilesGenerators.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewBackEndFilesGenerators.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ListViewBackEndFilesGenerators.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewBackEndFilesGenerators.CheckBoxes = true;
            this.ListViewBackEndFilesGenerators.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.ListViewBackEndFilesGenerators.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListViewBackEndFilesGenerators.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.ListViewBackEndFilesGenerators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.ListViewBackEndFilesGenerators.FullRowSelect = true;
            this.ListViewBackEndFilesGenerators.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewBackEndFilesGenerators.HideSelection = false;
            this.ListViewBackEndFilesGenerators.Location = new System.Drawing.Point(1, 30);
            this.ListViewBackEndFilesGenerators.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewBackEndFilesGenerators.MultiSelect = false;
            this.ListViewBackEndFilesGenerators.Name = "ListViewBackEndFilesGenerators";
            this.ListViewBackEndFilesGenerators.ShowGroups = false;
            this.ListViewBackEndFilesGenerators.ShowItemToolTips = true;
            this.ListViewBackEndFilesGenerators.Size = new System.Drawing.Size(661, 138);
            this.ListViewBackEndFilesGenerators.TabIndex = 159;
            this.ListViewBackEndFilesGenerators.TileSize = new System.Drawing.Size(50, 50);
            this.ListViewBackEndFilesGenerators.UseCompatibleStateImageBehavior = false;
            this.ListViewBackEndFilesGenerators.View = System.Windows.Forms.View.SmallIcon;
            this.ListViewBackEndFilesGenerators.BackColorChanged += new System.EventHandler(this.ListViewGenerators_BackColorChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 200;
            // 
            // chbclonedConfigurationDeleteFiles
            // 
            this.chbclonedConfigurationDeleteFiles.AutoSize = true;
            this.chbclonedConfigurationDeleteFiles.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.chbclonedConfigurationDeleteFiles.Location = new System.Drawing.Point(2, 413);
            this.chbclonedConfigurationDeleteFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chbclonedConfigurationDeleteFiles.Name = "chbclonedConfigurationDeleteFiles";
            this.chbclonedConfigurationDeleteFiles.Size = new System.Drawing.Size(136, 29);
            this.chbclonedConfigurationDeleteFiles.TabIndex = 190;
            this.chbclonedConfigurationDeleteFiles.Text = "Delete files";
            this.chbclonedConfigurationDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.label4.Location = new System.Drawing.Point(-3, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(375, 26);
            this.label4.TabIndex = 189;
            this.label4.Text = "During replacements in project folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.label3.Location = new System.Drawing.Point(-4, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 26);
            this.label3.TabIndex = 188;
            this.label3.Text = "Front-end files";
            // 
            // picStep2PathFiles
            // 
            this.picStep2PathFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStep2PathFiles.ErrorImage = null;
            this.picStep2PathFiles.Image = ((System.Drawing.Image)(resources.GetObject("picStep2PathFiles.Image")));
            this.picStep2PathFiles.Location = new System.Drawing.Point(29, 63);
            this.picStep2PathFiles.Name = "picStep2PathFiles";
            this.picStep2PathFiles.Size = new System.Drawing.Size(30, 30);
            this.picStep2PathFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStep2PathFiles.TabIndex = 106;
            this.picStep2PathFiles.TabStop = false;
            // 
            // picStep1Databases
            // 
            this.picStep1Databases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStep1Databases.ErrorImage = null;
            this.picStep1Databases.Image = ((System.Drawing.Image)(resources.GetObject("picStep1Databases.Image")));
            this.picStep1Databases.Location = new System.Drawing.Point(29, 13);
            this.picStep1Databases.Name = "picStep1Databases";
            this.picStep1Databases.Size = new System.Drawing.Size(30, 30);
            this.picStep1Databases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStep1Databases.TabIndex = 105;
            this.picStep1Databases.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = global::FiyiStackApp.Properties.Resources.btnEdit;
            this.btnSave.Location = new System.Drawing.Point(29, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 161;
            this.btnSave.TabStop = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSave_Paint);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(48)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1364, 1018);
            this.Controls.Add(this.labelDataBase);
            this.Controls.Add(this.labelPathFiles);
            this.Controls.Add(this.PanelPathFilesConfiguration);
            this.Controls.Add(this.picStep2PathFiles);
            this.Controls.Add(this.picStep1Databases);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.PanelDatabaseConfiguration);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.MaximizeBox = false;
            this.Name = "ConfigurationForm";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiyiStack - Configuration";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ConfigurationForm_MouseMove);
            this.PanelDatabaseConfiguration.ResumeLayout(false);
            this.PanelDatabaseConfiguration.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.PanelPathFilesConfiguration.ResumeLayout(false);
            this.PanelPathFilesConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStep2PathFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep1Databases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelDatabaseConfiguration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chbclonedConfigurationDeleteTable;
        private System.Windows.Forms.CheckBox chbclonedConfigurationDeleteField;
        private System.Windows.Forms.CheckBox chbclonedConfigurationDeleteStoredProcedure;
        private System.Windows.Forms.CheckBox chbclonedConfigurationAddAuditingFieldsToNewTable;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStatusLabel;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.Label labelPathFiles;
        private System.Windows.Forms.PictureBox picStep2PathFiles;
        private System.Windows.Forms.PictureBox picStep1Databases;
        private System.Windows.Forms.Panel PanelPathFilesConfiguration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbclonedConfigurationDeleteFiles;
        private System.Windows.Forms.Label label4;
        private ListView ListViewBackEndFilesGenerators;
        private ColumnHeader columnHeader2;
        private ListView ListViewFrontEndFilesGenerators;
        private ColumnHeader columnHeader1;
    }
}