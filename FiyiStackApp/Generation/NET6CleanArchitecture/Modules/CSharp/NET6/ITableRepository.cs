using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string ITableRepository(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using Shared.Core;
using Shared.Core.Domain;

namespace {Table.Name}.Core.Abstractions;
public interface I{Table.Name}Repository : IRepository<{Table.Name}, int>
{{
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
