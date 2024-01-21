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

        public fieldChainerNET8BlazorMSSQLServerCodeFirst() 
        { 
        }

        ///<summary>
        /// Object used to reduce duplicated code in /Generator/DataToGenerate folder <br/>
        /// This object contains all the fields chained to engage in every part of looped code
        ///</summary>
        public fieldChainerNET8BlazorMSSQLServerCodeFirst(Table Table) 
        {
            Field Field = new();
            List<Field> lstField = Field.GetAllByTableIdToModel(Table.TableId);
            NumberOfFields = lstField.Count;

            foreach (Field field in lstField)
            {
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

                PropertiesInHTML_TH_ForBlazorPageQuery += $@"<th>{field.Name}</th>
                                ";

                Properties_ForExcel_Converter_DefineDataColumns += $@"DataColumn dtColumn{field.Name}Fordt{Table.Name}Copy = new DataColumn();
            dtColumn{field.Name}Fordt{Table.Name}Copy.DataType = typeof(string);
            dtColumn{field.Name}Fordt{Table.Name}Copy.ColumnName = ""{field.Name}"";
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

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.Int(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue})]
        public int {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration += 
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""int"")
                    .IsRequired(true);

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""number""
                               step=""1""
                               min=""{field.MinValue}"" 
                               max=""{field.MaxValue}"" 
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";
                        }

                        break;
                    case 4: //Boolean

                        PropertiesForEntity +=
$@"        public bool {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""tinyint"")
                    .IsRequired(true);

                ";

                        if (field.Name != "Active")
                        {
                            PropertiesInHTML_TD_ForBlazorPageQuery += $@"@if (@{Table.Name.ToLower()}!.{field.Name})
{{
    <td>
        <span class=""badge rounded-pill bg-success"">ON</span>
    </td>
}}
else
{{
    <td>
        <span class=""badge rounded-pill bg-danger"">OFF</span>
    </td>
}}
                                        ";

                            PropertiesInHTML_Card_ForBlazorPageQuery += $@"@if (@{Table.Name.ToLower()}!.{field.Name})
{{
    <p>
        <b>{field.Name}: </b>
        <span class=""badge rounded-pill bg-success"">
            ON
        </span>
    </p>
}}
else
{{
    <p>
        <b>{field.Name}: </b>
        <span class=""badge rounded-pill bg-danger"">
            OFF
        </span>
    </p>
}}
                                        ";

                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""form-check form-switch"">
                        <input class=""form-check-input""
                               type=""checkbox""
                               name=""strict-search""
                               @bind=""{Table.Name}!.{field.Name}""
                               id=""{field.Name.ToLower()}"" />
                        <label class=""form-check-label""
                               for=""{field.Name.ToLower()}"">
                            {field.Name}
                        </label>
                    </div>
                    ";
                        }
                        break;
                    case 5: //Text: Basic

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""text""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 6: //Decimal

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.Decimal(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue.Replace(',', '.')}D, {field.MaxValue.Replace(',', '.')}D)]
        public decimal {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""numeric(18, 2)"")
                    .IsRequired(true);

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""number""
                               step=""0.1""
                               id=""{field.Name.ToLower()}""
                               min=""{field.MinValue}"" 
                               max=""{field.MaxValue}"" 
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 8: //Primary Key (Id)

                        PropertiesForEntity +=
$@"[Library.ModelAttributeValidator.Key(""{field.Name}"")]
        public int {field.Name} {{ get; set; }}
";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{Table.Name}Id</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{Table.Name}Id: </b>@{Table.Name.ToLower()}?.{Table.Name}Id</p>
                                        ";

                        break;
                    case 10: //DateTime

                        PropertiesForEntity +=
$@"[Library.ModelAttributeValidator.DateTime(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public DateTime {field.Name} {{ get; set; }}
";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""datetime"")
                    .IsRequired(true);

                ";

                        if (field.Name != "DateTimeCreation" && field.Name != "DateTimeLastModification")
                        {
                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                                class=""input-group input-group-static"">
                                {field.Name}
                        </label>
                        <input type=""datetime-local""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}""/>
                    </div>
                    ";
                        }
                        break;
                    case 11: //Time

                        PropertiesForEntity +=
$@"
    public TimeOnly {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""time(7)"")
                    .IsRequired(true);

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""time""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 13: //Foreign Key (Id): Options

                        throw new Exception("The Foreign Key (Id) Options property is not allowed in this generator");

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            
                        }
                        break;
                    case 14: //Text: HexColour

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.HexColour(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, ""{field.MinValue}"", ""{field.MaxValue}"")]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar(7)"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>
    <span style=""color:@{Table.Name.ToLower()}?.{field.Name};"">
        <b class=""fas fa-palette""></b>
        @{Table.Name.ToLower()}?.{field.Name}
    </span>
</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p style=""color:@{Table.Name.ToLower()}?.{field.Name};"">
    <b>{field.Name}: </b>
    <b class=""fas fa-palette""></b>
    @{Table.Name.ToLower()}?.{field.Name}
