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
        public Models.Tools.fieldChainer fieldChainer { get; set; }
        public Models.Tools.fieldChainerNodeJsExpressMongoDB fieldChainerNodeJsExpressMongoDB { get; set; }
        public Models.Tools.modelChainer modelChainer { get; set; }
        public Project ProjectChosen { get; set; }
        public DataBase DataBaseChosen { get; set; }
        public List<Table> lstTableInFiyiStack { get; set; }
        public List<Table> lstTableToGenerate { get; set; }
        public List<Field> lstFieldToGenerate { get; set; }
        public List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate { get; set; }

        #region Constructors
        public GeneratorConfigurationComponent(Configuration Configuration,
            Models.Tools.fieldChainer fieldChainer,
            Models.Tools.fieldChainerNodeJsExpressMongoDB fieldChainerNodeJsExpressMongoDB,
            Models.Tools.modelChainer modelChainer,
            Models.Core.Project ProjectChosen,
            Models.Core.DataBase DataBaseChosen,
            List<Models.Core.Table> lstTableInFiyiStack,
            List<Models.Core.Table> lstTableToGenerate,
            List<Models.Core.Field> lstFieldToGenerate,
            List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate)
        {

            //Initialization
            this.fieldChainer = new Models.Tools.fieldChainer();
            this.fieldChainerNodeJsExpressMongoDB = new Models.Tools.fieldChainerNodeJsExpressMongoDB();
            this.modelChainer = new Models.Tools.modelChainer();
            this.ProjectChosen = new Models.Core.Project();
            this.DataBaseChosen = new Models.Core.DataBase();
            this.lstTableInFiyiStack = new List<Models.Core.Table>();
            this.lstTableToGenerate = new List<Models.Core.Table>();
            this.lstFieldToGenerate = new List<Models.Core.Field>();
            this.lstStoredProcedureToGenerate = new List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure>();

            //Copy objects from parameters
            this.Configuration = Configuration;
            this.fieldChainer = fieldChainer;
            this.fieldChainerNodeJsExpressMongoDB = fieldChainerNodeJsExpressMongoDB;
            this.modelChainer = modelChainer;
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
