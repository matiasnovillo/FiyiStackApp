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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.CMS.UserBack.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.DatabaseContexts;
using System.Text.RegularExpressions;
using System.Data;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.{Table.Name}Back.Repositories
{{
    public class {Table.Name}Repository : I{Table.Name}Repository
    {{
        protected readonly {GeneratorConfigurationComponent.ProjectChosen.Name}Context _context;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;

        public {Table.Name}Repository({GeneratorConfigurationComponent.ProjectChosen.Name}Context context, IMemoryCache memoryCache)
        {{
            _context = context;
            _memoryCache = memoryCache;

            _memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {{
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            }};
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
                //Look in cache first
                if (!_memoryCache.TryGetValue($@""{Table.Area}.{Table.Name}.{Table.Name}Id={{{Table.Name.ToLower()}Id}}"", out {Table.Name}? {Table.Name.ToLower()}))
                {{
                    //If not exist in cache, look in DB
                    {Table.Name.ToLower()} = _context.{Table.Name}
                                .FirstOrDefault(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id);
                    
                    if ({Table.Name.ToLower()} != null)
                    {{
                        _memoryCache.Set({Table.Name.ToLower()}Id, {Table.Name.ToLower()}, _memoryCacheEntryOptions);
                    }}
                }}
                return {Table.Name.ToLower()};
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

        public List<{Table.Name}> GetAllBy{Table.Name}IdForModal(string textToSearch)
        {{
            try
            {{
                var query = from {Table.Name.ToLower()} in _context.{Table.Name}
                            select new {{ {Table.Name} = {Table.Name.ToLower()}}};

                // Extraemos los resultados en listas separadas
                List<{Table.Name}> lst{Table.Name} = query.Select(result => result.{Table.Name})
                        .Where(x => x.{Table.Name}Id.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lst{Table.Name};
            }}
            catch (Exception) {{ throw; }}
        }}

        public List<{Table.Name}?> GetAllBy{Table.Name}Id(List<int> lst{Table.Name}Checked)
        {{
            try
            {{
                List<{Table.Name}?> lst{Table.Name} = [];

                foreach (int {Table.Name}Id in lst{Table.Name}Checked)
                {{
                    {Table.Name} {Table.Name.ToLower()} = _context.{Table.Name}.Where(x => x.{Table.Name}Id == {Table.Name}Id).FirstOrDefault();

                    if ({Table.Name.ToLower()} != null)
                    {{
                        lst{Table.Name}.Add({Table.Name.ToLower()});
                    }}
                }}

                return lst{Table.Name};
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

                List<{Table.Name}> lst{Table.Name} = _context.{Table.Name}
                        .AsQueryable()
                        .Where(x => strictSearch ?
                            words.All(word => x.{Table.Name}Id.ToString().Contains(word)) :
                            words.Any(word => x.{Table.Name}Id.ToString().Contains(word)))
                        .OrderByDescending(x => x.DateTimeLastModification)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                List<User> lstUserCreation = [];
                List<User> lstUserLastModification = [];

                foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
                {{

                    User UserCreation = _context.User
                        .AsQueryable()
                        .Where(x => x.UserCreationId == {Table.Name.ToLower()}.UserCreationId)
                        .FirstOrDefault();

                    lstUserCreation.Add(UserCreation);

                    User UserLastModification = _context.User
                       .AsQueryable()
                       .Where(x => x.UserLastModificationId == {Table.Name.ToLower()}.UserLastModificationId)
                       .FirstOrDefault();

                    lstUserLastModification.Add(UserLastModification);
                }}

                return new paginated{Table.Name}DTO
                {{
                    lst{Table.Name} = lst{Table.Name},
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    TotalItems = Total{Table.Name},
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
                EntityEntry<{Table.Name}> {Table.Name}ToAdd = _context.{Table.Name}.Add({Table.Name.ToLower()});

                bool result = _context.SaveChanges() > 0;

                if (result)
                {{
                    int Added{Table.Name}Id = {Table.Name}ToAdd.Entity.{Table.Name}Id;

                    _memoryCache.Set($@""{Table.Area}.{Table.Name}.{Table.Name}Id={{Added{Table.Name}Id}}"", {Table.Name.ToLower()}, _memoryCacheEntryOptions);
                }}

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public bool Update({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _context.{Table.Name}.Update({Table.Name.ToLower()});

                bool result = _context.SaveChanges() > 0;

                if (result)
                {{
                    _memoryCache.Set($@""{Table.Area}.{Table.Name}.{Table.Name}Id={{{Table.Name.ToLower()}.{Table.Name}Id}}"", {Table.Name.ToLower()}, _memoryCacheEntryOptions);
                }}

                return result;
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

                bool result = _context.SaveChanges() > 0;

                if (result)
                {{
                    _memoryCache.Remove($@""{Table.Area}.{Table.Name}.{Table.Name}Id={{{Table.Name.ToLower()}Id}}"");
                }}

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Methods for DataTable
        public DataTable GetAllBy{Table.Name}IdInDataTable(List<int> lst{Table.Name}Checked)
        {{
            try
            {{
                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable1}

                foreach (int {Table.Name}Id in lst{Table.Name}Checked)
                {{
                    {Table.Name} {Table.Name.ToLower()} = _context.{Table.Name}.Where(x => x.{Table.Name}Id == {Table.Name}Id).FirstOrDefault();

                    if ({Table.Name.ToLower()} != null)
                    {{
                        DataTable.Rows.Add(
                        {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable}
                        );
                    }}
                }}                

                return DataTable;
            }}
            catch (Exception) {{ throw; }}
        }}

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
