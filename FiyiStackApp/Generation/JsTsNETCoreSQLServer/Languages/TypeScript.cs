using FiyiStackApp.Models.Core;


namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Languages
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

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region TypeScript model
                    if (GeneratorConfigurationComponent.Configuration.WantTypeScriptModels)
                    {
                        string TypeScriptModelPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\wwwroot\\ts\\{Table.Area}\\{Table.Name}\\TsModels\\";
                        if (Directory.Exists(TypeScriptModelPath))
                        {
                            LogText += $"Folder: {TypeScriptModelPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {TypeScriptModelPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(TypeScriptModelPath);
                        }

                        Content = Modules.TypeScript.Model(GeneratorConfigurationComponent, Table);
                        
                        WinFormConfigurationComponent.CreateFile(
                            $"{TypeScriptModelPath}{Table.Name}_TsModel.ts", 
                            Content, 
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"TypeScript model {Table.Name}.ts created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of TypeScript model for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region jQuery in TypeScript
                    if (GeneratorConfigurationComponent.Configuration.WantjQueryDOMManipulator)
                    {
                        string jQueryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\wwwroot\\ts\\{Table.Area}\\{Table.Name}\\jQuery\\";
                        if (Directory.Exists(jQueryPath))
                        {
                            LogText += $"Folder: {jQueryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {jQueryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(jQueryPath);
                        }

                        Content = Modules.TypeScript.jQueryQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{jQueryPath}{Table.Name}Query_jQuery.ts",
                            Content, 
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"jQuery in TypeScript {Table.Name}Query_jQuery.ts created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of jQuery in TypeScript for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region TypeScript DTO
                    if (GeneratorConfigurationComponent.Configuration.WantTypeScriptDTOs)
                    {
                        string TypeScriptDTOPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\wwwroot\\ts\\{Table.Area}\\{Table.Name}\\DTOs\\";
                        if (Directory.Exists(TypeScriptDTOPath))
                        {
                            LogText += $"Folder: {TypeScriptDTOPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {TypeScriptDTOPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(TypeScriptDTOPath);
                        }

                        Content = Modules.TypeScript.DTO(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{TypeScriptDTOPath}{Table.Name.ToLower()}SelectAllPaged.ts",
                            Content,
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"TypeScript DTO {Table.Name.ToLower()}SelectAllPaged.ts created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of TypeScript DTO for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion
                }

                return LogText;
            }
            catch (Exception) { throw; }
        }
    }
}
