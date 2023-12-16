using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules
{
    public static partial class CSharp
    {
        public static string Interface(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                    $@"using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Models;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;
using System;
using System.Collections.Generic;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

//Last modification on: {DateTime.Now}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces
{{
    /// <summary>
    /// Stack:             5<br/>
    /// Name:              C# Interface. <br/>
    /// Function:          This interface allow you to standardize the C# service associated. 
    ///                    In other words, define the functions that has to implement the C# service. <br/>
    /// Note:              Raise exception in case of missing any function declared here but not in the service. <br/>
    /// Last modification: {DateTime.Now}
    /// </summary>
    public partial interface I{Table.Name}
    {{
        #region Queries
        /// <summary>
        /// Note: Raise exception when the query find duplicated IDs
        /// </summary>
        /// <param name=""{Table.Name}Id""></param>
        /// <returns></returns>
        { Table.Name}Model Select1By{Table.Name}IdToModel(int {Table.Name}Id);

        List<{Table.Name}Model> SelectAllToList();

        {Table.Name.ToLower()}SelectAllPaged SelectAllPagedToModel({Table.Name.ToLower()}SelectAllPaged {Table.Name.ToLower()}SelectAllPaged);
        #endregion

        #region Non-Queries
        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull insertion in database
        /// </summary>
        /// <param name=""{Table.Name}""></param>
        /// <returns>NewEnteredId: The ID of the last registry inserted in {Table.Name} table</returns>
        int Insert({Table.Name}Model {Table.Name});

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull update in database
        /// </summary>
        /// <param name=""{Table.Name}""></param>
        /// <returns>The number of rows updated in {Table.Name} table</returns>
        int UpdateBy{Table.Name}Id({Table.Name}Model {Table.Name});

        /// <summary>
        /// Note: Raise exception when the function did not made a succesfull deletion in database
        /// </summary>
        /// <param name=""{Table.Name}Id""></param>
        /// <returns>The number of rows deleted in {Table.Name} table</returns>
        int DeleteBy{Table.Name}Id(int {Table.Name}Id);

        void DeleteManyOrAll(Ajax Ajax, string DeleteType);

        int CopyBy{Table.Name}Id(int {Table.Name}Id);

        int[] CopyManyOrAll(Ajax Ajax, string CopyType);
        #endregion

        #region Other actions
        DateTime ExportAsPDF(Ajax Ajax, string ExportationType);

        DateTime ExportAsExcel(Ajax Ajax, string ExportationType);

        DateTime ExportAsCSV(Ajax Ajax, string ExportationType);
        #endregion
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
