using Dapper;
using FiyiStackApp.Models.Tools;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FiyiStackApp.Models.Core
{
    public partial class Configuration
    {
        #region Fields
        public int ConfigurationId { get; set; }

        public bool Active { get; set; }

        public DateTime DateTimeCreation { get; set; }

        public DateTime DateTimeLastModification { get; set; }

        public int UserCreationId { get; set; }

        public int UserLastModificationId { get; set; }

        public int ProjectId { get; set; }

        public bool AddAuditingFieldsToNewTable { get; set; }

        public bool DeleteTable { get; set; }

        public bool DeleteField { get; set; }

        public bool DeleteStoredProcedure { get; set; }

        public bool DeleteFiles { get; set; }

        public int TemplateId { get; set; }

        public bool WantDTONET8BlazorMSSQLServerCodeFirst { get; set; }

        public bool WantEntityNET8BlazorMSSQLServerCodeFirst { get; set; }

        public bool WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst { get; set; }
        
        public bool WantInterfaceNET8BlazorMSSQLServerCodeFirst { get; set; }

        public bool WantRepositoryNET8BlazorMSSQLServerCodeFirst { get; set; }

        public  bool WantBlazorPageNET8BlazorMSSQLServerCodeFirst { get; set; }

        public bool WantServiceNET8BlazorMSSQLServerCodeFirst { get; set; }
        #endregion

        #region Constructors of Configuration
        public Configuration()
        {
            try { ConfigurationId = 0; }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        public int Add()
        {
            try
            {
                int MaxId;
                DynamicParameters dp = new DynamicParameters();

                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("AddAuditingFieldsToNewTable", AddAuditingFieldsToNewTable, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteTable", DeleteTable, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteField", DeleteField, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteStoredProcedure", DeleteStoredProcedure, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteFiles", DeleteFiles, DbType.Boolean, ParameterDirection.Input);
                dp.Add("TemplateId", TemplateId, DbType.Int32, ParameterDirection.Input);
                dp.Add("WantDTONET8BlazorMSSQLServerCodeFirst", WantDTONET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantEntityNET8BlazorMSSQLServerCodeFirst", WantEntityNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst", WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantInterfaceNET8BlazorMSSQLServerCodeFirst", WantInterfaceNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantRepositoryNET8BlazorMSSQLServerCodeFirst", WantRepositoryNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantBlazorPageNET8BlazorMSSQLServerCodeFirst", WantBlazorPageNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantServiceNET8BlazorMSSQLServerCodeFirst", WantServiceNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction,
                    "[dbo].[Configuration.Add]", 
                    dp);

                if (DataTable.Rows.Count > 0) { MaxId = Convert.ToInt32(DataTable.Rows[0][0].ToString()); }
                else { throw new Exception("MaxId with no value"); }

                return MaxId;
            }
            catch (Exception ex) { throw ex; }
        }

        public int UpdateByConfigurationId()
        {
            try
            {
                int RowsAffected;
                DynamicParameters dp = new DynamicParameters();

                dp.Add("ConfigurationId", ConfigurationId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("AddAuditingFieldsToNewTable", AddAuditingFieldsToNewTable, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteTable", DeleteTable, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteField", DeleteField, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteStoredProcedure", DeleteStoredProcedure, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DeleteFiles", DeleteFiles, DbType.Boolean, ParameterDirection.Input);
                dp.Add("TemplateId", TemplateId, DbType.Int32, ParameterDirection.Input);
                dp.Add("WantDTONET8BlazorMSSQLServerCodeFirst", WantDTONET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantEntityNET8BlazorMSSQLServerCodeFirst", WantEntityNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst", WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantInterfaceNET8BlazorMSSQLServerCodeFirst", WantInterfaceNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantRepositoryNET8BlazorMSSQLServerCodeFirst", WantRepositoryNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantBlazorPageNET8BlazorMSSQLServerCodeFirst", WantBlazorPageNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantServiceNET8BlazorMSSQLServerCodeFirst", WantServiceNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Configuration.UpdateByConfigurationId]", 
                    dp);

                if (DataTable.Rows.Count > 0) { RowsAffected = Convert.ToInt32(DataTable.Rows[0][0].ToString()); }
                else { throw new Exception("RowsAffected with no value"); }

                return RowsAffected;
            }
            catch (Exception ex) { throw ex; }
        }

        public Configuration GetOneByProjectIdToModel(int ProjectId)
        {
            try
            {
                Configuration Configuration = new Configuration();
                List<Configuration> lstConfiguration = new List<Configuration>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    //In case of not finding anything, Dapper return a List<Configuration>
                    lstConfiguration = (List<Configuration>)sqlConnection.Query<Configuration>("[dbo].[Configuration.GetOneByProjectId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstConfiguration.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[Configuration.GetOneByProjectId] returned more than one register/row");
                }

                foreach (Configuration configuration in lstConfiguration)
                {
                    Configuration.ConfigurationId = configuration.ConfigurationId;
                    Configuration.Active = configuration.Active;
                    Configuration.DateTimeCreation = configuration.DateTimeCreation;
                    Configuration.DateTimeLastModification = configuration.DateTimeLastModification;
                    Configuration.UserCreationId = configuration.UserCreationId;
                    Configuration.UserLastModificationId = configuration.UserLastModificationId;
                    Configuration.ProjectId = configuration.ProjectId;
                    Configuration.AddAuditingFieldsToNewTable = configuration.AddAuditingFieldsToNewTable;
                    Configuration.DeleteTable = configuration.DeleteTable;
                    Configuration.DeleteField = configuration.DeleteField;
                    Configuration.DeleteStoredProcedure = configuration.DeleteStoredProcedure;
                    Configuration.DeleteFiles = configuration.DeleteFiles;
                    Configuration.TemplateId = configuration.TemplateId;
                    Configuration.WantDTONET8BlazorMSSQLServerCodeFirst = configuration.WantDTONET8BlazorMSSQLServerCodeFirst;
                    Configuration.WantEntityNET8BlazorMSSQLServerCodeFirst = configuration.WantEntityNET8BlazorMSSQLServerCodeFirst;
                    Configuration.WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst = configuration.WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst;
                    Configuration.WantInterfaceNET8BlazorMSSQLServerCodeFirst = configuration.WantInterfaceNET8BlazorMSSQLServerCodeFirst;
                    Configuration.WantRepositoryNET8BlazorMSSQLServerCodeFirst = configuration.WantRepositoryNET8BlazorMSSQLServerCodeFirst;
                    Configuration.WantBlazorPageNET8BlazorMSSQLServerCodeFirst = configuration.WantBlazorPageNET8BlazorMSSQLServerCodeFirst;
                    Configuration.WantServiceNET8BlazorMSSQLServerCodeFirst = configuration.WantServiceNET8BlazorMSSQLServerCodeFirst;
                }

                return Configuration;
            }
            catch (Exception ex) { throw ex; }
        }

        public override string ToString()
        {
            return $"ConfigurationId: {ConfigurationId}, " +
                $"ProjectId: {ProjectId}, " +
                $"UserCreationId: {UserCreationId}, " +
                $"UserLastModificationId: {UserLastModificationId}, " +
                $"DateTimeCreation: {DateTimeCreation}, " +
                $"DateTimeLastModification: {DateTimeLastModification}, " +
                $"Active: {Active}, " +
                $"AddAuditingFieldsToNewTable: {AddAuditingFieldsToNewTable}, " +
                $"DeleteTable: {DeleteTable}, " +
                $"DeleteField: {DeleteField}, " +
                $"DeleteStoredProcedure: {DeleteStoredProcedure}, " +
                $"DeleteFiles: {DeleteFiles}, " +
                $"TemplateId: {TemplateId}, " +
                $"WantDTONET8BlazorMSSQLServerCodeFirst: {WantDTONET8BlazorMSSQLServerCodeFirst}, " +
                $"WantEntityNET8BlazorMSSQLServerCodeFirst: {WantEntityNET8BlazorMSSQLServerCodeFirst}, " +
                $"WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst: {WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst}, " +
                $"WantInterfaceNET8BlazorMSSQLServerCodeFirst: {WantInterfaceNET8BlazorMSSQLServerCodeFirst}, " +
                $"WantRepositoryNET8BlazorMSSQLServerCodeFirst: {WantRepositoryNET8BlazorMSSQLServerCodeFirst}, " +
                $"WantBlazorPageNET8BlazorMSSQLServerCodeFirst: {WantBlazorPageNET8BlazorMSSQLServerCodeFirst}, " +
                $"WantServiceNET8BlazorMSSQLServerCodeFirst: {WantServiceNET8BlazorMSSQLServerCodeFirst}";
        }
    }
}