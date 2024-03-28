using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string Entity(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities
{{
    public class {Table.Name}
    {{
        {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.PropertiesForEntity}
    
        public string ToStringOnlyValuesForHTML()
        {{
                return $@""<tr>
                    {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.PropertiesInHTMLForEntity}
                    </tr>"";
        }}
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
