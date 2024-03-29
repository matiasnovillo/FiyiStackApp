﻿using FiyiStack.Library.NET;
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
            catch (Exception) {{ throw; }}
        }}

        #region Queries
        public int Count()
        {{
            try
            {{
                return _context.{Table.Name}.Count();
            }}
            catch (Exception) {{ throw; }}
        }}

        public {Table.Name}? GetBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            try
            {{
                return _context.{Table.Name}
                            .FirstOrDefault(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id);
            }}
            catch (Exception) {{ throw; }}
        }}

        public List<{Table.Name}?> GetAll()
        {{
            try
            {{
                return _context.{Table.Name}.ToList();
            }}
            catch (Exception) {{ throw; }}
        }}

        public paginated{Table.Name}DTO GetAllBy{Table.Name}IdPaginated(string textToSearch,
            bool strictSearch,
            int pageIndex, 
            int pageSize)
        {{
            try
            {{
                //textToSearch: ""novillo matias  com"" -> words: {{novillo,matias,com}}
                string[] words = Regex
                    .Replace(textToSearch
                    .Trim(), @""\s+"", "" "")
                    .Split("" "");

                int Total{Table.Name} = _context.{Table.Name}.Count();

                var query = from {Table.Name.ToLower()} in _context.{Table.Name}
                            join userCreation in _context.User on {Table.Name.ToLower()}.UserCreationId equals userCreation.UserId
                            join userLastModification in _context.User on {Table.Name.ToLower()}.UserLastModificationId equals userLastModification.UserId
                            select new {{ {Table.Name} = {Table.Name.ToLower()}, UserCreation = userCreation, UserLastModification = userLastModification }};

                // Extraemos los resultados en listas separadas
                List<{Table.Name}> lst{Table.Name} = query.Select(result => result.{Table.Name})
                        .Where(x => strictSearch ?
                            words.All(word => x.{Table.Name}Id.ToString().Contains(word)) :
                            words.Any(word => x.{Table.Name}Id.ToString().Contains(word)))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                List<User> lstUserCreation = query.Select(result => result.UserCreation).ToList();
                List<User> lstUserLastModification = query.Select(result => result.UserLastModification).ToList();

                return new paginatedRoleDTO
                {{
                    lst{Table.Name} = lst{Table.Name},
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    TotalItems = TotalRole,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                }};
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Non-Queries
        public bool Add({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _context.{Table.Name}.Add({Table.Name.ToLower()});
                return _context.SaveChanges() > 0;
            }}
            catch (Exception) {{ throw; }}
        }}

        public bool Update({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _context.{Table.Name}.Update({Table.Name.ToLower()});
                return _context.SaveChanges() > 0;
            }}
            catch (Exception) {{ throw; }}
        }}

        public bool DeleteBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            try
            {{
                AsQueryable()
                        .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                        .ExecuteDelete();

                return _context.SaveChanges() > 0;
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Other methods
        public DataTable GetAllInDataTable()
        {{
            try
            {{
                List<{Table.Name}> lst{Table.Name} = _context.{Table.Name}.ToList();

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
            catch (Exception) {{ throw; }}
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
