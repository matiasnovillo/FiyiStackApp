namespace FiyiStackApp.Generation.NET8MSSQLServerAPI.Modules
{
    public static partial class CSharp
    {
        public static string JSONScript(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            try
            {
                string Content =
                    $@"{{
{GeneratorConfigurationComponent.fieldChainerNET8MSSQLServerAPI.Fields_ForJSONScript.TrimEnd('\t','\n', '\r', ',')}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
