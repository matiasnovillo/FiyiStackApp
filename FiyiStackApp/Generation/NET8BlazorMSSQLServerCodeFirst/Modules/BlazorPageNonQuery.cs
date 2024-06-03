using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string BlazorPageNonQuery(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {
            try
            {
                string Content =
                $@"@page ""/{Table.Area}/{Table.Name}Page/{{{Table.Name}Id:int}}""

@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Repositories;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
@using System.ComponentModel.DataAnnotations;
@inject {Table.Name}Repository {Table.Name.ToLower()}Repository;

@if ({Table.Name}Id == 0)
{{
    <PageTitle>Agregar {Table.Name.ToLower()} - {Table.Area}</PageTitle>
}}
else
{{
    <PageTitle>Editar {Table.Name.ToLower()} - {Table.Area}</PageTitle>
}}

<{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.SideNav lstFoldersAndPages=""lstFoldersAndPages""></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.SideNav>

<div class=""main-content position-relative max-height-vh-100 h-100"">
    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarDashboard Pagina=""{Table.Name}""></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarDashboard>
    <div class=""container-fluid px-2 px-md-4"">
        <div class=""page-header min-height-300 border-radius-xl mt-4""
             style=""background-image: url('assets/img/illustrations/Landscape2.jpg');"">
            <span class=""mask bg-gradient-primary opacity-6""></span>
        </div>
        <div class=""card card-body mx-3 mx-md-4 mt-n6"">
            <div class=""card-header mb-0 pb-0"">
                <div class=""d-flex justify-content-between"">
                    <h3 class=""mb-3"">
                        @if ({Table.Name}Id == 0)
                        {{
                            <span>Agregar {Table.Name.ToLower()}</span>
                        }}
                        else
                        {{
                            <span>Editar {Table.Name.ToLower()}</span>
                        }}
                    </h3>
                    <NavLink class=""btn btn-outline-dark"" href=""{Table.Area}/{Table.Name}Page"">
                        <span class=""fas fa-chevron-left""></span>
                        &nbsp;Volver
                    </NavLink>
                </div>
                <hr />
            </div>
            <div class=""card-body px-0"">
                <form method=""post"" @onsubmit=""Submit""
                      @formname=""{Table.Name.ToLower()}-form"" class=""mb-4"">
                    <AntiforgeryToken />
                    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_BlazorNonQueryPage}
                    <hr />
                    @((MarkupString)Message)
                    <div class=""d-flex justify-content-between"">
                        <button id=""btn-submit"" type=""submit""
                                class=""btn btn-success"">
                            <i class=""fas fa-pen""></i>
                            @if ({Table.Name}Id == 0)
                            {{
                                <span>Agregar</span>
                            }}
                            else
                            {{
                                <span>Editar</span>
                            }}
                        </button>
                        <NavLink class=""btn btn-outline-dark mx-3"" href=""{Table.Area}/{Table.Name}Page"">
                            <span class=""fas fa-chevron-left""></span>
                            &nbsp;Volver
                        </NavLink>
                    </div>
                </form>
                
            </div>
        </div>
    </div>

    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FixedPlugin></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FixedPlugin>
    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard>
</div>

@code {{
    #region Properties
    public List<folderForDashboard> lstFoldersAndPages = [];

    public List<Role> lstRole {{ get; set; }} = [];

    [Parameter]
    public int {Table.Name}Id {{ get; set; }}

    public string Message {{ get; set; }} = """";

    [SupplyParameterFromForm]
    public {Table.Name} {Table.Name} {{ get; set; }} = new();

    public User User {{ get; set; }} = new();

    //Error messages for inputs
    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.ErrorMessage_InNonQueryBlazor}

    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.ProgressBarForFile_BlazorNonQueryPage}
    #endregion

    protected override void OnInitialized()
    {{
        try
        {{
            //Look for saved user in shared component, simulates a session
            User = StateContainer.User == null ? new() : StateContainer.User;

            lstFoldersAndPages = [];
            {Table.Name} = new();

            if (User != null)
            {{
                if (User.UserId != 0)
                {{
                    //Logged user
                    List<Menu> lstMenuWithPermission = rolemenuRepository
                                    .GetAllByRoleIdAndPathForPermission(User.RoleId, ""/{Table.Area}/{Table.Name}Page"");

                    if (lstMenuWithPermission.Count == 0)
                    {{
                        //Redirect to...
                        NavigationManager.NavigateTo(""403"");
                    }}

                    List<Menu> lstMenu = menuRepository
                                        .GetAll();

                    lstFoldersAndPages = rolemenuRepository
                                            .GetAllPagesAndFoldersForDashboardByRoleId(User.RoleId);

                    lstRole = roleRepository.GetAll();

                    if ({Table.Name}Id == 0)
                    {{
                        //Create new {Table.Name}
                        {Table.Name} = new();
                    }}
                    else
                    {{
                        //Edit {Table.Name}

                        {Table.Name} = {Table.Name.ToLower()}Repository
                                    .GetBy{Table.Name}Id({Table.Name}Id);
                    }}                    
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
    }}

    private async Task Submit()
    {{
        try
        {{
            if ({Table.Name}Id == 0)
            {{
                //Create new {Table.Name}
                {Table.Name}.Active = true;
                {Table.Name}.UserCreationId = User.UserId;
                {Table.Name}.UserLastModificationId = User.UserId;
                {Table.Name}.DateTimeCreation = DateTime.Now;
                {Table.Name}.DateTimeLastModification = DateTime.Now;

                if(Check("""") == null)
                {{
                    {Table.Name.ToLower()}Repository
                        .Add({Table.Name});

                    //Redirect to users page
                    NavigationManager.NavigateTo(""{Table.Area}/{Table.Name}Page"");
                }}


            }}
            else
            {{
                //Update data
                {Table.Name}.DateTimeLastModification = DateTime.Now;
                {Table.Name}.UserLastModificationId = User.UserId;

                if(Check("""") == null)
                {{
                    {Table.Name.ToLower()}Repository
                            .Update({Table.Name});

                    //Redirect to users page
                    NavigationManager.NavigateTo(""{Table.Area}/{Table.Name}Page"");
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
            //Re-render the page to show ScannedText
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
    }}

    #region Uploaders
    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.UploadFileMethod_BlazorNonQueryPage}
    #endregion    

    #region Searchers
    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.Searchers_BlazorNonQueryPage}
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""attributeToValid"">Debe estar encapsulado en []. Ejemplo: [Boolean]</param>
    /// <returns></returns>
    private ValidationResult Check(string attributeToValid)
    {{
        try
        {{
            List<ValidationResult> lstValidationResult = new List<ValidationResult>();
            ValidationContext ValidationContext = new ValidationContext({Table.Name});

            bool IsValid = Validator.TryValidateObject({Table.Name}, ValidationContext, lstValidationResult, true);

            ValidationResult ValidationResult = lstValidationResult
            .AsQueryable()
            .FirstOrDefault(x => x.ErrorMessage.StartsWith(attributeToValid));

            if (!IsValid)
            {{
                Message = $@""<div class=""""alert alert-danger text-white font-weight-bold"""" role=""""alert"""">
                                Para guardar correctamente debe completar los siguientes puntos: <br/> <ul>"";

                foreach (var validationResult in lstValidationResult)
                {{
                    validationResult.ErrorMessage = validationResult.ErrorMessage.Substring(validationResult.ErrorMessage.IndexOf(']') + 1);
                    Message += $@""<li>{{validationResult}}</li>"";
                }}

                Message = Message + ""</ul></div>"";
            }}
            else
            {{
                Message = $@""<div class=""""alert alert-successs text-white font-weight-bold"""" role=""""alert"""">
                                Todos los datos ingresados son correctos
                            </div>"";
            }}


            if (ValidationResult != null)
            {{
                ValidationResult.ErrorMessage = ValidationResult.ErrorMessage.Substring(ValidationResult.ErrorMessage.IndexOf(']') + 1);
            }}

            return ValidationResult;
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

            return null;
        }}
        finally
        {{

        }}
    }}

    #region Handlers
    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.Handlers_InNonQueryBlazor}
    #endregion
}}

";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
