using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string InterfaceForRepository(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using System.Data;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces
{{
    public interface I{Table.Name}Repository
    {{
        IQueryable<{Table.Name}> AsQueryable();

        #region Queries
        int Count();

        {Table.Name}? GetBy{Table.Name}Id(int {Table.Name.ToLower()}Id);

        List<{Table.Name}?> GetAll();

        paginated{Table.Name}DTO GetAllBy{Table.Name}IdPaginated(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize);
        #endregion

        #region Non-Queries
        int Add({Table.Name} {Table.Name.ToLower()});

        int Update({Table.Name} {Table.Name.ToLower()});

        int DeleteBy{Table.Name}Id(int {Table.Name.ToLower()});

        string DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyBy{Table.Name}Id(int {Table.Name}Id);

        int CopyManyOrAll(Ajax Ajax, string CopyType);
        #endregion
    }}
}}
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
