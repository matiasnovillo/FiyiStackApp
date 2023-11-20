USE [fiyistack_FiyiStackApp]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.UpdateByUserProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.UpdateByUserProjectId]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetOneByUserProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.GetOneByUserProjectId]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetOneByUserIdByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.GetOneByUserIdByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetOneByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.GetOneByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUsersIdThatHasBeenInvited]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.GetAllByUsersIdThatHasBeenInvited]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUsersIdThatAcceptedInvitation]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.GetAllByUsersIdThatAcceptedInvitation]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUserIdByProjectNameByAccessTypeId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.GetAllByUserIdByProjectNameByAccessTypeId]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUserIdByAccessTypeId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.GetAllByUserIdByAccessTypeId]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.DeleteByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.DeleteByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[UserProject.Add]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[UserProject.Add]
GO

/****** Object:  StoredProcedure [dbo].[User.UpdateByUserId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[User.UpdateByUserId]
GO

/****** Object:  StoredProcedure [dbo].[User.GetOneByUserId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[User.GetOneByUserId]
GO

/****** Object:  StoredProcedure [dbo].[User.GetOneByFantasyNameByEmailByPassword]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[User.GetOneByFantasyNameByEmailByPassword]
GO

/****** Object:  StoredProcedure [dbo].[User.GetOneByFantasyNameByEmail]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[User.GetOneByFantasyNameByEmail]
GO

/****** Object:  StoredProcedure [dbo].[User.GetAll]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[User.GetAll]
GO

/****** Object:  StoredProcedure [dbo].[User.DeleteByUserId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[User.DeleteByUserId]
GO

/****** Object:  StoredProcedure [dbo].[User.Add]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[User.Add]
GO

/****** Object:  StoredProcedure [dbo].[Table.UpdateByTableId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Table.UpdateByTableId]
GO

/****** Object:  StoredProcedure [dbo].[Table.GetOneByTableId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Table.GetOneByTableId]
GO

/****** Object:  StoredProcedure [dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme]
GO

/****** Object:  StoredProcedure [dbo].[Table.GetAllByDataBaseId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Table.GetAllByDataBaseId]
GO

/****** Object:  StoredProcedure [dbo].[Table.DeleteByTableId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Table.DeleteByTableId]
GO

/****** Object:  StoredProcedure [dbo].[Table.DeleteByDataBaseId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Table.DeleteByDataBaseId]
GO

/****** Object:  StoredProcedure [dbo].[Table.Add]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Table.Add]
GO

/****** Object:  StoredProcedure [dbo].[Project.UpdateByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Project.UpdateByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[Project.GetOneByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Project.GetOneByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[Project.GetAllByUserId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Project.GetAllByUserId]
GO

/****** Object:  StoredProcedure [dbo].[Project.DeleteByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Project.DeleteByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[Project.Add]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Project.Add]
GO

/****** Object:  StoredProcedure [dbo].[Field.UpdateByFieldId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.UpdateByFieldId]
GO

/****** Object:  StoredProcedure [dbo].[Field.GetOneByTableIdByName]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.GetOneByTableIdByName]
GO

/****** Object:  StoredProcedure [dbo].[Field.GetOneByFieldId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.GetOneByFieldId]
GO

/****** Object:  StoredProcedure [dbo].[Field.GetAllByTableIdByForeignTableName]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.GetAllByTableIdByForeignTableName]
GO

/****** Object:  StoredProcedure [dbo].[Field.GetAllByTableId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.GetAllByTableId]
GO

/****** Object:  StoredProcedure [dbo].[Field.DeleteByTableId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.DeleteByTableId]
GO

/****** Object:  StoredProcedure [dbo].[Field.DeleteByFieldId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.DeleteByFieldId]
GO

/****** Object:  StoredProcedure [dbo].[Field.Add]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Field.Add]
GO

/****** Object:  StoredProcedure [dbo].[DataType.GetList]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[DataType.GetList]
GO

/****** Object:  StoredProcedure [dbo].[DataBase.UpdateByDataBaseId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[DataBase.UpdateByDataBaseId]
GO

/****** Object:  StoredProcedure [dbo].[DataBase.GetOneByProjectIdByName]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[DataBase.GetOneByProjectIdByName]
GO

/****** Object:  StoredProcedure [dbo].[DataBase.GetOneByDataBaseId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[DataBase.GetOneByDataBaseId]
GO

/****** Object:  StoredProcedure [dbo].[DataBase.GetAllByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[DataBase.GetAllByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[DataBase.DeleteByDataBaseId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[DataBase.DeleteByDataBaseId]
GO

/****** Object:  StoredProcedure [dbo].[DataBase.Add]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[DataBase.Add]
GO

/****** Object:  StoredProcedure [dbo].[Configuration.UpdateByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Configuration.UpdateByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[Configuration.UpdateByConfigurationId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Configuration.UpdateByConfigurationId]
GO

/****** Object:  StoredProcedure [dbo].[Configuration.GetOneByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Configuration.GetOneByProjectId]
GO

/****** Object:  StoredProcedure [dbo].[Configuration.DeleteByConfigurationId]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Configuration.DeleteByConfigurationId]
GO

/****** Object:  StoredProcedure [dbo].[Configuration.Add]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[Configuration.Add]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistTable]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistTable]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistField]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistField]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistDataBase]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistDataBase]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]
GO

/****** Object:  StoredProcedure [dbo].[ActionType.GetList]    Script Date: 05/12/2022 14:25:01 ******/
DROP PROCEDURE [dbo].[ActionType.GetList]
GO

/****** Object:  StoredProcedure [dbo].[ActionType.GetList]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[ActionType.GetList]
(
	@FirstTextItem varchar(200)
)


AS

SELECT 
	'0' AS [Value], 
	LTRIM(RTRIM(@FirstTextItem)) AS [Text]
UNION ALL

SELECT 
	CONVERT(VARCHAR(50),[ActionType].[ActionTypeId]) AS [Value], 
	LTRIM(RTRIM([ActionType].[Name])) AS [Text]
FROM 
	[ActionType]
WHERE 1 = 1
	AND [ActionType].[Active] = 1
ORDER BY 
	2
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]

AS

SELECT @@version

GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistDataBase]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistDataBase]
(
	@DataBaseName VARCHAR(MAX)
)

AS

IF DB_ID(@DataBaseName) IS NOT NULL
	SELECT 1
ELSE
	SELECT 0

GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistField]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistField]
(
	@TableName VARCHAR(MAX),
	@SchemeName VARCHAR(MAX),
	@FieldName VARCHAR(MAX)
)

AS

IF EXISTS (SELECT 1 FROM sys.columns 
          WHERE 1 = 1
			AND Name = @FieldName
			AND Object_ID = Object_ID('['+@SchemeName+'].['+@TableName+']'))
	SELECT 1 
ELSE 
	SELECT 0
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]
(
	@DataBaseName VARCHAR(MAX),
	@SchemeName VARCHAR(MAX),
	@TableArea VARCHAR(MAX),
	@TableName VARCHAR(MAX),
	@Action VARCHAR(MAX),
	@IsFiyiStackSP TINYINT
)

AS

/*

*/

IF EXISTS (SELECT 1 
			FROM INFORMATION_SCHEMA.ROUTINES
			WHERE 1 = 1
				AND ROUTINE_TYPE = 'PROCEDURE'
				AND ROUTINE_CATALOG = @DataBaseName
				AND ROUTINE_SCHEMA = @SchemeName
				AND ((ROUTINE_NAME = @TableArea + '.' + @TableName + '.' + @Action AND @IsFiyiStackSP = 1)
					OR 
					(ROUTINE_NAME = @Action AND @IsFiyiStackSP = 0))
			)  
	SELECT 1 
ELSE 
	SELECT 0
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistTable]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistTable]
(
	@TableName VARCHAR(MAX),
	@Scheme VARCHAR(MAX)
)

AS

IF EXISTS (SELECT 1 
           FROM INFORMATION_SCHEMA.TABLES 
           WHERE TABLE_TYPE = 'BASE TABLE' 
			   AND TABLE_NAME = @TableName
			   AND TABLE_SCHEMA = @Scheme) 
	SELECT 1 
