using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class CSharp
    {
        public static string Filter(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

//Last modification on: {DateTime.Now}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Filters
{{
    /// <summary>
    /// Stack:             7 <br/>
    /// Name:              C# Filter. <br/>
    /// Function:          Allow you to intercept HTPP inside a pipeline.<br/>
    /// Last modification: {DateTime.Now}
    /// </summary>
    public class {Table.Name}Filter : ActionFilterAttribute
    {{
        public override void OnActionExecuting(ActionExecutingContext context)
        {{
            int? UserId = context.HttpContext.Session.GetInt32(""UserId"");
            if (UserId == null || UserId == 0)
            {{
                context.HttpContext.Response.Redirect(""/BasicCore/Error?ErrorId=401"");
            }}
        }}

        public override void OnActionExecuted(ActionExecutedContext context)
        {{
        }}

        public override void OnResultExecuting(ResultExecutingContext context)
        {{
            int? UserId = context.HttpContext.Session.GetInt32(""UserId"");
            if (UserId == null || UserId == 0)
            {{
                context.HttpContext.Response.Redirect(""/BasicCore/Error?ErrorId=401"");
            }}
        }}

        public override void OnResultExecuted(ResultExecutedContext context)
        {{
        }}
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
