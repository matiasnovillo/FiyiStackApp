using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class TypeScript
    {
        public static string Entity(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
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
import {{ paginated{Table.Name}DTO }} from ""../DTOs/paginated{Table.Name}DTO"";

{Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

export class {Table.Name}Entity {{

    //Fields
    {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.TsFields_ForTsModel.TrimEnd('\t', '\n', '\r')}

    //Queries
    static GetBy{Table.Name}Id({Table.Name}Id: number) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/GetBy{Table.Name}Id/"" + {Table.Name}Id;
        return Rx.from(ajax(URL));
    }}

    static GetAll() {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/GetAll""
        return Rx.from(ajax(URL));
    }}
    
    static GetAllPaginated(paginated{Table.Name}DTO: paginated{Table.Name}DTO) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/GetAllPaginated"";
        let Body = {{
            ""lst{Table.Name}"": paginated{Table.Name}DTO.lst{Table.Name},
            ""lstUserCreation"": paginated{Table.Name}DTO.lstUserCreation,
            ""lstUserLastModification"": paginated{Table.Name}DTO.lstUserLastModification,
            ""TextToSearch"": paginated{Table.Name}DTO.TextToSearch,
            ""IsStrictSearch"": paginated{Table.Name}DTO.IsStrictSearch,
            ""PageIndex"": paginated{Table.Name}DTO.PageIndex,
            ""PageSize"": paginated{Table.Name}DTO.PageSize
        }};
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    //Non-Queries
    static AddOrUpdate(Body: Ajax) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/AddOrUpdate"";
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    static DeleteBy{Table.Name}Id({Table.Name}Id: number | string | string[] | undefined) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/DeleteBy{Table.Name}Id/"" + {Table.Name}Id;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.delete(URL, Header));
    }}

    static DeleteManyOrAll(DeleteType: string, Body: Ajax) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/DeleteManyOrAll/"" + DeleteType;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}
    
    static CopyBy{Table.Name}Id({Table.Name}Id: string | number | string[] | undefined) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/CopyBy{Table.Name}Id/"" + {Table.Name}Id;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        let Body: any = {{}};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    static CopyManyOrAll(CopyType: string, Body: Ajax) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/CopyManyOrAll/"" + CopyType;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    //Exportations
    static ExportAsPDF(ExportationType: string, Body: Ajax) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/ExportAsPDF/"" + ExportationType;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    static ExportAsExcel(ExportationType: string, Body: Ajax) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/ExportAsExcel/"" + ExportationType;
        let Header: any = {{
            ""Accept"": ""application/json"",
            ""Content-Type"": ""application/json; charset=utf-8""
        }};
        return Rx.from(ajax.post(URL, Body, Header));
    }}

    static ExportAsCSV(ExportationType: string, Body: Ajax) {{
        let URL = ""/api/{Table.Area}/{Table.Name}/{Table.Version}/ExportAsCSV/"" + ExportationType;
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
