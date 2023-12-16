using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules
{
    public static partial class CSharp
    {
        public static string DTO(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Models;
using System.Collections.Generic;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs
{{

    /// <summary>
    /// Virtual model used for [{Table.Scheme}].[{Table.Area}.{Table.Name}.SelectAllPaged] stored procedure
    /// </summary>
    public partial class {Table.Name.ToLower()}SelectAllPaged
    {{
        public string QueryString {{ get; set; }}
        public int ActualPageNumber {{ get; set; }}
        public int RowsPerPage {{ get; set; }}
        public string SorterColumn {{ get; set; }}
        public bool SortToggler {{ get; set; }}
        public int TotalRows {{ get; set; }}
        public int TotalPages {{ get; set; }}
        public List<{Table.Name}Model> lst{Table.Name}Model {{ get; set; }}
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
