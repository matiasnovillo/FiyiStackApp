using FiyiStackApp.Generation;
using FiyiStackApp.Models.Core;
using static System.Net.Mime.MediaTypeNames;

namespace FiyiStackApp.Models.Tools
{
    public class fieldChainerNET8BlazorMSSQLServerCodeFirst
    {
        public int NumberOfFields { get; set; } = 0;

        public string PropertiesForEntity { get; set; } = "";

        public string PropertiesForEntityConfiguration { get; set; } = "";

        public string PropertiesInHTMLForEntity { get; set; } = "";

        public string PropertiesInHTML_TH_ForBlazorPageQuery { get; set; } = "";

        public string PropertiesInHTML_TD_ForBlazorPageQuery { get; set; } = "";

        public string PropertiesInHTML_Card_ForBlazorPageQuery { get; set; } = "";

        public string Properties_ForExcel_Converter_DefineDataColumns { get; set; } = "";

        public string PropertiesForRepository_DataTable { get; set; } = "";

        public string PropertiesForRepository_DataTable1 { get; set; } = "";

        public string Properties_ForIronPDF_Converter { get; set; } = "";

        public string PropertiesInHTML_BlazorNonQueryPage { get; set; } = "";

        public string ProgressBarForFile_BlazorNonQueryPage { get; set; } = "";

        public string UploadFileMethod_BlazorNonQueryPage { get; set; } = "";

        public string Properties_ForImport1 { get; set; } = "";
        public string Properties_ForImport2 { get; set; } = "";

        public int iForImportInService { get; set; } = 7; //Start in 7 because it adds the auditory fields that are 5 + Id

        public string ErrorMessage_InNonQueryBlazor { get; set; } = "";

        public string Handlers_InNonQueryBlazor { get; set; } = "";

        public string Searchers_BlazorNonQueryPage { get; set; } = "";
        public string Injections_BlazorNonQueryPage { get; set; } = "";
        public string ForeignListsDeclaration_BlazorNonQueryPage { get; set; } = "";
        public string ForeignListsGet_BlazorNonQueryPage { get; set; } = "";
        public string EditPartFK_BlazorNonQueryPage { get; set; } = "";
        public string ForeignLists_DTO { get; set; } = "";

        public fieldChainerNET8BlazorMSSQLServerCodeFirst() 
        { 
        }

        ///<summary>
        /// Object used to reduce duplicated code in /Generator/DataToGenerate folder <br/>
        /// This object contains all the fields chained to engage in every part of looped code
        ///</summary>
        public fieldChainerNET8BlazorMSSQLServerCodeFirst(Table Table, Project Project)
        {
            Field Field = new();
            List<Field> lstField = Field.GetAllByTableIdToModel(Table.TableId);
            NumberOfFields = lstField.Count;

            foreach (Field field in lstField)
            {
                ErrorMessage_InNonQueryBlazor += $@"public string ErrorMessage{field.Name} {{ get; set; }} = """";
    ";

                PropertiesForEntity += field.HistoryUser == "" ? "" : $@"        ///<summary>
        /// {field.HistoryUser}
        ///</summary>
";

                PropertiesInHTMLForEntity += $@"<td align=""""left"""" valign=""""top"""">
        <div style=""""height: 12px; line-height: 12px; font-size: 10px;"""">&nbsp;</div>
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#000000"""" style=""""font-size: 20px; line-height: 28px;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px;"""">{{{field.Name}}}</span>
        </font>
        <div style=""""height: 40px; line-height: 40px; font-size: 38px;"""">&nbsp;</div>
    </td>";

                Properties_ForExcel_Converter_DefineDataColumns += $@"DataColumn dtColumn{field.Name}Fordt{Table.Name}Copy = new()
            {{
                DataType = typeof(string),
                ColumnName = ""{field.Name}""
            }};
            dt{Table.Name}Copy.Columns.Add(dtColumn{field.Name}Fordt{Table.Name}Copy);

            ";

                PropertiesForRepository_DataTable += $@"{Table.Name.ToLower()}.{field.Name},
                        ";

                Properties_ForIronPDF_Converter += $@"<th align=""""left"""" valign=""""top"""" style=""""border-width: 1px; border-style: solid; border-color: #e8e8e8; border-top: none; border-left: none; border-right: none;"""">
            <font face=""""'Source Sans Pro', sans-serif"""" color=""""#000000"""" style=""""font-size: 20px; line-height: 28px; font-weight: 600;"""">
                <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #000000; font-size: 20px; line-height: 28px; font-weight: 600;"""">{field.Name}&nbsp;&nbsp;&nbsp;</span>
            </font>
            <div style=""""height: 10px; line-height: 10px; font-size: 8px;"""">&nbsp;</div>
        </th>";

                if (field.Name != Table.Name + "Id")
                {
                    PropertiesForRepository_DataTable1 += $@"DataTable.Columns.Add(""{field.Name}"", typeof(string));
                ";
                }
                
                switch (Convert.ToInt32(field.DataTypeId))
                {
                    case 0:
                        throw new Exception("You must choose a Data Type");
                    case 3: //Integer

                        PropertiesForEntityConfiguration += 
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""int"")
                    .IsRequired(true);

                ";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            PropertiesForEntity +=
$@"        public int {field.Name} {{ get; set; }}
";

                            Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = Convert.ToInt32(e.Value?.ToString());
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""number""
                        step=""1"" 
                        id=""{field.Name.ToLower()}""
                        class=""form-control pt-0""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                            Properties_ForImport1 += $@"int {field.Name} = Convert.ToInt32(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";
                        }
                        else
                        {
                            PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.Int(""{field.Name}"", ""{field.Name}"", true, {field.MinValue}, {field.MaxValue})]
        public int {field.Name} {{ get; set; }}
";
                        }

