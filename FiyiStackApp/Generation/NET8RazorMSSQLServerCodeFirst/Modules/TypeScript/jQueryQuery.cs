using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class TypeScript
    {
        public static string jQueryQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            string Content = $@"//Import libraries to use
import {{ {Table.Name}Model }} from ""../../{Table.Name}/TsModels/{Table.Name}_TsModel"";
import {{ {Table.Name.ToLower()}SelectAllPaged }} from ""../DTOs/{Table.Name.ToLower()}SelectAllPaged"";
import * as $ from ""jquery"";
import * as Rx from ""rxjs"";
import {{ ajax }} from ""rxjs/ajax"";
import {{ Ajax }} from ""../../../Library/Ajax"";
import ""bootstrap-notify"";

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

//Stack: 10

//Last modification on: {DateTime.Now}

//Set default values
let LastTopDistance: number = 0;
let QueryString: string = """";
let ActualPageNumber: number = 1;
let RowsPerPage: number = 50;
let SorterColumn: string | undefined = """";
let SortToggler: boolean = false;
let TotalPages: number = 0;
let TotalRows: number = 0;
let ViewToggler: string = ""List"";
let ScrollDownNSearchFlag: boolean = false;

class {Table.Name}Query {{
    static SelectAllPagedToHTML(request_{Table.Name.ToLower()}SelectAllPaged: {Table.Name.ToLower()}SelectAllPaged) {{
        //Used for list view
        $(window).off(""scroll"");

        //Load some part of table
        var TableContent: string = `<thead class=""thead-light"">
    <tr>
        <th scope=""col"">
            <div>
                <input id=""{Table.Name.ToLower()}-table-check-all"" type=""checkbox"">
            </div>
        </th>
        {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForjQuery_TableFill_FirstPart}
        <th scope=""col""></th>
    </tr>
</thead>
<tbody>`;

        var ListContent: string = ``;

        {Table.Name}Model.SelectAllPaged(request_{Table.Name.ToLower()}SelectAllPaged).subscribe(
            {{
                next: newrow => {{
                    //Only works when there is data available
                    if (newrow.status != 204) {{

                        const response_{Table.Name.ToLower()}Query = newrow.response as {Table.Name.ToLower()}SelectAllPaged;

                        //Set to default values if they are null
                        QueryString = response_{Table.Name.ToLower()}Query.QueryString ?? """";
                        ActualPageNumber = response_{Table.Name.ToLower()}Query.ActualPageNumber ?? 0;
                        RowsPerPage = response_{Table.Name.ToLower()}Query.RowsPerPage ?? 0;
                        SorterColumn = response_{Table.Name.ToLower()}Query.SorterColumn ?? """";
                        SortToggler = response_{Table.Name.ToLower()}Query.SortToggler ?? false;
                        TotalRows = response_{Table.Name.ToLower()}Query.TotalRows ?? 0;
                        TotalPages = response_{Table.Name.ToLower()}Query.TotalPages ?? 0;

                        //Query string
                        $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-query-string"").attr(""placeholder"", `Search... (${{TotalRows}} records)`);
                        //Total pages of pagination
                        $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-total-pages-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-total-pages"").html(TotalPages.toString());
                        //Actual page number of pagination
                        $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-actual-page-number-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-actual-page-number"").html(ActualPageNumber.toString());
                        //If we are at the final of book disable next and last buttons in pagination
                        if (ActualPageNumber === TotalPages) {{
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page"").attr(""disabled"", ""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page"").attr(""disabled"", ""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-more-button-in-list"").html("""");
                        }}
                        else {{
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page"").removeAttr(""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page"").removeAttr(""disabled"");
                            //Scroll arrow for list view
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-more-button-in-list"").html(""<i class='fas fa-2x fa-chevron-down'></i>"");
                        }}
                        //If we are at the begining of the book disable previous and first buttons in pagination
                        if (ActualPageNumber === 1) {{
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page"").attr(""disabled"", ""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page"").attr(""disabled"", ""disabled"");
                        }}
                        else {{
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page"").removeAttr(""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page"").removeAttr(""disabled"");
                        }}
                        //If book is empty set to default pagination values
                        if (response_{Table.Name.ToLower()}Query?.lst{Table.Name}Model?.length === 0) {{
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page"").attr(""disabled"", ""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page"").attr(""disabled"", ""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page"").attr(""disabled"", ""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page"").attr(""disabled"", ""disabled"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-total-pages-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-total-pages"").html(""1"");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-actual-page-number-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-actual-page-number"").html(""1"");
                        }}
                        //Read data book
                        response_{Table.Name.ToLower()}Query?.lst{Table.Name}Model?.forEach(row => {{

                            TableContent += `<tr>
    <!-- Checkbox -->
    <td>
        <div>
            <input class=""{Table.Name.ToLower()}-table-checkbox-for-row"" value=""${{row.{Table.Name}Id}}"" type=""checkbox"">
        </div>
    </td>
    <!-- Data -->
    {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForjQuery_TableFill_SecondtPart}
    <!-- Actions -->
    <td class=""text-right"">
        <a class=""btn btn-icon-only text-primary"" href=""/{Table.Area}/{Table.Name}NonQueryPage?{Table.Name}Id=${{row.{Table.Name}Id}}"" role=""button"" data-toggle=""tooltip"" data-original-title=""Edit"">
            <i class=""fas fa-edit""></i>
        </a>
        <div class=""dropdown"">
            <button class=""btn btn-icon-only text-danger"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                <i class=""fas fa-trash""></i>
            </button>
            <div class=""dropdown-menu dropdown-menu-right dropdown-menu-arrow"">
                <button class=""dropdown-item text-danger {Table.Area.ToLower()}-{Table.Name.ToLower()}-table-delete-button"" value=""${{row.{Table.Name}Id}}"" type=""button"">
                    <i class=""fas fa-exclamation-triangle""></i> Yes, delete
                </button>
            </div>
        </div>
        <div class=""dropdown"">
            <button class=""btn btn-sm btn-icon-only text-primary"" href=""#"" type=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                <i class=""fas fa-ellipsis-v""></i>
            </button>
            <div class=""dropdown-menu dropdown-menu-right dropdown-menu-arrow"">
                <button type=""button"" class=""dropdown-item {Table.Area.ToLower()}-{Table.Name.ToLower()}-table-copy-button"" value=""${{row.{Table.Name}Id}}"">
                    <i class=""fas fa-copy text-primary""></i>&nbsp;Copy
                </button>
            </div>
        </div>
    </td>
</tr>`;

                            ListContent += `<div class=""row mx-2"">
    <div class=""col-sm"">
        <div class=""card bg-gradient-primary mb-2"">
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col text-truncate"">
                        {GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForjQuery_ListFill}
                    </div>
                    <div class=""col-auto"">
                    </div>
                </div>
                <!-- Actions -->
                <div class=""row"">
                    <div class=""col"">
                        <div class=""justify-content-end text-right mt-2"">
                            <div class=""mb-2"">
                                <a class=""{Table.Area.ToLower()}-{Table.Name.ToLower()}-checkbox-list list-row-unchecked icon icon-shape bg-white icon-sm rounded-circle shadow"" href=""javascript:void(0)"" role=""button"" data-toggle=""tooltip"" data-original-title=""Check"">
                                    <i class=""fas fa-circle text-white""></i>
                                </a>
                                <input type=""hidden"" value=""${{row.{Table.Name}Id}}""/>
                            </div>
                            <a class=""icon icon-shape bg-white icon-sm rounded-circle shadow"" href=""/{Table.Area}/{Table.Name}NonQueryPage?{Table.Name}Id=${{row.{Table.Name}Id}}"" role=""button"" data-toggle=""tooltip"" data-original-title=""edit"">
                                <i class=""fas fa-edit text-primary""></i>
                            </a>
                            <div class=""dropup"">
                                <a class=""icon icon-shape bg-white icon-sm text-primary rounded-circle shadow"" href=""javascript:void(0)"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                    <i class=""fas fa-ellipsis-v""></i>
                                </a>
                                <div class=""dropdown-menu dropdown-menu-right dropdown-menu-arrow"">
                                    <button value=""${{row.{Table.Name}Id}}"" class=""dropdown-item text-primary {Table.Area.ToLower()}-{Table.Name.ToLower()}-list-copy-button"" type=""button"">
                                        <i class=""fas fa-copy""></i>&nbsp;Copy
                                    </button>
                                    <button value=""${{row.{Table.Name}Id}}"" class=""dropdown-item text-danger {Table.Area.ToLower()}-{Table.Name.ToLower()}-list-delete-button"" type=""button"">
                                        <i class=""fas fa-trash""></i>&nbsp;Delete
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>`;
                        }})

                        //If view table is activated, clear table view, if not, clear list view
                        if (ViewToggler === ""Table"") {{
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-and-head-table"").html("""");
                            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-and-head-table"").html(TableContent);
                        }}
                        else {{
                            //Used for list view
                            if (ScrollDownNSearchFlag) {{
                                $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-list"").append(ListContent);
                                ScrollDownNSearchFlag = false;
                            }}
                            else {{
                                //Clear list view
                                $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-list"").html("""");
                                $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-list"").html(ListContent);
                            }}
                            }}
                    }}
                    else {{
                        //ERROR
                        // @ts-ignore
                        $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""No registers found"" }}, {{ type: ""warning"", placement: {{ from: ""bottom"", align: ""center"" }} }});
                    }}
                }},
                complete: () => {{
                    //Execute ScrollDownNSearch function when the user scroll the page
                    $(window).on(""scroll"", ScrollDownNSearch);

                    //Add final content to TableContent
                    TableContent += `</tbody>
                                </table>`;

                    //Check button inside list view
                    $("".{Table.Area.ToLower()}-{Table.Name.ToLower()}-checkbox-list"").on(""click"", function (e) {{
                        //Toggler
                        if ($(this).hasClass(""list-row-checked"")) {{
                            $(this).html(`<a class=""icon icon-shape bg-white icon-sm rounded-circle shadow"" href=""javascript:void(0)"" role=""button"" data-toggle=""tooltip"" data-original-title=""check"">
                                                            <i class=""fas fa-circle text-white""></i>
                                                        </a>`);
                            $(this).removeClass(""list-row-checked"").addClass(""list-row-unchecked"");
                        }}
                        else {{
                            $(this).html(`<a class=""icon icon-shape bg-white icon-sm text-primary rounded-circle shadow"" href=""javascript:void(0)"" role=""button"" data-toggle=""tooltip"" data-original-title=""check"">
                                                            <i class=""fas fa-check""></i>
                                                        </a>`);
                            $(this).removeClass(""list-row-unchecked"").addClass(""list-row-checked"");
                        }}
                    }});

                    //Check all button inside table
                    $(""#{Table.Name.ToLower()}-table-check-all"").on(""click"", function (e) {{ 
                        //Toggler
                        if ($(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row"").is("":checked"")) {{
                            $(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row"").removeAttr(""checked"");
                        }}
                        else {{
                            $(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row"").attr(""checked"", ""checked"");
                        }}
                    }});

                    //Buttons inside head of table
                    $(""tr th button"").one(""click"", function (e) {{
                        //Toggler
                        if (SorterColumn == $(this).attr(""value"")) {{
                            SorterColumn = """";
                            SortToggler = true;
                        }}
                        else {{
                            SorterColumn = $(this).attr(""value"");
                            SortToggler = false;
                        }}

                        ValidateAndSearch();
                    }});

                    //Delete button in table and list
                    $(""div.dropdown-menu button.{Table.Area.ToLower()}-{Table.Name.ToLower()}-table-delete-button, div.dropdown-menu button.{Table.Area.ToLower()}-{Table.Name.ToLower()}-list-delete-button"").on(""click"", function (e) {{
                        let {Table.Name}Id = $(this).val();
                        {Table.Name}Model.DeleteBy{Table.Name}Id({Table.Name}Id).subscribe({{
                            next: newrow => {{
                            }},
                            complete: () => {{
                                //SUCCESS
                                // @ts-ignore
                                $.notify({{ icon: ""fas fa-check"", message: ""Row deleted successfully"" }}, {{ type: ""success"", placement: {{ from: ""bottom"", align: ""center"" }} }});

                                ValidateAndSearch();
                            }},
                            error: err => {{
                                //ERROR
                                // @ts-ignore
                                $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to delete data"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
                                console.log(err);
                            }}
                        }});
                    }});

                    //Copy button in table and list
                    $(""div.dropdown-menu button.{Table.Area.ToLower()}-{Table.Name.ToLower()}-table-copy-button, div.dropdown-menu button.{Table.Area.ToLower()}-{Table.Name.ToLower()}-list-copy-button"").on(""click"", function (e) {{
                        let {Table.Name}Id = $(this).val();
                        {Table.Name}Model.CopyBy{Table.Name}Id({Table.Name}Id).subscribe({{
                            next: newrow => {{
                            }},
                            complete: () => {{
                                //SUCCESS
                                // @ts-ignore
                                $.notify({{ icon: ""fas fa-check"", message: ""Row copied successfully"" }}, {{ type: ""success"", placement: {{ from: ""bottom"", align: ""center"" }} }});

                                ValidateAndSearch();
                            }},
                            error: err => {{
                                //ERROR
                                // @ts-ignore
                                $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to copy data"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
                                console.log(err);
                            }}
                        }});
                    }});
                }},
                error: err => {{
                    //ERROR
                    // @ts-ignore
                    $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to get data"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
                    console.log(err);
                }}
            }});
    }}
}}

