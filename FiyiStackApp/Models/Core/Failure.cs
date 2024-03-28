using Dapper;
using FiyiStackApp.Models.Tools;
using System.Data;

namespace FiyiStackApp.Models.Core
{
    public partial class Failure
    {
        #region Fields
        public int FailureId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public bool Active { get; set; }
        public int UserCreationId { get; set; }
        public int UserLastModificationId { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public DateTime DateTimeLastModification { get; set; }
        #endregion

        public Failure()
        {
            try { FailureId = 0; }
            catch (Exception ex) { throw ex; }
        }

        public int Add()
        {
            try
            {
                int MaxId;

                DynamicParameters dp = new();
                dp.Add("Message", Message, DbType.String, ParameterDirection.Input);
                dp.Add("StackTrace", StackTrace, DbType.String, ParameterDirection.Input);
                dp.Add("Source", Source, DbType.String, ParameterDirection.Input);
                dp.Add("Active", Active, DbType.Boolean, ParameterDirection.Input);
                dp.Add("DateTimeCreation", DateTimeCreation, DbType.DateTime, ParameterDirection.Input);
                dp.Add("DateTimeLastModification", DateTimeLastModification, DbType.DateTime, ParameterDirection.Input);
                dp.Add("UserCreationId", UserCreationId, DbType.Int32, ParameterDirection.Input);
                dp.Add("UserLastModificationId", UserLastModificationId, DbType.Int32, ParameterDirection.Input);

                DataTable DataTable = new();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction,
                    "[dbo].[Failure.Add]",
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
            catch (Exception) { throw; }
        }

        public override string ToString()
        {
            return $"FailureId: {FailureId}, " +
                $"Message: {Message}, " +
                $"StackTrace: {StackTrace}, " +
                $"Source: {Source}, " +
                $"Active: {Active}, " +
                $"UserCreationId: {UserCreationId}, " +
                $"UserLastModificationId: {UserLastModificationId}, " +
                $"DateTimeCreation: {DateTimeCreation}, " +
                $"DateTimeLastModification: {DateTimeLastModification}";
        }
    }
}
