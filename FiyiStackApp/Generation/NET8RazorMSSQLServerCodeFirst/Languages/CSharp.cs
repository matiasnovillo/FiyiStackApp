using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Languages
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
                    GeneratorConfigurationComponent.fieldChainerNET8RazorMSSQLServerCodeFirst = new fieldChainerNET8RazorMSSQLServerCodeFirst(Table);

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region C# Entities
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpEntityPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Entities\\";
                        if (Directory.Exists(CSharpEntityPath))
                        {
                            LogText += $"Folder: {CSharpEntityPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpEntityPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpEntityPath);
                        }

                        Content = Modules.CSharp.Entity(GeneratorConfigurationComponent, Table);
                            
                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpEntityPath}{Table.Name}.cs",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# entity {Table.Name}.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# entity for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Entities configurations
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpEntityConfigurationPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\EntitiesConfiguration\\";
                        if (Directory.Exists(CSharpEntityConfigurationPath))
                        {
                            LogText += $"Folder: {CSharpEntityConfigurationPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpEntityConfigurationPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpEntityConfigurationPath);
                        }

                        Content = Modules.CSharp.EntityConfiguration(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpEntityConfigurationPath}{Table.Name}Configuration.cs",
                        Content, GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# entity configuration {Table.Name}Configuration.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# entity configuration for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# DTOs
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpDTOPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\DTOs\\";
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
                        $"{CSharpDTOPath}paginated{Table.Name}DTO.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# DTO paginated{Table.Name.ToLower()}DTO.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# DTO for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Interface for Repository
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpInterfaceForRepositoryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Interfaces\\";
                        if (Directory.Exists(CSharpInterfaceForRepositoryPath))
                        {
                            LogText += $"Folder: {CSharpInterfaceForRepositoryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpInterfaceForRepositoryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpInterfaceForRepositoryPath);
                        }

                        Content = Modules.CSharp.InterfaceForRepository(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpInterfaceForRepositoryPath}I{Table.Name}Repository.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# Interface I{Table.Name}Repository.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# interface for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Interface for Service
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpInterfaceForServicePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Interfaces\\";
                        if (Directory.Exists(CSharpInterfaceForServicePath))
                        {
                            LogText += $"Folder: {CSharpInterfaceForServicePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpInterfaceForServicePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpInterfaceForServicePath);
                        }

                        Content = Modules.CSharp.InterfaceForService(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpInterfaceForServicePath}I{Table.Name}Service.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# Interface I{Table.Name}Service.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# interface for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Filters
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpFilterPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Filters\\";
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

                    #region C# Repositories
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpRepositoryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Repositories\\";
                        if (Directory.Exists(CSharpRepositoryPath))
                        {
                            LogText += $"Folder: {CSharpRepositoryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpRepositoryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpRepositoryPath);
                        }

                        Content = Modules.CSharp.Repository(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpRepositoryPath}{Table.Name}Repository.cs",
                        Content, GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# Repository {Table.Name}Repository.cs created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# repository for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region C# Services
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string CSharpServicePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Services\\";
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

                    #region C# .NET 8 Controller
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        #region C# .NET Core Web API
                        string CSharpControllerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Controllers\\";
                        if (Directory.Exists(CSharpControllerPath))
                        {
                            LogText += $"Folder: {CSharpControllerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CSharpControllerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CSharpControllerPath);
                        }

                        Content = Modules.CSharp.Controller(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CSharpControllerPath}{Table.Name}ValuesController.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                        #endregion

                        LogText += $"C# .NET 8 Web API Controller {Table.Name}ValuesController.cs + JSON script created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# .NET 8 Web API Controller for {Table.Name} cancelled by user {Environment.NewLine}"; } 
                    #endregion

                    #region C# .NET Core Razor Pages
                        if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                        {
                        string RazorPagePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Pages\\";
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
                        $"{RazorPagePath}{Table.Name}.cshtml.cs",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET 8 Razor Page (Back) {Table.Name}.cshtml.cs created {Environment.NewLine}";

                        Content = CSharpNETCore.RazorPageBackNonQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RazorPagePath}{Table.Name}Id.cshtml.cs",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET 8 Razor Page (Back) {Table.Name}Id.cshtml.cs created {Environment.NewLine}";
                        #endregion

                        #region Front of Razor Page
                        Content = CSharpNETCore.RazorPageFrontQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RazorPagePath}{Table.Name}.cshtml",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET 8 Razor Page (Front) {Table.Name}Page.cshtml created {Environment.NewLine}";

                        Content = CSharpNETCore.RazorPageFrontNonQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RazorPagePath}{Table.Name}Id.cshtml",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"C# .NET 8 Razor Page (Front) Page{Table.Name}NonQuery.cshtml created {Environment.NewLine}";
                        #endregion
                    }
                    else { LogText += $"Generation of C# .NET 8 Razor Pages for {Table.Name} cancelled by user {Environment.NewLine}"; } 
                    #endregion
                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
