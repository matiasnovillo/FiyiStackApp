using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET6CleanArchitecture.Languages
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

                    #region ITableRepository
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string ITableRepositoryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Abstractions\\";
                        if (Directory.Exists(ITableRepositoryPath))
                        {
                            LogText += $"Folder: {ITableRepositoryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {ITableRepositoryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(ITableRepositoryPath);
                        }

                        Content = Modules.CSharp.ITableRepository(GeneratorConfigurationComponent, Table);
                            
                        WinFormConfigurationComponent.CreateFile(
                        $"{ITableRepositoryPath}I{Table.Name}Repository.cs",
                        Content, 
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region ServiceCollectionExtensionsFromTable
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string ServiceCollectionExtensionsFromTablePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}\\Extensions\\";
                        if (Directory.Exists(ServiceCollectionExtensionsFromTablePath))
                        {
                            LogText += $"Folder: {ServiceCollectionExtensionsFromTablePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {ServiceCollectionExtensionsFromTablePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(ServiceCollectionExtensionsFromTablePath);
                        }

                        Content = Modules.CSharp.ServiceCollectionExtensionsFromTable(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{ServiceCollectionExtensionsFromTablePath}ServiceCollectionExtensions.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region ServiceCollectionExtensionsFromTableCore
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string ServiceCollectionExtensionsFromTableCorePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Extensions\\";
                        if (Directory.Exists(ServiceCollectionExtensionsFromTableCorePath))
                        {
                            LogText += $"Folder: {ServiceCollectionExtensionsFromTableCorePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {ServiceCollectionExtensionsFromTableCorePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(ServiceCollectionExtensionsFromTableCorePath);
                        }

                        Content = Modules.CSharp.ServiceCollectionExtensionsFromTableCore(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{ServiceCollectionExtensionsFromTableCorePath}ServiceCollectionExtensions.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region ServiceCollectionExtensionsFromTableCore
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string TableControllerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}\\Controllers\\";
                        if (Directory.Exists(TableControllerPath))
                        {
                            LogText += $"Folder: {TableControllerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {TableControllerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(TableControllerPath);
                        }

                        Content = Modules.CSharp.TableController(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{TableControllerPath}{Table.Name}Controller.cs",
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
