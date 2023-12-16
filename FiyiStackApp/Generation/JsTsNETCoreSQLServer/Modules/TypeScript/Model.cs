using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class TypeScript
    {
        public static string Model(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                //Preparation
                Field Field = new Field();
                List<Field> lstField = Field.GetAllByTableIdToModel(Table.TableId);

                string Content =
                        $@"import * as Rx from ""rxjs"";
import {{ ajax }} from ""rxjs/ajax"";
import {{ Ajax }} from ""../../../Library/Ajax"";
import {{ {Table.Name.ToLower()}SelectAllPaged }} from ""../DTOs/{Table.Name.ToLower()}SelectAllPaged"";
{GeneratorConfigurationComponent.modelChainerJsTsNETCoreSQLServer.Imports_ForTypeScriptModel}

{Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

//{lstField.Count} fields | Sub-models: {GeneratorConfigurationComponent.modelChainerJsTsNETCoreSQLServer.CounterOfModelsThatDependOnThis} models  | Last modification on: {DateTime.Now} | Stack: 9

export class {Table.Name}Model {{

    //Fields
    {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.TsFields_ForTsModel.TrimEnd('\t', '\n', '\r')}
    {GeneratorConfigurationComponent.modelChainerJsTsNETCoreSQLServer.NewList_ForTypeScriptModel}

    //Queries
    static Select1By{Table.Name}Id({Table.Name}Id: number) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/Select1By{Table.Name}IdToJSON/"" + {Table.Name}Id;
        return Rx.from(ajax(URL));
    }}

    static SelectAll() {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/SelectAllToJSON""
        return Rx.from(ajax(URL));
    }}
    
    static SelectAllPaged({Table.Name.ToLower()}SelectAllPaged: {Table.Name.ToLower()}SelectAllPaged) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/SelectAllPagedToJSON"";
        let Body = {{
            QueryString: {Table.Name.ToLower()}SelectAllPaged.QueryString,
            ActualPageNumber: {Table.Name.ToLower()}SelectAllPaged.ActualPageNumber,
            RowsPerPage: {Table.Name.ToLower()}SelectAllPaged.RowsPerPage,
            SorterColumn: {Table.Name.ToLower()}SelectAllPaged.SorterColumn,
            SortToggler: {Table.Name.ToLower()}SelectAllPaged.SortToggler,
            RowCount: {Table.Name.ToLower()}SelectAllPaged.TotalRows,
            TotalPages: {Table.Name.ToLower()}SelectAllPaged.TotalPages,
            lst{Table.Name}Model: {Table.Name.ToLower()}SelectAllPaged.lst{Table.Name}Model
        }};
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    //Non-Queries
    static DeleteBy{Table.Name}Id({Table.Name}Id: number | string | string[] | undefined) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/DeleteBy{Table.Name}Id/"" + {Table.Name}Id;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.delete(URL, Header));
    }}

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/1/DeleteManyOrAll/"" + DeleteType;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}
    
    static CopyBy{Table.Name}Id({Table.Name}Id: string | number | string[] | undefined) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/1/CopyBy{Table.Name}Id/"" + {Table.Name}Id;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        let Body: any = {{}};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    static CopyManyOrAll(CopyType: string, Body: Ajax) {{
        let URL = ""/api/{Table.Name}ing/{Table.Name}/1/CopyManyOrAll/"" + CopyType;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
