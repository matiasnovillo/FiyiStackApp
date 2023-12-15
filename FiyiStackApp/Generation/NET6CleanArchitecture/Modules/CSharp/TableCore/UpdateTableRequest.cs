using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string UpdateTableRequest(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using MediatR;
using Shared.Core.Enum;

namespace {Table.Name}.Core.Features.Update{Table.Name};
public class Update{Table.Name}Request : IRequest<Update{Table.Name}Response>
{{

}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
