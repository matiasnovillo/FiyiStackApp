using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string HTTPFile(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"@api = http://localhost:PutHerePortNumber/api

### GetBy{Table.Name}Id
GET {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/GetBy{Table.Name}Id/1

### GetAll
GET {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/GetAll

### GetAllPaginated
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/GetAllPaginated
Content-Type: application/json

{{
    ""lst{Table.Name}"" : [],
    ""lstUserCreation"" : [],
    ""lstUserLastModification"" : [],
    ""TextToSearch"": "",
    ""IsStrictSearch"": false,
    ""PageIndex"" : 1,
    ""PageSize"": 10
}}

### InsertOrUpdate
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/AddOrUpdate
Content-Type: application/json

{{
    {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.FieldForHTTPFile.TrimEnd('\t', '\n', '\r', ',')}
}}

### DeleteBy{Table.Name}Id
DELETE {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/DeleteBy{Table.Name}Id/1

### DeleteManyOrAll
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/DeleteManyOrAll/All
Content-Type: application/json

{{
    ""AjaxForString"": """"
}}

### CopyBy{Table.Name}Id
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/CopyBy{Table.Name}Id/1

### CopyManyOrAll
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/CopyManyOrAll/All
Content-Type: application/json

{{
    ""AjaxForString"": """"
}}

### Export
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/Export/Excel/All
Content-Type: application/json

{{
    ""AjaxForString"": """"
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
