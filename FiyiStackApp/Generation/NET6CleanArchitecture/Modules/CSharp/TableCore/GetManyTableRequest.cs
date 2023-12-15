using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string GetManyTableRequest(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using MediatR;
using Shared.Core.Enum;

namespace {Table.Name}.Core.Features.GetMany{Table.Name};
public class GetMany{Table.Name}Request : IRequest<GetMany{Table.Name}Response>
{{

}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
