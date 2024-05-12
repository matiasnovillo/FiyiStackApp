namespace FiyiStackApp.Models.Tools
{
    public static class connectionStrings
    {
        public static string fiyistack_FiyiStackAppDevelopment = $@"data source =.; 
initial catalog = fiyistack_FiyiStackApp; 
Integrated Security = SSPI; 
MultipleActiveResultSets=True;
Pooling=false;
persist security info=True;
App=EntityFramework;
TrustServerCertificate=true";

        public static string fiyistac_FiyiStackAppProduction = "Password=Of0@c40d6;" +
                    "Persist Security Info=True;" +
                    "User ID=fiyista1_FiyiStackAppAdmin;" +
                    "Initial Catalog=fiyista1_FiyiStackApp;" +
                    "Data Source=sql4.baehost.com;" +
                    "TrustServerCertificate=True";
    }
}
