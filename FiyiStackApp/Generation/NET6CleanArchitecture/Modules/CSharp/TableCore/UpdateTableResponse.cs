using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string UpdateTableResponse(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using {Table.Name}.Core.Model;

namespace {Table.Name}.Core.Features.Update{Table.Name};
public class Update{Table.Name}Response
{{
    public {Table.Name}Model {Table.Name} {{ get; set; }} = new();
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
