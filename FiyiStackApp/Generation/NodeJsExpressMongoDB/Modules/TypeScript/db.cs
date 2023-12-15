using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NodeJsExpressMongoDB.Modules
{
    public static partial class TypeScript
    {
        public static string db(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            string Content = $@"

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

import mongoose from ""mongoose"";

const {Table.Name}Schema = new mongoose.Schema({{
    {GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB.PropertiesInJSONFordb}
  }});

  export const {Table.Name}Model = mongoose.model(""{Table.Name}"", {Table.Name}Schema);

  //{Table.Name} actions
  export const SelectAll = () => {Table.Name}Model.find();

  export const Select1ById = (id: string) => {Table.Name}Model.findById(id);

  export const Insert = (values: Record<string, any>) => new {Table.Name}Model(values).save().then(({Table.Name.ToLower()}) => {Table.Name.ToLower()}.toObject());

  export const UpdateById = (id: string, values: Record<string, any>) => {Table.Name}Model.findByIdAndUpdate(id, values);

  export const DeleteById = (id: string) => {Table.Name}Model.findOneAndDelete({{ _id: id }});";

            return Content;
        }
    }
}
