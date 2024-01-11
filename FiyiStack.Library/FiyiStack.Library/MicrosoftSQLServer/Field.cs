using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FiyiStack.Library.MicrosoftSQLServer
{
    public class Field
    {
        #region Fields
        public string Name { get; set; }

        public string DataTypeName { get; set; }

        public bool Nullable { get; set; }
        #endregion

        #region Queries
        public bool DoesFieldExist(string ConnectionString, string TableArea, string TableName, string SchemeName, string FieldName)
        {
            try
            {
                bool ExistField = false;
                DataTable DataTable = new DataTable();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableArea", TableArea, DbType.String, ParameterDirection.Input);
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("SchemeName", SchemeName, DbType.String, ParameterDirection.Input);
                dp.Add("FieldName", FieldName, DbType.String, ParameterDirection.Input);

                DataTable = NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(ConnectionString, "[dbo].[CommonFunctions.MSSQLServer.ExistField]", dp);

                if (DataTable.Rows.Count > 0)
                {
                    ExistField = Convert.ToInt32(DataTable.Rows[0][0].ToString()) == 0 ? false : true;
                }
                else { throw new Exception("The stored procedure [dbo].[CommonFunctions.MSSQLServer.ExistField] does not return anything"); }

                return ExistField;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Queries To Model/List<Model>
        public List<Field> GetAllFieldsByTableNameBySchemeNameToModel(string ConnectionString, string TableName, string SchemeName)
        {
            try
            {
                List<Field> lstField = new List<Field>();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("SchemeName", SchemeName, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    lstField = (List<Field>)sqlConnection.Query<Field>("[dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstField;
            }
            catch (Exception) { throw; }
        }

        public Field GetOneFieldByTableNameBySchemeNameByFieldNameToModel(string ConnectionString, string TableName, string SchemeName, string FieldName)
        {
            try
            {
                Field Field = new Field();
                List<Field> lstField = new List<Field>();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("SchemeName", SchemeName, DbType.String, ParameterDirection.Input);
                dp.Add("FieldName", FieldName, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    lstField = (List<Field>)sqlConnection.Query<Field>("[dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstField.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName] returned more than one register/row");
                }

                foreach (Field field in lstField)
                {
                    Field.Name = field.Name;
                    Field.DataTypeName = field.DataTypeName;
                    Field.Nullable = field.Nullable;
                }

                return Field;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
