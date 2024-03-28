namespace FiyiStackApp.Generation.NET8RazorMSSQLServerCodeFirst.Modules
{
    public static partial class CSharp
    {
        public static string JSONScript(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            try
            {
                string Content =
                    $@"{{
{GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.Fields_ForJSONScript.TrimEnd('\t','\n', '\r', ',')}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