function ValidateAndSearch() {{

    var _{Table.Name.ToLower()}SelectAllPaged: {Table.Name.ToLower()}SelectAllPaged = {{
        QueryString,
        ActualPageNumber,
        RowsPerPage,
        SorterColumn,
        SortToggler,
        TotalRows,
        TotalPages
    }};

    {Table.Name}Query.SelectAllPagedToHTML(_{Table.Name.ToLower()}SelectAllPaged);
}}

//LOAD EVENT
if ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-title-page"").html().includes(""Query {Table.Name.ToLower()}"")) {{
    //Set to default values
    QueryString = """";
    ActualPageNumber = 1;
    RowsPerPage = 50;
    SorterColumn = ""{Table.Name}Id"";
    SortToggler = false;
    TotalRows = 0;
    TotalPages = 0;
    ViewToggler = ""List"";
    //Disable first and previous links in pagination
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page"").attr(""disabled"", ""disabled"");
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page"").attr(""disabled"", ""disabled"");
    //Hide messages
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html("""");

    ValidateAndSearch();
}}
//CLICK, SCROLL AND KEYBOARD EVENTS
//Search button
$($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-button"")).on(""click"", function () {{
    ValidateAndSearch();
}});

//Query string
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-query-string"").on(""change keyup input"", function (e) {{
    //If undefined, set QueryString to """" value
    QueryString = ($(this).val()?.toString()) ?? """" ;
    ValidateAndSearch();
}});

//First page link in pagination
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-first-page"").on(""click"", function (e) {{
    ActualPageNumber = 1;
    ValidateAndSearch();
}});

//Previous page link in pagination
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-previous-page"").on(""click"", function (e) {{
    ActualPageNumber -= 1;
    ValidateAndSearch();
}});

//Next page link in pagination
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-next-page"").on(""click"", function (e) {{
    ActualPageNumber += 1;
    ValidateAndSearch();
}});

//Last page link in pagination
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page-lg, #{Table.Area.ToLower()}-{Table.Name.ToLower()}-lnk-last-page"").on(""click"", function (e) {{
    ActualPageNumber = TotalPages;
    ValidateAndSearch();
}});

//Table view button
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-table-view-button"").on(""click"", function (e) {{
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-view-toggler"").val(""Table"");
    ViewToggler = ""Table"";
    //Reset some values to default
    ActualPageNumber = 1;
    //Clear table view
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-and-head-table"").html("""");
    ValidateAndSearch();
}});

