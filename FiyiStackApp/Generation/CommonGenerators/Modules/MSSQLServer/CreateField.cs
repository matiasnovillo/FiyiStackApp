using System.Data;
using Dapper;
using FiyiStackApp.Models.Core;
using Microsoft.Data.SqlClient;

namespace FiyiStackApp.Generation.CommonGenerators.Modules.MSSQLServer
{
    public static partial class MSSQLServer
    {
        public static string CreateField(GeneratorConfigurationComponent GeneratorConfigurationComponent, string DataBaseName, string TableArea, string TableName, string TableScheme, Field Field)
        {
            
            try
            {
                string NonQuery = $@"

--Last modification on: {DateTime.Now}

";


                switch (Field.DataTypeId)
                {
                    case 3: //Integer
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] INT {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 4: //Boolean
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] TINYINT {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 5: //Text: Basic
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR({Field.MaxValue}) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 6: //Decimal
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] NUMERIC(24,6) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 8: //Primary Key (Id)
                        break;
                    case 10: //DateTime
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] DATETIME {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 11: //Time
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] TIME(3) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 13: //Foreign Key (Id): Options
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] INT {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 14: //Text: HexColour
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR(7) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 15: //Text: TextArea
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] TEXT {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 16: //Text: TextEditor
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] TEXT {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 17: //Text: Password
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR({Field.MaxValue}) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 18: //Text: PhoneNumber
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR({Field.MaxValue}) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 19: //Text: URL
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR({Field.MaxValue}) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 20: //Text: Email
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR({Field.MaxValue}) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 21: //Text: File
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR({Field.MaxValue}) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 22: //Text: Tag
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] VARCHAR({Field.MaxValue}) {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    case 23: //Foreign Key (Id): DropDown
                        NonQuery += $@"USE [{DataBaseName}]
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    ALTER TABLE [{TableScheme}].[{TableArea}.{TableName}] ADD [{Field.Name}] INT {(Field.Nullable == true ? "NULL" : "NOT NULL")}";
                        break;
                    default:
                        throw new Exception($"{Field.Name} have a Data Type not recognized");
                }

                if (Field.Name != TableName + "Id")
                {
                    using (SqlConnection sqlConnection = new SqlConnection(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer))
                    {
                        var dataReader = sqlConnection.ExecuteReader(NonQuery, commandType: CommandType.Text);
                    } 
                }

                return NonQuery;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
