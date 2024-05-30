using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string InterfaceRepository(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using System.Data;

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

        List<{Table.Name}?> GetAllBy{Table.Name}Id(List<int> lst{Table.Name}Checked);

        paginated{Table.Name}DTO GetAllBy{Table.Name}IdPaginated(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize);
        #endregion

        #region Non-Queries
        bool Add({Table.Name} {Table.Name.ToLower()});

        bool Update({Table.Name} {Table.Name.ToLower()});

        bool DeleteBy{Table.Name}Id(int {Table.Name.ToLower()});
        #endregion

        #region Methods for DataTable
        DataTable GetAllBy{Table.Name}IdInDataTable(List<int> lst{Table.Name}Checked);

        DataTable GetAllInDataTable();
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
