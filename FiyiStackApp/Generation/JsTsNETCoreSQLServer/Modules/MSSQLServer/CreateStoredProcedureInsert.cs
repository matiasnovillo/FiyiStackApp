﻿using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class MSSQLServer
    {
        public static void CreateStoredProcedureInsert(GeneratorConfigurationComponent GeneratorConfigurationComponent, string Action, Table Table)
        {
            try
            {
                string NonQuery = $@"CREATE PROCEDURE [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}] 
({GeneratorConfigurationComponent.fieldChainer.SQLServerFieldsForParametersInInsert_ForSQLServer}
    @NewEnteredId INT OUTPUT
)

AS

{Security.WaterMark(Security.EWaterMarkFor.MSSQLServer, Constant.FiyiStackGUID.ToString())}

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@NewEnteredId INT
EXEC [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
{GeneratorConfigurationComponent.fieldChainer.SQLServerFieldsForParametersExample_ForSQLServer}
@NewEnteredId = @NewEnteredId OUTPUT

SELECT @NewEnteredId AS N'@NewEnteredId'
 *
 */

--Last modification on: {DateTime.Now}

INSERT INTO [{Table.Area}.{Table.Name}]
(
{GeneratorConfigurationComponent.fieldChainer.SQLServerFieldsForInsertInto_ForSQLServer}
";
                NonQuery = NonQuery.TrimEnd('\n', '\r', ',');
                NonQuery += $@"
)
VALUES
(
{GeneratorConfigurationComponent.fieldChainer.SQLServerFieldsForValues_ForSQLServer}
";
                NonQuery = NonQuery.TrimEnd('\n','\r',',');
                NonQuery += $@"
)

SELECT @NewEnteredId = @@IDENTITY";


                NonQuery.Replace("\r", "").Replace("\n", "");

                using (SqlConnection sqlConnection = new SqlConnection(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer))
                {
                    var dataReader = sqlConnection.ExecuteReader(NonQuery, commandType: CommandType.Text);
                }

                #region Create script in project folder
                string ScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\SQLScripts\\";
                if (!Directory.Exists(ScriptPath))
                { Directory.CreateDirectory(ScriptPath); }

                WinFormConfigurationComponent.CreateFile(
                $"{ScriptPath}{Table.Area}.{Table.Name}_Insert.sql",
                NonQuery,
                GeneratorConfigurationComponent.Configuration.DeleteFiles);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