                        break;
                    case 4: //Boolean

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""tinyint"")
                    .IsRequired(true);

                ";

                        if (field.Name != "Active")
                        {

                            PropertiesForEntity +=
$@"        {(field.Nullable == true ? "" : $@"[Library.ModelAttributeValidator.Required(""{field.Name}"", ""{field.Name}"")]")}  
        public bool {field.Name} {{ get; set; }}
";

                            Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = Convert.ToBoolean(e.Value?.ToString());
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""form-check form-switch mb-5 pb-2"">
                        <input class=""form-check-input""
                        type=""checkbox""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change""
                        id=""{field.Name.ToLower()}"" />
                        <label class=""form-check-label""
                        for=""{field.Name.ToLower()}"">
                            {field.Name}
                        </label>
                    </div>
                    ";

                            Properties_ForImport1 += $@"bool {field.Name} = Convert.ToBoolean(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"@if (@paginated{Table.Name}DTO.lst{Table.Name}[i]!.{field.Name})
                                        {{
                                            <td>
                                                <span class=""badge rounded-pill bg-success"">Sí</span>
                                            </td>
                                        }}
                                        else
                                        {{
                                            <td>
                                                <span class=""badge rounded-pill bg-danger"">No</span>
                                            </td>
                                        }}
                                        ";

                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"@if (@paginated{Table.Name}DTO.lst{Table.Name}[i]!.{field.Name})
                                        {{
                                            <p>
                                                <b>{field.Name}: </b>
                                                <span class=""badge rounded-pill bg-success"">
                                                    Sí
                                                </span>
                                            </p>
                                        }}
                                        else
                                        {{
                                            <p>
                                                <b>{field.Name}: </b>
                                                <span class=""badge rounded-pill bg-danger"">
                                                    No
                                                </span>
                                            </p>
                                        }}
                                        ";
                        }
                        else
                        {
                            PropertiesForEntity +=
$@"        public bool {field.Name} {{ get; set; }}
";
                        }

