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
                $@"using Microsoft.AspNetCore.Mvc;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly I{Table.Name}Repository _{Table.Name.ToLower()}Repository;
        private readonly I{Table.Name}Service _{Table.Name.ToLower()}Service;

        public {Table.Name}ValuesController(IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration,
            I{Table.Name}Repository {Table.Name.ToLower()}Repository,
            I{Table.Name}Service {Table.Name.ToLower()}Service)
        {{
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _{Table.Name.ToLower()}Repository = {Table.Name.ToLower()}Repository;
            _{Table.Name.ToLower()}Service = {Table.Name.ToLower()}Service;
        }}

        #region Queries
        [HttpGet(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/GetBy{Table.Name}Id/{{{Table.Name.ToLower()}Id:int}}"")]
        public {Table.Name} GetBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            return _{Table.Name.ToLower()}Repository.GetBy{Table.Name}Id({Table.Name.ToLower()}Id);
        }}

        [HttpGet(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/GetAll"")]
        public List<{Table.Name}> GetAll()
        {{
            return _{Table.Name.ToLower()}Repository.GetAll();
        }}

        [HttpPost(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/GetAllPaginated"")]
        public paginated{Table.Name}DTO GetAllPaginated([FromBody] paginated{Table.Name}DTO paginated{Table.Name}DTO)
        {{
            return _{Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdPaginated(paginated{Table.Name}DTO.TextToSearch,
                                            paginated{Table.Name}DTO.IsStrictSearch,
                                            paginated{Table.Name}DTO.PageIndex,
                                            paginated{Table.Name}DTO.PageSize);
        }}
        #endregion

        #region Non-Queries
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/AddOrUpdate"")]
        public IActionResult AddOrUpdate()
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
                            var FilePath = $@""{{_webHostEnvironment.WebRootPath}}/Uploads/{Table.Area}/{Table.Name}/"";

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

        [HttpDelete(""~/api/{Table.Area}/{Table.Name}/{Table.Version}/DeleteBy{Table.Name}Id/{{{Table.Name.ToLower()}Id:int}}"")]
        public IActionResult DeleteBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            int RowsDeleted = _{Table.Name.ToLower()}Repository.DeleteBy{Table.Name}Id({Table.Name.ToLower()}Id);
            return StatusCode(200, RowsDeleted);
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
            string RowsDeleted = _{Table.Name.ToLower()}Repository.DeleteManyOrAll(Ajax, DeleteType);

            return StatusCode(200, RowsDeleted);
        }}

        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/CopyBy{Table.Name}Id/{{{Table.Name.ToLower()}Id:int}}"")]
        public IActionResult CopyBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            int NumberOfRegistersEntered = _{Table.Name.ToLower()}Repository.CopyBy{Table.Name}Id({Table.Name.ToLower()}Id);

            return StatusCode(200, NumberOfRegistersEntered);
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
            int NumberOfRegistersEntered = _{Table.Name.ToLower()}Repository.CopyManyOrAll(Ajax, CopyType);

            return StatusCode(200, NumberOfRegistersEntered);
        }}
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""Ajax"">Used when is NotAll option selected</param>
        /// <param name=""exportationFile"">Can be Excel, PDF o CSV</param>
        /// <param name=""exportationType"">Can be All or NotAll</param>
        /// <returns></returns>
        [HttpPost(""~/api/{Table.Area}/{Table.Name}/1/Export/{{exportationFile}}/{{exportationType}}"")]
        public IActionResult Export([FromBody] Ajax Ajax, string exportationFile, string exportationType)
        {{
            DateTime Now;

            if (exportationFile == ""Excel"")
            {{
                Now = _{Table.Name.ToLower()}Service.ExportAsExcel(Ajax, exportationType);
            }}
            else if (exportationFile == ""PDF"")
            {{
                Now = _{Table.Name.ToLower()}Service.ExportAsPDF(Ajax, exportationType);
            }}
            else if(exportationFile == ""CSV"")
            {{
                Now = _{Table.Name.ToLower()}Service.ExportAsCSV(Ajax, exportationType);
            }}
            else
            {{
                return StatusCode(400);
            }}
            
            return StatusCode(200, Now.ToString());
        }}
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
