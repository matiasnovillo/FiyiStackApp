using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class TypeScript
    {
        public static string jQueryNonQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            string Content = $@"

{ Security.WaterMark(Security.EWaterMarkFor.TypeScriptAndJavaScript, Constant.FiyiStackGUID.ToString())}

//Stack: 10

//Last modification on: {DateTime.Now}

//Create a formdata object
var formData = new FormData();

//Used for Quill Editor
{GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.FieldTextEditor_ForjQueryNonQuery_Quill}

//Used for file input
{GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.FieldTextFile_ForjQueryNonQuery}

//LOAD EVENT
$(document).ready(function () {{
    {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.FieldTextEditor_ForjQueryNonQuery_LoadEvent}
    
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.getElementsByClassName(""needs-validation"");
    // Loop over them and prevent submission
    Array.prototype.filter.call(forms, function (form) {{
        form.addEventListener(""submit"", function (event) {{

            event.preventDefault();
            event.stopPropagation();

            if (form.checkValidity() === true) {{
                
                //{Table.Name}Id
                formData.append(""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{Table.Name.ToLower()}id-input"", $(""#{Table.Area.ToLower()}-{Table.Name.ToLower()}-{Table.Name.ToLower()}id-input"").val());

                {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Field_ForjQueryNonQuery_FormData}

                //Setup request
                var xmlHttpRequest = new XMLHttpRequest();
                //Set event listeners
                xmlHttpRequest.upload.addEventListener(""loadstart"", function (e) {{
                    //SAVING
                    $.notify({{ message: ""Saving data. Please, wait"" }}, {{ type: ""info"", placement: {{ from: ""bottom"", align: ""center"" }} }});
                }});
                xmlHttpRequest.onload = function () {{
                    if (xmlHttpRequest.status >= 400) {{
                        //ERROR
                        console.log(xmlHttpRequest);
                        $.notify({{ icon: ""fas fa-exclamation-triangle"", message: ""There was an error while saving the data"" }}, {{ type: ""danger"", placement: {{ from: ""bottom"", align: ""center"" }} }});
                    }}
                    else {{
                        //SUCCESS
                        window.location.replace(""/{Table.Area}/{Table.Name}QueryPage"");
                    }}
                }};
                //Open connection
                xmlHttpRequest.open(""POST"", ""/api/{Table.Area}/{Table.Name}/1/InsertOrUpdateAsync"", true);
                //Send request
                xmlHttpRequest.send(formData);
            }}
            else {{
                $.notify({{ message: ""Please, complete all fields."" }}, {{ type: ""warning"", placement: {{ from: ""bottom"", align: ""center"" }} }});
            }}


            form.classList.add(""was-validated"");
        }}, false);
    }});
}});";

            return Content;
        }
    }
}
