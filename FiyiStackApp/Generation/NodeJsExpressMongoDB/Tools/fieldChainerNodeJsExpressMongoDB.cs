using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Models.Tools
{
    public class fieldChainerNodeJsExpressMongoDB
    {
        public int NumberOfFields { get; set; } = 0;

        public string PropertiesInJSON { get; set; } = "";

        public string PropertiesInJSONFordb { get; set; } = "";

        public string PropertiesForController { get; set; } = "";

        public string FieldForHTTPFile { get; set; } = "";

        public fieldChainerNodeJsExpressMongoDB() 
        { 
        }

        ///<summary>
        /// Object used to reduce duplicated code in /Generator/DataToGenerate folder <br/>
        /// This object contains all the fields chained to engage in every part of looped code
        ///</summary>
        public fieldChainerNodeJsExpressMongoDB(Table Table) 
        {
            Field Field = new Field();
            List<Field> lstField = Field.GetAllByTableIdToModel(Table.TableId);
            NumberOfFields = lstField.Count;

            foreach (Field field in lstField)
            {
                if (field.Name != Table.Name + "Id")
                {
                    PropertiesInJSON += $@"{field.Name},
        ";
                    PropertiesForController += $@"{Table.Name.ToLower()}.{field.Name} = {field.Name};
    ";
                }
                
                switch (Convert.ToInt32(field.DataTypeId))
                {
                    case 0:
                        throw new Exception("You must choose a Data Type");

                    case 3: //Integer
                        
                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: Number{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        break;
                    case 4: //Boolean
                        
                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: Boolean{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : true,{Environment.NewLine}";

                        break;
                    case 5: //Text: Basic
                        
                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 6: //Decimal

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: mongoose.Schema.Types.Decimal128{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 3.14,{Environment.NewLine}";

                        break;
                    case 8: //Primary Key (Id)
                        

                        break;
                    case 10: //DateTime

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: Date{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""1753-01-01T00:00:00.001Z"",{Environment.NewLine}";

                        break;
                    case 11: //Time

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""00:00:00.001"",{Environment.NewLine}";

                        break;
                    case 13: //Foreign Key (Id): Options

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: Number{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {

                        }
                        break;
                    case 14: //Text: HexColour
                        if (field.Name.ToLower().Contains("colour"))
                        {
                            PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";
                            FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";
                        }
                        else
                        { throw new Exception($"{field.Name} has not 'Colour' in the name"); }

                        break;
                    case 15: //Text: TextArea

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 16: //Text: TextEditor

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 17: //Text: Password

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 18: //Text: PhoneNumber

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 19: //Text: URL

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 20: //Text: Email

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 21: //Text: File

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 22: //Text: Tag

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: String{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        break;
                    case 23: //Foreign Key (Id): DropDown

                        PropertiesInJSONFordb += $@"{field.Name}: {{ type: Number{(field.Nullable == true ? "" : ", required: true")} }},
    ";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {

                        }
                        
                        break;
                    default:
                        throw new Exception("ERROR localizing Data Type: The Data Type identificator is not correct");
                }
            }
        }
    }
}
