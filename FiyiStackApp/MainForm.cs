using FiyiStackApp.Models.Core;
using FiyiStack.Library.NET;
using FiyiStackApp.Properties;
using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Generation;
using FiyiStackApp.Models.Tools;
using DataBase = FiyiStackApp.Models.Core.DataBase;
using Table = FiyiStackApp.Models.Core.Table;
using Field = FiyiStackApp.Models.Core.Field;

namespace FiyiStackApp
{
    public partial class MainForm : Form
    {
        User UserToFind;
        bool Loading = false;

        public MainForm()
        {
            InitializeComponent();
            //Basic
            Loading = true;
            Cursor = Cursors.WaitCursor;
            lblMessageDockedBottom.Text = "";

            #region Manage radius of WinForms components
            Color BlackColorPlus1 = (Color)new ColorConverter().ConvertFromString("#20262D");

            

            //Set border radius to various components
            txtFantasyNameOrEmail.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtPassword.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtSearchYourProjectByName.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            ListViewProjects.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            ListViewDatabase.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            ListViewTable.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            ListViewField.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            TextBoxLogger.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;

            txtFieldName.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtFieldHistoryUser.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtTextRegex.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtDateTimeMax.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtDateTimeMin.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtTimeSpanMax.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtTimeSpanMin.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtHexColourMax.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtHexColourMin.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            txtForeignTableName.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;

            cmbDataType.BackColor = Program.WinFormConfigurationComponent.BlackColorPlus1;
            #endregion

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

            //Load ComboBox for DataType
            Program.WinFormConfigurationComponent.DataType = new DataType();
            cmbDataType.ValueMember = "Value";
            cmbDataType.DisplayMember = "Text";
            cmbDataType.DataSource = new DataType().GetList("");

            //Basico
            PanelLogin.Location = new Point(6, 106);
            PanelProject.Location = new Point(6, 106);
            PanelGenerator.Location = new Point(6, 106);

            PanelDatabase.Location = new Point(242, 17);
            PanelTable.Location = new Point(242, 17);
            PanelField.Location = new Point(242, 17);
            PanelSummary.Location = new Point(242, 17);

            picStep1Databases.Visible = true;
            picStep2Tables.Visible = false;
            picStep3Properties.Visible = false;

            lblTitle.Text = "Welcome to FiyiStack. The great low-code generator";
            lblSubtitle.Text = "More than 5.000 lines of code per table. And keeps increasing";
            cambiarDatosDeUsuarioToolStripMenuItem.Visible = false;
            volverAProyectosToolStripMenuItem.Visible = false;

            HideAllPanelsExcept(PanelLogin);
            HideAllGeneratorPanelsExcept(PanelDatabase);
            
            lblMessageDockedBottom.Text = "Ready";
            Cursor = Cursors.Default;
        }

        private void HideAllPanelsExcept(Panel PanelToShow)
        {
            PanelLogin.Hide();
            PanelProject.Hide();
            PanelGenerator.Hide();
            PanelSummary.Hide();

            PanelToShow.Show();
        }

        private void HideAllGeneratorPanelsExcept(Panel PanelToShow)
        {
            PanelDatabase.Hide();
            PanelTable.Hide();
            PanelField.Hide();
            PanelSummary.Hide();

            PanelToShow.Show();
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

                    UserToFind = new User(txtFantasyNameOrEmail.Text, txtFantasyNameOrEmail.Text, Security.EncodeString(txtPassword.Text));

                    if (UserToFind.UserId == 0)//User not found
                    {
                        picErrorForFantasyNameOrEmail.Visible = true;
                        picErrorForPassword.Visible = true;
                        lblMessageDockedBottom.Text = "User not found";
                    }
                    else//User found
                    {
                        Converter.CopyObjectProperties(UserToFind, Program.WinFormConfigurationComponent.UserLogged);

                        if (Program.WinFormConfigurationComponent.RememberMe)
                        {
                            Program.WinFormConfigurationComponent.FantasyNameOrEmailFromLocalDB = UserToFind.FantasyName;
                        }
                        

                        Program.WinFormConfigurationComponent.UserLogged.UserId = UserToFind.UserId;
                        Program.WinFormConfigurationComponent.UserLogged.RoleId = UserToFind.RoleId;
                        Program.WinFormConfigurationComponent.UserLogged.Email = UserToFind.Email;
                        Program.WinFormConfigurationComponent.UserLogged.Password = UserToFind.Password;
                        Program.WinFormConfigurationComponent.UserLogged.Name = UserToFind.Name;
                        Program.WinFormConfigurationComponent.UserLogged.Role = UserToFind.Role;

                        lblMessageDockedBottom.Text = "User found. Entering";

                        HideAllPanelsExcept(PanelProject);
                        ShowingPanelProject();
                        LoadProjects();
                        NewProject();
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

        private void ShowingPanelProject()
        {
            //Basico (inicio)
            lblMessageDockedBottom.Text = "Loading";
            Cursor = Cursors.WaitCursor;

            PropertyGridProject.SelectedObject = new Project();

            lblTitle.Text = "Load or edit a project";
            lblSubtitle.Text = "";
            cambiarDatosDeUsuarioToolStripMenuItem.Visible = true;
        }

        private void LoadProjects()
        {
            ListViewProjects.Items.Clear();

            List<Project> lstProject = new Project()
                .GetAllByUserId(Program.WinFormConfigurationComponent.UserLogged.UserId);

            foreach (Project project in lstProject)
            {
                Program.WinFormConfigurationComponent.lstProject.Add(project);
                ListViewProjects.Items.Add(project.Name);
            }
        }

        private void NewProject()
        {
            lblMessageDockedBottom.Text = "Loading";
            Cursor = Cursors.WaitCursor;

            //Basic
            btnNewOrEdit.Image = Resources.btnNew;
            PropertyGridProject.SelectedObject = new Project();

            //Create a "zero" Project
            Program.WinFormConfigurationComponent.ProjectChosen = new Project();

            lblMessageDockedBottom.Text = "Ready";
            Cursor = Cursors.Default;
        }

        private void txtSearchYourProjectByName_KeyDown(object sender, KeyEventArgs e)
        {
            LoadProjects();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void btnDeleteYourProjects_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ListViewProjects.Items.Count; i++)
                {
                    if (ListViewProjects.Items[i].Checked)
                    {
                        Project Project = new Project(Convert.ToInt32(ListViewProjects.Items[i].Tag));
                        Project.DeleteByProjectId();

                        List<DataBase> lstDataBase = new DataBase().GetAllByProjectIdToModel(Project.ProjectId);
                        foreach (DataBase DataBase in lstDataBase)
                        {
                            List<Table> lstTable = new Table().GetAllByDataBaseIdToModel(DataBase.DataBaseId);

                            foreach (Table Table in lstTable)
                            {
                                List<Field> lstField = new Field().GetAllByTableIdToModel(Table.TableId);

                                foreach (Field Field in lstField)
                                {
                                    Field.DeleteByFieldId(Field.FieldId);
                                }

                                Table.DeleteByTableId(Table.TableId);
                            }

                            DataBase.DeleteByDataBaseId();
                        }
                    }
                }
                LoadProjects();
            }
            catch (Exception ex)
            {
                lblMessageDockedBottom.Text = ex.Message;
            }
        }

        private void ListViewYourProjects_ItemActivate(object sender, EventArgs e)
        {
            lblMessageDockedBottom.Text = "Loading";
            Cursor = Cursors.WaitCursor;
            btnNewOrEdit.Image = Resources.btnEdit;

            Project ProjectChosen = new Project();
            foreach (ListViewItem project in ListViewProjects.Items)
            {
                if (project.Selected)
                {
                    ProjectChosen = Program.WinFormConfigurationComponent.lstProject.Find(projectSaved =>
                            projectSaved.ProjectId == Convert.ToInt32(project.Tag));

                    //Load Basic panel of selected project
                    Program.WinFormConfigurationComponent.ProjectChosen = new Project(ProjectChosen.ProjectId);
                    PropertyGridProject.SelectedObject = Program.WinFormConfigurationComponent.ProjectChosen;
                }
            }

            lblMessageDockedBottom.Text = "Ready";
            Cursor = Cursors.Default;
        }

