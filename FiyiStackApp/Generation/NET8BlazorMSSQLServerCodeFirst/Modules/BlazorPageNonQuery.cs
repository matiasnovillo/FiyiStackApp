using FiyiStack.Library.NET;
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
                $@"
@page ""/{Table.Area}/{Table.Name}Page/{{{Table.Name}Id:int}}""

@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Repositories;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.Entities;
@using {GeneratorConfigurationComponent.ProjectChosen.Name}.Areas.{Table.Area}.DTOs;
@inject {Table.Name}Repository {Table.Name.ToLower()}Repository;

@if ({Table.Name}Id == 0)
{{
    <PageTitle>Add {Table.Name.ToLower()} - {GeneratorConfigurationComponent.ProjectChosen.Name}</PageTitle>
}}
else
{{
    <PageTitle>Edit {Table.Name.ToLower()} - {GeneratorConfigurationComponent.ProjectChosen.Name}</PageTitle>
}}

<{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarVerticalDashboard lstMenuResult=""lstMenuResult""></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarVerticalDashboard>

<div class=""main-content position-relative max-height-vh-100 h-100"">
    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarHorizontalDashboard></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.NavBarHorizontalDashboard>
    <div class=""container-fluid px-2 px-md-4"">
        <div class=""page-header min-height-300 border-radius-xl mt-4""
             style=""background-image: url('assets/img/illustrations/Landscape2.jpg');"">
            <span class=""mask bg-gradient-primary opacity-6""></span>
        </div>
        <div class=""card card-body mx-3 mx-md-4 mt-n6"">
            <div class=""card-header mb-0 pb-0 bg-white"">
                <h1 class=""mb-3"">
                    @if({Table.Name}Id == 0)
                    {{
                        <span>Add {Table.Name.ToLower()}</span>
                    }}
                    else
                    {{
                        <span>Edit {Table.Name.ToLower()}</span>
                    }}
                </h1>
                <NavLink class=""btn btn-outline-info"" href=""{Table.Area}/{Table.Name}Page"">
                    <span class=""fas fa-chevron-left""></span>
                    &nbsp;Go back
                </NavLink>
            </div>
            <div class=""card-body px-0"">
                <form method=""post"" @onsubmit=""Submit""
                      @formname=""{Table.Name.ToLower()}-form"" class=""mb-4"">
                    <AntiforgeryToken />
                    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.PropertiesInHTML_BlazorNonQueryPage}
                    <hr />
                    <button id=""btn-submit"" type=""submit""
                            class=""btn bg-gradient-primary"">
                        <i class=""fas fa-pen""></i>
                        @if ({Table.Name}Id == 0)
                        {{
                            <span>Add</span>
                        }}
                        else
                        {{
                            <span>Edit</span>
                        }}
                    </button>
                    <NavLink class=""btn btn-outline-info"" href=""{Table.Area}/{Table.Name}Page"">
                        <span class=""fas fa-chevron-left""></span>
                        &nbsp;Go back
                    </NavLink>
                </form>
                @if (MessageForForm != """")
                {{
                    <span class=""text-danger"">
                        @((MarkupString)MessageForForm)
                    </span>
                }}
            </div>
        </div>
    </div>

    <{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard></{GeneratorConfigurationComponent.ProjectChosen.Name}.Components.Layout.FooterDashboard>
</div>

@code {{
    #region Properties
    public List<Menu> lstMenuResult {{ get; set; }} = [];

    public List<Role> lstRole {{ get; set; }} = [];

    [Parameter]
    public int {Table.Name}Id {{ get; set; }}

    public string MessageForForm {{ get; set; }} = """";

    [SupplyParameterFromForm]
    public {Table.Name} {Table.Name} {{ get; set; }} = new();

    public User User {{ get; set; }} = new();

    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.ProgressBarForFile_BlazorNonQueryPage}
    #endregion

    protected override void OnInitialized()
    {{
        try
        {{
            //Look for saved user in shared component, simulates a session
            User = StateContainer.User == null ? new() : StateContainer.User;

            lstMenuResult = [];
            {Table.Name} = new();

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

                    lstMenuResult = rolemenuRepository
                                        .GetAllByRoleId(User.RoleId, lstMenu);

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
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    EmergencyLevel = 1,
                    Comment = """",
                    Message = ex.Message,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                }};

            failureRepository.Add(failure);

            MessageForForm = $@""There was a mistake. Try again.
                             Error message: {{ex.Message}}"";
        }}
    }}

    private async Task Submit()
    {{
        try
        {{
            if ({Table.Name}Id == 0)
            {{
                //Create new {Table.Name}
                {Table.Name}.{Table.Name}Id = 0;

                {Table.Name}.DateTimeCreation = DateTime.Now;
                {Table.Name}.DateTimeLastModification = DateTime.Now;

                {Table.Name.ToLower()}Repository
                        .Add({Table.Name});
            }}
            else
            {{
                //Update data
                {Table.Name}.DateTimeLastModification = DateTime.Now;

                {Table.Name.ToLower()}Repository
                            .Update({Table.Name});
            }}

            //Redirect to users page
            NavigationManager.NavigateTo(""{Table.Area}/{Table.Name}Page"");
        }}
        catch (Exception ex)
        {{
            Failure failure = new()
                {{
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1,
                    EmergencyLevel = 1,
                    Comment = """",
                    Message = ex.Message,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                }};

            failureRepository.Add(failure);

            MessageForForm = $@""There was a mistake. Try again.
                             Error message: {{ex.Message}}"";
        }}
        finally
        {{
            //Re-render the page to show ScannedText
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
    }}

    {GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst.UploadFileMethod_BlazorNonQueryPage}
}}

";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
