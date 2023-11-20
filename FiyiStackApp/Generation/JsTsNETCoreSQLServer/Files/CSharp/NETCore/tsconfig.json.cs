using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Files.CSharp.NETCore
{
    public static class tsconfigjson
    {
        public static void Create(Project Project)
        {
            try
            {
                string Content = $@"{{
  ""compileOnSave"": true,
  ""compilerOptions"": {{
    ""strictNullChecks"": true,
    ""noImplicitAny"": false,
    ""noEmitOnError"": true,
    ""removeComments"": false,
    ""sourceMap"": true,
    ""target"": ""es5"",
    ""lib"": [ ""dom"", ""es2017"" ]
  }},
  ""include"": [
    ""wwwroot/ts/**/*.ts""
  ],
  ""exclude"": [
    ""**/node_modules"",
    ""**/ClientApp""
  ]
}}";

                string Path = $"{Project.Path}\\";
                if (!Directory.Exists(Path))
                { Directory.CreateDirectory(Path); }

                WinFormConfigurationComponent.CreateFile(
                $"{Path}tsconfig.json",
                Content,
                true);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