//List view button
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-list-view-button"").on(""click"", function (e) {{
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-view-toggler"").val(""List"");
    ViewToggler = ""List"";
    //Reset some values to default
    ActualPageNumber = 1;
    //Clear list view
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-body-list"").html("""");
    ValidateAndSearch();
}});

//Used to list view
function ScrollDownNSearch() {{
    let WindowsTopDistance: number = $(window).scrollTop() ?? 0;
    let WindowsBottomDistance: number = ($(window).scrollTop() ?? 0) + ($(window).innerHeight() ?? 0);
    let CardsFooterTopPosition: number = $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-more-button-in-list"").offset()?.top ?? 0;
    let CardsFooterBottomPosition: number = ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-more-button-in-list"").offset()?.top ?? 0) + ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-search-more-button-in-list"").outerHeight() ?? 0);

    if (WindowsTopDistance > LastTopDistance) {{
        //Scroll down
        if ((WindowsBottomDistance > CardsFooterTopPosition) && (WindowsTopDistance < CardsFooterBottomPosition)) {{
            //Search More button visible
            if (ActualPageNumber !== TotalPages) {{
                ScrollDownNSearchFlag = true;
                ActualPageNumber += 1;
                ValidateAndSearch();
            }}
        }}
        else {{ /*Card footer not visible*/ }}
    }}
    else {{ /*Scroll up*/ }}
    LastTopDistance = WindowsTopDistance;
}}

//Used to list view
$(window).on(""scroll"", ScrollDownNSearch);

//Export as PDF button
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-as-pdf"").on(""click"", function (e) {{
    //There are two exportation types, All and JustChecked
    let ExportationType: string = """";
    let DateTimeNow: Ajax;
    let Body: Ajax = {{}};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {{
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    }};

    if ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-rows-all-checkbox"").is("":checked"")) {{
        ExportationType = ""All"";
    }}
    else{{
        ExportationType = ""JustChecked"";
        let CheckedRows = new Array();

        if (ViewToggler == ""Table"") {{
            $(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row:checked"").each(function () {{
                CheckedRows.push($(this).val());
            }});

            Body = {{
                AjaxForString: CheckedRows.toString()
            }};
        }}
        else {{
            $(""div .list-row-checked"").each(function () {{
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            }});

            Body = {{
                AjaxForString: CheckedRows.toString()
            }};
        }}
    }}

    Rx.from(ajax.post(""/api/{Table.Area}/{Table.Name}/1/ExportAsPDF/"" + ExportationType, Body, Header)).subscribe({{
        next: newrow => {{
            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html(""<strong>Exporting as PDF</strong>"");
            DateTimeNow = newrow.response as Ajax;
        }},
        complete: () => {{
            //SUCCESS
            // @ts-ignore
            $.notify({{ icon: ""fas fa-check"", message: ""Conversion completed"" }}, {{ type: ""success"", placement: {{ from: ""bottom"", align: ""center"" }} }});

            //Show download button for PDF file
            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html(`<a class=""btn btn-icon btn-success"" href=""/PDFFiles/{Table.Area}/{Table.Name}/{Table.Name}_${{DateTimeNow.AjaxForString}}.pdf"" type=""button"" download>
                                            <span class=""btn-inner--icon""><i class=""fas fa-file-pdf""></i></span>
                                            <span class=""btn-inner--text"">Download</span>
                                        </a>`);

        }},
        error: err => {{
            //ERROR
            // @ts-ignore
            $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to convert"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
            console.log(err);
        }}
    }});
}});

