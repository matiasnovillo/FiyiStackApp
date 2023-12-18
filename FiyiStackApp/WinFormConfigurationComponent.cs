using FiyiStackApp.Models.Core;
using System.ComponentModel;
using System.Text;

namespace FiyiStackApp
{
    /// <summary>
    /// Note: Avoid initialization of junction tables
    /// </summary>
    public partial class WinFormConfigurationComponent : Component
    {
        #region Properties
        //For all forms
        public User UserLogged = new User();
        public Configuration Configuration = new Configuration();
        public List<Project> lstYourFiyiStackProjects = new List<Project>();
        public List<Project> lstNotYourFiyiStackProjects = new List<Project>();
        public Color BlackColorPlus1 = (Color)new ColorConverter().ConvertFromString("#20262D");

        //For LoginForm
        public string FantasyNameOrEmailFromLocalDB
        {
            get { return Properties.Settings.Default.FantasyNameOrEmail; }
            set { Properties.Settings.Default.FantasyNameOrEmail = value; Properties.Settings.Default.Save(); }
        }
        public Image ProfilePicture
        {
            get
            {
                try
                {
                    return Image.FromFile("ProfilePicture.png");
                }
                catch (Exception) { return Properties.Resources.User; } //Can throw Exception due to trying to write the file while is being used in another application
            }
            set
            {
                //Save image outside the application. The only way available
                try
                {
                    Image _img;
                    _img = value;
                    _img.Save("ProfilePicture.png");
                }
                catch (Exception) { } //Can throw Exception due to trying to write the file while is being used in another application
            }
        }
        public bool RememberMe
        {
            get
            { return Properties.Settings.Default.RememberMe; }
            set
            {
                Properties.Settings.Default.RememberMe = value;
                if (value == false) { Properties.Settings.Default.FantasyNameOrEmail = ""; }
                Properties.Settings.Default.Save();
            }
        }

        //For GeneratorForm
        public Project ProjectChosen = new Project();
        public UserProject UserProjectChosen = new UserProject();

        public List<DataBase> lstDataBaseInFiyiStack = new List<DataBase>();
        public DataBase DataBaseChosen = new DataBase();

        public List<Table> lstTableInFiyiStack = new List<Table>();
        public Table TableChosen = new Table();

        public List<Field> lstFieldInFiyiStack = new List<Field>();
        public Field FieldChosen = new Field();

        public DataType DataType = new DataType();

        /// <summary>
        /// Auditing fields to add to a new Table, if auditory fields are requested
        /// </summary>
        public List<Field> lstAuditingFields = new List<Field>();

        public List<Table> lstTableToGenerate = new List<Table>();
        public List<Field> lstFieldToGenerate = new List<Field>();
        public List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate = new List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure>();
        #endregion

        #region Constructors
        public WinFormConfigurationComponent()
        {
            InitializeComponent();
        }

        public WinFormConfigurationComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region Functions
        public Configuration LoadDefaultConfiguration()
        {
            Configuration Configuration = new Configuration()
            {
                ConfigurationId = 0,
                ProjectId = 0,
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 0,
                UserLastModificationId = 0,

                AddAuditingFieldsToNewTable = true,
                DeleteTable = true,
                DeleteField = true,
                DeleteStoredProcedure = true,
                DeleteFiles = true,

                TemplateId = 1,

                WantCSharpModelsWithSPs = true,
                WantCSharpDTOs = true,
                WantCSharpFilters = true,
                WantCSharpInterfaces = true,
                WantCSharpServices = true,
                WantCSharpRazorPages = true,
                WantCSharpWebAPIs = true,
                WantTypeScriptModels = true,
                WantjQueryDOMManipulator = true,
                WantTypeScriptDTOs = true,
                WantBackendAPI = true,
                WantBackendAPINodeJsExpressMongoDB = true,
                WantNET8MSSQLServerAPI = true
            };
            return Configuration;
        }

