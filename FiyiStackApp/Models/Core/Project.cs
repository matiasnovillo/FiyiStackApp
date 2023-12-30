using Dapper;
using FiyiStackApp.Models.Tools;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;

namespace FiyiStackApp.Models.Core
{
    public partial class Project
    {
        #region Fields
        public int ProjectId { get; set; }
        
        [CategoryAttribute("Settings"), DescriptionAttribute("Project name")]
        public string Name { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("History user")]
        public string GeneralHistoryUser { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Path to JsTsNETCoreSQLServer")]
        public string PathJsTsNETCoreSQLServer { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Path to NET6CleanArchitecture")]
        public string PathNET6CleanArchitecture { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Path to NodeJsExpressMongoDB")]
        public string PathNodeJsExpressMongoDB { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Path to PathNET8MSSQLServerAPI")]
        public string PathNET8MSSQLServerAPI { get; set; }

        [CategoryAttribute("Settings"), DescriptionAttribute("Path to PathNET8BlazorMSSQLServerCodeFirst")]
        public string PathNET8BlazorMSSQLServerCodeFirst { get; set; }

        public bool Active { get; set; }

        public int UserIdCreation { get; set; }

        public int UserIdLastModification { get; set; }

        public DateTime DateTimeCreation { get; set; }

        public DateTime DateTimeLastModification { get; set; }
        #endregion

        #region Constructors
        public Project()
        {
            try { ProjectId = 0; }
            catch (Exception ex) { throw ex; }
        }

        public Project(int ProjectId)
        {
            try
            {
                List<Project> lstProject = new List<Project>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstProject = (List<Project>)sqlConnection.Query<Project>("[dbo].[Project.GetOneByProjectId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstProject.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[Project.GetOneByProjectId] returned more than one register/row");
                }

                foreach (var field in lstProject)
                {
                    this.ProjectId = field.ProjectId;
                    Name = field.Name;
                    GeneralHistoryUser = field.GeneralHistoryUser;
                    PathJsTsNETCoreSQLServer = field.PathJsTsNETCoreSQLServer;
                    PathNET6CleanArchitecture = field.PathNET6CleanArchitecture;
                    PathNodeJsExpressMongoDB = field.PathNodeJsExpressMongoDB;
                    PathNET8MSSQLServerAPI = field.PathNET8MSSQLServerAPI;
                    PathNET8BlazorMSSQLServerCodeFirst = field.PathNET8BlazorMSSQLServerCodeFirst;
                    Active = field.Active;
                    UserIdCreation = field.UserIdCreation;
                    UserIdLastModification = field.UserIdLastModification;
                    DateTimeCreation = field.DateTimeCreation;
                    DateTimeLastModification = field.DateTimeLastModification;
                }
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
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("GeneralHistoryUser", GeneralHistoryUser, DbType.String, ParameterDirection.Input);
                dp.Add("PathJsTsNETCoreSQLServer", PathJsTsNETCoreSQLServer, DbType.String, ParameterDirection.Input);
                dp.Add("PathNET6CleanArchitecture", PathNET6CleanArchitecture, DbType.String, ParameterDirection.Input);
                dp.Add("PathNodeJsExpressMongoDB", PathNodeJsExpressMongoDB, DbType.String, ParameterDirection.Input);
                dp.Add("PathNET8MSSQLServerAPI", PathNET8MSSQLServerAPI, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Project.Add]", 
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
        public int Update()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("GeneralHistoryUser", GeneralHistoryUser, DbType.String, ParameterDirection.Input);
                dp.Add("PathJsTsNETCoreSQLServer", PathJsTsNETCoreSQLServer, DbType.String, ParameterDirection.Input);
                dp.Add("PathNET6CleanArchitecture", PathNET6CleanArchitecture, DbType.String, ParameterDirection.Input);
                dp.Add("PathNodeJsExpressMongoDB", PathNodeJsExpressMongoDB, DbType.String, ParameterDirection.Input);
                dp.Add("PathNET8MSSQLServerAPI", PathNET8MSSQLServerAPI, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Project.UpdateByProjectId]", 
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
        public int DeleteByProjectId()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[Project.DeleteByProjectId]", 
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
            return $"ProjectId: {ProjectId}, " +
                $"Name: {Name}, " +
                $"GeneralHistoryUser: {GeneralHistoryUser}, " +
                $"PathJsTsNETCoreSQLServer: {PathJsTsNETCoreSQLServer}, " +
                $"PathNET6CleanArchitecture: {PathNET6CleanArchitecture}, " +
                $"PathNodeJsExpressMongoDB: {PathNodeJsExpressMongoDB}, " +
                $"PathNET8MSSQLServerAPI: {PathNET8MSSQLServerAPI}, " +
                $"Active: {Active}, " +
                $"UserIdCreation: {UserIdCreation}, " +
                $"UserIdLastModification: {UserIdLastModification}, " +
                $"DateTimeCreation: {DateTimeCreation}, " +
                $"DateTimeLastModification: {DateTimeLastModification}";
        }
    }
}