                        break;
                    case 5: //Text: Basic

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if(ErrorMessage{field.Name} != """")
                            {{
                            @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""text""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    case 6: //Decimal

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = Convert.ToDecimal(e.Value?.ToString());
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"decimal {field.Name} = Convert.ToDecimal(row.Cell({iForImportInService}).GetString());
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.Decimal(""{field.Name}"", ""{field.Name}"", true, {field.MinValue.Replace(',', '.')}D, {field.MaxValue.Replace(',', '.')}D)]
        public decimal {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""numeric(18, 2)"")
                    .IsRequired(true);

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""number""
                        step=""0.1""
                        id=""{field.Name.ToLower()}"" 
                        class=""form-control pt-0""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    case 8: //Primary Key (Id)

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>ID</th>
                                ";

                        PropertiesForEntity +=
$@"
        public int {field.Name} {{ get; set; }}
";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{Table.Name}Id</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>ID: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{Table.Name}Id</p>
                                        ";

                        break;
                    case 10: //DateTime

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""datetime"")
                    .IsRequired(true);

                ";

                        if (field.Name != "DateTimeCreation" && field.Name != "DateTimeLastModification")
                        {
                            PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.DateTime(""{field.Name}"", ""{field.Name}"", true, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public DateTime {field.Name} {{ get; set; }}
";

                            Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = Convert.ToDateTime(e.Value?.ToString());
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""datetime""
                        id=""{field.Name.ToLower()}""
                        class=""form-control pt-0""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change""/>
                    </div>
                    ";

                            Properties_ForImport1 += $@"DateTime {field.Name} = Convert.ToDateTime(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";
                        }
                        else
                        {
                            PropertiesForEntity +=
$@"        public DateTime {field.Name} {{ get; set; }}
";
                        }
                        break;
                    case 11: //TimeSpan

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = TimeSpan.Parse(e.Value?.ToString());
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        //Re-render the page to show ScannedText
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"TimeSpan {field.Name} = TimeSpan.Parse(row.Cell({iForImportInService}).GetString());
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.TimeSpan(""{field.Name}"", ""{field.Name}"", true, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public TimeSpan {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""time(7)"")
                    .IsRequired(true);

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""time""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    case 13: //Foreign Key (Id): Options

                        throw new Exception("The Foreign Key (Id) Options property is not allowed in this generator");

                    case 14: //Text: HexColour

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.HexColour(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar(7)"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                            <span style=""color:@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}"">
                                                <b class=""fas fa-palette""></b>
                                                @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                            </span>
                                        </td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p style=""color:@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name};"">
                                            <b>{field.Name}: </b>
                                            <b class=""fas fa-palette""></b>
                                            @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                        </p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""color""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    case 15: //Text: TextArea

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        { (field.Nullable == true ? "" : $@"[Library.ModelAttributeValidator.Required(""{field.Name}"", ""{field.Name}"")]") }
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar(MAX)"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<div><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</div>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <textarea rows=""10""
                        class=""form-control pt-0""
                        value=""@{Table.Name}!.{field.Name}""
                        @onchange=""Handle{field.Name}Change""
                        id=""{field.Name.ToLower()}"">
                        </textarea>
                    </div>
                    ";

                        break;
                    case 16: //Text: TextEditor 

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        {(field.Nullable == true ? "" : $@"[Library.ModelAttributeValidator.Required(""{field.Name}"", ""{field.Name}"")]")}
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar(MAX)"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<div><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</div>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""quill-editor-{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <div id=""quill-editor-{field.Name.ToLower()}"">
                        </div>
                        <button id=""button-quill-conversion-{field.Name.ToLower()}""
                        type=""button""
                        class=""btn btn-outline-primary my-2"">
                            Convertir a HTML
                        </button>
                        <input type=""text""
                               id=""quill-result-{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    <link rel=""stylesheet"" href=""assets/vendor/quill/dist/quill.snow.css"">
                    <script type=""text/javascript"">
                        var quilleditor{field.Name.ToLower()} = new Quill(""#quill-editor-{field.Name.ToLower()}"", {{
                            theme: 'snow',
                            modules: {{
                                toolbar: {{
                                    container: [
                                        [{{ header: [1, 2, 3, 4, 5, 6, false] }}],
                                        [""bold"", ""italic"", ""underline"", ""strike""],
                                        [{{ list: ""ordered"" }}, {{ list: ""bullet"" }}],
                                        [""link"", ""image"", ""video""],
                                        [""clean""]
                                    ],
                                    handlers: {{
                                        image: imageHandler{field.Name},
                                        video: videoHandler{field.Name}
                                    }}
                                }}
                            }}
                        }});

                        function imageHandler{field.Name}() {{
                            var range = this.quill.getSelection();
                            var value = prompt('Por favor, ingrese la URL de la imagen');
                            if (value) {{
                                this.quill.insertEmbed(range.index, 'image', value, Quill.sources.USER);
                            }}
                        }}

                        function videoHandler{field.Name}() {{
                            var range = this.quill.getSelection();
                            var value = prompt('Por favor, ingrese la URL del video');
                            if (value) {{
                                this.quill.insertEmbed(range.index, 'video', value, Quill.sources.USER);
                            }}
                        }}

                        $(""#button-quill-conversion-{field.Name.ToLower()}"").on(""click"", function () {{
                            var html{field.Name.ToLower()} = quilleditor{field.Name.ToLower()}.root.innerHTML;
                            $(""#quill-result-{field.Name.ToLower()}"").val(html{field.Name.ToLower()})
                        }});

                        $(document).ready(function () {{
                            quilleditor{field.Name.ToLower()}.container.childNodes[0].innerHTML = quilleditor{field.Name.ToLower()}.getText();
                        }});
                    </script>
                    <script src=""assets/vendor/quill/dist/quill.min.js""></script>
                    ";

                        break;
                    case 17: //Text: Password

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""password""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change""/>
                    </div>
                    ";

                        break;
                    case 18: //Text: PhoneNumber

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                            <a class=""nav-link text-info""
                                               href=""tel:@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}"">
                                                <b class=""fas fa-phone""></b>
                                                @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                            </a>
                                        </td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
                                            href=""tel:@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}"">
                                            <b>{field.Name}: </b>
                                            <b class=""fas fa-phone""></b>
                                            @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                        </a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""tel""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    case 19: //Text: URL

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                            <a class=""nav-link text-info""
                                               href=""@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}""
                                               target=""_blank"">
                                                <b class=""fas fa-link""></b>
                                                @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                            </a>
                                        </td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
                                            href=""@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}""
                                            target=""_blank"">
                                            <b>{field.Name}: </b>
                                            <b class=""fas fa-link""></b>
                                            @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                        </a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""url""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    case 20: //Text: Email

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                            <a class=""nav-link text-info""
                                               href=""mailto:@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}"">
                                                <b class=""fas fa-envelope""></b>
                                                @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                            </a>
                                        </td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
                                            href=""mailto:@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}"">
                                            <b>{field.Name}: </b>
                                            <b class=""fas fa-envelope""></b>
                                            @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                        </a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""email""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change"" />
                    </div>
                    ";

                        break;
                    case 21: //Text: File

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar(MAX)"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
                                            <a class=""nav-link text-info""
                                               href=""@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}""
                                               download>
                                                <b class=""fas fa-download""></b>
                                                @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                            </a>
                                        </td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
                                            href=""@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}""
                                            download>
                                            <b>{field.Name}: </b>
                                            <b class=""fas fa-download""></b>
                                            @paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}
                                        </a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <InputFile type=""file""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               
                               OnChange=""@Upload{field.Name}"" />
                        @{{
                            var ProgressCssFor{field.Name} = ""progress"" + (DisplayProgressFor{field.Name} ? """" : ""d-none"");
                            var ProgressWidthStyleFor{field.Name} = ProgressPercentFor{field.Name} + ""%"";
                        }}
                        <!--Progress bar-->
                        <div class=""@ProgressCssFor{field.Name}"">
                            <div class=""progress-bar progress-bar-striped progress-bar-animated @ProgressBarColourFor{field.Name}""
                                 role=""progressbar"" style=""width:@ProgressWidthStyleFor{field.Name}""
                                 area-valuenow=""@ProgressPercentFor{field.Name}"" 
                                 aria-valuemin=""0""
                                 aria-valuemax=""100"">
                            </div>
                        </div>
                    </div>
                    ";

                        ProgressBarForFile_BlazorNonQueryPage += $@"//Progress bar for {field.Name}
    public bool DisplayProgressFor{field.Name} {{ get; set; }} = false;
    public int ProgressPercentFor{field.Name} {{ get; set; }} = 0;
    public string ProgressTextFor{field.Name} {{ get; set; }} = """";
    public string ProgressBarColourFor{field.Name} {{ get; set; }} = ""bg-info"";
    
    ";

                        UploadFileMethod_BlazorNonQueryPage += $@"private async void Upload{field.Name}(InputFileChangeEventArgs e)
    {{

        try
        {{
            DisplayProgressFor{field.Name} = true;
            ProgressPercentFor{field.Name} = 80;
            ProgressBarColourFor{field.Name} = ""bg-info"";

            string path = Path.Combine(
                Environment.CurrentDirectory,
                ""wwwroot"",
                ""Uploads"",
                ""{Table.Area}"",
                ""{Table.Name}"",
                e.File.Name);

            if (!Directory.Exists(path))
            {{
                System.IO.Directory.CreateDirectory(path);
            }}

            long MaxFileSize = 1024L * 1024L; //3MB max.

            await using FileStream FileStream = new(path, FileMode.Create);
            await e.File.OpenReadStream(MaxFileSize).CopyToAsync(FileStream);

            FileStream.Close();

            string Limitator = ""\\wwwroot"";
            int StartIndex = path.IndexOf(Limitator);
            string Result = """";

            if (StartIndex != -1)
            {{
                Result = path.Substring(StartIndex + Limitator.Length);
            }}

            {Table.Name}!.{field.Name} = Result;

            Check(""[{field.Name}]"");

            ProgressPercentFor{field.Name} = 100;
            ProgressBarColourFor{field.Name} = ""bg-success"";
            DisplayProgressFor{field.Name} = false;
        }}
        catch (Exception ex)
        {{
            Message = $@""<div class=""""alert alert-danger text-white font-weight-bold"""" role=""""alert"""">
                            Hubo un error. Intente nuevamente. Mensaje del error: {{ex.Message}}
                         </div>"";

            ProgressPercentFor{field.Name} = 100;
            ProgressBarColourFor{field.Name} = ""bg-danger"";
        }}
        finally
        {{
            //Re-render the page to show ScannedText
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
    }}

    ";

                        break;
                    case 22: //Text: Tag

                        Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(ChangeEventArgs e)
    {{
        {Table.Name}.{field.Name} = e.Value?.ToString();
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                        PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                        Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                        Properties_ForImport1 += $@"string {field.Name} = row.Cell({iForImportInService}).GetString();
                    ";
                        iForImportInService += 1;

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", ""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static mb-5 pb-2"">
                        <label for=""{field.Name.ToLower()}"">
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""text""
                               id=""{field.Name.ToLower()}""
                               class=""form-control pt-0""
                               value=""@{Table.Name}!.{field.Name}""
                               @onchange=""Handle{field.Name}Change""
                               data-toggle=""tags"" />
                    </div>
                    ";

                        break;
                    case 23: //Foreign Key (Id): DropDown

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""int"")
                    .IsRequired(true);

                ";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            ForeignLists_DTO += $@"public List<{field.ForeignTableName}?> lst{field.ForeignTableName} {{ get; set; }}
        ";

                            ForeignListsGet_BlazorNonQueryPage += $@"lst{field.ForeignTableName} = {field.ForeignTableName.ToLower()}Repository.GetAllBy{field.Name}ForModal("""");
                    ";

                            EditPartFK_BlazorNonQueryPage += $@"{field.ForeignTableName} {field.ForeignTableName} = {field.ForeignTableName.ToLower()}Repository.GetBy{field.Name}({Table.Name}.{field.Name});
                        {field.ForeignTableName}XXX = {field.ForeignTableName}.XXX;
                        ";

                            ForeignListsDeclaration_BlazorNonQueryPage += $@"public List<{field.ForeignTableName}> lst{field.ForeignTableName} {{ get; set; }} = [];
    public string {field.ForeignTableName}XXX {{ get; set; }} = """";
    ";

                            Injections_BlazorNonQueryPage += $@"@using {Project.Name}.Areas.{Table.Area}.{field.ForeignTableName}Back.Entities;
@using {Project.Name}.Areas.{Table.Area}.{field.ForeignTableName}Back.Repositories;
@inject {field.ForeignTableName}Repository {field.ForeignTableName.ToLower()}Repository;
";

                            PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.Key(""{field.Name}"", ""{field.Name}"")]
        public int {field.Name} {{ get; set; }}
