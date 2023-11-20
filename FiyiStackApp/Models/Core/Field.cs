using Dapper;
using FiyiStackApp.Models.Tools;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FiyiStackApp.Models.Core
{
    public partial class Field
    {
        #region Fields
        public int FieldId { get; set; }

        public int TableId { get; set; }

        public int DataTypeId { get; set; }

        public string Name { get; set; }

        public bool Nullable { get; set; }

        public string HistoryUser { get; set; }

        public string Regex { get; set; }

        public string MinValue { get; set; }

        public string MaxValue { get; set; }

        public string ForeignTableName { get; set; }

        public bool Active { get; set; }

        public int UserIdCreation { get; set; }

        public int UserIdLastModification { get; set; }

        public DateTime DateTimeCreation { get; set; }

        public DateTime DateTimeLastModification { get; set; }
        #endregion

        #region Constructors
        public Field()
        {
            try { FieldId = 0; }
            catch (Exception ex) { throw ex; }
        }

        public Field(int FieldId)
        {
            try
            {
                List<Field> lstField = new List<Field>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("FieldId", FieldId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstField = (List<Field>)sqlConnection.Query<Field>("[dbo].[Field.GetOneByFieldId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstField.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[Field.GetOneByFieldId] returned more than one register/row");
                }

                foreach (var field in lstField)
                {
                    this.FieldId = field.FieldId;
                    this.TableId = field.TableId;
                    this.DataTypeId = field.DataTypeId;
                    this.Name = field.Name;
                    this.Nullable = field.Nullable;
                    this.HistoryUser = field.HistoryUser;
                    this.Regex = field.Regex;
                    this.MinValue = field.MinValue;
                    this.MaxValue = field.MaxValue;
                    this.ForeignTableName = field.ForeignTableName;
                    this.Active = field.Active;
                    this.UserIdCreation = field.UserIdCreation;
                    this.UserIdLastModification = field.UserIdLastModification;
                    this.DateTimeCreation = field.DateTimeCreation;
                    this.DateTimeLastModification = field.DateTimeLastModification; 
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Queries To Model/List<Model>
        public List<Field> GetAllByTableIdToModel(int TableId)
        {
            try
            {
                List<Field> lstField = new List<Field>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstField = (List<Field>)sqlConnection.Query<Field>("[dbo].[Field.GetAllByTableId]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstField;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Field> GetAllByTableIdByForeignTableNameToModel(int TableId, string ForeignTableName)
        {
            try
            {
                List<Field> lstField = new List<Field>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ForeignTableAreaAndName", ForeignTableName, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstField = (List<Field>)sqlConnection.Query<Field>("[dbo].[Field.GetAllByTableIdByForeignTableAreaAndName]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstField;
            }
            catch (Exception ex) { throw ex; }
        }

        public Field GetOneByTableIdByNameToModel(int TableId, string Name)
        {
            try
            {
                Field Field = new Field();
                List<Field> lstField = new List<Field>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstField = (List<Field>)sqlConnection.Query<Field>("[dbo].[Field.GetOneByTableIdByName]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstField.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[Field.GetOneByTableIdByName] returned more than one register/row");
                }

                foreach (var field in lstField)
                {
                    Field.FieldId = field.FieldId;
                    Field.TableId = field.TableId;
                    Field.DataTypeId = field.DataTypeId;
                    Field.Name = field.Name;
                    Field.Nullable = field.Nullable;
                    Field.Regex = field.Regex;
                    Field.MinValue = field.MinValue;
                    Field.MaxValue = field.MaxValue;
                    Field.ForeignTableName = field.ForeignTableName;
                    Field.HistoryUser = field.HistoryUser;
                    Field.Active = field.Active;
                    Field.UserIdCreation = field.UserIdCreation;
                    Field.UserIdLastModification = field.UserIdLastModification;
                    Field.DateTimeCreation = field.DateTimeCreation;
                    Field.DateTimeLastModification = field.DateTimeLastModification;
                }

                return Field;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Non-Queries
        /// <summary>
        /// 
        /// </summary>
        /// <returns>MaxId</returns>
        public int Add()
        {
            try
            {
                int MaxId;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);
                dp.Add("DataTypeId", DataTypeId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("Nullable", Nullable, DbType.Boolean, ParameterDirection.Input);
                dp.Add("Regex", Regex, DbType.String, ParameterDirection.Input);
                dp.Add("MaxValue", MaxValue, DbType.String, ParameterDirection.Input);
                dp.Add("ForeignTableName", ForeignTableName, DbType.String, ParameterDirection.Input);
                dp.Add("MinValue", MinValue, DbType.String, ParameterDirection.Input);
                dp.Add("HistoryUser", HistoryUser, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Field.Add]", 
                    dp);

                if (DataTable.Rows.Count > 0)
                {
                    MaxId = Convert.ToInt32(DataTable.Rows[0][0].ToString());
                }
                else
                {
                    throw new Exception("MaxId with no value");
                }

                return MaxId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>RowsAffected</returns>
        public int UpdateByFieldId()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("FieldId", FieldId, DbType.Int32, ParameterDirection.Input);
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);
                dp.Add("DataTypeId", DataTypeId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("Nullable", Nullable, DbType.Boolean, ParameterDirection.Input);
                dp.Add("Regex", Regex, DbType.String, ParameterDirection.Input);
                dp.Add("MinValue", MinValue, DbType.String, ParameterDirection.Input);
                dp.Add("MaxValue", MaxValue, DbType.String, ParameterDirection.Input);
                dp.Add("ForeignTableName", ForeignTableName, DbType.String, ParameterDirection.Input);
                dp.Add("HistoryUser", HistoryUser, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Field.UpdateByFieldId]", 
                    dp);

                if (DataTable.Rows.Count > 0)
                {
                    RowsAffected = Convert.ToInt32(DataTable.Rows[0][0].ToString());
                }
                else
                {
                    throw new Exception("RowsAffected with no value");
                }

                return RowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>RowsAffected</returns>
        public int DeleteByFieldId(int FieldId)
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("FieldId", FieldId, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Field.DeleteByFieldId]", 
                    dp);

                if (DataTable.Rows.Count > 0)
                {
                    RowsAffected = Convert.ToInt32(DataTable.Rows[0][0].ToString());
                }
                else
                {
                    throw new Exception("RowsAffected with no value");
                }

                return RowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>RowsAffected</returns>
        public int DeleteByTableId(int TableId)
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Field.DeleteByTableId]", 
                    dp);

                if (DataTable.Rows.Count > 0)
                {
                    RowsAffected = Convert.ToInt32(DataTable.Rows[0][0].ToString());
                }
                else
                {
                    throw new Exception("RowsAffected with no value");
                }

                return RowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public override string ToString()
        {
            return $"FieldId: {FieldId}, " +
                $"TableId: {TableId}, " +
                $"Name: {Name}, " +
                $"Nullable: {Nullable}, " +
                $"DataTypeId: {DataTypeId}, " +
                $"Active: {Active}, " +
                $"UserIdCreation: {UserIdCreation}, " +
                $"UserIdLastModification: {UserIdLastModification}, " +
                $"DateTimeCreation: {DateTimeCreation}, " +
                $"DateTimeLastModification: {DateTimeLastModification}";
        }
    }
}
