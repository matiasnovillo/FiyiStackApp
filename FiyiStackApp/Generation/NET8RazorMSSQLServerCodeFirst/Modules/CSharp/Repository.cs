using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
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
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.CMSCore.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.BasicCore;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;
using System.Data;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Repositories
{{
    public class {Table.Name}Repository : I{Table.Name}Repository
    {{
        protected readonly {GeneratorConfigurationComponent.ProjectChosen.Name}Context _context;

        public {Table.Name}Repository({GeneratorConfigurationComponent.ProjectChosen.Name}Context context)
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
        public int Add({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _context.{Table.Name}.Add({Table.Name.ToLower()});
                _context.SaveChanges();
                
                return {Table.Name.ToLower()}.{Table.Name}Id;   
            }}
            catch (Exception) {{ throw; }}
        }}

        public int Update({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _context.{Table.Name}.Update({Table.Name.ToLower()});
                return _context.SaveChanges();
            }}
            catch (Exception) {{ throw; }}
        }}

        public int DeleteBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            try
            {{
                int RowsDeleted = AsQueryable()
                        .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                        .ExecuteDelete();

                _context.SaveChanges();

                return RowsDeleted;
            }}
            catch (Exception) {{ throw; }}
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""ajax""></param>
        /// <param name=""deleteType""></param>
        /// <returns>Return the rows deleted</returns>
        public string DeleteManyOrAll(Ajax ajax, string deleteType)
        {{
            try
            {{
                if (deleteType == ""All"")
                {{
                    var RegistersToDelete = _context.{Table.Name}.ToList();
                    
                    List<{Table.Name}> lst{Table.Name} = _context.{Table.Name}.ToList();
                    string RowsDeleted = """";

                    for (int i = 0; i < lst{Table.Name}.Count; i++)
                    {{
                        RowsDeleted += $@""{{lst{Table.Name}[i].{Table.Name}Id}},""; 
                    }}

                    RowsDeleted = RowsDeleted.TrimEnd(',');

                    _context.{Table.Name}.RemoveRange(RegistersToDelete);

                    _context.SaveChanges();

                    return RowsDeleted;
                }}
                else
                {{
                    string[] RowsChecked = ajax.AjaxForString.Split(',');

                    for (int i = 0; i < RowsChecked.Length; i++)
                    {{
                        _context.{Table.Name}
                                    .Where(x => x.{Table.Name}Id == Convert.ToInt32(RowsChecked[i]))
                                    .ExecuteDelete();

                        _context.SaveChanges();
                    }}

                    ajax.AjaxForString = ajax.AjaxForString.TrimEnd(',');

                    return ajax.AjaxForString;
                }}
            }}
            catch (Exception) {{ throw; }}
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""{Table.Name.ToLower()}Id""></param>
        /// <returns>The last entered ID after the copy transaction</returns>        
        public int CopyBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            try
            {{
                {Table.Name} {Table.Name} = _context.{Table.Name}
                                .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                                .FirstOrDefault();

                {Table.Name}.{Table.Name}Id = 0;

                _context.{Table.Name}.Add({Table.Name});
                _context.SaveChanges();

                return _context.{Table.Name}
                                .OrderByDescending(x => x.{Table.Name}Id)
                                .FirstOrDefault().{Table.Name}Id;
            }}
            catch (Exception) {{ throw; }}
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""ajax""></param>
        /// <param name=""copyType""></param>
        /// <returns>The number of rows copied</returns>
        public int CopyManyOrAll(Ajax ajax, string copyType)
        {{
            try
            {{
                int NumberOfRegistersEntered = 0;

                if (copyType == ""All"")
                {{
                    List<{Table.Name}> lst{Table.Name} = [];
                    lst{Table.Name} = _context.{Table.Name}.ToList();

                    for (int i = 0; i < lst{Table.Name}.Count; i++)
                    {{
                        {Table.Name} {Table.Name} = lst{Table.Name}[i];
                        {Table.Name}.{Table.Name}Id = 0;
                        _context.{Table.Name}.Add({Table.Name});
                        NumberOfRegistersEntered += _context.SaveChanges();
                    }}
                }}
                else
                {{
                    string[] RowsChecked = ajax.AjaxForString.Split(',');

                    for (int i = 0; i < RowsChecked.Length; i++)
                    {{
                        {Table.Name} {Table.Name} = _context.{Table.Name}
                                                    .Where(x => x.{Table.Name}Id == Convert.ToInt32(RowsChecked[i]))
                                                    .FirstOrDefault();
                        {Table.Name}.{Table.Name}Id = 0;
                        _context.{Table.Name}.Add({Table.Name});
                        NumberOfRegistersEntered += _context.SaveChanges();
                    }}
                }}

                return NumberOfRegistersEntered;
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
