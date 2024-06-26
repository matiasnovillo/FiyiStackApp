﻿using FiyiStackApp.Models.Core;
using System.ComponentModel;

namespace FiyiStackApp.Generation
{
    public partial class GeneratorConfigurationComponent : Component
    {
        public Configuration Configuration { get; set; }
        public Models.Tools.fieldChainerNET8BlazorMSSQLServerCodeFirst fieldChainerNET8BlazorMSSQLServerCodeFirst { get; set; }

        public Project ProjectChosen { get; set; }
        public DataBase DataBaseChosen { get; set; }
        public List<Table> lstTableInFiyiStack { get; set; }
        public List<Table> lstTableToGenerate { get; set; }
        public List<Field> lstFieldToGenerate { get; set; }
        public List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate { get; set; }

        #region Constructors
        public GeneratorConfigurationComponent(Configuration Configuration,
            Models.Tools.fieldChainerNET8BlazorMSSQLServerCodeFirst fieldChainerNET8BlazorMSSQLServerCodeFirst,
            Project ProjectChosen,
            DataBase DataBaseChosen,
            List<Table> lstTableInFiyiStack,
            List<Table> lstTableToGenerate,
            List<Field> lstFieldToGenerate,
            List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate)
        {

            //Initialization
            this.fieldChainerNET8BlazorMSSQLServerCodeFirst = new Models.Tools.fieldChainerNET8BlazorMSSQLServerCodeFirst();
            this.ProjectChosen = new Project();
            this.DataBaseChosen = new DataBase();
            this.lstTableInFiyiStack = [];
            this.lstTableToGenerate = [];
            this.lstFieldToGenerate = [];
            this.lstStoredProcedureToGenerate = [];

            //Copy objects from parameters
            this.Configuration = Configuration;
            this.fieldChainerNET8BlazorMSSQLServerCodeFirst = fieldChainerNET8BlazorMSSQLServerCodeFirst;
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
