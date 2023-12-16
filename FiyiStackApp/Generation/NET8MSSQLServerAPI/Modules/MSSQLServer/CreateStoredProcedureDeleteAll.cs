using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules
{
    public static partial class MSSQLServer
    {
        public static void CreateStoredProcedureDeleteAll(GeneratorConfigurationComponent GeneratorConfigurationComponent, string Action, Table Table)
        {
            try
            {
                string NonQuery =   //The USE [Database] statement is not allowed in CREATE/ALTER Procedure statements
$@"CREATE PROCEDURE [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]

AS

{Security.WaterMark(Security.EWaterMarkFor.MSSQLServer, Constant.FiyiStackGUID.ToString())}

/*
 * Execute this stored procedure with the next script as example
 *
EXEC [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
 *
 */

--Last modification on: {DateTime.Now}

DELETE FROM [{Table.Area}.{Table.Name}]";

                NonQuery.Replace("\r", "").Replace("\n", "");;

                using (SqlConnection sqlConnection = new SqlConnection(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer))
                {
                    var dataReader = sqlConnection.ExecuteReader(NonQuery, commandType: CommandType.Text);
                }

                #region Create script in project folder
                string ScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\SQLScripts\\";
                if (!Directory.Exists(ScriptPath))
                { Directory.CreateDirectory(ScriptPath); }

                WinFormConfigurationComponent.CreateFile(
                $"{ScriptPath}{Table.Area}.{Table.Name}_DeleteAll.sql",
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
