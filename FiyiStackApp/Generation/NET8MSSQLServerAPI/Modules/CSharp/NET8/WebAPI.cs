using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules
{
    public static partial class CSharpNET8
    {
        public static string WebAPI(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.BasicCore.Models;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Filters;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Models;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.IO;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

//Last modification on: {DateTime.Now}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Controllers
{{
    /// <summary>
    /// Stack:             6<br/>
    /// Name:              C# Web API Controller. <br/>
    /// Function:          Allow you to intercept HTPP calls and comunicate with his C# Service using dependency injection.<br/>
    /// Last modification: {DateTime.Now}
    /// </summary>
    [ApiController]
    [{Table.Name}Filter]
    public partial class {Table.Name}ValuesController : ControllerBase
    {{
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly I{Table.Name} _I{Table.Name};

        public {Table.Name}ValuesController(IWebHostEnvironment WebHostEnvironment, I{Table.Name} I{Table.Name}) 
        {{
            _WebHostEnvironment = WebHostEnvironment;
            _I{Table.Name} = I{Table.Name};
        }}

        #region Queries
        [HttpGet(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/Select1By{Table.Name}IdToJSON/{{{Table.Name}Id:int}}"")]
        public {Table.Name}Model Select1By{Table.Name}IdToJSON(int {Table.Name}Id)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                return _I{Table.Name}.Select1By{Table.Name}IdToModel({Table.Name}Id);
            }}
            catch (Exception ex) 
            {{ 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return null;
            }}
        }}

        [HttpGet(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/SelectAllToJSON"")]
        public List<{Table.Name}Model> SelectAllToJSON()
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                return _I{Table.Name}.SelectAllToList();
            }}
            catch (Exception ex) 
            {{ 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return null;
            }}
        }}

        [HttpPost(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/SelectAllPagedToJSON"")]
        public {Table.Name.ToLower()}SelectAllPaged SelectAllPagedToJSON([FromBody] {Table.Name.ToLower()}SelectAllPaged {Table.Name.ToLower()}SelectAllPaged)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                 return _I{Table.Name}.SelectAllPagedToModel({Table.Name.ToLower()}SelectAllPaged);
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return null;
            }}
        }}
        #endregion

        #region Non-Queries
        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/InsertOrUpdateAsync"")]
        public async Task<IActionResult> InsertOrUpdateAsync()
        {{
            try
            {{
                //Get UserId from Session
                int UserId = HttpContext.Session.GetInt32(""UserId"") ?? 0;

                if(UserId == 0)
                {{
                    return StatusCode(401, ""User not found in session"");
                }}
                
                #region Pass data from client to server
                //{Table.Name}Id
                int {Table.Name}Id = Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{Table.Name.ToLower()}id-input""]);
                
                {GeneratorConfigurationComponent.fieldChainerNET8MSSQLServerAPI.Fields_ForController_InInsertAsync_Ajax}
                #endregion

                int NewEnteredId = 0;
                int RowsAffected = 0;

                if ({Table.Name}Id == 0)
                {{
                    //Insert
                    {Table.Name}Model {Table.Name}Model = new {Table.Name}Model()
                    {{
                        Active = true,
                        UserCreationId = UserId,
                        UserLastModificationId = UserId,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        {GeneratorConfigurationComponent.fieldChainerNET8MSSQLServerAPI.Fields_ForController_InInsertAsync.TrimEnd(',')}
                    }};
                    
                    NewEnteredId = _I{Table.Name}.Insert({Table.Name}Model);
                }}
                else
                {{
                    //Update
                    {Table.Name}Model {Table.Name}Model = new {Table.Name}Model({Table.Name}Id);
                    
                    {Table.Name}Model.UserLastModificationId = UserId;
                    {Table.Name}Model.DateTimeLastModification = DateTime.Now;
                    {GeneratorConfigurationComponent.fieldChainerNET8MSSQLServerAPI.Fields_ForController_InUpdateAsync}                   

                    RowsAffected = _I{Table.Name}.UpdateBy{Table.Name}Id({Table.Name}Model);
                }}
                

                //Look for sent files
                if (HttpContext.Request.Form.Files.Count != 0)
                {{
                    int i = 0; //Used to iterate in HttpContext.Request.Form.Files
                    foreach (var File in Request.Form.Files)
                    {{
                        if (File.Length > 0)
                        {{
                            var FileName = HttpContext.Request.Form.Files[i].FileName;
                            var FilePath = $@""{{_WebHostEnvironment.WebRootPath}}/Uploads/{Table.Area}/{Table.Name}/"";

                            using (var FileStream = new FileStream($@""{{FilePath}}{{FileName}}"", FileMode.Create))
                            {{
                                
                                await File.CopyToAsync(FileStream); // Read file to stream
                                byte[] array = new byte[FileStream.Length]; // Stream to byte array
                                FileStream.Seek(0, SeekOrigin.Begin);
                                FileStream.Read(array, 0, array.Length);
                            }}

                            i += 1;
                        }}
                    }}
                }}

                if ({Table.Name}Id == 0)
                {{
                    return StatusCode(200, NewEnteredId); 
                }}
                else
                {{
                    return StatusCode(200, RowsAffected);
                }}
            }}
            catch (Exception ex) 
            {{ 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}

        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpDelete(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/DeleteBy{Table.Name}Id/{{{Table.Name}Id:int}}"")]
        public IActionResult DeleteBy{Table.Name}Id(int {Table.Name}Id)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                int RowsAffected = _I{Table.Name}.DeleteBy{Table.Name}Id({Table.Name}Id);
                return StatusCode(200, RowsAffected);
            }}
            catch (Exception ex) 
            {{ 
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}

        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/DeleteManyOrAll/{{DeleteType}}"")]
        public IActionResult DeleteManyOrAll([FromBody] Ajax Ajax, string DeleteType)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                _I{Table.Name}.DeleteManyOrAll(Ajax, DeleteType);

                return StatusCode(200, Ajax.AjaxForString);
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}

        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/CopyBy{Table.Name}Id/{{{Table.Name}Id:int}}"")]
        public IActionResult CopyBy{Table.Name}Id(int {Table.Name}Id)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                int NewEnteredId = _I{Table.Name}.CopyBy{Table.Name}Id({Table.Name}Id);

                return StatusCode(200, NewEnteredId);
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}

        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/CopyManyOrAll/{{CopyType}}"")]
        public IActionResult CopyManyOrAll([FromBody] Ajax Ajax, string CopyType)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                int[] NewEnteredIds = _I{Table.Name}.CopyManyOrAll(Ajax, CopyType);
                string NewEnteredIdsAsString = """";

                for (int i = 0; i < NewEnteredIds.Length; i++)
                {{
                    NewEnteredIdsAsString += NewEnteredIds[i].ToString() + "","";
                }}
                NewEnteredIdsAsString = NewEnteredIdsAsString.TrimEnd(',');

                return StatusCode(200, NewEnteredIdsAsString);
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}
        #endregion

        #region Other actions
        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/ExportAsPDF/{{ExportationType}}"")]
        public IActionResult ExportAsPDF([FromBody] Ajax Ajax, string ExportationType)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                DateTime Now = _I{Table.Name}.ExportAsPDF(Ajax, ExportationType);

                return StatusCode(200, new Ajax() {{ AjaxForString = Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"") }});
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}

        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/ExportAsExcel/{{ExportationType}}"")]
        public IActionResult ExportAsExcel([FromBody] Ajax Ajax, string ExportationType)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                DateTime Now = _I{Table.Name}.ExportAsExcel(Ajax, ExportationType);

                return StatusCode(200, new Ajax() {{ AjaxForString = Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"") }});
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}

        //[Produces(""text/plain"")] //For production mode, uncomment this line
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/ExportAsCSV/{{ExportationType}}"")]
        public IActionResult ExportAsCSV([FromBody] Ajax Ajax, string ExportationType)
        {{
            try
            {{
                var SyncIO = HttpContext.Features.Get<IHttpBodyControlFeature>();
                if (SyncIO != null) {{ SyncIO.AllowSynchronousIO = true; }}

                DateTime Now = _I{Table.Name}.ExportAsCSV(Ajax, ExportationType);

                return StatusCode(200, new Ajax() {{ AjaxForString = Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"") }});
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                FailureModel FailureModel = new FailureModel()
                {{
                    HTTPCode = 500,
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now
                }};
                FailureModel.Insert();
                return StatusCode(500, ex.Message);
            }}
        }}
        #endregion
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
