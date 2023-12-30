using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.NET6CleanArchitecture.Languages;

namespace FiyiStackApp.Generation
{
    public static class GeneratorNET6CleanArchitecture
    {
        public static string Start(Configuration Configuration,
            Models.Tools.fieldChainerNET8MSSQLServerAPI fieldChainerNET8MSSQLServerAPI,
            Models.Tools.modelChainerNET8MSSQLServerAPI modelChainerNET8MSSQLServerAPI,
            Models.Tools.fieldChainerNodeJsExpressMongoDB fieldChainerNodeJsExpressMongoDB,
            Models.Tools.fieldChainerJsTsNETCoreSQLServer fieldChainerJsTsNETCoreSQLServer,
            Models.Tools.modelChainerJsTsNETCoreSQLServer modelChainerJsTsNETCoreSQLServer,
            Models.Tools.fieldChainerNET8BlazorMSSQLServerCodeFirst fieldChainerNET8BlazorMSSQLServerCodeFirst,
            Models.Core.Project ProjectChosen,
            Models.Core.DataBase DataBaseChosen,
            List<Models.Core.Table> lstTableInFiyiStack,
            List<Models.Core.Table> lstTableToGenerate,
            List<Models.Core.Field> lstFieldToGenerate,
            List<StoredProcedure> lstStoredProcedureToGenerate)
        {
            GeneratorConfigurationComponent GeneratorConfigurationComponent = new GeneratorConfigurationComponent(Configuration,
            fieldChainerNET8MSSQLServerAPI,
            modelChainerNET8MSSQLServerAPI,
            fieldChainerNodeJsExpressMongoDB,
            fieldChainerJsTsNETCoreSQLServer,
            modelChainerJsTsNETCoreSQLServer,
            fieldChainerNET8BlazorMSSQLServerCodeFirst,
            ProjectChosen,
            DataBaseChosen,
            lstTableInFiyiStack,
            lstTableToGenerate,
            lstFieldToGenerate,
            lstStoredProcedureToGenerate);

            try
            {
                string LogText = $@"Starting...
{GeneratorConfigurationComponent.lstTableToGenerate.Count} tables to work with
{GeneratorConfigurationComponent.lstFieldToGenerate.Count} fields to work with
{GeneratorConfigurationComponent.lstStoredProcedureToGenerate.Count} stored procedures to work with
";


                LogText += $"Entering C# language{Environment.NewLine}";
                LogText += CSharp.Start(GeneratorConfigurationComponent);

                return LogText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
