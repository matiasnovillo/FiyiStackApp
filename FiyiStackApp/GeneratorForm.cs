using FiyiStack.Library.NET;
using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Generation.Modules;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Models.Tools;
using FiyiStackApp.Properties;
using FiyiStackApp.Generation;

namespace FiyiStackApp
{
    public partial class GeneratorForm : Form
    {
        public GeneratorForm()
        {
            try
            {
                InitializeComponent();

                ToolStatusLabel.Text = "Loading";
                Cursor = Cursors.WaitCursor;

                #region Manage panel configuration
                //Set positions for panels and set the form size. This is used to move the panels to any place in the design layout
                PanelDatabase.Location = new Point(325, 100);
                PanelTable.Location = new Point(325, 100);
                PanelField.Location = new Point(325, 100);
                PanelSummary.Location = new Point(325, 100);
                PanelMain.Location = new Point(43, 100);
                this.Size = new Size(1090, 550);

                HideAllPanelsExcept(Program.WinFormConfigurationComponent.UserLogged.UserId, new Panel[] { PanelMain, PanelDatabase });
                #endregion

                #region Manage radius of WinForms components
                //Set border radius to various components
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

                Program.WinFormConfigurationComponent.UserProjectChosen = new UserProject(Program.WinFormConfigurationComponent.UserLogged.UserId, Program.WinFormConfigurationComponent.ProjectChosen.ProjectId);

                #region Manage pictures, messages and labels
                picStep1Databases.Visible = true;
                picStep2Tables.Visible = false;
                picStep3Properties.Visible = false;
                #endregion

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
                Models.Core.DataBase Database = new Models.Core.DataBase();
                Program.WinFormConfigurationComponent.DataBaseChosen = Database;

                //Load empty PropertyGridDatabase
                Models.Core.DataBase DataBase = new Models.Core.DataBase();

                DataBase.ConnectionStringForMSSQLServer = "data source =.; initial catalog = [PUT_A_DATABASE_NAME]; Integrated Security = SSPI; MultipleActiveResultSets=True;Pooling=false;Persist Security Info=True;App=EntityFramework;TrustServerCertificate=True";

                Program.WinFormConfigurationComponent.DataBaseChosen = DataBase;
                PropertyGridDatabase.SelectedObject = Program.WinFormConfigurationComponent.DataBaseChosen;

                btnAddDatabase.Image = Resources.btnNew;
                lblActionDatabase.Text = "Add";

                //Load DataBases
                LoadDataBases();

                //Load ComboBox for DataType
                Program.WinFormConfigurationComponent.DataType = new DataType();
                cmbDataType.ValueMember = "Value"; 
                cmbDataType.DisplayMember = "Text"; 
                cmbDataType.DataSource = new DataType().GetList("");

                //Basic
                ToolStatusLabel.Text = "Ready. Select or create a database";
                Cursor = Cursors.Default;
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //Reset timer
                Program.WinFormConfigurationComponent.timer.Stop();
                Program.WinFormConfigurationComponent.timer.Start();

                //Validation and preparing
                ToolStatusLabel.Text = "Validating and preparing";
                HideAllPanelsExcept(Program.WinFormConfigurationComponent.UserLogged.UserId, new Panel[] { PanelSummary });
                Program.WinFormConfigurationComponent.lstTableToGenerate = new List<Models.Core.Table>();
                Program.WinFormConfigurationComponent.lstFieldToGenerate = new List<Models.Core.Field>();
                Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate = new List<StoredProcedure>();
                //List of actions for stored procedures
                List<string> lstStoredProcedureAction = new List<string>()
                {
                "Insert", "UpdateBy", "DeleteBy", "Select1By", "SelectAll", "SelectAllPaged", "Count", "DeleteAll"
                };
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
                            Models.Core.Table TableChecked = new Models.Core.Table(Convert.ToInt32(ListViewTable.Items[i].Tag));
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
                                foreach (Models.Core.Field field in new Models.Core.Field().GetAllByTableIdToModel(TableChecked.TableId))
                                {
                                    Program.WinFormConfigurationComponent.lstFieldToGenerate.Add(field);
                                }

                                int actionId = 0;
                                foreach (string action in lstStoredProcedureAction)
                                {
                                    StoredProcedure storedprocedure = new StoredProcedure();
                                    storedprocedure.TableArea = TableChecked.Area;
                                    storedprocedure.TableName = TableChecked.Name;
                                    storedprocedure.SchemeName = TableChecked.Scheme;
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

                Cursor = Cursors.WaitCursor;
                if (Program.WinFormConfigurationComponent.lstTableToGenerate.Count != 0)
                {

                    //Before generation done
                    TextBoxLogger.Clear();
                    ToolStatusLabel.Text = "Starting...";
                    PanelSummary.Visible = true;

                    //Start generation
                    if (Program.WinFormConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer.Trim() != "")
                    {
                        TextBoxLogger.Text += GeneratorJsTsNETCoreSQLServer.Start(Program.WinFormConfigurationComponent.Configuration,
                                        new fieldChainer(),
                                        new fieldChainerNodeJsExpressMongoDB(),
                                        new modelChainer(),
                                        Program.WinFormConfigurationComponent.ProjectChosen,
                                        Program.WinFormConfigurationComponent.DataBaseChosen,
                                        Program.WinFormConfigurationComponent.lstTableInFiyiStack,
                                        Program.WinFormConfigurationComponent.lstTableToGenerate,
                                        Program.WinFormConfigurationComponent.lstFieldToGenerate,
                                        Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate); 
                    }
                    else if(Program.WinFormConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture.Trim() != "")
                    {
                        TextBoxLogger.Text += GeneratorNET6CleanArchitecture.Start(Program.WinFormConfigurationComponent.Configuration,
                                        new fieldChainer(),
                                        new fieldChainerNodeJsExpressMongoDB(),
                                        new modelChainer(),
                                        Program.WinFormConfigurationComponent.ProjectChosen,
                                        Program.WinFormConfigurationComponent.DataBaseChosen,
                                        Program.WinFormConfigurationComponent.lstTableInFiyiStack,
                                        Program.WinFormConfigurationComponent.lstTableToGenerate,
                                        Program.WinFormConfigurationComponent.lstFieldToGenerate,
                                        Program.WinFormConfigurationComponent.lstStoredProcedureToGenerate);
                    }
                    else
                    {
                        TextBoxLogger.Text += GeneratorNodeJsExpressMongoDB.Start(Program.WinFormConfigurationComponent.Configuration,
                                        new fieldChainer(),
                                        new fieldChainerNodeJsExpressMongoDB(),
                                        new modelChainer(),
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
                    ToolStatusLabel.Text = "Ready. Generation done";
                    TextBoxLogger.Text += "Ready. Generation done";
                    Cursor = Cursors.Default;
                }
                else { ToolStatusLabel.Text = "Nothing to generate"; }
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        #region DataBase configuration
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
                    ToolStatusLabel.Text = $"Database {DatabaseName} added correctly";
                }
                else //Edit database
                {
                    Program.WinFormConfigurationComponent.DataBaseChosen.UpdateByDataBaseId();
                    ToolStatusLabel.Text = $"Database {DatabaseName} updated correctly";
                }
                Program.WinFormConfigurationComponent.DataBaseChosen = new Models.Core.DataBase(Program.WinFormConfigurationComponent.ProjectChosen.ProjectId, DatabaseName);
                
                LoadDataBases();
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
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
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void LoadDataBases()
        {
            try
            {
                ToolStatusLabel.Text = "Loading";
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

                ToolStatusLabel.Text = "Ready";
                btnAddDatabase.Image = Resources.btnNew;
                Cursor = Cursors.Default;
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }
        #endregion

        #region Table configuration
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
                            Models.Core.Table Table = new Models.Core.Table(Convert.ToInt32(ListViewTable.Items[i].Tag));
                            //First, delete the Table inside FiyiStack
                            Table.DeleteByTableId(Convert.ToInt32(ListViewTable.Items[i].Tag));

                            //Second, delete all the Fields inside FiyiStack associated to that table
                            Models.Core.Field Field = new Models.Core.Field();
                            Field.DeleteByTableId(Convert.ToInt32(ListViewTable.Items[i].Tag));

                            LoadTables();
                            ListViewField.Clear();
                        }
                        else { ToolStatusLabel.Text = "It is not allowed to delete external tables."; }
                    }
                }
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void LoadTables()
        {
            try
            {
                ToolStatusLabel.Text = "Loading";
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

                ToolStatusLabel.Text = "Tables loaded. Ready";
                btnAddTable.Image = Resources.btnNew;
                Cursor = Cursors.Default;
            }
            catch (Exception ex) 
            { ToolStatusLabel.Text = ex.Message; ListViewTable.Items.Clear(); ListViewField.Items.Clear(); Cursor = Cursors.Default; }
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
                ToolStatusLabel.Text = $"Ready. [{Program.WinFormConfigurationComponent.TableChosen.Scheme}].[{Program.WinFormConfigurationComponent.TableChosen.Area}.{Program.WinFormConfigurationComponent.TableChosen.Name}] added/updated correctly";
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }
        #endregion

        #region Field configuration
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
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
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
                    ToolStatusLabel.Text = $"Field {txtFieldName.Text} added correctly";
                }
                else //Update field
                {
                    Field.UpdateByFieldId();
                    ToolStatusLabel.Text = $"Field {txtFieldName.Text} updated correctly";
                }
                LoadFields();
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void LoadFields()
        {
            try
            {
                ToolStatusLabel.Text = "Loading";
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

                ToolStatusLabel.Text = "Fields loaded. Ready";
                btnAddField.Image = Resources.btnNew;
                txtFieldName.Text = "";
                txtFieldHistoryUser.Text = "";
                chbNullable.Checked = false;
                cmbDataType.SelectedIndex = 0;
                Cursor = Cursors.Default;
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; ListViewField.Items.Clear(); Cursor = Cursors.Default; }
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
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; ListViewField.Items.Clear(); return null; }
        }
        #endregion

