using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiyiStackApp.Models.Core;
using FiyiStackApp.Models.Tools;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Modules
{
    public static partial class SQLScripts
    {
        public static void CreateField(GeneratorConfigurationComponent GeneratorConfigurationComponent, Table Table)
        {

            try
            {
                GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer = new fieldChainerJsTsNETCoreSQLServer(Table);

                string Script =
                    $@"USE [{GeneratorConfigurationComponent.DataBaseChosen.Name}]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: {DateTime.Now}

{GeneratorConfigurationComponent.fieldChainerJsTsNETCoreSQLServer.SQLServerFieldsForCreateFields_ForSQLServer}";

                #region Create script in project folder
                string ScriptPath = $"{GeneratorConfigurationComponent.ProjectChosen.PathJsTsNETCoreSQLServer}\\SQLScripts\\";
                if (!Directory.Exists(ScriptPath))
                { Directory.CreateDirectory(ScriptPath); }

                WinFormConfigurationComponent.CreateFile(
                $"{ScriptPath}{Table.Area}.{Table.Name}_CreateFields.sql",
                Script,
                GeneratorConfigurationComponent.Configuration.DeleteFiles);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
