using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
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
                        $@"import {{ UserEntity }} from ""../../../CMSCore/User_TsEntity"";
import {{ {Table.Name}Entity }} from ""../TsEntities/{Table.Name}_TsEntity"";

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

export class paginated{Table.Name}DTO {{
    lst{Table.Name}?: {Table.Name}Entity[] | undefined;
    lstUserCreation?: UserEntity[] | undefined;
    lstUserLastModification?: UserEntity[] | undefined;
    TextToSearch?: string;
    IsStrictSearch?: boolean;
    PageIndex?: number;
    PageSize?: number;
    TotalItems?: number;
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
