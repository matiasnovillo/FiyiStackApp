using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string Service(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using System.Data;
using System.Globalization;
using ClosedXML.Excel;
using CsvHelper;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.BasicCore;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Services
{{
    public class {Table.Name}Service : I{Table.Name}Service
    {{
        protected readonly {GeneratorConfigurationComponent.ProjectChosen.Name}Context _context;

        public {Table.Name}Service({GeneratorConfigurationComponent.ProjectChosen.Name}Context context)
        {{
            _context = context;
        }}

        #region Exportations
        public DateTime ExportAsPDF(Ajax Ajax, string ExportationType)
        {{
            var Renderer = new HtmlToPdf();
            DateTime Now = DateTime.Now;
            string RowsAsHTML = """";
            List<{Table.Name}> lst{Table.Name} = [];

            if (ExportationType == ""All"")
            {{
                lst{Table.Name} = _context.{Table.Name}.ToList();
            }}
            else
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {{
                    {Table.Name} {Table.Name} = _context.{Table.Name}
                                                .Where(x => x.{Table.Name}Id == Convert.ToInt32(RowChecked))
                                                .FirstOrDefault();
                    lst{Table.Name}.Add({Table.Name});
                }}
            }}

            foreach ({Table.Name} row in lst{Table.Name})
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
        {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Fields_ForIronPDF_Converter}
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
                DataTable dt{Table.Name} = new();

                //We define another DataTable dt{Table.Name}Copy to avoid issue related to DateTime conversion
                DataTable dt{Table.Name}Copy = new();
                dt{Table.Name}Copy.TableName = ""{Table.Name}"";

                #region Define columns for dt{Table.Name}Copy
                {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Fields_ForExcel_Converter_DefineDataColumns.TrimEnd('\t')}
                #endregion

                #region Create another DataTable to copy
                List<{Table.Name}> lst{Table.Name} = _context.{Table.Name}.ToList();

                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable1}

                foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
                        {{
                            DataTable.Rows.Add(
                                {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable}
                                );
                        }}
                #endregion

                dt{Table.Name} = DataTable;

                foreach (DataRow DataRow in dt{Table.Name}.Rows)
                {{
                    dt{Table.Name}Copy.Rows.Add(DataRow.ItemArray);
                }}

                var Sheet = Book.Worksheets.Add(dt{Table.Name}Copy);

                Sheet.ColumnsUsed().AdjustToContents();

                Book.SaveAs($@""wwwroot/ExcelFiles/{Table.Area}/{Table.Name}/{Table.Name}_{{Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.xlsx"");
            }}
            else
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                DataSet ds{Table.Name} = new();

                foreach (string RowChecked in RowsChecked)
                {{
                    //We define another DataTable dt{Table.Name}Copy to avoid issue related to DateTime conversion
                    DataTable dt{Table.Name}Copy = new();

                    #region Define columns for dt{Table.Name}Copy
                    {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Fields_ForExcel_Converter_DefineDataColumns}
                    #endregion

                    ds{Table.Name}.Tables.Add(dt{Table.Name}Copy);

                    #region Create DataTable with data from DB
                        {Table.Name} {Table.Name.ToLower()} = _context.{Table.Name}
                                                    .Where(x => x.{Table.Name}Id == Convert.ToInt32(RowChecked))
                                                    .FirstOrDefault();

                        DataTable DataTable = new();
                        DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                        {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable1}
                        
                        DataTable.Rows.Add(
                                {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.PropertiesForRepository_DataTable}
                                );
                        #endregion

                        dt{Table.Name}Copy = DataTable;

                        foreach (DataRow DataRow in dt{Table.Name}Copy.Rows)
                        {{
                            ds{Table.Name}.Tables[0].Rows.Add(DataRow.ItemArray);
                        }}
                }}

                for (int i = 0; i < ds{Table.Name}.Tables.Count; i++)
                {{
                    var Sheet = Book.Worksheets.Add(ds{Table.Name}.Tables[i]);
                    Sheet.ColumnsUsed().AdjustToContents();
                }}
                Book.SaveAs($@""wwwroot/ExcelFiles/{Table.Area}/{Table.Name}/{Table.Name}_{{Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.xlsx"");
            }}
            return Now;
        }}

        public DateTime ExportAsCSV(Ajax Ajax, string ExportationType)
        {{
            DateTime Now = DateTime.Now;
            List<{Table.Name}> lst{Table.Name} = new List<{Table.Name}> {{ }};

            if (ExportationType == ""All"")
            {{
                lst{Table.Name} = _context.{Table.Name}.ToList();
            }}
            else
            {{
                string[] RowsChecked = Ajax.AjaxForString.Split(',');

                foreach (string RowChecked in RowsChecked)
                {{
                    {Table.Name} {Table.Name} = _context.{Table.Name}
                                            .Where(x => x.{Table.Name}Id == Convert.ToInt32(RowChecked))
                                            .FirstOrDefault();      
                    lst{Table.Name}.Add({Table.Name});
                }}
            }}

            using (var Writer = new StreamWriter($@""wwwroot/CSVFiles/{Table.Area}/{Table.Name}/{Table.Name}_{{Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.csv""))
            using (var CsvWriter = new CsvWriter(Writer, CultureInfo.InvariantCulture))
            {{
                CsvWriter.WriteRecords(lst{Table.Name});
            }}

            return Now;
        }}
        #endregion
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
