using Dapper;
using FiyiStackApp.Models.Tools;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FiyiStackApp.Models.Core
{
    public partial class UserProject
    {
        #region Fields
        public int UserProjectId { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int AccessTypeId { get; set; }

        public string UsersIdThatAcceptedInvitation { get; set; }

        public string UsersIdThatHasBeenInvited { get; set; }

        public bool Active { get; set; }

        public int UserIdCreation { get; set; }

        public int UserIdLastModification { get; set; }

        public DateTime DateTimeCreation { get; set; }

        public DateTime DateTimeLastModification { get; set; }
        #endregion

        #region Constructors
        public UserProject()
        {
            try { UserProjectId = 0; }
            catch (Exception ex) { throw ex; }
        }

        public UserProject(int UserId, int ProjectId)
        {
            try
            {
                List<UserProject> lstUserProject = new List<UserProject>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstUserProject = (List<UserProject>)sqlConnection.Query<UserProject>("[dbo].[UserProject.GetOneByUserIdByProjectId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUserProject.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[UserProject.GetOneByUserIdByProjectId] returned more than one register/row");
                }

                foreach (var field in lstUserProject)
                {
                    this.UserProjectId = field.UserProjectId;
                    this.UserId = field.UserId;
                    this.ProjectId = field.ProjectId;
                    this.AccessTypeId = field.AccessTypeId;
                    this.UsersIdThatAcceptedInvitation = field.UsersIdThatAcceptedInvitation;
                    this.UsersIdThatHasBeenInvited = field.UsersIdThatHasBeenInvited;
                    this.Active = field.Active;
                    this.DateTimeCreation = field.DateTimeCreation;
                    this.DateTimeLastModification = field.DateTimeLastModification;
                    this.UserIdCreation = field.UserIdCreation;
                    this.UserIdLastModification = field.UserIdLastModification;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public UserProject(int ProjectId)
        {
            try
            {
                List<UserProject> lstUserProject = new List<UserProject>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstUserProject = (List<UserProject>)sqlConnection.Query<UserProject>("[dbo].[UserProject.GetOneByProjectId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUserProject.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[UserProject.GetOneByProjectId] returned more than one register/row");
                }

                foreach (var field in lstUserProject)
                {
                    this.UserProjectId = field.UserProjectId;
                    this.UserId = field.UserId;
                    this.ProjectId = field.ProjectId;
                    this.AccessTypeId = field.AccessTypeId;
                    this.UsersIdThatAcceptedInvitation = field.UsersIdThatAcceptedInvitation;
                    this.UsersIdThatHasBeenInvited = field.UsersIdThatHasBeenInvited;
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
        public List<UserProject> GetAllByUserIdByProjectNameByAccessTypeIdToModel(int UserId, string ProjectName, int AccessTypeId)
        {
            try
            {
                List<UserProject> lstUserProject = new List<UserProject>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ProjectName", ProjectName, DbType.String, ParameterDirection.Input);
                dp.Add("AccessTypeId", AccessTypeId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstUserProject = (List<UserProject>)sqlConnection.Query<UserProject>("[dbo].[UserProject.GetAllByUserIdByProjectNameByAccessTypeId]", dp, commandType: CommandType.StoredProcedure);
                }

                return lstUserProject;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Non-Queries
        /// <summary>
        /// 
        /// </summary>
        /// <returns>RowsAffected</returns>
        public int UpdateByUserProjectId()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("UserProjectId", UserProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("AccessTypeId", AccessTypeId, DbType.Int32, ParameterDirection.Input);
                dp.Add("UsersIdThatAcceptedInvitation", UsersIdThatAcceptedInvitation, DbType.String, ParameterDirection.Input);
                dp.Add("UsersIdThatHasBeenInvited", UsersIdThatHasBeenInvited, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[UserProject.UpdateByUserProjectId]", 
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
        /// <returns>MaxId</returns>
        public int Add()
        {
            try
            {
                int MaxId;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                dp.Add("ProjectId", ProjectId, DbType.Int32, ParameterDirection.Input);
                dp.Add("AccessTypeId", AccessTypeId, DbType.Int32, ParameterDirection.Input);
                dp.Add("UsersIdThatAcceptedInvitation", UsersIdThatAcceptedInvitation, DbType.String, ParameterDirection.Input);
                dp.Add("UsersIdThatHasBeenInvited", UsersIdThatHasBeenInvited, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserIdCreation", UserIdCreation, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserIdLastModification", UserIdLastModification, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[UserProject.Add]", 
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
                    "[dbo].[UserProject.DeleteByProjectId]", 
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
    }
}
