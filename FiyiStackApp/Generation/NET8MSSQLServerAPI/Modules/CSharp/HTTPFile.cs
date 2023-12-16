using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules
{
    public static partial class CSharp
    {
        public static string HTTPFile(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"@api = http://localhost:PutHerePortNumber/api

### Select1By{Table.Name}Id
{{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/Select1By{Table.Name}IdToJSON/1

### SelectAll
{{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/SelectAllToJSON

### SelectAllPaged
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/SelectAllPagedToJSON
Content-Type: application/json

{{
    ""QueryString"" : """",
    ""ActualPageNumber"" : 1,
    ""RowsPerPage"": 10,
    ""SorterColumn"": ""{Table.Name}Id"",
    ""SortToggler"": false,
    ""TotalRows"": 0,
    ""TotalPages"": 0
}}

### InsertOrUpdate
POST {{{{api}}}}/{Table.Area}/{Table.Name}/{Table.Version}/InsertOrUpdate
Content-Type: application/json

{{
    {GeneratorConfigurationComponent.fieldChainerNET8MSSQLServerAPI.FieldForHTTPFile.TrimEnd('\t', '\n', '\r', ',')}
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
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
