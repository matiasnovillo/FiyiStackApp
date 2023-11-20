using Dapper;
using FiyiStackApp.Models.Tools;
using Microsoft.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace FiyiStackApp.Models.Core
{
    public class DataBase
    {
        #region Fields
        public int DataBaseId { get; set; }

        public int ProjectId { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Name of the database")]
        public string Name { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Generate in Microsoft SQL Server")]
        public bool IsMSSQLServer { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Connection string for MS SQL Server database")]
        public string ConnectionStringForMSSQLServer { get; set; }

        public bool Active { get; set; }

        public int UserIdCreation { get; set; }

        public int UserIdLastModification { get; set; }

        public DateTime DateTimeCreation { get; set; }

        public DateTime DateTimeLastModification { get; set; }
        #endregion

        #region Constructors
        public DataBase()
        {
            try { DataBaseId = 0; }
            catch (Exception ex) { throw ex; }
        }

        public DataBase(int DataBaseId)
        {
            try
            {
                DataBase DataBase = new DataBase();
                List<DataBase> lstDataBase = new List<DataBase>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstDataBase = (List<DataBase>)sqlConnection.Query<DataBase>("[dbo].[DataBase.GetOneByDataBaseId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstDataBase.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[DataBase.GetOneByDataBaseId] returned more than one register/row");
                }

                foreach (var field in lstDataBase)
                {
                    this.DataBaseId = field.DataBaseId;
                    this.ProjectId = field.ProjectId;
                    this.Name = field.Name;
                    this.IsMSSQLServer = field.IsMSSQLServer;
                    this.ConnectionStringForMSSQLServer = field.ConnectionStringForMSSQLServer;
                    this.Active = field.Active;
                    this.DateTimeCreation = field.DateTimeCreation;
                    this.DateTimeLastModification = field.DateTimeLastModification;
                    this.UserIdCreation = field.UserIdCreation;
                    this.UserIdLastModification = field.UserIdLastModification;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public DataBase(int ProjectId, string Name)
        {
            try
            {
                DataBase DataBase = new DataBase();
                List<DataBase> lstDataBase = new List<DataBase>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstDataBase = (List<DataBase>)sqlConnection.Query<DataBase>("[dbo].[DataBase.GetOneByProjectIdByName]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstDataBase.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[DataBase.GetOneByProjectIdByName] returned more than one register/row");
                }

                foreach (var field in lstDataBase)
                {
                    this.DataBaseId = field.DataBaseId;
                    this.ProjectId = field.ProjectId;
                    this.Name = field.Name;
                    this.IsMSSQLServer = field.IsMSSQLServer;
                    this.ConnectionStringForMSSQLServer = field.ConnectionStringForMSSQLServer;
                    this.Active = field.Active;
                    this.DateTimeCreation = field.DateTimeCreation;
                    this.DateTimeLastModification = field.DateTimeLastModification;
                    this.UserIdCreation = field.UserIdCreation;
                    this.UserIdLastModification = field.UserIdLastModification;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Queries To Model/List<Model>
        public List<DataBase> GetAllByProjectIdToModel(int ProjectId)
        {
            try
            {
                List<DataBase> lstDataBase = new List<DataBase>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstDataBase = (List<DataBase>)sqlConnection.Query<DataBase>("[dbo].[DataBase.GetAllByProjectId]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstDataBase;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataBase GetOneByProjectIdByNameToModel(int ProjectId, string Name)
        {
            try
            {
                DataBase DataBase = new DataBase();
                List<DataBase> lstDataBase = new List<DataBase>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstDataBase = (List<DataBase>)sqlConnection.Query<DataBase>("[dbo].[DataBase.GetOneByProjectIdByName]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstDataBase.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[DataBase.GetOneByProjectIdByName] returned more than one register/row");
                }

                foreach (var field in lstDataBase)
                {
                    DataBase.DataBaseId = field.DataBaseId;
                    DataBase.ProjectId = field.ProjectId;
                    DataBase.Name = field.Name;
                    DataBase.IsMSSQLServer = field.IsMSSQLServer;
                    DataBase.ConnectionStringForMSSQLServer = field.ConnectionStringForMSSQLServer;
                    DataBase.Active = field.Active;
                    DataBase.DateTimeCreation = field.DateTimeCreation;
                    DataBase.DateTimeLastModification = field.DateTimeLastModification;
                    DataBase.UserIdCreation = field.UserIdCreation;
                    DataBase.UserIdLastModification = field.UserIdLastModification;
                }

                return DataBase;
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
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("IsMSSQLServer", IsMSSQLServer, DbType.Boolean, ParameterDirection.Input);
                dp.Add("ConnectionStringForMSSQLServer", ConnectionStringForMSSQLServer, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction,
                    "[dbo].[DataBase.Add]", 
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
        public int UpdateByDataBaseId()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("IsMSSQLServer", IsMSSQLServer, DbType.Boolean, ParameterDirection.Input);
                dp.Add("ConnectionStringForMSSQLServer", ConnectionStringForMSSQLServer, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[DataBase.UpdateByDataBaseId]", 
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
        public int DeleteByDataBaseId()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[DataBase.DeleteByDataBaseId]", 
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
            catch (Exception ex) { throw ex; }
        }
        #endregion

        public override string ToString()
        {
            return $"DataBaseId: {DataBaseId}, " +
                $"ProjectId: {ProjectId}, " +
                $"Name: {Name}, " +
                $"IsMSSQLServer: {IsMSSQLServer}, " +
                $"ConnectionStringForMSSQLServer: {ConnectionStringForMSSQLServer}, " +
                $"Active: {Active}, " +
                $"DateTimeCreation: {DateTimeCreation}, " +
                $"DateTimeLastModification: {DateTimeLastModification}, " +
                $"UserIdCreation: {UserIdCreation}, " +
                $"UserIdLastModification: {UserIdLastModification}";
        }
    }
}
