using FiyiStackApp.Models.Tools;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FiyiStackApp.Models.Core
{
    public class User
    {
        #region Fields
        public int UserId { get; set; }

        public string Name { get; set; }

        public string FantasyName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public int UserAccountTypeId { get; set; }

        public int GenerationsLeft { get; set; }

        public virtual Role Role { get; set; }
        #endregion

        #region Constructors
        public User()
        {
            try { UserId = 0; }
            catch (Exception ex) { throw ex; }
        }

        public User(int UserId)
        {
            try
            {
                List<User> lstUser = new List<User>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstUser = (List<User>)sqlConnection.Query<User>("[dbo].[User.GetOneByUserId]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUser.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[User.GetOneByUserId] returned more than one register/row");
                }

                foreach (var field in lstUser)
                {
                    this.UserId = field.UserId;
                    Name = field.Name;
                    FantasyName = field.FantasyName;
                    Email = field.Email;
                    Password = field.Password;
                    RoleId = field.RoleId;
                    UserAccountTypeId = field.UserAccountTypeId;
                    GenerationsLeft = field.GenerationsLeft;
                }

            }
            catch (Exception ex) { throw ex; }
        }

        public User(string FantasyName, string Email, string Password)
        {
            try
            {
                List<User> lstUser = new List<User>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add("FantasyName", FantasyName, DbType.String, ParameterDirection.Input);
                dp.Add("Email", Email, DbType.String, ParameterDirection.Input);
                dp.Add("Password", Password, DbType.String, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(connectionStrings.fiyistac_FiyiStackAppProduction))
                {
                    lstUser = (List<User>)sqlConnection.Query<User>("[dbo].[User.GetOneByFantasyNameByEmailByPassword]", dp, commandType: CommandType.StoredProcedure);
                }

                if (lstUser.Count > 1)
                {
                    throw new Exception("The stored procedure [dbo].[User.GetOneByFantasyNameByEmailByPassword] returned more than one register/row");
                }

                foreach (var field in lstUser)
                {
                    this.UserId = field.UserId;
                    this.Name = field.Name;
                    this.FantasyName = field.FantasyName;
                    this.Email = field.Email;
                    this.Password = field.Password;
                    this.RoleId = field.RoleId;
                    this.UserAccountTypeId = field.UserAccountTypeId;
                    this.GenerationsLeft = field.GenerationsLeft;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Non-Queries
        public int ChangePasswordByUserId(int UserId, string NewPassword)
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                dp.Add("NewPassword", NewPassword, DbType.String, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction,
                    "[dbo].[User.ChangePasswordByUserId]",
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
        public int UpdateByUserId()
        {
            try
            {
                int RowsAffected;

                DynamicParameters dp = new DynamicParameters();
                dp.Add("UserId", UserId, DbType.Int32, ParameterDirection.Input);
                dp.Add("Name", Name, DbType.String, ParameterDirection.Input);
                dp.Add("FantasyName", FantasyName, DbType.String, ParameterDirection.Input);
                dp.Add("Email", Email, DbType.String, ParameterDirection.Input);
                dp.Add("Password", Password, DbType.String, ParameterDirection.Input);
                dp.Add("RoleId", RoleId, DbType.Int32, ParameterDirection.Input);
                //dp.Add("UserAccountTypeId", UserAccountTypeId, DbType.Int32, ParameterDirection.Input);
                //dp.Add("GenerationsLeft", GenerationsLeft, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[User.UpdateByUserId]", 
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
            return $"UserId: {UserId}, " +
                $"Name: {Name}, " +
                $"FantasyName: {FantasyName}, " +
                $"Email: {Email}, " +
                $"Password: {Password}, " +
                //$"UserAccountTypeId: {UserAccountTypeId}, " +
                //$"GenerationsLeft: {GenerationsLeft}, " +
                $"RoleId: {RoleId}";
        }
    }
}
