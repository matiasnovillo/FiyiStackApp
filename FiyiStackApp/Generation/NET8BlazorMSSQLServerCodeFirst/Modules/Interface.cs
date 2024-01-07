using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string Interface(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
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
        Task<int> Count(CancellationToken cancellationToken);

        Task<{Table.Name}?> GetBy{Table.Name}Id(int testId, CancellationToken cancellationToken);

        Task<List<{Table.Name}?>> GetAll(CancellationToken cancellationToken);

        Task<paginated{Table.Name}DTO> GetAllBy{Table.Name}IdPaginated(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize,
            CancellationToken cancellationToken);
        #endregion

        #region Non-Queries
        Task<bool> Add({Table.Name} test, CancellationToken cancellationToken);

        Task<bool> Update({Table.Name} test, CancellationToken cancellationToken);

        Task<bool> DeleteBy{Table.Name}Id(int testId, CancellationToken cancellationToken);
        #endregion

        #region Other methods
        Task<DataTable> GetAllInDataTable(CancellationToken cancellationToken);
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
