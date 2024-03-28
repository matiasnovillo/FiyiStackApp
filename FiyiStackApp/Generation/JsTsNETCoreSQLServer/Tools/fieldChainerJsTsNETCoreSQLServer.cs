using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Models.Tools
{
    public class fieldChainerJsTsNETCoreSQLServer
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
        public string TsFields_ForTsModel { get; set; } = "";
        public string Fields_ForIronPDF_Converter { get; set; } = "";
        public string Fields_ForExcel_Converter_DefineDataColumns { get; set; } = "";
        public string Fields_ForjQuery_TableFill_FirstPart { get; set; } = "";
        public string Fields_ForjQuery_TableFill_SecondtPart { get; set; } = "";
        public string Fields_ForjQuery_ListFill { get; set; } = "";
        /// <summary>
        /// Format: [Field] = [Field],
        /// </summary>
        public string Fields_ForController_InInsertAsync { get; set; } = "";
        public string Fields_ForController_InUpdateAsync { get; set; } = "";
        public string Fields_ForController_InInsertAsync_Ajax { get; set; } = "";
        public int iFields_ForController_InInsertAsync_Ajax { get; set; } = 0;
        /// <summary>
        /// Format: bool Boolean;
        /// </summary>
        public string Fields_ForRazorPageFrontNonQuery_Part1 { get; set; } = "";
        /// <summary>
        /// Format: Boolean = false;
        /// </summary>
        public string Fields_ForRazorPageFrontNonQuery_Part2 { get; set; } = "";
        /// <summary>
        /// Format: Boolean = {Table.Name}Model.Boolean;
        /// </summary>
        public string Fields_ForRazorPageFrontNonQuery_Part3 { get; set; } = "";
        public string Fields_ForRazorPageFrontNonQuery_InHTMLTag { get; set; } = "";
        public string FieldTextFile_ForjQueryNonQuery { get; set; } = "";
        public string FieldTextEditor_ForjQueryNonQuery { get; set; } = "";
        public string Field_ForjQueryNonQuery_FormData { get; set; } = "";
        public string FieldTextEditor_ForjQueryNonQuery_LoadEvent { get; set; } = "";
        public string FieldTextEditor_ForjQueryNonQuery_Quill { get; set; } = "";

        public string FieldForHTTPFile { get; set; } = "";
        public fieldChainerJsTsNETCoreSQLServer() 
        { 
        }

        ///<summary>
        /// Object used to reduce duplicated code in /Generator/DataToGenerate folder <br/>
        /// This object contains all the fields chained to engage in every part of looped code
        ///</summary>
        public fieldChainerJsTsNETCoreSQLServer(Table Table) 
        {
            Field Field = new();
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

                Fields_ForjQuery_TableFill_FirstPart += $@"<th scope=""col"">
            <button value=""{field.Name}"" class=""btn btn-outline-secondary btn-sm"" type=""button"">
                {field.Name}
            </button>
        </th>
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

                        TsFields_ForTsModel += $@"{field.Name}?: number";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong><i class=""fas fa-divide"">
            </i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                            {field.Name} <i class=""fas fa-divide""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

                        
                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"int {field.Name} = Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";

                            Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
                ";

                            Fields_ForRazorPageFrontNonQuery_Part1 += $@"int {field.Name};
    ";

                            Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = {field.MinValue};
        ";

                            Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                            Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-divide""></i> 
                                {field.Name}
                            </label>
                            <input class=""form-control"" 
                                type=""number"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                value=""@{field.Name}"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                step=""1"" 
                                pattern=""[^0-9]""
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
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

                        TsFields_ForTsModel += $@"{field.Name}?: boolean";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-toggle-on""></i> ${{row.{field.Name} == true ? ""Active <i class='text-success fas fa-circle'></i>"" : ""Not active <i class='text-danger fas fa-circle'></i>""}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-toggle-on""></i> ${{row.{field.Name} == true ? ""Active <i class='text-success fas fa-circle'></i>"" : ""Not active <i class='text-danger fas fa-circle'></i>""}}
                        </span>
                        <br/>
                        ";

                        if (field.Name != "Active")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"bool {field.Name} = Convert.ToBoolean(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";
                            Fields_ForRazorPageFrontNonQuery_Part1 += $@"bool {field.Name};
    ";

                            Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = false;
        ";

                            Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                            Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                            <div class=""form-group mb-3"">
                                <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                    <i class=""fas fa-toggle-on""></i> {field.Name}
                                </label>
                                <br/>
                                <input type=""checkbox"" 
                                    id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""
                                    @({field.Name} == true ? ""checked"" : """" )
                                    {(field.Nullable == true ? "" : "required")}/>
                                <br />
                                {(field.Nullable == true ? "" : $@"<p class=""text-danger text-sm"">
                                    <b>This value is required.</b>
                                </p>")}
                            </div>
                        ";

                            Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").is("":checked""));
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong><i class=""fas fa-font"">
            </i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-font""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-font""></i> {field.Name}
                            </label>
                            <input class=""form-control"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                type=""text"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                value=""@{field.Name}""
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                    This value is required.
                                </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: number";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-divide""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-divide""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"decimal {field.Name} = Convert.ToDecimal(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""].ToString().Replace(""."","",""));
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"decimal {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = {field.MinValue.Replace(",", ".")}M;
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-divide""></i> {field.Name}
                            </label>
                            <input class=""form-control"" 
                                type=""number"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""
                                value=""@(Convert.ToDouble({field.Name}))"" 
                                min=""{field.MinValue.Replace(",",".")}"" 
                                max=""{field.MaxValue.Replace(",", ".")}"" 
                                step="".01"" 
                                pattern=""^\d*(\.\d{{0,2}})?$"" 
                                {(field.Nullable == true ? "" : "required")}>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: number";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left text-light"">
        <i class=""fas fa-key""></i> ${{row.{field.Name}}}
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white text-light mb-4"">
                           {field.Name} <i class=""fas fa-key""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-calendar""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-calendar""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

                        if (field.Name != "DateTimeCreation" && field.Name != "DateTimeLastModification")
                        {
                            Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                            Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                            Fields_ForController_InInsertAsync_Ajax += $@"DateTime {field.Name} = Convert.ToDateTime(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";

                            Fields_ForRazorPageFrontNonQuery_Part1 += $@"DateTime {field.Name};
    ";

                            Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = DateTime.Now;
        ";

                            Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                            Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                            <div class=""form-group mb-3"">
                                <label class=""form-control-label"">
                                    <i class=""fas fa-calendar""></i> {field.Name}
                                </label>
                                <input id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                    value=""@{field.Name}.ToString(""yyyy'-'MM'-'dd'T'HH':'mm"")"" 
                                    type=""datetime-local"" 
                                    min=""{field.MinValue}"" 
                                    max=""{field.MaxValue}"" 
                                    class=""form-control""
                                    {(field.Nullable == true ? "" : "required")}/>
                                {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                    This value is required.
                                </div>")}
                            </div>
                        ";

                            Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: string";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-clock""></i> ${{row.{field.Name}?.substring(0, 12)}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-clock""></i> ${{row.{field.Name}?.substring(0, 12)}}
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"TimeSpan {field.Name} = TimeSpan.Parse(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""]);
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"TimeSpan {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = TimeSpan.Parse(""00:00"");
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label class=""form-control-label"">
                                <i class=""fas fa-clock""></i> 
                                {field.Name}
                            </label>
                            <input class=""form-control"" 
                                type=""time"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                value=""@{field.Name}"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: number";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-key""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-key""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

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

                            Fields_ForRazorPageFrontNonQuery_Part1 += $@"int {field.Name};
    ";

                            Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = 0;
        ";

                            Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                            Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                            <div class=""form-group mb-3"">
                                <label class=""form-control-label"">
                                    <i class=""fas fa-hashtag""></i> 
                                    {field.Name}
                                </label>
                                <ul class=""nav nav-pills nav-fill flex-column flex-sm-row"" 
                                    role=""tablist"">
                                        <li class=""nav-item"">
                                            <a class=""nav-link mb-sm-3 mb-md-0 {Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-a active"" 
                                                data-toggle=""tab"" 
                                                href=""javascript:void(0)"" 
                                                role=""tab"" 
                                                aria-controls="""" 
                                                aria-selected=""true"">
                                                    Choose a value
                                            </a>
                                            <input type=""hidden"" value=""0""/>
                                        </li>
                                </ul>
                            </div>
                        ";

                            Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $("".{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-a.active"").next().val());
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

                            SQLServerFieldsForCreateFields_ForSQLServer += "VARCHAR(7) ";

                            SQLServerFieldsForParametersExample_ForSQLServer += $@"    @{field.Name} = AABBCC,";

                            SQLServerFieldsForParametersInInsert_ForSQLServer += $@"    @{field.Name} VARCHAR(7),";

                            SQLServerFieldsForParametersInUpdateBy_ForSQLServer += $@"    @{field.Name} VARCHAR(7),";

                            Fields_ForJSONScript += $@"    ""{field.Name}"" : ""212529"",{Environment.NewLine}";

                            FieldForHTTPFile += $@"    ""{field.Name}"" : ""212529"",{Environment.NewLine}";
                        }
                        else
                        { throw new Exception($"{field.Name} has not 'Colour' in the name"); }

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"" >
        <strong style=""color:#${{row.{field.Name}}}"">
            <i class=""fas fa-palette""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""mb-4"" style=""color:#${{row.{field.Name}}}"">
                           {field.Name} <i class=""fas fa-palette""></i>
                            <strong>${{row.{field.Name}}}</strong>
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = ""#FFFFFF"";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                class=""form-control-label"">
                                    <i class=""fas fa-palette""></i> 
                                    {field.Name}
                            </label>
                            <input class=""form-control"" 
                                type=""color""
                                min=""{field.MinValue}""
                                max=""{field.MaxValue}""
                                value=""@{field.Name}"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-font""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-font""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-font""></i> 
                                {field.Name}
                            </label>
                            <textarea class=""form-control mt-1"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                rows=""3"" 
                                resize=""none"" 
                                {(field.Nullable == true ? "" : "required")}>
                                    @{field.Name}
                            </textarea>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <i class=""fas fa-font""></i> ${{row.{field.Name}}}
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-font""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                            <i class=""fas fa-font""></i> 
                            {field.Name}
                        </label>
                        <div id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"">
                        </div>
                        <input type=""hidden"" 
                            value=""@{field.Name}"" 
                            id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-hidden-value"">
                        <div class=""mb-3""></div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}quill.root.innerHTML);
                ";

                        FieldTextEditor_ForjQueryNonQuery_LoadEvent += $@"{Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}quill.root.innerHTML = $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-hidden-value"").val();
    ";

                        FieldTextEditor_ForjQueryNonQuery_Quill += $@"let {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}toolbaroptions = [
    [""bold"", ""italic"", ""underline"", ""strike""],        // toggled buttons
    [""link"", ""blockquote"", ""code-block""],

    [{{ ""header"": 1 }}, {{ ""header"": 2 }}],               // custom button values
    [{{ ""list"": ""ordered"" }}, {{ ""list"": ""bullet"" }}],
    [{{ ""script"": ""sub"" }}, {{ ""script"": ""super"" }}],      // superscript/subscript
    [{{ ""indent"": ""-1"" }}, {{ ""indent"": ""+1"" }}],          // outdent/indent
    [{{ ""direction"": ""rtl"" }}],                         // text direction
    [""image"", ""video""],
    [""clean""]                                         // remove formatting button
];
let {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}quill = new Quill(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", {{
    modules: {{
        toolbar: {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}toolbaroptions
    }},
    theme: ""snow""
}});
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-asterisk""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-asterisk""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

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

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-asterisk""></i> 
                                {field.Name}
                            </label>
                            <input class=""form-control"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                type=""password"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                value=""@{field.Name}"" 
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
                ";

                        FieldTextEditor_ForjQueryNonQuery += $@"{Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}quill.root.innerHTML = $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-hidden-value"").val();
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <a href=""tel:${{row.{field.Name}}}"">
            <strong>
                <i class=""fas fa-phone""></i> ${{row.{field.Name}}}
            </strong>
        </a>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                            <a style=""color:#FFFFFF"" href=""tel:${{row.{field.Name}}}"">
                               {field.Name} <i class=""fas fa-phone""></i> ${{row.{field.Name}}}
                            </a>
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-phone""></i> 
                                {field.Name}
                            </label>
                            <input class=""form-control mt-2"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                type=""tel"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                value=""@{field.Name}"" 
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <a href=""${{row.{field.Name}}}"" target=""_blank"">
            <strong>
                <i class=""fas fa-globe""></i> ${{row.{field.Name}}}
            </strong>
        </a>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""mb-4"">
                            <a href=""${{row.{field.Name}}}"" style=""color:#FFFFFF"" target=""_blank"">
                               {field.Name} <i class=""fas fa-globe""></i> ${{row.{field.Name}}}
                            </a>
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = ""http://"";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-globe""></i> 
                                {field.Name}
                            </label>
                            <input class=""form-control"" 
                                type=""url"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                value=""@{field.Name}"" 
                                required>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <a href=""mailto:${{row.{field.Name}}}"">
            <strong>
                <i class=""fas fa-at""></i> ${{row.{field.Name}}}
            </strong>
        </a>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                            <a style=""color:#FFFFFF"" href=""mailto:${{row.{field.Name}}}"">
                               {field.Name} <i class=""fas fa-at""></i> ${{row.{field.Name}}}
                            <a/>
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-at""></i> {field.Name}
                            </label>
                            <input class=""form-control"" 
                                type=""email"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                value=""@{field.Name}"" 
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <a href=""${{row.{field.Name}}}"">
            <strong>
                <i class=""fas fa-file""></i> ${{row.{field.Name}}}
            </strong>
        </a>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-file""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

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

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group"">
                            <label class=""form-control-label"">
                                <i class=""fas fa-file""></i> {field.Name}
                            </label>
                            <br/>
                            <div class=""fileinput fileinput-new"" data-provides=""fileinput"">
                                <div class=""fileinput-preview img-thumbnail"" 
                                    data-trigger=""fileinput"" 
                                    style=""width: 200px; height: 150px;"">
                                </div>
                                <div>
                                    <span class=""btn btn-primary btn-file"">
                                        <span class=""fileinput-new"">Select file</span>
                                        <span class=""fileinput-exists"">Change</span>
                                        <input type=""file"" 
                                            min=""{field.MinValue}"" 
                                            max=""{field.MaxValue}"" 
                                            id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                            value=""""/>
                                    </span>
                                    <a href=""#"" class=""btn btn-outline-danger fileinput-exists"" data-dismiss=""fileinput"">
                                        Remove
                                    </a>
                                </div>
                            </div>
                            <input type=""hidden"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-readonly"" 
                                value=""@{field.Name}""/>
                            <br />
                            @if (@{field.Name} == """"){{
                                {(field.Nullable == true ? "" : $@"<p class=""text-danger text-sm"">
                                    <b>This value is required.</b>
                                </p>")}
                            }}
                            else
                            {{
                                <a class=""btn btn-info btn-sm""
                                    href=""@{field.Name}""
                                    download>
                                        <i class=""fas fa-download""></i>
                                        Download file
                                </a>
                            }}
                        </div>
                        ";

                        FieldTextFile_ForjQueryNonQuery += $@"let {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}input;
