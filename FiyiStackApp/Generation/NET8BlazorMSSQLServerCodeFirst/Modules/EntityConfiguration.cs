using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string EntityConfiguration(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.EntitiesConfiguration
{{
    public class {Table.Name}Configuration : IEntityTypeConfiguration<{Table.Name}>
    {{
        public void Configure(EntityTypeBuilder<{Table.Name}> entity)
        {{
            try
            {{
                //{Table.Name}Id
                entity.HasKey(e => e.{Table.Name}Id);
                entity.Property(e => e.{Table.Name}Id)
                    .ValueGeneratedOnAdd();

                {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesForEntityConfiguration}
            }}
            catch (Exception) {{ throw; }}
        }}
    }}
}}
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
