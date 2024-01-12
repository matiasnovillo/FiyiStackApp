USE [fiyistack_FiyiStackApp]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistTable]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistTable]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistField]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistField]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistDataBase]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.ExistDataBase]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]    Script Date: 11/01/2024 22:14:30 ******/
DROP PROCEDURE [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]
GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]    Script Date: 11/01/2024 22:14:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[CommonFunctions.MSSQLServer.DataBaseVersion]

AS

SELECT @@version

GO

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistDataBase]    Script Date: 11/01/2024 22:14:30 ******/
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

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistField]    Script Date: 11/01/2024 22:14:30 ******/
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

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistStoredProcedure]    Script Date: 11/01/2024 22:14:30 ******/
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

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.ExistTable]    Script Date: 11/01/2024 22:14:30 ******/
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

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllFieldsByTableNameBySchemeName]    Script Date: 11/01/2024 22:14:30 ******/
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

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetAllTablesByDataBaseName]    Script Date: 11/01/2024 22:14:30 ******/
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

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneFieldByTableNameBySchemeNameByFieldName]    Script Date: 11/01/2024 22:14:30 ******/
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

/****** Object:  StoredProcedure [dbo].[CommonFunctions.MSSQLServer.GetOneStoredProcedureByDataBaseNameBySchemeNameByName]    Script Date: 11/01/2024 22:14:30 ******/
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


