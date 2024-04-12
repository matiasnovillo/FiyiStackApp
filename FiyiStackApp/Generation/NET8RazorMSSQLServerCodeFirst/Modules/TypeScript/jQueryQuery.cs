using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class TypeScript
    {
        public static string jQueryQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            string Content = $@"//Import libraries to use
import {{ {Table.Name}Entity }} from ""../TsEntities/{Table.Name}_TsEntity"";
import {{ paginated{Table.Name}DTO }} from ""../DTOs/paginated{Table.Name}DTO"";
import * as $ from ""jquery"";
import * as Rx from ""rxjs"";
import {{ ajax }} from ""rxjs/ajax"";
import {{ Ajax }} from ""../../../Library/Ajax"";
import ""bootstrap-notify"";

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

//Set default values
let TextToSearch: string = """";
let IsStrictSearch: boolean = false;
let PageIndex: number = 0;
let PageSize: number = 0;
let ViewToggler: string = ""List"";
let TotalItems: number = 0;

class {Table.Name}Query {{
    static GetAllPaginated(request_paginated{Table.Name}DTO: paginated{Table.Name}DTO) {{

        var ListContent: string = ``;

        {Table.Name}Entity.GetAllPaginated(request_paginated{Table.Name}DTO).subscribe(
            {{
                next: newrow => {{
                    //Only works when there is data available
                    if (newrow.status != 204) {{

                        const response_{Table.Name.ToLower()}Query = newrow.response as paginated{Table.Name}DTO;

                        //Set to default values if they are null
                        TextToSearch = response_{Table.Name.ToLower()}Query.TextToSearch ?? """";
                        IsStrictSearch = response_{Table.Name.ToLower()}Query.IsStrictSearch ?? false;
                        PageIndex = response_{Table.Name.ToLower()}Query.PageIndex ?? 0;
                        PageSize = response_{Table.Name.ToLower()}Query.PageSize ?? 0;
                        TotalItems = response_{Table.Name.ToLower()}Query.TotalItems ?? 0;

                        //Query string
                        $(""#query-string"").attr(""placeholder"", `Buscar {Table.Name.ToLower()} por {Table.Name}Id... (${{TotalItems}} {Table.Name.ToLower()} in this page)`);

                        //If book is empty set to default pagination values
                        if (response_{Table.Name.ToLower()}Query?.lst{Table.Name}?.length === 0) {{
                            
                        }}
                        //Read data book
                        response_{Table.Name.ToLower()}Query?.lst{Table.Name}?.forEach(row => {{

                            ListContent += `
<div class=""row"">
    <div class=""col-12"">
        <div class=""card bg-gradient-dark h-100"">
            <div class=""card-header bg-transparent text-sm-start text-center pt-4 pb-3 px-4"">
                <h6 class=""mb-1 text-white"">ID: ${{row.{Table.Name}Id}}</h6>
            </div>
            <hr class=""horizontal light my-0"">
            <div class=""card-body"">
                {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Fields_ForjQuery_ListFill}
            </div>
        </div>
    </div>
</div>`;
                        }})

                        //If view table is activated, clear table view, if not, clear list view
                        if (ViewToggler === ""Table"") {{
                        }}
                        else {{
                            $(""#body-list"").html(ListContent);
                        }}
                    }}
                    else {{
                        //ERROR
                        // @ts-ignore
                        $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""No registers found"" }}, {{ type: ""warning"", placement: {{ from: ""bottom"", align: ""center"" }} }});
                    }}
                }},
                complete: () => {{

                    //Check button inside list view
                    $("".checkbox-list"").on(""click"", function (e) {{
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
                    $(""#table-check-all"").on(""click"", function (e) {{ 
                        //Toggler
                        if ($(""tr td div input.table-checkbox-for-row"").is("":checked"")) {{
                            $(""tr td div input.table-checkbox-for-row"").removeAttr(""checked"");
                        }}
                        else {{
                            $(""tr td div input.table-checkbox-for-row"").attr(""checked"", ""checked"");
                        }}
                    }});

                    //Buttons inside head of table
                    $(""tr th button"").one(""click"", function (e) {{
                        ValidateAndSearch();
                    }});

                    //Delete button in table and list
                    $(""div.dropdown-menu button.table-delete-button, div.dropdown-menu button.list-delete-button"").on(""click"", function (e) {{
                        let {Table.Name}Id = $(this).val();
                        {Table.Name}Entity.DeleteBy{Table.Name}Id({Table.Name}Id).subscribe({{
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
                    $(""div.dropdown-menu button.table-copy-button, div.dropdown-menu button.list-copy-button"").on(""click"", function (e) {{
                        let {Table.Name}Id = $(this).val();
                        {Table.Name}Entity.CopyBy{Table.Name}Id({Table.Name}Id).subscribe({{
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

    var _{Table.Name.ToLower()}SelectAllPaged: paginated{Table.Name}DTO = {{
        lst{Table.Name}: [],
        lstUserCreation: [],
        lstUserLastModification: [],
        TextToSearch,
        IsStrictSearch,
        PageIndex,
        PageSize,
        TotalItems
    }};

    {Table.Name}Query.GetAllPaginated(_{Table.Name.ToLower()}SelectAllPaged);
}}

//LOAD EVENT
if ($(""#title-page"").html().includes(""Buscar {Table.Name.ToLower()}"")) {{
    //Set to default values
    TextToSearch = """";
    IsStrictSearch = false;
    PageIndex = 1;
    PageSize = 15;
    ViewToggler = ""List"";
    TotalItems = 0;

    ValidateAndSearch();
}}
//CLICK, SCROLL AND KEYBOARD EVENTS
//Search button
$($(""#search-button"")).on(""click"", function () {{
    ValidateAndSearch();
}});

//Query string
$(""#query-string"").on(""change keyup input"", function (e) {{
    //If undefined, set TextToSearch to """" value
    TextToSearch = ($(this).val()?.toString()) ?? """" ;
    ValidateAndSearch();
}});

//Table view button
$(""#table-view-button"").on(""click"", function (e) {{
    $(""#view-toggler"").val(""Table"");
    ViewToggler = ""Table"";
    //Clear table view
    $(""#body-and-head-table"").html("""");
    ValidateAndSearch();
}});

//List view button
$(""#list-view-button"").on(""click"", function (e) {{
    $(""#view-toggler"").val(""List"");
    ViewToggler = ""List"";
    //Clear list view
    $(""#body-list"").html("""");
    ValidateAndSearch();
}});";

            return Content;
        }
    }
}
