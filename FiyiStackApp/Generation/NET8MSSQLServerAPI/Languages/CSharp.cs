using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules;

namespace FiyiStackApp.Generation.NET8MSSQLServerAPI.Languages
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

                    //Here we prepare the fieldChainerNET8MSSQLServerAPI object for every table to generate
                    GeneratorConfigurationComponent.fieldChainerNET8MSSQLServerAPI = new fieldChainerNET8MSSQLServerAPI(Table);
                    GeneratorConfigurationComponent.modelChainerNET8MSSQLServerAPI = new modelChainerNET8MSSQLServerAPI(Table, GeneratorConfigurationComponent.lstTableInFiyiStack);

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region C# Models with stored procedures
                    if (GeneratorConfigurationComponent.Configuration.WantNET8MSSQLServerAPI)
                    {
                        string CSharpModelPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\Areas\\{Table.Area}\\Models\\";
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
                    if (GeneratorConfigurationComponent.Configuration.WantNET8MSSQLServerAPI)
                    {
                        string CSharpDTOPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\Areas\\{Table.Area}\\DTOs\\";
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
                    if (GeneratorConfigurationComponent.Configuration.WantNET8MSSQLServerAPI)
                    {
                        string CSharpInterfacePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\Areas\\{Table.Area}\\Interfaces\\";
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
                    if (GeneratorConfigurationComponent.Configuration.WantNET8MSSQLServerAPI)
                    {
                        string CSharpFilterPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\Areas\\{Table.Area}\\Filters\\";
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
                    if (GeneratorConfigurationComponent.Configuration.WantNET8MSSQLServerAPI)
                    {
                        string CSharpServicePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\Areas\\{Table.Area}\\Services\\";
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

                    #region C# .NET 8 Web API + JSON Script + HTTP file
                    if (GeneratorConfigurationComponent.Configuration.WantNET8MSSQLServerAPI)
                    {
                        #region C# .NET 8 Web API
                        string WebAPIPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\Areas\\{Table.Area}\\Controllers\\";
                        if (Directory.Exists(WebAPIPath))
                        {
                            LogText += $"Folder: {WebAPIPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {WebAPIPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(WebAPIPath);
                        }

                        Content = CSharpNET8.WebAPI(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{WebAPIPath}{Table.Name}ValuesController.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                        #endregion

                        #region JSON Script
                        string JSONScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\JSONScripts\\";
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

                        #region HTTP file
                        string HTTPFilePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8MSSQLServerAPI}\\HTTPFile\\";
                        if (Directory.Exists(HTTPFilePath))
                        {
                            LogText += $"Folder: {HTTPFilePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {HTTPFilePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(HTTPFilePath);
                        }

                        Content = Modules.CSharp.HTTPFile(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{HTTPFilePath}{Table.Name}.http",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                        #endregion

                        LogText += $"C# .NET Core Web API Controller {Table.Name}ValuesController.cs + JSON script created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of C# .NET Core Web API Controller for {Table.Name} cancelled by user {Environment.NewLine}"; } 
                    #endregion
                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
