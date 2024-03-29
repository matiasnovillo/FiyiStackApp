﻿using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace FiyiStackApp.Generation.CommonGenerators.Modules.MSSQLServer   
{
    public static partial class MSSQLServer
    {
        public static void CreateStoredProcedureUpdateBy(GeneratorConfigurationComponent GeneratorConfigurationComponent, string Action, Table Table)
        {
            try
            {
                string NonQuery = $@"CREATE PROCEDURE [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
(
    {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.SQLServerFieldsForParametersInUpdateBy_ForSQLServer}
    @RowsAffected INT OUTPUT
)

AS

{Security.WaterMark(Security.EWaterMarkFor.MSSQLServer, Constant.FiyiStackGUID.ToString())}

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected int
EXEC [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
    @{Table.Name}Id = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: {DateTime.Now}

UPDATE [{Table.Area}.{Table.Name}] SET
{GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.SQLServerFieldsForUpdateInUpdateBy_ForSQLServer}";

                NonQuery = NonQuery.TrimEnd('\n', '\r', ',');
                NonQuery += $@"
WHERE 
    1 = 1 
    AND [{Table.Area}.{Table.Name}].[{Table.Name}Id] = @{Table.Name}Id 

SELECT @RowsAffected = @@ROWCOUNT";


                NonQuery.Replace("\r", "").Replace("\n", "");

                using (SqlConnection sqlConnection = new SqlConnection(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer))
                {
                    var dataReader = sqlConnection.ExecuteReader(NonQuery, commandType: CommandType.Text);
                }

                #region Create script in project folder
                string ScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\SQLScripts\\";
                if (!Directory.Exists(ScriptPath))
                { Directory.CreateDirectory(ScriptPath); }

                WinFormConfigurationComponent.CreateFile(
                $"{ScriptPath}{Table.Area}.{Table.Name}_UpdateBy.sql",
                NonQuery,
                GeneratorConfigurationComponent.Configuration.DeleteFiles);
                #endregion
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
