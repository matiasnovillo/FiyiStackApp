using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NodeJsExpressMongoDB.Modules
{
    public static partial class TypeScript
    {
        public static string httpfile(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            string Content = $@"

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

@api = http://localhost:3000/api

### Select all
{{{{api}}}}/{Table.Area}/{Table.Name}

### Select 1
{{{{api}}}}/{Table.Area}/{Table.Name}/657b59d6a088d5a86a51a00b

### Insert
POST {{{{api}}}}/{Table.Area}/{Table.Name}
Content-Type: application/json

{{
    {GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB.FieldForHTTPFile}
}}

### Update
PATCH {{{{api}}}}/{Table.Area}/{Table.Name}/657b59d6a088d5a86a51a00b
Content-Type: application/json

{{
    {GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB.FieldForHTTPFile}
}}

### Delete
DELETE {{{{api}}}}/{Table.Area}/{Table.Name}/657b59d6a088d5a86a51a00b";

            return Content;
        }
    }
}
