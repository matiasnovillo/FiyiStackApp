using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class MSSQLServer
    {
        public static void DeleteField(string ConnectionString, string DataBaseName, string SchemeName, string TableArea, string TableName, string FieldName)
        {
            try
            {
                string NonQuery =
$@"USE [{DataBaseName}]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
ALTER TABLE [{SchemeName}].[{TableArea}.{TableName}] DROP COLUMN {FieldName}";

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
