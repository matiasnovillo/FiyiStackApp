using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NodeJsExpressMongoDB.Modules
{
    public static partial class TypeScript
    {
        public static string router(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            string Content = $@"

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

import express from ""express"";

import {{ selectAll{Table.Name}, select1ById, insert{Table.Name}, update{Table.Name}, delete{Table.Name} }} from ""../../controllers/{Table.Area}/{Table.Name}Controller"";
import {{ isAuthenticated, isOwner }} from ""../../middlewares"";

export default (router: express.Router) => {{
  router.get(""/api/{Table.Area}/{Table.Name}"", isAuthenticated, selectAll{Table.Name});
  
  router.get(""/api/{Table.Area}/{Table.Name}/:id"", isAuthenticated, select1ById);
  
  router.post(""/api/{Table.Area}/{Table.Name}"", isAuthenticated, insert{Table.Name});

  router.patch(""/api/{Table.Area}/{Table.Name}/:id"", isAuthenticated, update{Table.Name});
  
  router.delete(""/api/{Table.Area}/{Table.Name}/:id"", isAuthenticated, delete{Table.Name});
}};";

            return Content;
        }
    }
}
