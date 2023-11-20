using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.JsTsNETCoreSQLServer.Languages;

namespace FiyiStackApp.Generation
{
    public static class Generator
    {
        public static string Start(Configuration Configuration,
            Models.Tools.fieldChainer fieldChainer,
            Models.Tools.modelChainer modelChainer,
            Models.Core.Project ProjectChosen,
            Models.Core.DataBase DataBaseChosen,
            List<Models.Core.Table> lstTableInFiyiStack,
            List<Models.Core.Table> lstTableToGenerate,
            List<Models.Core.Field> lstFieldToGenerate,
            List<StoredProcedure> lstStoredProcedureToGenerate)
        {
            GeneratorConfigurationComponent GeneratorConfigurationComponent = new GeneratorConfigurationComponent(Configuration,
            fieldChainer,
            modelChainer,
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

                if (DataBaseChosen.IsMSSQLServer)
                {
                    LogText += $"Entering MS SQL Server language {Environment.NewLine}";
                    LogText += MSSQLServer.Start(GeneratorConfigurationComponent);
                }
                else { LogText += $"Generation in MS SQL Server language omitted by user{Environment.NewLine}"; }

                LogText += $"Entering C# language{Environment.NewLine}";
                LogText += CSharp.Start(GeneratorConfigurationComponent);
                LogText += $"Entering TypeScript language{Environment.NewLine}";
                LogText += TypeScript.Start(GeneratorConfigurationComponent);
                LogText += $"Entering JavaScript language{Environment.NewLine}";
                LogText += JavaScript.Start(GeneratorConfigurationComponent);

                return LogText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
