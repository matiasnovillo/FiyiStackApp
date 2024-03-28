using FiyiStackApp.Models.Core;


namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Languages
{
    public static class JavaScript
    {
        public static string Start(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            try
            {
                string LogText = "";

                foreach (Table Table in GeneratorConfigurationComponent.lstTableToGenerate)
                {
                    if (Table.Area == "" || Table.Name == "") { throw new Exception("JavaScript generation cancelled. A table does not have an area or name declared"); }

                    LogText += $"Working with {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region jQuery in JavaScript
                    if (GeneratorConfigurationComponent.Configuration.WantjQueryDOMManipulator)
                    {
                        string jQueryPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\wwwroot\\js\\{Table.Area}\\{Table.Name}\\jQuery\\";
                        if (Directory.Exists(jQueryPath))
                        {
                            LogText += $"Folder: {jQueryPath} exist {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Folder: {jQueryPath} does not exist. Creating folder {Environment.NewLine}";
                            Directory.CreateDirectory(jQueryPath);
                        }

                        Content = Modules.JavaScript.jQueryNonQuery(GeneratorConfigurationComponent, Table);

                        WinFormConfigurationComponent.CreateFile(
                            $"{jQueryPath}{Table.Name}NonQuery_jQuery.js",
                            Content, 
                            GeneratorConfigurationComponent.Configuration.DeleteFiles);

                        LogText += $"jQuery in JavaScript {Table.Name}Query_jQuery.js created {Environment.NewLine}";
                    }
                    else { LogText += $"Generation of jQuery in JavaScript for {Table.Name} cancelled by user {Environment.NewLine}"; }
                    #endregion
                }

                return LogText;
            }
            catch (Exception) { throw; }
        }
    }
}
