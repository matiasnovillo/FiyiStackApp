using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string GetOneTableResponse(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using {Table.Name}.Core.Model;

namespace {Table.Name}.Core.Features.GetOne{Table.Name};
public class GetOne{Table.Name}Response
{{
    public {Table.Name}Model {Table.Name} {{ get; set; }} = new();
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