let {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}boolfileadded;
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").on(""change"", function (e) {{
    {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}input = $(this).get(0).files;
    {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}boolfileadded = true;
    formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}input[0], {Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}input[0].name);
}});

";

                        Field_ForjQueryNonQuery_FormData += $@"if (!{Table.Area.ToLower()}{Table.Name.ToLower()}{field.Name.ToLower()}boolfileadded) {{
                    formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-readonly"").val());
                }}
                ";

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

                        TsFields_ForTsModel += $@"{field.Name}?: string | string[] | number | undefined";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-tag""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-tag""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

                        Fields_ForController_InInsertAsync += $@"{field.Name} = {field.Name},
                        ";

                        Fields_ForController_InUpdateAsync += $@"{Table.Name}Model.{field.Name} = {field.Name};
                    ";

                        Fields_ForController_InInsertAsync_Ajax += $@"string {field.Name} = HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""];
                ";

                        Fields_ForRazorPageFrontNonQuery_Part1 += $@"string {field.Name};
    ";

                        Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = """";
        ";

                        Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                        Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                        <div class=""form-group mb-3"">
                            <label for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" class=""form-control-label"">
                                <i class=""fas fa-tag""></i> {field.Name}
                            </label>
                            <br/>
                            <input type=""text"" 
                                class=""form-control"" 
                                min=""{field.MinValue}"" 
                                max=""{field.MaxValue}"" 
                                id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"" 
                                value=""@{field.Name}"" 
                                data-toggle=""tags"" 
                                {(field.Nullable == true ? "" : "required")}/>
                            {(field.Nullable == true ? "" : $@"<div class=""invalid-feedback"">
                                This value is required.
                            </div>")}
                        </div>
                        ";

                        Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                        TsFields_ForTsModel += $@"{field.Name}?: number";

                        Fields_ForjQuery_TableFill_SecondtPart += $@"<td class=""text-left"">
        <strong>
            <i class=""fas fa-key""></i> ${{row.{field.Name}}}
        </strong>
    </td>
    ";
                        Fields_ForjQuery_ListFill += $@"<span class=""text-white mb-4"">
                           {field.Name} <i class=""fas fa-key""></i> ${{row.{field.Name}}}
                        </span>
                        <br/>
                        ";

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

                            Fields_ForRazorPageFrontNonQuery_Part1 += $@"int {field.Name};
    ";

                            Fields_ForRazorPageFrontNonQuery_Part2 += $@"{field.Name} = 0;
        ";

                            Fields_ForRazorPageFrontNonQuery_Part3 += $@"{field.Name} = {Table.Name}Model.{field.Name};
        ";

                            Fields_ForRazorPageFrontNonQuery_InHTMLTag += $@"<!-- {field.Name} -->
                            <div class=""form-group mb-3"">
                                <label class=""form-control-label"">
                                    <i class=""fas fa-hashtag""></i> {field.Name}
                                </label>
                                <br/>
                                <button type=""button"" 
                                    class=""btn btn-outline-primary border-0"" 
                                    data-toggle=""modal"" 
                                    data-target=""#modal-foreign-key-code-selector"">
                                        <i class=""fas fa-hashtag""></i>
                                </button>
                                <ul id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-list""
                                    class=""nav nav-pills nav-fill flex-column flex-sm-row"" 
                                    role=""tablist"">
                                    <li class=""nav-item"">
                                        <a class=""nav-link mb-sm-3 mb-md-0 active"" 
                                            data-toggle=""tab"" 
                                            href=""javascript:void(0)"" 
                                            role=""tab"" 
                                            aria-controls="""" 
                                            aria-selected=""true"">
                                                Choose a value
                                        </a>
                                        <input type=""hidden"" 
                                            id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input""
                                            value=""@{field.Name}""/>
                                    </li>
                                </ul>
                                {(field.Nullable == true ? "" : $@"<p class=""text-danger text-sm"">
                                    <b>This value is required.</b>
                                </p>")}
                            </div>
                        ";

                            Field_ForjQueryNonQuery_FormData += $@"formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{field.Name.ToLower()}-input"").val());
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

                TsFields_ForTsModel += $";{Environment.NewLine}\t";
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
