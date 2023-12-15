using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Modules
{
    public static partial class CSharp
    {
        public static string ModuleProfile(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using AutoMapper;
using {Table.Name}.Core.Model;
using Shared.Core.Domain;

namespace {Table.Name}.Core.Mapping;
public class ModuleProfile : Profile
{{
    public ModuleProfile()
    {{
        
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
