using Dapper;
using FiyiStackApp.Models.Tools;
using Microsoft.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace FiyiStackApp.Models.Core
{
    public partial class Table
    {
        #region Fields
        public int TableId { get; set; }

        public int DataBaseId { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Name of the table")]
        public string Name { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Scheme of the table. dbo is preferred")]
        public string Scheme { get; set; }

        public bool Active { get; set; }

        public int UserIdCreation { get; set; }

        public int UserIdLastModification { get; set; }

        public DateTime DateTimeCreation { get; set; }

        public DateTime DateTimeLastModification { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Area of the table")]
        public string Area { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Version of the table")]
        public string Version { get; set; }
        #endregion

        #region Constructors
        public Table()
        {
            try
            { TableId = 0; }
            catch (Exception ex) { throw ex; }
        }

        public Table(int TableId)
        {
            try
            {
                List<Table> _lst = new List<Table>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    _lst = (List<Table>)sqlConnection.Query<Table>("[dbo].[Table.GetOneByTableId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (_lst.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[Table.GetOneByTableId] returned more than one register/row");
                }

                foreach (var field in _lst)
                {
                    this.TableId = field.TableId;
                    DataBaseId = field.DataBaseId;
                    Name = field.Name;
                    Scheme = field.Scheme;
                    Active = field.Active;
                    DateTimeCreation = field.DateTimeCreation;
                    DateTimeLastModification = field.DateTimeLastModification;
                    UserIdCreation = field.UserIdCreation;
                    UserIdLastModification = field.UserIdLastModification;
                    Area = field.Area;
                    Version = field.Version;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Table(int DataBaseId, string Area, string Name, string Scheme)
        {
            try
            {
                List<Table> lstTable = new List<Table>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Area", Area, DbType.String, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("Scheme", Scheme, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstTable = (List<Table>)sqlConnection.Query<Table>("[dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstTable.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme] returned more than one register/row");
                }

                foreach (var field in lstTable)
                {
                    this.TableId = field.TableId;
                    this.DataBaseId = field.DataBaseId;
                    this.Name = field.Name;
                    this.Scheme = field.Scheme;
                    this.Active = field.Active;
                    this.DateTimeCreation = field.DateTimeCreation;
                    this.DateTimeLastModification = field.DateTimeLastModification;
                    this.UserIdCreation = field.UserIdCreation;
                    this.UserIdLastModification = field.UserIdLastModification;
                    this.Area = field.Area;
                    this.Version = field.Version;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Queries To Model/List<Model>
        public List<Table> GetAllByDataBaseIdToModel(int DataBaseId)
        {
            try
            {
                List<Table> lstTable = new List<Table>();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstTable = (List<Table>)sqlConnection.Query<Table>("[dbo].[Table.GetAllByDataBaseId]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public Table GetOneByDataBaseIdByNameBySchemeToModel(int DataBaseId, string Area, string Name, string Scheme)
        {
            try
            {
                Table Table = new Table();
                List<Table> lstTable = new List<Table>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("Area", Area, DbType.String, ParameterDirection.Input);
                dp.Add("Scheme", Scheme, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstTable = (List<Table>)sqlConnection.Query<Table>("[dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstTable.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme] returned more than one register/row");
                }

                foreach (var field in lstTable)
                {
                    Table.TableId = field.TableId;
                    Table.DataBaseId = field.DataBaseId;
                    Table.Name = field.Name;
                    Table.Scheme = field.Scheme;
                    Table.Active = field.Active;
                    Table.UserIdCreation = field.UserIdCreation;
                    Table.UserIdLastModification = field.UserIdLastModification;
                    Table.DateTimeCreation = field.DateTimeCreation;
                    Table.DateTimeLastModification = field.DateTimeLastModification;
                    Table.Area = field.Area;
                    Table.Version = field.Version;
                }

                return Table;
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
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("Scheme", Scheme, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);
                dp.Add("Area", Area, DbType.String, ParameterDirection.Input);
                dp.Add("Version", Version, DbType.String, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Table.Add]",
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
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>RowsAffected</returns>
        public int UpdateByTableId()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableId", TableId, DbType.Int32, ParameterDirection.Input);
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("Scheme", Scheme, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);
                dp.Add("Area", Area, DbType.String, ParameterDirection.Input);
                dp.Add("Version", Version, DbType.String, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Table.UpdateByTableId]", 
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
                    "[dbo].[Table.DeleteByTableId]", 
                    dp);

                if (DataTable.Rows.Count > 0) { RowsAffected = Convert.ToInt32(DataTable.Rows[0][0].ToString()); }
                else { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>RowsAffected</returns>
        public int DeleteByDataBaseId(int DataBaseId)
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("DataBaseId", DataBaseId, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Table.DeleteByDataBaseId]", 
                    dp);

                if (DataTable.Rows.Count > 0) { RowsAffected = Convert.ToInt32(DataTable.Rows[0][0].ToString()); }
                else { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        public override string ToString()
        {
            return $"TableId: {TableId}, " +
                $"DataBaseId: {DataBaseId}, " +
                $"Name: {Name}, " +
                $"Scheme: {Scheme}, " +
                $"Area: {Area}, " +
                $"Version: {Version}, " +
                $"Active: {Active}, " +
                $"UserIdCreation: {UserIdCreation}, " +
                $"UserIdLastModification: {UserIdLastModification}, " +
                $"DateTimeCreation: {DateTimeCreation}, " +
                $"DateTimeLastModification: {DateTimeLastModification}";
        }
    }
}
