using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class CSharpNETCore
    {
        public static string RazorPageFrontQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {

                string Content =
                $@"@page
@model {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Pages.{Table.Name}QueryPageModel
@{{

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}
    
//Stack: 11
//Last modification on: {DateTime.Now}

    Layout = ""_LayoutDashboard"";
}}
<!-- Header -->
<div class=""header bg-primary pb-6"">
    <div class=""container-fluid"">
        <!-- Header body -->
        <div class=""header-body"">
            <div class=""row align-items-center py-4"">
                <div class=""col-lg-6 col-7"">
                    <!-- Page title -->
                    <h2 id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-title-page"" class=""h2 text-white d-inline-block mb-0"">
                        Query {Table.Name.ToLower()}
                    </h2>
                    <!-- Breadcrumb -->
                    <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                        <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                            <li class=""breadcrumb-item"">
                                <a href=""/CMSCore/DashboardIndex""><i class=""fas fa-home""></i></a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""javascript:void(0)"">
                                    {Table.Area}
                                </a>
                            </li>
                            <li class=""breadcrumb-item active"" aria-current=""page"">
                                {Table.Name}<i class=""fas ml-2 fa-search""></i>
                            </li>
                        </ol>
                    </nav>
                </div>
                <div class=""col-lg-6 col-5 text-right"">
                    <!-- XL screens -->
                    <div class=""d-none d-xl-inline"">
                        <button type=""button"" class=""btn btn-secondary"" data-toggle=""modal"" data-target=""#modal-export-actions"">
                            <i class=""fas fa-file-export""></i> Export</button>
                        <button type=""button"" class=""btn btn-secondary"" data-toggle=""modal"" data-target=""#modal-massive-actions"">
                            <i class=""fas fa-rocket""></i> Massive actions 
                        </button>
                        <a href=""/{Table.Area}/{Table.Name}NonQueryPage?{Table.Name}Id=0"" class=""btn btn-secondary"">
                            <i class=""fas fa-plus""></i> Add
                        </a>
                    </div>
                    <!-- Other screens -->
                    <div class=""d-inline d-sm-inline d-md-inline d-lg-inline d-xl-none"">
                        <!-- Options in Dropdown-->
                        <div class=""dropdown"">
                            <a class=""btn btn-secondary"" href=""javascript:void(0)"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                <i class=""fas fa-cog""></i>
                            </a>
                            <div class=""dropdown-menu dropdown-menu-right dropdown-menu-arrow"">
                                <a class=""dropdown-item"" href=""javascript:void(0)"" data-toggle=""modal"" data-target=""#modal-export-actions"">
                                    Export <i class=""fas fa-file-export""></i>
                                </a>
                                <a class=""dropdown-item"" href=""javascript:void(0)"" data-toggle=""modal"" data-target=""#modal-massive-actions"">
                                    Massive actions <i class=""fas fa-rocket""></i>
                                </a>
                            </div>
                        </div>
                        <!-- Add button -->
                        <a href=""/{Table.Area}/{Table.Name}NonQueryPage?{Table.Name}Id=0"" class=""btn btn-secondary"">
                            <i class=""fas fa-plus""></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Page content -->
<div class=""container-fluid mt--6"">
    <div class=""row"">
        <div class=""col"">
            <!-- Card -->
            <div class=""card shadow"">
                <!-- Card header -->
                <div class=""card-header border-0"">
                    <div class=""row"">
                        <!-- Search Bar -->
                        <div class=""col-12 col-sm-12 col-md-8 col-lg-8 col-xl-8"">
                            <form>
                                <div class=""input-group input-group-merge input-group-alternative"">
                                    <div class=""input-group-prepend"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-button"">
                                        <span class=""input-group-text"">
                                            <i class=""fas fa-search""></i>
                                        </span>
                                    </div>
                                    <input id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-query-string"" class=""form-control font-weight-bolder"" type=""search"" placeholder=""Search..."">
                                </div>
                            </form>
                        </div>
                        <div class=""col-4 col-sm-4 col-md-4"">
                            <div class=""nav-wrapper d-none d-sm-none d-md-inline d-lg-inline d-xl-inline"">
                                <ul id=""tabs-icons-text"" class=""nav nav-pills nav-fill flex-column flex-md-row"" role=""tablist"">
                                    <!-- Table view button -->
                                    <li class=""nav-item"">
                                        <a id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-table-view-button"" class=""nav-link mb-sm-3 mb-md-0"" data-toggle=""tab"" href=""#tab-table"" role=""tab"" aria-controls=""tab-table"" aria-selected=""false"">
                                            <i class=""fas fa-table""></i>
                                        </a>
                                    </li>
                                    <!-- List view button -->
                                    <li class=""nav-item"">
                                        <a id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-list-view-button"" class=""nav-link mb-sm-3 mb-md-0 active"" data-toggle=""tab"" href=""#tab-list"" role=""tab"" aria-controls=""tab-list"" aria-selected=""true"">
                                            <i class=""fas fa-th-list""></i>
                                         </a>
                                    </li>
                                </ul>
                                <!-- Toggler -->
                                <input type=""hidden"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-view-toggler"" value=""List"" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Card body -->
                <div class=""card-body p-0 mb-4"">
                    <!-- Tab content -->
                    <div class=""tab-content"">
                        <div id=""tab-table"" class=""tab-pane fade"" role=""tabpanel"" aria-labelledby=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-table-view-button"">
                            <!-- Table View -->
                            <div class=""table-responsive"">
                                <table class=""table align-items-center table-flush"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-and-head-table""></table>
                            </div>
                            <div class=""row"">
                                <div class=""col-12"">
                                    <!-- Pagination in LG and XL Screens-->
                                    <nav aria-label=""..."" class=""d-none d-sm-none d-md-none d-lg-inline d-xl-inline"">
                                        <ul class=""pagination justify-content-center mb-0 mt-3 pagination-lg"">
                                            <li class=""page-item"">
                                                <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page-lg"" class=""page-link btn fas fa-angle-double-left""></button>
                                            </li>
                                            <li class=""page-item"">
                                                <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page-lg"" class=""page-link btn fas fa-angle-left""></button>
                                            </li>
                                            <li class=""page-item"">
                                                <button class=""btn btn-link mx-3"" disabled>
                                                    <strong id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-actual-page-number-lg"">
                                                        0
                                                    </strong> 
                                                    of 
                                                    <strong id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-total-pages-lg"">
                                                        0
                                                    </strong>
                                                </button>
                                            </li>
                                            <li class=""page-item"">
                                                <button class=""page-link btn fas fa-angle-right"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page-lg""></button>
                                            </li>
                                            <li class=""page-item"">
                                                <button class=""page-link btn fas fa-angle-double-right"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page-lg""></button>
                                            </li>
                                        </ul>
                                    </nav>
                                    <!-- Pagination in other Screens-->
                                    <nav aria-label=""..."" class=""d-inline d-sm-inline d-md-inline d-lg-none d-xl-none"">
                                        <ul class=""pagination justify-content-center mb-0 mt-3 pagination-sm"">
                                            <li class=""page-item"">
                                                <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page"" class=""page-link btn fas fa-angle-double-left""></button>
                                            </li>
                                            <li class=""page-item"">
                                                <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page"" class=""page-link btn fas fa-angle-left""></button>
                                            </li>
                                            <li class=""page-item"">
                                                <button class=""btn btn-link btn-sm mx-3"" disabled>
                                                    <strong id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-actual-page-number"">
                                                        0
                                                    </strong> 
                                                    of 
                                                    <strong id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-total-pages"">
                                                        0
                                                    </strong>
                                                </button>
                                            </li>
                                            <li class=""page-item"">
                                                <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page"" class=""page-link btn fas fa-angle-right""></button>
                                            </li>
                                            <li class=""page-item"">
                                                <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page"" class=""page-link btn fas fa-angle-double-right""></button>
                                            </li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                        <!-- List View -->
                        <div class=""tab-pane fade show active"" id=""tab-list"" role=""tabpanel"" aria-labelledby=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-list-view-button"">
                            <div id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-list""></div>
                            <div class=""row mx-2"">
                                <div class=""col-12 text-center"">
                                    <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-more-button-in-list"" class=""btn btn-link btn-block text-gray"">
                                        <i class=""fas fa-2x fa-chevron-down""></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Export actions in modal style -->
        <div class=""row"">
            <div class=""col-md-4 px-0"">
                <div class=""modal fade"" id=""modal-export-actions"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modal-export-actions"" aria-hidden=""true"">
                    <div class=""modal-dialog modal-secondary modal-dialog-centered modal-"" role=""document"">
                        <div class=""modal-content bg-gradient-secondary"">
                            <!-- Modal title -->
                            <div class=""modal-header"">
                                <h6 class=""modal-title text-primary"">Choose an exporting type <i class=""fas fa-file-export""></i></h6>
                            </div>
                            <!-- Modal body -->
                            <div class=""modal-body pt-0 pb-0"">
                                <form role=""form"">
                                    <h6 class=""text-primary text-sm"">Rows to export</h6>
                                    <div class=""form-group mb-3"">
                                        <div class=""custom-control custom-radio"">
                                            <input id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-rows-checked-checkbox"" name=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export"" type=""radio"" class=""custom-control-input"" checked>
                                            <label class=""custom-control-label"" for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-rows-checked-checkbox"">
                                                Just the rows checked
                                            </label>
                                        </div>
                                        <div class=""custom-control custom-radio"">
                                            <input id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-rows-all-checkbox"" name=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export"" type=""radio"" class=""custom-control-input"">
                                            <label class=""custom-control-label"" for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-rows-all-checkbox"">
                                                All
                                            </label>
                                        </div>
                                    </div>
                                    <h6 class=""text-primary text-sm"">Formats</h6>
                                    <div class=""form-group mb-3"">
                                        <!-- Export as PDF file button -->
                                        <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-as-pdf"" class=""btn btn-icon btn-primary"" type=""button"">
                                            <span class=""btn-inner--icon""><i class=""fas fa-file-pdf""></i></span>
                                            <span class=""btn-inner--text"">Export as PDF file (.pdf)</span>
                                        </button>
                                    </div>
                                    <div class=""form-group mb-3"">
                                        <!-- Export as Excel file button -->
                                        <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-as-excel"" class=""btn btn-icon btn-primary"" type=""button"">
                                            <span class=""btn-inner--icon""><i class=""fas fa-file-excel""></i></span>
                                            <span class=""btn-inner--text"">Export as Excel file (.xlsx)</span>
                                        </button>
                                    </div>
                                    <div class=""form-group mb-3"">
                                        <!-- Export as CSV file button -->
                                        <button id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-as-csv"" class=""btn btn-icon btn-primary"" type=""button"">
                                            <span class=""btn-inner--icon""><i class=""fas fa-file-csv""></i></span>
                                            <span class=""btn-inner--text"">Export as CSV file (.csv)</span>
                                        </button>
                                    </div>
                                </form>
                            </div>
                            <!-- Close button -->
                            <div class=""modal-footer pt-4"">
                                <p class=""text-primary"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message""><strong></strong></p>
                                <button type=""button"" class=""btn btn-outline-primary ml-auto"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-close-button"" data-dismiss=""modal"">
                                    Close
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Massive actions in modal style -->
        <div class=""row"">
            <div class=""col-md-4 px-0"">
                <div class=""modal fade"" id=""modal-massive-actions"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modal-massive-actions"" aria-hidden=""true"">
                    <div class=""modal-dialog modal-secondary modal-dialog-centered modal-"" role=""document"">
                        <div class=""modal-content bg-gradient-secondary"">
                            <!-- Modal title -->
                            <div class=""modal-header"">
                                <h6 class=""modal-title text-primary"">Choose a massive action <i class=""fas fa-rocket""></i></h6>
                            </div>
                            <!-- Modal body -->
                            <div class=""modal-body pt-0 pb-0"">
                                <form role=""form"">
                                    <h6 class=""text-primary text-sm"">Rows to select</h6>
                                    <div class=""form-group mb-3"">
                                        <div class=""custom-control custom-radio"">
                                            <input type=""radio"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-copy-rows-checked-checkbox"" name=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-massive-action"" class=""custom-control-input"" checked>
                                            <label class=""custom-control-label"" for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-copy-rows-checked-checkbox"">
                                                Just the rows checked
                                            </label>
                                        </div>
                                        <div class=""custom-control custom-radio"">
                                            <input type=""radio"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-copy-rows-all-checkbox"" name=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-massive-action"" class=""custom-control-input"">
                                            <label class=""custom-control-label"" for=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-copy-rows-all-checkbox"">
                                                All
                                            </label>
                                        </div>
                                    </div>
                                    <h6 class=""text-primary text-sm"">Actions</h6>
                                    <div class=""form-group mb-3"">
                                        <!-- Copy button -->
                                        <button class=""btn btn-icon btn-primary"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-massive-action-copy"" type=""button"">
                                            <span class=""btn-inner--icon""><i class=""far fa-copy""></i></span>
                                            <span class=""btn-inner--text"">Copy</span>
                                        </button>
                                    </div>
                                    <div class=""form-group m-0"">
                                        <!-- Delete button -->
                                        <button class=""btn btn-icon btn-danger"" id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-massive-action-delete"" type=""button"">
                                            <span class=""btn-inner--icon""><i class=""fas fa-trash""></i></span>
                                            <span class=""btn-inner--text"">Delete</span>
                                        </button>
                                    </div>
                                </form>
                            </div>
                            <!-- Close button -->
                            <div class=""modal-footer"">
                                <button type=""button"" class=""btn btn-outline-primary ml-auto"" data-dismiss=""modal"">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script src=""/dist/{Table.Name.ToLower()}jquery.bundle.js""></script>";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
