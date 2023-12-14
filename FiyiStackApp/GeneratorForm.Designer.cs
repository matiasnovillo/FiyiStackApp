
namespace FiyiStackApp
{
    partial class GeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorForm));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToProjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDataBase = new System.Windows.Forms.Label();
            this.ListViewDatabase = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.ListViewTable = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTables = new System.Windows.Forms.Label();
            this.labelFields = new System.Windows.Forms.Label();
            this.lblActionDatabase = new System.Windows.Forms.Label();
            this.ListViewField = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PanelForeignKey = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtForeignTableName = new System.Windows.Forms.TextBox();
            this.PanelBoolean = new System.Windows.Forms.Panel();
            this.PanelPrimaryKey = new System.Windows.Forms.Panel();
            this.PanelDecimal = new System.Windows.Forms.Panel();
            this.txtDecimalMax = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDecimalMin = new System.Windows.Forms.NumericUpDown();
            this.picErrorForDecimalMin = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PanelHexColour = new System.Windows.Forms.Panel();
            this.txtHexColourMax = new System.Windows.Forms.TextBox();
            this.txtHexColourMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PanelTime = new System.Windows.Forms.Panel();
            this.txtTimeSpanMax = new System.Windows.Forms.TextBox();
            this.txtTimeSpanMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelDateTime = new System.Windows.Forms.Panel();
            this.DatePickerMax = new System.Windows.Forms.DateTimePicker();
            this.TimePickerMin = new System.Windows.Forms.DateTimePicker();
            this.TimePickerMax = new System.Windows.Forms.DateTimePicker();
            this.DatePickerMin = new System.Windows.Forms.DateTimePicker();
            this.txtDateTimeMax = new System.Windows.Forms.TextBox();
            this.txtDateTimeMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PanelInteger = new System.Windows.Forms.Panel();
            this.txtIntMax = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntMin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelText = new System.Windows.Forms.Panel();
            this.txtTextMax = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTextMin = new System.Windows.Forms.NumericUpDown();
            this.labelStringRegex = new System.Windows.Forms.Label();
            this.txtTextRegex = new System.Windows.Forms.TextBox();
            this.labelStringLength = new System.Windows.Forms.Label();
            this.labelDataType = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.labelFieldHistoryUser = new System.Windows.Forms.Label();
            this.txtFieldHistoryUser = new System.Windows.Forms.TextBox();
            this.labelFieldName = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.PanelSummary = new System.Windows.Forms.Panel();
            this.TextBoxLogger = new System.Windows.Forms.TextBox();
            this.btnHidePanelSummary = new System.Windows.Forms.PictureBox();
            this.PanelDatabase = new System.Windows.Forms.Panel();
            this.btnCopyDBProduction = new System.Windows.Forms.PictureBox();
            this.btnCopyDBLocalhost = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PropertyGridDatabase = new System.Windows.Forms.PropertyGrid();
            this.btnRefreshDataBases = new System.Windows.Forms.PictureBox();
            this.picAddDataBase = new System.Windows.Forms.PictureBox();
            this.btnDeleteDataBases = new System.Windows.Forms.PictureBox();
            this.btnAddDatabase = new System.Windows.Forms.PictureBox();
            this.PanelTable = new System.Windows.Forms.Panel();
            this.lblActionTable = new System.Windows.Forms.Label();
            this.PropertyGridTable = new System.Windows.Forms.PropertyGrid();
            this.btnRefreshTables = new System.Windows.Forms.PictureBox();
            this.AddTableButton = new System.Windows.Forms.PictureBox();
            this.btnSelectAllTable = new System.Windows.Forms.PictureBox();
            this.btnAddTable = new System.Windows.Forms.PictureBox();
            this.btnDeleteTables = new System.Windows.Forms.PictureBox();
            this.PanelField = new System.Windows.Forms.Panel();
            this.btnRefreshFields = new System.Windows.Forms.PictureBox();
            this.picAddFieldButton = new System.Windows.Forms.PictureBox();
            this.btnSelectAllField = new System.Windows.Forms.PictureBox();
            this.chbNullable = new System.Windows.Forms.CheckBox();
            this.picDataType = new System.Windows.Forms.PictureBox();
            this.btnDeleteField = new System.Windows.Forms.PictureBox();
            this.btnAddField = new System.Windows.Forms.PictureBox();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.btnShowConfigurationForm = new System.Windows.Forms.PictureBox();
            this.picStep3Properties = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.PictureBox();
            this.picStep2Tables = new System.Windows.Forms.PictureBox();
            this.picStep1Databases = new System.Windows.Forms.PictureBox();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.PanelForeignKey.SuspendLayout();
            this.PanelDecimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecimalMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecimalMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForDecimalMin)).BeginInit();
            this.PanelHexColour.SuspendLayout();
            this.PanelTime.SuspendLayout();
            this.PanelDateTime.SuspendLayout();
            this.PanelInteger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntMin)).BeginInit();
            this.PanelText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextMin)).BeginInit();
            this.PanelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHidePanelSummary)).BeginInit();
            this.PanelDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyDBProduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyDBLocalhost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshDataBases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddDataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteDataBases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDatabase)).BeginInit();
            this.PanelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddTableButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectAllTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTables)).BeginInit();
            this.PanelField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddFieldButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectAllField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDataType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddField)).BeginInit();
            this.PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowConfigurationForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep3Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep2Tables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep1Databases)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.MenuStrip.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.projectToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(1751, 33);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(34, 29);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToProjectsToolStripMenuItem});
            this.projectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // goToProjectsToolStripMenuItem
            // 
            this.goToProjectsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.goToProjectsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.goToProjectsToolStripMenuItem.Name = "goToProjectsToolStripMenuItem";
            this.goToProjectsToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.goToProjectsToolStripMenuItem.Text = "Go to Projects";
            this.goToProjectsToolStripMenuItem.Click += new System.EventHandler(this.goToProjectsToolStripMenuItem_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 650);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1751, 26);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Click += new System.EventHandler(this.StatusStrip_Click);
            // 
            // ToolStatusLabel
            // 
            this.ToolStatusLabel.ForeColor = System.Drawing.Color.White;
            this.ToolStatusLabel.Name = "ToolStatusLabel";
            this.ToolStatusLabel.Size = new System.Drawing.Size(114, 20);
            this.ToolStatusLabel.Text = "ToolStatusLabel";
            // 
            // labelDataBase
            // 
            this.labelDataBase.AutoSize = true;
            this.labelDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDataBase.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelDataBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelDataBase.Location = new System.Drawing.Point(52, 4);
            this.labelDataBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataBase.Name = "labelDataBase";
            this.labelDataBase.Size = new System.Drawing.Size(155, 36);
            this.labelDataBase.TabIndex = 62;
            this.labelDataBase.Text = "Databases";
            this.labelDataBase.Click += new System.EventHandler(this.labelDataBase_Click);
            // 
            // ListViewDatabase
            // 
            this.ListViewDatabase.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ListViewDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewDatabase.CheckBoxes = true;
            this.ListViewDatabase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ListViewDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListViewDatabase.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.ListViewDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.ListViewDatabase.FullRowSelect = true;
            this.ListViewDatabase.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewDatabase.HideSelection = false;
            this.ListViewDatabase.Location = new System.Drawing.Point(0, 0);
            this.ListViewDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewDatabase.MultiSelect = false;
            this.ListViewDatabase.Name = "ListViewDatabase";
            this.ListViewDatabase.ShowGroups = false;
            this.ListViewDatabase.ShowItemToolTips = true;
            this.ListViewDatabase.Size = new System.Drawing.Size(296, 335);
            this.ListViewDatabase.SmallImageList = this.ImageList;
            this.ListViewDatabase.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListViewDatabase.TabIndex = 63;
            this.ListViewDatabase.TileSize = new System.Drawing.Size(50, 50);
            this.ListViewDatabase.UseCompatibleStateImageBehavior = false;
            this.ListViewDatabase.View = System.Windows.Forms.View.List;
            this.ListViewDatabase.ItemActivate += new System.EventHandler(this.ListViewDataBase_ItemActivate);
            this.ListViewDatabase.BackColorChanged += new System.EventHandler(this.ListViewDataBase_BackColorChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "OKNegative.png");
            this.ImageList.Images.SetKeyName(1, "Upload1.png");
            this.ImageList.Images.SetKeyName(2, "NotSee1.png");
            this.ImageList.Images.SetKeyName(3, "DownloadNegative1.png");
            this.ImageList.Images.SetKeyName(4, "DataTypeInteger1.png");
            this.ImageList.Images.SetKeyName(5, "DataTypeBoolean1.png");
            this.ImageList.Images.SetKeyName(6, "DataTypeText1.png");
            this.ImageList.Images.SetKeyName(7, "DataTypeDecimal1.png");
            this.ImageList.Images.SetKeyName(8, "DataTypePK1.png");
            this.ImageList.Images.SetKeyName(9, "DataTypeDateTime1.png");
            this.ImageList.Images.SetKeyName(10, "DataTypeTime1.png");
            this.ImageList.Images.SetKeyName(11, "DataTypeFK1.png");
            this.ImageList.Images.SetKeyName(12, "DataTypeHexColour1.png");
            // 
            // ListViewTable
            // 
            this.ListViewTable.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ListViewTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewTable.CheckBoxes = true;
            this.ListViewTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.ListViewTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListViewTable.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.ListViewTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.ListViewTable.FullRowSelect = true;
            this.ListViewTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewTable.HideSelection = false;
            this.ListViewTable.Location = new System.Drawing.Point(0, 0);
            this.ListViewTable.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewTable.MultiSelect = false;
            this.ListViewTable.Name = "ListViewTable";
            this.ListViewTable.ShowGroups = false;
            this.ListViewTable.ShowItemToolTips = true;
            this.ListViewTable.Size = new System.Drawing.Size(488, 335);
            this.ListViewTable.SmallImageList = this.ImageList;
            this.ListViewTable.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListViewTable.TabIndex = 68;
            this.ListViewTable.TileSize = new System.Drawing.Size(50, 50);
            this.ListViewTable.UseCompatibleStateImageBehavior = false;
            this.ListViewTable.View = System.Windows.Forms.View.SmallIcon;
            this.ListViewTable.ItemActivate += new System.EventHandler(this.ListViewTable_ItemActivate);
            this.ListViewTable.BackColorChanged += new System.EventHandler(this.ListViewTable_BackColorChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 200;
            // 
            // labelTables
            // 
            this.labelTables.AutoSize = true;
            this.labelTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelTables.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelTables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelTables.Location = new System.Drawing.Point(52, 66);
            this.labelTables.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTables.Name = "labelTables";
            this.labelTables.Size = new System.Drawing.Size(103, 36);
            this.labelTables.TabIndex = 67;
            this.labelTables.Text = "Tables";
            this.labelTables.Click += new System.EventHandler(this.labelTables_Click);
            // 
            // labelFields
            // 
            this.labelFields.AutoSize = true;
            this.labelFields.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFields.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelFields.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelFields.Location = new System.Drawing.Point(52, 124);
            this.labelFields.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFields.Name = "labelFields";
            this.labelFields.Size = new System.Drawing.Size(135, 36);
            this.labelFields.TabIndex = 76;
            this.labelFields.Text = "Columns";
            this.labelFields.Click += new System.EventHandler(this.labelFields_Click);
            // 
            // lblActionDatabase
            // 
            this.lblActionDatabase.AutoSize = true;
            this.lblActionDatabase.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.lblActionDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.lblActionDatabase.Location = new System.Drawing.Point(326, 0);
            this.lblActionDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActionDatabase.Name = "lblActionDatabase";
            this.lblActionDatabase.Size = new System.Drawing.Size(52, 27);
            this.lblActionDatabase.TabIndex = 85;
            this.lblActionDatabase.Text = "Add";
            // 
            // ListViewField
            // 
            this.ListViewField.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.ListViewField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewField.CheckBoxes = true;
            this.ListViewField.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.ListViewField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListViewField.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.ListViewField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.ListViewField.FullRowSelect = true;
            this.ListViewField.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewField.HideSelection = false;
            this.ListViewField.Location = new System.Drawing.Point(0, 0);
            this.ListViewField.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewField.MultiSelect = false;
            this.ListViewField.Name = "ListViewField";
            this.ListViewField.ShowGroups = false;
            this.ListViewField.ShowItemToolTips = true;
            this.ListViewField.Size = new System.Drawing.Size(296, 335);
            this.ListViewField.SmallImageList = this.ImageList;
            this.ListViewField.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListViewField.TabIndex = 86;
            this.ListViewField.TileSize = new System.Drawing.Size(50, 50);
            this.ListViewField.UseCompatibleStateImageBehavior = false;
            this.ListViewField.View = System.Windows.Forms.View.SmallIcon;
            this.ListViewField.ItemActivate += new System.EventHandler(this.ListViewField_ItemActivate);
            this.ListViewField.BackColorChanged += new System.EventHandler(this.ListViewField_BackColorChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 200;
            // 
            // PanelForeignKey
            // 
            this.PanelForeignKey.Controls.Add(this.label12);
            this.PanelForeignKey.Controls.Add(this.txtForeignTableName);
            this.PanelForeignKey.Location = new System.Drawing.Point(663, 0);
            this.PanelForeignKey.Margin = new System.Windows.Forms.Padding(4);
            this.PanelForeignKey.Name = "PanelForeignKey";
            this.PanelForeignKey.Size = new System.Drawing.Size(307, 236);
            this.PanelForeignKey.TabIndex = 107;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label12.Location = new System.Drawing.Point(16, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(197, 27);
            this.label12.TabIndex = 93;
            this.label12.Text = "Foreign table name";
            // 
            // txtForeignTableName
            // 
            this.txtForeignTableName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtForeignTableName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtForeignTableName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtForeignTableName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtForeignTableName.Location = new System.Drawing.Point(21, 38);
            this.txtForeignTableName.Margin = new System.Windows.Forms.Padding(4);
            this.txtForeignTableName.MaxLength = 200;
            this.txtForeignTableName.Name = "txtForeignTableName";
            this.txtForeignTableName.Size = new System.Drawing.Size(228, 26);
            this.txtForeignTableName.TabIndex = 87;
            this.txtForeignTableName.BackColorChanged += new System.EventHandler(this.txtForeignTableName_BackColorChanged);
            // 
            // PanelBoolean
            // 
            this.PanelBoolean.Location = new System.Drawing.Point(663, 0);
            this.PanelBoolean.Margin = new System.Windows.Forms.Padding(4);
            this.PanelBoolean.Name = "PanelBoolean";
            this.PanelBoolean.Size = new System.Drawing.Size(307, 250);
            this.PanelBoolean.TabIndex = 107;
            // 
            // PanelPrimaryKey
            // 
            this.PanelPrimaryKey.Location = new System.Drawing.Point(663, 0);
            this.PanelPrimaryKey.Margin = new System.Windows.Forms.Padding(4);
            this.PanelPrimaryKey.Name = "PanelPrimaryKey";
            this.PanelPrimaryKey.Size = new System.Drawing.Size(307, 262);
            this.PanelPrimaryKey.TabIndex = 106;
            // 
            // PanelDecimal
            // 
            this.PanelDecimal.Controls.Add(this.txtDecimalMax);
            this.PanelDecimal.Controls.Add(this.label7);
            this.PanelDecimal.Controls.Add(this.txtDecimalMin);
            this.PanelDecimal.Controls.Add(this.picErrorForDecimalMin);
            this.PanelDecimal.Controls.Add(this.label8);
            this.PanelDecimal.Location = new System.Drawing.Point(663, 0);
            this.PanelDecimal.Margin = new System.Windows.Forms.Padding(4);
            this.PanelDecimal.Name = "PanelDecimal";
            this.PanelDecimal.Size = new System.Drawing.Size(307, 274);
            this.PanelDecimal.TabIndex = 105;
            // 
            // txtDecimalMax
            // 
            this.txtDecimalMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtDecimalMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDecimalMax.DecimalPlaces = 6;
            this.txtDecimalMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtDecimalMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtDecimalMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.txtDecimalMax.Location = new System.Drawing.Point(25, 133);
            this.txtDecimalMax.Margin = new System.Windows.Forms.Padding(4);
            this.txtDecimalMax.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            393216});
            this.txtDecimalMax.Minimum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            -2147090432});
            this.txtDecimalMax.Name = "txtDecimalMax";
            this.txtDecimalMax.Size = new System.Drawing.Size(228, 29);
            this.txtDecimalMax.TabIndex = 99;
            this.txtDecimalMax.ThousandsSeparator = true;
            this.txtDecimalMax.Paint += new System.Windows.Forms.PaintEventHandler(this.txtDecimalMax_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label7.Location = new System.Drawing.Point(20, 103);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 27);
            this.label7.TabIndex = 97;
            this.label7.Text = "Max";
            // 
            // txtDecimalMin
            // 
            this.txtDecimalMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtDecimalMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDecimalMin.DecimalPlaces = 6;
            this.txtDecimalMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtDecimalMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtDecimalMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.txtDecimalMin.Location = new System.Drawing.Point(25, 38);
            this.txtDecimalMin.Margin = new System.Windows.Forms.Padding(4);
            this.txtDecimalMin.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            393216});
            this.txtDecimalMin.Minimum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            -2147090432});
            this.txtDecimalMin.Name = "txtDecimalMin";
            this.txtDecimalMin.Size = new System.Drawing.Size(228, 29);
            this.txtDecimalMin.TabIndex = 96;
            this.txtDecimalMin.ThousandsSeparator = true;
            this.txtDecimalMin.Paint += new System.Windows.Forms.PaintEventHandler(this.txtDecimalMin_Paint);
            // 
            // picErrorForDecimalMin
            // 
            this.picErrorForDecimalMin.Image = ((System.Drawing.Image)(resources.GetObject("picErrorForDecimalMin.Image")));
            this.picErrorForDecimalMin.Location = new System.Drawing.Point(261, 39);
            this.picErrorForDecimalMin.Margin = new System.Windows.Forms.Padding(4);
            this.picErrorForDecimalMin.Name = "picErrorForDecimalMin";
            this.picErrorForDecimalMin.Size = new System.Drawing.Size(27, 25);
            this.picErrorForDecimalMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picErrorForDecimalMin.TabIndex = 92;
            this.picErrorForDecimalMin.TabStop = false;
            this.picErrorForDecimalMin.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label8.Location = new System.Drawing.Point(20, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 27);
            this.label8.TabIndex = 90;
            this.label8.Text = "Min";
            // 
            // PanelHexColour
            // 
            this.PanelHexColour.Controls.Add(this.txtHexColourMax);
            this.PanelHexColour.Controls.Add(this.txtHexColourMin);
            this.PanelHexColour.Controls.Add(this.label5);
            this.PanelHexColour.Controls.Add(this.label6);
            this.PanelHexColour.Location = new System.Drawing.Point(663, 0);
            this.PanelHexColour.Margin = new System.Windows.Forms.Padding(4);
            this.PanelHexColour.Name = "PanelHexColour";
            this.PanelHexColour.Size = new System.Drawing.Size(307, 288);
            this.PanelHexColour.TabIndex = 104;
            // 
            // txtHexColourMax
            // 
            this.txtHexColourMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtHexColourMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHexColourMax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHexColourMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtHexColourMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtHexColourMax.Location = new System.Drawing.Point(25, 133);
            this.txtHexColourMax.Margin = new System.Windows.Forms.Padding(4);
            this.txtHexColourMax.MaxLength = 100;
            this.txtHexColourMax.Name = "txtHexColourMax";
            this.txtHexColourMax.Size = new System.Drawing.Size(228, 26);
            this.txtHexColourMax.TabIndex = 100;
            this.txtHexColourMax.BackColorChanged += new System.EventHandler(this.txtHexColourMax_BackColorChanged);
            // 
            // txtHexColourMin
            // 
            this.txtHexColourMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtHexColourMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHexColourMin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHexColourMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtHexColourMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtHexColourMin.Location = new System.Drawing.Point(25, 38);
            this.txtHexColourMin.Margin = new System.Windows.Forms.Padding(4);
            this.txtHexColourMin.MaxLength = 100;
            this.txtHexColourMin.Name = "txtHexColourMin";
            this.txtHexColourMin.Size = new System.Drawing.Size(228, 26);
            this.txtHexColourMin.TabIndex = 99;
            this.txtHexColourMin.BackColorChanged += new System.EventHandler(this.txtHexColourMin_BackColorChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label5.Location = new System.Drawing.Point(20, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 27);
            this.label5.TabIndex = 97;
            this.label5.Text = "Max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label6.Location = new System.Drawing.Point(20, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 27);
            this.label6.TabIndex = 90;
            this.label6.Text = "Min";
            // 
            // PanelTime
            // 
            this.PanelTime.Controls.Add(this.txtTimeSpanMax);
            this.PanelTime.Controls.Add(this.txtTimeSpanMin);
            this.PanelTime.Controls.Add(this.label3);
            this.PanelTime.Controls.Add(this.label4);
            this.PanelTime.Location = new System.Drawing.Point(663, 0);
            this.PanelTime.Margin = new System.Windows.Forms.Padding(4);
            this.PanelTime.Name = "PanelTime";
            this.PanelTime.Size = new System.Drawing.Size(307, 299);
            this.PanelTime.TabIndex = 103;
            // 
            // txtTimeSpanMax
            // 
            this.txtTimeSpanMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtTimeSpanMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimeSpanMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtTimeSpanMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtTimeSpanMax.Location = new System.Drawing.Point(25, 133);
            this.txtTimeSpanMax.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimeSpanMax.MaxLength = 100;
            this.txtTimeSpanMax.Name = "txtTimeSpanMax";
            this.txtTimeSpanMax.Size = new System.Drawing.Size(228, 26);
            this.txtTimeSpanMax.TabIndex = 100;
            this.txtTimeSpanMax.BackColorChanged += new System.EventHandler(this.txtTimeSpanMax_BackColorChanged);
            // 
            // txtTimeSpanMin
            // 
            this.txtTimeSpanMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtTimeSpanMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimeSpanMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtTimeSpanMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtTimeSpanMin.Location = new System.Drawing.Point(25, 38);
            this.txtTimeSpanMin.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimeSpanMin.MaxLength = 100;
            this.txtTimeSpanMin.Name = "txtTimeSpanMin";
            this.txtTimeSpanMin.Size = new System.Drawing.Size(228, 26);
            this.txtTimeSpanMin.TabIndex = 99;
            this.txtTimeSpanMin.BackColorChanged += new System.EventHandler(this.txtTimeSpanMin_BackColorChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 27);
            this.label3.TabIndex = 97;
            this.label3.Text = "Max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label4.Location = new System.Drawing.Point(20, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 27);
            this.label4.TabIndex = 90;
            this.label4.Text = "Min";
            // 
            // PanelDateTime
            // 
            this.PanelDateTime.Controls.Add(this.DatePickerMax);
            this.PanelDateTime.Controls.Add(this.TimePickerMin);
            this.PanelDateTime.Controls.Add(this.TimePickerMax);
            this.PanelDateTime.Controls.Add(this.DatePickerMin);
            this.PanelDateTime.Controls.Add(this.txtDateTimeMax);
            this.PanelDateTime.Controls.Add(this.txtDateTimeMin);
            this.PanelDateTime.Controls.Add(this.label9);
            this.PanelDateTime.Controls.Add(this.label10);
            this.PanelDateTime.Location = new System.Drawing.Point(662, 4);
            this.PanelDateTime.Margin = new System.Windows.Forms.Padding(4);
            this.PanelDateTime.Name = "PanelDateTime";
            this.PanelDateTime.Size = new System.Drawing.Size(307, 311);
            this.PanelDateTime.TabIndex = 108;
            // 
            // DatePickerMax
            // 
            this.DatePickerMax.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMax.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.DatePickerMax.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMax.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMax.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMax.CustomFormat = "MM\'/\'dd\'/\'yyyy";
            this.DatePickerMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.DatePickerMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePickerMax.Location = new System.Drawing.Point(25, 196);
            this.DatePickerMax.Margin = new System.Windows.Forms.Padding(4);
            this.DatePickerMax.Name = "DatePickerMax";
            this.DatePickerMax.Size = new System.Drawing.Size(227, 33);
            this.DatePickerMax.TabIndex = 116;
            this.DatePickerMax.Value = new System.DateTime(1800, 1, 1, 10, 10, 0, 0);
            this.DatePickerMax.ValueChanged += new System.EventHandler(this.DatePickerMax_ValueChanged);
            // 
            // TimePickerMin
            // 
            this.TimePickerMin.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMin.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.TimePickerMin.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMin.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMin.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMin.CustomFormat = "hh\':\'mm";
            this.TimePickerMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.TimePickerMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerMin.Location = new System.Drawing.Point(25, 78);
            this.TimePickerMin.Margin = new System.Windows.Forms.Padding(4);
            this.TimePickerMin.Name = "TimePickerMin";
            this.TimePickerMin.ShowUpDown = true;
            this.TimePickerMin.Size = new System.Drawing.Size(228, 33);
            this.TimePickerMin.TabIndex = 115;
            this.TimePickerMin.Value = new System.DateTime(1800, 1, 1, 10, 10, 0, 0);
            this.TimePickerMin.ValueChanged += new System.EventHandler(this.TimePickerMin_ValueChanged);
            // 
            // TimePickerMax
            // 
            this.TimePickerMax.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMax.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.TimePickerMax.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMax.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMax.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.TimePickerMax.CustomFormat = "hh\':\'mm";
            this.TimePickerMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.TimePickerMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TimePickerMax.Location = new System.Drawing.Point(25, 238);
            this.TimePickerMax.Margin = new System.Windows.Forms.Padding(4);
            this.TimePickerMax.Name = "TimePickerMax";
            this.TimePickerMax.ShowUpDown = true;
            this.TimePickerMax.Size = new System.Drawing.Size(227, 33);
            this.TimePickerMax.TabIndex = 114;
            this.TimePickerMax.Value = new System.DateTime(1800, 1, 1, 10, 10, 0, 0);
            this.TimePickerMax.ValueChanged += new System.EventHandler(this.TimePickerMax_ValueChanged);
            // 
            // DatePickerMin
            // 
            this.DatePickerMin.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMin.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.DatePickerMin.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMin.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMin.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.DatePickerMin.CustomFormat = "MM\'/\'dd\'/\'yyyy";
            this.DatePickerMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.DatePickerMin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePickerMin.Location = new System.Drawing.Point(25, 36);
            this.DatePickerMin.Margin = new System.Windows.Forms.Padding(4);
            this.DatePickerMin.Name = "DatePickerMin";
            this.DatePickerMin.Size = new System.Drawing.Size(227, 33);
            this.DatePickerMin.TabIndex = 111;
            this.DatePickerMin.Value = new System.DateTime(1800, 1, 1, 10, 10, 0, 0);
            this.DatePickerMin.ValueChanged += new System.EventHandler(this.DatePickerMin_ValueChanged);
            // 
            // txtDateTimeMax
            // 
            this.txtDateTimeMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtDateTimeMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateTimeMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtDateTimeMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtDateTimeMax.Location = new System.Drawing.Point(25, 279);
            this.txtDateTimeMax.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateTimeMax.MaxLength = 100;
            this.txtDateTimeMax.Name = "txtDateTimeMax";
            this.txtDateTimeMax.Size = new System.Drawing.Size(228, 26);
            this.txtDateTimeMax.TabIndex = 100;
            this.txtDateTimeMax.BackColorChanged += new System.EventHandler(this.txtDateTimeMax_BackColorChanged);
            // 
            // txtDateTimeMin
            // 
            this.txtDateTimeMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtDateTimeMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateTimeMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtDateTimeMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtDateTimeMin.Location = new System.Drawing.Point(25, 119);
            this.txtDateTimeMin.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateTimeMin.MaxLength = 100;
            this.txtDateTimeMin.Name = "txtDateTimeMin";
            this.txtDateTimeMin.Size = new System.Drawing.Size(228, 26);
            this.txtDateTimeMin.TabIndex = 99;
            this.txtDateTimeMin.BackColorChanged += new System.EventHandler(this.txtDateTimeMin_BackColorChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label9.Location = new System.Drawing.Point(20, 166);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 27);
            this.label9.TabIndex = 97;
            this.label9.Text = "Max";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label10.Location = new System.Drawing.Point(20, 9);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 27);
            this.label10.TabIndex = 90;
            this.label10.Text = "Min";
            // 
            // PanelInteger
            // 
            this.PanelInteger.Controls.Add(this.txtIntMax);
            this.PanelInteger.Controls.Add(this.label1);
            this.PanelInteger.Controls.Add(this.txtIntMin);
            this.PanelInteger.Controls.Add(this.label2);
            this.PanelInteger.Location = new System.Drawing.Point(663, 0);
            this.PanelInteger.Margin = new System.Windows.Forms.Padding(4);
            this.PanelInteger.Name = "PanelInteger";
            this.PanelInteger.Size = new System.Drawing.Size(307, 324);
            this.PanelInteger.TabIndex = 101;
            // 
            // txtIntMax
            // 
            this.txtIntMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtIntMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIntMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtIntMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtIntMax.Location = new System.Drawing.Point(25, 133);
            this.txtIntMax.Margin = new System.Windows.Forms.Padding(4);
            this.txtIntMax.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtIntMax.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.txtIntMax.Name = "txtIntMax";
            this.txtIntMax.Size = new System.Drawing.Size(228, 29);
            this.txtIntMax.TabIndex = 99;
            this.txtIntMax.ThousandsSeparator = true;
            this.txtIntMax.Value = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtIntMax.Paint += new System.Windows.Forms.PaintEventHandler(this.txtIntMax_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label1.Location = new System.Drawing.Point(20, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 27);
            this.label1.TabIndex = 97;
            this.label1.Text = "Max";
            // 
            // txtIntMin
            // 
            this.txtIntMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtIntMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIntMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtIntMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtIntMin.Location = new System.Drawing.Point(25, 38);
            this.txtIntMin.Margin = new System.Windows.Forms.Padding(4);
            this.txtIntMin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.txtIntMin.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.txtIntMin.Name = "txtIntMin";
            this.txtIntMin.Size = new System.Drawing.Size(228, 29);
            this.txtIntMin.TabIndex = 96;
            this.txtIntMin.ThousandsSeparator = true;
            this.txtIntMin.Paint += new System.Windows.Forms.PaintEventHandler(this.txtIntMin_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label2.Location = new System.Drawing.Point(20, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 27);
            this.label2.TabIndex = 90;
            this.label2.Text = "Min";
            // 
            // PanelText
            // 
            this.PanelText.Controls.Add(this.txtTextMax);
            this.PanelText.Controls.Add(this.label11);
            this.PanelText.Controls.Add(this.txtTextMin);
            this.PanelText.Controls.Add(this.labelStringRegex);
            this.PanelText.Controls.Add(this.txtTextRegex);
            this.PanelText.Controls.Add(this.labelStringLength);
            this.PanelText.Location = new System.Drawing.Point(663, 0);
            this.PanelText.Margin = new System.Windows.Forms.Padding(4);
            this.PanelText.Name = "PanelText";
            this.PanelText.Size = new System.Drawing.Size(307, 335);
            this.PanelText.TabIndex = 100;
            // 
            // txtTextMax
            // 
            this.txtTextMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtTextMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextMax.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtTextMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtTextMax.Location = new System.Drawing.Point(27, 135);
            this.txtTextMax.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextMax.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.txtTextMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTextMax.Name = "txtTextMax";
            this.txtTextMax.Size = new System.Drawing.Size(228, 29);
            this.txtTextMax.TabIndex = 99;
            this.txtTextMax.ThousandsSeparator = true;
            this.txtTextMax.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label11.Location = new System.Drawing.Point(21, 106);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 27);
            this.label11.TabIndex = 97;
            this.label11.Text = "Max";
            // 
            // txtTextMin
            // 
            this.txtTextMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtTextMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextMin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtTextMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtTextMin.Location = new System.Drawing.Point(25, 38);
            this.txtTextMin.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextMin.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.txtTextMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTextMin.Name = "txtTextMin";
            this.txtTextMin.Size = new System.Drawing.Size(228, 29);
            this.txtTextMin.TabIndex = 96;
            this.txtTextMin.ThousandsSeparator = true;
            this.txtTextMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTextMin.Paint += new System.Windows.Forms.PaintEventHandler(this.txtStringN_Paint);
            // 
            // labelStringRegex
            // 
            this.labelStringRegex.AutoSize = true;
            this.labelStringRegex.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelStringRegex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelStringRegex.Location = new System.Drawing.Point(21, 201);
            this.labelStringRegex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStringRegex.Name = "labelStringRegex";
            this.labelStringRegex.Size = new System.Drawing.Size(70, 27);
            this.labelStringRegex.TabIndex = 94;
            this.labelStringRegex.Text = "Regex";
            // 
            // txtTextRegex
            // 
            this.txtTextRegex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtTextRegex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextRegex.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtTextRegex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtTextRegex.Location = new System.Drawing.Point(27, 230);
            this.txtTextRegex.Margin = new System.Windows.Forms.Padding(4);
            this.txtTextRegex.MaxLength = 100;
            this.txtTextRegex.Name = "txtTextRegex";
            this.txtTextRegex.Size = new System.Drawing.Size(228, 26);
            this.txtTextRegex.TabIndex = 93;
            this.txtTextRegex.BackColorChanged += new System.EventHandler(this.txtStringRegex_BackColorChanged);
            // 
            // labelStringLength
            // 
            this.labelStringLength.AutoSize = true;
            this.labelStringLength.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelStringLength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelStringLength.Location = new System.Drawing.Point(20, 9);
            this.labelStringLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStringLength.Name = "labelStringLength";
            this.labelStringLength.Size = new System.Drawing.Size(49, 27);
            this.labelStringLength.TabIndex = 90;
            this.labelStringLength.Text = "Min";
            // 
            // labelDataType
            // 
            this.labelDataType.AutoSize = true;
            this.labelDataType.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelDataType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelDataType.Location = new System.Drawing.Point(323, 267);
            this.labelDataType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataType.Name = "labelDataType";
            this.labelDataType.Size = new System.Drawing.Size(108, 27);
            this.labelDataType.TabIndex = 95;
            this.labelDataType.Text = "Data Type";
            // 
            // cmbDataType
            // 
            this.cmbDataType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataType.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.cmbDataType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(325, 299);
            this.cmbDataType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDataType.MaxDropDownItems = 10;
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(227, 35);
            this.cmbDataType.TabIndex = 94;
            this.cmbDataType.SelectedIndexChanged += new System.EventHandler(this.cmbDataType_SelectedIndexChanged);
            this.cmbDataType.BackColorChanged += new System.EventHandler(this.cmbDataType_BackColorChanged);
            // 
            // labelFieldHistoryUser
            // 
            this.labelFieldHistoryUser.AutoSize = true;
            this.labelFieldHistoryUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelFieldHistoryUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelFieldHistoryUser.Location = new System.Drawing.Point(323, 118);
            this.labelFieldHistoryUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFieldHistoryUser.Name = "labelFieldHistoryUser";
            this.labelFieldHistoryUser.Size = new System.Drawing.Size(126, 27);
            this.labelFieldHistoryUser.TabIndex = 92;
            this.labelFieldHistoryUser.Text = "History user";
            // 
            // txtFieldHistoryUser
            // 
            this.txtFieldHistoryUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtFieldHistoryUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFieldHistoryUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtFieldHistoryUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtFieldHistoryUser.Location = new System.Drawing.Point(328, 148);
            this.txtFieldHistoryUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtFieldHistoryUser.MaxLength = 100;
            this.txtFieldHistoryUser.Multiline = true;
            this.txtFieldHistoryUser.Name = "txtFieldHistoryUser";
            this.txtFieldHistoryUser.Size = new System.Drawing.Size(228, 106);
            this.txtFieldHistoryUser.TabIndex = 91;
            this.txtFieldHistoryUser.BackColorChanged += new System.EventHandler(this.txtFieldHistoryUser_BackColorChanged);
            // 
            // labelFieldName
            // 
            this.labelFieldName.AutoSize = true;
            this.labelFieldName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelFieldName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelFieldName.Location = new System.Drawing.Point(323, 0);
            this.labelFieldName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFieldName.Name = "labelFieldName";
            this.labelFieldName.Size = new System.Drawing.Size(69, 27);
            this.labelFieldName.TabIndex = 88;
            this.labelFieldName.Text = "Name";
            // 
            // txtFieldName
            // 
            this.txtFieldName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.txtFieldName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFieldName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.txtFieldName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtFieldName.Location = new System.Drawing.Point(328, 30);
            this.txtFieldName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFieldName.MaxLength = 100;
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(228, 26);
            this.txtFieldName.TabIndex = 86;
            this.txtFieldName.BackColorChanged += new System.EventHandler(this.txtFieldName_BackColorChanged);
            // 
            // PanelSummary
            // 
            this.PanelSummary.Controls.Add(this.TextBoxLogger);
            this.PanelSummary.Controls.Add(this.btnHidePanelSummary);
            this.PanelSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PanelSummary.Location = new System.Drawing.Point(1366, 578);
            this.PanelSummary.Margin = new System.Windows.Forms.Padding(4);
            this.PanelSummary.Name = "PanelSummary";
            this.PanelSummary.Size = new System.Drawing.Size(969, 438);
            this.PanelSummary.TabIndex = 92;
            // 
            // TextBoxLogger
            // 
            this.TextBoxLogger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(44)))));
            this.TextBoxLogger.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.TextBoxLogger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.TextBoxLogger.Location = new System.Drawing.Point(0, 5);
            this.TextBoxLogger.Multiline = true;
            this.TextBoxLogger.Name = "TextBoxLogger";
            this.TextBoxLogger.ReadOnly = true;
            this.TextBoxLogger.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxLogger.Size = new System.Drawing.Size(969, 377);
            this.TextBoxLogger.TabIndex = 100;
            this.TextBoxLogger.BackColorChanged += new System.EventHandler(this.TextBoxLogger_BackColorChanged);
            // 
            // btnHidePanelSummary
            // 
            this.btnHidePanelSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHidePanelSummary.Image = ((System.Drawing.Image)(resources.GetObject("btnHidePanelSummary.Image")));
            this.btnHidePanelSummary.Location = new System.Drawing.Point(809, 389);
            this.btnHidePanelSummary.Margin = new System.Windows.Forms.Padding(4);
            this.btnHidePanelSummary.Name = "btnHidePanelSummary";
            this.btnHidePanelSummary.Size = new System.Drawing.Size(160, 49);
            this.btnHidePanelSummary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHidePanelSummary.TabIndex = 99;
            this.btnHidePanelSummary.TabStop = false;
            this.btnHidePanelSummary.Click += new System.EventHandler(this.btnHidePanelSummary_Click);
            this.btnHidePanelSummary.Paint += new System.Windows.Forms.PaintEventHandler(this.btnHidePanelSummary_Paint);
            // 
            // PanelDatabase
            // 
            this.PanelDatabase.Controls.Add(this.btnCopyDBProduction);
            this.PanelDatabase.Controls.Add(this.btnCopyDBLocalhost);
            this.PanelDatabase.Controls.Add(this.label14);
            this.PanelDatabase.Controls.Add(this.label13);
            this.PanelDatabase.Controls.Add(this.PropertyGridDatabase);
            this.PanelDatabase.Controls.Add(this.btnRefreshDataBases);
            this.PanelDatabase.Controls.Add(this.picAddDataBase);
            this.PanelDatabase.Controls.Add(this.ListViewDatabase);
            this.PanelDatabase.Controls.Add(this.btnDeleteDataBases);
            this.PanelDatabase.Controls.Add(this.lblActionDatabase);
            this.PanelDatabase.Controls.Add(this.btnAddDatabase);
            this.PanelDatabase.Location = new System.Drawing.Point(109, 58);
            this.PanelDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.PanelDatabase.Name = "PanelDatabase";
            this.PanelDatabase.Size = new System.Drawing.Size(969, 439);
            this.PanelDatabase.TabIndex = 94;
            // 
            // btnCopyDBProduction
            // 
            this.btnCopyDBProduction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyDBProduction.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyDBProduction.Image")));
            this.btnCopyDBProduction.Location = new System.Drawing.Point(651, 347);
            this.btnCopyDBProduction.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyDBProduction.Name = "btnCopyDBProduction";
            this.btnCopyDBProduction.Size = new System.Drawing.Size(33, 31);
            this.btnCopyDBProduction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCopyDBProduction.TabIndex = 196;
            this.btnCopyDBProduction.TabStop = false;
            this.btnCopyDBProduction.Click += new System.EventHandler(this.btnCopyDBProduction_Click);
            // 
            // btnCopyDBLocalhost
            // 
            this.btnCopyDBLocalhost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyDBLocalhost.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyDBLocalhost.Image")));
            this.btnCopyDBLocalhost.Location = new System.Drawing.Point(436, 347);
            this.btnCopyDBLocalhost.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyDBLocalhost.Name = "btnCopyDBLocalhost";
            this.btnCopyDBLocalhost.Size = new System.Drawing.Size(33, 31);
            this.btnCopyDBLocalhost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCopyDBLocalhost.TabIndex = 195;
            this.btnCopyDBLocalhost.TabStop = false;
            this.btnCopyDBLocalhost.Click += new System.EventHandler(this.btnCopyDBLocalhost_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label14.Location = new System.Drawing.Point(526, 350);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 27);
            this.label14.TabIndex = 194;
            this.label14.Text = "Production";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.label13.Location = new System.Drawing.Point(326, 351);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 27);
            this.label13.TabIndex = 193;
            this.label13.Text = "Localhost";
            // 
            // PropertyGridDatabase
            // 
            this.PropertyGridDatabase.Location = new System.Drawing.Point(331, 30);
            this.PropertyGridDatabase.Name = "PropertyGridDatabase";
            this.PropertyGridDatabase.Size = new System.Drawing.Size(621, 309);
            this.PropertyGridDatabase.TabIndex = 192;
            // 
            // btnRefreshDataBases
            // 
            this.btnRefreshDataBases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshDataBases.Image = global::FiyiStackApp.Properties.Resources.Refresh;
            this.btnRefreshDataBases.Location = new System.Drawing.Point(82, 342);
            this.btnRefreshDataBases.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshDataBases.Name = "btnRefreshDataBases";
            this.btnRefreshDataBases.Size = new System.Drawing.Size(33, 31);
            this.btnRefreshDataBases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRefreshDataBases.TabIndex = 191;
            this.btnRefreshDataBases.TabStop = false;
            this.btnRefreshDataBases.Click += new System.EventHandler(this.btnRefreshDataBases_Click);
            // 
            // picAddDataBase
            // 
            this.picAddDataBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddDataBase.Image = global::FiyiStackApp.Properties.Resources.Add;
            this.picAddDataBase.Location = new System.Drawing.Point(41, 343);
            this.picAddDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.picAddDataBase.Name = "picAddDataBase";
            this.picAddDataBase.Size = new System.Drawing.Size(33, 31);
            this.picAddDataBase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddDataBase.TabIndex = 190;
            this.picAddDataBase.TabStop = false;
            this.picAddDataBase.Click += new System.EventHandler(this.picAddDataBase_Click);
            // 
            // btnDeleteDataBases
            // 
            this.btnDeleteDataBases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteDataBases.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDataBases.Image")));
            this.btnDeleteDataBases.Location = new System.Drawing.Point(0, 342);
            this.btnDeleteDataBases.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteDataBases.Name = "btnDeleteDataBases";
            this.btnDeleteDataBases.Size = new System.Drawing.Size(33, 31);
            this.btnDeleteDataBases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteDataBases.TabIndex = 66;
            this.btnDeleteDataBases.TabStop = false;
            this.btnDeleteDataBases.Click += new System.EventHandler(this.btnDeleteDataBases_Click);
            // 
            // btnAddDatabase
            // 
            this.btnAddDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDatabase.Image")));
            this.btnAddDatabase.Location = new System.Drawing.Point(809, 390);
            this.btnAddDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDatabase.Name = "btnAddDatabase";
            this.btnAddDatabase.Size = new System.Drawing.Size(160, 49);
            this.btnAddDatabase.TabIndex = 92;
            this.btnAddDatabase.TabStop = false;
            this.btnAddDatabase.Click += new System.EventHandler(this.btnAddDatabase_Click);
            this.btnAddDatabase.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSaveDataBaseConfig_Paint);
            // 
            // PanelTable
            // 
            this.PanelTable.Controls.Add(this.lblActionTable);
            this.PanelTable.Controls.Add(this.PropertyGridTable);
            this.PanelTable.Controls.Add(this.btnRefreshTables);
            this.PanelTable.Controls.Add(this.AddTableButton);
            this.PanelTable.Controls.Add(this.btnSelectAllTable);
            this.PanelTable.Controls.Add(this.ListViewTable);
            this.PanelTable.Controls.Add(this.btnAddTable);
            this.PanelTable.Controls.Add(this.btnDeleteTables);
            this.PanelTable.Location = new System.Drawing.Point(175, 80);
            this.PanelTable.Margin = new System.Windows.Forms.Padding(4);
            this.PanelTable.Name = "PanelTable";
            this.PanelTable.Size = new System.Drawing.Size(969, 439);
            this.PanelTable.TabIndex = 95;
            // 
            // lblActionTable
            // 
            this.lblActionTable.AutoSize = true;
            this.lblActionTable.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.lblActionTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.lblActionTable.Location = new System.Drawing.Point(509, 0);
            this.lblActionTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActionTable.Name = "lblActionTable";
            this.lblActionTable.Size = new System.Drawing.Size(52, 27);
            this.lblActionTable.TabIndex = 193;
            this.lblActionTable.Text = "Add";
            // 
            // PropertyGridTable
            // 
            this.PropertyGridTable.Location = new System.Drawing.Point(514, 30);
            this.PropertyGridTable.Name = "PropertyGridTable";
            this.PropertyGridTable.Size = new System.Drawing.Size(452, 305);
            this.PropertyGridTable.TabIndex = 192;
            // 
            // btnRefreshTables
            // 
            this.btnRefreshTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshTables.Image = global::FiyiStackApp.Properties.Resources.Refresh;
            this.btnRefreshTables.Location = new System.Drawing.Point(123, 344);
            this.btnRefreshTables.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshTables.Name = "btnRefreshTables";
            this.btnRefreshTables.Size = new System.Drawing.Size(33, 31);
            this.btnRefreshTables.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRefreshTables.TabIndex = 191;
            this.btnRefreshTables.TabStop = false;
            this.btnRefreshTables.Click += new System.EventHandler(this.btnRefreshTables_Click);
            // 
            // AddTableButton
            // 
            this.AddTableButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddTableButton.Image = global::FiyiStackApp.Properties.Resources.Add;
            this.AddTableButton.Location = new System.Drawing.Point(82, 342);
            this.AddTableButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddTableButton.Name = "AddTableButton";
            this.AddTableButton.Size = new System.Drawing.Size(33, 31);
            this.AddTableButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddTableButton.TabIndex = 188;
            this.AddTableButton.TabStop = false;
            this.AddTableButton.Click += new System.EventHandler(this.AddTableButton_Click);
            // 
            // btnSelectAllTable
            // 
            this.btnSelectAllTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectAllTable.Image = global::FiyiStackApp.Properties.Resources.SelectAll;
            this.btnSelectAllTable.Location = new System.Drawing.Point(41, 343);
            this.btnSelectAllTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAllTable.Name = "btnSelectAllTable";
            this.btnSelectAllTable.Size = new System.Drawing.Size(33, 31);
            this.btnSelectAllTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSelectAllTable.TabIndex = 99;
            this.btnSelectAllTable.TabStop = false;
            this.btnSelectAllTable.Click += new System.EventHandler(this.btnSelectAllTable_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTable.Image = global::FiyiStackApp.Properties.Resources.btnNew;
            this.btnAddTable.Location = new System.Drawing.Point(809, 390);
            this.btnAddTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(160, 49);
            this.btnAddTable.TabIndex = 92;
            this.btnAddTable.TabStop = false;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            this.btnAddTable.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSaveTableConfig_Paint);
            // 
            // btnDeleteTables
            // 
            this.btnDeleteTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTables.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTables.Image")));
            this.btnDeleteTables.Location = new System.Drawing.Point(0, 342);
            this.btnDeleteTables.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTables.Name = "btnDeleteTables";
            this.btnDeleteTables.Size = new System.Drawing.Size(33, 31);
            this.btnDeleteTables.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteTables.TabIndex = 70;
            this.btnDeleteTables.TabStop = false;
            this.btnDeleteTables.Click += new System.EventHandler(this.btnDeleteTables_Click);
            // 
            // PanelField
            // 
            this.PanelField.Controls.Add(this.btnRefreshFields);
            this.PanelField.Controls.Add(this.picAddFieldButton);
            this.PanelField.Controls.Add(this.btnSelectAllField);
            this.PanelField.Controls.Add(this.chbNullable);
            this.PanelField.Controls.Add(this.PanelForeignKey);
            this.PanelField.Controls.Add(this.PanelBoolean);
            this.PanelField.Controls.Add(this.PanelPrimaryKey);
            this.PanelField.Controls.Add(this.PanelDecimal);
            this.PanelField.Controls.Add(this.PanelHexColour);
            this.PanelField.Controls.Add(this.PanelTime);
            this.PanelField.Controls.Add(this.PanelDateTime);
            this.PanelField.Controls.Add(this.PanelInteger);
            this.PanelField.Controls.Add(this.PanelText);
            this.PanelField.Controls.Add(this.picDataType);
            this.PanelField.Controls.Add(this.btnDeleteField);
            this.PanelField.Controls.Add(this.ListViewField);
            this.PanelField.Controls.Add(this.labelFieldName);
            this.PanelField.Controls.Add(this.txtFieldName);
            this.PanelField.Controls.Add(this.btnAddField);
            this.PanelField.Controls.Add(this.txtFieldHistoryUser);
            this.PanelField.Controls.Add(this.labelFieldHistoryUser);
            this.PanelField.Controls.Add(this.labelDataType);
            this.PanelField.Controls.Add(this.cmbDataType);
            this.PanelField.Location = new System.Drawing.Point(268, 62);
            this.PanelField.Margin = new System.Windows.Forms.Padding(4);
            this.PanelField.Name = "PanelField";
            this.PanelField.Size = new System.Drawing.Size(969, 439);
            this.PanelField.TabIndex = 96;
            // 
            // btnRefreshFields
            // 
            this.btnRefreshFields.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshFields.Image = global::FiyiStackApp.Properties.Resources.Refresh;
            this.btnRefreshFields.Location = new System.Drawing.Point(123, 342);
            this.btnRefreshFields.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshFields.Name = "btnRefreshFields";
            this.btnRefreshFields.Size = new System.Drawing.Size(33, 31);
            this.btnRefreshFields.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRefreshFields.TabIndex = 190;
            this.btnRefreshFields.TabStop = false;
            this.btnRefreshFields.Click += new System.EventHandler(this.btnRefreshFields_Click);
            // 
            // picAddFieldButton
            // 
            this.picAddFieldButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddFieldButton.Image = global::FiyiStackApp.Properties.Resources.Add;
            this.picAddFieldButton.Location = new System.Drawing.Point(82, 342);
            this.picAddFieldButton.Margin = new System.Windows.Forms.Padding(4);
            this.picAddFieldButton.Name = "picAddFieldButton";
            this.picAddFieldButton.Size = new System.Drawing.Size(33, 31);
            this.picAddFieldButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddFieldButton.TabIndex = 189;
            this.picAddFieldButton.TabStop = false;
            this.picAddFieldButton.Click += new System.EventHandler(this.picAddFieldButton_Click);
            // 
            // btnSelectAllField
            // 
            this.btnSelectAllField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectAllField.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAllField.Image")));
            this.btnSelectAllField.Location = new System.Drawing.Point(41, 343);
            this.btnSelectAllField.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAllField.Name = "btnSelectAllField";
            this.btnSelectAllField.Size = new System.Drawing.Size(33, 31);
            this.btnSelectAllField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSelectAllField.TabIndex = 110;
            this.btnSelectAllField.TabStop = false;
            this.btnSelectAllField.Click += new System.EventHandler(this.btnSelectAllField_Click);
            // 
            // chbNullable
            // 
            this.chbNullable.AutoSize = true;
            this.chbNullable.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.chbNullable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.chbNullable.Location = new System.Drawing.Point(328, 68);
            this.chbNullable.Margin = new System.Windows.Forms.Padding(4);
            this.chbNullable.Name = "chbNullable";
            this.chbNullable.Size = new System.Drawing.Size(110, 29);
            this.chbNullable.TabIndex = 94;
            this.chbNullable.Text = "Nullable";
            this.chbNullable.UseVisualStyleBackColor = true;
            // 
            // picDataType
            // 
            this.picDataType.Cursor = System.Windows.Forms.Cursors.Default;
            this.picDataType.ErrorImage = null;
            this.picDataType.Location = new System.Drawing.Point(573, 273);
            this.picDataType.Margin = new System.Windows.Forms.Padding(4);
            this.picDataType.Name = "picDataType";
            this.picDataType.Size = new System.Drawing.Size(67, 62);
            this.picDataType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDataType.TabIndex = 109;
            this.picDataType.TabStop = false;
            this.picDataType.Paint += new System.Windows.Forms.PaintEventHandler(this.picDataType_Paint);
            // 
            // btnDeleteField
            // 
            this.btnDeleteField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteField.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteField.Image")));
            this.btnDeleteField.Location = new System.Drawing.Point(0, 342);
            this.btnDeleteField.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteField.Name = "btnDeleteField";
            this.btnDeleteField.Size = new System.Drawing.Size(33, 31);
            this.btnDeleteField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteField.TabIndex = 80;
            this.btnDeleteField.TabStop = false;
            this.btnDeleteField.Click += new System.EventHandler(this.btnDeleteField_Click);
            // 
            // btnAddField
            // 
            this.btnAddField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddField.Image = ((System.Drawing.Image)(resources.GetObject("btnAddField.Image")));
            this.btnAddField.Location = new System.Drawing.Point(809, 390);
            this.btnAddField.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(160, 49);
            this.btnAddField.TabIndex = 98;
            this.btnAddField.TabStop = false;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            this.btnAddField.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSaveFieldConfig_Paint);
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.btnShowConfigurationForm);
            this.PanelMain.Controls.Add(this.labelDataBase);
            this.PanelMain.Controls.Add(this.labelTables);
            this.PanelMain.Controls.Add(this.picStep3Properties);
            this.PanelMain.Controls.Add(this.labelFields);
            this.PanelMain.Controls.Add(this.btnGenerate);
            this.PanelMain.Controls.Add(this.picStep2Tables);
            this.PanelMain.Controls.Add(this.picStep1Databases);
            this.PanelMain.Location = new System.Drawing.Point(57, 143);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(269, 439);
            this.PanelMain.TabIndex = 102;
            // 
            // btnShowConfigurationForm
            // 
            this.btnShowConfigurationForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowConfigurationForm.Image = ((System.Drawing.Image)(resources.GetObject("btnShowConfigurationForm.Image")));
            this.btnShowConfigurationForm.Location = new System.Drawing.Point(0, 302);
            this.btnShowConfigurationForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowConfigurationForm.Name = "btnShowConfigurationForm";
            this.btnShowConfigurationForm.Size = new System.Drawing.Size(169, 56);
            this.btnShowConfigurationForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnShowConfigurationForm.TabIndex = 91;
            this.btnShowConfigurationForm.TabStop = false;
            this.btnShowConfigurationForm.Click += new System.EventHandler(this.btnShowConfigurationForm_Click);
            this.btnShowConfigurationForm.Paint += new System.Windows.Forms.PaintEventHandler(this.btnShowConfigurationForm_Paint);
            // 
            // picStep3Properties
            // 
            this.picStep3Properties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStep3Properties.ErrorImage = null;
            this.picStep3Properties.Image = ((System.Drawing.Image)(resources.GetObject("picStep3Properties.Image")));
            this.picStep3Properties.Location = new System.Drawing.Point(4, 124);
            this.picStep3Properties.Margin = new System.Windows.Forms.Padding(4);
            this.picStep3Properties.Name = "picStep3Properties";
            this.picStep3Properties.Size = new System.Drawing.Size(40, 37);
            this.picStep3Properties.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStep3Properties.TabIndex = 100;
            this.picStep3Properties.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerate.Image")));
            this.btnGenerate.Location = new System.Drawing.Point(0, 380);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(244, 59);
            this.btnGenerate.TabIndex = 77;
            this.btnGenerate.TabStop = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.btnGenerate.Paint += new System.Windows.Forms.PaintEventHandler(this.btnGenerate_Paint);
            // 
            // picStep2Tables
            // 
            this.picStep2Tables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStep2Tables.ErrorImage = null;
            this.picStep2Tables.Image = ((System.Drawing.Image)(resources.GetObject("picStep2Tables.Image")));
            this.picStep2Tables.Location = new System.Drawing.Point(4, 64);
            this.picStep2Tables.Margin = new System.Windows.Forms.Padding(4);
            this.picStep2Tables.Name = "picStep2Tables";
            this.picStep2Tables.Size = new System.Drawing.Size(40, 37);
            this.picStep2Tables.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStep2Tables.TabIndex = 98;
            this.picStep2Tables.TabStop = false;
            // 
            // picStep1Databases
            // 
            this.picStep1Databases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStep1Databases.ErrorImage = null;
            this.picStep1Databases.Image = ((System.Drawing.Image)(resources.GetObject("picStep1Databases.Image")));
            this.picStep1Databases.Location = new System.Drawing.Point(4, 2);
            this.picStep1Databases.Margin = new System.Windows.Forms.Padding(4);
            this.picStep1Databases.Name = "picStep1Databases";
            this.picStep1Databases.Size = new System.Drawing.Size(40, 37);
            this.picStep1Databases.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStep1Databases.TabIndex = 97;
            this.picStep1Databases.TabStop = false;
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(48)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1751, 676);
            this.Controls.Add(this.PanelTable);
            this.Controls.Add(this.PanelField);
            this.Controls.Add(this.PanelDatabase);
            this.Controls.Add(this.PanelSummary);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GeneratorForm";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiyiStack - Generator";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GeneratorForm_MouseMove);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.PanelForeignKey.ResumeLayout(false);
            this.PanelForeignKey.PerformLayout();
            this.PanelDecimal.ResumeLayout(false);
            this.PanelDecimal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecimalMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDecimalMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorForDecimalMin)).EndInit();
            this.PanelHexColour.ResumeLayout(false);
            this.PanelHexColour.PerformLayout();
            this.PanelTime.ResumeLayout(false);
            this.PanelTime.PerformLayout();
            this.PanelDateTime.ResumeLayout(false);
            this.PanelDateTime.PerformLayout();
            this.PanelInteger.ResumeLayout(false);
            this.PanelInteger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntMin)).EndInit();
            this.PanelText.ResumeLayout(false);
            this.PanelText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextMin)).EndInit();
            this.PanelSummary.ResumeLayout(false);
            this.PanelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHidePanelSummary)).EndInit();
            this.PanelDatabase.ResumeLayout(false);
            this.PanelDatabase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyDBProduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCopyDBLocalhost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshDataBases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddDataBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteDataBases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddDatabase)).EndInit();
            this.PanelTable.ResumeLayout(false);
            this.PanelTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddTableButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectAllTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteTables)).EndInit();
            this.PanelField.ResumeLayout(false);
            this.PanelField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddFieldButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectAllField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDataType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddField)).EndInit();
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowConfigurationForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep3Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep2Tables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStep1Databases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToProjectsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStatusLabel;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.ListView ListViewDatabase;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.PictureBox btnDeleteDataBases;
        private System.Windows.Forms.PictureBox btnDeleteTables;
        private System.Windows.Forms.ListView ListViewTable;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label labelTables;
        private System.Windows.Forms.Label labelFields;
        private System.Windows.Forms.PictureBox btnGenerate;
        private System.Windows.Forms.PictureBox btnDeleteField;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Label lblActionDatabase;
        private System.Windows.Forms.PictureBox btnAddDatabase;
        private System.Windows.Forms.PictureBox btnAddTable;
        private System.Windows.Forms.ListView ListViewField;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelFieldName;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.Label labelFieldHistoryUser;
        private System.Windows.Forms.TextBox txtFieldHistoryUser;
        private System.Windows.Forms.Label labelDataType;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.PictureBox btnAddField;
        private System.Windows.Forms.Panel PanelText;
        private System.Windows.Forms.NumericUpDown txtTextMin;
        private System.Windows.Forms.Label labelStringRegex;
        private System.Windows.Forms.TextBox txtTextRegex;
        private System.Windows.Forms.Label labelStringLength;
        private System.Windows.Forms.Panel PanelInteger;
        private System.Windows.Forms.NumericUpDown txtIntMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtIntMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelDecimal;
        private System.Windows.Forms.NumericUpDown txtDecimalMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtDecimalMin;
        private System.Windows.Forms.PictureBox picErrorForDecimalMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel PanelHexColour;
        private System.Windows.Forms.TextBox txtHexColourMax;
        private System.Windows.Forms.TextBox txtHexColourMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel PanelTime;
        private System.Windows.Forms.TextBox txtTimeSpanMax;
        private System.Windows.Forms.TextBox txtTimeSpanMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PanelPrimaryKey;
        private System.Windows.Forms.Panel PanelBoolean;
        private System.Windows.Forms.Panel PanelDateTime;
        private System.Windows.Forms.TextBox txtDateTimeMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox picDataType;
        private System.Windows.Forms.PictureBox btnShowConfigurationForm;
        private System.Windows.Forms.Panel PanelSummary;
        private System.Windows.Forms.PictureBox btnHidePanelSummary;
        private System.Windows.Forms.DateTimePicker DatePickerMin;
        private System.Windows.Forms.TextBox txtDateTimeMin;
        private System.Windows.Forms.DateTimePicker TimePickerMax;
        private System.Windows.Forms.DateTimePicker TimePickerMin;
        private System.Windows.Forms.DateTimePicker DatePickerMax;
        private System.Windows.Forms.NumericUpDown txtTextMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtForeignTableName;
        private System.Windows.Forms.Panel PanelForeignKey;
        private System.Windows.Forms.Panel PanelDatabase;
        private System.Windows.Forms.Panel PanelTable;
        private System.Windows.Forms.Panel PanelField;
        private System.Windows.Forms.PictureBox picStep1Databases;
        private System.Windows.Forms.PictureBox picStep2Tables;
        private System.Windows.Forms.PictureBox picStep3Properties;
        private System.Windows.Forms.CheckBox chbNullable;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.PictureBox btnSelectAllTable;
        private System.Windows.Forms.PictureBox btnSelectAllField;
        private System.Windows.Forms.TextBox TextBoxLogger;
        private PictureBox AddTableButton;
        private PictureBox picAddFieldButton;
        private PictureBox picAddDataBase;
        private PictureBox btnRefreshFields;
        private PictureBox btnRefreshDataBases;
        private PictureBox btnRefreshTables;
        private PropertyGrid PropertyGridTable;
        private Label lblActionTable;
        private PropertyGrid PropertyGridDatabase;
        private Label label13;
        private PictureBox btnCopyDBProduction;
        private PictureBox btnCopyDBLocalhost;
        private Label label14;
    }
}