using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FiyiStack.Library.MicrosoftSQLServer
{
    public class StoredProcedure
    {
        #region Fields
        public string TableArea { get; set; }

        public string TableName { get; set; }

        public string SchemeName { get; set; }

        public string Action { get; set; }

        public string Content { get; set; }
        #endregion

        #region Queries
        /// <summary>
        /// <c>IsFiyiStackSP = true</c> for stored procedures like this [Scheme].[Table.Action] <br/>
        /// <c>IsFiyiStackSP = false</c> for stored procedures like this [Scheme].[Action] <br/>
        /// </summary>
        /// <returns></returns>
        public bool ExistStoredProcedure(string ConnectionString, string DataBaseName, string SchemeName, string TableArea, string TableName, string Action, bool IsFiyiStackSP)
        {
            try
            {
                bool ExistStoredProcedure = false;
                DataTable DataTable = new DataTable();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseName", DataBaseName, DbType.String, ParameterDirection.Input);
                dp.Add("SchemeName", SchemeName, DbType.String, ParameterDirection.Input);
                dp.Add("TableArea", TableArea, DbType.String, ParameterDirection.Input);
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("Action", Action, DbType.String, ParameterDirection.Input);
                dp.Add("IsFiyiStackSP", IsFiyiStackSP, DbType.Boolean, ParameterDirection.Input);

                DataTable = NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(ConnectionString, "[dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]", dp);

                if (DataTable.Rows.Count > 0)
                {
                    ExistStoredProcedure = Convert.ToInt32(DataTable.Rows[0][0].ToString()) == 0 ? false : true;
                }
                else { throw new Exception("The stored procedure ExistFiyiStackStoredProcedure does not return anything"); }

                return ExistStoredProcedure;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Queries To Model/List<Model>
        public StoredProcedure GetOneStoredProcedureByDataBaseNameBySchemeNameByNameToModel(string ConnectionString, string DataBaseName, string SchemeName, string TableArea, string TableName, string Action)
        {
            try
            {
                StoredProcedure StoredProcedure = new StoredProcedure();
                List<StoredProcedure> lstStoredProcedure = new List<StoredProcedure>();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseName", DataBaseName, DbType.String, ParameterDirection.Input);
                dp.Add("SchemeName", SchemeName, DbType.String, ParameterDirection.Input);
                dp.Add("TableArea", TableArea, DbType.String, ParameterDirection.Input);
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("Action", Action, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    lstStoredProcedure = (List<StoredProcedure>)sqlConnection.Query<StoredProcedure>("[dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstStoredProcedure.Count > 1)
                {
                    throw new Exception("The stored procedure returned more than one register/row");
                }

                foreach (StoredProcedure storedProcedure in lstStoredProcedure)
                {
                    StoredProcedure.TableName = storedProcedure.TableName;
                    StoredProcedure.SchemeName = storedProcedure.SchemeName;
                    StoredProcedure.Action = storedProcedure.Action;
                    StoredProcedure.Content = storedProcedure.Content;
                }

                return StoredProcedure;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
