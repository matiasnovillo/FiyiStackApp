using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;


namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class MSSQLServer
    {
        public static void CreateStoredProcedureDeleteBy(GeneratorConfigurationComponent GeneratorConfigurationComponent, string Action, Table Table)
        {
            try
            {
                string NonQuery =   //The USE [Database] statement is not allowed in CREATE/ALTER Procedure statements
$@"CREATE PROCEDURE [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
(
    @{Table.Name}Id INT,
    @RowsAffected INT OUTPUT
)

AS

{Security.WaterMark(Security.EWaterMarkFor.MSSQLServer, Constant.FiyiStackGUID.ToString())}

/*
 * Execute this stored procedure with the next script as example
 *
DECLARE	@RowsAffected INT
EXEC [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
    @{Table.Name}Id = 1,
    @RowsAffected = @RowsAffected OUTPUT
SELECT @RowsAffected AS N'@RowsAffected'
 *
 */

--Last modification on: {DateTime.Now}

DELETE FROM 
    [{Table.Area}.{Table.Name}]
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
                string ScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\SQLScripts\\";
                if (!Directory.Exists(ScriptPath))
                { Directory.CreateDirectory(ScriptPath); }

                WinFormConfigurationComponent.CreateFile(
                $"{ScriptPath}{Table.Area}.{Table.Name}_DeleteBy.sql",
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