//Export as Excel button
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-as-excel"").on(""click"", function (e) {{
    //There are two exportation types, All and JustChecked
    let ExportationType: string = """";
    let DateTimeNow: Ajax;
    let Body: Ajax = {{}};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {{
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    }};

    if ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-rows-all-checkbox"").is("":checked"")) {{
        ExportationType = ""All"";
    }}
    else {{
        ExportationType = ""JustChecked"";
        let CheckedRows = new Array();

        if (ViewToggler == ""Table"") {{
            $(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row:checked"").each(function () {{
                CheckedRows.push($(this).val());
            }});

            Body = {{
                AjaxForString: CheckedRows.toString()
            }};
        }}
        else {{
            $(""div .list-row-checked"").each(function () {{
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            }});

            Body = {{
                AjaxForString: CheckedRows.toString()
            }};
        }}
    }}

    Rx.from(ajax.post(""/api/{Table.Area}/{Table.Name}/1/ExportAsExcel/"" + ExportationType, Body, Header)).subscribe({{
        next: newrow => {{
            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html(""<strong>Exporting as Excel</strong>"");
            DateTimeNow = newrow.response as Ajax;
        }},
        complete: () => {{
            //SUCCESS
            // @ts-ignore
            $.notify({{ icon: ""fas fa-check"", message: ""Conversion completed"" }}, {{ type: ""success"", placement: {{ from: ""bottom"", align: ""center"" }} }});

            //Show download button for Excel file
            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html(`<a class=""btn btn-icon btn-success"" href=""/ExcelFiles/{Table.Area}/{Table.Name}/{Table.Name}_${{DateTimeNow.AjaxForString}}.xlsx"" type=""button"" download>
                                            <span class=""btn-inner--icon""><i class=""fas fa-file-excel""></i></span>
                                            <span class=""btn-inner--text"">Download</span>
                                        </a>`);
        }},
        error: err => {{
            //ERROR
            // @ts-ignore
            $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to convert"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
            console.log(err);
        }}
    }});
}});

//Export as CSV button
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-as-csv"").on(""click"", function (e) {{
    //There are two exportation types, All and JustChecked
    let ExportationType: string = """";
    let DateTimeNow: Ajax;
    let Body: Ajax = {{}};
    //Define a header for HTTP protocol with Accept (receiver data type) and Content-Type (sender data type)
    let Header: any = {{
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    }};

    if ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-rows-all-checkbox"").is("":checked"")) {{
        ExportationType = ""All"";
    }}
    else {{
        ExportationType = ""JustChecked"";
        let CheckedRows = new Array();

        if (ViewToggler == ""Table"") {{
            $(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row:checked"").each(function () {{
                CheckedRows.push($(this).val());
            }});

            Body = {{
                AjaxForString: CheckedRows.toString()
            }};
        }}
        else {{
            $(""div .list-row-checked"").each(function () {{
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            }});

            Body = {{
                AjaxForString: CheckedRows.toString()
            }};
        }}
    }}

    Rx.from(ajax.post(""/api/{Table.Area}/{Table.Name}/1/ExportAsCSV/"" + ExportationType, Body, Header)).subscribe({{
        next: newrow => {{
            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html(""<strong>Exporting as CSV</strong>"");
            DateTimeNow = newrow.response as Ajax;
        }},
        complete: () => {{
            //SUCCESS
            // @ts-ignore
            $.notify({{ icon: ""fas fa-check"", message: ""Conversion completed"" }}, {{ type: ""success"", placement: {{ from: ""bottom"", align: ""center"" }} }});

            //Show download button for CSV file
            $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html(`<a class=""btn btn-icon btn-success"" href=""/CSVFiles/{Table.Area}/{Table.Name}/{Table.Name}_${{DateTimeNow.AjaxForString}}.csv"" type=""button"" download>
                                            <span class=""btn-inner--icon""><i class=""fas fa-file-csv""></i></span>
                                            <span class=""btn-inner--text"">Download</span>
                                        </a>`);
        }},
        error: err => {{
            //ERROR
            // @ts-ignore
            $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to convert"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
            console.log(err);
        }}
    }});
}});

