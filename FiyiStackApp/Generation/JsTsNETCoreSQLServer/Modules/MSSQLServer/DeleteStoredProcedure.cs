using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class MSSQLServer
    {
        public static void DeleteStoredProcedure(string ConnectionString, string DataBaseName, string SchemeName, string TableArea, string TableName, string Action)
        {
            try
            {
                string NonQuery =
                    $"USE [{DataBaseName}] " +
                    $"DROP PROCEDURE [{SchemeName}].[{TableArea}.{TableName}.{Action}]";

                NonQuery.Replace("\r", "").Replace("\n", "");

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var dataReader = sqlConnection.ExecuteReader(NonQuery, commandType: CommandType.Text);
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
