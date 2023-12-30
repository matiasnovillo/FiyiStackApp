using FiyiStackApp.Models.Core;
using System.ComponentModel;

namespace FiyiStackApp.Generation
{
    public partial class GeneratorConfigurationComponent : Component
    {
        public Configuration Configuration { get; set; }
        public Models.Tools.fieldChainerNET8MSSQLServerAPI fieldChainerNET8MSSQLServerAPI { get; set; }
        public Models.Tools.modelChainerNET8MSSQLServerAPI modelChainerNET8MSSQLServerAPI { get; set; }
        public Models.Tools.fieldChainerNodeJsExpressMongoDB fieldChainerNodeJsExpressMongoDB { get; set; }
        public Models.Tools.fieldChainerJsTsNETCoreSQLServer fieldChainerJsTsNETCoreSQLServer { get; set; }
        public Models.Tools.modelChainerJsTsNETCoreSQLServer modelChainerJsTsNETCoreSQLServer { get; set; }
        public Models.Tools.fieldChainerNET8BlazorMSSQLServerCodeFirst fieldChainerNET8BlazorMSSQLServerCodeFirst { get; set; }

        public Project ProjectChosen { get; set; }
        public DataBase DataBaseChosen { get; set; }
        public List<Table> lstTableInFiyiStack { get; set; }
        public List<Table> lstTableToGenerate { get; set; }
        public List<Field> lstFieldToGenerate { get; set; }
        public List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate { get; set; }

        #region Constructors
        public GeneratorConfigurationComponent(Configuration Configuration,
            Models.Tools.fieldChainerNET8MSSQLServerAPI fieldChainerNET8MSSQLServerAPI,
            Models.Tools.modelChainerNET8MSSQLServerAPI modelChainerNET8MSSQLServerAPI,
            Models.Tools.fieldChainerNodeJsExpressMongoDB fieldChainerNodeJsExpressMongoDB,
            Models.Tools.fieldChainerJsTsNETCoreSQLServer fieldChainerJsTsNETCoreSQLServer,
            Models.Tools.modelChainerJsTsNETCoreSQLServer modelChainerJsTsNETCoreSQLServer,
            Models.Tools.fieldChainerNET8BlazorMSSQLServerCodeFirst fieldChainerNET8BlazorMSSQLServerCodeFirst,
            Project ProjectChosen,
            DataBase DataBaseChosen,
            List<Table> lstTableInFiyiStack,
            List<Table> lstTableToGenerate,
            List<Field> lstFieldToGenerate,
            List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate)
        {

            //Initialization
            this.fieldChainerNET8MSSQLServerAPI = new Models.Tools.fieldChainerNET8MSSQLServerAPI();
            this.modelChainerNET8MSSQLServerAPI = new Models.Tools.modelChainerNET8MSSQLServerAPI();
            this.fieldChainerNodeJsExpressMongoDB = new Models.Tools.fieldChainerNodeJsExpressMongoDB();
            this.fieldChainerJsTsNETCoreSQLServer = new Models.Tools.fieldChainerJsTsNETCoreSQLServer();
            this.modelChainerJsTsNETCoreSQLServer = new Models.Tools.modelChainerJsTsNETCoreSQLServer();
            this.ProjectChosen = new Project();
            this.DataBaseChosen = new DataBase();
            this.lstTableInFiyiStack = [];
            this.lstTableToGenerate = [];
            this.lstFieldToGenerate = [];
            this.lstStoredProcedureToGenerate = [];

            //Copy objects from parameters
            this.Configuration = Configuration;
            this.fieldChainerNET8MSSQLServerAPI = fieldChainerNET8MSSQLServerAPI;
            this.modelChainerNET8MSSQLServerAPI = modelChainerNET8MSSQLServerAPI;
            this.fieldChainerNodeJsExpressMongoDB = fieldChainerNodeJsExpressMongoDB;
            this.fieldChainerJsTsNETCoreSQLServer = fieldChainerJsTsNETCoreSQLServer;
            this.modelChainerJsTsNETCoreSQLServer = modelChainerJsTsNETCoreSQLServer;
            this.ProjectChosen = ProjectChosen;
            this.DataBaseChosen = DataBaseChosen;
            this.lstTableInFiyiStack = lstTableInFiyiStack;
            this.lstTableToGenerate = lstTableToGenerate;
            this.lstFieldToGenerate = lstFieldToGenerate;
            this.lstStoredProcedureToGenerate = lstStoredProcedureToGenerate;

            InitializeComponent();
        }

        public GeneratorConfigurationComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        } 
        #endregion
    }
}
