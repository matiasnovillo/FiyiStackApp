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

        public bool WantCSharpModelsWithSPs { get; set; }

        public bool WantCSharpDTOs { get; set; }

        public bool WantCSharpFilters { get; set; }

        public bool WantCSharpInterfaces { get; set; }

        public bool WantCSharpServices { get; set; }

        public bool WantCSharpRazorPages { get; set; }

        public bool WantCSharpWebAPIs { get; set; }

        public bool WantTypeScriptModels { get; set; }

        public bool WantTypeScriptDTOs { get; set; }

        public bool WantjQueryDOMManipulator { get; set; }

        //For NET6CleanArchitecture
        public bool WantBackendAPI { get; set; }

        public bool WantBackendAPINodeJsExpressMongoDB { get; set; }

        public bool WantNET8MSSQLServerAPI { get; set; }

        public bool WantNET8BlazorMSSQLServerCodeFirst { get; set; }
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
                dp.Add("WantCSharpModelsWithSPs", WantCSharpModelsWithSPs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpDTOs", WantCSharpDTOs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpFilters", WantCSharpFilters, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpInterfaces", WantCSharpInterfaces, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpServices", WantCSharpServices, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpRazorPages", WantCSharpRazorPages, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpWebAPIs", WantCSharpWebAPIs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantTypeScriptModels", WantTypeScriptModels, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantTypeScriptDTOs", WantTypeScriptDTOs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantjQueryDOMManipulator", WantjQueryDOMManipulator, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantBackendAPI", WantBackendAPI, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantBackendAPINodeJsExpressMongoDB", WantBackendAPINodeJsExpressMongoDB, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantNET8MSSQLServerAPI", WantNET8MSSQLServerAPI, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantNET8BlazorMSSQLServerCodeFirst", WantNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);

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
                dp.Add("WantCSharpModelsWithSPs", WantCSharpModelsWithSPs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpDTOs", WantCSharpDTOs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpFilters", WantCSharpFilters, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpInterfaces", WantCSharpInterfaces, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpServices", WantCSharpServices, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpRazorPages", WantCSharpRazorPages, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantCSharpWebAPIs", WantCSharpWebAPIs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantTypeScriptModels", WantTypeScriptModels, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantTypeScriptDTOs", WantTypeScriptDTOs, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantjQueryDOMManipulator", WantjQueryDOMManipulator, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantBackendAPI", WantBackendAPI, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantBackendAPINodeJsExpressMongoDB", WantBackendAPINodeJsExpressMongoDB, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantNET8MSSQLServerAPI", WantNET8MSSQLServerAPI, DbType.Boolean, ParameterDirection.Input);
                dp.Add("WantNET8BlazorMSSQLServerCodeFirst", WantNET8BlazorMSSQLServerCodeFirst, DbType.Boolean, ParameterDirection.Input);

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
                    Configuration.WantCSharpModelsWithSPs = configuration.WantCSharpModelsWithSPs;
                    Configuration.WantCSharpDTOs = configuration.WantCSharpDTOs;
                    Configuration.WantCSharpFilters = configuration.WantCSharpFilters;
                    Configuration.WantCSharpInterfaces = configuration.WantCSharpInterfaces;
                    Configuration.WantCSharpServices = configuration.WantCSharpServices;
                    Configuration.WantCSharpRazorPages = configuration.WantCSharpRazorPages;
                    Configuration.WantCSharpWebAPIs = configuration.WantCSharpWebAPIs;
                    Configuration.WantTypeScriptModels = configuration.WantTypeScriptModels;
                    Configuration.WantTypeScriptDTOs = configuration.WantTypeScriptDTOs;
                    Configuration.WantjQueryDOMManipulator = configuration.WantjQueryDOMManipulator;
                    Configuration.WantBackendAPI = configuration.WantBackendAPI;
                    Configuration.WantBackendAPINodeJsExpressMongoDB = configuration.WantBackendAPINodeJsExpressMongoDB;
                    Configuration.WantNET8MSSQLServerAPI = configuration.WantNET8MSSQLServerAPI;
                    Configuration.WantNET8BlazorMSSQLServerCodeFirst = configuration.WantNET8BlazorMSSQLServerCodeFirst;
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
                $"WantCSharpModelsWithSPs: {WantCSharpModelsWithSPs}, " +
                $"WantCSharpDTOs: {WantCSharpDTOs}, " +
                $"WantCSharpFilters: {WantCSharpFilters}, " +
                $"WantCSharpInterfaces: {WantCSharpInterfaces}, " +
                $"WantCSharpServices: {WantCSharpServices}, " +
                $"WantCSharpRazorPages: {WantCSharpRazorPages}, " +
                $"WantCSharpWebAPIs: {WantCSharpWebAPIs}, " +
                $"WantTypeScriptModels: {WantTypeScriptModels}, " +
                $"WantTypeScriptDTOs: {WantTypeScriptDTOs}, " +
                $"WantjQueryDOMManipulator: {WantjQueryDOMManipulator}, " +
                $"WantBackendAPINodeJsExpressMongoDB: {WantBackendAPINodeJsExpressMongoDB}, " +
                $"WantNET8MSSQLServerAPI: {WantNET8MSSQLServerAPI}, " +
                $"WantNET8BlazorMSSQLServerCodeFirst: {WantNET8BlazorMSSQLServerCodeFirst}, " +
                $"WantBackendAPI:WantBackendAPI {WantBackendAPI}";
        }
    }
}