";

                            Searchers_BlazorNonQueryPage += $@"private async Task SearchText{field.Name}(ChangeEventArgs args)
    {{
        try
        {{
            //Basic configuration
            Message = """";

            string TextToSearch = args.Value.ToString();

            lst{field.ForeignTableName} = {field.ForeignTableName.ToLower()}Repository.GetAllBy{field.Name}ForModal(TextToSearch);
        }}
        catch (Exception ex)
        {{
            Failure failure = new()
                {{
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = User.UserId == 0 ? 1 : User.UserId,
                    UserLastModificationId = User.UserId == 0 ? 1 : User.UserId,
                    EmergencyLevel = 1,
                    Comment = """",
                    Message = ex.Message,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                }};

            failureRepository.Add(failure);

            Message = $@""<div class=""""alert alert-danger text-white font-weight-bold"""" role=""""alert"""">
                                Hubo un error. Intente nuevamente. Mensaje del error: {{ex.Message}}
                            </div>"";
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
    }}
    ";

                            Handlers_InNonQueryBlazor += $@"private async Task Handle{field.Name}Change(int {field.Name.ToLower()})
    {{
        {Table.Name}.{field.Name} = {field.Name.ToLower()};
        ValidationResult ValidationResult = Check(""[{field.Name}]"");

        {field.ForeignTableName} {field.ForeignTableName} = {field.ForeignTableName.ToLower()}Repository.GetBy{field.Name}({Table.Name}.{field.Name});
        {field.ForeignTableName}XXX = {field.ForeignTableName}.XXX;

        if (ValidationResult == null)
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-success"""">
                <i class=""""fas fa-circle-check""""></i>
            </span>"";
        }}
        else
        {{
            ErrorMessage{field.Name} = $@""<span class=""""text-danger"""">
                <i class=""""fas fa-circle-xmark""""></i>
                {{ValidationResult.ErrorMessage}}
            </span>"";
        }}

        //Re-render the page to show ScannedText
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}
    ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""input-group input-group-static"">
                        <label>
                            {field.Name}
                            @if (ErrorMessage{field.Name} != """")
                            {{
                                @((MarkupString)ErrorMessage{field.Name})
                            }}
                        </label>
                        <input type=""text""
                               readonly
                               class=""form-control pt-0""
                               @bind=""{field.ForeignTableName}XXX""/>
                        <input type=""hidden""
                               id=""{field.Name.ToLower()}""
                               value=""@{Table.Name}!.{field.Name}""/>
                    </div>
                    <button type=""button"" 
                    class=""btn btn-dark mb-5 pb-2"" 
                    data-bs-toggle=""modal"" 
                    data-bs-target=""#{field.Name.ToLower()}modal"">
                        Seleccionar
                    </button>
                    <!-- Modal -->
                    <div class=""modal fade"" 
                        id=""{field.Name.ToLower()}modal"" 
                        tabindex=""-1"" 
                        aria-labelledby=""{field.Name.ToLower()}modallabel"" 
                        aria-hidden=""true"">
                        <div class=""modal-dialog"">
                            <div class=""modal-content"">
                                <div class=""modal-header"">
                                    <h5 class=""modal-title"" id=""{field.Name.ToLower()}modallabel"">
                                        {field.ForeignTableName}
                                    </h5>
                                </div>
                                <div class=""modal-body"">
                                    <div class=""input-group input-group-dynamic"">
                                        <span class=""input-group-text"">
                                            <i class=""fas fa-search"" aria-hidden=""true""></i>
                                        </span>
                                        <input class=""form-control pt-0""
                                                @oninput=""SearchText{field.Name}""
                                                type=""search"">
                                    </div>
                                    <br />
                                    <div class=""table-responsive"">
                                        <table class=""table table-striped table-hover table-bordered mt-4"">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>ID</th>
                                                    <th>XXX</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                @foreach ({field.ForeignTableName} {field.ForeignTableName.ToLower()} in lst{field.ForeignTableName})
                                                {{
                                                    <tr>
                                                        <td>
                                                            <input type=""radio"" 
                                                            id=""@{field.ForeignTableName.ToLower()}-{field.ForeignTableName.ToLower()}.{field.Name}"" 
                                                            name=""{field.Name.ToLower()}""
                                                            value=""@{field.ForeignTableName.ToLower()}.{field.Name}""
                                                            @onclick=""@(() => Handle{field.Name}Change({field.ForeignTableName.ToLower()}.{field.Name}))"">
                                                        </td>
                                                        <td>
                                                            @{field.ForeignTableName.ToLower()}.{field.Name}
                                                        </td>
                                                        <td>
                                                            @{field.ForeignTableName.ToLower()}.XXX
                                                        </td>
                                                    </tr>
                                                }}
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class=""modal-footer justify-content-end"">
                                    <button type=""button"" 
                                    class=""btn btn-dark mb-0"" 
                                    data-bs-dismiss=""modal"">
                                        Cerrar
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                    ";

                            Properties_ForImport1 += $@"int {field.Name} = Convert.ToInt32(row.Cell({iForImportInService}).GetString());
                    ";
                            iForImportInService += 1;

                            Properties_ForImport2 += $@"{field.Name} = {field.Name},
                        ";

                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</td>
                                        ";

                            PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{field.Name}</p>
                                        ";
                        }
                        else
                        {
                            PropertiesForEntity +=
$@"        public int {field.Name} {{ get; set; }}
";
                        }

                        break;
                    default:
                        throw new Exception("ERROR localizing Data Type: The Data Type identificator is not correct");
                }
                PropertiesForEntity += Environment.NewLine;
            }
            PropertiesForEntity = PropertiesForEntity.TrimEnd('\n', '\r', '\n', '\r');
            PropertiesForRepository_DataTable = PropertiesForRepository_DataTable.TrimEnd('\t', '\t', '\t', '\t', '\t', '\t', '\n', '\r', ',');
        }
    }
}
