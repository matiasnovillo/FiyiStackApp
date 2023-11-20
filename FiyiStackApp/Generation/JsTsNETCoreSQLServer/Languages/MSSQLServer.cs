using FiyiStackApp.Models.Core;
using FiyiStackApp.Generation.Modules;
using FiyiStack.Library.MicrosoftSQLServer;
using FiyiStackApp.Models.Tools;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Languages
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
                    GeneratorConfigurationComponent.fieldChainer = new fieldChainer(TableToGenerate);
                    FiyiStack.Library.MicrosoftSQLServer.Table MSSQLServerTable = new FiyiStack.Library.MicrosoftSQLServer.Table();

                    //Search the table, if it is not found, create it.
                    if (!MSSQLServerTable.DoesTableExist(GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer, TableToGenerate.Area, TableToGenerate.Name, TableToGenerate.Scheme))
                    {
                        LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] not found. Creating it {Environment.NewLine}";

                        Modules.MSSQLServer.CreateTable(GeneratorConfigurationComponent,
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

                        Modules.MSSQLServer.CreateField(GeneratorConfigurationComponent,
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

            #region Stored procedure
            LogText += $"Getting inside stored procedure structure. {GeneratorConfigurationComponent.lstStoredProcedureToGenerate.Count} to work with {Environment.NewLine}";
            Action<StoredProcedure> ActionForStoredProcedures = (StoredProcedureToGenerate) =>
            {
                try
                {
                    string CompleteStoredProcedureName = $"[{StoredProcedureToGenerate.SchemeName}].[{StoredProcedureToGenerate.TableArea}.{StoredProcedureToGenerate.TableName}.{StoredProcedureToGenerate.Action}]";
                    LogText += $"Searching {CompleteStoredProcedureName} {Environment.NewLine}";

                    StoredProcedure MSSQLServerStoredProcedure = new StoredProcedure();

                //Search the stored procedure, if it is not found, create it
                bool CreateStoredProcedure = true;
                    if (!MSSQLServerStoredProcedure.ExistStoredProcedure(
                        GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer,
                        GeneratorConfigurationComponent.DataBaseChosen.Name,
                        StoredProcedureToGenerate.SchemeName,
                        StoredProcedureToGenerate.TableArea,
                        StoredProcedureToGenerate.TableName,
                        StoredProcedureToGenerate.Action,
                        true))
                    { LogText += $"{CompleteStoredProcedureName} not found. Creating it {Environment.NewLine}"; CreateStoredProcedure = true; }
                    else
                    {
                    //Delete the stored procedure if the user allow
                    if (GeneratorConfigurationComponent.Configuration.DeleteStoredProcedure)
                        {
                            LogText += $"{CompleteStoredProcedureName} found. Deleting and creating it {Environment.NewLine}";
                            Modules.MSSQLServer.DeleteStoredProcedure(
                                GeneratorConfigurationComponent.DataBaseChosen.ConnectionStringForMSSQLServer,
                                GeneratorConfigurationComponent.DataBaseChosen.Name,
                                StoredProcedureToGenerate.SchemeName,
                                StoredProcedureToGenerate.TableArea,
                                StoredProcedureToGenerate.TableName,
                                StoredProcedureToGenerate.Action);
                            CreateStoredProcedure = true;
                        }
                        else
                        {
                            LogText += $"{CompleteStoredProcedureName} found. FiyiStack is not allowed to delete it. {Environment.NewLine}";
                            CreateStoredProcedure = false;
                        }
                    }

                    if (CreateStoredProcedure)
                    {
                        //Search the table
                        Models.Core.Table Table = new Models.Core.Table(
                            GeneratorConfigurationComponent.DataBaseChosen.DataBaseId,
                            StoredProcedureToGenerate.TableArea,
                            StoredProcedureToGenerate.TableName,
                            StoredProcedureToGenerate.SchemeName);

                        //Insert
                        if (StoredProcedureToGenerate.Action.StartsWith("Insert"))
                        {
                            Modules.MSSQLServer.CreateStoredProcedureInsert(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }
                        //UpdateBy
                        if (StoredProcedureToGenerate.Action.StartsWith("UpdateBy"))
                        {
                            Modules.MSSQLServer.CreateStoredProcedureUpdateBy(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }
                        //Count
                        if (StoredProcedureToGenerate.Action.StartsWith("Count"))
                        {
                            Modules.MSSQLServer.CreateStoredProcedureCount(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }
                        //DeleteAll
                        if (StoredProcedureToGenerate.Action.StartsWith("DeleteAll"))
                        {
                            Modules.MSSQLServer.CreateStoredProcedureDeleteAll(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }
                        //DeleteBy
                        if (StoredProcedureToGenerate.Action.StartsWith("DeleteBy"))
                        {
                            Modules.MSSQLServer.CreateStoredProcedureDeleteBy(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }
                        //Select1By
                        if (StoredProcedureToGenerate.Action.StartsWith("Select1By"))
                        {
                            Modules.MSSQLServer.CreateStoredProcedureSelect1By(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }
                        //SelectAll
                        if (StoredProcedureToGenerate.Action == "SelectAll")
                        {
                            Modules.MSSQLServer.CreateStoredProcedureSelectAll(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }
                        //SelectAllPaged
                        if (StoredProcedureToGenerate.Action == "SelectAllPaged")
                        {
                            Modules.MSSQLServer.CreateStoredProcedureSelectAllPaged(
                            GeneratorConfigurationComponent,
                            StoredProcedureToGenerate.Action,
                            Table);
                        }

                        LogText += $"{CompleteStoredProcedureName} created correctly {Environment.NewLine}";
                    }
                }
                catch (Exception ex) { throw ex; }
            };

            foreach (StoredProcedure StoredProcedureToGenerate in GeneratorConfigurationComponent.lstStoredProcedureToGenerate)
            {
                Models.Core.Table TableToGenerate = new Models.Core.Table().GetOneByDataBaseIdByNameBySchemeToModel(
                    GeneratorConfigurationComponent.DataBaseChosen.DataBaseId,
                    StoredProcedureToGenerate.TableArea,
                    StoredProcedureToGenerate.TableName,
                    StoredProcedureToGenerate.SchemeName);

                ActionForStoredProcedures(StoredProcedureToGenerate);
            }
            #endregion

            #region SQL Scripts in project folder
            foreach (Models.Core.Table TableToGenerate in GeneratorConfigurationComponent.lstTableToGenerate)
            {
                SQLScripts.CreateField(GeneratorConfigurationComponent, TableToGenerate);
            }
            
            #endregion

            return LogText;
        }
    }
}
