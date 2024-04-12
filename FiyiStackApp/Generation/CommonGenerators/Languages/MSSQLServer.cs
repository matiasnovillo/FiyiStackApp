using FiyiStackApp.Models.Core;
using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Models.Tools;
using FiyiStackApp.Generation.CommonGenerators.Modules.MSSQLServer;

namespace FiyiStackApp.Generation.CommonGenerators.Languages
{
    public static class MSSQLServer
    {
        public static string Start(GeneratorConfigurationComponent GeneratorConfigurationComponent)
        {
            string LogText = "";

            #region Table
            LogText += $"Getting inside table structure. {GeneratorConfigurationComponent.lstTableToGenerate.Count} tables to work with {Environment.NewLine}";

            Action<Models.Core.Table> TableGenerator = (TableToGenerate) =>
            {
                try
                {
                    LogText += $"Searching [{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] {Environment.NewLine}";
                    FiyiStack.Library.MicrosoftSQLServer.Table MSSQLServerTable = new FiyiStack.Library.MicrosoftSQLServer.Table();

                    //Search the table, if it is not found, create it.
                    if (!MSSQLServerTable.DoesTableExist(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer, TableToGenerate.Area, TableToGenerate.Name, TableToGenerate.Scheme))
                    {
                        LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] not found. Creating it {Environment.NewLine}";

                        Modules.MSSQLServer.MSSQLServer.CreateTable(GeneratorConfigurationComponent,
                            GeneratorConfigurationComponent.DataBaseChosen.Name,
                            TableToGenerate.Area,
                            TableToGenerate.Name,
                            TableToGenerate.Scheme);

                        LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Name}] created correctly";
                    }
                    else
                    {
                        LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Name}] found {Environment.NewLine}";
                    }
                }
                catch (Exception ex) { throw ex; }
            };

            foreach (Models.Core.Table TableToGenerate in GeneratorConfigurationComponent.lstTableToGenerate)
            {
                TableGenerator(TableToGenerate);
            }
            #endregion

            #region Field
            LogText += $"Getting inside field structure. {GeneratorConfigurationComponent.lstFieldToGenerate.Count} fields to work with {Environment.NewLine}";
            Action<Models.Core.Field> FieldGenerator = (FieldToGenerate) =>
            {
                try
                {
                    LogText += $"Searching {FieldToGenerate.Name} {Environment.NewLine}";

                    FiyiStack.Library.MicrosoftSQLServer.Field MSSQLServerField = new FiyiStack.Library.MicrosoftSQLServer.Field();

                    Models.Core.Table Table = new Models.Core.Table(FieldToGenerate.TableId);

                    //Search the field, if it is not found, create it
                    if (!MSSQLServerField.DoesFieldExist(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer, Table.Area, Table.Name, Table.Scheme, FieldToGenerate.Name))
                    {
                        LogText += $"{FieldToGenerate.Name} not found. Creating it {Environment.NewLine}";

                        Modules.MSSQLServer.MSSQLServer.CreateField(GeneratorConfigurationComponent,
                            GeneratorConfigurationComponent.DataBaseChosen.Name,
                            Table.Area,
                            Table.Name,
                            Table.Scheme,
                            FieldToGenerate);

                        LogText += $"{FieldToGenerate.Name} created correctly {Environment.NewLine}";
                    }
                    else
                    {
                        LogText += $"{FieldToGenerate.Name} found {Environment.NewLine}";
                    }
                }
                catch (Exception ex) { throw ex; }
            };

            foreach (Models.Core.Field FieldToGenerate in GeneratorConfigurationComponent.lstFieldToGenerate)
            {
                Models.Core.Table TableToGenerate = new Models.Core.Table(FieldToGenerate.TableId);
                FieldGenerator(FieldToGenerate);
            }
            #endregion

            return LogText;
        }
    }
}
