using FiyiStackApp.Models.Core;
using FiyiStackApp.Models.Tools;

namespace FiyiStackApp.Generation.NodeJsExpressMongoDB.Languages
{
    public static class TypeScript
    {
        public static string Start(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            try
            {
                string LogText = "";

                foreach (Table Table in GeneratorConfigurationComponent.lstTableToGenerate)
                {
                    if (Table.Area == "" || Table.Name == "") { throw new Exception("TypeScript generation cancelled. A table does not have an area or name declared"); }

                    //Here we prepare the fieldChainer object for every table to generate
                    GeneratorConfigurationComponent.fieldChainerNodeJsExpressMongoDB = new fieldChainerNodeJsExpressMongoDB(Table);

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region controllers
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPINodeJsExpressMongoDB)
                    {
                        string controllerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNodeJsExpressMongoDB}\\src\\controllers\\{Table.Area}\\";
                        if (Directory.Exists(controllerPath))
                        {
                            LogText += $"Folder: {controllerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {controllerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(controllerPath);
                        }

                        Content = Modules.TypeScript.controllers(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{controllerPath}{Table.Name}Controller.ts",
                            Content, 
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region db
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPINodeJsExpressMongoDB)
                    {
                        string dbPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNodeJsExpressMongoDB}\\src\\db\\{Table.Area}\\";
                        if (Directory.Exists(dbPath))
                        {
                            LogText += $"Folder: {dbPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {dbPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(dbPath);
                        }

                        Content = Modules.TypeScript.db(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{dbPath}{Table.Name}Model.ts",
                            Content,
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region router
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPINodeJsExpressMongoDB)
                    {
                        string routerPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNodeJsExpressMongoDB}\\src\\router\\{Table.Area}\\";
                        if (Directory.Exists(routerPath))
                        {
                            LogText += $"Folder: {routerPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {routerPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(routerPath);
                        }

                        Content = Modules.TypeScript.router(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{routerPath}{Table.Name}Router.ts",
                            Content,
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion

                    #region httpfile
                    if (GeneratorConfigurationComponent.Configuration.WantBackendAPINodeJsExpressMongoDB)
                    {
                        string httpfilePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNodeJsExpressMongoDB}\\test\\{Table.Area}\\";
                        if (Directory.Exists(httpfilePath))
                        {
                            LogText += $"Folder: {httpfilePath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {httpfilePath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(httpfilePath);
                        }

                        Content = Modules.TypeScript.httpfile(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{httpfilePath}{Table.Name}.http",
                            Content,
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);
                    }
                    #endregion
                }

                return LogText;
            }
            catch (Exception) { throw; }
        }
    }
}
