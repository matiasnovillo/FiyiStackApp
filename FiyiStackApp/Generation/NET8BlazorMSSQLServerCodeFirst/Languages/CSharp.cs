using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Languages
{
    public static class CSharp
    {
        public static string Start(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            try
            {
                string LogText = "";

                foreach (Table Table in GeneratorConfigurationComponent.lstTableToGenerate)
                {
                    if (Table.Area == "" || Table.Name == "") { throw new Exception("C# generation cancelled. A table does not have an area or name declared"); }

                    //Here we prepare the fieldChainerNET8MSSQLServerAPI object for every table to generate
                    GeneratorConfigurationComponent.fieldChainerNET8MSSQLServerAPI = new fieldChainerNET8MSSQLServerAPI(Table);
                    GeneratorConfigurationComponent.modelChainerNET8MSSQLServerAPI = new modelChainerNET8MSSQLServerAPI(Table, GeneratorConfigurationComponent.lstTableInFiyiStack);

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";


                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
