using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Models.Tools
{
    public class fieldChainerNET8BlazorMSSQLServerCodeFirst
    {
        public int NumberOfFields { get; set; } = 0; 


        public fieldChainerNET8BlazorMSSQLServerCodeFirst() 
        { 
        }

        ///<summary>
        /// Object used to reduce duplicated code in /Generator/DataToGenerate folder <br/>
        /// This object contains all the fields chained to engage in every part of looped code
        ///</summary>
        public fieldChainerNET8BlazorMSSQLServerCodeFirst(Table Table) 
        {
            Field Field = new Field();
            List<Field> lstField = Field.GetAllByTableIdToModel(Table.TableId);
            NumberOfFields = lstField.Count;

            foreach (Field field in lstField)
            {
                if (field.Name != Table.Name + "Id")
                {

                }
                
                switch (Convert.ToInt32(field.DataTypeId))
                {
                    case 0:
                        throw new Exception("You must choose a Data Type");
                    case 3: //Integer
                        
                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                           
                        }

                        break;
                    case 4: //Boolean
                        

                        if (field.Name != "Active")
                        {
                            
                        }
                        break;
                    case 5: //Text: Basic

                        break;
                    case 6: //Decimal
                        
                        break;
                    case 8: //Primary Key (Id)
                        
                        break;
                    case 10: //DateTime
                        
                        if (field.Name != "DateTimeCreation" && field.Name != "DateTimeLastModification")
                        {
                           
                        }
                        break;
                    case 11: //Time
                        
                        break;
                    case 13: //Foreign Key (Id): Options
                        

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            
                        }
                        break;
                    case 14: //Text: HexColour
                        

                        if (field.Name.ToLower().Contains("colour"))
                        {
                            
                        }
                        else
                        { throw new Exception($"{field.Name} has not 'Colour' in the name"); }

                        
                        break;
                    case 15: //Text: TextArea
                        
                        break;
                    case 16: //Text: TextEditor
                        

                        break;
                    case 17: //Text: Password
                        
                        break;
                    case 18: //Text: PhoneNumber
                        
                        break;
                    case 19: //Text: URL
                        
                        break;
                    case 20: //Text: Email
                        
                        break;
                    case 21: //Text: File
                        
                        break;
                    case 22: //Text: Tag
                        
                        break;
                    case 23: //Foreign Key (Id): DropDown
                        
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
