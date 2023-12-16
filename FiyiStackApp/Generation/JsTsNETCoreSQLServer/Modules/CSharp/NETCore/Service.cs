using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class CSharp
    {
        public static string Service(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content = $@"using ClosedXML.Excel;
using CsvHelper;
using IronPdf;
using Microsoft.AspNetCore.Http;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Models;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

//Last modification on: {DateTime.Now}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Services
{{
    /// <summary>
    /// Stack:             4<br/>
    /// Name:              C# Service. <br/>
    /// Function:          Allow you to separate data contract stored in C# model from business with your clients. <br/>
    /// Also, allow dependency injection inside controllers/web apis<br/>
    /// Last modification: {DateTime.Now}
    /// </summary>
    public partial class {Table.Name}Service : I{Table.Name}
    {{
        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public {Table.Name}Service(IHttpContextAccessor IHttpContextAccessor)
        {{
            _IHttpContextAccessor = IHttpContextAccessor;
        }}

        #region Queries
        public {Table.Name}Model Select1By{Table.Name}IdToModel(int {Table.Name}Id)
        {{
            return new {Table.Name}Model().Select1By{Table.Name}IdToModel({Table.Name}Id);
        }}

        public List<{Table.Name}Model> SelectAllToList()
        {{
            return new {Table.Name}Model().SelectAllToList();
        }}

        public {Table.Name.ToLower()}SelectAllPaged SelectAllPagedToModel({Table.Name.ToLower()}SelectAllPaged {Table.Name.ToLower()}SelectAllPaged)
        {{
            return new {Table.Name}Model().SelectAllPagedToModel({Table.Name.ToLower()}SelectAllPaged);
        }} 
        #endregion

        #region Non-Queries
        public int Insert({Table.Name}Model {Table.Name}Model)
        {{
            return new {Table.Name}Model().Insert({Table.Name}Model);
        }}

        public int UpdateBy{Table.Name}Id({Table.Name}Model {Table.Name}Model)
        {{
            return new {Table.Name}Model().UpdateBy{Table.Name}Id({Table.Name}Model);
        }}

        public int DeleteBy{Table.Name}Id(int {Table.Name}Id)
        {{
            return new {Table.Name}Model().DeleteBy{Table.Name}Id({Table.Name}Id);
        }}

        public void DeleteManyOrAll(Ajax Ajax, string DeleteType)
        {{
            if (DeleteType == ""All"")
            {{
                {Table.Name}Model {Table.Name}Model = new {Table.Name}Model();
                {Table.Name}Model.DeleteAll();
            }}
            else
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                for (int i = 0; i < RowsChecked.Length; i++)
                {{
                    {Table.Name}Model {Table.Name}Model = new {Table.Name}Model().Select1By{Table.Name}IdToModel(Convert.ToInt32(RowsChecked[i]));
                    {Table.Name}Model.DeleteBy{Table.Name}Id({Table.Name}Model.{Table.Name}Id);
                }}
            }}
        }}

        public int CopyBy{Table.Name}Id(int {Table.Name}Id)
        {{
            {Table.Name}Model {Table.Name}Model = new {Table.Name}Model().Select1By{Table.Name}IdToModel({Table.Name}Id);
            int NewEnteredId = new {Table.Name}Model().Insert({Table.Name}Model);

            return NewEnteredId;
        }}

        public int[] CopyManyOrAll(Ajax Ajax, string CopyType)
        {{
            if (CopyType == ""All"")
            {{
                List<{Table.Name}Model> lst{Table.Name}Model = new List<{Table.Name}Model> {{ }};
                lst{Table.Name}Model = new {Table.Name}Model().SelectAllToList();

                int[] NewEnteredIds = new int[lst{Table.Name}Model.Count];

                for (int i = 0; i < lst{Table.Name}Model.Count; i++)
                {{
                    NewEnteredIds[i] = lst{Table.Name}Model[i].Insert();
                }}

                return NewEnteredIds;
            }}
            else
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');
                int[] NewEnteredIds = new int[RowsChecked.Length];

                for (int i = 0; i < RowsChecked.Length; i++)
                {{
                    {Table.Name}Model {Table.Name}Model = new {Table.Name}Model().Select1By{Table.Name}IdToModel(Convert.ToInt32(RowsChecked[i]));
                    NewEnteredIds[i] = {Table.Name}Model.Insert();
                }}

                return NewEnteredIds;
            }}
        }}
        #endregion

        #region Other services
        public DateTime ExportAsPDF(Ajax Ajax, string ExportationType)
        {{
            var Renderer = new HtmlToPdf();
            DateTime Now = DateTime.Now;
            string RowsAsHTML = """";
            List<{Table.Name}Model> lst{Table.Name}Model = new List<{Table.Name}Model> {{ }};

            if (ExportationType == ""All"")
            {{
                lst{Table.Name}Model = new {Table.Name}Model().SelectAllToList();

            }}
            else if (ExportationType == ""JustChecked"")
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {{
                    {Table.Name}Model {Table.Name}Model = new {Table.Name}Model().Select1By{Table.Name}IdToModel(Convert.ToInt32(RowChecked));
                    lst{Table.Name}Model.Add({Table.Name}Model);
                }}
            }}

            foreach ({Table.Name}Model row in lst{Table.Name}Model)
            {{
                RowsAsHTML += $@""{{row.ToStringOnlyValuesForHTML()}}"";
            }}

            Renderer.RenderHtmlAsPdf($@""<table cellpadding=""""0"""" cellspacing=""""0"""" border=""""0"""" width=""""88%"""" style=""""width: 88% !important; min-width: 88%; max-width: 88%;"""">
    <tr>
    <td align=""""left"""" valign=""""top"""">
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#1a1a1a"""" style=""""font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"""">Mikromatica</span>
        </font>
        <div style=""""height: 25px; line-height: 25px; font-size: 23px;"""">&nbsp;</div>
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#4c4c4c"""" style=""""font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"""">Registers of {Table.Name}</span>
        </font>
        <div style=""""height: 35px; line-height: 35px; font-size: 33px;"""">&nbsp;</div>
    </td>
    </tr>
</table>
<br>
<table cellpadding=""""0"""" cellspacing=""""0"""" border=""""0"""" width=""""100%"""" style=""""width: 100% !important; min-width: 100%; max-width: 100%;"""">
    <tr>
        {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForIronPDF_Converter}
    </tr>
    {{RowsAsHTML}}
</table>
<br>
<font face=""""'Source Sans Pro', sans-serif"""" color=""""#868686"""" style=""""font-size: 17px; line-height: 20px;"""">
    <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #868686; font-size: 17px; line-height: 20px;"""">Printed on: {{Now}}</span>
</font>
"").SaveAs($@""wwwroot/PDFFiles/{Table.Area}/{Table.Name}/{Table.Name}_{{Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.pdf"");

            return Now;
        }}

        public DateTime ExportAsExcel(Ajax Ajax, string ExportationType)
        {{
            DateTime Now = DateTime.Now;

            using var Book = new XLWorkbook();

            if (ExportationType == ""All"")
            {{
                DataTable dt{Table.Name} = new DataTable();
                dt{Table.Name}.TableName = ""{Table.Name}"";

                //We define another DataTable dt{Table.Name}Copy to avoid issue related to DateTime conversion
                DataTable dt{Table.Name}Copy = new DataTable();
                dt{Table.Name}Copy.TableName = ""{Table.Name}"";

                #region Define columns for dt{Table.Name}Copy
                {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForExcel_Converter_DefineDataColumns.TrimEnd('\t')}
                #endregion

                dt{Table.Name} = new {Table.Name}Model().SelectAllToDataTable();

                foreach (DataRow DataRow in dt{Table.Name}.Rows)
                {{
                    dt{Table.Name}Copy.Rows.Add(DataRow.ItemArray);
                }}

                var Sheet = Book.Worksheets.Add(dt{Table.Name}Copy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@""wwwroot/ExcelFiles/{Table.Name}ing/{Table.Name}/{Table.Name}_{{Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.xlsx"");
            }}
            else if (ExportationType == ""JustChecked"")
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet ds{Table.Name} = new DataSet();

                foreach (string RowChecked in RowsChecked)
                {{
                    //We define another DataTable dt{Table.Name}Copy to avoid issue related to DateTime conversion
                    DataTable dt{Table.Name}Copy = new DataTable();
                    dt{Table.Name}Copy.TableName = ""{Table.Name}"";

                    #region Define columns for dt{Table.Name}Copy
                    {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForExcel_Converter_DefineDataColumns}
                    #endregion

                    ds{Table.Name}.Tables.Add(dt{Table.Name}Copy);

                    for (int i = 0; i < ds{Table.Name}.Tables.Count; i++)
                    {{
                        dt{Table.Name}Copy = new {Table.Name}Model().Select1By{Table.Name}IdToDataTable(Convert.ToInt32(RowChecked));

                        foreach (DataRow DataRow in dt{Table.Name}Copy.Rows)
                        {{
                            ds{Table.Name}.Tables[0].Rows.Add(DataRow.ItemArray);
                        }}
                    }}
                    
                }}

                for (int i = 0; i < ds{Table.Name}.Tables.Count; i++)
                {{
                    var Sheet = Book.Worksheets.Add(ds{Table.Name}.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }}

                Book.SaveAs($@""wwwroot/ExcelFiles/{Table.Name}ing/{Table.Name}/{Table.Name}_{{Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.xlsx"");
            }}

            return Now;
        }}

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {{
            DateTime Now = DateTime.Now;
            List<{Table.Name}Model> lst{Table.Name}Model = new List<{Table.Name}Model> {{ }};

            if (ExportationType == ""All"")
            {{
                lst{Table.Name}Model = new {Table.Name}Model().SelectAllToList();

            }}
            else if (ExportationType == ""JustChecked"")
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {{
                    {Table.Name}Model {Table.Name}Model = new {Table.Name}Model().Select1By{Table.Name}IdToModel(Convert.ToInt32(RowChecked));
                    lst{Table.Name}Model.Add({Table.Name}Model);
                }}
            }}

            using (var Writer = new StreamWriter($@""wwwroot/CSVFiles/{Table.Name}ing/{Table.Name}/{Table.Name}_{{Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.csv""))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {{
                CsvWriter.WriteRecords(lst{Table.Name}Model);
            }}

            return Now;
        }}
        #endregion
    }}
}}";

                return Content;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