//Export close button in modal
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-close-button"").on(""click"", function (e) {{
    $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-export-message"").html("""");
}});

//Massive action Copy
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-massive-action-copy"").on(""click"", function (e) {{
    //There are two deletion types, All and JustChecked
    let CopyType: string = """";
    let Body: Ajax = {{}};

    if ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-copy-rows-all-checkbox"").is("":checked"")) {{
        CopyType = ""All"";
    }}
    else {{
        CopyType = ""JustChecked"";
        let CheckedRows = new Array();

        if (ViewToggler == ""Table"") {{
            $(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row:checked"").each(function () {{
                CheckedRows.push($(this).val());
            }});
        }}
        else {{
            $(""div .list-row-checked"").each(function () {{
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            }});
        }}
        Body = {{
            AjaxForString: CheckedRows.toString()
        }};
    }}

    {Table.Name}Model.CopyManyOrAll(CopyType, Body).subscribe({{
        next: newrow => {{
        }},
        complete: () => {{
            //SUCCESS
            // @ts-ignore
            $.notify({{ icon: ""fas fa-check"", message: ""Completed copy"" }}, {{ type: ""success"", placement: {{ from: ""bottom"", align: ""center"" }} }});

            ValidateAndSearch();
        }},
        error: err => {{
            //ERROR
            // @ts-ignore
            $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to copy"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
            console.log(err);
        }}
    }});
}});

