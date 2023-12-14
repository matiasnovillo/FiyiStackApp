
namespace FiyiStackApp
{
    partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelNewOrEditProject = new System.Windows.Forms.Label();
            this.labelLoadProject = new System.Windows.Forms.Label();
            this.ListViewYourProjects = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageListForYourProjects = new System.Windows.Forms.ImageList(this.components);
            this.PanelFiltersForYourProjects = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelSearchByName = new System.Windows.Forms.Label();
            this.txtSearchYourProjectByName = new System.Windows.Forms.TextBox();
            this.labelFilters = new System.Windows.Forms.Label();
            this.PanelYourProjects = new System.Windows.Forms.Panel();
            this.panelLeftSide = new System.Windows.Forms.Panel();
            this.btnNewProject = new System.Windows.Forms.PictureBox();
            this.picLoadProject = new System.Windows.Forms.PictureBox();
            this.PanelLoadProject = new System.Windows.Forms.Panel();
            this.btnDeleteYourProjects = new System.Windows.Forms.PictureBox();
            this.labelYourProjects = new System.Windows.Forms.Label();
            this.btnShowFiltersForYourProjects = new System.Windows.Forms.PictureBox();
            this.panelRightSide = new System.Windows.Forms.Panel();
            this.btnNewOrEdit = new System.Windows.Forms.PictureBox();
            this.Panel0Basic = new System.Windows.Forms.Panel();
            this.PropertyGridProject = new System.Windows.Forms.PropertyGrid();
            this.picPanelSeparator = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.PanelFiltersForYourProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelYourProjects.SuspendLayout();
            this.panelLeftSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadProject)).BeginInit();
            this.PanelLoadProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteYourProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowFiltersForYourProjects)).BeginInit();
            this.panelRightSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewOrEdit)).BeginInit();
            this.Panel0Basic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPanelSeparator)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(34, 29);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.changePasswordToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(262, 30);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 663);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip.Size = new System.Drawing.Size(1067, 26);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            this.StatusStrip.Click += new System.EventHandler(this.StatusStrip_Click);
            // 
            // ToolStatusLabel
            // 
            this.ToolStatusLabel.ForeColor = System.Drawing.Color.White;
            this.ToolStatusLabel.Name = "ToolStatusLabel";
            this.ToolStatusLabel.Size = new System.Drawing.Size(151, 20);
            this.ToolStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // labelNewOrEditProject
            // 
            this.labelNewOrEditProject.AutoSize = true;
            this.labelNewOrEditProject.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewOrEditProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelNewOrEditProject.Location = new System.Drawing.Point(49, 23);
            this.labelNewOrEditProject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNewOrEditProject.Name = "labelNewOrEditProject";
            this.labelNewOrEditProject.Size = new System.Drawing.Size(268, 45);
            this.labelNewOrEditProject.TabIndex = 22;
            this.labelNewOrEditProject.Text = "NEW PROJECT";
            // 
            // labelLoadProject
            // 
            this.labelLoadProject.AutoSize = true;
            this.labelLoadProject.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoadProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.labelLoadProject.Location = new System.Drawing.Point(49, 23);
            this.labelLoadProject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLoadProject.Name = "labelLoadProject";
            this.labelLoadProject.Size = new System.Drawing.Size(283, 45);
            this.labelLoadProject.TabIndex = 23;
            this.labelLoadProject.Text = "LOAD PROJECT";
            // 
            // ListViewYourProjects
            // 
            this.ListViewYourProjects.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewYourProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.ListViewYourProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewYourProjects.CheckBoxes = true;
            this.ListViewYourProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.ListViewYourProjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListViewYourProjects.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewYourProjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.ListViewYourProjects.FullRowSelect = true;
            this.ListViewYourProjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewYourProjects.HideSelection = false;
            this.ListViewYourProjects.LargeImageList = this.ImageListForYourProjects;
            this.ListViewYourProjects.Location = new System.Drawing.Point(24, 6);
            this.ListViewYourProjects.Margin = new System.Windows.Forms.Padding(4);
            this.ListViewYourProjects.MultiSelect = false;
            this.ListViewYourProjects.Name = "ListViewYourProjects";
            this.ListViewYourProjects.ShowGroups = false;
            this.ListViewYourProjects.ShowItemToolTips = true;
            this.ListViewYourProjects.Size = new System.Drawing.Size(412, 347);
            this.ListViewYourProjects.SmallImageList = this.ImageListForYourProjects;
            this.ListViewYourProjects.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListViewYourProjects.TabIndex = 24;
            this.ListViewYourProjects.TileSize = new System.Drawing.Size(50, 50);
            this.ListViewYourProjects.UseCompatibleStateImageBehavior = false;
            this.ListViewYourProjects.View = System.Windows.Forms.View.SmallIcon;
            this.ListViewYourProjects.ItemActivate += new System.EventHandler(this.ListViewYourProjects_ItemActivate);
            this.ListViewYourProjects.BackColorChanged += new System.EventHandler(this.ListViewYourProjects_BackColorChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // ImageListForYourProjects
            // 
            this.ImageListForYourProjects.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListForYourProjects.ImageStream")));
            this.ImageListForYourProjects.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListForYourProjects.Images.SetKeyName(0, "LogoutNegative.png");
            this.ImageListForYourProjects.Images.SetKeyName(1, "LinkNegative1.png");
            this.ImageListForYourProjects.Images.SetKeyName(2, "PublicNegative.png");
            this.ImageListForYourProjects.Images.SetKeyName(3, "MailNegative.png");
            this.ImageListForYourProjects.Images.SetKeyName(4, "OKNegative.png");
            // 
            // PanelFiltersForYourProjects
            // 
            this.PanelFiltersForYourProjects.Controls.Add(this.pictureBox1);
            this.PanelFiltersForYourProjects.Controls.Add(this.labelSearchByName);
            this.PanelFiltersForYourProjects.Controls.Add(this.txtSearchYourProjectByName);
            this.PanelFiltersForYourProjects.Controls.Add(this.labelFilters);
            this.PanelFiltersForYourProjects.Location = new System.Drawing.Point(17, 44);
            this.PanelFiltersForYourProjects.Margin = new System.Windows.Forms.Padding(4);
            this.PanelFiltersForYourProjects.Name = "PanelFiltersForYourProjects";
            this.PanelFiltersForYourProjects.Size = new System.Drawing.Size(467, 382);
            this.PanelFiltersForYourProjects.TabIndex = 55;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::FiyiStackApp.Properties.Resources.FilterNegative;
            this.pictureBox1.Location = new System.Drawing.Point(24, 63);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            // 
            // labelSearchByName
            // 
            this.labelSearchByName.AutoSize = true;
            this.labelSearchByName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchByName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelSearchByName.Location = new System.Drawing.Point(60, 62);
            this.labelSearchByName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchByName.Name = "labelSearchByName";
            this.labelSearchByName.Size = new System.Drawing.Size(238, 27);
            this.labelSearchByName.TabIndex = 58;
            this.labelSearchByName.Text = "Search by project name";
            // 
            // txtSearchYourProjectByName
            // 
            this.txtSearchYourProjectByName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(42)))));
            this.txtSearchYourProjectByName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchYourProjectByName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchYourProjectByName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.txtSearchYourProjectByName.Location = new System.Drawing.Point(65, 91);
            this.txtSearchYourProjectByName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchYourProjectByName.MaxLength = 100;
            this.txtSearchYourProjectByName.Name = "txtSearchYourProjectByName";
            this.txtSearchYourProjectByName.Size = new System.Drawing.Size(289, 26);
            this.txtSearchYourProjectByName.TabIndex = 57;
            this.txtSearchYourProjectByName.BackColorChanged += new System.EventHandler(this.txtSearchYourProjectByName_BackColorChanged);
            this.txtSearchYourProjectByName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchYourProjectByName_KeyDown);
            // 
            // labelFilters
            // 
            this.labelFilters.AutoSize = true;
            this.labelFilters.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelFilters.Location = new System.Drawing.Point(19, 21);
            this.labelFilters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFilters.Name = "labelFilters";
            this.labelFilters.Size = new System.Drawing.Size(68, 27);
            this.labelFilters.TabIndex = 54;
            this.labelFilters.Text = "Filters";
            // 
            // PanelYourProjects
            // 
            this.PanelYourProjects.Controls.Add(this.ListViewYourProjects);
            this.PanelYourProjects.Location = new System.Drawing.Point(17, 44);
            this.PanelYourProjects.Margin = new System.Windows.Forms.Padding(4);
            this.PanelYourProjects.Name = "PanelYourProjects";
            this.PanelYourProjects.Size = new System.Drawing.Size(467, 366);
            this.PanelYourProjects.TabIndex = 57;
            // 
            // panelLeftSide
            // 
            this.panelLeftSide.Controls.Add(this.btnNewProject);
            this.panelLeftSide.Controls.Add(this.picLoadProject);
            this.panelLeftSide.Controls.Add(this.PanelLoadProject);
            this.panelLeftSide.Controls.Add(this.labelLoadProject);
            this.panelLeftSide.Location = new System.Drawing.Point(0, 38);
            this.panelLeftSide.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeftSide.Name = "panelLeftSide";
            this.panelLeftSide.Size = new System.Drawing.Size(519, 620);
            this.panelLeftSide.TabIndex = 58;
            // 
            // btnNewProject
            // 
            this.btnNewProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewProject.ErrorImage = null;
            this.btnNewProject.Image = global::FiyiStackApp.Properties.Resources.Add;
            this.btnNewProject.Location = new System.Drawing.Point(403, 31);
            this.btnNewProject.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewProject.Name = "btnNewProject";
            this.btnNewProject.Size = new System.Drawing.Size(40, 37);
            this.btnNewProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNewProject.TabIndex = 60;
            this.btnNewProject.TabStop = false;
            this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
            // 
            // picLoadProject
            // 
            this.picLoadProject.Cursor = System.Windows.Forms.Cursors.Default;
            this.picLoadProject.ErrorImage = null;
            this.picLoadProject.Image = ((System.Drawing.Image)(resources.GetObject("picLoadProject.Image")));
            this.picLoadProject.Location = new System.Drawing.Point(355, 31);
            this.picLoadProject.Margin = new System.Windows.Forms.Padding(4);
            this.picLoadProject.Name = "picLoadProject";
            this.picLoadProject.Size = new System.Drawing.Size(40, 37);
            this.picLoadProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoadProject.TabIndex = 59;
            this.picLoadProject.TabStop = false;
            // 
            // PanelLoadProject
            // 
            this.PanelLoadProject.Controls.Add(this.btnDeleteYourProjects);
            this.PanelLoadProject.Controls.Add(this.labelYourProjects);
            this.PanelLoadProject.Controls.Add(this.PanelYourProjects);
            this.PanelLoadProject.Controls.Add(this.PanelFiltersForYourProjects);
            this.PanelLoadProject.Controls.Add(this.btnShowFiltersForYourProjects);
            this.PanelLoadProject.Location = new System.Drawing.Point(16, 75);
            this.PanelLoadProject.Margin = new System.Windows.Forms.Padding(4);
            this.PanelLoadProject.Name = "PanelLoadProject";
            this.PanelLoadProject.Size = new System.Drawing.Size(495, 430);
            this.PanelLoadProject.TabIndex = 57;
            // 
            // btnDeleteYourProjects
            // 
            this.btnDeleteYourProjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteYourProjects.Image = global::FiyiStackApp.Properties.Resources.Trash;
            this.btnDeleteYourProjects.Location = new System.Drawing.Point(379, 12);
            this.btnDeleteYourProjects.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteYourProjects.Name = "btnDeleteYourProjects";
            this.btnDeleteYourProjects.Size = new System.Drawing.Size(33, 31);
            this.btnDeleteYourProjects.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDeleteYourProjects.TabIndex = 59;
            this.btnDeleteYourProjects.TabStop = false;
            this.btnDeleteYourProjects.Click += new System.EventHandler(this.btnDeleteYourProjects_Click);
            // 
            // labelYourProjects
            // 
            this.labelYourProjects.AutoSize = true;
            this.labelYourProjects.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYourProjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(210)))), ((int)(((byte)(221)))));
            this.labelYourProjects.Location = new System.Drawing.Point(36, 12);
            this.labelYourProjects.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelYourProjects.Name = "labelYourProjects";
            this.labelYourProjects.Size = new System.Drawing.Size(145, 27);
            this.labelYourProjects.TabIndex = 58;
            this.labelYourProjects.Text = "Your projects";
            // 
            // btnShowFiltersForYourProjects
            // 
            this.btnShowFiltersForYourProjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowFiltersForYourProjects.Image = global::FiyiStackApp.Properties.Resources.Filter;
            this.btnShowFiltersForYourProjects.Location = new System.Drawing.Point(420, 12);
            this.btnShowFiltersForYourProjects.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowFiltersForYourProjects.Name = "btnShowFiltersForYourProjects";
            this.btnShowFiltersForYourProjects.Size = new System.Drawing.Size(33, 31);
            this.btnShowFiltersForYourProjects.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnShowFiltersForYourProjects.TabIndex = 54;
            this.btnShowFiltersForYourProjects.TabStop = false;
            this.btnShowFiltersForYourProjects.Click += new System.EventHandler(this.btnShowFiltersForSavedProjects_Click);
            // 
            // panelRightSide
            // 
            this.panelRightSide.Controls.Add(this.labelNewOrEditProject);
            this.panelRightSide.Controls.Add(this.btnNewOrEdit);
            this.panelRightSide.Controls.Add(this.Panel0Basic);
            this.panelRightSide.Location = new System.Drawing.Point(548, 38);
            this.panelRightSide.Margin = new System.Windows.Forms.Padding(4);
            this.panelRightSide.Name = "panelRightSide";
            this.panelRightSide.Size = new System.Drawing.Size(497, 623);
            this.panelRightSide.TabIndex = 55;
            // 
            // btnNewOrEdit
            // 
            this.btnNewOrEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewOrEdit.Image = global::FiyiStackApp.Properties.Resources.btnNew;
            this.btnNewOrEdit.Location = new System.Drawing.Point(291, 556);
            this.btnNewOrEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewOrEdit.Name = "btnNewOrEdit";
            this.btnNewOrEdit.Size = new System.Drawing.Size(160, 49);
            this.btnNewOrEdit.TabIndex = 3;
            this.btnNewOrEdit.TabStop = false;
            this.btnNewOrEdit.Click += new System.EventHandler(this.btnNewOrEdit_Click);
            this.btnNewOrEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.btnNew_Paint);
            // 
            // Panel0Basic
            // 
            this.Panel0Basic.Controls.Add(this.PropertyGridProject);
            this.Panel0Basic.Location = new System.Drawing.Point(17, 75);
            this.Panel0Basic.Margin = new System.Windows.Forms.Padding(4);
            this.Panel0Basic.Name = "Panel0Basic";
            this.Panel0Basic.Size = new System.Drawing.Size(464, 470);
            this.Panel0Basic.TabIndex = 31;
            // 
            // PropertyGridProject
            // 
            this.PropertyGridProject.Location = new System.Drawing.Point(37, 50);
            this.PropertyGridProject.Name = "PropertyGridProject";
            this.PropertyGridProject.Size = new System.Drawing.Size(396, 388);
            this.PropertyGridProject.TabIndex = 0;
            // 
            // picPanelSeparator
            // 
            this.picPanelSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.picPanelSeparator.Location = new System.Drawing.Point(527, 15);
            this.picPanelSeparator.Margin = new System.Windows.Forms.Padding(4);
            this.picPanelSeparator.Name = "picPanelSeparator";
            this.picPanelSeparator.Size = new System.Drawing.Size(13, 654);
            this.picPanelSeparator.TabIndex = 2;
            this.picPanelSeparator.TabStop = false;
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(48)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1067, 689);
            this.Controls.Add(this.panelLeftSide);
            this.Controls.Add(this.panelRightSide);
            this.Controls.Add(this.picPanelSeparator);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ProjectForm";
            this.Opacity = 0.98D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiyiStack - Projects";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProjectForm_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.PanelFiltersForYourProjects.ResumeLayout(false);
            this.PanelFiltersForYourProjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelYourProjects.ResumeLayout(false);
            this.panelLeftSide.ResumeLayout(false);
            this.panelLeftSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadProject)).EndInit();
            this.PanelLoadProject.ResumeLayout(false);
            this.PanelLoadProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteYourProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowFiltersForYourProjects)).EndInit();
            this.panelRightSide.ResumeLayout(false);
            this.panelRightSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewOrEdit)).EndInit();
            this.Panel0Basic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPanelSeparator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.PictureBox picPanelSeparator;
        private System.Windows.Forms.PictureBox btnNewOrEdit;
        private System.Windows.Forms.Label labelNewOrEditProject;
        private System.Windows.Forms.Label labelLoadProject;
        private System.Windows.Forms.ListView ListViewYourProjects;
        private System.Windows.Forms.ToolStripStatusLabel ToolStatusLabel;
        private System.Windows.Forms.PictureBox btnShowFiltersForYourProjects;
        private System.Windows.Forms.Panel PanelFiltersForYourProjects;
        private System.Windows.Forms.Label labelFilters;
        private System.Windows.Forms.Panel PanelYourProjects;
        private System.Windows.Forms.Label labelSearchByName;
        private System.Windows.Forms.TextBox txtSearchYourProjectByName;
        private System.Windows.Forms.Panel panelLeftSide;
        private System.Windows.Forms.Panel panelRightSide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelLoadProject;
        private System.Windows.Forms.Label labelYourProjects;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ImageList ImageListForYourProjects;
        private System.Windows.Forms.PictureBox picLoadProject;
        private System.Windows.Forms.PictureBox btnNewProject;
        private System.Windows.Forms.PictureBox btnDeleteYourProjects;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private Panel Panel0Basic;
        private PropertyGrid PropertyGridProject;
    }
}