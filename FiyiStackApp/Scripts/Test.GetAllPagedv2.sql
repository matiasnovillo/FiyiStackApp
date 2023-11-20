drop procedure [dbo].[Test.GetAllPaged]
go
CREATE PROCEDURE [dbo].[Test.GetAllPaged] (@p_query_string varchar(100), @p_Page_Number INT, @p_Num_Of_Rows_Per_Page INT, @p_Sorting_Column varchar(100))
AS
	SET NOCOUNT ON;
	BEGIN TRY
		select 
		[TestId], [FullName], [ProfilePicture], [Password], [AboutMe], [TechnologiesUsed], 
		[IsGirl], [Age], [CreationDateTime], [TimeLastConnection], [FavouriteColour], [Height]
		from test
		WHERE [AboutMe] LIKE  '%' + @p_query_string + '%'
		ORDER BY 
		CASE WHEN @p_Sorting_Column = 'TestId' THEN [TestId] END ,
		CASE WHEN @p_Sorting_Column = 'FullName' THEN [FullName] END,
		CASE WHEN @p_Sorting_Column = 'ProfilePicture' THEN [ProfilePicture] END ,
		CASE WHEN @p_Sorting_Column = 'Password' THEN [Password] END ,
		CASE WHEN @p_Sorting_Column = 'AboutMe' THEN [AboutMe] END ,
		CASE WHEN @p_Sorting_Column = 'TechnologiesUsed' THEN [TechnologiesUsed] END ,
		CASE WHEN @p_Sorting_Column = 'IsGirl' THEN [IsGirl] END ,
		CASE WHEN @p_Sorting_Column = 'Age' THEN [Age] END ,
		CASE WHEN @p_Sorting_Column = 'CreationDateTime' THEN [CreationDateTime] END ,
		CASE WHEN @p_Sorting_Column = 'TimeLastConnection' THEN [TimeLastConnection] END ,
		CASE WHEN @p_Sorting_Column = 'FavouriteColour' THEN [FavouriteColour] END ,
		CASE WHEN @p_Sorting_Column = 'Height' THEN [Height] END
		OFFSET (@p_Page_Number-1)*@p_Num_Of_Rows_Per_Page ROWS
		FETCH NEXT @p_Num_Of_Rows_Per_Page ROWS ONLY
	END TRY
	BEGIN CATCH
		PRINT ERROR_MESSAGE();
	END CATCH;