//Massive action Delete
$(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-massive-action-delete"").on(""click"", function (e) {{
    //There are two deletion types, All and JustChecked
    let DeleteType: string = """";
    let Body: Ajax = {{}};

    if ($(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-copy-rows-all-checkbox"").is("":checked"")) {{
        DeleteType = ""All"";
    }}
    else {{
        DeleteType = ""JustChecked"";
        let CheckedRows = new Array();

        if (ViewToggler == ""Table"") {{
            $(""tr td div input.{Table.Name.ToLower()}-table-checkbox-for-row:checked"").each(function () {{
                CheckedRows.push($(this).val());
            }});
        }}
        else {{
            $(""div .list-row-checked"").each(function () {{
                //With .next() we access to input type hidden
                CheckedRows.push($(this).next().val());
            }});
        }}
        Body = {{
            AjaxForString: CheckedRows.toString()
        }};
    }}

    {Table.Name}Model.DeleteManyOrAll(DeleteType, Body).subscribe({{
        next: newrow => {{
        }},
        complete: () => {{
            //SUCCESS
            // @ts-ignore
            $.notify({{ icon: ""fas fa-check"", message: ""Completed deletion"" }}, {{ type: ""success"", placement: {{ from: ""bottom"", align: ""center"" }} }});

            ValidateAndSearch();
        }},
        error: err => {{
            //ERROR
            // @ts-ignore
            $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while trying to delete"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
            console.log(err);
        }}
    }});
}});";

            return Content;
        }
    }
}
