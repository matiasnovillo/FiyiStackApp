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

                    #region CreateTableInput
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string CreateTableInputPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}\\Input\\";
                        if (Directory.Exists(CreateTableInputPath))
                        {
                            LogText += $"Folder: {CreateTableInputPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CreateTableInputPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CreateTableInputPath);
                        }

                        Content = Modules.CSharp.CreateTableInput(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CreateTableInputPath}Create{Table.Name}Input.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region GetManyTableInput
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string GetManyTableInputPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}\\Input\\";
                        if (Directory.Exists(GetManyTableInputPath))
                        {
                            LogText += $"Folder: {GetManyTableInputPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {GetManyTableInputPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(GetManyTableInputPath);
                        }

                        Content = Modules.CSharp.GetManyTableInput(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{GetManyTableInputPath}GetMany{Table.Name}Input.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region UpdateTableInput
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string UpdateTableInputPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}\\Input\\";
                        if (Directory.Exists(UpdateTableInputPath))
                        {
                            LogText += $"Folder: {UpdateTableInputPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {UpdateTableInputPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(UpdateTableInputPath);
                        }

                        Content = Modules.CSharp.UpdateTableInput(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{UpdateTableInputPath}Update{Table.Name}Input.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region CreateTableRequest
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string CreateTableRequestPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Create{Table.Name}";
                        if (Directory.Exists(CreateTableRequestPath))
                        {
                            LogText += $"Folder: {CreateTableRequestPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CreateTableRequestPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CreateTableRequestPath);
                        }

                        Content = Modules.CSharp.CreateTableRequest(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CreateTableRequestPath}Create{Table.Name}Request.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region CreateTableRequestHandler
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string CreateTableRequestHandlerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Create{Table.Name}";
                        if (Directory.Exists(CreateTableRequestHandlerPath))
                        {
                            LogText += $"Folder: {CreateTableRequestHandlerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CreateTableRequestHandlerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CreateTableRequestHandlerPath);
                        }

                        Content = Modules.CSharp.CreateTableRequestHandler(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CreateTableRequestHandlerPath}Create{Table.Name}RequestHandler.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region CreateTableResponse
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string CreateTableResponsePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Create{Table.Name}";
                        if (Directory.Exists(CreateTableResponsePath))
                        {
                            LogText += $"Folder: {CreateTableResponsePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {CreateTableResponsePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(CreateTableResponsePath);
                        }

                        Content = Modules.CSharp.CreateTableResponse(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{CreateTableResponsePath}Create{Table.Name}Response.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region GetManyTableRequest
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string GetManyTableRequestPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\GetMany{Table.Name}";
                        if (Directory.Exists(GetManyTableRequestPath))
                        {
                            LogText += $"Folder: {GetManyTableRequestPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {GetManyTableRequestPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(GetManyTableRequestPath);
                        }

                        Content = Modules.CSharp.GetManyTableRequest(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{GetManyTableRequestPath}GetMany{Table.Name}Request.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region GetManyTableRequestHandler
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string GetManyTableRequestHandlerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\GetMany{Table.Name}";
                        if (Directory.Exists(GetManyTableRequestHandlerPath))
                        {
                            LogText += $"Folder: {GetManyTableRequestHandlerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {GetManyTableRequestHandlerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(GetManyTableRequestHandlerPath);
                        }

                        Content = Modules.CSharp.GetManyTableRequestHandler(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{GetManyTableRequestHandlerPath}GetMany{Table.Name}RequestHandler.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region GetManyTableResponse
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string GetManyTableResponsePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\GetMany{Table.Name}";
                        if (Directory.Exists(GetManyTableResponsePath))
                        {
                            LogText += $"Folder: {GetManyTableResponsePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {GetManyTableResponsePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(GetManyTableResponsePath);
                        }

                        Content = Modules.CSharp.GetManyTableResponse(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{GetManyTableResponsePath}GetMany{Table.Name}Response.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region GetOneTableRequest
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string GetOneTableRequestPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\GetOne{Table.Name}";
                        if (Directory.Exists(GetOneTableRequestPath))
                        {
                            LogText += $"Folder: {GetOneTableRequestPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {GetOneTableRequestPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(GetOneTableRequestPath);
                        }

                        Content = Modules.CSharp.GetOneTableRequest(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{GetOneTableRequestPath}GetOne{Table.Name}Request.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region GetOneTableRequestHandler
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string GetOneTableRequestHandlerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\GetOne{Table.Name}";
                        if (Directory.Exists(GetOneTableRequestHandlerPath))
                        {
                            LogText += $"Folder: {GetOneTableRequestHandlerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {GetOneTableRequestHandlerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(GetOneTableRequestHandlerPath);
                        }

                        Content = Modules.CSharp.GetOneTableRequestHandler(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{GetOneTableRequestHandlerPath}GetOne{Table.Name}RequestHandler.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region GetOneTableResponse
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string GetOneTableResponsePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\GetOne{Table.Name}";
                        if (Directory.Exists(GetOneTableResponsePath))
                        {
                            LogText += $"Folder: {GetOneTableResponsePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {GetOneTableResponsePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(GetOneTableResponsePath);
                        }

                        Content = Modules.CSharp.GetOneTableResponse(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{GetOneTableResponsePath}GetOne{Table.Name}Response.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region RemoveTableRequest
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string RemoveTableRequestPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Remove{Table.Name}";
                        if (Directory.Exists(RemoveTableRequestPath))
                        {
                            LogText += $"Folder: {RemoveTableRequestPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RemoveTableRequestPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RemoveTableRequestPath);
                        }

                        Content = Modules.CSharp.RemoveTableRequest(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RemoveTableRequestPath}Remove{Table.Name}Request.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region RemoveTableRequestHandler
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string RemoveTableRequestHandlerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Remove{Table.Name}";
                        if (Directory.Exists(RemoveTableRequestHandlerPath))
                        {
                            LogText += $"Folder: {RemoveTableRequestHandlerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RemoveTableRequestHandlerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RemoveTableRequestHandlerPath);
                        }

                        Content = Modules.CSharp.RemoveTableRequestHandler(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RemoveTableRequestHandlerPath}Remove{Table.Name}RequestHandler.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region RemoveTableResponse
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string RemoveTableResponsePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Remove{Table.Name}";
                        if (Directory.Exists(RemoveTableResponsePath))
                        {
                            LogText += $"Folder: {RemoveTableResponsePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RemoveTableResponsePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RemoveTableResponsePath);
                        }

                        Content = Modules.CSharp.RemoveTableResponse(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RemoveTableResponsePath}Remove{Table.Name}Response.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region RestoreTableRequest
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string RestoreTableRequestPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Restore{Table.Name}";
                        if (Directory.Exists(RestoreTableRequestPath))
                        {
                            LogText += $"Folder: {RestoreTableRequestPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RestoreTableRequestPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RestoreTableRequestPath);
                        }

                        Content = Modules.CSharp.RestoreTableRequest(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RestoreTableRequestPath}Restore{Table.Name}Request.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region RestoreTableRequestHandler
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string RestoreTableRequestHandlerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Restore{Table.Name}";
                        if (Directory.Exists(RestoreTableRequestHandlerPath))
                        {
                            LogText += $"Folder: {RestoreTableRequestHandlerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RestoreTableRequestHandlerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RestoreTableRequestHandlerPath);
                        }

                        Content = Modules.CSharp.RestoreTableRequestHandler(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RestoreTableRequestHandlerPath}Restore{Table.Name}RequestHandler.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region RestoreTableResponse
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string RestoreTableResponsePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Restore{Table.Name}";
                        if (Directory.Exists(RestoreTableResponsePath))
                        {
                            LogText += $"Folder: {RestoreTableResponsePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {RestoreTableResponsePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(RestoreTableResponsePath);
                        }

                        Content = Modules.CSharp.RestoreTableResponse(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{RestoreTableResponsePath}Restore{Table.Name}Response.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region UpdateTableRequest
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string UpdateTableRequestPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Update{Table.Name}";
                        if (Directory.Exists(UpdateTableRequestPath))
                        {
                            LogText += $"Folder: {UpdateTableRequestPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {UpdateTableRequestPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(UpdateTableRequestPath);
                        }

                        Content = Modules.CSharp.UpdateTableRequest(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{UpdateTableRequestPath}Update{Table.Name}Request.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region UpdateTableRequestHandler
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string UpdateTableRequestHandlerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Update{Table.Name}";
                        if (Directory.Exists(UpdateTableRequestHandlerPath))
                        {
                            LogText += $"Folder: {UpdateTableRequestHandlerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {UpdateTableRequestHandlerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(UpdateTableRequestHandlerPath);
                        }

                        Content = Modules.CSharp.UpdateTableRequestHandler(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{UpdateTableRequestHandlerPath}Update{Table.Name}RequestHandler.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region UpdateTableResponse
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string UpdateTableResponsePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Features\\Update{Table.Name}";
                        if (Directory.Exists(UpdateTableResponsePath))
                        {
                            LogText += $"Folder: {UpdateTableResponsePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {UpdateTableResponsePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(UpdateTableResponsePath);
                        }

                        Content = Modules.CSharp.UpdateTableResponse(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{UpdateTableResponsePath}Update{Table.Name}Response.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region ModuleProfile
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string ModuleProfilePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Core\\Mapping\\";
                        if (Directory.Exists(ModuleProfilePath))
                        {
                            LogText += $"Folder: {ModuleProfilePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {ModuleProfilePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(ModuleProfilePath);
                        }

                        Content = Modules.CSharp.ModuleProfile(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{ModuleProfilePath}ModuleProfile.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region ServiceCollectionExtensionsFromInfrastructure
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string ServiceCollectionExtensionsFromInfrastructurePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Infrastructure\\Extensions\\";
                        if (Directory.Exists(ServiceCollectionExtensionsFromInfrastructurePath))
                        {
                            LogText += $"Folder: {ServiceCollectionExtensionsFromInfrastructurePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {ServiceCollectionExtensionsFromInfrastructurePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(ServiceCollectionExtensionsFromInfrastructurePath);
                        }

                        Content = Modules.CSharp.ServiceCollectionExtensionsFromInfrastructure(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{ServiceCollectionExtensionsFromInfrastructurePath}ServiceCollectionExtensions.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region TableRepository
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string TableRepositoryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Infrastructure\\Persistence\\";
                        if (Directory.Exists(TableRepositoryPath))
                        {
                            LogText += $"Folder: {TableRepositoryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {TableRepositoryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(TableRepositoryPath);
                        }

                        Content = Modules.CSharp.TableRepository(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{TableRepositoryPath}{Table.Name}Repository.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region TableTest
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string TableTestPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Modules\\{Table.Name}\\{Table.Name}.Test\\";
                        if (Directory.Exists(TableTestPath))
                        {
                            LogText += $"Folder: {TableTestPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {TableTestPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(TableTestPath);
                        }

                        Content = Modules.CSharp.TableTest(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{TableTestPath}{Table.Name}Test.cs",
                        Content,
                        GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region Table
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPI)
                    {
                        string TablePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET6CleanArchitecture}\\api\\Common\\Shared.Core\\Domain\\";
                        if (Directory.Exists(TablePath))
                        {
                            LogText += $"Folder: {TablePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {TablePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(TablePath);
                        }

                        Content = Modules.CSharp.Table(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                        $"{TablePath}{Table.Name}.cs",
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
