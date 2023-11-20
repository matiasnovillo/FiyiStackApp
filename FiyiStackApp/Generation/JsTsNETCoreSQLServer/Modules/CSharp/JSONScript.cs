namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class CSharp
    {
        public static string JSONScript(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            try
            {
                string Content =
                    $@"{{
{GeneratorConfigurationComponent.fieldChainer.Fields_ForJSONScript.TrimEnd('\t','\n', '\r', ',')}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