        private void cambiarDatosDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserData ChangePassword = new ChangeUserData();
            ChangePassword.ShowDialog();
        }

        private void btnNewOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //Validations
                Project Project = (Project)PropertyGridProject.SelectedObject;

                bool flagDuplicated = false;
                foreach (ListViewItem project in ListViewProjects.Items)
                {
                    if (project.Text == Project.Name)
                    {
                        flagDuplicated = true;
                    }
                }

                if (flagDuplicated)
                {
                    throw new Exception("Ya existe un proyecto guardado con ese nombre");
                }

                LoadPanelGenerator();
                HideAllPanelsExcept(PanelGenerator);
                LoadDataBases();

                #region Load auditing fields in a list 
                Models.Core.Field ActiveField = new Models.Core.Field()
                {
                    FieldId = 0,
                    TableId = 0,
                    DataTypeId = 4, //Boolean
                    Name = "Active",
                    Nullable = true,
                    HistoryUser = "For auditing purposes",
                    Regex = "",
                    MinValue = "",
                    MaxValue = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1
                };
                Models.Core.Field DateTimeCreationField = new Models.Core.Field()
                {
                    FieldId = 0,
                    TableId = 0,
                    DataTypeId = 10, //DateTime
                    Name = "DateTimeCreation",
                    Nullable = true,
                    HistoryUser = "For auditing purposes",
                    Regex = "",
                    MinValue = new DateTime(1753, 1, 1, 0, 0, 0, 0).ToString("yyyy-MM-ddTHH:mm"),
                    MaxValue = new DateTime(9998, 12, 30, 23, 59, 59, 999).ToString("yyyy-MM-ddTHH:mm"),
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1
                };
                Models.Core.Field DateTimeLastModificationField = new Models.Core.Field()
                {
                    FieldId = 0,
                    TableId = 0,
                    DataTypeId = 10, //DateTime
                    Name = "DateTimeLastModification",
                    Nullable = true,
                    HistoryUser = "For auditing purposes",
                    Regex = "",
                    MinValue = new DateTime(1753, 1, 1, 0, 0, 0, 0).ToString("yyyy-MM-ddTHH:mm"),
                    MaxValue = new DateTime(9998, 12, 30, 23, 59, 59, 999).ToString("yyyy-MM-ddTHH:mm"),
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1
                };
                Models.Core.Field UserCreationIdField = new Models.Core.Field()
                {
                    FieldId = 0,
                    TableId = 0,
                    DataTypeId = 13, //Foreign Key (Id)
                    Name = "UserCreationId",
                    Nullable = true,
                    HistoryUser = "For auditing purposes",
                    Regex = "",
                    MinValue = "",
                    MaxValue = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1
                };
                Models.Core.Field UserLastModificationIdField = new Models.Core.Field()
                {
                    FieldId = 0,
                    TableId = 0,
                    DataTypeId = 13, //Foreign Key (Id)
                    Name = "UserLastModificationId",
                    Nullable = true,
                    HistoryUser = "For auditing purposes",
                    Regex = "",
                    MinValue = "",
                    MaxValue = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1
                };
                Program.WinFormConfigurationComponent.lstAuditingFields.Add(ActiveField);
                Program.WinFormConfigurationComponent.lstAuditingFields.Add(DateTimeCreationField);
                Program.WinFormConfigurationComponent.lstAuditingFields.Add(DateTimeLastModificationField);
                Program.WinFormConfigurationComponent.lstAuditingFields.Add(UserCreationIdField);
                Program.WinFormConfigurationComponent.lstAuditingFields.Add(UserLastModificationIdField);
                #endregion

                #region Default Configuration
                //Search the Configuration for the selected project
                Configuration Configuration = new Configuration().GetOneByProjectIdToModel(Program.WinFormConfigurationComponent.ProjectChosen.ProjectId);
                if (Configuration.ConfigurationId == 0)
                {
                    //If Configuration not found create one
                    Configuration = Program.WinFormConfigurationComponent.LoadDefaultConfiguration();
                    Configuration.ProjectId = Program.WinFormConfigurationComponent.ProjectChosen.ProjectId;
                    Configuration.UserCreationId = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    Configuration.UserLastModificationId = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    Configuration.Add();
                }
                #endregion

                Program.WinFormConfigurationComponent.LoadConfiguration();

                //Load
                DataBase Database = new();
                Program.WinFormConfigurationComponent.DataBaseChosen = Database;

                //Load empty PropertyGridDatabase
                DataBase DataBase = new()
                {
                    ConnectionStringForMSSQLServer = "data source =.; initial catalog = [PUT_A_DATABASE_NAME]; Integrated Security = SSPI; MultipleActiveResultSets=True;Pooling=false;Persist Security Info=True;App=EntityFramework;TrustServerCertificate=True"
                };

                Program.WinFormConfigurationComponent.DataBaseChosen = DataBase;
                PropertyGridDatabase.SelectedObject = Program.WinFormConfigurationComponent.DataBaseChosen;

                btnAddDatabase.Image = Resources.btnNew;
                lblActionDatabase.Text = "Add";

                volverAProyectosToolStripMenuItem.Visible = true;

