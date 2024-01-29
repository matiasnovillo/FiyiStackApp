using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string BlazorPageQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"
@page ""/{Table.Area}/{Table.Name}Page""

@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Repositories;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
@inject {Table.Name}Repository {Table.Name.ToLower()}Repository;

<PageTitle>Query {Table.Name} - {GeneratorConfigurationComponent.ProjectChosen.Name}</PageTitle>

<{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarVerticalDashboard lstMenuResult=""lstMenuResult""></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarVerticalDashboard>

<div class=""main-content position-relative max-height-vh-100 h-100"">
    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarHorizontalDashboard></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarHorizontalDashboard>
    <div class=""container-fluid px-2 px-md-4"">
        <div class=""page-header min-height-300 border-radius-xl mt-4""
             style=""background-image: url('assets/img/illustrations/Landscape2.jpg');"">
            <span class=""mask bg-gradient-primary opacity-6""></span>
        </div>
        <div class=""card card-body mx-3 mx-md-4 mt-n6"">
            <div class=""card-header mb-0 pb-0 bg-white"">
                <h1 class=""mb-3"">
                    Query {Table.Name.ToLower()}
                </h1>
                <NavLink class=""btn btn-outline-info"" href=""Dashboard"">
                    <span class=""fas fa-chevron-left"" aria-hidden=""true""></span>
                    &nbsp;Go back
                </NavLink>
                <NavLink class=""btn btn-success text-white"" href=""{Table.Area}/{Table.Name}Page/0"">
                    <span class=""fas fa-plus"" aria-hidden=""true""></span>
                    &nbsp;Create {Table.Name.ToLower()}
                </NavLink>
            </div>
            <div class=""card-body px-0"">
                @((MarkupString)Message)
                <div class=""row"">
                    <div class=""col-12 col-md-4"">
                        <!--Searchbox-->
                        <input type=""search"" @oninput=""SearchText""
                               class=""form-control""
                               placeholder=""Search {Table.Name.ToLower()} by {Table.Name}Id..."" />
                        <br />
                        <!--Strict or lax search-->
                        <div>
                            <h6><b>Strict or lax search</b></h6>
                            <div class=""form-check form-switch"">
                                <input class=""form-check-input""
                                       type=""checkbox""
                                       name=""strict-search""
                                       @bind=""checkStrict""
                                       id=""strict-search"" />
                                <label class=""form-check-label""
                                       for=""strict-search"">
                                    Strict search
                                </label>
                            </div>
                        </div>
                        <br />
                        <h6><b>View type</b></h6>
                        <div class=""btn-group mb-3"" role=""group"" aria-label=""btngroup"">
                            <button type=""button"" 
                                class=""btn bg-gradient-primary""
                                onclick=@(() => ChangeView(""table""))>
                                <i class=""fas fa-table""></i>
                                Table
                            </button>
                            <button type=""button"" 
                                class=""btn bg-gradient-primary""
                                onclick=@(() => ChangeView(""list""))>
                                <i class=""fas fa-th-list""></i>
                                Cards
                            </button>
                        </div>
                    </div>
                    <div class=""col-12 col-md-8"">
                        <div class=""row"">
                            <div class=""d-flex justify-content-end"">
                                <!--Export buttons-->
                                <button type=""button""
                                        @onclick=""ConvertToExcel""
                                        class=""btn btn-outline-info ml-4 mb-4"">
                                    <i class=""fas fa-file""></i>
                                    Export to Excel
                                </button>
                                <button type=""button""
                                        @onclick=""ConvertToCSV""
                                        class=""btn btn-outline-warning mb-4 mx-3"">
                                    <i class=""fas fa-file""></i>
                                    Export to CSV
                                </button>
                                <button type=""button""
                                        @onclick=""ConvertToPDF""
                                        class=""btn btn-outline-success mb-4"">
                                    <i class=""fas fa-file""></i>
                                    Export to PDF
                                </button>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""d-flex justify-content-end"">
                                <!--Download buttons-->
                                @if (ShowDownloadButtonForExcel)
                                {{
                                    <a class=""btn btn-info mb-4""
                                       href=""@DownloadPathForExcel""
                                       download>
                                        <i class=""fas fa-download""></i>
                                        Descargar
                                    </a>
                                }}
                                @if (ShowDownloadButtonForCSV)
                                {{
                                    <a class=""btn btn-warning mb-4 mx-3""
                                       href=""@DownloadPathForCSV""
                                       download>
                                        <i class=""fas fa-download""></i>
                                        Descargar
                                    </a>
                                }}
                                @if (ShowDownloadButtonForPDF)
                                {{
                                    <a class=""btn btn-success mb-4""
                                       href=""@DownloadPathForPDF""
                                       download>
                                        <i class=""fas fa-download""></i>
                                        Descargar
                                    </a>
                                }}
                            </div>
                        </div>
                    </div>
                </div>
                <!--Table-->
                <h6><b>Number of registers: @TotalRows</b></h6>
                @if (ChosenView == ""table"")
                {{
                    <table class=""table table-striped table-hover table-bordered table-responsive mt-4"">
                        <thead>
                            <tr>
                                {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_TH_ForBlazorPageQuery}
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            @if (paginated{Table.Name}DTO != null)
                            {{
                                @foreach ({Table.Name}? {Table.Name.ToLower()} in paginated{Table.Name}DTO.lst{Table.Name})
                                {{
                                    <tr>
                                        {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_TD_ForBlazorPageQuery}
                                        <td>
                                            <div class=""nav-item"">
                                                <button class=""btn btn-sm btn-outline-danger""
                                                        onclick=@(() => Delete({Table.Name.ToLower()}!.{Table.Name}Id))>
                                                    <span class=""fas fa-trash"" aria-hidden=""true""></span>
                                                </button>
                                            </div>
                                            <div class=""nav-item mt-2"">
                                                <a class=""btn btn-sm btn-outline-info""
                                                   href=""{Table.Area}/{Table.Name}Page/@{Table.Name.ToLower()}?.{Table.Name}Id"">
                                                    <span class=""fas fa-pen"" aria-hidden=""true""></span>
                                                </a>
                                            </div>
                                        </td>
                                    </tr>
                                }}
                            }}
                        </tbody>
                    </table>
                }}
                else
                {{
                    @if (paginated{Table.Name}DTO != null)      
                    {{
                        @foreach ({Table.Name}? {Table.Name.ToLower()} in paginated{Table.Name}DTO.lst{Table.Name})
                        {{
                            <div class=""card shadow-lg mt-2"">
                                <div class=""card-body"">
                                        {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_Card_ForBlazorPageQuery}
                                </div>
                                <div class=""card-footer text-body-secondary"">
                                    <div class=""row"">
                                        <div class=""col-10"">
                                            &nbsp;
                                        </div>
                                        <div class=""col-2"">
                                            <button class=""btn btn-lg btn-outline-danger""
                                                    onclick=@(() => Delete({Table.Name.ToLower()}!.{Table.Name}Id))>
                                                <span class=""fas fa-trash"" aria-hidden=""true""></span>
                                            </button>
                                            <a class=""btn btn-lg btn-outline-info""
                                                href=""{Table.Area}/{Table.Name}Page/@{Table.Name.ToLower()}?.{Table.Name}Id"">
                                                <span class=""fas fa-pen"" aria-hidden=""true""></span>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        }}
                    }}
                }}

                <nav aria-label=""Page navigation example"">
                    <ul class=""pagination justify-content-center"">
                        <li class=""page-item
                        @(paginated{Table.Name}DTO!.HasPreviousPage ? """" : ""disabled"")"">
                            <button class=""page-link""
                                    disabled=""@(!paginated{Table.Name}DTO.HasPreviousPage)""
                                    @onclick=""() => OnPreviousPage()"">
                                <i class=""fas fa-chevron-left""></i>
                            </button>
                        </li>
                        @for (int i = 1; i <= paginated{Table.Name}DTO.TotalPages; i++)
                        {{
                            int currentPage = i;
                            <li class=""page-item
                            @(i == paginated{Table.Name}DTO.PageIndex ? ""active"" : """")"">
                                <button class=""page-link""
                                        onclick=@(() => OnPageSelected(currentPage))>
                                    @i
                                </button>
                            </li>
                        }}
                        <li class=""page-item
                        @(paginated{Table.Name}DTO.HasNextPage ? """" : ""disabled"")"">
                            <button class=""page-link""
                                    disabled=""@(!paginated{Table.Name}DTO.HasNextPage)""
                                    @onclick=""() => OnNextPage()"">
                                <i class=""fas fa-chevron-right""></i>
                            </button>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>
    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard>
</div>

@code {{
    #region Properties
    public List<Menu> lstMenuResult {{ get; set; }} = [];

    public int TotalRows {{ get; set; }} = 0;

    public string? ChosenView {{ get; set; }}

    public bool checkStrict {{ get; set; }}

    public string TextToSearch {{ get; set; }} = """";

    public string Message {{ get; set; }} = """";

    public bool ShowDownloadButtonForExcel {{ get; set; }}
    public bool ShowDownloadButtonForPDF {{ get; set; }}
    public bool ShowDownloadButtonForCSV {{ get; set; }}

    public string? DownloadPathForExcel {{ get; set; }}
    public string? DownloadPathForPDF {{ get; set; }}
    public string? DownloadPathForCSV {{ get; set; }}

    public User User = new();

    public {Table.Name} {Table.Name} = new();

    paginated{Table.Name}DTO paginated{Table.Name}DTO = new();
    #endregion

    protected override void OnInitialized()
    {{
        try
        {{
            //Look for saved user in shared component, simulates a session
            User = StateContainer.User == null ? new() : StateContainer.User;

            lstMenuResult = [];

            paginated{Table.Name}DTO = new();
            paginated{Table.Name}DTO.lst{Table.Name} = [];

            if (User != null)
            {{
                if (User.UserId != 0)
                {{
                    //Logged user
                    if (User.RoleId != 1) //Only Root can access
                    {{
                        NavigationManager.NavigateTo(""403"");
                    }}

                    List<Menu> lstMenu = menuRepository
                                            .GetAll();

                    lstMenuResult = rolemenuRepository
                                        .GetAllByRoleId(User.RoleId, lstMenu);

                    paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginated(
                                                    """",
                                                    checkStrict,
                                                    1,
                                                    15);

                    TotalRows = {Table.Name.ToLower()}Repository
                                    .Count();

                    ChosenView = ""list"";
                }}
                else
                {{
                    //Not logged user

                    //Redirect to...
                    NavigationManager.NavigateTo(""Login"");
                }}
            }}
            else
            {{
                //Impossible
            }}

            base.OnInitialized();
        }}
        catch (Exception ex)
        {{
            Failure failure = new()
            {{
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 1,
                UserLastModificationId = 1,
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

    }}

    #region Events
    private async Task SearchText(ChangeEventArgs args)
    {{
        try
        {{
            //Basic configuration
            Message = """";

            TextToSearch = args.Value.ToString();

            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                        .GetAllBy{Table.Name}IdPaginated(
                                            TextToSearch,
                                            checkStrict,
                                            1,
                                            15);

            TotalRows = {Table.Name.ToLower()}Repository
                            .Count();

            //Re-render the page
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
        catch (Exception ex)
        {{
            Failure failure = new()
            {{
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 1,
                UserLastModificationId = 1,
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

    }}

    private async Task OnPreviousPage()
    {{
        if (paginated{Table.Name}DTO.HasPreviousPage)
        {{
            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                        .GetAllBy{Table.Name}IdPaginated(
                                            TextToSearch,
                                            checkStrict,
                                            (paginated{Table.Name}DTO.PageIndex - 1),
                                            paginated{Table.Name}DTO.PageSize);
        }}

        TotalRows = {Table.Name.ToLower()}Repository
                            .Count();

        //Re-render the page
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}

    private async Task OnPageSelected(int pageIndex)
    {{
        paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                            .GetAllBy{Table.Name}IdPaginated(
                                                TextToSearch,
                                                checkStrict,
                                                pageIndex,
                                                paginated{Table.Name}DTO.PageSize);

        TotalRows = {Table.Name.ToLower()}Repository
                        .Count();

        //Re-render the page
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}

    private async Task OnNextPage()
    {{
        if (paginated{Table.Name}DTO.HasNextPage)
        {{
            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                        .GetAllBy{Table.Name}IdPaginated(
                                            TextToSearch,
                                            checkStrict,
                                            (paginated{Table.Name}DTO.PageIndex + 1),
                                            paginated{Table.Name}DTO.PageSize);
        }}

        TotalRows = {Table.Name.ToLower()}Repository
                            .Count();

        //Re-render the page
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}

    private async Task ChangeView(string chosenView)
    {{
        ChosenView = chosenView;

        //Re-render the page
        await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
    }}

    private async Task Delete(int {Table.Name.ToLower()}Id)
    {{
        try
        {{
            {Table.Name.ToLower()}Repository.DeleteBy{Table.Name}Id({Table.Name.ToLower()}Id);

            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                        .GetAllBy{Table.Name}IdPaginated(
                                            TextToSearch,
                                            checkStrict,
                                            1,
                                            15);

            TotalRows = {Table.Name.ToLower()}Repository
                                .Count();

            TextToSearch = """";

            Message = $@""<div class=""""alert alert-success text-white font-weight-bold"""" role=""""alert"""">
                                Register deleted correctly
                            </div>"";

            //Re-render the page
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
        catch (Exception ex)
        {{
            Failure failure = new()
            {{
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 1,
                UserLastModificationId = 1,
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
    }}
    #endregion

    #region Conversions
    private async Task ConvertToExcel()
    {{
        try
        {{
            //Set initial state
            Message = """";

            using var Book = new XLWorkbook();

            DataTable dt{Table.Name} = new DataTable();
            dt{Table.Name}.TableName = ""{Table.Name}"";

            //We define another DataTable dt{Table.Name}Copy to avoid issue related to DateTime conversion
            DataTable dt{Table.Name}Copy = new DataTable();
            dt{Table.Name}Copy.TableName = ""{Table.Name}"";

            #region Define columns for dt{Table.Name}Copy
            {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.Properties_ForExcel_Converter_DefineDataColumns}
            #endregion

            dt{Table.Name} = {Table.Name.ToLower()}Repository.GetAllInDataTable();

            foreach (DataRow DataRow in dt{Table.Name}.Rows)
            {{
                dt{Table.Name}Copy.Rows.Add(DataRow.ItemArray);
            }}

            var Sheet = Book.Worksheets.Add(dt{Table.Name}Copy);

            Sheet.ColumnsUsed().AdjustToContents();

            DownloadPathForExcel = $@""wwwroot/Downloads/ExcelFiles/{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.xlsx"";
            Book.SaveAs(DownloadPathForExcel);

            //Delete wwwroot from path to download correctly
            DownloadPathForExcel = DownloadPathForExcel.Replace(""wwwroot"", """");

            ShowDownloadButtonForExcel = true;

            //Re-render the page
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);

        }}
        catch (Exception ex)
        {{
            Failure failure = new()
            {{
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 1,
                UserLastModificationId = 1,
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
    }}

    private async Task ConvertToCSV()
    {{
        try
        {{
            //Set initial state
            Message = """";

            List<{Table.Name}?> lst{Table.Name} = {Table.Name.ToLower()}Repository
                                    .GetAll();

            DownloadPathForCSV = $@""wwwroot/Downloads/CSVFiles/{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.csv"";

            using (var Writer = new StreamWriter(DownloadPathForCSV))
            using (var CsvWriter = new CsvWriter(Writer,
                CultureInfo.InvariantCulture))
            {{
                CsvWriter.WriteRecords(lst{Table.Name});
            }}

            //Delete wwwroot from path to download correctly
            DownloadPathForCSV = DownloadPathForCSV.Replace(""wwwroot"", """");

            ShowDownloadButtonForCSV = true;

            //Re-render the page
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);             
        }}
        catch (Exception ex)
        {{
            Failure failure = new()
            {{
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 1,
                UserLastModificationId = 1,
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
    }}

    private async Task ConvertToPDF()
    {{
        try
        {{
            //Set initial state
            Message = """";
            string ProjectName = ""{GeneratorConfigurationComponent.ProjectChosen.Name}"";
            string Table = ""{Table.Name}"";
            var Renderer = new HtmlToPdf();
            string RowsAsHTML = """";

            List<{Table.Name}> lst{Table.Name} = {Table.Name.ToLower()}Repository
                                    .GetAll();

            DownloadPathForPDF = $@""wwwroot/Downloads/PDFFiles/{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.pdf"";

            foreach ({Table.Name}? {Table.Name} in lst{Table.Name})
            {{
                RowsAsHTML += $@""{{{Table.Name}?.ToStringOnlyValuesForHTML()}}"";
            }}

            Renderer.RenderHtmlAsPdf($@""<table cellpadding=""""0"""" cellspacing=""""0"""" border=""""0"""" width=""""88%"""" style=""""width: 88% !important; min-width: 88%; max-width: 88%;"""">
    <tr>
    <td align=""""left"""" valign=""""top"""">
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#1a1a1a"""" style=""""font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #1a1a1a; font-size: 52px; line-height: 55px; font-weight: 300; letter-spacing: -1.5px;"""">{{ProjectName}}</span>
        </font>
        <div style=""""height: 25px; line-height: 25px; font-size: 23px;"""">&nbsp;</div>
        <font face=""""'Source Sans Pro', sans-serif"""" color=""""#4c4c4c"""" style=""""font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"""">
            <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #4c4c4c; font-size: 36px; line-height: 45px; font-weight: 300; letter-spacing: -1px;"""">Registers of {{Table}}</span>
        </font>
        <div style=""""height: 35px; line-height: 35px; font-size: 33px;"""">&nbsp;</div>
    </td>
    </tr>
</table>
<br>
<table cellpadding=""""0"""" cellspacing=""""0"""" border=""""0"""" width=""""100%"""" style=""""width: 100% !important; min-width: 100%; max-width: 100%;"""">
    <tr>
        {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.Properties_ForIronPDF_Converter}
    </tr>
    {{RowsAsHTML}}
</table>
<br>
<font face=""""'Source Sans Pro', sans-serif"""" color=""""#868686"""" style=""""font-size: 17px; line-height: 20px;"""">
    <span style=""""font-family: 'Source Sans Pro', Arial, Tahoma, Geneva, sans-serif; color: #868686; font-size: 17px; line-height: 20px;"""">Printed on: {{DateTime.Now}}</span>
</font>
"").SaveAs(DownloadPathForPDF);

            ShowDownloadButtonForPDF = true;

            //Delete wwwroot from path to download correctly
            DownloadPathForPDF = DownloadPathForPDF.Replace(""wwwroot"", """");

            //Re-render the page
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);

        }}
        catch (Exception ex)
        {{
            Failure failure = new()
            {{
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 1,
                UserLastModificationId = 1,
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

    }}
    #endregion
}}

";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
