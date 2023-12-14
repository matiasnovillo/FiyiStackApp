using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.NET6CleanArchitecture.Languages;

namespace FiyiStackApp.Generation
{
    public static class GeneratorNET6CleanArchitecture
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