</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""color""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 15: //Text: TextArea

                        PropertiesForEntity +=
$@"        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""text"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<div><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</div>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <textarea rows=""10""
                            class=""form-control""
                            @bind=""{Table.Name}!.{field.Name}""
                            {(field.Nullable == true ? "" : "required")}
                            id=""{field.Name.ToLower()}"">
                        </textarea>
                    </div>
                    ";

                        break;
                    case 16: //Text: TextEditor 

                        throw new Exception("The TextEditor property is not allowed in this generator");

                        break;
                    case 17: //Text: Password

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""password""
                               id=""{field.Name.ToLower()}""
                               {(field.Nullable == true ? "" : "required")}
                               class=""form-control""
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 18: //Text: PhoneNumber

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
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
       href=""tel:@{Table.Name.ToLower()}?.{field.Name}"">
        <b class=""fas fa-phone""></b>
        @{Table.Name.ToLower()}?.{field.Name}
    </a>
</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
    href=""tel:@{Table.Name.ToLower()}?.{field.Name}"">
    <b>{field.Name}: </b>
    <b class=""fas fa-phone""></b>
    @{Table.Name.ToLower()}?.{field.Name}
</a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""tel""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 19: //Text: URL

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
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
       href=""@{Table.Name.ToLower()}?.{field.Name}""
       target=""_blank"">
        <b class=""fas fa-link""></b>
        @{Table.Name.ToLower()}?.{field.Name}
    </a>
</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
    href=""@{Table.Name.ToLower()}?.{field.Name}""
    target=""_blank"">
    <b>{field.Name}: </b>
    <b class=""fas fa-link""></b>
    @{Table.Name.ToLower()}?.{field.Name}
</a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""url""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 20: //Text: Email

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
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
       href=""mailto:@{Table.Name.ToLower()}?.{field.Name}"">
        <b class=""fas fa-envelope""></b>
        @{Table.Name.ToLower()}?.{field.Name}
    </a>
</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
    href=""mailto:@{Table.Name.ToLower()}?.{field.Name}"">
    <b>{field.Name}: </b>
    <b class=""fas fa-envelope""></b>
    @{Table.Name.ToLower()}?.{field.Name}
</a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""email""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}"" />
                    </div>
                    ";

                        break;
                    case 21: //Text: File

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
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
       href=""@{Table.Name.ToLower()}?.{field.Name}""
       download>
        <b class=""fas fa-download""></b>
        @{Table.Name.ToLower()}?.{field.Name}
    </a>
</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<a class=""nav-link text-info px-0""
    href=""@{Table.Name.ToLower()}?.{field.Name}""
    download>
    <b>{field.Name}: </b>
    <b class=""fas fa-download""></b>
    @{Table.Name.ToLower()}?.{field.Name}
</a>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <InputFile type=""file""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
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

            ProgressPercentFor{field.Name} = 100;
            ProgressBarColourFor{field.Name} = ""bg-success"";
            DisplayProgressFor{field.Name} = false;
        }}
        catch (Exception ex)
        {{
            MessageForForm = $@""There was a mistake. Try again.
                             Error message: {{ex.Message}}"";

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

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.String(""{field.Name}"", {(field.Nullable == true ? "false" : "true")}, {field.MinValue}, {field.MaxValue}, {(field.Regex == "" ? @"""""" : $@"""{field.Regex}""")})]
        public string? {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""varchar({field.MaxValue})"")
                    .IsRequired({(field.Nullable == true ? "false" : "true")});

                ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <input type=""text""
                               id=""{field.Name.ToLower()}""
                               class=""form-control""
                               {(field.Nullable == true ? "" : "required")}
                               @bind=""{Table.Name}!.{field.Name}""
                               data-toggle=""tags"" />
                    </div>
                    ";

                        break;
                    case 23: //Foreign Key (Id): DropDown

                        PropertiesForEntity +=
$@"        [Library.ModelAttributeValidator.Key(""{field.Name}"")]
        public int {field.Name} {{ get; set; }}
";

                        PropertiesForEntityConfiguration +=
$@"//{field.Name}
                entity.Property(e => e.{field.Name})
                    .HasColumnType(""int"")
                    .IsRequired(true);

                ";

                        PropertiesInHTML_Card_ForBlazorPageQuery += $@"<p><b>{field.Name}: </b>@{Table.Name.ToLower()}?.{field.Name}</p>
                                        ";

                        PropertiesInHTML_TD_ForBlazorPageQuery += $@"<td>@{Table.Name.ToLower()}?.{field.Name}</td>
                                        ";

                        if (field.Name != "UserCreationId" && field.Name != "UserLastModificationId")
                        {
                            PropertiesInHTML_BlazorNonQueryPage += $@"<!--{field.Name}-->
                    <div class=""mb-3"">
                        <label for=""{field.Name.ToLower()}""
                               class=""input-group input-group-static"">
                            {field.Name}
                        </label>
                        <select id=""{field.Name.ToLower()}""
                            class=""form-control""
                            @bind={Table.Name}.{field.Name}>
                        </select>
                    </div>
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
