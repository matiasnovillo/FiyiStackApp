using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Languages;
using FiyiStackApp.Generation.CommonGenerators.Languages;

namespace FiyiStackApp.Generation
{
    public static class GeneratorNET8BlazorMSSQLServerCodeFirst
    {
        public static string Start(Configuration Configuration,
            Models.Tools.fieldChainerNodeJsExpressMongoDB fieldChainerNodeJsExpressMongoDB,
            Models.Tools.fieldChainerNET8BlazorMSSQLServerCodeFirst fieldChainerNET8BlazorMSSQLServerCodeFirst,
            Models.Tools.fieldChainerNET8RazorMSSQLServerCodeFirst fieldChainerNET8RazorMSSQLServerCodeFirst,
            Models.Core.Project ProjectChosen,
            Models.Core.DataBase DataBaseChosen,
            List<Models.Core.Table> lstTableInFiyiStack,
            List<Models.Core.Table> lstTableToGenerate,
            List<Models.Core.Field> lstFieldToGenerate,
            List<StoredProcedure> lstStoredProcedureToGenerate)
        {
            GeneratorConfigurationComponent GeneratorConfigurationComponent = new GeneratorConfigurationComponent(Configuration,
            fieldChainerNodeJsExpressMongoDB,
            fieldChainerNET8BlazorMSSQLServerCodeFirst,
            fieldChainerNET8RazorMSSQLServerCodeFirst,
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
";

                LogText += $"Entering Microsoft SQL Server language{Environment.NewLine}";
                LogText += MSSQLServer.Start(GeneratorConfigurationComponent);
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
