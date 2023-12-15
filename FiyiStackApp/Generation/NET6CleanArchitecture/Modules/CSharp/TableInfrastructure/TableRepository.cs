using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string TableRepository(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using {Table.Name}.Core.Abstractions;
using Shared.Core.Domain;
using Shared.Infrastructure.Persistence;

namespace {Table.Name}.Insfrastructure.Persistence;
public class {Table.Name}Repository : Repository<{Table.Name}, int>, I{Table.Name}Repository
{{
    public {Table.Name}Repository(DatabaseContext context) : base(context) {{ }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
