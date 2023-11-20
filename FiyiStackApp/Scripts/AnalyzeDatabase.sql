USE [fiyistack_FiyiStackApp]

--ANALYTICS
SET DATEFORMAT dmy

SELECT -----------------------
CONVERT(varchar(10),[User_UserId].[UserId])+'-'+[User_UserId].[FantasyName]+'/'+CONVERT(varchar(10),[Project_ProjectId].[ProjectId])+'-'+[Project_ProjectId].[Name] AS [USUARIOS CON PROYECTOS ACTIVOS],
[Project_ProjectId].[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...]
FROM [UserProject] 
INNER JOIN [dbo].[User] AS [User_UserId] ON [dbo].[UserProject].[UserIdLastModification] = [User_UserId].[UserId]
INNER JOIN [dbo].[Project] AS [Project_ProjectId] ON [dbo].[UserProject].[ProjectId] = [Project_ProjectId].[ProjectId];

SELECT -----------------------
CONVERT(varchar(10),[DataBaseId])+'-'+[Name] AS [BDs ACTIVAS],
[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...] 
FROM [DataBase];

SELECT -----------------------
CONVERT(varchar(10),[TableId])+'-'+[Name] AS [TABLAS ACTIVAS], 
[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...]
FROM [Table];

SELECT -----------------------
[User_UserId].[FantasyName]+'/'+[Table_TableId].[Name]+'/'+[Field].[Name] AS [USUARIOS CON TABLAS Y PROPIEDADES ACTIVAS],
[DataType_DataTypeId].[Name] AS [DataType],
[Field].[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...] 
FROM [dbo].[Field]
INNER JOIN [dbo].[User] AS [User_UserId] ON [dbo].[Field].[UserIdLastModification] = [User_UserId].[UserId]
INNER JOIN [dbo].[DataType] AS [DataType_DataTypeId] ON [dbo].[Field].[DataTypeId] = [DataType_DataTypeId].[DataTypeId]
INNER JOIN [dbo].[Table] AS [Table_TableId] ON [dbo].[Field].[TableId] = [Table_TableId].[TableId];

SELECT -----------------------
[User_UserId].[FantasyName] + ' (ON)' AS [CONFIGURACIONES PARA USUARIOS ACTIVAS],
[UserConfiguration].[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...],
*
FROM [UserConfiguration]
INNER JOIN [dbo].[User] AS [User_UserId] ON [dbo].[UserConfiguration].[UserLastModificationId] = [User_UserId].[UserId];

SELECT -----------------------
[Project_ProjectId].[Name] + ' (ON)' AS [CONFIGURACIONES PARA PROYECTOS ACTIVOS],
[ProjectConfiguration].[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...],
* 
FROM [ProjectConfiguration]
INNER JOIN [dbo].[Project] AS [Project_ProjectId] ON [dbo].[ProjectConfiguration].[ProjectId] = [Project_ProjectId].[ProjectId];

SELECT -----------------------
[DataBase_DataBaseId].[Name] + ' (ON)' AS [CONFIGURACIONES PARA BDs ACTIVAS],
[DataBaseConfiguration].[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...],
* 
FROM [DataBaseConfiguration]
INNER JOIN [dbo].[DataBase] AS [DataBase_DataBaseId] ON [dbo].[DataBaseConfiguration].[DataBaseId] = [DataBase_DataBaseId].[DataBaseId];

SELECT -----------------------
[Table_TableId].[Name] + ' (ON)' AS [CONFIGURACIONES PARA TABLAS ACTIVAS],
[TableConfiguration].[DateTimeLastModification] AS [Última Fecha/Hora|yyyy-mm-dd/...],
* 
FROM [TableConfiguration]
INNER JOIN [dbo].[Table] AS [Table_TableId] ON [dbo].[TableConfiguration].[TableId] = [Table_TableId].[TableId];