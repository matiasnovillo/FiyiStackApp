using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NETFrameworkWinForm.Languages
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

                    #region C# Interface
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

                        Content = Modules.CSharp.Interface(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{InterfacePath}I{Table.Name}Repository.cs",
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

                    #region C# EntityConfiguration
                    if (GeneratorConfigurationComponent.Configuration.WantEntityConfigurationNET8BlazorMSSQLServerCodeFirst)
                    {
                        string RepositoryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8BlazorMSSQLServerCodeFirst}\\Areas\\{Table.Area}\\Entities\\EntitiesConfiguration\\";
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
                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
