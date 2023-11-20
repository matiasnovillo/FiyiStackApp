using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class CSharpNETCore
    {
        public static string RazorPageBackQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.CMSCore.Models;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Models;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

//Last modification on: {DateTime.Now}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Pages
{{
    /// <summary>
    /// Stack:             9 <br/>
    /// Name:              C# Razor Page. <br/>
    /// Function:          Allow you to show HTML files using Razor Page technology. <br/>
    /// Last modification: {DateTime.Now}
    /// </summary>
    [{Table.Name}Filter]
    public partial class {Table.Name}QueryPageModel : PageModel
    {{
        public void OnGet()
        {{
            int UserId = HttpContext.Session.GetInt32(""UserId"") ?? 0;
            UserModel UserModel = new UserModel().Select1ByUserIdToModel(UserId);

            string Menues = new RoleMenuModel().SelectMenuesByRoleIdToStringForLayoutDashboard(UserModel.RoleId);

            ViewData[""FantasyName""] = UserModel.FantasyName;
            ViewData[""Menues""] = Menues;
            }}
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
