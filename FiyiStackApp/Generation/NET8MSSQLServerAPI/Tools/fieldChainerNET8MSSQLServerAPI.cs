using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Models.Tools
{
    public class fieldChainerNET8MSSQLServerAPI
    {
        public int NumberOfFields { get; set; } = 0; 
        /// <summary>
        /// --------[Library.ModelAttributeValidator...] <br/>
        /// Format: public [DataType.Name] [Field.Name] { get; set; }
        /// </summary>
        public string CSharpFields_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: this.[Field.Name] = [Table.Name.ToLower()].[Field.Name]
        /// </summary>
        public string CSharpFieldsAndParameters1_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: this.[Field.Name] = [Field.Name]
        /// </summary>
        public string CSharpFieldsAndParameters2_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: this.[Field.Name] = [Field.Name]
        /// </summary>
        public string CSharpFieldsAndParameters3_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: [Table.Name][Field.Name] = [Table.Name].[Field.Name]
        /// </summary>
        public string CSharpFieldsAndParameters4_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: [DataType.Name]1 [Field.Name]1, [DataType.Name]2 [Field.Name]2, ... [DataType.Name]N [Field.Name]N
        /// </summary>
        public string CSharpFieldsAsParametersInOneLine_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: [Field.Name] = fields[i] | [Field.Name] = function(fields[i])
        /// </summary>
        public string CSharpFieldsForNonQuerySP1_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: dp.Add([Field.Name], [Table.Name][Field.Name], DbType.[DataType.Name], ParameterDirection.Input)
        /// </summary>
        public string CSharpFieldsForNonQuerySP2_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: $"[Field.Name]": {[Field.Name]}
        /// </summary>
        public string CSharpFieldsForToStringFunction_ForCSharpModel { get; set; } = "";
        public string CSharpFieldsForToStringOnlyValuesForHTMLFunction_ForCSharpModel { get; set; } = "";
        /// <summary>
        /// Format: ALTER TABLE [{Table.Scheme}].[{Table.Name}] ADD [{field.Name}] [DataType.Name] [NULL or NOT NULL]
        /// </summary>
        public string SQLServerFieldsForCreateFields_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     @{field.Name} = 1,
        /// </summary>
        public string SQLServerFieldsForParametersExample_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     @{field.Name} INT,
        /// </summary>
        public string SQLServerFieldsForParametersInInsert_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     [{field.Name}],{Environment.NewLine}
        /// </summary>
        public string SQLServerFieldsForInsertInto_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     @{field.Name},{Environment.NewLine}
        /// </summary>
        public string SQLServerFieldsForValues_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     [{Table.Name}].[{field.Name}],{Environment.NewLine}
        /// </summary>
        public string SQLServerFieldsForSelect_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{field.Name}] END ASC,
        //              CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{field.Name}] END DESC,
        /// </summary>
        public string SQLServerFieldsForSelectAllPaged_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     [{field.Name}] = @{field.Name},{Environment.NewLine}
        /// </summary>
        public string SQLServerFieldsForUpdateInUpdateBy_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     @{field.Name} INT,
        /// </summary>
        public string SQLServerFieldsForParametersInUpdateBy_ForSQLServer { get; set; } = "";
        /// <summary>
        /// Format:     OR ([{Table.Name}].[{field.Name}] LIKE  '%' + @QueryString + '%')
        /// </summary>
        public string SQLServerFieldsForWhereClauseSelectAllPaged_ForSQLServer { get; set; } = "";
        public string Fields_ForJSONScript { get; set; } = "";
        /// <summary>
        /// Format: this.[Field.Name] = [Field.Name]
        /// </summary>
        public string Fields_ForIronPDF_Converter { get; set; } = "";
        public string Fields_ForExcel_Converter_DefineDataColumns { get; set; } = "";
        /// <summary>
        /// Format: [Field] = [Field],
        /// </summary>
        public string Fields_ForController_InInsertAsync { get; set; } = "";
        public string Fields_ForController_InUpdateAsync { get; set; } = "";
        public string Fields_ForController_InInsertAsync_Ajax { get; set; } = "";
        public int iFields_ForController_InInsertAsync_Ajax { get; set; } = 0;

        public string FieldForHTTPFile { get; set; } = "";
        public fieldChainerNET8MSSQLServerAPI() 
        { 
        }

        ///<summary>
        /// Object used to reduce duplicated code in /Generator/DataToGenerate folder <br/>
        /// This object contains all the fields chained to engage in every part of looped code
        ///</summary>
        public fieldChainerNET8MSSQLServerAPI(Table Table) 
        {
            Field Field = new Field();
            List<Field> lstField = Field.GetAllByTableIdToModel(Table.TableId);
            NumberOfFields = lstField.Count;

            foreach (Field field in lstField)
            {
                CSharpFields_ForCSharpModel += field.HistoryUser == "" ? "" : $@"        ///<summary>
        /// {field.HistoryUser}
        ///</summary>
";
                CSharpFieldsAndParameters1_ForCSharpModel += $@"this.{field.Name} = {Table.Name.ToLower()}.{field.Name};
" + "\t\t\t\t";
                CSharpFieldsAndParameters2_ForCSharpModel += $@"this.{field.Name} = {field.Name};
" + "\t\t\t\t";
                CSharpFieldsAndParameters4_ForCSharpModel += $@"{Table.Name}Model.{field.Name} = {Table.Name.ToLower()}.{field.Name};
" + "\t\t\t\t\t";
                CSharpFieldsForNonQuerySP1_ForCSharpModel += $@"dp.Add(""{field.Name}"", {field.Name}, DbType.";
                CSharpFieldsForNonQuerySP2_ForCSharpModel += $@"dp.Add(""{field.Name}"", {Table.Name.ToLower()}.{field.Name}, DbType.";
                CSharpFieldsForToStringFunction_ForCSharpModel += $@"$""{field.Name}: {{{field.Name}}}, "" +
" + "\t\t\t\t";
                SQLServerFieldsForCreateFields_ForSQLServer += $@"ALTER TABLE [{Table.Scheme}].[{Table.Area}.{Table.Name}] ADD [{field.Name}] ";

                if (field.Name != Table.Name + "Id")
                {
                    SQLServerFieldsForInsertInto_ForSQLServer += $"    [{field.Name}],{Environment.NewLine}";
                    SQLServerFieldsForValues_ForSQLServer += $@"    @{field.Name},{Environment.NewLine}";
                    SQLServerFieldsForUpdateInUpdateBy_ForSQLServer += $"    [{field.Name}] = @{field.Name},{Environment.NewLine}";
                }
                SQLServerFieldsForSelect_ForSQLServer += $@"    [{Table.Area}.{Table.Name}].[{field.Name}],{Environment.NewLine}";

                SQLServerFieldsForWhereClauseSelectAllPaged_ForSQLServer += $@"OR ([{Table.Area}.{Table.Name}].[{field.Name}] LIKE  '%' + @QueryString + '%')
        ";

                Fields_ForIronPDF_Converter += $@"<th align=""""left"""" valign=""""top"""" style=""""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"""">
            <font face=""""'Source Sans Pro', sans-serif"""" color=""""#000000"""" style=""""font-size: 20px; line-height: 28px; font-weight: 600;"""">
                <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"""">{field.Name}&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""""height: 10px; line-height: 10px; font-size: 8px;"""">&nbsp;</div>
        </th>";

                CSharpFieldsForToStringOnlyValuesForHTMLFunction_ForCSharpModel += $@"<td align=""""left"""" valign=""""top"""">
        <div style=""""height: 12px; line-height: 12px; font-size: 10px;"""">&nbsp;</div>
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#000000"""" style=""""font-size: 20px; line-height: 28px;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"""">{{{field.Name}}}</span>
        </font>
        <div style=""""height: 40px; line-height: 40px; font-size: 38px;"""">&nbsp;</div>
    </td>";

                Fields_ForExcel_Converter_DefineDataColumns += $@"DataColumn dtColumn{field.Name}Fordt{Table.Name}Copy = new DataColumn();
                    dtColumn{field.Name}Fordt{Table.Name}Copy.DataType = typeof(string);
                    dtColumn{field.Name}Fordt{Table.Name}Copy.ColumnName = ""{field.Name}"";
                    dt{Table.Name}Copy.Columns.Add(dtColumn{field.Name}Fordt{Table.Name}Copy);

                    ";

                switch (Convert.ToInt32(field.DataTypeId))
                {
                    case 0:
                        throw new Exception("You must choose a Data Type");
                    case 3: //Integer
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.Int(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue})]
        public int {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "int ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "Int32";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "Int32";

                        SQLServerFieldsForCreateFields_ForSQLServer += $@"INT ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = 1,";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} INT,";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} INT,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        
                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"int {field.Name} = Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";
                        }

                        break;
                    case 4: //Boolean
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        public bool {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "bool ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "Boolean";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "Boolean";

                        SQLServerFieldsForCreateFields_ForSQLServer += "TINYINT ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = 1,";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} TINYINT,";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} TINYINT,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : true,{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : true,{Environment.NewLine}";

                        if (field.Name != "Active")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"bool {field.Name} = Convert.ToBoolean(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";
                        }
                        break;
                    case 5: //Text: Basic
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        break;
                    case 6: //Decimal
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.Decimal(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue.Replace(',', '.')}D, {field.MaxValue.Replace(',', '.')}D)]
        public decimal {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "decimal ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "Decimal";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "Decimal";

                        SQLServerFieldsForCreateFields_ForSQLServer += "NUMERIC(24,6) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = 3.14,";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} NUMERIC(24,6),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} NUMERIC(24,6),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : 3.14,{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 3.14,{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"decimal {field.Name} = Convert.ToDecimal(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""].ToString().Replace(""."","",""));
                ";
                        break;
                    case 8: //Primary Key (Id)
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"[Library.ModelAttributeValidator.Key(""{field.Name}"")]
        public int {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "int ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "Int32";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "Int32";

                        SQLServerFieldsForCreateFields_ForSQLServer += "INT IDENTITY(1,1) ";

                        SQLServerFieldsForParametersExample_ForSQLServer.TrimEnd('\n', '\r');

                        SQLServerFieldsForParametersInInsert_ForSQLServer.TrimEnd('\n', '\r');

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} INT,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";
                        ;
                        break;
                    case 10: //DateTime
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.DateTime(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public DateTime {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "DateTime ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "DateTime";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "DateTime";

                        SQLServerFieldsForCreateFields_ForSQLServer += "DATETIME ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'01/01/1753 0:00:00.001',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} DATETIME,";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} DATETIME,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""1753-01-01T00:00:00.001Z"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""1753-01-01T00:00:00.001Z"",{Environment.NewLine}";

                        if (field.Name != "DateTimeCreation" && field.Name != "DateTimeLastModification")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"DateTime {field.Name} = Convert.ToDateTime(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";
                        }
                        break;
                    case 11: //Time
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.TimeSpan(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public TimeSpan {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "TimeSpan ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "Time";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "Time";

                        SQLServerFieldsForCreateFields_ForSQLServer += "TIME(3) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'00:00:00.001',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} TIME(3),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} TIME(3),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""00:00:00.001"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""00:00:00.001"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"TimeSpan {field.Name} = TimeSpan.Parse(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";
                        break;
                    case 13: //Foreign Key (Id): Options
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.Key(""{field.Name}"")]
        public int {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "int ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "Int32";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "Int32";

                        SQLServerFieldsForCreateFields_ForSQLServer += "INT ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = 1,";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} INT,";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} INT,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"int {field.Name} = 0; 
                if (Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]) != 0)
                {{
                    {field.Name} = Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                }}
                else
                {{ return StatusCode(400, ""It's not allowed to save zero values in {field.Name}""); }}
                ";
                        }
                        break;
                    case 14: //Text: HexColour
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        if (field.Name.ToLower().Contains("colour"))
                        {
                            CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.HexColour(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public string {field.Name} {{ get; set; }}
";
                            CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                            CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                            CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                            SQLServerFieldsForCreateFields_ForSQLServer += "VARCHAR(6) ";

                            SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = AABBCC,";

                            SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR(6),";

                            SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR(6),";

                            Fields_ForJSONScript += $@"    ""{field.Name}"" : ""212529"",{Environment.NewLine}";

                            FieldForHTTPFile += $@"    ""{field.Name}"" : ""212529"",{Environment.NewLine}";
                        }
                        else
                        { throw new Exception($"{field.Name} has not 'Colour' in the name"); }

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";
                        break;
                    case 15: //Text: TextArea
                        CSharpFields_ForCSharpModel +=
$@"        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} TEXT,";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} TEXT,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";
                        break;
                    case 16: //Text: TextEditor
                        CSharpFields_ForCSharpModel +=
$@"        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} TEXT,";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} TEXT,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";
                        break;
                    case 17: //Text: Password
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = """";
                if (HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""] != """")
                {{
                    {field.Name} = Security.EncodeString(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]); 
                }}
                ";
                        break;
                    case 18: //Text: PhoneNumber
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";
                        break;
                    case 19: //Text: URL
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";
                        break;
                    case 20: //Text: Email
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";
                        break;
                    case 21: //Text: File
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];;
                if (HttpContext.Request.Form.Files.Count != 0)
                {{
                    {field.Name} = $@""/Uploads/{Table.Area}/{Table.Name}/{{HttpContext.Request.Form.Files[{iFields_ForController_InInsertAsync_Ajax}].FileName}}"";
                }}
                ";
                        iFields_ForController_InInsertAsync_Ajax += 1;

                        break;
                    case 22: //Text: Tag
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "string ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "String";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "String";

                        SQLServerFieldsForCreateFields_ForSQLServer += $"VARCHAR({field.MaxValue}) ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = N'Put{field.Name}',";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR({field.MaxValue}),";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : ""Put{field.Name}"",{Environment.NewLine}";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";
                        break;
                    case 23: //Foreign Key (Id): DropDown
                        SQLServerFieldsForSelectAllPaged_ForSQLServer += $@"
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 0) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END ASC,
    CASE WHEN (@SorterColumn = '{field.Name}' AND @SortToggler = 1) THEN [{Table.Area}.{Table.Name}].[{field.Name}] END DESC,";

                        CSharpFields_ForCSharpModel +=
