using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string CreateTableRequest(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using MediatR;
using Shared.Core.Enum;

namespace {Table.Name}.Core.Features.Create{Table.Name};
public class Create{Table.Name}Request : IRequest<Create{Table.Name}Response>
{{

}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
