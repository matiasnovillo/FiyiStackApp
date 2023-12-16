using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class CSharp
    {
        public static string ModelWithSPs(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using Dapper;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Models
{{
    /// <summary>
    /// Stack:             3 <br/>
    /// Name:              C# Model with stored procedure calls saved on database. <br/>
    /// Function:          Allow you to manipulate information from database using stored procedures.
    ///                    Also, let you make other related actions with the model in question or
    ///                    make temporal copies with random data. <br/>
    /// Fields:            {GeneratorConfigurationComponent.fieldChainer.NumberOfFields} <br/> 
    /// Sub-models:      {GeneratorConfigurationComponent.modelChainer.CounterOfModelsThatDependOnThis} models <br/>
    /// Last modification: {DateTime.Now}
    /// </summary>
    public partial class {Table.Name}Model
    {{
        [NotMapped]
        private string _ConnectionString = ConnectionStrings.ConnectionStrings.Development();

        #region Fields
        {GeneratorConfigurationComponent.fieldChainer.CSharpFields_ForCSharpModel}
        #endregion

        #region Sub-lists
        {GeneratorConfigurationComponent.modelChainer.CSharpModelsThatDependOnThis_ForCSharpModel}
        #endregion

        #region Constructors
        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create fastly this model with field {Table.Name}Id = 0 <br/>
        /// Note 1:       Generally used to have fast access to functions of object. <br/>
        /// Note 2:       Need construction with [new] reserved word, as all constructors. <br/>
        /// Fields:       {GeneratorConfigurationComponent.fieldChainer.NumberOfFields} <br/> 
        /// Dependencies: {GeneratorConfigurationComponent.modelChainer.CounterOfModelsThatDependOnThis} models depend on this model <br/>
        /// </summary>
        public {Table.Name}Model()
        {{
            try 
            {{
                {Table.Name}Id = 0;

                //Initialize sub-lists
                {GeneratorConfigurationComponent.modelChainer.NewList_ForCSharpModel}
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with stored information in database using {Table.Name}Id <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       {GeneratorConfigurationComponent.fieldChainer.NumberOfFields} <br/> 
        /// Dependencies: {GeneratorConfigurationComponent.modelChainer.CounterOfModelsThatDependOnThis} models depend on this model <br/>
        /// </summary>
        public {Table.Name}Model(int {Table.Name}Id)
        {{
            try
            {{
                List<{Table.Name}Model> lst{Table.Name}Model = new List<{Table.Name}Model>();

                //Initialize sub-lists
                {GeneratorConfigurationComponent.modelChainer.NewList_ForCSharpModel}
                
                DynamicParameters dp = new DynamicParameters();

                dp.Add(""{Table.Name}Id"", {Table.Name}Id, DbType.Int32, ParameterDirection.Input);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    //In case of not finding anything, Dapper return a List<{Table.Name}Model>
                    lst{Table.Name}Model = (List<{Table.Name}Model>)sqlConnection.Query<{Table.Name}Model>(""[{Table.Scheme}].[{Table.Area}.{Table.Name}.Select1By{Table.Name}Id]"", dp, commandType: CommandType.StoredProcedure);
                }}

                if (lst{Table.Name}Model.Count > 1)
                {{
                    throw new Exception(""The stored procedure [{Table.Scheme}].[{Table.Area}.{Table.Name}.Select1By{Table.Name}Id] returned more than one register/row"");
                }}
        
                foreach ({Table.Name}Model {Table.Name.ToLower()} in lst{Table.Name}Model)
                {{
                    {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsAndParameters1_ForCSharpModel.Replace("\t\t\t\t", "\t\t\t\t\t")}
                }}
            }}
            catch (Exception ex) {{ throw ex; }}
        }}


        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model with filled parameters <br/>
        /// Note:         Raise exception on duplicated IDs <br/>
        /// Fields:       {GeneratorConfigurationComponent.fieldChainer.NumberOfFields} <br/> 
        /// Dependencies: {GeneratorConfigurationComponent.modelChainer.CounterOfModelsThatDependOnThis} models depend on this model <br/>
        /// </summary>
        public {Table.Name}Model({GeneratorConfigurationComponent.fieldChainer.CSharpFieldsAsParametersInOneLine_ForCSharpModel})
        {{
            try
            {{
                //Initialize sub-lists
                {GeneratorConfigurationComponent.modelChainer.NewList_ForCSharpModel}

                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsAndParameters2_ForCSharpModel}
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Stack:        3 <br/>
        /// Function:     Create this model (copy) using the given model (original), {Table.Name.ToLower()}, passed by parameter. <br/>
        /// Note:         This constructor is generally used to execute functions using the copied fields <br/>
        /// Fields:       {GeneratorConfigurationComponent.fieldChainer.NumberOfFields} <br/> 
        /// Dependencies: {GeneratorConfigurationComponent.modelChainer.CounterOfModelsThatDependOnThis} models depend on this model <br/>
        /// </summary>
        public {Table.Name}Model({Table.Name}Model {Table.Name.ToLower()})
        {{
            try
            {{
                //Initialize sub-lists
                {GeneratorConfigurationComponent.modelChainer.NewList_ForCSharpModel}

                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsAndParameters1_ForCSharpModel.Replace("this.", "")}
            }}
            catch (Exception ex) {{ throw ex; }}
        }}
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The number of rows inside {Table.Name}</returns>
        public int Count()
        {{
            try
            {{
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.Count]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }}

                int RowsCounter = Convert.ToInt32(DataTable.Rows[0][0].ToString());

                return RowsCounter;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        #region Queries to DataTable
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        public DataTable Select1By{Table.Name}IdToDataTable(int {Table.Name}Id)
        {{
            try
            {{
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();

                dp.Add(""{Table.Name}Id"", {Table.Name}Id, DbType.Int32, ParameterDirection.Input);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[{Table.Scheme}].[{Table.Area}.{Table.Name}.Select1By{Table.Name}Id]"", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }}

                if (DataTable.Rows.Count > 1)
                {{ throw new Exception(""The stored procedure [{Table.Scheme}].[{Table.Area}.{Table.Name}.Select1By{Table.Name}Id] returned more than one register/row""); }}

                return DataTable;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        public DataTable SelectAllToDataTable()
        {{
            try
            {{
                DataTable DataTable = new DataTable();
                DynamicParameters dp = new DynamicParameters();
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[{Table.Scheme}].[{Table.Area}.{Table.Name}.SelectAll]"", commandType: CommandType.StoredProcedure, param: dp);

                    DataTable.Load(dataReader);
                }}

                return DataTable;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}
        #endregion

        #region Queries to Models
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        public {Table.Name}Model Select1By{Table.Name}IdToModel(int {Table.Name}Id)
        {{
            try
            {{
                {Table.Name}Model {Table.Name}Model = new {Table.Name}Model();
                List<{Table.Name}Model> lst{Table.Name}Model = new List<{Table.Name}Model>();
                DynamicParameters dp = new DynamicParameters();

                dp.Add(""{Table.Name}Id"", {Table.Name}Id, DbType.Int32, ParameterDirection.Input);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    lst{Table.Name}Model = (List<{Table.Name}Model>)sqlConnection.Query<{Table.Name}Model>(""[{Table.Scheme}].[{Table.Area}.{Table.Name}.Select1By{Table.Name}Id]"", dp, commandType: CommandType.StoredProcedure);
                }}
        
                if (lst{Table.Name}Model.Count > 1)
                {{ throw new Exception(""The stored procedure [{Table.Scheme}].[{Table.Area}.{Table.Name}.Select1By{Table.Name}Id] returned more than one register/row""); }}

                foreach ({Table.Name}Model {Table.Name.ToLower()} in lst{Table.Name}Model)
                {{
                    {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsAndParameters4_ForCSharpModel}
                }}

                return {Table.Name}Model;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        public List<{Table.Name}Model> SelectAllToList()
        {{
            try
            {{
                List<{Table.Name}Model> lst{Table.Name}Model = new List<{Table.Name}Model>();
                DynamicParameters dp = new DynamicParameters();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    lst{Table.Name}Model = (List<{Table.Name}Model>)sqlConnection.Query<{Table.Name}Model>(""[{Table.Scheme}].[{Table.Area}.{Table.Name}.SelectAll]"", dp, commandType: CommandType.StoredProcedure);
                }}

                return lst{Table.Name}Model;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        public {Table.Name.ToLower()}SelectAllPaged SelectAllPagedToModel({Table.Name.ToLower()}SelectAllPaged {Table.Name.ToLower()}SelectAllPaged)
        {{
            try
            {{
                {Table.Name.ToLower()}SelectAllPaged.lst{Table.Name}Model = new List<{Table.Name}Model>();
                DynamicParameters dp = new DynamicParameters();
                dp.Add(""QueryString"", {Table.Name.ToLower()}SelectAllPaged.QueryString, DbType.String, ParameterDirection.Input);
                dp.Add(""ActualPageNumber"", {Table.Name.ToLower()}SelectAllPaged.ActualPageNumber, DbType.Int32, ParameterDirection.Input);
                dp.Add(""RowsPerPage"", {Table.Name.ToLower()}SelectAllPaged.RowsPerPage, DbType.Int32, ParameterDirection.Input);
                dp.Add(""SorterColumn"", {Table.Name.ToLower()}SelectAllPaged.SorterColumn, DbType.String, ParameterDirection.Input);
                dp.Add(""SortToggler"", {Table.Name.ToLower()}SelectAllPaged.SortToggler, DbType.Boolean, ParameterDirection.Input);
                dp.Add(""TotalRows"", {Table.Name.ToLower()}SelectAllPaged.TotalRows, DbType.Int32, ParameterDirection.Output);

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    {Table.Name.ToLower()}SelectAllPaged.lst{Table.Name}Model = (List<{Table.Name}Model>)sqlConnection.Query<{Table.Name}Model>(""[{Table.Scheme}].[{Table.Area}.{Table.Name}.SelectAllPaged]"", dp, commandType: CommandType.StoredProcedure);
                    {Table.Name.ToLower()}SelectAllPaged.TotalRows = dp.Get<int>(""TotalRows"");
                }}

                {Table.Name.ToLower()}SelectAllPaged.TotalPages = Library.Math.Divide({Table.Name.ToLower()}SelectAllPaged.TotalRows, {Table.Name.ToLower()}SelectAllPaged.RowsPerPage, Library.Math.RoundType.RoundUp);

                {GeneratorConfigurationComponent.modelChainer.LoopThroughListsAndSubLists_ForCSharpModel}

                return {Table.Name.ToLower()}SelectAllPaged;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>NewEnteredId: The ID of the last registry inserted in {Table.Name} table</returns>
        public int Insert()
        {{
            try
            {{
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
                
                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForNonQuerySP1_ForCSharpModel.Replace($@"dp.Add(""{Table.Name}Id"", {Table.Name}Id, DbType.Int32, ParameterDirection.Input);
" + "\t\t\t\t", "")}
                dp.Add(""NewEnteredId"", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.Insert]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    NewEnteredId = dp.Get<int>(""NewEnteredId"");
                }}
                                
                if (NewEnteredId == 0) {{ throw new Exception(""NewEnteredId with no value""); }}

                return NewEnteredId;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>The ID of the last registry inserted in {Table.Name} table</returns>
        public int Insert({Table.Name}Model {Table.Name.ToLower()})
        {{
            try
            {{
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForNonQuerySP2_ForCSharpModel.Replace($@"dp.Add(""{Table.Name}Id"", {Table.Name.ToLower()}.{Table.Name}Id, DbType.Int32, ParameterDirection.Input);
" + "\t\t\t\t", "")}
                dp.Add(""NewEnteredId"", NewEnteredId, DbType.Int32, ParameterDirection.Output);
                
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.Insert]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    NewEnteredId = dp.Get<int>(""NewEnteredId"");
                }}
                                
                if (NewEnteredId == 0) {{ throw new Exception(""NewEnteredId with no value""); }}

                return NewEnteredId;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <returns>The ID of the last registry inserted in {Table.Name} table</returns>
        public int Insert({GeneratorConfigurationComponent.fieldChainer.CSharpFieldsAsParametersInOneLine_ForCSharpModel.Replace($"int {Table.Name}Id, ", "")})
        {{
            try
            {{
                int NewEnteredId = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForNonQuerySP1_ForCSharpModel.Replace($@"dp.Add(""{Table.Name}Id"", {Table.Name}Id, DbType.Int32, ParameterDirection.Input);
" + "\t\t\t\t", "")}
                dp.Add(""NewEnteredId"", NewEnteredId, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.Insert]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    NewEnteredId = dp.Get<int>(""NewEnteredId"");
                }}
                                
                if (NewEnteredId == 0) {{ throw new Exception(""NewEnteredId with no value""); }}

                return NewEnteredId;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <returns>The number of rows updated in {Table.Name} table</returns>
        public int UpdateBy{Table.Name}Id()
        {{
            try
            {{
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForNonQuerySP1_ForCSharpModel}
                dp.Add(""RowsAffected"", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.UpdateBy{Table.Name}Id]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>(""RowsAffected"");
                }}
                                
                if (RowsAffected == 0) {{ throw new Exception(""RowsAffected with no value""); }}

                return RowsAffected;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <returns>The number of rows updated in {Table.Name} table</returns>
        public int UpdateBy{Table.Name}Id({Table.Name}Model {Table.Name.ToLower()})
        {{
            try
            {{
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForNonQuerySP2_ForCSharpModel}
                dp.Add(""RowsAffected"", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.UpdateBy{Table.Name}Id]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>(""RowsAffected"");
                }}
                                
                if (RowsAffected == 0) {{ throw new Exception(""RowsAffected with no value""); }}

                return RowsAffected;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <returns>The number of rows updated in {Table.Name} table</returns>
        public int UpdateBy{Table.Name}Id({GeneratorConfigurationComponent.fieldChainer.CSharpFieldsAsParametersInOneLine_ForCSharpModel})
        {{
            try
            {{
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForNonQuerySP1_ForCSharpModel}
                dp.Add(""RowsAffected"", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.UpdateBy{Table.Name}Id]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>(""RowsAffected"");
                }}
                                
                if (RowsAffected == 0) {{ throw new Exception(""RowsAffected with no value""); }}

                return RowsAffected;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        ///
        public void DeleteAll()
        {{
            try
            {{
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();

                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.DeleteAll]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                }}
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows deleted in {Table.Name} table</returns>
        public int DeleteBy{Table.Name}Id()
        {{
            try
            {{
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add(""{Table.Name}Id"", {Table.Name}Id, DbType.Int32, ParameterDirection.Input);        
                dp.Add(""RowsAffected"", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.DeleteBy{Table.Name}Id]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>(""RowsAffected"");
                }}
                                
                if (RowsAffected == 0) {{ throw new Exception(""RowsAffected with no value""); }}

                return RowsAffected;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <returns>The number of rows affected in {Table.Name} table</returns>
        public int DeleteBy{Table.Name}Id(int {Table.Name}Id)
        {{
            try
            {{
                int RowsAffected = 0;
                DynamicParameters dp = new DynamicParameters();
                DataTable DataTable = new DataTable();
        
                dp.Add(""{Table.Name}Id"", {Table.Name}Id, DbType.Int32, ParameterDirection.Input);        
                dp.Add(""RowsAffected"", RowsAffected, DbType.Int32, ParameterDirection.Output);
        
                using (SqlConnection sqlConnection = new SqlConnection(_ConnectionString))
                {{
                    var dataReader = sqlConnection.ExecuteReader(""[dbo].[{Table.Area}.{Table.Name}.DeleteBy{Table.Name}Id]"", commandType: CommandType.StoredProcedure, param: dp);
                    DataTable.Load(dataReader);
                    RowsAffected = dp.Get<int>(""RowsAffected"");
                }}
                                
                if (RowsAffected == 0) {{ throw new Exception(""RowsAffected with no value""); }}

                return RowsAffected;
            }}
            catch (Exception ex) {{ throw ex; }}
        }}
        #endregion
        
        /// <summary>
        /// Function: Show all information (fields) inside the model during depuration mode.
        /// </summary>
        public override string ToString()
        {{
            return {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForToStringFunction_ForCSharpModel};
        }}

        public string ToStringOnlyValuesForHTML()
        {{
            return $@""<tr>
                {GeneratorConfigurationComponent.fieldChainer.CSharpFieldsForToStringOnlyValuesForHTMLFunction_ForCSharpModel}
                </tr>"";
        }}
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
