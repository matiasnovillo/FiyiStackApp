using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class CSharpNETCore
    {
        public static string RazorPageFrontNonQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content = $@"@page
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Models
@model {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Pages.{Table.Name}NonQueryPageModel
@{{
    Layout = ""_LayoutDashboard"";

    string NonQueryText = """";
    string NonQueryIcon = """";

    int {Table.Name}Id;
    {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForRazorPageFrontNonQuery_Part1}

    if(HttpContext.Request.QueryString.Value.Contains(""?{Table.Name}Id=0""))
    {{
        NonQueryText = ""Add"";
        NonQueryIcon = ""fas fa-plus"";

        {Table.Name}Id = 0;
        {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForRazorPageFrontNonQuery_Part2}
    }}
    else
    {{
        NonQueryText = ""Edit"";
        NonQueryIcon = ""fas fa-pen"";

        {Table.Name}Model {Table.Name}Model = new {Table.Name}Model().Select1By{Table.Name}IdToModel
        (Convert.ToInt32(HttpContext.Request.QueryString.Value.Replace(""?{Table.Name}Id="","""")));

        {Table.Name}Id = {Table.Name}Model.{Table.Name}Id;
        {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForRazorPageFrontNonQuery_Part3}
    }}

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}
    
//Stack: 11
//Last modification on: {DateTime.Now}

}}
<!-- Header -->
<div class=""header bg-primary pb-6"">
    <div class=""container-fluid"">
        <!-- Header body -->
        <div class=""header-body"">
            <div class=""row align-items-center py-4"">
                <div class=""col-lg-6 col-7"">
                    <!-- Title -->
                    <h2 class=""h2 text-white d-inline-block mb-0"">
                        @NonQueryText 
                        {Table.Name.ToLower()}
                    </h2>
                    <input type=""hidden"" 
                        id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{Table.Name.ToLower()}id-input"" 
                        value=""@{Table.Name}Id""/>
                    <!-- Breadcrumb -->
                    <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                        <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                            <li class=""breadcrumb-item"">
                                <a href=""/CMSCore/DashboardIndex"">
                                    <i class=""fas fa-home""></i>
                                </a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""javascript:void(0)"">
                                    {Table.Area}
                                </a>
                            </li>
                            <li class=""breadcrumb-item"">
                                <a href=""javascript:void(0)"">
                                    {Table.Name}
                                 </a>
                            </li>
                            <li class=""breadcrumb-item active"" aria-current=""page"">
                                <i class=""@NonQueryIcon""></i>
                            </li>
                        </ol>
                    </nav>
                </div>
                <div class=""col-lg-6 col-5 text-right"">
                    <!-- XL Screens -->
                    <div class=""d-none d-xl-inline"">
                        <a href=""/{Table.Area}/{Table.Name}QueryPage"" class=""btn btn-secondary"">
                            <i class=""fas fa-angle-left""></i> Go back
                        </a>
                    </div>
                    <!-- Other Screens -->
                    <div class=""d-inline d-sm-inline d-md-inline d-lg-inline d-xl-none"">
                        <a href=""/{Table.Area}/{Table.Name}QueryPage"" class=""btn btn-secondary"">
                            <i class=""fas fa-angle-left""></i>
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
            <div class=""card"">
                <!-- Card body -->
                <div class=""card-body"">
                    <form class=""needs-validation"" novalidate>
                        { GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForRazorPageFrontNonQuery_InHTMLTag}
                        <!-- Buttons -->
                        <div class=""row justify-content-between"">
                            <button class=""btn btn-primary text-nowrap ml-3 mt-4"" 
                                type=""submit"">
                                    <i class=""@NonQueryIcon""></i> 
                                    @NonQueryText
                            </button>
                            <a href=""/{Table.Area}/{Table.Name}QueryPage"" 
                                class=""btn btn-outline-primary col-auto mr-3 mt-4 text-nowrap"">
                                    <i class=""fas fa-angle-left""></i> 
                                    Go back
                            </a>
                        </div>
                    </form>
                </div>
            </div>
            <!-- Card footer -->
            <div class=""card-footer py-2"">
            </div>
        </div>
    </div>
</div>

<!-- ForeignKeyDropDown selector in Modal style -->
<div class=""row"">
    <div class=""col-md-4"">
        <!-- Modal -->
        <div class=""modal fade"" id=""modal-foreign-key-code-selector"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modal-foreign-key-selector"" aria-hidden=""true"">
            <div class=""modal-dialog modal-secondary modal-dialog-centered modal-"" role=""document"">
                <!-- Modal content -->
                <div class=""modal-content bg-gradient-secondary"">
                    <div class=""modal-header"">
                        <h6 class=""modal-title text-primary"">
                            Choose a ForeignKeyDropDown value <i class=""fas fa-hashtag""></i>
                         </h6>
                    </div>
                    <div class=""modal-body"">
                        <form role=""form"">
                            <div class=""form-group"">
                                <div class=""input-group input-group-merge input-group-alternative"">
                                    <select id=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-foreignkeydropdown-select"" class=""form-control"" data-toggle=""select"" title=""Simple select"" data-live-search=""true"" data-live-search-placeholder=""Choose value"" data-allow-reset=""true"">
                                        <option value=""0""></option> <!--This must be empty-->
                                    </select>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-outline-primary ml-auto"" data-dismiss=""modal"">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Phone code Selector in Modal style -->
<div class=""row"">
    <div class=""col-md-4"">
        <div class=""modal fade"" id=""modal-phone-code-selector"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modal-phone-code-selector"" aria-hidden=""true"">
            <div class=""modal-dialog modal-secondary modal-dialog-centered modal-"" role=""document"">
                <div class=""modal-content bg-gradient-secondary"">
                    <div class=""modal-header"">
                        <h6 class=""modal-title text-primary"">Choose your phone code <i class=""fas fa-globe-americas""></i></h6>
                    </div>
                    <div class=""modal-body"">
                        <form role=""form"">
                            <div class=""form-group"">
                                <div class=""input-group input-group-merge input-group-alternative"">
                                    <select class=""form-control"" data-toggle=""select"" title=""Simple select"" data-live-search=""true"" data-live-search-placeholder=""Country (+Code)"" data-allow-reset=""true"">
                                        <option></option> <!--This must be empty-->
                                        <option>Argentina (+54)</option>
                                        <option>USA (+1)</option>
                                    </select>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-outline-primary ml-auto"" data-dismiss=""modal"">Close</button>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>

<script src=""/js/BasicCore/jquery-3.6.1.min.js""></script>
<script src=""/assets/vendor/quill/dist/quill.min.js""></script>
<script src=""/js/{Table.Area}/{Table.Name}/jQuery/{Table.Name}NonQuery_jQuery.js""></script>
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