        #region Action configuration
        private void btnSaveActionConfig_Click(object sender, EventArgs e)
        {
            //TODO Trabajar esto cuando le haya encontrado la vuelta
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            //TODO Trabajar esto cuando le haya encontrado la vuelta
        }
        #endregion

        #region Secondary configuration
        private void btnRefreshFields_Click(object sender, EventArgs e)
        {
            LoadFields();
        }

        private void btnRefreshDataBases_Click(object sender, EventArgs e)
        {
            LoadDataBases();
        }

        private void btnRefreshTables_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void ListViewDataBase_ItemActivate(object sender, EventArgs e)
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
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
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
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
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

                ToolStatusLabel.Text = Program.WinFormConfigurationComponent.FieldChosen.Name + " loaded";
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
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

                //Set picDataType to null
                picDataType.Image = null;

                switch (Convert.ToInt32(cmbDataType.SelectedValue))
                {
                    case 0:
                        picDataType.Image = null;
                        break;
                    case 3: //Integer
                        PanelInteger.Visible = true;
                        picDataType.Image = Resources.DataTypeInteger1;
                        break;
                    case 4: //Boolean
                        PanelBoolean.Visible = true;
                        picDataType.Image = Resources.DataTypeBoolean1;
                        break;
                    case 5: //Text: Basic
                        PanelText.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 6: //Decimal
                        PanelDecimal.Visible = true;
                        picDataType.Image = Resources.DataTypeDecimal1;
                        break;
                    case 8: //Primary Key (Id)
                        PanelPrimaryKey.Visible = true;
                        picDataType.Image = Resources.DataTypePK1;
                        break;
                    case 10: //DateTime
                        PanelDateTime.Visible = true;
                        picDataType.Image = Resources.DataTypeDateTime1;
                        break;
                    case 11: //Time
                        PanelTime.Visible = true;
                        picDataType.Image = Resources.DataTypeTime1;
                        break;
                    case 13: //Foreign Key (Id): Options
                        PanelForeignKey.Visible = true;
                        picDataType.Image = Resources.DataTypeFK1;
                        break;
                    case 14: //Text: HexColour
                        PanelHexColour.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 15: //Text: TextArea
                        PanelBoolean.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 16: //Text: TextEditor
                        PanelBoolean.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 17: //Text: Password
                        PanelText.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 18: //Text: PhoneNumber
                        PanelText.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 19: //Text: URL
                        PanelText.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 20: //Text: Email
                        PanelText.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 21: //Text: File
                        PanelText.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 22: //Text: Tag
                        PanelText.Visible = true;
                        picDataType.Image = Resources.DataTypeText1;
                        break;
                    case 23: //Foreign Key (Id): DropDown
                        PanelForeignKey.Visible = true;
                        picDataType.Image = Resources.DataTypeFK1;
                        break;
                    default:
                        picDataType.Image = null;
                        throw new Exception("The Data Type selector entered in error");
                }
            }
            catch (Exception ex) { ToolStatusLabel.Text = ex.Message; Cursor = Cursors.Default; }
        }

        private void DatePickerMin_ValueChanged(object sender, EventArgs e)
        {
            txtDateTimeMin.Text = DatePickerMin.Value.ToString("yyyy-MM-dd");
            txtDateTimeMin.Text += "T" + TimePickerMin.Value.ToString().Substring(11,4);
        }

        private void TimePickerMin_ValueChanged(object sender, EventArgs e)
        {
            txtDateTimeMin.Text = DatePickerMin.Value.ToString("yyyy-MM-dd");
            txtDateTimeMin.Text += "T" + TimePickerMin.Value.ToString().Substring(11,4);
        }

        private void DatePickerMax_ValueChanged(object sender, EventArgs e)
        {
            txtDateTimeMax.Text = DatePickerMax.Value.ToString("yyyy-MM-dd");
            txtDateTimeMax.Text += "T" + TimePickerMax.Value.ToString().Substring(11);
        }

        private void TimePickerMax_ValueChanged(object sender, EventArgs e)
        {
            txtDateTimeMax.Text = DatePickerMax.Value.ToString("yyyy-MM-dd");
            txtDateTimeMax.Text += "T" + TimePickerMax.Value.ToString().Substring(11);
        }
        #endregion

        #region Third configuration. Painting mostly
        private void HideAllPanelsExcept(int UserId, Panel[] PanelsToAvoid = null)
        {
            PanelSummary.Visible = false;
            PanelDatabase.Visible = false;
            PanelTable.Visible = false;
            PanelField.Visible = false;
            PanelText.Visible = false;
            PanelInteger.Visible = false;
            PanelDateTime.Visible = false;
            PanelTime.Visible = false;
            PanelHexColour.Visible = false;
            PanelDecimal.Visible = false;
            PanelPrimaryKey.Visible = false;
            PanelForeignKey.Visible = false;
            PanelBoolean.Visible = false;

            if (PanelsToAvoid != null)
            {
                foreach (Panel PanelToAvoid in PanelsToAvoid)
                {
                    PanelToAvoid.Visible = true;
                }
            }
        }

        private void btnHidePanelSummary_Click(object sender, EventArgs e)
        {
            PanelSummary.Visible = false;
        }

        private void ListViewDataBase_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewTable_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnGenerate_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnHidePanelSummary_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnSaveDataBaseConfig_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnSaveTableConfig_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnSaveFieldConfig_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void ListViewField_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtFieldHistoryUser_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtFieldName_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void cmbDataType_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 1, 10);
        }

        private void txtDecimalMax_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 1);
        }

        private void txtDecimalMin_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 1);
        }

        private void txtHexColourMax_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtHexColourMin_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtTimeSpanMax_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtTimeSpanMin_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtIntMax_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 1);
        }

        private void txtIntMin_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 1);
        }

        private void txtStringN_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 1);
        }

        private void txtStringRegex_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtDateTimeMax_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtDateTimeMin_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void txtForeignTableName_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void TextBoxLogger_BackColorChanged(object sender, EventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void picDataType_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 15, 15);
        }

        private void btnShowConfigurationForm_Paint(object sender, PaintEventArgs e)
        {
            FiyiStackApp.Library.UI.UI.SetBorderRadiusToControl(ref sender, 10, 50);
        }

        private void btnShowConfigurationForm_Click(object sender, EventArgs e)
        {
            ConfigurationForm ConfigurationForm = new ConfigurationForm();
            ConfigurationForm.ShowDialog();
        }

        private void labelDataBase_Click(object sender, EventArgs e)
        {
            HideAllPanelsExcept(Program.WinFormConfigurationComponent.UserLogged.UserId, new Panel[]{ PanelDatabase });
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = false;
            picStep3Properties.Visible = false;
        }

        private void labelTables_Click(object sender, EventArgs e)
        {
            HideAllPanelsExcept(Program.WinFormConfigurationComponent.UserLogged.UserId, new Panel[] { PanelTable });
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = true;
            picStep3Properties.Visible = false;
        }

        private void labelFields_Click(object sender, EventArgs e)
        {
            HideAllPanelsExcept(Program.WinFormConfigurationComponent.UserLogged.UserId, new Panel[] { PanelField });
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = true;
            picStep3Properties.Visible = true;
        }

        private void GeneratorForm_MouseMove(object sender, MouseEventArgs e)
        {
            //Reset timer
            Program.WinFormConfigurationComponent.timer.Stop();
            Program.WinFormConfigurationComponent.timer.Start();
        }
        #endregion

        #region Configuration MenuStrip
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WinFormConfigurationComponent.UserLogged = (User)Converter.SetObjectPropertiesToNull(Program.WinFormConfigurationComponent.UserLogged);
            Program.WinFormConfigurationComponent.ProjectChosen = (Project)Converter.SetObjectPropertiesToNull(Program.WinFormConfigurationComponent.ProjectChosen);
            Program.WinFormConfigurationComponent = new WinFormConfigurationComponent();
            this.Dispose();
            LoginForm LoginForm = new LoginForm();
            LoginForm.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void goToProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            ProjectForm ProjectForm = new ProjectForm();
            ProjectForm.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStatusLabel.Text = "Function under construction";
        }

        private void searchUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStatusLabel.Text = "Function under construction";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStatusLabel.Text = "Function under construction";
        }
        #endregion

        private void StatusStrip_Click(object sender, EventArgs e)
        {
            Program.WinFormConfigurationComponent.SetClipBoard(ToolStatusLabel.Text + "\n");
        }

        private void btnSelectAllTable_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lviTable in ListViewTable.Items)
            {
                lviTable.Checked = true;
            }
        }

        private void btnSelectAllField_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lviField in ListViewField.Items)
            {
                lviField.Checked = true;
            }
        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {
            Models.Core.Table Table = new Models.Core.Table();
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

        private void picAddDataBase_Click(object sender, EventArgs e)
        {
            Models.Core.DataBase DataBase = new Models.Core.DataBase();

            DataBase.ConnectionStringForMSSQLServer = "data source =.; initial catalog = [PUT_A_DATABASE_NAME]; Integrated Security = SSPI; MultipleActiveResultSets=True;Pooling=false;Persist Security Info=True;App=EntityFramework;TrustServerCertificate=True";

            Program.WinFormConfigurationComponent.DataBaseChosen = DataBase;
            PropertyGridDatabase.SelectedObject = Program.WinFormConfigurationComponent.DataBaseChosen;

            btnAddDatabase.Image = Resources.btnNew;
            lblActionDatabase.Text = "Add";
        }

        private void picAddFieldButton_Click(object sender, EventArgs e)
        {
            txtFieldName.Text = "";
            chbNullable.Checked = false;
            txtFieldHistoryUser.Text = "";
            cmbDataType.SelectedIndex = 0;
            picDataType.Image = null;
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

        private void btnCopyDBLocalhost_Click(object sender, EventArgs e)
        {
            Models.Core.DataBase DataBase = new Models.Core.DataBase();
            DataBase.ConnectionStringForMSSQLServer = "data source =.;initial catalog=[PUT_A_DATABASE_NAME];Integrated Security = SSPI;MultipleActiveResultSets=True;Pooling=false;persist security info=True;App=EntityFramework";
            DataBase.DateTimeLastModification = DateTime.Now;
            DataBase.DateTimeCreation = DateTime.Now;
            
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
    }
}
