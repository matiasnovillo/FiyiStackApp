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
                $@"@page ""/{Table.Area}/{Table.Name}Page""

@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Repositories;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Services;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
@inject {Table.Name}Repository {Table.Name.ToLower()}Repository;
@inject {Table.Name}Service {Table.Name.ToLower()}Service;

<PageTitle>Buscar {Table.Name} - {Table.Area}</PageTitle>

<{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.SideNav lstFoldersAndPages=""lstFoldersAndPages""></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.SideNav>

<div class=""main-content position-relative max-height-vh-100 h-100"">
    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarDashboard Pagina=""{Table.Name}""></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarDashboard>
    <div class=""container-fluid px-2 px-md-4"">
        <div class=""page-header min-height-300 border-radius-xl mt-4""
        style=""background-image: url('img/BasicCore/Landscape.jpg');"">
            <span class=""mask bg-gradient-dark opacity-6""></span>
        </div>
        <div class=""card mx-3 mx-md-4 mt-n6"">
            <!--CARD HEADER-->
            <div class=""card-header mb-0 pb-0"">
                <h3 class=""mb-3"">
                    Buscar {Table.Name.ToLower()}
                </h3>
                <NavLink class=""btn btn-outline-dark"" href=""Dashboard"">
                    <span class=""fas fa-chevron-left"" aria-hidden=""true""></span>
                    &nbsp;Volver
                </NavLink>
                <NavLink class=""btn btn-success text-white"" href=""{Table.Area}/{Table.Name}Page/0"">
                    <span class=""fas fa-plus"" aria-hidden=""true""></span>
                    &nbsp;Crear {Table.Name.ToLower()}
                </NavLink>
                <hr />
            </div>
            <!--CARD BODY-->
            <div class=""card-body px-3"">
                @((MarkupString)Message)
                <div class=""row"">
                    <div class=""col-12 col-md-4"">
                        <!--Searchbox-->
                        <div class=""input-group input-group-dynamic"">
                            <span class=""input-group-text"">
                                <i class=""fas fa-search"" aria-hidden=""true""></i>
                            </span>
                            <input class=""form-control"" 
                            @oninput=""SearchText""
                            placeholder=""Buscar {Table.Name.ToLower()} por {Table.Name}Id...""
                            type=""search"">
                        </div>
                        <br />
                        <!--Strict or lax search-->
                        <div>
                            <h6>
                                <b>
                                    Búsqueda estricta o laxa
                                    <button type=""button"" 
                                    class=""btn btn-outline-dark"" 
                                    data-bs-toggle-tooltip=""tooltip"" 
                                    data-bs-placement=""right"" 
                                    title=""Una búsqueda laxa es más flexible, permite errores y devuelve resultados más amplios, algo que una búsqueda estricta no permite"">
                                        <i class=""fas fa-circle-info""></i>
                                    </button>
                                </b>
                            </h6>
                            
                            <div class=""form-check form-switch"">
                                <input class=""form-check-input""
                                type=""checkbox""
                                name=""strict-search""
                                @bind=""CheckStrict""
                                id=""strict-search"" />
                                <label class=""form-check-label""
                                for=""strict-search"">
                                    Búsqueda estricta
                                </label>
                            </div>
                        </div>
                        <br/>
                        <!--View type-->
                        <h6>
                            <b>
                                Tipo de vista
                            </b>
                        </h6>
                        <div class=""btn-group mb-3"" role=""group"" aria-label=""btngroup"">
                            <button type=""button""
                            class=""btn btn-dark""
                            onclick=@(() => ChangeView(""table""))>
                                <i class=""fas fa-table""></i>
                                Tabla
                            </button>
                            <button type=""button""
                            class=""btn btn-dark""
                            onclick=@(() => ChangeView(""list""))>
                                <i class=""fas fa-th-list""></i>
                                Lista
                            </button>
                        </div>
                        <br />
                        <!--Registers per page-->
                        <h6>
                            <b>
                                Registros por página
                            </b>
                        </h6>
                        <div class=""dropdown"">
                            <button class=""btn btn-dark dropdown-toggle""
                            type=""button""
                            id=""dropdown-registers-per-page""
                            data-bs-toggle=""dropdown""
                            aria-expanded=""false"">
                                Ver @RegistersPerPage
                            </button>
                            <ul class=""dropdown-menu px-2 py-3"" aria-labelledby=""dropdown-registers-per-page"">
                                <li>
                                    <a class=""dropdown-item border-radius-md""
                                    href=""javascript:;""
                                    @onclick=""(() => ChangeRegistersPerPage(50))"">
                                        50
                                    </a>
                                </li>
                                <li>
                                    <button class=""dropdown-item border-radius-md""
                                    @onclick=""(() => ChangeRegistersPerPage(500))"">
                                        500
                                    </button>
                                </li>
                                <li>
                                    <a class=""dropdown-item border-radius-md""
                                    href=""javascript:;""
                                    @onclick=""(() => ChangeRegistersPerPage(5000))"">
                                        5.000
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class=""col-12 col-md-8"">
                        <div class=""row"">
                            <div class=""d-flex justify-content-start"">
                                <!--Import function-->
                                <button type=""button"" 
                                class=""btn btn-outline-dark mx-2"" 
                                data-bs-toggle=""modal""
                                data-bs-target=""#modal-import""
                                data-bs-placement=""bottom""
                                data-bs-toggle-tooltip=""tooltip""
                                title=""Importar"">
                                    <i class=""fas fa-file-import fa-xl""></i>
                                </button>
                                <div class=""modal fade""
                                     id=""modal-import""
                                     tabindex=""-1""
                                     aria-labelledby=""modal-import-title""
                                     aria-hidden=""true"">
                                    <div class=""modal-dialog"">
                                        <div class=""modal-content"">
                                            <div class=""modal-header"">
                                                <h5 class=""modal-title"" 
                                                id=""modal-import-title"">
                                                    Importar
                                                </h5>
                                            </div>
                                            <div class=""modal-body"">
                                                <form role=""form"">
                                                    <div class=""input-group input-group-static mb-3"">
                                                        <label for=""importingfile"">
                                                            Archivo a importar
                                                        </label>
                                                        <InputFile type=""file""
                                                        id=""importingfile""
                                                        class=""form-control""
                                                        OnChange=""@UploadImportingFile"" />
                                                        @{{
                                                            var ProgressCssForImportingFile = ""progress"" + (DisplayProgressForImportingFile ? """" : ""d-none"");
                                                            var ProgressWidthStyleForImportingFile = ProgressPercentForImportingFile + ""%"";
                                                        }}
                                                        <!--Progress bar-->
                                                        <div class=""@ProgressCssForImportingFile"">
                                                            <div class=""progress-bar progress-bar-striped progress-bar-animated @ProgressBarColourForImportingFile""
                                                            role=""progressbar"" style=""width:@ProgressWidthStyleForImportingFile""
                                                            area-valuenow=""@ProgressPercentForImportingFile""
                                                            aria-valuemin=""0""
                                                            aria-valuemax=""100"">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class=""form-group mb-3"">
                                                        <!-- Import from Excel button -->
                                                        <button class=""btn btn-icon btn-dark""
                                                        type=""button""
                                                        @onclick=""ImportExcel"">
                                                            <span class=""btn-inner--icon"">
                                                                <i class=""fas fa-file-excel""></i>
                                                            </span>
                                                            <span class=""btn-inner--text"">
                                                                Importar de archivo Excel
                                                            </span>
                                                        </button>
                                                    </div>
                                                </form>
                                                @((MarkupString)ImportingMessage)
                                            </div>
                                            <div class=""modal-footer justify-content-end"">
                                                <button type=""button"" 
                                                class=""btn btn-outline-dark mb-0"" 
                                                data-bs-dismiss=""modal"">
                                                    Cerrar
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--Export function-->
                                <button type=""button""
                                class=""btn btn-outline-dark mx-2""
                                data-bs-toggle=""modal""
                                data-bs-target=""#modal-export""
                                data-bs-placement=""bottom""
                                data-bs-toggle-tooltip=""tooltip""
                                title=""Exportar"">
                                    <i class=""fas fa-file-export fa-xl""></i>
                                </button>
                                <div class=""modal fade""
                                    id=""modal-export""
                                    tabindex=""-1"" 
                                    aria-labelledby=""modal-export-title"" 
                                    aria-hidden=""true"">
                                    <div class=""modal-dialog"">
                                        <div class=""modal-content"">
                                            <div class=""modal-header"">
                                                <h5 class=""modal-title"" 
                                                id=""modal-export-title"">
                                                    Exportar
                                                </h5>
                                            </div>
                                            <div class=""modal-body"">
                                                <form role=""form"">
                                                    <h6>
                                                        Registros a exportar
                                                    </h6>
                                                    <div class=""form-group mb-3"">
                                                        <div class=""custom-control custom-radio"">
                                                            <input name=""export"" 
                                                            type=""radio"" 
                                                            class=""custom-control-input"" 
                                                            checked
                                                            id=""export-just""
                                                            value=""just""
                                                            @onchange=""@(() => ExportationType = ""just"")"">
                                                            <label class=""custom-control-label"" 
                                                            for=""export-just"">
                                                                Sólo los registros seleccionados
                                                            </label>
                                                        </div>
                                                        <div class=""custom-control custom-radio"">
                                                            <input name=""export""
                                                            type=""radio"" 
                                                            class=""custom-control-input""
                                                            id=""export-all""
                                                            value=""all""
                                                            @onchange=""@(() => ExportationType = ""all"")"">
                                                            <label class=""custom-control-label"" 
                                                            for=""export-all"">
                                                                Todo
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <h6>
                                                        Formatos
                                                    </h6>
                                                    <!-- Export as PDF file button -->
                                                    <div class=""d-flex justify-content-start"">
                                                        <button class=""btn btn-icon btn-dark""
                                                        type=""button""
                                                        @onclick=""ExportToPDF"">
                                                            <span class=""btn-inner--icon"">
                                                                <i class=""fas fa-file-pdf""></i>
                                                            </span>
                                                            <span class=""btn-inner--text"">
                                                                Exportar como PDF
                                                            </span>
                                                        </button>
                                                        @if (DownloadPathForPDF != """")
                                                        {{
                                                            <a class=""btn btn-icon btn-success mx-3""
                                                            download
                                                            href=""@DownloadPathForPDF"">
                                                                Descargar
                                                            </a>
                                                        }}
                                                    </div>
                                                    <!-- Export as Excel file button -->
                                                    <div class=""d-flex justify-content-start"">
                                                        <button class=""btn btn-icon btn-dark""
                                                        type=""button""
                                                        @onclick=""ExportToExcel"">
                                                            <span class=""btn-inner--icon"">
                                                                <i class=""fas fa-file-excel""></i>
                                                            </span>
                                                            <span class=""btn-inner--text"">
                                                                Exportar como Excel
                                                            </span>
                                                        </button>
                                                        @if (DownloadPathForExcel != """")
                                                        {{
                                                            <a class=""btn btn-icon btn-success mx-3""
                                                            download
                                                            href=""@DownloadPathForExcel"">
                                                                Descargar
                                                            </a>
                                                        }}
                                                    </div>
                                                    <!-- Export as CSV file button -->
                                                    <div class=""d-flex justify-content-start"">
                                                        <button class=""btn btn-icon btn-dark""
                                                        type=""button""
                                                        @onclick=""ExportToCSV"">
                                                            <span class=""btn-inner--icon"">
                                                                <i class=""fas fa-file-csv""></i>
                                                            </span>
                                                            <span class=""btn-inner--text"">
                                                                Exportar como CSV
                                                            </span>
                                                        </button>
                                                        @if (DownloadPathForCSV != """")
                                                        {{
                                                            <a class=""btn btn-icon btn-success mx-3""
                                                            download
                                                            href=""@DownloadPathForCSV"">
                                                                Descargar
                                                            </a>
                                                        }}
                                                    </div>
                                                </form>
                                            </div>
                                            <div class=""modal-footer justify-content-end"">
                                                <button type=""button"" 
                                                class=""btn btn-outline-dark mb-0"" 
                                                data-bs-dismiss=""modal"">
                                                    Cerrar
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--Massive actions-->
                                <button type=""button""
                                disabled
                                class=""btn btn-outline-dark mx-2""
                                data-bs-toggle=""modal""
                                data-bs-target=""#modal-massive-actions""
                                data-bs-placement=""bottom""
                                data-bs-toggle-tooltip=""tooltip""
                                title=""Acciones masivas"">
                                    <i class=""fas fa-rocket fa-xl""></i>
                                </button>
                                <div class=""modal fade""
                                id=""modal-massive-actions""
                                tabindex=""-1""
                                aria-labelledby=""modal-massive-actions-title""
                                aria-hidden=""true"">
                                    <div class=""modal-dialog"">
                                        <div class=""modal-content"">
                                            <div class=""modal-header"">
                                                <h5 class=""modal-title""
                                                id=""modal-massive-actions-title"">
                                                    Acciones masivas
                                                </h5>
                                            </div>
                                            <div class=""modal-body"">
                                                <form role=""form"">
                                                    <h6>
                                                        Registros a seleccionar
                                                    </h6>
                                                    <div class=""form-group mb-3"">
                                                        <div class=""custom-control custom-radio"">
                                                            <input name=""massiveactions""
                                                            type=""radio""
                                                            class=""custom-control-input""
                                                            checked
                                                            id=""massiveactions-just""
                                                            @onchange=""@(() => MassiveActionType = ""just"")"">
                                                            <label class=""custom-control-label""
                                                            for=""massiveactions-just"">
                                                                Sólo los registros seleccionados
                                                            </label>
                                                        </div>
                                                        <div class=""custom-control custom-radio"">
                                                            <input name=""massiveactions""
                                                            type=""radio""
                                                            class=""custom-control-input""
                                                            id=""massiveactions-all""
                                                            @onchange=""@(() => MassiveActionType = ""all"")"">
                                                            <label class=""custom-control-label""
                                                            for=""massiveactions-all"">
                                                                Todo
                                                            </label>
                                                        </div>
                                                    </div>
                                                    <h6>
                                                        Acciones
                                                    </h6>
                                                    <div class=""form-group"">
                                                        <!-- Copy button -->
                                                        <button class=""btn btn-icon btn-dark""
                                                        type=""button""
                                                        @onclick=""Copy"">
                                                            <span class=""btn-inner--icon"">
                                                                <i class=""fas fa-copy""></i>
                                                            </span>
                                                            <span class=""btn-inner--text"">
                                                                Copiar
                                                            </span>
                                                        </button>
                                                    </div>
                                                    <div class=""form-group"">
                                                        <!-- Delete button -->
                                                        <button class=""btn btn-icon btn-dark""
                                                        type=""button""
                                                        @onclick=""Delete"">
                                                            <span class=""btn-inner--icon"">
                                                                <i class=""fas fa-trash""></i>
                                                            </span>
                                                            <span class=""btn-inner--text"">
                                                                Eliminar
                                                            </span>
                                                        </button>
                                                    </div>
                                                </form>
                                                @((MarkupString)MassiveActionMessage)
                                            </div>
                                            <div class=""modal-footer justify-content-end"">
                                                <button type=""button"" 
                                                class=""btn btn-outline-dark mb-0"" 
                                                data-bs-dismiss=""modal"">
                                                    Cerrar
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Number of registers-->
                <h6 class=""mt-3"">
                    <b>
                        Nº de registros: @TotalRows
                    </b>
                </h6>
                <!--Table-->
                @if (ChosenView == ""table"")
                {{
                    <div class=""table-responsive"">
                        <table class=""table table-striped table-hover table-bordered mt-4"">
                            <thead>
                                <tr>
                                    <th></th>
                                    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_TH_ForBlazorPageQuery}

                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                @if (paginated{Table.Name}DTO != null)
                                {{
                                    @for (int i = 0; i < paginated{Table.Name}DTO.lst{Table.Name}.Count(); i++)
                                    {{
                                        int {Table.Name.ToLower()}Id = @paginated{Table.Name}DTO.lst{Table.Name}[i]!.{Table.Name}Id;

                                        <tr>
                                            <td>
                                                <input type=""checkbox""
                                                @onchange=""(() => CheckList({Table.Name.ToLower()}Id))"" />
                                            </td>
                                            {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_TD_ForBlazorPageQuery}

                                            <td>
                                                <div class=""d-flex justify-content-start"">
                                                    <a class=""btn btn-sm btn-outline-info mx-2""
                                                       href=""{Table.Area}/{Table.Name}Page/@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{Table.Name}Id"">
                                                        <span class=""fas fa-pen"" aria-hidden=""true""></span>
                                                    </a>
                                                    <button class=""btn btn-outline-danger btn-sm toast-delete showtoast"">
                                                        <span class=""fas fa-trash"" aria-hidden=""true""></span>
                                                    </button>
                                                    <div class=""toast bg-gradient-dark fade p-2 mx-auto""
                                                         role=""alert""
                                                         aria-live=""assertive""
                                                         aria-atomic=""true"">
                                                        <div class=""toast-header border-0 bg-transparent"">
                                                            <i class=""fas fa-circle-xmark me-2 text-white""></i>
                                                            <span class=""me-auto font-weight-bold text-white"">Confirmar eliminación</span>
                                                            <i class=""fas fa-times text-md ms-3 cursor-pointer text-white closetoast"" data-bs-dismiss=""toast"" aria-label=""Close""></i>
                                                        </div>
                                                        <hr class=""horizontal light m-0"">
                                                        <div class=""toast-body text-white"">
                                                            ¿Esta seguro que desea borrar 
                                                            <br/>
                                                            este registro con ID @{Table.Name.ToLower()}Id?
                                                            <br />
                                                            Presione SI para borrar
                                                            <br />
                                                            <button class=""btn btn-outline-danger btn-sm mt-2 closetoast""
                                                                    onclick=@(() => Delete({Table.Name.ToLower()}Id))>
                                                                SI
                                                            </button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    }}
                                }}
                            </tbody>
                        </table>
                    </div>
                }}
                else
                {{
                    <!--List-->
                    @if (paginated{Table.Name}DTO != null)      
                    {{
                        @for (int i = 0; i < paginated{Table.Name}DTO.lst{Table.Name}.Count(); i++)
                        {{
                            int {Table.Name.ToLower()}Id = @paginated{Table.Name}DTO.lst{Table.Name}[i]!.{Table.Name}Id;

                            <div class=""card shadow-lg mt-2"">
                                <div class=""card-body"">
                                    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_Card_ForBlazorPageQuery}
                                </div>
                                <div class=""card-footer text-body-secondary"">
                                    <div class=""d-flex justify-content-end"">
                                        <style>
                                            input.larger-checkbox {{
                                                width: 60px;
                                                height: 30px;
                                            }}
                                        </style>
                                        <input class=""larger-checkbox""
                                                   type=""checkbox""
                                                   @onchange=""(() => CheckList({Table.Name.ToLower()}Id))"" />
                                        <a class=""btn btn-outline-info mx-3""
                                           href=""{Table.Area}/{Table.Name}Page/@paginated{Table.Name}DTO.lst{Table.Name}[i]?.{Table.Name}Id"">
                                            <span class=""fas fa-pen"" aria-hidden=""true""></span>
                                        </a>
                                        <button 
                                            class=""btn btn-outline-danger toast-delete showtoast"">
                                            <span class=""fas fa-trash"" aria-hidden=""true""></span>
                                        </button>
                                        <div class=""toast bg-gradient-dark fade p-2 mx-auto"" 
                                        role=""alert"" 
                                        aria-live=""assertive"" 
                                        aria-atomic=""true"">
                                            <div class=""toast-header border-0 bg-transparent"">
                                                <i class=""fas fa-circle-xmark me-2 text-white""></i>
                                                <span class=""me-auto font-weight-bold text-white"">Confirmar eliminación</span>
                                                <i class=""fas fa-times text-md ms-3 cursor-pointer text-white closetoast"" data-bs-dismiss=""toast"" aria-label=""Close""></i>
                                            </div>
                                            <hr class=""horizontal light m-0"">
                                            <div class=""toast-body text-white"">
                                                ¿Esta seguro que desea borrar este registro con ID @{Table.Name.ToLower()}Id? Presione SI para borrar
                                                <br/>
                                                <button class=""btn btn-outline-danger btn-sm mt-2 closetoast""
                                                        onclick=@(() => Delete({Table.Name.ToLower()}Id))>
                                                    SI
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        }}
                    }}
                }}
                <!--Pagination-->
                <nav aria-label=""Page navigation example"">
                    <ul class=""pagination justify-content-center mt-3"">
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

    <!-- Initialization of tooltip -->
    <script>
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle-tooltip=""tooltip""]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {{
            return new bootstrap.Tooltip(tooltipTriggerEl)
        }})
    </script>

    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FixedPlugin></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FixedPlugin>
    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard>

</div>

@code {{
    #region Properties
    public List<folderForDashboard> lstFoldersAndPages {{ get; set; }} = [];

    public int TotalRows {{ get; set; }} = 0;

    public string? ChosenView {{ get; set; }}

    public bool CheckStrict {{ get; set; }}

    public string? TextToSearch {{ get; set; }} = """";

    public string? Message {{ get; set; }} = """";

    public string? ExportationType {{ get; set; }} = ""just"";
    public string? MassiveActionType {{ get; set; }} = ""just"";

    public string? DownloadPathForExcel {{ get; set; }} = """";
    public string? DownloadPathForPDF {{ get; set; }} = """";
    public string? DownloadPathForCSV {{ get; set; }} = """";

    public User User = new();

    public {Table.Name} {Table.Name} = new();

    paginated{Table.Name}DTO paginated{Table.Name}DTO = new();

    public List<int> lst{Table.Name}Checked = [];

    public int RegistersPerPage {{ get; set; }} = 50;

    //Data for importing file
    public bool DisplayProgressForImportingFile {{ get; set; }} = false;
    public int ProgressPercentForImportingFile {{ get; set; }} = 0;
    public string ProgressTextForTextFile {{ get; set; }} = """";
    public string ProgressBarColourForImportingFile {{ get; set; }} = ""bg-info"";
    public string UploadPath {{ get; set; }} = """";
    public string ImportingMessage {{ get; set; }} = """";

    public string MassiveActionMessage {{ get; set; }} = """";
    #endregion

    protected override void OnInitialized()
    {{
        try
        {{
            //Look for saved user in shared component, simulates a session
            User = StateContainer.User == null ? new() : StateContainer.User;

            lstFoldersAndPages = [];

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

                    lstFoldersAndPages = rolemenuRepository
                                            .GetAllPagesAndFoldersForDashboardByRoleId(User.RoleId);

                    paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginated(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

                    TotalRows = paginated{Table.Name}DTO.TotalItems;

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

        }}
    }}

    #region Events
    private async Task ImportExcel()
    {{
        try
        {{
            if (!UploadPath.EndsWith("".xlsx""))
            {{
                ImportingMessage = $@""<div class=""""alert alert-warning text-white font-weight-bold"""" role=""""alert"""">
                            Solo se permiten archivos Excel (.xlsx)
                         </div>"";
                return;
            }}

            UploadPath = $@""wwwroot/{{UploadPath.Replace(""\\"",""/"")}}"";

            List<{Table.Name}> lst{Table.Name} = {Table.Name.ToLower()}Service.ImportExcel(UploadPath, User.UserId);

            foreach ({Table.Name} {Table.Name} in lst{Table.Name})
            {{
                {Table.Name.ToLower()}Repository.Add({Table.Name});
            }}

            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginated(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

            TotalRows = paginated{Table.Name}DTO.TotalItems;

            ChosenView = ""list"";

            ImportingMessage = $@""<div class=""""alert alert-success text-white font-weight-bold"""" role=""""alert"""">
                            Importación finalizada correctamente.
                         </div>"";
        }}
        catch (Exception ex)
        {{
            Message = $@""<div class=""""alert alert-danger text-white font-weight-bold"""" role=""""alert"""">
                            Hubo un error. Intente nuevamente. Mensaje del error: {{ex.Message}}
                         </div>"";
        }}
        finally
        {{
            //Re-render the page to show ScannedText
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
    }}

    private async void UploadImportingFile(InputFileChangeEventArgs e)
    {{

        try
        {{
            DisplayProgressForImportingFile = true;
            ProgressPercentForImportingFile = 80;
            ProgressBarColourForImportingFile = ""bg-info"";

            string path = Path.Combine(
                Environment.CurrentDirectory,
                ""wwwroot"",
                ""Uploads"",
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

            UploadPath = Result;

            ProgressPercentForImportingFile = 100;
            ProgressBarColourForImportingFile = ""bg-success"";
            DisplayProgressForImportingFile = false;
        }}
        catch (Exception ex)
        {{
            Message = $@""<div class=""""alert alert-danger text-white font-weight-bold"""" role=""""alert"""">
                            Hubo un error. Intente nuevamente. Mensaje del error: {{ex.Message}}
                         </div>"";

            ProgressPercentForImportingFile = 100;
            ProgressBarColourForImportingFile = ""bg-danger"";
        }}
        finally
        {{
            //Re-render the page to show ScannedText
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
    }}

    private async Task ChangeRegistersPerPage(int registersPerPage)
    {{
        try
        {{
            //Basic configuration
            Message = """";

            RegistersPerPage = registersPerPage;

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
                                            CheckStrict,
                                            1,
                                            RegistersPerPage);

            TotalRows = paginated{Table.Name}DTO.TotalItems;

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

    private async Task OnPreviousPage()
    {{
        try
        {{
            if (paginated{Table.Name}DTO.HasPreviousPage)
            {{
                paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                            .GetAllBy{Table.Name}IdPaginated(
                                                TextToSearch,
                                                CheckStrict,
                                                (paginated{Table.Name}DTO.PageIndex - 1),
                                                paginated{Table.Name}DTO.PageSize);
            }}

            TotalRows = paginated{Table.Name}DTO.TotalItems;
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

    private async Task OnPageSelected(int pageIndex)
    {{
        try
        {{
            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                            .GetAllBy{Table.Name}IdPaginated(
                                                TextToSearch,
                                                CheckStrict,
                                                pageIndex,
                                                paginated{Table.Name}DTO.PageSize);

            TotalRows = paginated{Table.Name}DTO.TotalItems;
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

    private async Task OnNextPage()
    {{
        try
        {{
            if (paginated{Table.Name}DTO.HasNextPage)
            {{
                paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                            .GetAllBy{Table.Name}IdPaginated(
                                                TextToSearch,
                                                CheckStrict,
                                                (paginated{Table.Name}DTO.PageIndex + 1),
                                                paginated{Table.Name}DTO.PageSize);
            }}

            TotalRows = paginated{Table.Name}DTO.TotalItems;
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
                                            CheckStrict,
                                            1,
                                            RegistersPerPage);

            TotalRows = paginated{Table.Name}DTO.TotalItems;

            TextToSearch = """";

            Message = $@""<div class=""""alert alert-success text-white font-weight-bold"""" role=""""alert"""">
                                Register deleted correctly
                            </div>"";
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

    private async Task CheckList(int {Table.Name.ToLower()}Id)
    {{
        try
        {{
            int[] lst{Table.Name}Id = {{ {Table.Name.ToLower()}Id }};

            foreach (int {Table.Name}Id in lst{Table.Name}Id)
            {{
                if (lst{Table.Name}Checked.Contains({Table.Name}Id))
                {{
                    lst{Table.Name}Checked.Remove({Table.Name}Id);
                }}
                else
                {{
                    lst{Table.Name}Checked.Add({Table.Name}Id);
                }}
            }}
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
    #endregion

    #region Exportations
    private async Task ExportToExcel()
    {{
        try
        {{
            //Set initial state
            Message = """";

            DownloadPathForExcel = $@""wwwroot/Downloads/ExcelFiles/{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.xlsx"";

            DataTable dt{Table.Name} = new();

            if (ExportationType == ""just"")
            {{
                dt{Table.Name} = {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdInDataTable(lst{Table.Name}Checked);
            }}
            else
            {{
                dt{Table.Name} = {Table.Name.ToLower()}Repository.GetAllInDataTable();
            }}

            {Table.Name.ToLower()}Service.ExportToExcel(DownloadPathForExcel,
            dt{Table.Name});

            //Delete wwwroot from path to download correctly
            DownloadPathForExcel = DownloadPathForExcel.Replace(""wwwroot"", """");
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

    private async Task ExportToCSV()
    {{
        try
        {{
            //Set initial state
            Message = """";

            DownloadPathForCSV = $@""wwwroot/Downloads/CSVFiles/{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.csv"";

            List<{Table.Name}?> lst{Table.Name} = [];

            if (ExportationType == ""just"")
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}Id(lst{Table.Name}Checked);
            }}
            else
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAll();
            }}

            {Table.Name.ToLower()}Service.ExportToCSV(DownloadPathForCSV, lst{Table.Name});

            //Delete wwwroot from path to download correctly
            DownloadPathForCSV = DownloadPathForCSV.Replace(""wwwroot"", """");            
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

    private async Task ExportToPDF()
    {{
        try
        {{
            //Set initial state
            Message = """";

            List<{Table.Name}?> lst{Table.Name} = [];

            if (ExportationType == ""just"")
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}Id(lst{Table.Name}Checked);
            }}
            else
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAll();
            }}

            DownloadPathForPDF = $@""wwwroot/Downloads/PDFFiles/{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.pdf"";

            {Table.Name.ToLower()}Service.ExportToPDF(DownloadPathForPDF, lst{Table.Name});

            //Delete wwwroot from path to download correctly
            DownloadPathForPDF = DownloadPathForPDF.Replace(""wwwroot"", """");
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
    #endregion

    #region Massive actions
    private async Task Copy()
    {{
        try
        {{
            //Set initial state
            Message = """";

            List<{Table.Name}?> lst{Table.Name} = [];

            if (MassiveActionType == ""just"")
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}Id(lst{Table.Name}Checked);
            }}
            else
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAll();
            }}

            foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
            {{
                {Table.Name.ToLower()}.{Table.Name}Id = 0;
                {Table.Name.ToLower()}Repository.Add({Table.Name.ToLower()});
            }}

            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginated(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

            TotalRows = paginated{Table.Name}DTO.TotalItems;

            ChosenView = ""list"";

            MassiveActionMessage = $@""<div class=""""alert alert-success text-white font-weight-bold"""" role=""""alert"""">
                            Proceso de copiado finalizado correctamente
                         </div>"";
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

    private async Task Delete()
    {{
        try
        {{
            //Set initial state
            Message = """";

            List<{Table.Name}?> lst{Table.Name} = [];

            if (MassiveActionType == ""just"")
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}Id(lst{Table.Name}Checked);
            }}
            else
            {{
                lst{Table.Name} = {Table.Name.ToLower()}Repository.GetAll();
            }}

            foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
            {{
                {Table.Name.ToLower()}Repository.DeleteBy{Table.Name}Id({Table.Name.ToLower()}.{Table.Name}Id);
            }}

            paginated{Table.Name}DTO = {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginated(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

            TotalRows = paginated{Table.Name}DTO.TotalItems;

            ChosenView = ""list"";

            MassiveActionMessage = $@""<div class=""""alert alert-success text-white font-weight-bold"""" role=""""alert"""">
                            Proceso de eliminado finalizado correctamente
                         </div>"";
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
    #endregion
}}

";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
