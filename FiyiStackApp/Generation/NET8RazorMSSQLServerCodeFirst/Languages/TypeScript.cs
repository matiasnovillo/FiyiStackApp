using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Languages
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

                    #region TypeScript entity
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string TypeScriptModelPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\wwwroot\\ts\\{Table.Area}\\{Table.Name}\\TsEntities\\";
                        if (Directory.Exists(TypeScriptModelPath))
                        {
                            LogText += $"Folder: {TypeScriptModelPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {TypeScriptModelPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(TypeScriptModelPath);
                        }

                        Content = Modules.TypeScript.Entity(GeneratorConfigurationComponent, Table);
                        
                        WinFormConfigurationComponent.CreateFile(
                            $"{TypeScriptModelPath}{Table.Name}_TsEntity.ts", 
                            Content, 
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"TypeScript entity {Table.Name}_TsEntity.ts created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of TypeScript entity for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region jQuery in TypeScript (Query)
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string QueryjQueryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\wwwroot\\ts\\{Table.Area}\\{Table.Name}\\jQuery\\";
                        if (Directory.Exists(QueryjQueryPath))
                        {
                            LogText += $"Folder: {QueryjQueryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {QueryjQueryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(QueryjQueryPath);
                        }

                        Content = Modules.TypeScript.jQueryQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{QueryjQueryPath}{Table.Name}Query_jQuery.ts",
                            Content,
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"jQuery in TypeScript {Table.Name}Query_jQuery.ts created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of jQuery in TypeScript for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion

                    #region TypeScript DTO
                    if (GeneratorConfigurationComponent.Configuration.WantNET8RazorMSSQLServerCodeFirst)
                    {
                        string TypeScriptDTOPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathNET8RazorMSSQLServerCodeFirst}\\wwwroot\\ts\\{Table.Area}\\{Table.Name}\\DTOs\\";
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
                            $"{TypeScriptDTOPath}paginated{Table.Name}DTO.ts",
                            Content,
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"TypeScript DTO paginated{Table.Name}DTO.ts created {Environment.NewLine}";
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
