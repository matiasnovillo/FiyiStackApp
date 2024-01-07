using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string Repository(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.BasicCore.Entities.Configuration;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces;
using System.Data;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Repositories
{{
    public class {Table.Name}Repository : I{Table.Name}Repository
    {{
        protected readonly EFCoreContext _context;

        public {Table.Name}Repository(EFCoreContext context)
        {{
            _context = context;
        }}

        public IQueryable<{Table.Name}> AsQueryable()
        {{
            try
            {{
                return _context.{Table.Name}.AsQueryable();
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        #region Queries
        public async Task<int> Count(CancellationToken cancellationToken)
        {{
            try
            {{
                return await _context.{Table.Name}.CountAsync();
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        public async Task<{Table.Name}?> GetBy{Table.Name}Id(int {Table.Name.ToLower()}Id, CancellationToken cancellationToken)
        {{
            try
            {{
                return await _context.{Table.Name}
                                .FirstOrDefaultAsync(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id);
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        public async Task<List<{Table.Name}?>> GetAll(CancellationToken cancellationToken)
        {{
            try
            {{
                return await _context.{Table.Name}.ToListAsync();
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        public async Task<paginated{Table.Name}DTO> GetAllBy{Table.Name}IdPaginated(string textToSearch,
            bool strictSearch,
            int pageIndex, 
            int pageSize,
            CancellationToken cancellationToken)
        {{
            try
            {{
                //textToSearch: ""novillo matias  com"" -> words: {{novillo,matias,com}}
                string[] words = Regex
                    .Replace(textToSearch
                    .Trim(), @""\s+"", "" "")
                    .Split("" "");

                int Total{Table.Name} = await _context.{Table.Name}.CountAsync();

                var paginated{Table.Name} = await _context.{Table.Name}
                        .Where(x => strictSearch ?
                            words.All(word => x.{Table.Name}Id.ToString().Contains(word)) :
                            words.Any(word => x.{Table.Name}Id.ToString().Contains(word)))
                        .OrderBy(p => p.{Table.Name}Id)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

                return new paginated{Table.Name}DTO
                {{
                    lst{Table.Name} = paginated{Table.Name},
                    TotalItems = Total{Table.Name},
                    PageIndex = pageIndex,
                    PageSize = pageSize
                }};
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}
        #endregion

        #region Non-Queries
        public async Task<bool> Add({Table.Name} {Table.Name.ToLower()}, 
            CancellationToken cancellationToken)
        {{
            try
            {{
                await _context.{Table.Name}.AddAsync({Table.Name.ToLower()}, cancellationToken);
                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        public async Task<bool> Update({Table.Name} {Table.Name.ToLower()}, 
            CancellationToken cancellationToken)
        {{
            try
            {{
                _context.{Table.Name}.Update({Table.Name.ToLower()});
                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        public async Task<bool> DeleteBy{Table.Name}Id(int {Table.Name.ToLower()}Id, 
            CancellationToken cancellationToken)
        {{
            try
            {{
                AsQueryable()
                        .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                        .ExecuteDelete();

                return await _context.SaveChangesAsync(cancellationToken) > 0;
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}
        #endregion

        #region Other methods
        public async Task<DataTable> GetAllInDataTable(CancellationToken cancellationToken)
        {{
            try
            {{
                List<{Table.Name}> lst{Table.Name} = await _context.{Table.Name}.ToListAsync(cancellationToken);

                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable1}

                foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
                {{
                    DataTable.Rows.Add(
                        {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable}
                        );
                }}

                return DataTable;
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}
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
