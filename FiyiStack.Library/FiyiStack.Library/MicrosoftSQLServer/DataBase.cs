using System.Data;
using Dapper;

namespace FiyiStack.Library.MicrosoftSQLServer
{
    public class DataBase
    {
        #region Queries
        public bool ExistDataBase(string ConnectionString, string DataBaseName)
        {
            try
            {
                bool ExistDataBase = false;
                DataTable DataTable = new DataTable();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseName", DataBaseName, DbType.String, ParameterDirection.Input);

                DataTable = NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(ConnectionString, "[dbo].[CommonFunctions.MSSQLServer.ExistDataBase]", dp);
                
                if (DataTable.Rows.Count > 0)
                {
                    ExistDataBase = Convert.ToInt32(DataTable.Rows[0][0].ToString()) == 0 ? false : true;
                }
                else { throw new Exception("The stored procedure ExistDataBase does not return anything"); }

                return ExistDataBase;
            }
            catch (Exception) { throw; }
        }

        public string DataBaseVersion(string ConnectionString, string DataBaseName)
        {
            try
            {
                string Version = "";
                DataTable DataTable = new DataTable();

                DynamicParameters dp = new DynamicParameters();

                DataTable = NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(ConnectionString, "[dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]", dp);

                if (DataTable.Rows.Count > 0)
                {
                    Version = DataTable.Rows[0][0].ToString();
                }
                else { throw new Exception("The stored procedure [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion] does not return anything"); }

                return Version;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
