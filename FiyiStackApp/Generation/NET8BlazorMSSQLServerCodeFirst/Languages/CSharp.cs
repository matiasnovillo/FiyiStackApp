using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8BlazorMSSQLServerCodeFirst.Languages
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
                    GeneratorConfigurationComponent.fieldChainerNET8BlazorMSSQLServerCodeFirst = new(Table);

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region C# DTO
                    if (GeneratorConfigurationComponent.Configuration.WantDTONET8BlazorMSSQLServerCodeFirst)
                    {
                        string DTOPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\DTOs\\";
                        if (Directory.Exists(DTOPath))
                        {
                            LogText += $"Folder: {DTOPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {DTOPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(DTOPath);
                        }

                        Content = Modules.CSharp.DTO(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{DTOPath}paginated{Table.Name}DTO.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Entity
                    if (GeneratorConfigurationComponent.Configuration.WantEntityNET8BlazorMSSQLServerCodeFirst)
                    {
                        string EntityPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Entities\\";
                        if (Directory.Exists(EntityPath))
                        {
                            LogText += $"Folder: {EntityPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {EntityPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(EntityPath);
                        }

                        Content = Modules.CSharp.Entity(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{EntityPath}{Table.Name}.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Interface for repository
                    if (GeneratorConfigurationComponent.Configuration.WantInterfaceNET8BlazorMSSQLServerCodeFirst)
                    {
                        string InterfacePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Interfaces\\";
                        if (Directory.Exists(InterfacePath))
                        {
                            LogText += $"Folder: {InterfacePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {InterfacePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(InterfacePath);
                        }

                        Content = Modules.CSharp.InterfaceRepository(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{InterfacePath}I{Table.Name}Repository.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Interface for service
                    if (GeneratorConfigurationComponent.Configuration.WantInterfaceNET8BlazorMSSQLServerCodeFirst)
                    {
                        string InterfacePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Interfaces\\";
                        if (Directory.Exists(InterfacePath))
                        {
                            LogText += $"Folder: {InterfacePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {InterfacePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(InterfacePath);
                        }

                        Content = Modules.CSharp.InterfaceService(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{InterfacePath}I{Table.Name}Service.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Repository
                    if (GeneratorConfigurationComponent.Configuration.WantRepositoryNET8BlazorMSSQLServerCodeFirst)
                    {
                        string RepositoryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Repositories\\";
                        if (Directory.Exists(RepositoryPath))
                        {
                            LogText += $"Folder: {RepositoryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RepositoryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RepositoryPath);
                        }

                        Content = Modules.CSharp.Repository(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RepositoryPath}{Table.Name}Repository.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Service
                    if (GeneratorConfigurationComponent.Configuration.WantServiceNET8BlazorMSSQLServerCodeFirst)
                    {
                        string ServicePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Services\\";
                        if (Directory.Exists(ServicePath))
                        {
                            LogText += $"Folder: {ServicePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {ServicePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(ServicePath);
                        }

                        Content = Modules.CSharp.Service(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{ServicePath}{Table.Name}Service.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# EntityConfiguration
                    if (GeneratorConfigurationComponent.Configuration.WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst)
                    {
                        string RepositoryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\EntitiesConfiguration\\";
                        if (Directory.Exists(RepositoryPath))
                        {
                            LogText += $"Folder: {RepositoryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RepositoryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RepositoryPath);
                        }

                        Content = Modules.CSharp.EntityConfiguration(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RepositoryPath}{Table.Name}Configuration.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Blazor Pages (Query)
                    if (GeneratorConfigurationComponent.Configuration.WantBlazorPageNET8BlazorMSSQLServerCodeFirst)
                    {
                        string BlazorPagePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Components\\Pages\\{Table.Area}Pages\\{Table.Name}\\";
                        if (Directory.Exists(BlazorPagePath))
                        {
                            LogText += $"Folder: {BlazorPagePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {BlazorPagePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(BlazorPagePath);
                        }

                        Content = Modules.CSharp.BlazorPageQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{BlazorPagePath}{Table.Name}Page.razor",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Blazor Pages (Non-Query)
                    if (GeneratorConfigurationComponent.Configuration.WantBlazorPageNET8BlazorMSSQLServerCodeFirst)
                    {
                        string BlazorPagePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Components\\Pages\\{Table.Area}Pages\\{Table.Name}\\";
                        if (Directory.Exists(BlazorPagePath))
                        {
                            LogText += $"Folder: {BlazorPagePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {BlazorPagePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(BlazorPagePath);
                        }

                        Content = Modules.CSharp.BlazorPageNonQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{BlazorPagePath}{Table.Name}IdPage.razor",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion
                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
