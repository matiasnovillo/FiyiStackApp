using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NodeJsExpressMongoDB.Modules
{
    public static partial class TypeScript
    {
        public static string controllers(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            string Content = $@"

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

import express from ""express"";

import {{ SelectAll, Select1ById, Insert, UpdateById, DeleteById }} from ""../../db/{Table.Area}/{Table.Name}Model"";
import {{ authentication, random }} from ""../../helpers"";

export const selectAll{Table.Name} = async (request: express.Request, response: express.Response) => {{
  try {{
    const all{Table.Name.ToLower()} = await SelectAll();

    return response.status(200).json(all{Table.Name.ToLower()});
  }} catch (error) {{
    console.log(error);
    return response.sendStatus(400);
  }}
}};

export const select1ById = async (request: express.Request, response: express.Response) => {{
  try {{
    const {{ id }} = request.params;

    const {Table.Name.ToLower()} = await Select1ById(id);

    return response.status(200).json({Table.Name.ToLower()});
  }} catch (error) {{
    console.log(error);
    return response.sendStatus(400);
  }}
}};

export const insert{Table.Name} = async (request: express.Request, response: express.Response) => {{
  try {{
    const {{
        {GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB.PropertiesInJSON}
    }} = request.body;

    const {Table.Name.ToLower()} = await Insert({{
        {GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB.PropertiesInJSON}
    }});

    return response.status(200).json({Table.Name.ToLower()}).end();
  }} catch (error) {{
    console.log(error);
    return response.sendStatus(400);
  }}
}}

export const update{Table.Name} = async (request: express.Request, response: express.Response) => {{
  try {{
    const {{ id }} = request.params;
    const {{ 
        {GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB.PropertiesInJSON}
      }} = request.body;

    const {Table.Name.ToLower()} = await Select1ById(id);
    
    //Pass data from front-end to back-end
    {GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB.PropertiesForController}
    
    await {Table.Name.ToLower()}.save();

    return response.status(200).json({Table.Name.ToLower()}).end();
  }} catch (error) {{
    console.log(error);
    return response.sendStatus(400);
  }}
}}

export const delete{Table.Name} = async (request: express.Request, response: express.Response) => {{
  try {{
    const {{ id }} = request.params;

    const deleted{Table.Name} = await DeleteById(id);

    return response.json(deleted{Table.Name});
  }} catch (error) {{
    console.log(error);
    return response.sendStatus(400);
  }}
}}";

            return Content;
        }
    }
}
