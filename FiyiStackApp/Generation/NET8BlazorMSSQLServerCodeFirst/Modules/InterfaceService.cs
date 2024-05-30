using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string InterfaceService(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
using System.Data;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces
{{
    public interface I{Table.Name}Service
    {{
        void ExportToExcel(string path, DataTable dt{Table.Name});

        void ExportToCSV(string path, List<{Table.Name}> lst{Table.Name});

        void ExportToPDF(string path, List<{Table.Name}> lst{Table.Name});

        List<{Table.Name}> ImportExcel(string path, int userId);
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
