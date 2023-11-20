using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class MSSQLServer
    {
        public static void CreateStoredProcedureSelectAllPaged(GeneratorConfigurationComponent GeneratorConfigurationComponent, string Action, Table Table)
        {
            try
            {
                string Query =   //The USE [Database] statement is not allowed in CREATE/ALTER Procedure statements
$@"CREATE PROCEDURE [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
(
    @QueryString VARCHAR(100),
    @ActualPageNumber INT,
    @RowsPerPage INT,
    @SorterColumn VARCHAR(100),
    @SortToggler TINYINT,
    @TotalRows INT OUTPUT
)

AS

{Security.WaterMark(Security.EWaterMarkFor.MSSQLServer, Constant.FiyiStackGUID.ToString())}

/*Execute this stored procedure with the next script as example

DECLARE	@TotalRows int
EXEC [{Table.Scheme}].[{Table.Area}.{Table.Name}.{Action}]
    
    @QueryString = N'',
    @ActualPageNumber = 1,
    @RowsPerPage = 10,
    @SorterColumn = N'{Table.Name}Id',
    @SortToggler = 0,
    @TotalRows = @TotalRows OUTPUT

SELECT @TotalRows AS N'@TotalRows'
*/

--Last modification on: {DateTime.Now}

SET DATEFORMAT DMY
SET NOCOUNT ON

SELECT
{GeneratorConfigurationComponent.fieldChainer.SQLServerFieldsForSelect_ForSQLServer}
";
                Query = Query.TrimEnd('\n', '\r', ',');

                Query += 
$@"
FROM 
    [{Table.Area}.{Table.Name}]
    LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserCreationId] ON [{Table.Area}.{Table.Name}].[UserCreationId] = [CMSCore.User.UserCreationId].[UserId]
	LEFT OUTER JOIN [CMSCore.User] AS [CMSCore.User.UserLastModificationId] ON [{Table.Area}.{Table.Name}].[UserLastModificationId] = [CMSCore.User.UserLastModificationId].[UserId]
WHERE
    1=1
    AND (@QueryString = '' 
        {GeneratorConfigurationComponent.fieldChainer.SQLServerFieldsForWhereClauseSelectAllPaged_ForSQLServer.TrimEnd(' ')}
    )
ORDER BY {GeneratorConfigurationComponent.fieldChainer.SQLServerFieldsForSelectAllPaged_ForSQLServer}
";
                Query = Query.TrimEnd('\n', '\r', ',');

                Query += $@"

OFFSET (@ActualPageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY
SELECT @TotalRows = COUNT(*) FROM [{Table.Area}.{Table.Name}]";

                Query.Replace("\r", "").Replace("\n", "");

                using (SqlConnection sqlConnection = new SqlConnection(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer))
                {
                    var dataReader = sqlConnection.ExecuteReader(Query, commandType: CommandType.Text);
                }

                #region Create script in project folder
                string ScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\SQLScripts\\";
                if (!Directory.Exists(ScriptPath))
                { Directory.CreateDirectory(ScriptPath); }

                WinFormConfigurationComponent.CreateFile(
                $"{ScriptPath}{Table.Area}.{Table.Name}_SelectAllPaged.sql",
                Query,
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
