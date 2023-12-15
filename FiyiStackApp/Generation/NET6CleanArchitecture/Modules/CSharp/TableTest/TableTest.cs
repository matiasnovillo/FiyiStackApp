using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string TableTest(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using Shared.Core.Enum;

namespace {Table.Name}.Test;
public class {Table.Name}Test
{{

}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
