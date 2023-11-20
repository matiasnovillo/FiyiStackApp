using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Files.CSharp.NETCore
{
    public static class packagejson
    {
        public static void Create(Project Project)
        {
            try
            {
                string Content = $@"{{
  ""name"": ""{Project.Name.ToLower()}"",
  ""version"": ""1.0.0"",
  ""author"": """",
  ""main"": ""index.js"",
  ""private"": true,
  ""keywords"": [],
  ""license"": ""ISC"",
  ""//"": ""\""-vs-binding\"": {{\""BeforeBuild\"": [ \""build-prod\"" ]}}"",
  ""scripts"": {{
    ""test"": ""echo \""Error: no test specified\"" && exit 1"",
    ""build-dev"": ""webpack --mode development"",
    ""build-prod"": ""webpack"",
    ""build-vendor"": ""webpack --config webpack.config.vendor.js""
  }},
  ""dependencies"": {{
    ""@types/jqueryui"": ""^1.12.7"",
    ""@types/node"": ""^11.13.9"",
    ""@types/plotly.js"": ""^1.44.6"",
    ""bootstrap-notify"": ""^3.1.3"",
    ""jquery-ui"": ""^1.12.1"",
    ""list.js"": ""^2.3.1"",
    ""plotly.js"": ""^1.48.3"",
    ""quill"": ""^1.3.6""
  }},
  ""devDependencies"": {{
    ""@babel/core"": ""^7.13.14"",
    ""@babel/preset-env"": ""^7.13.12"",
    ""@morbidick/bootstrap"": ""^0.4.2"",
    ""@types/backbone"": ""^1.4.10"",
    ""@types/jquery"": ""^3.5.5"",
    ""@types/navigo"": ""7.0.1"",
    ""aspnet-webpack"": ""3.0.0"",
    ""awesome-typescript-loader"": ""^5.2.1"",
    ""backbone"": ""^1.4.0"",
    ""bootstrap"": ""^4.6.0"",
    ""css-loader"": ""^5.2.0"",
    ""file-loader"": ""^6.2.0"",
    ""font-awesome"": ""^4.7.0"",
    ""glob"": ""^7.1.6"",
    ""html-webpack-plugin"": ""^5.3.1"",
    ""jquery"": ""^3.6.0"",
    ""mini-css-extract-plugin"": ""^1.4.0"",
    ""navigo"": ""8.11.0"",
    ""optimize-css-assets-webpack-plugin"": ""^5.0.4"",
    ""path"": ""^0.12.7"",
    ""popper.js"": ""^1.16.1"",
    ""raw-loader"": ""^4.0.2"",
    ""rxjs"": ""^6.6.7"",
    ""rxjs-webworker"": ""0.0.2"",
    ""style-loader"": ""2.0.0"",
    ""terser-webpack-plugin"": ""^5.1.1"",
    ""typescript"": ""4.2.3"",
    ""url-loader"": ""^4.1.1"",
    ""webpack"": ""^5.30.0"",
    ""webpack-cli"": ""^4.6.0"",
    ""webpack-dev-middleware"": ""4.1.0"",
    ""webpack-hot-middleware"": ""^2.25.0""
  }},
  ""description"": """"
}}
";

                string Path = $"{Project.Path}\\";
                if (!Directory.Exists(Path))
                { Directory.CreateDirectory(Path); }

                WinFormConfigurationComponent.CreateFile(
                $"{Path}package.json",
                Content,
                true);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
