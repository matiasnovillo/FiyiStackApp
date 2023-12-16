using FiyiStackApp.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Models.Core.Project ProjectChosen,
            Models.Core.DataBase DataBaseChosen,
            List<Models.Core.Table> lstTableInFiyiStack,
            List<Models.Core.Table> lstTableToGenerate,
            List<Models.Core.Field> lstFieldToGenerate,
            List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate)
        {

            //Initialization
            this.fieldChainerNET8MSSQLServerAPI = new Models.Tools.fieldChainerNET8MSSQLServerAPI();
            this.modelChainerNET8MSSQLServerAPI = new Models.Tools.modelChainerNET8MSSQLServerAPI();
            this.fieldChainerNodeJsExpressMongoDB = new Models.Tools.fieldChainerNodeJsExpressMongoDB();
            this.fieldChainerJsTsNETCoreSQLServer = new Models.Tools.fieldChainerJsTsNETCoreSQLServer();
            this.modelChainerJsTsNETCoreSQLServer = new Models.Tools.modelChainerJsTsNETCoreSQLServer();
            this.ProjectChosen = new Models.Core.Project();
            this.DataBaseChosen = new Models.Core.DataBase();
            this.lstTableInFiyiStack = new List<Models.Core.Table>();
            this.lstTableToGenerate = new List<Models.Core.Table>();
            this.lstFieldToGenerate = new List<Models.Core.Field>();
            this.lstStoredProcedureToGenerate = new List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure>();

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