ELSE 
	SELECT 0
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO














CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]
(
	@TableName VARCHAR(MAX),
	@SchemeName VARCHAR(MAX)
)

AS

SELECT 
	COLUMN_NAME AS [Name],
CASE
	WHEN DATA_TYPE = 'int' THEN DATA_TYPE 
	WHEN DATA_TYPE = 'varchar' THEN DATA_TYPE + '(' + (CASE WHEN CHARACTER_MAXIMUM_LENGTH = -1 THEN 'MAX' ELSE CONVERT(VARCHAR(MAX), CHARACTER_MAXIMUM_LENGTH) END) + ')'
	WHEN DATA_TYPE = 'numeric' THEN DATA_TYPE + '(' + CONVERT(VARCHAR(MAX), NUMERIC_PRECISION) + ',' + CONVERT(VARCHAR(MAX), NUMERIC_SCALE) + ')'
	WHEN DATA_TYPE = 'datetime' THEN DATA_TYPE
	WHEN DATA_TYPE = 'time' THEN DATA_TYPE + '(' + CONVERT(VARCHAR(MAX), DATETIME_PRECISION) + ')'
	ELSE DATA_TYPE
END AS [DataTypeName],
CASE WHEN IS_NULLABLE = 'YES' THEN 1 ELSE 0 END AS [Nullable]

FROM 
	INFORMATION_SCHEMA.COLUMNS
WHERE 1 = 1
	AND TABLE_NAME = @TableName
	AND TABLE_SCHEMA = @SchemeName

GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]
(
	@DataBaseName VARCHAR(MAX)
)

AS

SELECT 
TABLE_NAME AS [Name],
TABLE_SCHEMA AS [Scheme]
FROM 
	INFORMATION_SCHEMA.TABLES 
WHERE 1=1
	AND TABLE_TYPE = 'BASE TABLE' 
	AND TABLE_CATALOG = @DataBaseName

GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO














CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]
(
	@TableName VARCHAR(MAX),
	@SchemeName VARCHAR(MAX),
	@FieldName VARCHAR(MAX)
)

AS

SELECT 
	COLUMN_NAME AS [Name],
CASE
	WHEN DATA_TYPE = 'int' THEN DATA_TYPE 
	WHEN DATA_TYPE = 'varchar' THEN DATA_TYPE + '(' + (CASE WHEN CHARACTER_MAXIMUM_LENGTH = -1 THEN 'MAX' ELSE CONVERT(VARCHAR(MAX), CHARACTER_MAXIMUM_LENGTH) END) + ')'
	WHEN DATA_TYPE = 'numeric' THEN DATA_TYPE + '(' + CONVERT(VARCHAR(MAX), NUMERIC_PRECISION) + ',' + CONVERT(VARCHAR(MAX), NUMERIC_SCALE) + ')'
	WHEN DATA_TYPE = 'datetime' THEN DATA_TYPE
	WHEN DATA_TYPE = 'time' THEN DATA_TYPE + '(' + CONVERT(VARCHAR(MAX), DATETIME_PRECISION) + ')'
	ELSE DATA_TYPE
END AS [DataTypeName],
CASE WHEN IS_NULLABLE = 'YES' THEN 1 ELSE 0 END AS [Nullable]

FROM 
	INFORMATION_SCHEMA.COLUMNS
WHERE 1 = 1
	AND TABLE_NAME = @TableName
	AND TABLE_SCHEMA = @SchemeName
	AND COLUMN_NAME = @FieldName

GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]
(
	@DataBaseName VARCHAR(MAX),
	@SchemeName VARCHAR(MAX),
	@TableArea VARCHAR(MAX),
	@Name VARCHAR(MAX)
)

AS

SELECT
	ROUTINE_NAME AS [Name],
	ROUTINE_DEFINITION AS [Content]
FROM 
	INFORMATION_SCHEMA.ROUTINES
WHERE 1 = 1
	AND ROUTINE_TYPE = 'PROCEDURE'
	AND ROUTINE_CATALOG = @DataBaseName
	AND ROUTINE_SCHEMA = @SchemeName
	AND ROUTINE_NAME = @TableArea + '.' + @Name

GO

