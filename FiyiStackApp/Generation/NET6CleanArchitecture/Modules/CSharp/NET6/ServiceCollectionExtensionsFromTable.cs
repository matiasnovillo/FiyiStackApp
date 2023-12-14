using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string ServiceCollectionExtensionsFromTable(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using Microsoft.Extensions.DependencyInjection;
using {Table.Name}.Controllers;
using {Table.Name}.Core.Extensions;
using {Table.Name}.Insfrastructure.Extensions;
using Shared.Infrastructure.Extensions;

namespace {Table.Name}.Extensions;
public static class ServiceCollectionExtensions
{{
    public static IServiceCollection Add{Table.Name}(this IServiceCollection services)
    {{
        services.Add{Table.Name}Core();
        services.Add{Table.Name}Infrastructure();
        services.AddSwaggerComments<{Table.Name}Controller>();
        return services;
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
