using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class TypeScript
    {
        public static string DTO(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                //Preparation
                Field Field = new Field();
                List<Field> lstField = Field.GetAllByTableIdToModel(Table.TableId);

                string Content =
                        $@"import {{ {Table.Name}Model }} from ""../TsModels/{Table.Name}_TsModel"";

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

export class {Table.Name.ToLower()}SelectAllPaged {{
    QueryString?: string;
    ActualPageNumber?: number;
    RowsPerPage?: number;
    SorterColumn?: string;
    SortToggler?: boolean;
    TotalRows?: number;
    TotalPages?: number;
    lst{Table.Name}Model?: {Table.Name}Model[] | undefined;
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