/****** Object:  StoredProcedure [dbo].[Configuration.Add]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Configuration.Add]
(
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserCreationId INT,
	@UserLastModificationId INT,
	@ProjectId INT,
	@AddAuditingFieldsToNewTable TINYINT,
	@DeleteTable TINYINT,
	@DeleteField TINYINT,
	@DeleteStoredProcedure TINYINT,
	@DeleteFiles TINYINT,
	@TemplateId INT,
	@IsMSSQLServer TINYINT,
	@ConnectionStringForMSSQLServer VARCHAR(500),
	@IsPostgreSQL TINYINT,
	@ConnectionStringForPostgreSQL VARCHAR(500),
	@IsPLSQL TINYINT,
	@ConnectionStringForPLSQL VARCHAR(500),
	@IsSQLite TINYINT,
	@ConnectionStringForSQLite VARCHAR(500),
	@IsMongoDB TINYINT,
	@ConnectionStringForMongoDB VARCHAR(500),
	@IsMySQL TINYINT,
	@ConnectionStringForMySQL VARCHAR(500),
	@WantCSharpModelsWithSPs TINYINT,
	@WantCSharpFilters TINYINT,
	@WantCSharpInterfaces TINYINT,
	@WantCSharpServices TINYINT,
	@WantCSharpWebForms TINYINT,
	@WantCSharpRazorPages TINYINT,
	@WantCSharpWebAPIs TINYINT,
	@WantTypeScriptModels TINYINT,
	@WantjQueryDOMManipulator TINYINT,
	@WantPythonModels TINYINT
)

AS

INSERT INTO [Configuration]
(
	[Active],
	[DateTimeCreation],
	[DateTimeLastModification],
	[UserCreationId],
	[UserLastModificationId],
	[ProjectId],
	[AddAuditingFieldsToNewTable],
	[DeleteTable],
	[DeleteField],
	[DeleteStoredProcedure],
	[DeleteFiles],
	[TemplateId],
	[IsMSSQLServer],
	[ConnectionStringForMSSQLServer],
	[IsPostgreSQL],
	[ConnectionStringForPostgreSQL],
	[IsPLSQL],
	[ConnectionStringForPLSQL],
	[IsSQLite],
	[ConnectionStringForSQLite],
	[IsMongoDB],
	[ConnectionStringForMongoDB],
	[IsMySQL],
	[ConnectionStringForMySQL],
	[WantCSharpModelsWithSPs],
	[WantCSharpFilters],
	[WantCSharpInterfaces],
	[WantCSharpServices],
	[WantCSharpWebForms],
	[WantCSharpRazorPages],
	[WantCSharpWebAPIs],
	[WantTypeScriptModels],
	[WantjQueryDOMManipulator],
	[WantPythonModels]
)
VALUES
(
	@Active,
	@DateTimeCreation,
	@DateTimeLastModification,
	@UserCreationId,
	@UserLastModificationId,
	@ProjectId,
	@AddAuditingFieldsToNewTable,
	@DeleteTable,
	@DeleteField,
	@DeleteStoredProcedure,
	@DeleteFiles,
	@TemplateId,
	@IsMSSQLServer,
	@ConnectionStringForMSSQLServer,
	@IsPostgreSQL,
	@ConnectionStringForPostgreSQL,
	@IsPLSQL,
	@ConnectionStringForPLSQL,
	@IsSQLite,
	@ConnectionStringForSQLite,
	@IsMongoDB,
	@ConnectionStringForMongoDB,
	@IsMySQL,
	@ConnectionStringForMySQL,
	@WantCSharpModelsWithSPs,
	@WantCSharpFilters,
	@WantCSharpInterfaces,
	@WantCSharpServices,
	@WantCSharpWebForms,
	@WantCSharpRazorPages,
	@WantCSharpWebAPIs,
	@WantTypeScriptModels,
	@WantjQueryDOMManipulator,
	@WantPythonModels
)

SELECT @@identity AS 'MaxId'
GO

/****** Object:  StoredProcedure [dbo].[Configuration.DeleteByConfigurationId]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[Configuration.DeleteByConfigurationId]
(
	@ConfigurationId int
)

AS

DELETE FROM [Configuration]
WHERE 1 = 1
	AND [Configuration].[ConfigurationId] = @ConfigurationId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Configuration.GetOneByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Configuration.GetOneByProjectId]
(
	@ProjectId INT
)

AS

SELECT
	[Configuration].[ConfigurationId],
	[Configuration].[Active],
	[Configuration].[DateTimeCreation],
	[Configuration].[DateTimeLastModification],
	[Configuration].[UserCreationId],
	[Configuration].[UserLastModificationId],
	[Configuration].[ProjectId],
	[Configuration].[AddAuditingFieldsToNewTable],
	[Configuration].[DeleteTable],
	[Configuration].[DeleteField],
	[Configuration].[DeleteStoredProcedure],
	[Configuration].[DeleteFiles],
	[Configuration].[TemplateId],
	[Configuration].[IsMSSQLServer],
	[Configuration].[ConnectionStringForMSSQLServer],
	[Configuration].[IsPostgreSQL],
	[Configuration].[ConnectionStringForPostgreSQL],
	[Configuration].[IsPLSQL],
	[Configuration].[ConnectionStringForPLSQL],
	[Configuration].[IsSQLite],
	[Configuration].[ConnectionStringForSQLite],
	[Configuration].[IsMongoDB],
	[Configuration].[ConnectionStringForMongoDB],
	[Configuration].[IsMySQL],
	[Configuration].[ConnectionStringForMySQL],
	[Configuration].[WantCSharpModelsWithSPs],
	[Configuration].[WantCSharpFilters],
	[Configuration].[WantCSharpInterfaces],
	[Configuration].[WantCSharpServices],
	[Configuration].[WantCSharpWebForms],
	[Configuration].[WantCSharpRazorPages],
	[Configuration].[WantCSharpWebAPIs],
	[Configuration].[WantTypeScriptModels],
	[Configuration].[WantjQueryDOMManipulator],
	[Configuration].[WantPythonModels]
FROM 
	[Configuration]
WHERE 1 = 1 
	AND [Configuration].[ProjectId] = @ProjectId
GO

/****** Object:  StoredProcedure [dbo].[Configuration.UpdateByConfigurationId]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Configuration.UpdateByConfigurationId]
(
	@ConfigurationId INT,
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserCreationId INT,
	@UserLastModificationId INT,
	@ProjectId INT,
	@AddAuditingFieldsToNewTable TINYINT,
	@DeleteTable TINYINT,
	@DeleteField TINYINT,
	@DeleteStoredProcedure TINYINT,
	@DeleteFiles TINYINT,
	@TemplateId INT,
	@IsMSSQLServer TINYINT,
	@ConnectionStringForMSSQLServer VARCHAR(500),
	@IsPostgreSQL TINYINT,
	@ConnectionStringForPostgreSQL VARCHAR(500),
	@IsPLSQL TINYINT,
	@ConnectionStringForPLSQL VARCHAR(500),
	@IsSQLite TINYINT,
	@ConnectionStringForSQLite VARCHAR(500),
	@IsMongoDB TINYINT,
	@ConnectionStringForMongoDB VARCHAR(500),
	@IsMySQL TINYINT,
	@ConnectionStringForMySQL VARCHAR(500),
	@WantCSharpModelsWithSPs TINYINT,
	@WantCSharpFilters TINYINT,
	@WantCSharpInterfaces TINYINT,
	@WantCSharpServices TINYINT,
	@WantCSharpWebForms TINYINT,
	@WantCSharpRazorPages TINYINT,
	@WantCSharpWebAPIs TINYINT,
	@WantTypeScriptModels TINYINT,
	@WantjQueryDOMManipulator TINYINT,
	@WantPythonModels TINYINT
)

AS

UPDATE [Configuration] SET
	[Active] = @Active,
	[DateTimeCreation] = @DateTimeCreation,
	[DateTimeLastModification] = @DateTimeLastModification,
	[UserCreationId] = @UserCreationId,
	[UserLastModificationId] = @UserLastModificationId,
	[ProjectId] = @ProjectId,
	[AddAuditingFieldsToNewTable] = @AddAuditingFieldsToNewTable,
	[DeleteTable] = @DeleteTable,
	[DeleteField] = @DeleteField,
	[DeleteStoredProcedure] = @DeleteStoredProcedure,
	[DeleteFiles] = @DeleteFiles,
	[TemplateId] = @TemplateId,
	[IsMSSQLServer] = @IsMSSQLServer,
	[ConnectionStringForMSSQLServer] = @ConnectionStringForMSSQLServer,
	[IsPostgreSQL] = @IsPostgreSQL,
	[ConnectionStringForPostgreSQL] = @ConnectionStringForPostgreSQL,
	[IsPLSQL] = @IsPLSQL,
	[ConnectionStringForPLSQL] = @ConnectionStringForPLSQL,
	[IsSQLite] = @IsSQLite,
	[ConnectionStringForSQLite] = @ConnectionStringForSQLite,
	[IsMongoDB] = @IsMongoDB,
	[ConnectionStringForMongoDB] = @ConnectionStringForMongoDB,
	[IsMySQL] = @IsMySQL,
	[ConnectionStringForMySQL] = @ConnectionStringForMySQL,
	[WantCSharpModelsWithSPs] = @WantCSharpModelsWithSPs,
	[WantCSharpFilters] = @WantCSharpFilters,
	[WantCSharpInterfaces] = @WantCSharpInterfaces,
	[WantCSharpServices] = @WantCSharpServices,
	[WantCSharpWebForms] = @WantCSharpWebForms,
	[WantCSharpRazorPages] = @WantCSharpRazorPages,
	[WantCSharpWebAPIs] = @WantCSharpWebAPIs,
	[WantTypeScriptModels] = @WantTypeScriptModels,
	[WantjQueryDOMManipulator] = @WantjQueryDOMManipulator,
	[WantPythonModels] = @WantPythonModels
WHERE 1 = 1
	AND [ConfigurationId] = @ConfigurationId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Configuration.UpdateByProjectId]    Script Date: 05/12/2022 14:25:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Configuration.UpdateByProjectId]
(
	@ConfigurationId INT,
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserCreationId INT,
	@UserLastModificationId INT,
	@ProjectId INT,
	@AddAuditingFieldsToNewTable TINYINT,
	@DeleteTable TINYINT,
	@DeleteField TINYINT,
	@DeleteStoredProcedure TINYINT,
	@DeleteFiles TINYINT,
	@TemplateId INT,
	@IsMSSQLServer TINYINT,
	@ConnectionStringForMSSQLServer VARCHAR(500),
	@IsPostgreSQL TINYINT,
	@ConnectionStringForPostgreSQL VARCHAR(500),
	@IsPLSQL TINYINT,
	@ConnectionStringForPLSQL VARCHAR(500),
	@IsSQLite TINYINT,
	@ConnectionStringForSQLite VARCHAR(500),
	@IsMongoDB TINYINT,
	@ConnectionStringForMongoDB VARCHAR(500),
	@IsMySQL TINYINT,
	@ConnectionStringForMySQL VARCHAR(500),
	@WantCSharpModelsWithSPs TINYINT,
	@WantCSharpFilters TINYINT,
	@WantCSharpInterfaces TINYINT,
	@WantCSharpServices TINYINT,
	@WantCSharpWebForms TINYINT,
	@WantCSharpRazorPages TINYINT,
	@WantCSharpWebAPIs TINYINT,
	@WantTypeScriptModels TINYINT,
	@WantjQueryDOMManipulator TINYINT,
	@WantPythonModels TINYINT
)

AS

UPDATE [Configuration] SET
	[Active] = @Active,
	[DateTimeCreation] = @DateTimeCreation,
	[DateTimeLastModification] = @DateTimeLastModification,
	[UserCreationId] = @UserCreationId,
	[UserLastModificationId] = @UserLastModificationId,
	[ProjectId] = @ProjectId,
	[AddAuditingFieldsToNewTable] = @AddAuditingFieldsToNewTable,
	[DeleteTable] = @DeleteTable,
	[DeleteField] = @DeleteField,
	[DeleteStoredProcedure] = @DeleteStoredProcedure,
	[DeleteFiles] = @DeleteFiles,
	[TemplateId] = @TemplateId,
	[IsMSSQLServer] = @IsMSSQLServer,
	[ConnectionStringForMSSQLServer] = @ConnectionStringForMSSQLServer,
	[IsPostgreSQL] = @IsPostgreSQL,
	[ConnectionStringForPostgreSQL] = @ConnectionStringForPostgreSQL,
	[IsPLSQL] = @IsPLSQL,
	[ConnectionStringForPLSQL] = @ConnectionStringForPLSQL,
	[IsSQLite] = @IsSQLite,
	[ConnectionStringForSQLite] = @ConnectionStringForSQLite,
	[IsMongoDB] = @IsMongoDB,
	[ConnectionStringForMongoDB] = @ConnectionStringForMongoDB,
	[IsMySQL] = @IsMySQL,
	[ConnectionStringForMySQL] = @ConnectionStringForMySQL,
	[WantCSharpModelsWithSPs] = @WantCSharpModelsWithSPs,
	[WantCSharpFilters] = @WantCSharpFilters,
	[WantCSharpInterfaces] = @WantCSharpInterfaces,
	[WantCSharpServices] = @WantCSharpServices,
	[WantCSharpWebForms] = @WantCSharpWebForms,
	[WantCSharpRazorPages] = @WantCSharpRazorPages,
	[WantCSharpWebAPIs] = @WantCSharpWebAPIs,
	[WantTypeScriptModels] = @WantTypeScriptModels,
	[WantjQueryDOMManipulator] = @WantjQueryDOMManipulator,
	[WantPythonModels] = @WantPythonModels
WHERE 1 = 1
AND [ProjectId] = @ProjectId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[DataBase.Add]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[DataBase.Add]
(
	@ProjectId INT,
	@Name VARCHAR(100),
	@Active TINYINT,
	@UserIdCreation INT,
	@UserIdLastModification INT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME
)

AS

INSERT INTO [DataBase]
(
	[ProjectId],
	[Name],
	[Active],
	[UserIdCreation],
	[UserIdLastModification],
	[DateTimeCreation],
	[DateTimeLastModification]
)
VALUES
(
	@ProjectId,
	@Name,
	@Active,
	@UserIdCreation,
	@UserIdLastModification,
	@DateTimeCreation,
	@DateTimeLastModification
)

SELECT @@identity AS 'MaxId'
GO

/****** Object:  StoredProcedure [dbo].[DataBase.DeleteByDataBaseId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[DataBase.DeleteByDataBaseId]
(
	@DataBaseId INT
)

AS

DELETE FROM [DataBase]
WHERE 1 = 1
	AND [DataBase].[DataBaseId] = @DataBaseId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[DataBase.GetAllByProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[DataBase.GetAllByProjectId]
(
	@ProjectId int
)

AS

SELECT
	[DataBase].[DataBaseId],
	[DataBase].[ProjectId],
	[DataBase].[Name],
	[DataBase].[Active],
	[DataBase].[DateTimeCreation],
	[DataBase].[DateTimeLastModification],
	[DataBase].[UserIdCreation],
	[DataBase].[UserIdLastModification]
FROM 
	[DataBase]
WHERE 1 = 1 
	AND [DataBase].[ProjectId] = @ProjectId
GO

/****** Object:  StoredProcedure [dbo].[DataBase.GetOneByDataBaseId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[DataBase.GetOneByDataBaseId]
(
	@DataBaseId int
)

AS

SELECT
	[DataBase].[DataBaseId],
	[DataBase].[ProjectId],
	[DataBase].[Name],
	[DataBase].[Active],
	[DataBase].[UserIdCreation],
	[DataBase].[UserIdLastModification],
	[DataBase].[DateTimeCreation],
	[DataBase].[DateTimeLastModification]
FROM 
	[DataBase]
WHERE 1 = 1 
	AND [DataBase].[DataBaseId] = @DataBaseId
GO

/****** Object:  StoredProcedure [dbo].[DataBase.GetOneByProjectIdByName]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[DataBase.GetOneByProjectIdByName]
(
	@ProjectId INT,
	@Name VARCHAR(100)
)

AS

SELECT
	[DataBase].[DataBaseId],
	[DataBase].[ProjectId],
	[DataBase].[Name],
	[DataBase].[Active],
	[DataBase].[UserIdCreation],
	[DataBase].[UserIdLastModification],
	[DataBase].[DateTimeCreation],
	[DataBase].[DateTimeLastModification]
FROM 
	[DataBase]
WHERE 1 = 1 
	AND [DataBase].[ProjectId] = @ProjectId
	AND [DataBase].[Name] = @Name
GO

/****** Object:  StoredProcedure [dbo].[DataBase.UpdateByDataBaseId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[DataBase.UpdateByDataBaseId]
(
	@DataBaseId INT,
	@ProjectId INT,
	@Name VARCHAR(100),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT
)

AS

UPDATE [DataBase] SET
	[ProjectId] = @ProjectId,
	[Name] = @Name,
	[Active] = @Active,
	[UserIdCreation] = @UserIdCreation,
	[UserIdLastModification] = @UserIdLastModification,
	[DateTimeCreation] = @DateTimeCreation,
	[DateTimeLastModification] = @DateTimeLastModification
WHERE 1 = 1
	AND [DataBaseId] = @DataBaseId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[DataType.GetList]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[DataType.GetList]
(
	@FirstTextItem VARCHAR(500)
)
as

SELECT 
	'0' AS [Value], 
	LTRIM(RTRIM(@FirstTextItem)) AS [Text]

UNION ALL

SELECT 
	CONVERT(VARCHAR(50),[DataTypeId]) AS [Value],
	LTRIM(RTRIM([DataType].[Name])) AS [Text]
FROM 
	[DataType]
WHERE 1 = 1
	AND [DataType].[Active] = 1
ORDER BY
	2
GO

/****** Object:  StoredProcedure [dbo].[Field.Add]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[Field.Add]
(
	@TableId INT,
	@DataTypeId INT,
	@Name VARCHAR(100),
	@Nullable TINYINT,
	@HistoryUser VARCHAR(MAX),
	@Regex VARCHAR(MAX),
	@MinValue VARCHAR(MAX),
	@MaxValue VARCHAR(MAX),
	@ForeignTableName VARCHAR(MAX),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT
)

AS

INSERT INTO [Field]
(
	[TableId],
	[DataTypeId],
	[Name],
	[Nullable],
	[HistoryUser],
	[Regex],
	[MinValue],
	[MaxValue],
	[ForeignTableName],
	[Active],
	[DateTimeCreation],
	[DateTimeLastModification],
	[UserIdCreation],
	[UserIdLastModification]
)
VALUES
(
	@TableId,
	@DataTypeId,
	@Name,
	@Nullable,
	@HistoryUser,
	@Regex,
	@MinValue,
	@MaxValue,
	@ForeignTableName,
	@Active,
	@DateTimeCreation,
	@DateTimeLastModification,
	@UserIdCreation,
	@UserIdLastModification
)

SELECT @@identity AS 'MaxId'
GO

/****** Object:  StoredProcedure [dbo].[Field.DeleteByFieldId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO














CREATE PROCEDURE [dbo].[Field.DeleteByFieldId]
(
	@FieldId INT
) 

AS

DELETE FROM [Field] 
WHERE 1=1 
	AND [Field].[FieldId] =  @FieldId

SELECT @@ROWCOUNT As 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Field.DeleteByTableId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[Field.DeleteByTableId]
(
	@TableId INT
) 

AS

DELETE FROM [Field] 
WHERE 1=1 
	AND [Field].[TableId] =  @TableId

SELECT @@ROWCOUNT As 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Field.GetAllByTableId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[Field.GetAllByTableId]
(
	@TableId int
)

AS

SELECT
	[Field].[FieldId],
	[Field].[TableId],
	[Field].[DataTypeId],
	[Field].[Name],
	[Field].[Nullable],
	[Field].[HistoryUser],
	[Field].[Regex],
	[Field].[MinValue],
	[Field].[MaxValue],
	[Field].[ForeignTableName],
	[Field].[DateTimeLastModification]
FROM 
	[Field]
	LEFT OUTER JOIN [User] AS User_UserIdCreation ON [Field].[UserIdCreation] = User_UserIdCreation.[UserId]
	LEFT OUTER JOIN [User] AS User_UserIdLastModification ON [Field].[UserIdLastModification] = User_UserIdLastModification.[UserId]
WHERE 1 = 1 
	AND [Field].[TableId] = @TableId
GO

/****** Object:  StoredProcedure [dbo].[Field.GetAllByTableIdByForeignTableName]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[Field.GetAllByTableIdByForeignTableName]
(
	@TableId INT,
	@ForeignTableName VARCHAR(MAX)
)

AS

SELECT
	[Field].[FieldId],
	[Field].[TableId],
	[Field].[DataTypeId],
	[Field].[Name],
	[Field].[Nullable],
	[Field].[HistoryUser],
	[Field].[Regex],
	[Field].[MinValue],
	[Field].[MaxValue],
	[Field].[ForeignTableName],
	[Field].[DateTimeLastModification]
FROM 
	[Field]
	LEFT OUTER JOIN [User] AS User_UserIdCreation ON [Field].[UserIdCreation] = User_UserIdCreation.[UserId]
	LEFT OUTER JOIN [User] AS User_UserIdLastModification ON [Field].[UserIdLastModification] = User_UserIdLastModification.[UserId]
WHERE 1 = 1 
	AND [Field].[TableId] = @TableId
	AND [Field].[ForeignTableName] = @ForeignTableName
GO

/****** Object:  StoredProcedure [dbo].[Field.GetOneByFieldId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[Field.GetOneByFieldId]
(
	@FieldId int
)

AS

SELECT
	[Field].[FieldId],
	[Field].[TableId],
	[Field].[DataTypeId],
	ISNULL([Field].[Name], ' ') AS [Name],
	[Field].[Nullable],
	[Field].[HistoryUser],
	[Field].[Regex],
	[Field].[MinValue],
	[Field].[MaxValue],
	[Field].[ForeignTableName],
	[Field].[Active],
	[Field].[UserIdCreation],
	[Field].[UserIdLastModification],
	[Field].[DateTimeCreation],
	[Field].[DateTimeLastModification]
FROM [Field]
	LEFT OUTER JOIN [User] AS User_UserIdCreation ON [Field].[UserIdCreation] = User_UserIdCreation.[UserId]
	LEFT OUTER JOIN [User] AS User_UserIdLastModification ON [Field].[UserIdLastModification] = User_UserIdLastModification.[UserId]
WHERE 1 = 1 
	AND [Field].[FieldId] = @FieldId
GO

/****** Object:  StoredProcedure [dbo].[Field.GetOneByTableIdByName]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[Field.GetOneByTableIdByName]
(
	@TableId INT,
	@Name VARCHAR(100)
)

AS

SELECT
	[Field].[FieldId],
	[Field].[TableId],
	[Field].[DataTypeId],
	ISNULL([Field].[Name], ' ') AS [Name],
	[Field].[Nullable],
	[Field].[HistoryUser],
	[Field].[Regex],
	[Field].[MinValue],
	[Field].[MaxValue],
	[Field].[ForeignTableName],
	[Field].[Active],
	[Field].[UserIdCreation],
	[Field].[UserIdLastModification],
	[Field].[DateTimeCreation],
	[Field].[DateTimeLastModification]
FROM [Field]
	LEFT OUTER JOIN [User] AS User_UserIdCreation ON [Field].[UserIdCreation] = User_UserIdCreation.[UserId]
	LEFT OUTER JOIN [User] AS User_UserIdLastModification ON [Field].[UserIdLastModification] = User_UserIdLastModification.[UserId]
WHERE 1 = 1 
	AND [Field].[TableId] = @TableId
	AND [Field].[Name] = @Name
GO

/****** Object:  StoredProcedure [dbo].[Field.UpdateByFieldId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[Field.UpdateByFieldId]
(
	@FieldId INT,
	@TableId INT,
	@DataTypeId INT,
	@Name VARCHAR(100),
	@Nullable TINYINT,
	@HistoryUser VARCHAR(MAX),
	@Regex VARCHAR(MAX),
	@MinValue VARCHAR(MAX),
	@MaxValue VARCHAR(MAX),
	@ForeignTableName VARCHAR(MAX),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT
)

AS

UPDATE [Field] SET
	[TableId] = @TableId,
	[DataTypeId] = @DataTypeId,
	[Name] = @Name,
	[Nullable] = @Nullable,
	[HistoryUser] = @HistoryUser,
	[Regex] = @Regex,
	[MinValue] = @MinValue,
	[MaxValue] = @MaxValue,
	[ForeignTableName] = @ForeignTableName,
	[Active] = @Active,
	[DateTimeCreation] = @DateTimeCreation,
	[DateTimeLastModification] = @DateTimeLastModification,
	[UserIdCreation] = @UserIdCreation,
	[UserIdLastModification] = @UserIdLastModification
WHERE 1 = 1
	AND [FieldId] = @FieldId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Project.Add]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[Project.Add]
(
	@Name VARCHAR(100),
	@GeneralHistoryUser VARCHAR(MAX),
	@Path VARCHAR(MAX),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT
)

AS

INSERT INTO [Project]
(
	[Name],
	[GeneralHistoryUser],
	[Path],
	[Active],
	[DateTimeCreation],
	[DateTimeLastModification],
	[UserIdCreation],
	[UserIdLastModification]
)
VALUES
(
	@Name,
	@GeneralHistoryUser,
	@Path,
	@Active,
	@DateTimeCreation,
	@DateTimeLastModification,
	@UserIdCreation,
	@UserIdLastModification
)

SELECT @@identity AS 'MaxId'
GO

/****** Object:  StoredProcedure [dbo].[Project.DeleteByProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[Project.DeleteByProjectId]
(
	@ProjectId INT
) 

AS

DELETE FROM [Project] 
WHERE 1=1 
	AND [Project].[ProjectId] =  @ProjectId

SELECT @@ROWCOUNT As 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Project.GetAllByUserId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[Project.GetAllByUserId]
(
	@UserId INT
)

AS

SELECT
	[Project].[ProjectId],
	[Project].[Name],
	[Project].[GeneralHistoryUser],
	[Project].[Path],
	[Project].[Active],
	[Project].[DateTimeCreation],
	[Project].[DateTimeLastModification],
	[Project].[UserIdCreation],
	[Project].[UserIdLastModification]
FROM
	[Project],[UserProject]
WHERE 1 = 1 
	AND [Project].[ProjectId] = [UserProject].[ProjectId]
	AND [UserProject].[UserId] = @UserId
GO

/****** Object:  StoredProcedure [dbo].[Project.GetOneByProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[Project.GetOneByProjectId]
(
	@ProjectId INT
)

AS

SELECT
	[Project].[ProjectId],
	ISNULL([Project].[Name], ' ') AS [Name],
	ISNULL([Project].[GeneralHistoryUser], ' ') AS [GeneralHistoryUser],
	ISNULL([Project].[Path], ' ') AS [Path],
	[Project].[Active],
	[Project].[UserIdCreation],
	[Project].[UserIdLastModification],
	[Project].[DateTimeCreation],
	[Project].[DateTimeLastModification]
FROM 
	[Project]
	LEFT OUTER JOIN [User] AS User_UserIdCreation ON [Project].[UserIdCreation] = User_UserIdCreation.[UserId]
	LEFT OUTER JOIN [User] AS User_UserIdLastModification ON [Project].[UserIdLastModification] = User_UserIdLastModification.[UserId]
WHERE 1 = 1 
	AND [Project].[ProjectId] = @ProjectId
GO

/****** Object:  StoredProcedure [dbo].[Project.UpdateByProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[Project.UpdateByProjectId]
(
	@ProjectId INT,
	@Name VARCHAR(100),
	@GeneralHistoryUser VARCHAR(MAX),
	@Path VARCHAR(MAX),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT
)

AS

UPDATE [Project] SET
	[Name] = @Name,
	[GeneralHistoryUser] = @GeneralHistoryUser,
	[Path] = @Path,
	[Active] = @Active,
	[DateTimeCreation] = @DateTimeCreation,
	[DateTimeLastModification] = @DateTimeLastModification,
	[UserIdCreation] = @UserIdCreation,
	[UserIdLastModification] = @UserIdLastModification
WHERE 1 = 1
	AND [Project].[ProjectId] = @ProjectId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Table.Add]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[Table.Add]
(
	@DataBaseId INT,
	@Name VARCHAR(100),
	@Scheme VARCHAR(100),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT,
	@Area VARCHAR(100),
	@Version VARCHAR(100),
	@IsVirtual TINYINT
)

AS

INSERT INTO [Table]
(
	[DataBaseId],
	[Name],
	[Scheme],
	[Active],
	[DateTimeCreation],
	[DateTimeLastModification],
	[UserIdCreation],
	[UserIdLastModification],
	[Area],
	[Version],
	[IsVirtual]
)
VALUES
(
	@DataBaseId,
	@Name,
	@Scheme,
	@Active,
	@DateTimeCreation,
	@DateTimeLastModification,
	@UserIdCreation,
	@UserIdLastModification,
	@Area,
	@Version,
	@IsVirtual
)

SELECT @@identity AS 'MaxId'
GO

/****** Object:  StoredProcedure [dbo].[Table.DeleteByDataBaseId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO














CREATE PROCEDURE [dbo].[Table.DeleteByDataBaseId]
(
	@DataBaseId INT
) 

AS

DELETE FROM [Table] 
WHERE 1=1 
	AND [Table].[DataBaseId] =  @DataBaseId

SELECT @@ROWCOUNT As 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Table.DeleteByTableId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[Table.DeleteByTableId]
(
	@TableId INT
) 

AS

DELETE FROM [Table] 
WHERE 1=1 
	AND [Table].[TableId] =  @TableId

SELECT @@ROWCOUNT As 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[Table.GetAllByDataBaseId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[Table.GetAllByDataBaseId]
(
	@DataBaseId INT
)

AS

SELECT
	[Table].[TableId],
	[Table].[DataBaseId],
	[Table].[Name],
	[Table].[Scheme],
	[Table].[Active],
	[Table].[DateTimeLastModification],
	[Table].[Area],
	[Table].[Version],
	[Table].[IsVirtual]
FROM
	[Table]
WHERE 1 = 1 
	AND [Table].[DataBaseId] = @DataBaseId
GO

/****** Object:  StoredProcedure [dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO














CREATE PROCEDURE [dbo].[Table.GetOneByDataBaseIdByAreaByNameByScheme]
(
	@DataBaseId INT,
	@Area VARCHAR(100),
	@Name VARCHAR(100),
	@Scheme VARCHAR(100)
)

AS

SELECT
	[Table].[TableId],
	[Table].[DataBaseId],
	[Table].[Name],
	[Table].[Scheme],
	[Table].[Active],
	[Table].[UserIdCreation],
	[Table].[UserIdLastModification],
	[Table].[DateTimeCreation],
	[Table].[DateTimeLastModification],
	[Table].[Area],
	[Table].[Version],
	[Table].[IsVirtual]
FROM 
	[Table]
WHERE 1 = 1 
	AND [Table].[DataBaseId] = @DataBaseId
	AND [Table].[Area] = @Area
	AND [Table].[Name] = @Name
	AND [Table].[Scheme] = @Scheme
GO

/****** Object:  StoredProcedure [dbo].[Table.GetOneByTableId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO












CREATE PROCEDURE [dbo].[Table.GetOneByTableId]
(
	@TableId INT
)

AS

SELECT
	[Table].[TableId],
	[Table].[DataBaseId],
	[Table].[Name],
	[Table].[Scheme],
	[Table].[Active],
	[Table].[UserIdCreation],
	[Table].[UserIdLastModification],
	[Table].[DateTimeCreation],
	[Table].[DateTimeLastModification],
	[Table].[Area],
	[Table].[Version],
	[Table].[IsVirtual]
FROM 
	[Table]
WHERE 1 = 1 
	AND [Table].[TableId] = @TableId
GO

/****** Object:  StoredProcedure [dbo].[Table.UpdateByTableId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[Table.UpdateByTableId]
(
	@TableId INT,
	@DataBaseId INT,
	@Name VARCHAR(100),
	@Scheme VARCHAR(100),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT,
	@Area VARCHAR(100),
	@Version VARCHAR(100),
	@IsVirtual TINYINT
)

AS

UPDATE [Table] SET
	[DataBaseId] = @DataBaseId,
	[Name] = @Name,
	[Scheme] = @Scheme,
	[Active] = @Active,
	[DateTimeCreation] = @DateTimeCreation,
	[DateTimeLastModification] = @DateTimeLastModification,
	[UserIdCreation] = @UserIdCreation,
	[UserIdLastModification] = @UserIdLastModification,
	[Area] = @Area,
	[Version] = @Version,
	[IsVirtual] = @IsVirtual
WHERE 1 = 1
	AND [Table].[TableId] = @TableId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[User.Add]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
















CREATE PROCEDURE [dbo].[User.Add]
(
	@Name VARCHAR(100),
	@FantasyName VARCHAR(100),
	@Email VARCHAR(100),
	@Password VARCHAR(100),
	@ProfilePicturePath VARCHAR(MAX),
	@RoleId INT,
	@PublicProjectsIdJoined VARCHAR(MAX),
	@TokenGivenFromFiyiStack VARCHAR(MAX),
	@IAcceptTermsAndConditions TINYINT
) 

AS

INSERT INTO [User] 
(
	[Name],
	[FantasyName],
	[Email],
	[Password],
	[ProfilePicturePath],
	[RoleId],
	[PublicProjectsIdJoined],
	[TokenGivenFromFiyiStack],
	[IAcceptTermsAndConditions]
) 
VALUES
(
	@Name,
	@FantasyName,
	@Email,
	@Password,
	@ProfilePicturePath,
	@RoleId,
	@PublicProjectsIdJoined,
	@TokenGivenFromFiyiStack,
	@IAcceptTermsAndConditions
)

SELECT @@identity AS 'MaxId'
GO

/****** Object:  StoredProcedure [dbo].[User.DeleteByUserId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO















CREATE PROCEDURE [dbo].[User.DeleteByUserId]
(
	@UserId INT
) 

AS

DELETE FROM [User] 
WHERE 1=1 
	AND [User].[UserId] =  @UserId

SELECT @@ROWCOUNT As 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[User.GetAll]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


















CREATE PROCEDURE [dbo].[User.GetAll]

AS

SET DATEFORMAT DMY

SELECT
	[User].[UserId] AS [UserId],
	ISNULL([User].[Name],' ') AS [Name],
	ISNULL([User].[FantasyName],' ') AS [FantasyName],
	ISNULL([User].[Email],' ') AS [Email],
	ISNULL([User].[Password],' ') AS [Password],
	ISNULL([User].[ProfilePicturePath],' ') AS [ProfilePicturePath],
	[User].[RoleId] AS [RoleId],
	[User].[PublicProjectsIdJoined] AS [PublicProjectsIdJoined],
	[User].[TokenGivenFromFiyiStack] AS [TokenGivenFromFiyiStack],
	[User].[IAcceptTermsAndConditions] AS [IAcceptTermsAndConditions]
FROM 
	[User]
ORDER BY 
	[User].[FantasyName]
GO

/****** Object:  StoredProcedure [dbo].[User.GetOneByFantasyNameByEmail]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




















CREATE PROCEDURE [dbo].[User.GetOneByFantasyNameByEmail]
(
	@FantasyName VARCHAR(100),
	@Email VARCHAR(100)
)

AS

SET DATEFORMAT DMY

SELECT
	[User].[UserId] AS [UserId],
	ISNULL([User].[Name],' ') AS [Name],
	ISNULL([User].[FantasyName],' ') AS [FantasyName],
	ISNULL([User].[Email],' ') AS [Email],
	ISNULL([User].[Password],' ') AS [Password],
	ISNULL([User].[ProfilePicturePath],' ') AS [ProfilePicturePath],
	[User].[RoleId] AS [RoleId],
	[User].[PublicProjectsIdJoined] AS [PublicProjectsIdJoined],
	[User].[TokenGivenFromFiyiStack] AS [TokenGivenFromFiyiStack],
	[User].[IAcceptTermsAndConditions] AS [IAcceptTermsAndConditions]
FROM [User]
WHERE 1 = 1
	AND ([User].[FantasyName] = @FantasyName OR [User].[Email] = @Email)
GO

/****** Object:  StoredProcedure [dbo].[User.GetOneByFantasyNameByEmailByPassword]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



















CREATE PROCEDURE [dbo].[User.GetOneByFantasyNameByEmailByPassword]
(
	@FantasyName VARCHAR(100),
	@Email VARCHAR(100),
	@Password VARCHAR(100)
)

AS

SET DATEFORMAT DMY

SELECT
	[User].[UserId] AS [UserId],
	ISNULL([User].[Name],' ') AS [Name],
	ISNULL([User].[FantasyName],' ') AS [FantasyName],
	ISNULL([User].[Email],' ') AS [Email],
	ISNULL([User].[Password],' ') AS [Password],
	ISNULL([User].[ProfilePicturePath],' ') AS [ProfilePicturePath],
	[User].[RoleId] AS [RoleId],
	[User].[PublicProjectsIdJoined] AS [PublicProjectsIdJoined],
	[User].[TokenGivenFromFiyiStack] AS [TokenGivenFromFiyiStack],
	[User].[IAcceptTermsAndConditions] AS [IAcceptTermsAndConditions]
FROM 
	[User]
WHERE 1 = 1
	AND ([User].[FantasyName] = @FantasyName OR [User].[Email] = @Email)
	AND [User].[Password] = @Password
GO

/****** Object:  StoredProcedure [dbo].[User.GetOneByUserId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



















CREATE PROCEDURE [dbo].[User.GetOneByUserId]
(
	@UserId INT
)

AS

SET DATEFORMAT DMY

SELECT
	[User].[UserId] AS [UserId],
	ISNULL([User].[Name],' ') AS [Name],
	ISNULL([User].[FantasyName],' ') AS [FantasyName],
	ISNULL([User].[Email],' ') AS [Email],
	ISNULL([User].[Password],' ') AS [Password],
	ISNULL([User].[ProfilePicturePath],' ') AS [ProfilePicturePath],
	[User].[RoleId] AS [RoleId],
	[User].[PublicProjectsIdJoined] AS [PublicProjectsIdJoined],
	[User].[TokenGivenFromFiyiStack] AS [TokenGivenFromFiyiStack],
	[User].[IAcceptTermsAndConditions] AS [IAcceptTermsAndConditions]
FROM 
	[User]
WHERE 1 = 1
	AND [User].[UserId] = @UserId
GO

/****** Object:  StoredProcedure [dbo].[User.UpdateByUserId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

















CREATE PROCEDURE [dbo].[User.UpdateByUserId]
(
	@UserId INT,
	@Name VARCHAR(100),
	@FantasyName VARCHAR(100),
	@Email VARCHAR(100),
	@Password VARCHAR(100),
	@ProfilePicturePath VARCHAR(MAX),
	@RoleId INT,
	@PublicProjectsIdJoined VARCHAR(MAX),
	@TokenGivenFromFiyiStack VARCHAR(MAX),
	@IAcceptTermsAndConditions TINYINT
) 

AS

UPDATE [User] SET
	[Name] = @Name,
	[FantasyName] = @FantasyName,
	[Email] = @Email,
	[Password] = @Password,
	[ProfilePicturePath] = @ProfilePicturePath,
	[RoleId] = @RoleId,
	[PublicProjectsIdJoined] = @PublicProjectsIdJoined,
	[TokenGivenFromFiyiStack] = @TokenGivenFromFiyiStack,
	[IAcceptTermsAndConditions] = @IAcceptTermsAndConditions
WHERE 1 = 1
	AND [User].[UserId] = @UserId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[UserProject.Add]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO














CREATE PROCEDURE [dbo].[UserProject.Add]
(
	@UserId INT,
	@ProjectId INT,
	@AccessTypeId INT,
	@UsersIdThatAcceptedInvitation VARCHAR(MAX),
	@UsersIdThatHasBeenInvited VARCHAR(MAX),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@DateTimeLastModification DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT
) 

AS

INSERT INTO [UserProject] 
(
	[UserId],
	[ProjectId],
	[AccessTypeId],
	[UsersIdThatAcceptedInvitation],
	[UsersIdThatHasBeenInvited],
	[Active],
	[DateTimeCreation],
	[DateTimeLastModification],
	[UserIdCreation],
	[UserIdLastModification]
) 
VALUES
(
	@UserId,
	@ProjectId,
	@AccessTypeId,
	@UsersIdThatAcceptedInvitation,
	@UsersIdThatHasBeenInvited,
	@Active,
	@DateTimeCreation,
	@DateTimeLastModification,
	@UserIdCreation,
	@UserIdLastModification
)

SELECT @@identity AS 'MaxId'
GO

/****** Object:  StoredProcedure [dbo].[UserProject.DeleteByProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[UserProject.DeleteByProjectId]
(
	@ProjectId INT
) 

AS

DELETE FROM [UserProject] 
WHERE 1=1 
	AND [UserProject].[ProjectId] =  @ProjectId

SELECT @@ROWCOUNT As 'RowsAffected'
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUserIdByAccessTypeId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













CREATE PROCEDURE [dbo].[UserProject.GetAllByUserIdByAccessTypeId]
(
	@UserId INT,
	@AccessTypeId INT
)

AS

SELECT
	[UserProject].[UserProjectId] AS [UserProjectId],
	[UserProject].[UserId] AS [UserId],
	[UserProject].[ProjectId] AS [ProjectId],
	[UserProject].[AccessTypeId] AS [AccessTypeId],
	[UserProject].[UsersIdThatAcceptedInvitation] AS [UsersIdThatAcceptedInvitation],
	[UserProject].[UsersIdThatHasBeenInvited] as [UsersIdThatHasBeenInvited],
	[UserProject].[Active] AS [Active],
	[UserProject].[DateTimeCreation] AS [DateTimeCreation],
	[UserProject].[DateTimeLastModification] AS [DateTimeLastModification],
	[UserProject].[UserIdCreation] AS [UserIdCreation],
	[UserProject].[UserIdLastModification] AS [UserIdLastModification]
FROM 
	[UserProject]
WHERE 1 = 1 
	AND [UserProject].[AccessTypeId] = @AccessTypeId
	AND [UserProject].[UserId] = @UserId
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUserIdByProjectNameByAccessTypeId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[UserProject.GetAllByUserIdByProjectNameByAccessTypeId]
(
	@UserId INT,
	@ProjectName VARCHAR(100),
	@AccessTypeId INT
)

AS

SELECT
	[UserProject].[UserProjectId] AS [UserProjectId],
	[UserProject].[UserId] AS [UserId],
	[UserProject].[ProjectId] AS [ProjectId],
	[UserProject].[AccessTypeId] AS [AccessTypeId],
	[UserProject].[UsersIdThatAcceptedInvitation] AS [UsersIdThatAcceptedInvitation],
	[UserProject].[UsersIdThatHasBeenInvited] AS [UsersIdThatHasBeenInvited],
	[UserProject].[Active] AS [Active],
	[UserProject].[DateTimeCreation] AS [DateTimeCreation],
	[UserProject].[DateTimeLastModification] AS [DateTimeLastModification],
	[UserProject].[UserIdCreation] AS [UserIdCreation],
	[UserProject].[UserIdLastModification] AS [UserIdLastModification]
FROM 
	[UserProject], [Project]
WHERE 1 = 1 
	AND [UserProject].[ProjectId] = [Project].[ProjectId]
	AND [UserProject].[UserId] = @UserId
	AND ((@ProjectName != '' AND [Project].[Name] LIKE '%'+@ProjectName+'%') OR @ProjectName = '')
	AND ((@AccessTypeId != 0 AND [UserProject].[AccessTypeId] = @AccessTypeId) OR @AccessTypeId = 0)
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUsersIdThatAcceptedInvitation]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
















CREATE PROCEDURE [dbo].[UserProject.GetAllByUsersIdThatAcceptedInvitation]
(
	@UserId VARCHAR(MAX) --Need to be entered as UserId; . Example: 1;
)

AS

SELECT
	[UserProject].[UserProjectId] AS [UserProjectId],
	[UserProject].[UserId] AS [UserId],
	[UserProject].[ProjectId] AS [ProjectId],
	[UserProject].[AccessTypeId] AS [AccessTypeId],
	[UserProject].[UsersIdThatAcceptedInvitation] AS [UsersIdThatAcceptedInvitation],
	[UserProject].[UsersIdThatHasBeenInvited] AS [UsersIdThatHasBeenInvited],
	[UserProject].[Active] AS [Active],
	[UserProject].[DateTimeCreation] AS [DateTimeCreation],
	[UserProject].[DateTimeLastModification] AS [DateTimeLastModification],
	[UserProject].[UserIdCreation] AS [UserIdCreation],
	[UserProject].[UserIdLastModification] AS [UserIdLastModification]
FROM 
	[UserProject]
WHERE 1 = 1 
	AND [UserProject].[UsersIdThatAcceptedInvitation] LIKE '%' + @UserId + '%'
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetAllByUsersIdThatHasBeenInvited]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
















CREATE PROCEDURE [dbo].[UserProject.GetAllByUsersIdThatHasBeenInvited]
(
	@UserId VARCHAR(MAX) --Need to be entered as UserId; . Example: 1;
)

AS

SELECT
	[UserProject].[UserProjectId] AS [UserProjectId],
	[UserProject].[UserId] AS [UserId],
	[UserProject].[ProjectId] AS [ProjectId],
	[UserProject].[AccessTypeId] AS [AccessTypeId],
	[UserProject].[UsersIdThatAcceptedInvitation] AS [UsersIdThatAcceptedInvitation],
	[UserProject].[UsersIdThatHasBeenInvited] AS [UsersIdThatHasBeenInvited],
	[UserProject].[Active] AS [Active],
	[UserProject].[DateTimeCreation] AS [DateTimeCreation],
	[UserProject].[DateTimeLastModification] AS [DateTimeLastModification],
	[UserProject].[UserIdCreation] AS [UserIdCreation],
	[UserProject].[UserIdLastModification] AS [UserIdLastModification]
FROM 
	[UserProject]
WHERE 1 = 1 
	AND [UserProject].[UsersIdThatHasBeenInvited] = @UserId
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetOneByProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[UserProject.GetOneByProjectId]
(
	@ProjectId INT
)

AS

SELECT
	[UserProject].[UserProjectId] AS [UserProjectId],
	[UserProject].[UserId] AS [UserId],
	[UserProject].[ProjectId] AS [ProjectId],
	[UserProject].[AccessTypeId] AS [AccessTypeId],
	[UserProject].[UsersIdThatAcceptedInvitation] AS [UsersIdThatAcceptedInvitation],
	[UserProject].[UsersIdThatHasBeenInvited] as [UsersIdThatHasBeenInvited],
	[UserProject].[Active] AS [Active],
	[UserProject].[DateTimeCreation] AS [DateTimeCreation],
	[UserProject].[DateTimeLastModification] AS [DateTimeLastModification],
	[UserProject].[UserIdCreation] AS [UserIdCreation],
	[UserProject].[UserIdLastModification] AS [UserIdLastModification]
FROM
	[UserProject]
	LEFT OUTER JOIN [User] AS User_UserIdCreation ON [UserProject].[UserIdCreation] = User_UserIdCreation.[UserId]
	LEFT OUTER JOIN [User] AS User_UserIdLastModification ON [UserProject].[UserIdLastModification] = User_UserIdLastModification.[UserId]
WHERE 1 = 1 
	AND [UserProject].[ProjectId] = @ProjectId
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetOneByUserIdByProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[UserProject.GetOneByUserIdByProjectId]
(
	@UserId INT,
	@ProjectId INT
)

AS

SELECT
	[UserProject].[UserProjectId] AS [UserProjectId],
	[UserProject].[UserId] AS [UserId],
	[UserProject].[ProjectId] AS [ProjectId],
	[UserProject].[AccessTypeId] AS [AccessTypeId],
	[UserProject].[UsersIdThatAcceptedInvitation] AS [UsersIdThatAcceptedInvitation],
	[UserProject].[UsersIdThatHasBeenInvited] AS [UsersIdThatHasBeenInvited],
	[UserProject].[Active] AS [Active],
	[UserProject].[DateTimeCreation] AS [DateTimeCreation],
	[UserProject].[DateTimeLastModification] AS [DateTimeLastModification],
	[UserProject].[UserIdCreation] AS [UserIdCreation],
	[UserProject].[UserIdLastModification] AS [UserIdLastModification]
FROM 
	[UserProject]
WHERE 1 = 1 
	AND [UserProject].[UserId] = @UserId
	AND [UserProject].[ProjectId] = @ProjectId
GO

/****** Object:  StoredProcedure [dbo].[UserProject.GetOneByUserProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[UserProject.GetOneByUserProjectId]
(
	@UserProjectId INT
)

AS

SELECT
[UserProject].[UserProjectId] AS [UserProjectId],
[UserProject].[UserId] AS [UserId],
[UserProject].[ProjectId] AS [ProjectId],
[UserProject].[AccessTypeId] AS [AccessTypeId],
[UserProject].[UsersIdThatAcceptedInvitation] AS [UsersIdThatAcceptedInvitation],
[UserProject].[UsersIdThatHasBeenInvited] AS [UsersIdThatHasBeenInvited],
[UserProject].[Active] AS [Active],
[UserProject].[DateTimeCreation] AS [DateTimeCreation],
[UserProject].[DateTimeLastModification] AS [DateTimeLastModification],
[UserProject].[UserIdCreation] AS [UserIdCreation],
[UserProject].[UserIdLastModification] AS [UserIdLastModification]
FROM 
	[UserProject]
	LEFT OUTER JOIN [User] AS User_UserIdCreation ON [UserProject].[UserIdCreation] = User_UserIdCreation.[UserId]
	LEFT OUTER JOIN [User] AS User_UserIdLastModification ON [UserProject].[UserIdLastModification] = User_UserIdLastModification.[UserId]
WHERE 1 = 1 
	AND [UserProject].[UserProjectId] = @UserProjectId
GO

/****** Object:  StoredProcedure [dbo].[UserProject.UpdateByUserProjectId]    Script Date: 05/12/2022 14:25:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[UserProject.UpdateByUserProjectId]
(
	@UserProjectId INT,
	@UserId INT,
	@ProjectId INT,
	@AccessTypeId INT,
	@UsersIdThatAcceptedInvitation VARCHAR(MAX),
	@UsersIdThatHasBeenInvited VARCHAR(MAX),
	@Active TINYINT,
	@DateTimeCreation DATETIME,
	@UserIdCreation INT,
	@UserIdLastModification INT
)

AS

UPDATE [UserProject] SET
	[UserId] = @UserId,
	[ProjectId] = @ProjectId,
	[AccessTypeId] = @AccessTypeId,
	[UsersIdThatAcceptedInvitation] = @UsersIdThatAcceptedInvitation,
	[UsersIdThatHasBeenInvited] = @UsersIdThatHasBeenInvited,
	[Active] = @Active,
	[DateTimeCreation] = @DateTimeCreation,
	[UserIdCreation] = @UserIdCreation,
	[UserIdLastModification] = @UserIdLastModification
WHERE 1 = 1
	AND [UserProject].[UserProjectId] = @UserProjectId

SELECT @@ROWCOUNT AS 'RowsAffected'
GO


