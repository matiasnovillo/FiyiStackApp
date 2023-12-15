using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string GetOneTableRequest(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using MediatR;

namespace {Table.Name}.Core.Features.GetOne{Table.Name};
public class GetOne{Table.Name}Request : IRequest<GetOne{Table.Name}Response>
{{
    public int {Table.Name}Id {{ get; set; }}
}}
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
