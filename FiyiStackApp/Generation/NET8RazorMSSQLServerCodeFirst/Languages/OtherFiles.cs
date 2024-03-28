using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Languages
{
    public static class OtherFiles
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
                    GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer = new fieldChainerJsTsNETCoreSQLServer(Table);
                    GeneratorConfigurationComponent.modelChainerJsTsNETCoreSQLServer = new modelChainerJsTsNETCoreSQLServer(Table, GeneratorConfigurationComponent.lstTableInFiyiStack);

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region JSON Script
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string JSONScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\JSONScriptsForPostman\\";
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
                    }
                    #endregion

                    #region HTTP file
                    string HTTPFilePath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\HTTPFilesForTestingAPIs\\";
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
                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
