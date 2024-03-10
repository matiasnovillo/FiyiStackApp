using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FiyiStackApp.Generation.CommonGenerators.Modules.MSSQLServer
{
    public static partial class MSSQLServer
    {
        public static void DeleteTable(string ConnectionString, string DataBaseName, string SchemeName, string TableName)
        {
            try
            {
                string NonQuery =
                    $"USE [{DataBaseName}] " +
                    $"DROP TABLE [{SchemeName}].[{TableName}]";

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
