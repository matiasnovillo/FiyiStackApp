using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string InterfaceForService(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using System.Data;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces
{{
    public interface I{Table.Name}Service
    {{
        #region Exportations
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }}
}}
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
