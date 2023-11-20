using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Languages
{
    public static class CSharp
    {
        public static string Start(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            try
            {
                string LogText = "";

                foreach (Table Table in GeneratorConfigurationComponent.lstTableToGenerate)
                {
                    if (Table.Area == "" || Table.Name == "") { throw new Exception("C# generation cancelled. A table does not have an area or name declared"); }

                    //Here we prepare the fieldChainer object for every table to generate
                    GeneratorConfigurationComponent.fieldChainer = new fieldChainer(Table);
                    GeneratorConfigurationComponent.modelChainer = new modelChainer(Table, GeneratorConfigurationComponent.lstTableInFiyiStack);

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region C# Models with stored procedures
                    if (GeneratorConfigurationComponent.Configuration.WantCSharpModelsWithSPs)
                    {
                        string CSharpModelPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\Areas\\{Table.Area}\\Models\\";
                        if (Directory.Exists(CSharpModelPath))
                        {
                            LogText += $"Folder: {CSharpModelPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpModelPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpModelPath);
                        }

                        Content = Modules.CSharp.ModelWithSPs(GeneratorConfigurationComponent, Table);
                            
                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpModelPath}{Table.Name}Model.cs",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# Model with SPs {Table.Name}Model.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# model with SPs for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# DTOs
                    if (GeneratorConfigurationComponent.Configuration.WantCSharpDTOs)
                    {
                        string CSharpDTOPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\Areas\\{Table.Area}\\DTOs\\";
                        if (Directory.Exists(CSharpDTOPath))
                        {
                            LogText += $"Folder: {CSharpDTOPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpDTOPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpDTOPath);
                        }

                        Content = Modules.CSharp.DTO(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpDTOPath}{Table.Name.ToLower()}SelectAllPaged.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# DTO {Table.Name.ToLower()}SelectAllPaged.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# DTO for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Interfaces
                    if (GeneratorConfigurationComponent.Configuration.WantCSharpInterfaces)
                    {
                        string CSharpInterfacePath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\Areas\\{Table.Area}\\Interfaces\\";
                        if (Directory.Exists(CSharpInterfacePath))
                        {
                            LogText += $"Folder: {CSharpInterfacePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpInterfacePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpInterfacePath);
                        }

                        Content = Modules.CSharp.Interface(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpInterfacePath}I{Table.Name}.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# Interface I{Table.Name}.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# interface for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Filters
                    if (GeneratorConfigurationComponent.Configuration.WantCSharpFilters)
                    {
                        string CSharpFilterPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\Areas\\{Table.Area}\\Filters\\";
                        if (Directory.Exists(CSharpFilterPath))
                        {
                            LogText += $"Folder: {CSharpFilterPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpFilterPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpFilterPath);
                        }

                        Content = Modules.CSharp.Filter(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpFilterPath}{Table.Name}Filter.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# Filter {Table.Name}Filter.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# filter for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Services
                    if (GeneratorConfigurationComponent.Configuration.WantCSharpServices)
                    {
                        string CSharpServicePath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\Areas\\{Table.Area}\\Services\\";
                        if (Directory.Exists(CSharpServicePath))
                        {
                            LogText += $"Folder: {CSharpServicePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpServicePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpServicePath);
                        }

                        Content = Modules.CSharp.Service(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpServicePath}{Table.Name}Service.cs",
                        Content, GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# Service {Table.Name}Service.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# service for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# .NET Core Web API + JSON Script
                    if (GeneratorConfigurationComponent.Configuration.WantCSharpWebAPIs)
                    {
                        #region C# .NET Core Web API
                        string WebAPIPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\Areas\\{Table.Area}\\Controllers\\";
                        if (Directory.Exists(WebAPIPath))
                        {
                            LogText += $"Folder: {WebAPIPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {WebAPIPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(WebAPIPath);
                        }

                        Content = CSharpNETCore.WebAPI(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{WebAPIPath}{Table.Name}ValuesController.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                        #endregion

                        #region JSON Script
                        string JSONScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\JSONScripts\\";
                        if (Directory.Exists(JSONScriptPath))
                        {
                            LogText += $"Folder: {JSONScriptPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {JSONScriptPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(JSONScriptPath);
                        }

                        Content = Modules.CSharp.JSONScript(GeneratorConfigurationComponent);

                        WinFormConfigurationComponent.CreateFile(
                        $"{JSONScriptPath}{Table.Name}_JSONScript.json",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                        #endregion

                        LogText += $"C# .NET Core Web API Controller {Table.Name}ValuesController.cs + JSON script created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# .NET Core Web API Controller for {Table.Name} cancelled by user {Environment.NewLine}"; } 
                    #endregion

                    #region C# .NET Core Razor Pages
                        if (GeneratorConfigurationComponent.Configuration.WantCSharpRazorPages)
                        {
                        string RazorPagePath = $"{GeneratorConfigurationComponent.ProjectChosen.Path}\\Areas\\{Table.Area}\\Pages\\";
                        if (Directory.Exists(RazorPagePath))
                        {
                            LogText += $"Folder: {RazorPagePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RazorPagePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RazorPagePath);
                        }

                        #region Back of Razor Page
                        Content = CSharpNETCore.RazorPageBackQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RazorPagePath}{Table.Name}QueryPage.cshtml.cs",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET Core Razor Page (Back) Page{Table.Name}Query.cshtml.cs created {Environment.NewLine}";

                        Content = CSharpNETCore.RazorPageBackNonQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RazorPagePath}{Table.Name}NonQueryPage.cshtml.cs",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET Core Razor Page (Back) Page{Table.Name}NonQuery.cshtml.cs created {Environment.NewLine}";
                        #endregion

                        #region Front of Razor Page
                        Content = CSharpNETCore.RazorPageFrontQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RazorPagePath}{Table.Name}QueryPage.cshtml",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET Core Razor Page (Front) Page{Table.Name}Query.cshtml created {Environment.NewLine}";

                        Content = CSharpNETCore.RazorPageFrontNonQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RazorPagePath}{Table.Name}NonQueryPage.cshtml",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET Core Razor Page (Front) Page{Table.Name}NonQuery.cshtml created {Environment.NewLine}";
                        #endregion
                    }
                    else { LogText += $"Generation of C# .NET Core Razor Pages for {Table.Name} cancelled by user {Environment.NewLine}"; } 
                    #endregion
                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
