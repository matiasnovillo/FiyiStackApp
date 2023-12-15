using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string ServiceCollectionExtensionsFromInfrastructure(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using Microsoft.Extensions.DependencyInjection;
using {Table.Name}.Core.Abstractions;
using {Table.Name}.Insfrastructure.Persistence;

namespace {Table.Name}.Insfrastructure.Extensions;
public static class ServiceCollectionExtensions
{{
    public static IServiceCollection Add{Table.Name}Infrastructure(this IServiceCollection services)
    {{
        services.AddScoped<I{Table.Name}Repository, {Table.Name}Repository>();
        return services;
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