                lblMessageDockedBottom.Text = "Project loaded";
                lblTitle.Text = $@"Project: {Program.WinFormConfigurationComponent.ProjectChosen.Name}";
                lblSubtitle.Text = $@"Database: | Table: | Field: ";
            }
            catch (Exception ex)
            {
                lblMessageDockedBottom.Text = ex.Message;
            }
        }

        private void LoadPanelGenerator()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int _ProjectId = 0;
                if (Program.WinFormConfigurationComponent.ProjectChosen.ProjectId == 0) //New project
                {
                    lblMessageDockedBottom.Text = "Creating new project";

                    #region Basic
                    Program.WinFormConfigurationComponent.ProjectChosen = (Project)PropertyGridProject.SelectedObject;
                    Program.WinFormConfigurationComponent.ProjectChosen.Active = true;
                    Program.WinFormConfigurationComponent.ProjectChosen.DateTimeCreation = DateTime.Now;
                    Program.WinFormConfigurationComponent.ProjectChosen.DateTimeLastModification = Program.WinFormConfigurationComponent.ProjectChosen.DateTimeCreation;
                    Program.WinFormConfigurationComponent.ProjectChosen.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    Program.WinFormConfigurationComponent.ProjectChosen.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    #endregion

                    _ProjectId = Program.WinFormConfigurationComponent.ProjectChosen.Add();
                }
                else //Edit project
                {
                    lblMessageDockedBottom.Text = "Editing project";

                    _ProjectId = Program.WinFormConfigurationComponent.ProjectChosen.ProjectId;

                    #region Basic
                    Program.WinFormConfigurationComponent.ProjectChosen = (Project)PropertyGridProject.SelectedObject;
                    Program.WinFormConfigurationComponent.ProjectChosen.Active = true;
                    //Program.WinFormConfigurationComponent.ProjectChosen.DateTimeCreation = DateTime.Now; NO MODIFICATION
                    Program.WinFormConfigurationComponent.ProjectChosen.DateTimeLastModification = DateTime.Now;
                    //Program.WinFormConfigurationComponent.ProjectChosen.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId; NO MODIFICATION
                    Program.WinFormConfigurationComponent.ProjectChosen.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;

                    Program.WinFormConfigurationComponent.ProjectChosen.Update();
                    #endregion
                }

                Program.WinFormConfigurationComponent.ProjectChosen = new Project(_ProjectId);
                Cursor = Cursors.Default;
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation and preparing
                lblMessageDockedBottom.Text = "Validating and preparing";
                HideAllGeneratorPanelsExcept(PanelSummary);

                Program.WinFormConfigurationComponent.lstTableToGenerate = [];
                Program.WinFormConfigurationComponent.lstFieldToGenerate = [];

                //Before generation done
                TextBoxLogger.Clear();
                lblMessageDockedBottom.Text = "Starting...";
                PanelSummary.Visible = true;

                //Start generation
                Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate = [];
                //List of actions for stored procedures
                List<string> lstStoredProcedureAction =
                [
                "Insert", "UpdateBy", "DeleteBy", "Select1By", "SelectAll", "SelectAllPaged", "Count", "DeleteAll"
                ];

                for (int i = 0; i < ListViewTable.Items.Count; i++)
                {
                    if (ListViewTable.Items[i].Checked)
                    {
                        if (ListViewTable.Items[i].ImageIndex == 3) { throw new Exception("It is not allowed to generate external tables. First, import them."); }
                        if (ListViewTable.Items[i].ImageIndex == 2) { throw new Exception("It is not allowed to generate using blinded tables. First, give a ConnectionString"); }
                        if (ListViewTable.Items[i].ImageIndex == 0 ||
                            ListViewTable.Items[i].ImageIndex == 1 ||
                            ListViewTable.Items[i].ImageIndex == 13) //OK or Need to upload or Virtual model
                        {
                            Table TableChecked = new(Convert.ToInt32(ListViewTable.Items[i].Tag));
                            if (TableChecked.TableId == 0 ||
                                TableChecked.Name.Trim() == "" ||
                                TableChecked.Name == null ||
                                TableChecked.Scheme.Trim() == "" ||
                                TableChecked.Scheme == null ||
                                TableChecked.Area.Trim() == "" ||
                                TableChecked.Area == null)
                            { throw new Exception("It is not allowed to generate tables without neccessary data"); }
                            else
                            {
                                //Fill a list of tables, fields and stored procedures to generate
                                Program.WinFormConfigurationComponent.lstTableToGenerate.Add(TableChecked);
                                foreach (Field field in new Field().GetAllByTableIdToModel(TableChecked.TableId))
                                {
                                    Program.WinFormConfigurationComponent.lstFieldToGenerate.Add(field);
                                }

                                int actionId = 0;
                                foreach (string action in lstStoredProcedureAction)
                                {
                                    StoredProcedure storedprocedure = new()
                                    {
                                        TableArea = TableChecked.Area,
                                        TableName = TableChecked.Name,
                                        SchemeName = TableChecked.Scheme
                                    };
                                    switch (actionId)
                                    {
                                        case 0: //Insert
                                            storedprocedure.Action = action;
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        case 1: //UpdateBy
                                            storedprocedure.Action = $"{action}{TableChecked.Name}Id";
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        case 2: //DeleteBy
                                            storedprocedure.Action = $"{action}{TableChecked.Name}Id";
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        case 3: //Select1By
                                            storedprocedure.Action = $"{action}{TableChecked.Name}Id";
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        case 4: //SelectAll
                                            storedprocedure.Action = action;
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        case 5: //SelectAllPaged
                                            storedprocedure.Action = action;
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        case 6: //Count
                                            storedprocedure.Action = action;
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        case 7: //DeleteAll
                                            storedprocedure.Action = action;
                                            Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate.Add(storedprocedure);
                                            break;
                                        default:
                                            throw new Exception("An unexpected value entered inside validation and preparation step");
                                    }

                                    actionId += 1;
                                }
                            }
                        }
                    }
                }

                if (Program.WinFormConfigurationComponent.lstTableToGenerate.Count == 0)
                {
                    lblMessageDockedBottom.Text = "Nothing to generate";
                    TextBoxLogger.Text += "Nothing to generate";

                    return;
                }

                Cursor = Cursors.WaitCursor;

                if (Program.WinFormConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer.Trim() != "")
                {
                    TextBoxLogger.Text += GeneratorJsTsNETCoreSQLServer.Start(Program.WinFormConfigurationComponent.Configuration,
                                    new fieldChainerNET8MSSQLServerAPI(),
                                    new modelChainerNET8MSSQLServerAPI(),
                                    new fieldChainerNodeJsExpressMongoDB(),
                                    new fieldChainerJsTsNETCoreSQLServer(),
                                    new modelChainerJsTsNETCoreSQLServer(),
                                    new fieldChainerNET8BlazorMSSQLServerCodeFirst(),
                                    Program.WinFormConfigurationComponent.ProjectChosen,
                                    Program.WinFormConfigurationComponent.DataBaseChosen,
                                    Program.WinFormConfigurationComponent.lstTableInFiyiStack,
                                    Program.WinFormConfigurationComponent.lstTableToGenerate,
                                    Program.WinFormConfigurationComponent.lstFieldToGenerate,
                                    Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate);
                }
                else if (Program.WinFormConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture.Trim() != "")
                {
                    TextBoxLogger.Text += GeneratorNET6CleanArchitecture.Start(Program.WinFormConfigurationComponent.Configuration,
                                    new fieldChainerNET8MSSQLServerAPI(),
                                    new modelChainerNET8MSSQLServerAPI(),
                                    new fieldChainerNodeJsExpressMongoDB(),
                                    new fieldChainerJsTsNETCoreSQLServer(),
                                    new modelChainerJsTsNETCoreSQLServer(),
                                    new fieldChainerNET8BlazorMSSQLServerCodeFirst(),
                                    Program.WinFormConfigurationComponent.ProjectChosen,
                                    Program.WinFormConfigurationComponent.DataBaseChosen,
                                    Program.WinFormConfigurationComponent.lstTableInFiyiStack,
                                    Program.WinFormConfigurationComponent.lstTableToGenerate,
                                    Program.WinFormConfigurationComponent.lstFieldToGenerate,
                                    Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate);
                }
                else if (Program.WinFormConfigurationComponent.ProjectChosen.PathNodeJsExpressMongoDB.Trim() != "")
                {
                    TextBoxLogger.Text += GeneratorNodeJsExpressMongoDB.Start(Program.WinFormConfigurationComponent.Configuration,
                                    new fieldChainerNET8MSSQLServerAPI(),
                                    new modelChainerNET8MSSQLServerAPI(),
                                    new fieldChainerNodeJsExpressMongoDB(),
                                    new fieldChainerJsTsNETCoreSQLServer(),
                                    new modelChainerJsTsNETCoreSQLServer(),
                                    new fieldChainerNET8BlazorMSSQLServerCodeFirst(),
                                    Program.WinFormConfigurationComponent.ProjectChosen,
                                    Program.WinFormConfigurationComponent.DataBaseChosen,
                                    Program.WinFormConfigurationComponent.lstTableInFiyiStack,
                                    Program.WinFormConfigurationComponent.lstTableToGenerate,
                                    Program.WinFormConfigurationComponent.lstFieldToGenerate,
                                    Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate);
                }
                else if (Program.WinFormConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI.Trim() != "")
                {
                    TextBoxLogger.Text += GeneratorNET8MSSQLServerAPI.Start(Program.WinFormConfigurationComponent.Configuration,
                                    new fieldChainerNET8MSSQLServerAPI(),
                                    new modelChainerNET8MSSQLServerAPI(),
                                    new fieldChainerNodeJsExpressMongoDB(),
                                    new fieldChainerJsTsNETCoreSQLServer(),
                                    new modelChainerJsTsNETCoreSQLServer(),
                                    new fieldChainerNET8BlazorMSSQLServerCodeFirst(),
                                    Program.WinFormConfigurationComponent.ProjectChosen,
                                    Program.WinFormConfigurationComponent.DataBaseChosen,
                                    Program.WinFormConfigurationComponent.lstTableInFiyiStack,
                                    Program.WinFormConfigurationComponent.lstTableToGenerate,
                                    Program.WinFormConfigurationComponent.lstFieldToGenerate,
                                    Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate);
                }
                else
                {
                    TextBoxLogger.Text += GeneratorNET8BlazorMSSQLServerCodeFirst.Start(Program.WinFormConfigurationComponent.Configuration,
                                    new fieldChainerNET8MSSQLServerAPI(),
                                    new modelChainerNET8MSSQLServerAPI(),
                                    new fieldChainerNodeJsExpressMongoDB(),
                                    new fieldChainerJsTsNETCoreSQLServer(),
                                    new modelChainerJsTsNETCoreSQLServer(),
                                    new fieldChainerNET8BlazorMSSQLServerCodeFirst(),
                                    Program.WinFormConfigurationComponent.ProjectChosen,
                                    Program.WinFormConfigurationComponent.DataBaseChosen,
                                    Program.WinFormConfigurationComponent.lstTableInFiyiStack,
                                    Program.WinFormConfigurationComponent.lstTableToGenerate,
                                    Program.WinFormConfigurationComponent.lstFieldToGenerate,
                                    Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate);
                }

                //After generation done
                LoadTables();
                ListViewField.Clear();
                lblMessageDockedBottom.Text = "Ready. Generation done";
                TextBoxLogger.Text += "Ready. Generation done";
                Cursor = Cursors.Default;
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void LoadTables()
        {
            try
            {
                lblMessageDockedBottom.Text = "Loading tables";
                Cursor = Cursors.WaitCursor;

                if (Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId == 0) { throw new Exception("Select a database"); }

                Models.Core.Table Table = new Models.Core.Table();
                Program.WinFormConfigurationComponent.lstTableInFiyiStack = Table.GetAllByDataBaseIdToModel(Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId);

                //Fill listview
                ListViewTable.Clear();
                foreach (Models.Core.Table table in Program.WinFormConfigurationComponent.lstTableInFiyiStack)
                {
                    ListViewItem lvi = new ListViewItem($"[{table.Scheme}].[{table.Area}.{table.Name}]");
                    lvi.Tag = table.TableId;

                    //Analyze if the Table exist in the DB hosting/Database only if the user provide a ConnectionString
                    if (Program.WinFormConfigurationComponent.DataBaseChosen.IsMSSQLServer)
                    {
                        FiyiStack.Library.MicrosoftSQLServer.Table MSSQLServerTable = new FiyiStack.Library.MicrosoftSQLServer.Table();
                        if (MSSQLServerTable.DoesTableExist(Program.WinFormConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer, table.Area, table.Name, table.Scheme))
                        {
                            if (table.TableId != 0)
                            {
                                lvi.ImageIndex = 0; //OK 
                            }
                            else
                            {
                                lvi.ImageIndex = 3; //Need to import to FiyiStack
                            }
                        }
                        else { lvi.ImageIndex = 1; } //Need to upload/create Table inside DB hosting/DataBase
                    }
                    else
                    {
                        lvi.ImageIndex = 2; //NotSee. The user do not provide a ConnectionString to analyze
                    }

                    ListViewTable.Items.Add(lvi);
                }

                //Fill PropertyGridTable
                Table = new Models.Core.Table();
                Program.WinFormConfigurationComponent.TableChosen = Table;
                PropertyGridTable.SelectedObject = Program.WinFormConfigurationComponent.TableChosen;

                lblMessageDockedBottom.Text = "Tables loaded. Ready";
                btnAddTable.Image = Resources.btnNew;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            { lblMessageDockedBottom.Text = ex.Message; ListViewTable.Items.Clear(); ListViewField.Items.Clear(); Cursor = Cursors.Default; }
        }

        private void btnShowConfigurationForm_Click(object sender, EventArgs e)
        {
            ConfigurationForm ConfigurationForm = new ConfigurationForm();
            ConfigurationForm.ShowDialog();
        }

        private void labelDataBase_Click(object sender, EventArgs e)
        {
            HideAllGeneratorPanelsExcept(PanelDatabase);
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = false;
            picStep3Properties.Visible = false;
        }

        private void labelTables_Click(object sender, EventArgs e)
        {
            HideAllGeneratorPanelsExcept(PanelTable);
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = true;
            picStep3Properties.Visible = false;
        }

        private void labelFields_Click(object sender, EventArgs e)
        {
            HideAllGeneratorPanelsExcept(PanelField );
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = true;
            picStep3Properties.Visible = true;
        }

        private void btnCopyDBLocalhost_Click(object sender, EventArgs e)
        {
            Models.Core.DataBase DataBase = new Models.Core.DataBase
            {
                ConnectionStringForMSSQLServer = "data source =.;initial catalog=[PUT_A_DATABASE_NAME];Integrated Security = SSPI;MultipleActiveResultSets=True;Pooling=false;persist security info=True;App=EntityFramework",
                DateTimeLastModification = DateTime.Now,
                DateTimeCreation = DateTime.Now
            };

            Program.WinFormConfigurationComponent.DataBaseChosen = DataBase;

            PropertyGridDatabase.SelectedObject = Program.WinFormConfigurationComponent.DataBaseChosen;
        }

        private void btnCopyDBProduction_Click(object sender, EventArgs e)
        {
            Models.Core.DataBase DataBase = new Models.Core.DataBase();
            DataBase.ConnectionStringForMSSQLServer = "Password=[PUT_A_PASSWORD];Persist Security Info=True;User ID=[PUT_A_USER_ID];Initial Catalog=[PUT_A_DATABASE_NAME];Data Source=[PUT_A_SOURCE_(SERVER)];TrustServerCertificate=True";
            DataBase.DateTimeLastModification = DateTime.Now;
            DataBase.DateTimeCreation = DateTime.Now;

            Program.WinFormConfigurationComponent.DataBaseChosen = DataBase;

            PropertyGridDatabase.SelectedObject = Program.WinFormConfigurationComponent.DataBaseChosen;
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                //Mantain important data
                string DatabaseName = Program.WinFormConfigurationComponent.DataBaseChosen.Name;

                //Collect data
                Program.WinFormConfigurationComponent.DataBaseChosen.ProjectId = Program.WinFormConfigurationComponent.ProjectChosen.ProjectId;
                Program.WinFormConfigurationComponent.DataBaseChosen.Active = true;
                Program.WinFormConfigurationComponent.DataBaseChosen.DateTimeLastModification = DateTime.Now;
                Program.WinFormConfigurationComponent.DataBaseChosen.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;

                if (lblActionDatabase.Text == "Add") //Add database
                {
                    Program.WinFormConfigurationComponent.DataBaseChosen.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId;
                    Program.WinFormConfigurationComponent.DataBaseChosen.DateTimeCreation = DateTime.Now;
                    Program.WinFormConfigurationComponent.DataBaseChosen.Add();
                    lblMessageDockedBottom.Text = $"Database {DatabaseName} added correctly";
                }
                else //Edit database
                {
                    Program.WinFormConfigurationComponent.DataBaseChosen.UpdateByDataBaseId();
                    lblMessageDockedBottom.Text = $"Database {DatabaseName} updated correctly";
                }
                Program.WinFormConfigurationComponent.DataBaseChosen = new Models.Core.DataBase(Program.WinFormConfigurationComponent.ProjectChosen.ProjectId, DatabaseName);

                LoadDataBases();
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void volverAProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideAllPanelsExcept(PanelProject);
            lblTitle.Text = "Load or edit a project";
            lblSubtitle.Text = $@"";
        }

        private void btnDeleteDataBases_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ListViewDatabase.Items.Count; i++)
                {
                    if (ListViewDatabase.Items[i].Checked)
                    {
                        //First, delete the DataBase
                        Models.Core.DataBase DataBase = new Models.Core.DataBase(Convert.ToInt32(ListViewDatabase.Items[i].Tag));

                        DataBase.DeleteByDataBaseId();

                        //Second, delete the Tables associated to that Database
                        Models.Core.Table Table = new Models.Core.Table();
                        List<Models.Core.Table> _lstTable = Table.GetAllByDataBaseIdToModel(Convert.ToInt32(ListViewDatabase.Items[i].Tag));
                        Table.DeleteByDataBaseId(Convert.ToInt32(ListViewDatabase.Items[i].Tag));

                        //Third, delete the Fields associated to each Table associated to that DataBase
                        foreach (Models.Core.Table table in _lstTable)
                        {
                            Models.Core.Field Field = new Models.Core.Field();
                            Field.DeleteByTableId(table.TableId);
                        }

                        LoadDataBases();
                        ListViewTable.Clear();
                        ListViewField.Clear();
                    }
                }
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void LoadDataBases()
        {
            try
            {
                lblMessageDockedBottom.Text = "Loading";
                Cursor = Cursors.WaitCursor;

                Models.Core.DataBase DataBase = new Models.Core.DataBase();
                Program.WinFormConfigurationComponent.lstDataBaseInFiyiStack = DataBase.GetAllByProjectIdToModel(Program.WinFormConfigurationComponent.ProjectChosen.ProjectId);

                //Fill listview
                ListViewDatabase.Clear();
                foreach (Models.Core.DataBase database in Program.WinFormConfigurationComponent.lstDataBaseInFiyiStack)
                {
                    ListViewItem lvi = new ListViewItem(database.Name);
                    lvi.Tag = database.DataBaseId;
                    lvi.ImageIndex = 0; //OK 
                    ListViewDatabase.Items.Add(lvi);
                }

                lblMessageDockedBottom.Text = "Ready";
                btnAddDatabase.Image = Resources.btnNew;
                Cursor = Cursors.Default;
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void picAddDataBase_Click(object sender, EventArgs e)
        {
            Models.Core.DataBase DataBase = new Models.Core.DataBase();

            DataBase.ConnectionStringForMSSQLServer = "data source =.; initial catalog = [PUT_A_DATABASE_NAME]; Integrated Security = SSPI; MultipleActiveResultSets=True;Pooling=false;Persist Security Info=True;App=EntityFramework;TrustServerCertificate=True";

            Program.WinFormConfigurationComponent.DataBaseChosen = DataBase;
            PropertyGridDatabase.SelectedObject = Program.WinFormConfigurationComponent.DataBaseChosen;

            btnAddDatabase.Image = Resources.btnNew;
            lblActionDatabase.Text = "Add";
        }

        private void btnRefreshDataBases_Click(object sender, EventArgs e)
        {
            LoadDataBases();
        }

        private void ListViewDatabase_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ListViewDatabase.Items.Count; i++)
                {
                    if (ListViewDatabase.Items[i].Selected)
                    {
                        Program.WinFormConfigurationComponent.DataBaseChosen = new Models.Core.DataBase(Convert.ToInt32(ListViewDatabase.Items[i].Tag));

                        PropertyGridDatabase.SelectedObject = Program.WinFormConfigurationComponent.DataBaseChosen;

                        lblActionDatabase.Text = "Edit";

                        LoadTables();

                        btnAddDatabase.Image = Resources.btnEdit;
                    }
                }

                lblSubtitle.Text = $@"Database: {Program.WinFormConfigurationComponent.DataBaseChosen.Name} ({Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId}) | Table: | Field: ";
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void btnDeleteTables_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ListViewTable.Items.Count; i++)
                {
                    if (ListViewTable.Items[i].Checked)
                    {
                        if (ListViewTable.Items[i].ImageIndex != 3) //It is not allowed to delete external tables. First, import them.
                        {
                            Table Table = new Table(Convert.ToInt32(ListViewTable.Items[i].Tag));
                            //First, delete the Table inside FiyiStack
                            Table.DeleteByTableId(Convert.ToInt32(ListViewTable.Items[i].Tag));

                            //Second, delete all the Fields inside FiyiStack associated to that table
                            Field Field = new Field();
                            Field.DeleteByTableId(Convert.ToInt32(ListViewTable.Items[i].Tag));

                            LoadTables();
                            ListViewField.Clear();
                        }
                        else { lblMessageDockedBottom.Text = "It is not allowed to delete external tables."; }
                    }
                }
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void btnSelectAllTable_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lviTable in ListViewTable.Items)
            {
                lviTable.Checked = true;
            }
        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {
            Table Table = new();
            Program.WinFormConfigurationComponent.TableChosen = Table;
            PropertyGridTable.SelectedObject = Program.WinFormConfigurationComponent.TableChosen;

            btnAddTable.Image = Resources.btnNew;
            lblActionTable.Text = "Add";

            //Uncheck all fields in ListViewTable
            foreach (ListViewItem item in ListViewTable.Items)
            {
                item.Checked = false;
                item.Focused = false;
                item.Selected = false;
            }
        }

        private void btnRefreshTables_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void ListViewTable_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ListViewTable.Items.Count; i++)
                {
                    if (ListViewTable.Items[i].Selected)
                    {
                        Program.WinFormConfigurationComponent.TableChosen = new Models.Core.Table(Convert.ToInt32(ListViewTable.Items[i].Tag));

                        string[] Table = ListViewTable.Items[i].Text.Replace("].[", "").Replace("[", "").Replace("]", "").Split('.');

                        PropertyGridTable.SelectedObject = Program.WinFormConfigurationComponent.TableChosen;

                        lblActionTable.Text = "Edit";

                        LoadFields();

                        btnAddTable.Image = Resources.btnEdit;
                    }
                }

                lblSubtitle.Text = $@"Database: {Program.WinFormConfigurationComponent.DataBaseChosen.Name} ({Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId}) | Table: {Program.WinFormConfigurationComponent.TableChosen.Name} ({Program.WinFormConfigurationComponent.TableChosen.TableId}) | Field: ";
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void LoadFields()
        {
            try
            {
                lblMessageDockedBottom.Text = "Loading";
                Cursor = Cursors.WaitCursor;

                if (Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId == 0) { throw new Exception("Select a database"); }
                if (Program.WinFormConfigurationComponent.TableChosen.TableId == 0) { throw new Exception("If you want to see the fields of the selected table, you have to import it first"); }

                Models.Core.Field Field = new Models.Core.Field();
                Program.WinFormConfigurationComponent.lstFieldInFiyiStack = Field.GetAllByTableIdToModel(Program.WinFormConfigurationComponent.TableChosen.TableId);

                //Look for fields created outside FiyiStack
                List<Models.Core.Field> lstFieldsCreatedOutsideFiyiStack = LoadFieldsCreatedOutsideFiyiStack();
                if (lstFieldsCreatedOutsideFiyiStack != null)
                {
                    bool existfield = false;
                    foreach (Models.Core.Field fieldcreatedoutsidefiyistack in lstFieldsCreatedOutsideFiyiStack)
                    {
                        foreach (Models.Core.Field field in Program.WinFormConfigurationComponent.lstFieldInFiyiStack)
                        {
                            if (field.Name == fieldcreatedoutsidefiyistack.Name)
                            { existfield = true; }
                        }
                        if (!existfield)
                        {
                            Program.WinFormConfigurationComponent.lstFieldInFiyiStack.Add(fieldcreatedoutsidefiyistack);
                        }
                        existfield = false;
                    }
                }

                //Fill listview
                ListViewField.Clear();
                foreach (Models.Core.Field field in Program.WinFormConfigurationComponent.lstFieldInFiyiStack)
                {
                    ListViewItem lvi = new ListViewItem($"{field.Name}");
                    lvi.Tag = field.FieldId;


                    //Analyze if the Field exist in the DB hosting/Database only if the user provide a ConnectionString

                    FiyiStack.Library.MicrosoftSQLServer.Field MSSQLServerField = new FiyiStack.Library.MicrosoftSQLServer.Field();
                    if (MSSQLServerField.DoesFieldExist(
                        Program.WinFormConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer,
                        Program.WinFormConfigurationComponent.TableChosen.Area,
                        Program.WinFormConfigurationComponent.TableChosen.Name,
                        Program.WinFormConfigurationComponent.TableChosen.Scheme,
                        field.Name))
                    {
                        if (field.FieldId != 0)
                        {
                            //lvi.ImageIndex = 0; OK 

                            //The next lines are to improve the UX of DataTypes
                            switch (field.DataTypeId)
                            {
                                case 3: //Integer
                                    lvi.ImageIndex = 4;
                                    break;
                                case 4: //Boolean
                                    lvi.ImageIndex = 5;
                                    break;
                                case 5: //Text: Basic
                                    lvi.ImageIndex = 6;
                                    break;
                                case 6: //Decimal
                                    lvi.ImageIndex = 7;
                                    break;
                                case 8: //Primary Key (Id)
                                    lvi.ImageIndex = 8;
                                    break;
                                case 10: //DateTime
                                    lvi.ImageIndex = 9;
                                    break;
                                case 11: //Time
                                    lvi.ImageIndex = 10;
                                    break;
                                case 13: //Foreign Key (Id): Options
                                    lvi.ImageIndex = 11;
                                    break;
                                case 14: //Text: HexColour
                                    lvi.ImageIndex = 6;
                                    break;
                                case 15: //Text: TextArea
                                    lvi.ImageIndex = 6;
                                    break;
                                case 16: //Text: TextEditor
                                    lvi.ImageIndex = 6;
                                    break;
                                case 17: //Text: Password
                                    lvi.ImageIndex = 6;
                                    break;
                                case 18: //Text: PhoneNumber
                                    lvi.ImageIndex = 6;
                                    break;
                                case 19: //Text: URL
                                    lvi.ImageIndex = 6;
                                    break;
                                case 20: //Text: Email
                                    lvi.ImageIndex = 6;
                                    break;
                                case 21: //Text: File
                                    lvi.ImageIndex = 6;
                                    break;
                                case 22: //Text: Tag
                                    lvi.ImageIndex = 6;
                                    break;
                                case 23: //Foreign Key (Id): DropDown
                                    lvi.ImageIndex = 11;
                                    break;
                                default:
                                    throw new Exception($"{field.Name} have a Data Type not recognized");
                            }
                        }
                        else
                        {
                            lvi.ImageIndex = 3; //Need to import to FiyiStack
                        }
                    }
                    else { lvi.ImageIndex = 1; } //Need to upload/create Field inside DB hosting/DataBase

                    ListViewField.Items.Add(lvi);
                }

                lblMessageDockedBottom.Text = "Fields loaded. Ready";
                btnAddField.Image = Resources.btnNew;
                txtFieldName.Text = "";
                txtFieldHistoryUser.Text = "";
                chbNullable.Checked = false;
                cmbDataType.SelectedIndex = 0;
                Cursor = Cursors.Default;
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; ListViewField.Items.Clear(); Cursor = Cursors.Default; }
        }

        private List<Models.Core.Field> LoadFieldsCreatedOutsideFiyiStack()
        {
            try
            {
                if (Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId == 0) { throw new Exception("Select a database"); }
                if (Program.WinFormConfigurationComponent.TableChosen.TableId == 0) { throw new Exception("Select a table"); }


                if (Program.WinFormConfigurationComponent.DataBaseChosen.IsMSSQLServer)
                {
                    //Fill a List<CommonFunctions.MSSQLServer.Field>
                    FiyiStack.Library.MicrosoftSQLServer.Field MSSQLServerField = new FiyiStack.Library.MicrosoftSQLServer.Field();
                    List<FiyiStack.Library.MicrosoftSQLServer.Field> lstFieldCreatedOutsideFiyiStack = new List<FiyiStack.Library.MicrosoftSQLServer.Field>();
                    lstFieldCreatedOutsideFiyiStack = MSSQLServerField.GetAllFieldsByTableNameBySchemeNameToModel(Program.WinFormConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer,
                        Program.WinFormConfigurationComponent.TableChosen.Name, Program.WinFormConfigurationComponent.TableChosen.Scheme);



                    //Move the above list to List<Models.Core.Field>
                    List<Models.Core.Field> lstField = new List<Models.Core.Field>();
                    foreach (FiyiStack.Library.MicrosoftSQLServer.Field fieldcreatedoutsidefiyistack in lstFieldCreatedOutsideFiyiStack)
                    {
                        Models.Core.Field Field = new Models.Core.Field();
                        Field.Name = fieldcreatedoutsidefiyistack.Name;
                        lstField.Add(Field);
                    }
                    return lstField;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; ListViewField.Items.Clear(); return null; }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                //Validations
                if (Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId == 0)
                { throw new Exception("First, select a database"); }

                Cursor = Cursors.WaitCursor;

                //Mantain important data
                string TableChosenScheme = Program.WinFormConfigurationComponent.TableChosen.Scheme;
                string TableChosenArea = Program.WinFormConfigurationComponent.TableChosen.Area;
                string TableChosenName = Program.WinFormConfigurationComponent.TableChosen.Name;

                for (int i = 0; i < ListViewTable.Items.Count; i++)
                {
                    if (ListViewTable.Items[i].Selected)
                    {
                        if (ListViewTable.Items[i].ImageIndex != 3) //It is not allowed to configure external tables. First, import them.
                        {
                            Models.Core.Table savedTable = new Models.Core.Table(Convert.ToInt32(ListViewTable.Items[i].Tag));
                            if ($@"[{savedTable.Scheme}].[{savedTable.Area}.{savedTable.Name}]" !=
                                $@"[{TableChosenScheme}].[{TableChosenArea}.{TableChosenName}]") //Search to verify inexistance
                            {
                                savedTable = savedTable.GetOneByDataBaseIdByNameBySchemeToModel(
                                    Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId,
                                    TableChosenArea,
                                    TableChosenName,
                                    TableChosenScheme);
                                if (savedTable.TableId != 0) { throw new Exception($"The table [{TableChosenScheme}].[{TableChosenArea}.{TableChosenName}] already exist in the database {Program.WinFormConfigurationComponent.DataBaseChosen.Name}"); }
                            }
                        }
                        else { throw new Exception("It is not allowed to configure external tables"); }
                    }
                }

                //Collect data
                Program.WinFormConfigurationComponent.TableChosen.DataBaseId = Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId;
                Program.WinFormConfigurationComponent.TableChosen.Active = true;
                Program.WinFormConfigurationComponent.TableChosen.DateTimeLastModification = DateTime.Now;
                Program.WinFormConfigurationComponent.TableChosen.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;

                if (lblActionTable.Text == "Add") //Add table
                {
                    Program.WinFormConfigurationComponent.TableChosen.DateTimeCreation = DateTime.Now;
                    Program.WinFormConfigurationComponent.TableChosen.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId;

                    int TableAddedId = Program.WinFormConfigurationComponent.TableChosen.Add();

                    //Adding Primary Key (Id) always
                    Models.Core.Field Field = new Models.Core.Field()
                    {
                        FieldId = 0,
                        TableId = TableAddedId,
                        DataTypeId = 8, //Primary Key (Id)
                        Name = TableChosenName + "Id",
                        Nullable = false,
                        HistoryUser = "",
                        Regex = "",
                        MinValue = "",
                        MaxValue = "",
                        Active = true,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId,
                        UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId
                    };
                    Field.Add();

                    //Adding auditing fields if the user want
                    if (Program.WinFormConfigurationComponent.Configuration.AddAuditingFieldsToNewTable)
                    {
                        foreach (Models.Core.Field field in Program.WinFormConfigurationComponent.lstAuditingFields)
                        {
                            field.TableId = TableAddedId;
                            field.Add();
                        }
                    }


                    Cursor = Cursors.Default;
                }
                else //Update table
                {
                    Program.WinFormConfigurationComponent.TableChosen.UpdateByTableId();
                }

                Program.WinFormConfigurationComponent.TableChosen = new Models.Core.Table(Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId, TableChosenArea, TableChosenName, TableChosenScheme);

                LoadTables();

                LoadFields();

                btnAddTable.Image = Resources.btnNew;
                lblActionTable.Text = "Add";
                lblMessageDockedBottom.Text = $"Ready. [{Program.WinFormConfigurationComponent.TableChosen.Scheme}].[{Program.WinFormConfigurationComponent.TableChosen.Area}.{Program.WinFormConfigurationComponent.TableChosen.Name}] added/updated correctly";
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void btnDeleteField_Click(object sender, EventArgs e)
        {
            try
            {

                //This a for cycle for validation
                for (int i = 0; i < ListViewField.Items.Count; i++)
                {
                    if (ListViewField.Items[i].Checked)
                    {
                        if (ListViewField.Items[i].ImageIndex == 3)
                        { throw new Exception("It is not allowed to delete external fields. First, import them."); }
                        if (ListViewField.Items[i].Text == Program.WinFormConfigurationComponent.TableChosen.Name + "Id")
                        { throw new Exception("It is not allowed to delete the Primary Key field. You have to delete the entire table"); }
                    }
                }

                //Here is the deletion
                for (int i = 0; i < ListViewField.Items.Count; i++)
                {
                    if (ListViewField.Items[i].Checked)
                    {
                        Models.Core.Field Field = new Models.Core.Field();

                        Field.DeleteByFieldId(Convert.ToInt32(ListViewField.Items[i].Tag));

                        LoadFields();
                    }
                }
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void btnSelectAllField_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lviField in ListViewField.Items)
            {
                lviField.Checked = true;
            }
        }

        private void picAddFieldButton_Click(object sender, EventArgs e)
        {
            txtFieldName.Text = "";
            chbNullable.Checked = false;
            txtFieldHistoryUser.Text = "";
            cmbDataType.SelectedIndex = 0;
            btnAddField.Image = Resources.btnNew;

            //Uncheck all fields in ListViewField
            foreach (ListViewItem item in ListViewField.Items)
            {
                item.Checked = false;
                item.Focused = false;

                item.Selected = false;
            }

            //Hide all panels
            PanelText.Visible = false;
            PanelInteger.Visible = false;
            PanelDateTime.Visible = false;
            PanelTime.Visible = false;
            PanelHexColour.Visible = false;
            PanelDecimal.Visible = false;
            PanelPrimaryKey.Visible = false;
            PanelForeignKey.Visible = false;
            PanelBoolean.Visible = false;

        }

        private void btnRefreshFields_Click(object sender, EventArgs e)
        {
            LoadFields();
        }

        

        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Hide all panels
                PanelText.Visible = false;
                PanelInteger.Visible = false;
                PanelDateTime.Visible = false;
                PanelTime.Visible = false;
                PanelHexColour.Visible = false;
                PanelDecimal.Visible = false;
                PanelPrimaryKey.Visible = false;
                PanelForeignKey.Visible = false;
                PanelBoolean.Visible = false;

                //Set to default all Data Type components
                txtTextMin.Value = 1;
                txtTextMax.Value = 8000;
                txtTextRegex.Text = "";
                txtForeignTableName.Text = "";

                txtIntMax.Value = 1000;
                txtIntMin.Value = 0;

                DatePickerMax.Value = new DateTime(9998, 12, 30, 23, 59, 59, 999);
                DatePickerMin.Value = new DateTime(1753, 1, 1, 0, 0, 0, 0);
                TimePickerMax.Value = new DateTime(9998, 12, 30, 23, 59, 59, 999);
                TimePickerMin.Value = new DateTime(1753, 1, 1, 0, 0, 0, 0);
                txtDateTimeMax.Text = DatePickerMax.Value.ToString("yyyy-MM-ddTHH:mm");
                txtDateTimeMin.Text = DatePickerMin.Value.ToString("yyyy-MM-ddTHH:mm");

                //txtTimeSpanMax.Text = FiyiStack.Library.MicrosoftSQLServer.Constant.TimeMAXValue.ToString();
                //txtTimeSpanMin.Text = FiyiStack.Library.MicrosoftSQLServer.Constant.TimeMINValue.ToString();

                txtHexColourMax.Text = "FFFFFF";
                txtHexColourMin.Text = "000000";

                txtDecimalMax.Value = 1000;
                txtDecimalMin.Value = 0;

                switch (Convert.ToInt32(cmbDataType.SelectedValue))
                {
                    case 0:
                        break;
                    case 3: //Integer
                        PanelInteger.Visible = true;
                        break;
                    case 4: //Boolean
                        PanelBoolean.Visible = true;
                        break;
                    case 5: //Text: Basic
                        PanelText.Visible = true;
                        break;
                    case 6: //Decimal
                        PanelDecimal.Visible = true;
                        break;
                    case 8: //Primary Key (Id)
                        PanelPrimaryKey.Visible = true;
                        break;
                    case 10: //DateTime
                        PanelDateTime.Visible = true;
                        break;
                    case 11: //Time
                        PanelTime.Visible = true;
                        break;
                    case 13: //Foreign Key (Id): Options
                        PanelForeignKey.Visible = true;
                        break;
                    case 14: //Text: HexColour
                        PanelHexColour.Visible = true;
                        break;
                    case 15: //Text: TextArea
                        PanelBoolean.Visible = true;
                        break;
                    case 16: //Text: TextEditor
                        PanelBoolean.Visible = true;
                        break;
                    case 17: //Text: Password
                        PanelText.Visible = true;
                        break;
                    case 18: //Text: PhoneNumber
                        PanelText.Visible = true;
                        break;
                    case 19: //Text: URL
                        PanelText.Visible = true;
                        break;
                    case 20: //Text: Email
                        PanelText.Visible = true;
                        break;
                    case 21: //Text: File
                        PanelText.Visible = true;
                        break;
                    case 22: //Text: Tag
                        PanelText.Visible = true;
                        break;
                    case 23: //Foreign Key (Id): DropDown
                        PanelForeignKey.Visible = true;
                        break;
                    default:
                        throw new Exception("The Data Type selector entered in error");
                }
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void ListViewField_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                int SelectedFieldId = 0;
                for (int i = 0; i < ListViewField.Items.Count; i++)
                {
                    if (ListViewField.Items[i].Selected)
                    {
                        if (ListViewField.Items[i].ImageIndex == 3)
                        { throw new Exception("It is not allowed to configure external fields. First, import them."); }

                        if (ListViewField.Items[i].Text == Program.WinFormConfigurationComponent.TableChosen.Name + "Id")
                        { throw new Exception("It is not allowed to configure the Primary Key (Id)"); }

                        SelectedFieldId = Convert.ToInt32(ListViewField.Items[i].Tag);

                        btnAddField.Image = Resources.btnEdit;
                    }
                }

                //Config the Field configuration panel
                Program.WinFormConfigurationComponent.FieldChosen = new Models.Core.Field(SelectedFieldId);
                txtFieldName.Text = Program.WinFormConfigurationComponent.FieldChosen.Name;
                if (Program.WinFormConfigurationComponent.FieldChosen.Nullable) { chbNullable.Checked = true; } else { chbNullable.Checked = false; }
                txtFieldHistoryUser.Text = Program.WinFormConfigurationComponent.FieldChosen.HistoryUser;
                cmbDataType.SelectedValue = Program.WinFormConfigurationComponent.FieldChosen.DataTypeId;

                //Configure the right Data Type panel according to the DataTypeId selected
                switch (Program.WinFormConfigurationComponent.FieldChosen.DataTypeId)
                {
                    case 3: //Integer
                        txtIntMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtIntMin.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MinValue);
                        break;
                    case 4: //Boolean

                        break;
                    case 5: //Text: Basic
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 6: //Decimal
                        txtDecimalMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtDecimalMin.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MinValue);
                        break;
                    case 8: //Primary Key (Id)

                        break;
                    case 10: //DateTime
                        txtDateTimeMax.Text = Program.WinFormConfigurationComponent.FieldChosen.MaxValue;
                        txtDateTimeMin.Text = Program.WinFormConfigurationComponent.FieldChosen.MinValue;
                        break;
                    case 11: //Time
                        txtTimeSpanMax.Text = Program.WinFormConfigurationComponent.FieldChosen.MaxValue;
                        txtTimeSpanMin.Text = Program.WinFormConfigurationComponent.FieldChosen.MinValue;
                        break;
                    case 13: //Foreign Key (Id): Options
                        txtForeignTableName.Text = Program.WinFormConfigurationComponent.FieldChosen.ForeignTableName;
                        break;
                    case 14: //Text: HexColour
                        txtHexColourMax.Text = Program.WinFormConfigurationComponent.FieldChosen.MaxValue;
                        txtHexColourMin.Text = Program.WinFormConfigurationComponent.FieldChosen.MinValue;
                        break;
                    case 15: //Text: TextArea
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 16: //Text: TextEditor
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 17: //Text: Password
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 18: //Text: PhoneNumber
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 19: //Text: URL
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 20: //Text: Email
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 21: //Text: File
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 22: //Text: Tag
                        txtTextMin.Value = 1;
                        txtTextMax.Value = Program.WinFormConfigurationComponent.FieldChosen.MaxValue == "" ? 1 : Convert.ToDecimal(Program.WinFormConfigurationComponent.FieldChosen.MaxValue);
                        txtTextRegex.Text = Program.WinFormConfigurationComponent.FieldChosen.Regex;
                        break;
                    case 23: //Foreign Key (Id): DropDown
                        txtForeignTableName.Text = Program.WinFormConfigurationComponent.FieldChosen.ForeignTableName;
                        break;
                    default:
                        throw new Exception($"The field have a Data Type not recognized");
                }

                lblSubtitle.Text = $@"Database: {Program.WinFormConfigurationComponent.DataBaseChosen.Name} ({Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId}) | Table: {Program.WinFormConfigurationComponent.TableChosen.Name} ({Program.WinFormConfigurationComponent.TableChosen.TableId}) | Field: {Program.WinFormConfigurationComponent.FieldChosen.Name} ({Program.WinFormConfigurationComponent.FieldChosen.FieldId})";

                lblMessageDockedBottom.Text = Program.WinFormConfigurationComponent.FieldChosen.Name + " loaded";
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            try
            {
                //Validations
                if (txtFieldName.Text.Trim() == "") { throw new Exception("Enter a valid field name"); }
                if (!Validator.IsRegexOk(txtFieldName.Text.Trim(), @"^[A-Za-z0-9]+$")) { throw new Exception("A field name only accept letters and numbers"); }
                if (Program.WinFormConfigurationComponent.DataBaseChosen.DataBaseId == 0) { throw new Exception("First, select a database"); }
                if (Program.WinFormConfigurationComponent.TableChosen.TableId == 0) { throw new Exception("First, select a table"); }
                if (cmbDataType.SelectedIndex == 0) { throw new Exception("You must choose a Data Type"); }

                Cursor = Cursors.WaitCursor;

                Models.Core.Field Field = new Models.Core.Field();

                //Update or Add?
                bool IsUpdate = false;
                for (int i = 0; i < ListViewField.Items.Count; i++)
                {
                    if (ListViewField.Items[i].Selected)
                    {
                        if (ListViewField.Items[i].ImageIndex != 3) //It is not allowed to configure external fields. First, import them.
                        {
                            IsUpdate = true;
                            Models.Core.Field savedField = new Models.Core.Field(Convert.ToInt32(ListViewField.Items[i].Tag));
                            if (savedField.Name != txtFieldName.Text) //Search the field name to verify inexistance
                            {
                                savedField = savedField.GetOneByTableIdByNameToModel(Program.WinFormConfigurationComponent.TableChosen.TableId, txtFieldName.Text);
                                if (savedField.FieldId != 0) { throw new Exception($"The field {txtFieldName.Text} already exist in the table {Program.WinFormConfigurationComponent.TableChosen.Name}"); }
                            }
                            Field = new Models.Core.Field(Convert.ToInt32(ListViewField.Items[i].Tag));
                        }
                        else { throw new Exception("It is not allowed to configure external fields. First, import them."); }
                    }
                }

                //Collect data
                Field.Name = txtFieldName.Text;
                Field.TableId = Program.WinFormConfigurationComponent.TableChosen.TableId;
                Field.HistoryUser = txtFieldHistoryUser.Text;
                Field.Nullable = chbNullable.Checked;
                Field.DataTypeId = Convert.ToInt32(cmbDataType.SelectedValue);
                Field.Active = true;
                Field.DateTimeLastModification = DateTime.Now;
                Field.UserIdLastModification = Program.WinFormConfigurationComponent.UserLogged.UserId;
                switch (Convert.ToInt32(cmbDataType.SelectedValue))
                {
                    case 0:
                        throw new Exception("You must choose a Data Type");
                    case 3: //Integer
                        if (txtIntMin.Value > txtIntMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtIntMin.Value > int.MaxValue || txtIntMin.Value < int.MinValue) { throw new Exception("The minimum entered is not supported"); }
                        if (txtIntMax.Value > int.MaxValue || txtIntMax.Value < int.MinValue) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtIntMin.Value.ToString();
                        Field.MaxValue = txtIntMax.Value.ToString();
                        break;
                    case 4: //Boolean
                        break;
                    case 5: //Text: Basic
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 6: //Decimal
                        if (txtDecimalMin.Value > txtDecimalMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtDecimalMin.Value > decimal.MaxValue || txtDecimalMin.Value < decimal.MinValue) { throw new Exception("The minimum entered is not supported"); }
                        if (txtDecimalMax.Value > decimal.MaxValue || txtDecimalMax.Value < decimal.MinValue) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtDecimalMin.Value.ToString();
                        Field.MaxValue = txtDecimalMax.Value.ToString();
                        break;
                    case 8: //Primary Key (Id)
                        break;
                    case 10: //DateTime
                        Field.MinValue = txtDateTimeMin.Text;
                        Field.MaxValue = txtDateTimeMax.Text;
                        break;
                    case 11: //Time
                        if (!Validator.IsTimeSpan(txtTimeSpanMax.Text)) { throw new Exception("The maximum has a format not supported"); }
                        if (!Validator.IsTimeSpan(txtTimeSpanMin.Text)) { throw new Exception("The minimum has a format not supported"); }
                        if (Convert.ToDateTime("01/01/1753 " + txtTimeSpanMin.Text) > Convert.ToDateTime("01/01/1753 " + txtTimeSpanMax.Text))
                        { throw new Exception("The minimum has to be at least equal to maximum"); }

                        Field.MinValue = txtTimeSpanMin.Text;
                        Field.MaxValue = txtTimeSpanMax.Text;
                        break;
                    case 13: //Foreign Key (Id): Options
                        Field.ForeignTableName = txtForeignTableName.Text;
                        break;
                    case 14: //Text: HexColour
                        if (!Validator.IsHexColour(txtHexColourMax.Text)) { throw new Exception("The maximum has a format not supported"); }
                        if (!Validator.IsHexColour(txtHexColourMin.Text)) { throw new Exception("The minimum has a format not supported"); }
                        char charValue2;
                        charValue2 = Validator.CompareStrings(txtHexColourMin.Text, txtHexColourMax.Text, true);
                        if (charValue2 == '\0') { throw new Exception("The inputs have different lengths"); }
                        if (charValue2 == 'A') { throw new Exception("The minimum has to be at least equal to maximum"); }
                        charValue2 = Validator.CompareStrings(txtHexColourMin.Text, "000000", true);
                        if (charValue2 == '\0') { throw new Exception("The minimum has a length not supported"); }
                        if (charValue2 == 'B') { throw new Exception("The minimum entered is not supported"); }
                        charValue2 = Validator.CompareStrings(txtHexColourMax.Text, "FFFFFF", true);
                        if (charValue2 == '\0') { throw new Exception("The maximum has a length not supported"); }
                        if (charValue2 == 'A') { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtHexColourMin.Text;
                        Field.MaxValue = txtHexColourMax.Text;
                        break;
                    case 15: //Text: TextArea
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 16: //Text: TextEditor
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 17: //Text: Password
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 18: //Text: PhoneNumber
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 19: //Text: URL
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 20: //Text: Email
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 21: //Text: File
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 22: //Text: Tag
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 23: //Foreign Key (Id): Options
                        Field.ForeignTableName = txtForeignTableName.Text;
                        break;
                    default:
                        throw new Exception("The Data Type identificator is not correct");
                }

                if (!IsUpdate) //Add field
                {
                    Field.DateTimeCreation = DateTime.Now;
                    Field.UserIdCreation = Program.WinFormConfigurationComponent.UserLogged.UserId;

                    Field.Add();
                    lblMessageDockedBottom.Text = $"Field {txtFieldName.Text} added correctly";
                }
                else //Update field
                {
                    Field.UpdateByFieldId();
                    lblMessageDockedBottom.Text = $"Field {txtFieldName.Text} updated correctly";
                }
                LoadFields();
            }
            catch (Exception ex) { lblMessageDockedBottom.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void btnHidePanelSummary_Click(object sender, EventArgs e)
        {
            PanelSummary.Visible = false;

            HideAllGeneratorPanelsExcept(PanelDatabase);
        }

        #region Secondary Configuration
        private void btnAddDatabase_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnGenerate_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnAddField_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnShowConfigurationForm_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnNewOrEdit_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void ListViewDatabase_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtSearchYourProjectByName_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewYourProjects_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewField_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtUserName_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtUserPassword_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
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

        private void btnHidePanelSummary_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void picProfilePicture_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 50, 50);
        }

        private void btnAddTable_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void ListViewTable_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void cmbDataType_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void picRememberMe_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 20, 20);
        }

        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void picLogo_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.UI.SetBorderRadiusToControl(ref sender, 20, 20);
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
