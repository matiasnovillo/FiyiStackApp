using FiyiStackApp.Generation;
using FiyiStackApp.Models.Tools;
using FiyiStackApp.Models.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTestOverFiyiStackApp
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGenerator()
        {
            DateTime Now = DateTime.Now;
            fieldChainer fieldChainer = new fieldChainer();
            fieldChainerNodeJsExpressMongoDB fieldChainerNodeJsExpressMongoDB = new fieldChainerNodeJsExpressMongoDB();
            modelChainer modelChainer = new modelChainer();

            //Tables inside FiyiStack database = 0
            List<Table> lstTableInFiyiStack = new List<Table>();

            #region Data initialization
            Configuration Configuration = new Configuration()
            {
                Active = false,
                AddAuditingFieldsToNewTable = true,
                DateTimeCreation = Now,
                DateTimeLastModification = Now,
                DeleteField = true,
                DeleteFiles = true,
                DeleteStoredProcedure = true,
                DeleteTable = true,
                TemplateId = 1,
                UserCreationId = 1,
                UserLastModificationId = 1,
                WantCSharpFilters = true,
                WantCSharpInterfaces = true,
                WantCSharpModelsWithSPs = true,
                WantCSharpRazorPages = true,
                WantCSharpServices = true,
                WantCSharpWebAPIs = true,
                WantCSharpDTOs = true,
                WantTypeScriptModels = true,
                WantjQueryDOMManipulator = true,
                WantTypeScriptDTOs = true,
                WantBackendAPI = true,
                WantBackendAPINodeJsExpressMongoDB = true
            };
            Project ProjectChosen = new Project()
            {
                ProjectId = 1,
                Active = true,
                DateTimeCreation = Now,
                DateTimeLastModification = Now,
                GeneralHistoryUser = "",
                Name = "Test",
                PathJsTsNETCoreSQLServer = "C:\\FiyiStack\\Test\\TestDeFiyiStackApp",
                PathNET6CleanArchitecture = "C:\\FiyiStack\\Test\\TestDeFiyiStackApp",
                PathNodeJsExpressMongoDB = "C:\\FiyiStack\\Test\\TestDeFiyiStackApp",
                UserIdCreation = 1,
                UserIdLastModification = 1
            };
            DataBase DataBaseChosen = new DataBase()
            {
                ProjectId = 1,
                DataBaseId = 1,
                Active = true,
                DateTimeCreation = Now,
                DateTimeLastModification = Now,
                Name = "fiyistack_Mikromatica",
                UserIdCreation = 1,
                UserIdLastModification = 1
            };

            #endregion

            #region Tables to generate in testing
            List<Table> lstTableToGenerate = new List<Table>()
            {
                new FiyiStackApp.Models.Core.Table()
                {
                    DataBaseId = 1,
                    TableId = 8,
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    Name = "Sex",
                    Scheme = "dbo",
                    Area = "Basic.Culture",
                    Version = "1"
                },
            };
            List<Field> lstFieldToGenerate = new List<Field>()
            {
                new FiyiStackApp.Models.Core.Field()    //SexId
                {
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    TableId = 8,
                    DataTypeId = 8,
                    FieldId = 68,
                    ForeignTableName = "",
                    HistoryUser = "",
                    MaxValue = "2147483647",
                    MinValue = "1",
                    Name = "SexId",
                    Nullable = false,
                    Regex = "^[0-9]+$"
                },
                new FiyiStackApp.Models.Core.Field()    //Name
                {
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    TableId = 8,
                    DataTypeId = 5,
                    FieldId = 69,
                    ForeignTableName = "",
                    HistoryUser = "",
                    MaxValue = "500",
                    MinValue = "1",
                    Name = "Name",
                    Nullable = true,
                    Regex = ""
                },
                new FiyiStackApp.Models.Core.Field()    //Active
                {
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    TableId = 8,
                    DataTypeId = 4,
                    FieldId = 70,
                    ForeignTableName = "",
                    HistoryUser = "",
                    MaxValue = "",
                    MinValue = "",
                    Name = "Active",
                    Nullable = true,
                    Regex = ""
                },
                new FiyiStackApp.Models.Core.Field()    //UserCreationId
                {
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    TableId = 8,
                    DataTypeId = 3,
                    FieldId = 71,
                    ForeignTableName = "",
                    HistoryUser = "",
                    MaxValue = "2147483647",
                    MinValue = "1",
                    Name = "UserCreationId",
                    Nullable = true,
                    Regex = "^[0-9]+$"
                },
                new FiyiStackApp.Models.Core.Field()    //UserLastModificationId
                {
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    TableId = 8,
                    DataTypeId = 3,
                    FieldId = 72,
                    ForeignTableName = "",
                    HistoryUser = "",
                    MaxValue = "2147483647",
                    MinValue = "1",
                    Name = "UserLastModificationId",
                    Nullable = true,
                    Regex = "^[0-9]+$"
                },
                new FiyiStackApp.Models.Core.Field()    //DateTimeCreation
                {
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    TableId = 8,
                    DataTypeId = 10,
                    FieldId = 73,
                    ForeignTableName = "",
                    HistoryUser = "",
                    MaxValue = "",
                    MinValue = "",
                    Name = "DateTimeCreation",
                    Nullable = true,
                    Regex = ""
                },
                new FiyiStackApp.Models.Core.Field()    //DateTimeLastModification
                {
                    Active = true,
                    DateTimeCreation = Now,
                    DateTimeLastModification = Now,
                    UserIdCreation = 1,
                    UserIdLastModification = 1,
                    TableId = 8,
                    DataTypeId = 10,
                    FieldId = 74,
                    ForeignTableName = "",
                    HistoryUser = "",
                    MaxValue = "",
                    MinValue = "",
                    Name = "DateTimeLastModification",
                    Nullable = true,
                    Regex = ""
                }
            };
            List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure> lstStoredProcedureToGenerate = new List<FiyiStack.Library.MicrosoftSQLServer.StoredProcedure>()
            {
                new FiyiStack.Library.MicrosoftSQLServer.StoredProcedure()   //Insert
                {
                    Action = "Insert",
                    Content = null,
                    SchemeName = "dbo",
                    TableName = "Sex"
                },
                new FiyiStack.Library.MicrosoftSQLServer.StoredProcedure()   //UpdateBySexId
                {
                    Action = "UpdateBySexId",
                    Content = null,
                    SchemeName = "dbo",
                    TableName = "Sex"
                },
                new FiyiStack.Library.MicrosoftSQLServer.StoredProcedure()   //DeleteBySexId
                {
                    Action = "DeleteBySexId",
                    Content = null,
                    SchemeName = "dbo",
                    TableName = "Sex"
                },
                new FiyiStack.Library.MicrosoftSQLServer.StoredProcedure()   //Select1BySexId
                {
                    Action = "Select1BySexId",
                    Content = null,
                    SchemeName = "dbo",
                    TableName = "Sex"
                },
                new FiyiStack.Library.MicrosoftSQLServer.StoredProcedure()   //SelectAll
                {
                    Action = "SelectAll",
                    Content = null,
                    SchemeName = "dbo",
                    TableName = "Sex"
                },
                new FiyiStack.Library.MicrosoftSQLServer.StoredProcedure()   //SelectAllPaged
                {
                    Action = "SelectAllPaged",
                    Content = null,
                    SchemeName = "dbo",
                    TableName = "Sex"
                },
            };
            #endregion

            #region Result
            string Result = GeneratorJsTsNETCoreSQLServer.Start(Configuration,
                fieldChainer,
                fieldChainerNodeJsExpressMongoDB,
                modelChainer,
                ProjectChosen,
                DataBaseChosen,
                lstTableInFiyiStack,
                lstTableToGenerate,
                lstFieldToGenerate,
                lstStoredProcedureToGenerate);
            #endregion

            Assert.AreNotEqual("BAD_GENERATION", Result);
        }
    }
}