        public void LoadConfiguration()
        {
            try
            {
                Configuration Configuration = new Configuration().GetOneByProjectIdToModel(Program.WinFormConfigurationComponent.ProjectChosen.ProjectId);

                Program.WinFormConfigurationComponent.Configuration.ProjectId = Configuration.ProjectId;

                Program.WinFormConfigurationComponent.Configuration.AddAuditingFieldsToNewTable = Configuration.AddAuditingFieldsToNewTable;
                Program.WinFormConfigurationComponent.Configuration.DeleteTable = Configuration.DeleteTable;
                Program.WinFormConfigurationComponent.Configuration.DeleteField = Configuration.DeleteField;
                Program.WinFormConfigurationComponent.Configuration.DeleteStoredProcedure = Configuration.DeleteStoredProcedure;
                Program.WinFormConfigurationComponent.Configuration.DeleteFiles = Configuration.DeleteFiles;
                Program.WinFormConfigurationComponent.Configuration.TemplateId = Configuration.TemplateId;

                //C#
                Program.WinFormConfigurationComponent.Configuration.WantCSharpModelsWithSPs = Configuration.WantCSharpModelsWithSPs;
                Program.WinFormConfigurationComponent.Configuration.WantCSharpDTOs = Configuration.WantCSharpDTOs;
                Program.WinFormConfigurationComponent.Configuration.WantCSharpFilters = Configuration.WantCSharpFilters;
                Program.WinFormConfigurationComponent.Configuration.WantCSharpInterfaces = Configuration.WantCSharpInterfaces;
                Program.WinFormConfigurationComponent.Configuration.WantCSharpServices = Configuration.WantCSharpServices;
                Program.WinFormConfigurationComponent.Configuration.WantCSharpRazorPages = Configuration.WantCSharpRazorPages;
                Program.WinFormConfigurationComponent.Configuration.WantCSharpWebAPIs = Configuration.WantCSharpWebAPIs;
                Program.WinFormConfigurationComponent.Configuration.WantBackendAPI = Configuration.WantBackendAPI;
                Program.WinFormConfigurationComponent.Configuration.WantBackendAPINodeJsExpressMongoDB = Configuration.WantBackendAPINodeJsExpressMongoDB;
                Program.WinFormConfigurationComponent.Configuration.WantNET8MSSQLServerAPI = Configuration.WantNET8MSSQLServerAPI;
                //Front-end
                Program.WinFormConfigurationComponent.Configuration.WantTypeScriptModels = Configuration.WantTypeScriptModels;
                Program.WinFormConfigurationComponent.Configuration.WantjQueryDOMManipulator = Configuration.WantjQueryDOMManipulator;
                Program.WinFormConfigurationComponent.Configuration.WantTypeScriptDTOs = Configuration.WantTypeScriptDTOs;
            }
            catch (Exception ex) { throw ex; }
        }

        public static void CreateFile(string FilePath, string Content, bool DeleteFile)
        {
            try
            {
                if (File.Exists(FilePath)) //Edit the file
                {
                    if (DeleteFile)
                    {
                        //Take all the information of the file and convert it to a string
                        string ContentOfFile = "";
                        using (FileStream filestream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                        {
                            //Convert the source file into a byte array
                            byte[] arrayByte = new byte[filestream.Length];
                            int NumberOfBytesToRead = (int)filestream.Length;
                            int NumberOfBytesRead = 0;
                            while (NumberOfBytesToRead > 0)
                            {
                                int TotalBytesRead = filestream.Read(arrayByte, NumberOfBytesRead, NumberOfBytesToRead); // Read may return anything from 0 to NumberOfBytesToRead.
                                if (TotalBytesRead == 0) { break; } // Break when the end of the file is reached.

                                NumberOfBytesRead += TotalBytesRead;
                                NumberOfBytesToRead -= TotalBytesRead;
                            }
                            NumberOfBytesToRead = arrayByte.Length;

                            ContentOfFile = Encoding.UTF8.GetString(arrayByte);
                        }

                        using (FileStream filestream = new FileStream(FilePath, FileMode.Open, FileAccess.Write))
                        {
                            byte[] arrayByte = new UTF8Encoding(true).GetBytes(Content);
                            filestream.Write(arrayByte, 0, arrayByte.Length);
                        } 
                    }
                }
                else    //Create the file
                {
                    using (FileStream filestream = File.Create(FilePath))
                    {
                        byte[] arrayByte = new UTF8Encoding(true).GetBytes(Content);
                        filestream.Write(arrayByte, 0, arrayByte.Length);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void SetClipBoard(string TextToClip)
        {
            StringBuilder sbTextToClip = new StringBuilder(TextToClip);
            Clipboard.SetText(sbTextToClip.ToString());
        }
        #endregion
    }
}
