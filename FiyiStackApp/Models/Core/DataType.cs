using Dapper;
using FiyiStackApp.Models.Tools;
using System.Data;

namespace FiyiStackApp.Models.Core
{
    public partial class DataType
    {
        #region Fields
        public int DataTypeId { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int UserIdCreation { get; set; }

        public int UserIdLastModification { get; set; }
        
        public DateTime DateTimeCreation { get; set; }
        
        public DateTime DateTimeLastModification { get; set; }
        #endregion

        #region Constructors
        public DataType()
        {
            try { DataTypeId = 0; }
            catch (Exception ex) { throw ex; }
        } 
        #endregion

        public DataTable GetList(string FirstTextItem)
        {
            try
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("FirstTextItem", FirstTextItem, DbType.String, ParameterDirection.Input);
                DataTable DataTable = new DataTable();
                DataTable = FiyiStack.Library.NET.Dapper.Connector.ExecuteStoredProcedureToDataTable(
                    connectionStrings.fiyistac_FiyiStackAppProduction, 
                    "[dbo].[DataType.GetList]", 
                    dp);

                return DataTable;
            }
            catch (Exception ex) { throw ex; }
        } 
    }
}
