using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string Table(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using Dawn;
using Shared.Core.Enum;

namespace Shared.Core.Domain;
public class {Table.Name} : Entity<int>
{{

}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
