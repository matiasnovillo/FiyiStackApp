using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string ServiceCollectionExtensionsFromTableCore(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using MediatR;
using Microsoft.Extensions.DependencyInjection;
using {Table.Name}.Core.Abstractions;

namespace {Table.Name}.Core.Extensions;
public static class ServiceCollectionExtensions
{{
    public static IServiceCollection Add{Table.Name}Core(this IServiceCollection services)
    {{
        services.AddMediatR(typeof(I{Table.Name}Repository).Assembly);
        services.AddAutoMapper(typeof(I{Table.Name}Repository).Assembly);
        return services;
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
