using FiyiStack.Library.NET;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string Controller(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.BasicCore.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.BasicCore.Interfaces;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Filters;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Interfaces;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
using {GeneratorConfigurationComponent.ProjectChosen.Name}.Library;

{Security.WaterMark(Security.EWaterMarkFor.CSharp, Constant.FiyiStackGUID.ToString())}

namespace {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Controllers
{{
    [ApiController]
    [{Table.Name}Filter]
    public partial class {Table.Name}ValuesController : ControllerBase
    {{
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IFailureRepository _failureRepository;
        private readonly I{Table.Name}Repository _{Table.Name.ToLower()}Repository;
        private readonly I{Table.Name}Service _{Table.Name.ToLower()}Service;

        public {Table.Name}ValuesController(IWebHostEnvironment WebHostEnvironment,
            IConfiguration configuration,
            IFailureRepository failureRepository,
            I{Table.Name}Repository {Table.Name.ToLower()}Repository,
            I{Table.Name}Service {Table.Name.ToLower()}Service)
        {{
            _WebHostEnvironment = WebHostEnvironment;
            _configuration = configuration;
            _failureRepository = failureRepository;
            _{Table.Name.ToLower()}Repository = {Table.Name.ToLower()}Repository;
            _{Table.Name.ToLower()}Service = {Table.Name.ToLower()}Service;
        }}

        #region Queries
        [HttpGet(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/GetBy{Table.Name}Id/{{{Table.Name}Id:int}}"")]
        public {Table.Name} GetBy{Table.Name}Id(int {Table.Name}Id)
        {{
            try
            {{
                return _{Table.Name.ToLower()}Repository.GetBy{Table.Name}Id({Table.Name}Id);
            }}
            catch (Exception ex) 
            {{ 
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return null;
            }}
        }}

        [HttpGet(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/GetAll"")]
        public List<{Table.Name}> GetAll()
        {{
            try
            {{
                return _{Table.Name.ToLower()}Repository.GetAll();
            }}
            catch (Exception ex) 
            {{ 
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return null;
            }}
        }}

        [HttpPost(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/GetAllPaginated"")]
        public paginated{Table.Name}DTO GetAllPaginated([FromBody] paginated{Table.Name}DTO paginated{Table.Name}DTO)
        {{
            try
            {{
                return _{Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdPaginated(paginated{Table.Name}DTO.TextToSearch,
                                            paginated{Table.Name}DTO.IsStrictSearch,
                                            paginated{Table.Name}DTO.PageIndex,
                                            paginated{Table.Name}DTO.PageSize);
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return null;
            }}
        }}
        #endregion

        #region Non-Queries
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/AddOrUpdate"")]
        public IActionResult AddOrUpdate()
        {{
            try
            {{
                //Get UserId from Session
                int UserId = HttpContext.Session.GetInt32(""UserId"") ?? 0;

                if(UserId == 0)
                {{
                    return StatusCode(401, ""Usuario no encontrado en sesión"");
                }}
                
                #region Pass data from client to server
                //{Table.Name}Id
                int {Table.Name}Id = Convert.ToInt32(HttpContext.Request.Form[""{Table.Area.ToLower()}-{Table.Name.ToLower()}-{Table.Name.ToLower()}id-input""]);
                
                {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Fields_ForController_InInsertAsync_Ajax}
                #endregion

                int NewEnteredId = 0;
                int RowsAffected = 0;

                if ({Table.Name}Id == 0)
                {{
                    //Insert
                    {Table.Name} {Table.Name} = new {Table.Name}()
                    {{
                        Active = true,
                        UserCreationId = UserId,
                        UserLastModificationId = UserId,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Fields_ForController_InInsertAsync.TrimEnd(',')}
                    }};
                    
                    NewEnteredId = _{Table.Name.ToLower()}Repository.Add({Table.Name});
                }}
                else
                {{
                    //Update
                    {Table.Name} {Table.Name} = _{Table.Name.ToLower()}Repository.GetBy{Table.Name}Id({Table.Name}Id);
                    
                    {Table.Name}.UserLastModificationId = UserId;
                    {Table.Name}.DateTimeLastModification = DateTime.Now;
                    {GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst.Fields_ForController_InUpdateAsync}                   

                    RowsAffected = _{Table.Name.ToLower()}Repository.Update({Table.Name});
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
                                
                                File.CopyToAsync(FileStream); // Read file to stream
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
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return StatusCode(500, ex.Message);
            }}
        }}

        [HttpDelete(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/DeleteBy{Table.Name}Id/{{{Table.Name}Id:int}}"")]
        public IActionResult DeleteBy{Table.Name}Id(int {Table.Name}Id)
        {{
            try
            {{
                int RowsDeleted = _{Table.Name.ToLower()}Repository.DeleteBy{Table.Name}Id({Table.Name}Id);
                return StatusCode(200, RowsDeleted);
            }}
            catch (Exception ex) 
            {{ 
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return StatusCode(500, ex.Message);
            }}
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""Ajax""></param>
        /// <param name=""DeleteType"">Accept two values: All or NotAll</param>
        /// <returns></returns>
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/DeleteManyOrAll/{{DeleteType}}"")]
        public IActionResult DeleteManyOrAll([FromBody] Ajax Ajax, string DeleteType)
        {{
            try
            {{
                _{Table.Name.ToLower()}Repository.DeleteManyOrAll(Ajax, DeleteType);

                return StatusCode(200, ""OK"");
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return StatusCode(500, ex.Message);
            }}
        }}

        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/CopyBy{Table.Name}Id/{{{Table.Name}Id:int}}"")]
        public IActionResult CopyBy{Table.Name}Id(int {Table.Name}Id)
        {{
            try
            {{
                int NumberOfRegistersEntered = _{Table.Name.ToLower()}Repository.CopyBy{Table.Name}Id({Table.Name}Id);

                return StatusCode(200, NumberOfRegistersEntered);
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return StatusCode(500, ex.Message);
            }}
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""Ajax""></param>
        /// <param name=""CopyType"">Accept two values: All or NotAll</param>
        /// <returns></returns>
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/CopyManyOrAll/{{CopyType}}"")]
        public IActionResult CopyManyOrAll([FromBody] Ajax Ajax, string CopyType)
        {{
            try
            {{
                int NumberOfRegistersEntered = _{Table.Name.ToLower()}Repository.CopyManyOrAll(Ajax, CopyType);
                
                return StatusCode(200, NumberOfRegistersEntered);
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return StatusCode(500, ex.Message);
            }}
        }}
        #endregion

        #region Exportations
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""Ajax""></param>
        /// <param name=""ExportationType"">Accept two values: All or NotAll</param>
        /// <returns></returns>
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/ExportAsPDF/{{ExportationType}}"")]
        public IActionResult ExportAsPDF([FromBody] Ajax Ajax, string ExportationType)
        {{
            try
            {{
                DateTime Now = _{Table.Name.ToLower()}Service.ExportAsPDF(Ajax, ExportationType);

                return StatusCode(200, new Ajax() {{ AjaxForString = Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"") }});
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return StatusCode(500, ex.Message);
            }}
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""Ajax""></param>
        /// <param name=""ExportationType"">Accept two values: All or NotAll</param>
        /// <returns></returns>
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/ExportAsExcel/{{ExportationType}}"")]
        public IActionResult ExportAsExcel([FromBody] Ajax Ajax, string ExportationType)
        {{
            try
            {{
                DateTime Now = _{Table.Name.ToLower()}Service.ExportAsExcel(Ajax, ExportationType);

                return StatusCode(200, new Ajax() {{ AjaxForString = Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"") }});
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
                return StatusCode(500, ex.Message);
            }}
        }}

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""Ajax""></param>
        /// <param name=""ExportationType"">Accept two values: All or NotAll</param>
        /// <returns></returns>
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/ExportAsCSV/{{ExportationType}}"")]
        public IActionResult ExportAsCSV([FromBody] Ajax Ajax, string ExportationType)
        {{
            try
            {{
                DateTime Now = _{Table.Name.ToLower()}Service.ExportAsCSV(Ajax, ExportationType);

                return StatusCode(200, new Ajax() {{ AjaxForString = Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"") }});
            }}
            catch (Exception ex)
            {{
                DateTime Now = DateTime.Now;
                Failure Failure = new()
                {{
                    Message = ex.Message,
                    EmergencyLevel = 1,
                    StackTrace = ex.StackTrace ?? """",
                    Source = ex.Source ?? """",
                    Comment = """",
                    Active = true,
                    UserCreationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    UserLastModificationId = HttpContext.Session.GetInt32(""UserId"") ?? 1,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                }};
                _failureRepository.Add(Failure);
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