$@"        [Library.ModelAttributeValidator.Key(""{field.Name}"")]
        public int {field.Name} {{ get; set; }}
";
                        CSharpFieldsAsParametersInOneLine_ForCSharpModel += "int ";

                        CSharpFieldsForNonQuerySP1_ForCSharpModel += "Int32";

                        CSharpFieldsForNonQuerySP2_ForCSharpModel += "Int32";

                        SQLServerFieldsForCreateFields_ForSQLServer += "INT ";

                        SQLServerFieldsForParametersExample_ForSQLServer += $@"     @{field.Name} = 1,";

                        SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} INT,";

                        SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} INT,";

                        Fields_ForJSONScript += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        FieldForHTTPFile += $@"    ""{field.Name}"" : 1,{Environment.NewLine}";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"int {field.Name} = 0; 
                if (Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]) != 0)
                {{
                    {field.Name} = Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                }}
                else
                {{ return StatusCode(400, ""It's not allowed to save zero values in {field.Name}""); }}
                ";

                        }
                        break;
                    default:
                        throw new Exception("ERROR localizing Data Type: The Data Type identificator is not correct");
                }
                CSharpFields_ForCSharpModel += Environment.NewLine;
                CSharpFieldsAsParametersInOneLine_ForCSharpModel += $@"{field.Name}, ";
                CSharpFieldsForNonQuerySP1_ForCSharpModel += $@", ParameterDirection.Input{(field.DataTypeId == 6 ? ", precision: 24, scale: 6" : "")});
" + "\t\t\t\t";
                CSharpFieldsForNonQuerySP2_ForCSharpModel += $@", ParameterDirection.Input{(field.DataTypeId == 6 ? ", precision: 24, scale: 6" : "")});
" + "\t\t\t\t";
                SQLServerFieldsForCreateFields_ForSQLServer += $@"{(Field.Nullable == true ? "NULL" : "NOT NULL")}
";
                SQLServerFieldsForParametersExample_ForSQLServer += Environment.NewLine;
                SQLServerFieldsForParametersInInsert_ForSQLServer += Environment.NewLine;
                SQLServerFieldsForParametersInUpdateBy_ForSQLServer += Environment.NewLine;
            }
            CSharpFields_ForCSharpModel = CSharpFields_ForCSharpModel.TrimEnd('\n', '\r', '\n', '\r');
            CSharpFieldsAndParameters1_ForCSharpModel = CSharpFieldsAndParameters1_ForCSharpModel.TrimEnd('\t', '\t', '\t', '\t', '\t', '\n', '\r');
            CSharpFieldsAndParameters2_ForCSharpModel = CSharpFieldsAndParameters2_ForCSharpModel.TrimEnd('\t', '\t', '\t', '\t', '\n', '\r');
            CSharpFieldsAndParameters4_ForCSharpModel = CSharpFieldsAndParameters4_ForCSharpModel.TrimEnd('\t', '\t', '\t', '\t', '\t', '\n', '\r');
            CSharpFieldsAsParametersInOneLine_ForCSharpModel = CSharpFieldsAsParametersInOneLine_ForCSharpModel.TrimEnd(' ', ',');
            CSharpFieldsForNonQuerySP1_ForCSharpModel = CSharpFieldsForNonQuerySP1_ForCSharpModel.TrimEnd('\t', '\t', '\t', '\t', '\n', '\r');
            CSharpFieldsForNonQuerySP2_ForCSharpModel = CSharpFieldsForNonQuerySP2_ForCSharpModel.TrimEnd('\t', '\t', '\t', '\t', '\n', '\r');
            CSharpFieldsForToStringFunction_ForCSharpModel = CSharpFieldsForToStringFunction_ForCSharpModel.TrimEnd('\t', '\t', '\t', '\t', '\n', '\r', '+', ' ', '"', ' ', ',') + "\"";
            SQLServerFieldsForParametersInInsert_ForSQLServer.TrimEnd('\n', '\r', '\n', '\r');
        }
    }
}
