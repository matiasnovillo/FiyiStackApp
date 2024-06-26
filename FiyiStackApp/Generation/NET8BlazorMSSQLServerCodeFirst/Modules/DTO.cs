﻿using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string DTO(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.CMS.UserBack.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs
{{
    public class paginated{Table.Name}DTO
    {{
        public List<{Table.Name}?> lst{Table.Name} {{ get; set; }}
        public List<User?> lstUserCreation {{ get; set; }}
        public List<User?> lstUserLastModification {{ get; set; }}

        //FOREIGN LISTS (TABLES)
        {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.ForeignLists_DTO}

        public int TotalItems {{ get; set; }}
        public int PageIndex {{ get; set; }}
        public int PageSize {{ get; set; }}

        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
