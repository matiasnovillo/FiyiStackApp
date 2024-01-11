using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FiyiStack.Library.MicrosoftSQLServer
{
    public class Table
    {
        #region Fields
        public string Name { get; set; }
        public string Scheme { get; set; }
        #endregion

        public bool DoesTableExist(string ConnectionString, string TableArea, string TableName, string Scheme)
        {
            try
            {
                bool ExistTable = false;
                DataTable DataTable = new DataTable();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableArea", TableArea, DbType.String, ParameterDirection.Input);
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("Scheme", Scheme, DbType.String, ParameterDirection.Input);

                DataTable = NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(ConnectionString, "[dbo].[CommonFunctions.MSSQLServer.ExistTable]", dp);

                if (DataTable.Rows.Count > 0)
                {
                    ExistTable = Convert.ToInt32(DataTable.Rows[0][0].ToString()) == 0 ? false : true;
                }
                else { throw new Exception("The stored procedure ExistTable does not return anything"); }

                return ExistTable;
            }
            catch (Exception) { throw; }
        }

        public List<Table> GetAllTablesByDataBaseNameToModel(string ConnectionString, string DataBaseName)
        {
            try
            {
                List<Table> lstTable = new List<Table>();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseName", DataBaseName, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    lstTable = (List<Table>)sqlConnection.Query<Table>("[dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstTable;
            }
            catch (Exception) { throw; }
        }
    }
}
