
Use [Cossis]
Go
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Department_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Department_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Department_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Department table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Department_Get_List

AS



SELECT
    [DeptId],
    [Code],
    [Name],
    [Phone],
    [Priority],
    [Fax],
    [IsActive],
    [IsDeletable],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Department]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Department_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Department_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Department_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Department table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Department_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[DeptId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [DeptId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [Phone]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [Fax]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Department]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [DeptId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [Phone],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [Fax],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Department]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Department_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Department_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Department_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Department table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Department_Insert
(
    @DeptId int OUTPUT,
    @Code nvarchar(50),
    @Name nvarchar(200),
    @Phone varchar(100),
    @Priority int,
    @Fax varchar(100),
    @IsActive bigint,
    @IsDeletable bigint,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Department]
(
    [Code],
    [Name],
    [Phone],
    [Priority],
    [Fax],
    [IsActive],
    [IsDeletable],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @Code,
    @Name,
    @Phone,
    @Priority,
    @Fax,
    @IsActive,
    @IsDeletable,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @DeptId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Department_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Department_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Department_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Department table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Department_Update
(
    @DeptId int,
    @Code nvarchar(50),
    @Name nvarchar(200),
    @Phone varchar(100),
    @Priority int,
    @Fax varchar(100),
    @IsActive bigint,
    @IsDeletable bigint,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Department]
SET
    [Code] = @Code,
    [Name] = @Name,
    [Phone] = @Phone,
    [Priority] = @Priority,
    [Fax] = @Fax,
    [IsActive] = @IsActive,
    [IsDeletable] = @IsDeletable,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [DeptId] = @DeptId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Department_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Department_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Department_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Department table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Department_Delete
(
    @DeptId int
)
AS


DELETE FROM dbo.[Department] WITH (ROWLOCK) 
WHERE
    [DeptId] = @DeptId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Department_GetByDeptId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Department_GetByDeptId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Department_GetByDeptId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Department table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Department_GetByDeptId
(
    @DeptId int
)
AS


SELECT
    [DeptId],
    [Code],
    [Name],
    [Phone],
    [Priority],
    [Fax],
    [IsActive],
    [IsDeletable],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Department]
WHERE
    [DeptId] = @DeptId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Department_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Department_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Department_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Department table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Department_Find
(
    @SearchUsingOR bit = null,
    @DeptId int = null,
    @Code nvarchar(50) = null,
    @Name nvarchar(200) = null,
    @Phone varchar(100) = null,
    @Priority int = null,
    @Fax varchar(100) = null,
    @IsActive bigint = null,
    @IsDeletable bigint = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [DeptId], 
        [Code], 
        [Name], 
        [Phone], 
        [Priority], 
        [Fax], 
        [IsActive], 
        [IsDeletable], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[Department]
    WHERE 
     ([DeptId] = @DeptId OR @DeptId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([Phone] = @Phone OR @Phone is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([Fax] = @Fax OR @Fax is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [DeptId], 
            [Code], 
            [Name], 
            [Phone], 
            [Priority], 
            [Fax], 
            [IsActive], 
            [IsDeletable], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[Department]
        WHERE
     ([DeptId] = @DeptId AND @DeptId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([Phone] = @Phone AND @Phone is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([Fax] = @Fax AND @Fax is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Group_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Group_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Group_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Group_Get_List

AS



SELECT
    [GroupId],
    [ParentGroupId],
    [Code],
    [Name],
    [Description],
    [Type],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationUserId],
    [CreationDate],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Group]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Group_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Group_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Group_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Group table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Group_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[GroupId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [GroupId]'
SET @SQL = @SQL + ', [ParentGroupId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [Description]'
SET @SQL = @SQL + ', [Type]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Group]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [GroupId],'
SET @SQL = @SQL + ' [ParentGroupId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [Description],'
SET @SQL = @SQL + ' [Type],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Group]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Group_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Group_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Group_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Group_Insert
(
    @GroupId int OUTPUT,
    @ParentGroupId int,
    @Code nvarchar(50),
    @Name nvarchar(200),
    @Description nvarchar(1000),
    @Type int,
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @CreationUserId int,
    @CreationDate datetime,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Group]
(
    [ParentGroupId],
    [Code],
    [Name],
    [Description],
    [Type],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationUserId],
    [CreationDate],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @ParentGroupId,
    @Code,
    @Name,
    @Description,
    @Type,
    @IsActive,
    @IsDeletable,
    @Priority,
    @CreationUserId,
    @CreationDate,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @GroupId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Group_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Group_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Group_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Group_Update
(
    @GroupId int,
    @ParentGroupId int,
    @Code nvarchar(50),
    @Name nvarchar(200),
    @Description nvarchar(1000),
    @Type int,
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @CreationUserId int,
    @CreationDate datetime,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Group]
SET
    [ParentGroupId] = @ParentGroupId,
    [Code] = @Code,
    [Name] = @Name,
    [Description] = @Description,
    [Type] = @Type,
    [IsActive] = @IsActive,
    [IsDeletable] = @IsDeletable,
    [Priority] = @Priority,
    [CreationUserId] = @CreationUserId,
    [CreationDate] = @CreationDate,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [GroupId] = @GroupId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Group_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Group_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Group_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Group table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Group_Delete
(
    @GroupId int
)
AS


DELETE FROM dbo.[Group] WITH (ROWLOCK) 
WHERE
    [GroupId] = @GroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Group_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Group_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Group_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Group table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Group_GetByGroupId
(
    @GroupId int
)
AS


SELECT
    [GroupId],
    [ParentGroupId],
    [Code],
    [Name],
    [Description],
    [Type],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationUserId],
    [CreationDate],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Group]
WHERE
    [GroupId] = @GroupId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Group_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Group_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Group_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Group table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Group_Find
(
    @SearchUsingOR bit = null,
    @GroupId int = null,
    @ParentGroupId int = null,
    @Code nvarchar(50) = null,
    @Name nvarchar(200) = null,
    @Description nvarchar(1000) = null,
    @Type int = null,
    @IsActive bit = null,
    @IsDeletable bit = null,
    @Priority int = null,
    @CreationUserId int = null,
    @CreationDate datetime = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [GroupId], 
        [ParentGroupId], 
        [Code], 
        [Name], 
        [Description], 
        [Type], 
        [IsActive], 
        [IsDeletable], 
        [Priority], 
        [CreationUserId], 
        [CreationDate], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[Group]
    WHERE 
     ([GroupId] = @GroupId OR @GroupId is null)
    AND ([ParentGroupId] = @ParentGroupId OR @ParentGroupId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([Description] = @Description OR @Description is null)
    AND ([Type] = @Type OR @Type is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [GroupId], 
            [ParentGroupId], 
            [Code], 
            [Name], 
            [Description], 
            [Type], 
            [IsActive], 
            [IsDeletable], 
            [Priority], 
            [CreationUserId], 
            [CreationDate], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[Group]
        WHERE
     ([GroupId] = @GroupId AND @GroupId is not null)
    OR ([ParentGroupId] = @ParentGroupId AND @ParentGroupId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([Description] = @Description AND @Description is not null)
    OR ([Type] = @Type AND @Type is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Repository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_Get_List

AS



SELECT
    [RepositoryId],
    [RepositoryManagerStaffId],
    [Code],
    [Name],
    [Address],
    [ProvinceId],
    [IsActive],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Repository]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Repository table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[RepositoryId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [RepositoryId]'
SET @SQL = @SQL + ', [RepositoryManagerStaffId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [Address]'
SET @SQL = @SQL + ', [ProvinceId]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Repository]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [RepositoryId],'
SET @SQL = @SQL + ' [RepositoryManagerStaffId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [Address],'
SET @SQL = @SQL + ' [ProvinceId],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Repository]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Repository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_Insert
(
    @RepositoryId int,
    @RepositoryManagerStaffId int,
    @Code nvarchar(50),
    @Name nvarchar(300),
    @Address nvarchar(500),
    @ProvinceId int,
    @IsActive bit,
    @Priority int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Repository]
(
    [RepositoryId],
    [RepositoryManagerStaffId],
    [Code],
    [Name],
    [Address],
    [ProvinceId],
    [IsActive],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @RepositoryId,
    @RepositoryManagerStaffId,
    @Code,
    @Name,
    @Address,
    @ProvinceId,
    @IsActive,
    @Priority,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Repository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_Update
(
    @RepositoryId int,
    @OriginalRepositoryId int,
    @RepositoryManagerStaffId int,
    @Code nvarchar(50),
    @Name nvarchar(300),
    @Address nvarchar(500),
    @ProvinceId int,
    @IsActive bit,
    @Priority int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Repository]
SET
    [RepositoryId] = @RepositoryId,
    [RepositoryManagerStaffId] = @RepositoryManagerStaffId,
    [Code] = @Code,
    [Name] = @Name,
    [Address] = @Address,
    [ProvinceId] = @ProvinceId,
    [IsActive] = @IsActive,
    [Priority] = @Priority,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [RepositoryId] = @OriginalRepositoryId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Repository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_Delete
(
    @RepositoryId int
)
AS


DELETE FROM dbo.[Repository] WITH (ROWLOCK) 
WHERE
    [RepositoryId] = @RepositoryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_GetByRepositoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_GetByRepositoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_GetByRepositoryId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Repository table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_GetByRepositoryId
(
    @RepositoryId int
)
AS


SELECT
    [RepositoryId],
    [RepositoryManagerStaffId],
    [Code],
    [Name],
    [Address],
    [ProvinceId],
    [IsActive],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Repository]
WHERE
    [RepositoryId] = @RepositoryId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_GetByItemIdFromItemInRepository procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_GetByItemIdFromItemInRepository') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_GetByItemIdFromItemInRepository
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_GetByItemIdFromItemInRepository
(
    @ItemId bigint
)
AS


SELECT dbo.[Repository].[RepositoryId]
       ,dbo.[Repository].[RepositoryManagerStaffId]
       ,dbo.[Repository].[Code]
       ,dbo.[Repository].[Name]
       ,dbo.[Repository].[Address]
       ,dbo.[Repository].[ProvinceId]
       ,dbo.[Repository].[IsActive]
       ,dbo.[Repository].[Priority]
       ,dbo.[Repository].[CreationDate]
       ,dbo.[Repository].[CreationUserId]
       ,dbo.[Repository].[LastModificationDate]
       ,dbo.[Repository].[LastModificationUserId]
  FROM dbo.[Repository]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[ItemInRepository] 
                WHERE dbo.[ItemInRepository].[ItemId] = @ItemId
                  AND dbo.[ItemInRepository].[RepositoryId] = dbo.[Repository].[RepositoryId]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Repository_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Repository_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Repository_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Repository table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Repository_Find
(
    @SearchUsingOR bit = null,
    @RepositoryId int = null,
    @RepositoryManagerStaffId int = null,
    @Code nvarchar(50) = null,
    @Name nvarchar(300) = null,
    @Address nvarchar(500) = null,
    @ProvinceId int = null,
    @IsActive bit = null,
    @Priority int = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [RepositoryId], 
        [RepositoryManagerStaffId], 
        [Code], 
        [Name], 
        [Address], 
        [ProvinceId], 
        [IsActive], 
        [Priority], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[Repository]
    WHERE 
     ([RepositoryId] = @RepositoryId OR @RepositoryId is null)
    AND ([RepositoryManagerStaffId] = @RepositoryManagerStaffId OR @RepositoryManagerStaffId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([Address] = @Address OR @Address is null)
    AND ([ProvinceId] = @ProvinceId OR @ProvinceId is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [RepositoryId], 
            [RepositoryManagerStaffId], 
            [Code], 
            [Name], 
            [Address], 
            [ProvinceId], 
            [IsActive], 
            [Priority], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[Repository]
        WHERE
     ([RepositoryId] = @RepositoryId AND @RepositoryId is not null)
    OR ([RepositoryManagerStaffId] = @RepositoryManagerStaffId AND @RepositoryManagerStaffId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([Address] = @Address AND @Address is not null)
    OR ([ProvinceId] = @ProvinceId AND @ProvinceId is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Get_List

AS



SELECT
    [ItemId],
    [GroupId],
    [Code],
    [Name],
    [Description],
    [BaseUnitId],
    [UsedUnitId],
    [Density],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [Status],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Item]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Item table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[ItemId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [ItemId]'
SET @SQL = @SQL + ', [GroupId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [Description]'
SET @SQL = @SQL + ', [BaseUnitId]'
SET @SQL = @SQL + ', [UsedUnitId]'
SET @SQL = @SQL + ', [Density]'
SET @SQL = @SQL + ', [TotalQuantity]'
SET @SQL = @SQL + ', [AvailabelQuantity]'
SET @SQL = @SQL + ', [ReserveQuantity]'
SET @SQL = @SQL + ', [ReturnQuantity]'
SET @SQL = @SQL + ', [AdjustQuantity]'
SET @SQL = @SQL + ', [Status]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Item]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [ItemId],'
SET @SQL = @SQL + ' [GroupId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [Description],'
SET @SQL = @SQL + ' [BaseUnitId],'
SET @SQL = @SQL + ' [UsedUnitId],'
SET @SQL = @SQL + ' [Density],'
SET @SQL = @SQL + ' [TotalQuantity],'
SET @SQL = @SQL + ' [AvailabelQuantity],'
SET @SQL = @SQL + ' [ReserveQuantity],'
SET @SQL = @SQL + ' [ReturnQuantity],'
SET @SQL = @SQL + ' [AdjustQuantity],'
SET @SQL = @SQL + ' [Status],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Item]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Insert
(
    @ItemId bigint,
    @GroupId int,
    @Code varchar(200),
    @Name nvarchar(500),
    @Description ntext,
    @BaseUnitId int,
    @UsedUnitId int,
    @Density float,
    @TotalQuantity bigint,
    @AvailabelQuantity bigint,
    @ReserveQuantity bigint,
    @ReturnQuantity bigint,
    @AdjustQuantity bigint,
    @Status int,
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Item]
(
    [ItemId],
    [GroupId],
    [Code],
    [Name],
    [Description],
    [BaseUnitId],
    [UsedUnitId],
    [Density],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [Status],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @ItemId,
    @GroupId,
    @Code,
    @Name,
    @Description,
    @BaseUnitId,
    @UsedUnitId,
    @Density,
    @TotalQuantity,
    @AvailabelQuantity,
    @ReserveQuantity,
    @ReturnQuantity,
    @AdjustQuantity,
    @Status,
    @IsActive,
    @IsDeletable,
    @Priority,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Update
(
    @ItemId bigint,
    @OriginalItemId bigint,
    @GroupId int,
    @Code varchar(200),
    @Name nvarchar(500),
    @Description ntext,
    @BaseUnitId int,
    @UsedUnitId int,
    @Density float,
    @TotalQuantity bigint,
    @AvailabelQuantity bigint,
    @ReserveQuantity bigint,
    @ReturnQuantity bigint,
    @AdjustQuantity bigint,
    @Status int,
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Item]
SET
    [ItemId] = @ItemId,
    [GroupId] = @GroupId,
    [Code] = @Code,
    [Name] = @Name,
    [Description] = @Description,
    [BaseUnitId] = @BaseUnitId,
    [UsedUnitId] = @UsedUnitId,
    [Density] = @Density,
    [TotalQuantity] = @TotalQuantity,
    [AvailabelQuantity] = @AvailabelQuantity,
    [ReserveQuantity] = @ReserveQuantity,
    [ReturnQuantity] = @ReturnQuantity,
    [AdjustQuantity] = @AdjustQuantity,
    [Status] = @Status,
    [IsActive] = @IsActive,
    [IsDeletable] = @IsDeletable,
    [Priority] = @Priority,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [ItemId] = @OriginalItemId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Item table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Delete
(
    @ItemId bigint
)
AS


DELETE FROM dbo.[Item] WITH (ROWLOCK) 
WHERE
    [ItemId] = @ItemId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByBaseUnitId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByBaseUnitId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByBaseUnitId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Item table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByBaseUnitId
(
    @BaseUnitId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ItemId],
    [GroupId],
    [Code],
    [Name],
    [Description],
    [BaseUnitId],
    [UsedUnitId],
    [Density],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [Status],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Item]
WHERE
    [BaseUnitId] = @BaseUnitId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByUsedUnitId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByUsedUnitId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByUsedUnitId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Item table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByUsedUnitId
(
    @UsedUnitId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ItemId],
    [GroupId],
    [Code],
    [Name],
    [Description],
    [BaseUnitId],
    [UsedUnitId],
    [Density],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [Status],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Item]
WHERE
    [UsedUnitId] = @UsedUnitId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Item table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByGroupId
(
    @GroupId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ItemId],
    [GroupId],
    [Code],
    [Name],
    [Description],
    [BaseUnitId],
    [UsedUnitId],
    [Density],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [Status],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Item]
WHERE
    [GroupId] = @GroupId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Item table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByItemId
(
    @ItemId bigint
)
AS


SELECT
    [ItemId],
    [GroupId],
    [Code],
    [Name],
    [Description],
    [BaseUnitId],
    [UsedUnitId],
    [Density],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [Status],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Item]
WHERE
    [ItemId] = @ItemId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_GetByRepositoryIdFromItemInRepository procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_GetByRepositoryIdFromItemInRepository') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_GetByRepositoryIdFromItemInRepository
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_GetByRepositoryIdFromItemInRepository
(
    @RepositoryId int
)
AS


SELECT dbo.[Item].[ItemId]
       ,dbo.[Item].[GroupId]
       ,dbo.[Item].[Code]
       ,dbo.[Item].[Name]
       ,dbo.[Item].[Description]
       ,dbo.[Item].[BaseUnitId]
       ,dbo.[Item].[UsedUnitId]
       ,dbo.[Item].[Density]
       ,dbo.[Item].[TotalQuantity]
       ,dbo.[Item].[AvailabelQuantity]
       ,dbo.[Item].[ReserveQuantity]
       ,dbo.[Item].[ReturnQuantity]
       ,dbo.[Item].[AdjustQuantity]
       ,dbo.[Item].[Status]
       ,dbo.[Item].[IsActive]
       ,dbo.[Item].[IsDeletable]
       ,dbo.[Item].[Priority]
       ,dbo.[Item].[CreationDate]
       ,dbo.[Item].[CreationUserId]
       ,dbo.[Item].[LastModificationDate]
       ,dbo.[Item].[LastModificationUserId]
  FROM dbo.[Item]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[ItemInRepository] 
                WHERE dbo.[ItemInRepository].[RepositoryId] = @RepositoryId
                  AND dbo.[ItemInRepository].[ItemId] = dbo.[Item].[ItemId]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Item_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Item_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Item_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Item table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Item_Find
(
    @SearchUsingOR bit = null,
    @ItemId bigint = null,
    @GroupId int = null,
    @Code varchar(200) = null,
    @Name nvarchar(500) = null,
    @Description ntext = null,
    @BaseUnitId int = null,
    @UsedUnitId int = null,
    @Density float = null,
    @TotalQuantity bigint = null,
    @AvailabelQuantity bigint = null,
    @ReserveQuantity bigint = null,
    @ReturnQuantity bigint = null,
    @AdjustQuantity bigint = null,
    @Status int = null,
    @IsActive bit = null,
    @IsDeletable bit = null,
    @Priority int = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [ItemId], 
        [GroupId], 
        [Code], 
        [Name], 
        [Description], 
        [BaseUnitId], 
        [UsedUnitId], 
        [Density], 
        [TotalQuantity], 
        [AvailabelQuantity], 
        [ReserveQuantity], 
        [ReturnQuantity], 
        [AdjustQuantity], 
        [Status], 
        [IsActive], 
        [IsDeletable], 
        [Priority], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[Item]
    WHERE 
     ([ItemId] = @ItemId OR @ItemId is null)
    AND ([GroupId] = @GroupId OR @GroupId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([BaseUnitId] = @BaseUnitId OR @BaseUnitId is null)
    AND ([UsedUnitId] = @UsedUnitId OR @UsedUnitId is null)
    AND ([Density] = @Density OR @Density is null)
    AND ([TotalQuantity] = @TotalQuantity OR @TotalQuantity is null)
    AND ([AvailabelQuantity] = @AvailabelQuantity OR @AvailabelQuantity is null)
    AND ([ReserveQuantity] = @ReserveQuantity OR @ReserveQuantity is null)
    AND ([ReturnQuantity] = @ReturnQuantity OR @ReturnQuantity is null)
    AND ([AdjustQuantity] = @AdjustQuantity OR @AdjustQuantity is null)
    AND ([Status] = @Status OR @Status is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [ItemId], 
            [GroupId], 
            [Code], 
            [Name], 
            [Description], 
            [BaseUnitId], 
            [UsedUnitId], 
            [Density], 
            [TotalQuantity], 
            [AvailabelQuantity], 
            [ReserveQuantity], 
            [ReturnQuantity], 
            [AdjustQuantity], 
            [Status], 
            [IsActive], 
            [IsDeletable], 
            [Priority], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[Item]
        WHERE
     ([ItemId] = @ItemId AND @ItemId is not null)
    OR ([GroupId] = @GroupId AND @GroupId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([BaseUnitId] = @BaseUnitId AND @BaseUnitId is not null)
    OR ([UsedUnitId] = @UsedUnitId AND @UsedUnitId is not null)
    OR ([Density] = @Density AND @Density is not null)
    OR ([TotalQuantity] = @TotalQuantity AND @TotalQuantity is not null)
    OR ([AvailabelQuantity] = @AvailabelQuantity AND @AvailabelQuantity is not null)
    OR ([ReserveQuantity] = @ReserveQuantity AND @ReserveQuantity is not null)
    OR ([ReturnQuantity] = @ReturnQuantity AND @ReturnQuantity is not null)
    OR ([AdjustQuantity] = @AdjustQuantity AND @AdjustQuantity is not null)
    OR ([Status] = @Status AND @Status is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserGroup_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserGroup_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserGroup_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the UserGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserGroup_Get_List

AS



SELECT
    [UserGroupId],
    [UserGroupName],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[UserGroup]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserGroup_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserGroup_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserGroup_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the UserGroup table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserGroup_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[UserGroupId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [UserGroupId]'
SET @SQL = @SQL + ', [UserGroupName]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[UserGroup]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [UserGroupId],'
SET @SQL = @SQL + ' [UserGroupName],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[UserGroup]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserGroup_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserGroup_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserGroup_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the UserGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserGroup_Insert
(
    @UserGroupId int OUTPUT,
    @UserGroupName nvarchar(200),
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[UserGroup]
(
    [UserGroupName],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @UserGroupName,
    @IsActive,
    @IsDeletable,
    @Priority,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @UserGroupId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserGroup_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserGroup_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserGroup_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the UserGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserGroup_Update
(
    @UserGroupId int,
    @UserGroupName nvarchar(200),
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[UserGroup]
SET
    [UserGroupName] = @UserGroupName,
    [IsActive] = @IsActive,
    [IsDeletable] = @IsDeletable,
    [Priority] = @Priority,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [UserGroupId] = @UserGroupId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserGroup_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserGroup_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserGroup_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the UserGroup table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserGroup_Delete
(
    @UserGroupId int
)
AS


DELETE FROM dbo.[UserGroup] WITH (ROWLOCK) 
WHERE
    [UserGroupId] = @UserGroupId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserGroup_GetByUserGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserGroup_GetByUserGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserGroup_GetByUserGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the UserGroup table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserGroup_GetByUserGroupId
(
    @UserGroupId int
)
AS


SELECT
    [UserGroupId],
    [UserGroupName],
    [IsActive],
    [IsDeletable],
    [Priority],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[UserGroup]
WHERE
    [UserGroupId] = @UserGroupId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserGroup_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserGroup_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserGroup_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the UserGroup table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserGroup_Find
(
    @SearchUsingOR bit = null,
    @UserGroupId int = null,
    @UserGroupName nvarchar(200) = null,
    @IsActive bit = null,
    @IsDeletable bit = null,
    @Priority int = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [UserGroupId], 
        [UserGroupName], 
        [IsActive], 
        [IsDeletable], 
        [Priority], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[UserGroup]
    WHERE 
     ([UserGroupId] = @UserGroupId OR @UserGroupId is null)
    AND ([UserGroupName] = @UserGroupName OR @UserGroupName is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [UserGroupId], 
            [UserGroupName], 
            [IsActive], 
            [IsDeletable], 
            [Priority], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[UserGroup]
        WHERE
     ([UserGroupId] = @UserGroupId AND @UserGroupId is not null)
    OR ([UserGroupName] = @UserGroupName AND @UserGroupName is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contactor_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contactor_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contactor_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Contactor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contactor_Get_List

AS



SELECT
    [ContractId],
    [PartnerId],
    [GroupId],
    [Code],
    [Name],
    [JobTitle],
    [Email],
    [Mobile],
    [Phone],
    [Ext],
    [IsActive],
    [Priority],
    [Comment],
    [CreationDate],
    [CreationUserId],
    [LastModifitionDate],
    [LastModificationUserId]
FROM
    dbo.[Contactor]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contactor_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contactor_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contactor_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Contactor table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contactor_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[ContractId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [ContractId]'
SET @SQL = @SQL + ', [PartnerId]'
SET @SQL = @SQL + ', [GroupId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [JobTitle]'
SET @SQL = @SQL + ', [Email]'
SET @SQL = @SQL + ', [Mobile]'
SET @SQL = @SQL + ', [Phone]'
SET @SQL = @SQL + ', [Ext]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [Comment]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModifitionDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Contactor]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [ContractId],'
SET @SQL = @SQL + ' [PartnerId],'
SET @SQL = @SQL + ' [GroupId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [JobTitle],'
SET @SQL = @SQL + ' [Email],'
SET @SQL = @SQL + ' [Mobile],'
SET @SQL = @SQL + ' [Phone],'
SET @SQL = @SQL + ' [Ext],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [Comment],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModifitionDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Contactor]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contactor_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contactor_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contactor_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Contactor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contactor_Insert
(
    @ContractId int OUTPUT,
    @PartnerId int,
    @GroupId int,
    @Code varchar(50),
    @Name nvarchar(500),
    @JobTitle nvarchar(200),
    @Email nvarchar(100),
    @Mobile varchar(100),
    @Phone varchar(100),
    @Ext varchar(5),
    @IsActive bit,
    @Priority int,
    @Comment ntext,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModifitionDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Contactor]
(
    [PartnerId],
    [GroupId],
    [Code],
    [Name],
    [JobTitle],
    [Email],
    [Mobile],
    [Phone],
    [Ext],
    [IsActive],
    [Priority],
    [Comment],
    [CreationDate],
    [CreationUserId],
    [LastModifitionDate],
    [LastModificationUserId]
)
VALUES
(
    @PartnerId,
    @GroupId,
    @Code,
    @Name,
    @JobTitle,
    @Email,
    @Mobile,
    @Phone,
    @Ext,
    @IsActive,
    @Priority,
    @Comment,
    @CreationDate,
    @CreationUserId,
    @LastModifitionDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @ContractId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contactor_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contactor_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contactor_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Contactor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contactor_Update
(
    @ContractId int,
    @PartnerId int,
    @GroupId int,
    @Code varchar(50),
    @Name nvarchar(500),
    @JobTitle nvarchar(200),
    @Email nvarchar(100),
    @Mobile varchar(100),
    @Phone varchar(100),
    @Ext varchar(5),
    @IsActive bit,
    @Priority int,
    @Comment ntext,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModifitionDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Contactor]
SET
    [PartnerId] = @PartnerId,
    [GroupId] = @GroupId,
    [Code] = @Code,
    [Name] = @Name,
    [JobTitle] = @JobTitle,
    [Email] = @Email,
    [Mobile] = @Mobile,
    [Phone] = @Phone,
    [Ext] = @Ext,
    [IsActive] = @IsActive,
    [Priority] = @Priority,
    [Comment] = @Comment,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModifitionDate] = @LastModifitionDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [ContractId] = @ContractId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contactor_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contactor_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contactor_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Contactor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contactor_Delete
(
    @ContractId int
)
AS


DELETE FROM dbo.[Contactor] WITH (ROWLOCK) 
WHERE
    [ContractId] = @ContractId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contactor_GetByContractId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contactor_GetByContractId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contactor_GetByContractId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Contactor table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contactor_GetByContractId
(
    @ContractId int
)
AS


SELECT
    [ContractId],
    [PartnerId],
    [GroupId],
    [Code],
    [Name],
    [JobTitle],
    [Email],
    [Mobile],
    [Phone],
    [Ext],
    [IsActive],
    [Priority],
    [Comment],
    [CreationDate],
    [CreationUserId],
    [LastModifitionDate],
    [LastModificationUserId]
FROM
    dbo.[Contactor]
WHERE
    [ContractId] = @ContractId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contactor_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contactor_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contactor_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Contactor table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contactor_Find
(
    @SearchUsingOR bit = null,
    @ContractId int = null,
    @PartnerId int = null,
    @GroupId int = null,
    @Code varchar(50) = null,
    @Name nvarchar(500) = null,
    @JobTitle nvarchar(200) = null,
    @Email nvarchar(100) = null,
    @Mobile varchar(100) = null,
    @Phone varchar(100) = null,
    @Ext varchar(5) = null,
    @IsActive bit = null,
    @Priority int = null,
    @Comment ntext = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModifitionDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [ContractId], 
        [PartnerId], 
        [GroupId], 
        [Code], 
        [Name], 
        [JobTitle], 
        [Email], 
        [Mobile], 
        [Phone], 
        [Ext], 
        [IsActive], 
        [Priority], 
        [Comment], 
        [CreationDate], 
        [CreationUserId], 
        [LastModifitionDate], 
        [LastModificationUserId]
    FROM
        dbo.[Contactor]
    WHERE 
     ([ContractId] = @ContractId OR @ContractId is null)
    AND ([PartnerId] = @PartnerId OR @PartnerId is null)
    AND ([GroupId] = @GroupId OR @GroupId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([JobTitle] = @JobTitle OR @JobTitle is null)
    AND ([Email] = @Email OR @Email is null)
    AND ([Mobile] = @Mobile OR @Mobile is null)
    AND ([Phone] = @Phone OR @Phone is null)
    AND ([Ext] = @Ext OR @Ext is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModifitionDate] = @LastModifitionDate OR @LastModifitionDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [ContractId], 
            [PartnerId], 
            [GroupId], 
            [Code], 
            [Name], 
            [JobTitle], 
            [Email], 
            [Mobile], 
            [Phone], 
            [Ext], 
            [IsActive], 
            [Priority], 
            [Comment], 
            [CreationDate], 
            [CreationUserId], 
            [LastModifitionDate], 
            [LastModificationUserId]
        FROM
            dbo.[Contactor]
        WHERE
     ([ContractId] = @ContractId AND @ContractId is not null)
    OR ([PartnerId] = @PartnerId AND @PartnerId is not null)
    OR ([GroupId] = @GroupId AND @GroupId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([JobTitle] = @JobTitle AND @JobTitle is not null)
    OR ([Email] = @Email AND @Email is not null)
    OR ([Mobile] = @Mobile AND @Mobile is not null)
    OR ([Phone] = @Phone AND @Phone is not null)
    OR ([Ext] = @Ext AND @Ext is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModifitionDate] = @LastModifitionDate AND @LastModifitionDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Contract table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_Get_List

AS



SELECT
    [ContractId],
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Contract]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Contract table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[ContractId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [ContractId]'
SET @SQL = @SQL + ', [ConstructDeptId]'
SET @SQL = @SQL + ', [DesignDeptId]'
SET @SQL = @SQL + ', [GroupId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Number]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [Description]'
SET @SQL = @SQL + ', [InitPrice]'
SET @SQL = @SQL + ', [LastPrice]'
SET @SQL = @SQL + ', [FromDate]'
SET @SQL = @SQL + ', [ToDate]'
SET @SQL = @SQL + ', [RealFromDate]'
SET @SQL = @SQL + ', [RealToDate]'
SET @SQL = @SQL + ', [Status]'
SET @SQL = @SQL + ', [IsApprove]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsPrinted]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ' FROM dbo.[Contract]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [ContractId],'
SET @SQL = @SQL + ' [ConstructDeptId],'
SET @SQL = @SQL + ' [DesignDeptId],'
SET @SQL = @SQL + ' [GroupId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Number],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [Description],'
SET @SQL = @SQL + ' [InitPrice],'
SET @SQL = @SQL + ' [LastPrice],'
SET @SQL = @SQL + ' [FromDate],'
SET @SQL = @SQL + ' [ToDate],'
SET @SQL = @SQL + ' [RealFromDate],'
SET @SQL = @SQL + ' [RealToDate],'
SET @SQL = @SQL + ' [Status],'
SET @SQL = @SQL + ' [IsApprove],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsPrinted],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [LastModificationUserId],'
SET @SQL = @SQL + ' [LastModificationDate]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Contract]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Contract table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_Insert
(
    @ContractId int OUTPUT,
    @ConstructDeptId int,
    @DesignDeptId int,
    @GroupId int,
    @Code nvarchar(200),
    @Number nvarchar(200),
    @Name nvarchar(500),
    @Description ntext,
    @InitPrice money,
    @LastPrice money,
    @FromDate datetime,
    @ToDate datetime,
    @RealFromDate datetime,
    @RealToDate datetime,
    @Status int,
    @IsApprove bit,
    @IsActive bit,
    @IsPrinted bigint,
    @CreationUserId int,
    @CreationDate datetime,
    @LastModificationUserId int,
    @LastModificationDate datetime
)
AS


					
INSERT INTO dbo.[Contract]
(
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
)
VALUES
(
    @ConstructDeptId,
    @DesignDeptId,
    @GroupId,
    @Code,
    @Number,
    @Name,
    @Description,
    @InitPrice,
    @LastPrice,
    @FromDate,
    @ToDate,
    @RealFromDate,
    @RealToDate,
    @Status,
    @IsApprove,
    @IsActive,
    @IsPrinted,
    @CreationUserId,
    @CreationDate,
    @LastModificationUserId,
    @LastModificationDate
)
				
-- Get the identity value
SET @ContractId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Contract table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_Update
(
    @ContractId int,
    @ConstructDeptId int,
    @DesignDeptId int,
    @GroupId int,
    @Code nvarchar(200),
    @Number nvarchar(200),
    @Name nvarchar(500),
    @Description ntext,
    @InitPrice money,
    @LastPrice money,
    @FromDate datetime,
    @ToDate datetime,
    @RealFromDate datetime,
    @RealToDate datetime,
    @Status int,
    @IsApprove bit,
    @IsActive bit,
    @IsPrinted bigint,
    @CreationUserId int,
    @CreationDate datetime,
    @LastModificationUserId int,
    @LastModificationDate datetime
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Contract]
SET
    [ConstructDeptId] = @ConstructDeptId,
    [DesignDeptId] = @DesignDeptId,
    [GroupId] = @GroupId,
    [Code] = @Code,
    [Number] = @Number,
    [Name] = @Name,
    [Description] = @Description,
    [InitPrice] = @InitPrice,
    [LastPrice] = @LastPrice,
    [FromDate] = @FromDate,
    [ToDate] = @ToDate,
    [RealFromDate] = @RealFromDate,
    [RealToDate] = @RealToDate,
    [Status] = @Status,
    [IsApprove] = @IsApprove,
    [IsActive] = @IsActive,
    [IsPrinted] = @IsPrinted,
    [CreationUserId] = @CreationUserId,
    [CreationDate] = @CreationDate,
    [LastModificationUserId] = @LastModificationUserId,
    [LastModificationDate] = @LastModificationDate
WHERE
    [ContractId] = @ContractId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Contract table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_Delete
(
    @ContractId int
)
AS


DELETE FROM dbo.[Contract] WITH (ROWLOCK) 
WHERE
    [ContractId] = @ContractId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_GetByConstructDeptId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_GetByConstructDeptId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_GetByConstructDeptId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Contract table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_GetByConstructDeptId
(
    @ConstructDeptId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ContractId],
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Contract]
WHERE
    [ConstructDeptId] = @ConstructDeptId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_GetByDesignDeptId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_GetByDesignDeptId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_GetByDesignDeptId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Contract table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_GetByDesignDeptId
(
    @DesignDeptId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ContractId],
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Contract]
WHERE
    [DesignDeptId] = @DesignDeptId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Contract table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_GetByGroupId
(
    @GroupId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ContractId],
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Contract]
WHERE
    [GroupId] = @GroupId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_GetByCreationUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_GetByCreationUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_GetByCreationUserId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Contract table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_GetByCreationUserId
(
    @CreationUserId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ContractId],
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Contract]
WHERE
    [CreationUserId] = @CreationUserId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_GetByLastModificationUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_GetByLastModificationUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_GetByLastModificationUserId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Contract table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_GetByLastModificationUserId
(
    @LastModificationUserId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ContractId],
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Contract]
WHERE
    [LastModificationUserId] = @LastModificationUserId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_GetByContractId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_GetByContractId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_GetByContractId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Contract table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_GetByContractId
(
    @ContractId int
)
AS


SELECT
    [ContractId],
    [ConstructDeptId],
    [DesignDeptId],
    [GroupId],
    [Code],
    [Number],
    [Name],
    [Description],
    [InitPrice],
    [LastPrice],
    [FromDate],
    [ToDate],
    [RealFromDate],
    [RealToDate],
    [Status],
    [IsApprove],
    [IsActive],
    [IsPrinted],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Contract]
WHERE
    [ContractId] = @ContractId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Contract_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Contract_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Contract_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Contract table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Contract_Find
(
    @SearchUsingOR bit = null,
    @ContractId int = null,
    @ConstructDeptId int = null,
    @DesignDeptId int = null,
    @GroupId int = null,
    @Code nvarchar(200) = null,
    @Number nvarchar(200) = null,
    @Name nvarchar(500) = null,
    @Description ntext = null,
    @InitPrice money = null,
    @LastPrice money = null,
    @FromDate datetime = null,
    @ToDate datetime = null,
    @RealFromDate datetime = null,
    @RealToDate datetime = null,
    @Status int = null,
    @IsApprove bit = null,
    @IsActive bit = null,
    @IsPrinted bigint = null,
    @CreationUserId int = null,
    @CreationDate datetime = null,
    @LastModificationUserId int = null,
    @LastModificationDate datetime = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [ContractId], 
        [ConstructDeptId], 
        [DesignDeptId], 
        [GroupId], 
        [Code], 
        [Number], 
        [Name], 
        [Description], 
        [InitPrice], 
        [LastPrice], 
        [FromDate], 
        [ToDate], 
        [RealFromDate], 
        [RealToDate], 
        [Status], 
        [IsApprove], 
        [IsActive], 
        [IsPrinted], 
        [CreationUserId], 
        [CreationDate], 
        [LastModificationUserId], 
        [LastModificationDate]
    FROM
        dbo.[Contract]
    WHERE 
     ([ContractId] = @ContractId OR @ContractId is null)
    AND ([ConstructDeptId] = @ConstructDeptId OR @ConstructDeptId is null)
    AND ([DesignDeptId] = @DesignDeptId OR @DesignDeptId is null)
    AND ([GroupId] = @GroupId OR @GroupId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Number] = @Number OR @Number is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([InitPrice] = @InitPrice OR @InitPrice is null)
    AND ([LastPrice] = @LastPrice OR @LastPrice is null)
    AND ([FromDate] = @FromDate OR @FromDate is null)
    AND ([ToDate] = @ToDate OR @ToDate is null)
    AND ([RealFromDate] = @RealFromDate OR @RealFromDate is null)
    AND ([RealToDate] = @RealToDate OR @RealToDate is null)
    AND ([Status] = @Status OR @Status is null)
    AND ([IsApprove] = @IsApprove OR @IsApprove is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsPrinted] = @IsPrinted OR @IsPrinted is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
END
ELSE
    BEGIN
        SELECT
            [ContractId], 
            [ConstructDeptId], 
            [DesignDeptId], 
            [GroupId], 
            [Code], 
            [Number], 
            [Name], 
            [Description], 
            [InitPrice], 
            [LastPrice], 
            [FromDate], 
            [ToDate], 
            [RealFromDate], 
            [RealToDate], 
            [Status], 
            [IsApprove], 
            [IsActive], 
            [IsPrinted], 
            [CreationUserId], 
            [CreationDate], 
            [LastModificationUserId], 
            [LastModificationDate]
        FROM
            dbo.[Contract]
        WHERE
     ([ContractId] = @ContractId AND @ContractId is not null)
    OR ([ConstructDeptId] = @ConstructDeptId AND @ConstructDeptId is not null)
    OR ([DesignDeptId] = @DesignDeptId AND @DesignDeptId is not null)
    OR ([GroupId] = @GroupId AND @GroupId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Number] = @Number AND @Number is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([InitPrice] = @InitPrice AND @InitPrice is not null)
    OR ([LastPrice] = @LastPrice AND @LastPrice is not null)
    OR ([FromDate] = @FromDate AND @FromDate is not null)
    OR ([ToDate] = @ToDate AND @ToDate is not null)
    OR ([RealFromDate] = @RealFromDate AND @RealFromDate is not null)
    OR ([RealToDate] = @RealToDate AND @RealToDate is not null)
    OR ([Status] = @Status AND @Status is not null)
    OR ([IsApprove] = @IsApprove AND @IsApprove is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsPrinted] = @IsPrinted AND @IsPrinted is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the ItemInRepository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_Get_List

AS



SELECT
    [RepositoryId],
    [ItemId],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [IsActive],
    [IsDeletable],
    [Status],
    [Priority],
    [BaseUnitId],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInRepository]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the ItemInRepository table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[RepositoryId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [RepositoryId]'
SET @SQL = @SQL + ', [ItemId]'
SET @SQL = @SQL + ', [TotalQuantity]'
SET @SQL = @SQL + ', [AvailabelQuantity]'
SET @SQL = @SQL + ', [ReserveQuantity]'
SET @SQL = @SQL + ', [ReturnQuantity]'
SET @SQL = @SQL + ', [AdjustQuantity]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [Status]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [BaseUnitId]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[ItemInRepository]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [RepositoryId],'
SET @SQL = @SQL + ' [ItemId],'
SET @SQL = @SQL + ' [TotalQuantity],'
SET @SQL = @SQL + ' [AvailabelQuantity],'
SET @SQL = @SQL + ' [ReserveQuantity],'
SET @SQL = @SQL + ' [ReturnQuantity],'
SET @SQL = @SQL + ' [AdjustQuantity],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [Status],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [BaseUnitId],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[ItemInRepository]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the ItemInRepository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_Insert
(
    @RepositoryId int,
    @ItemId bigint,
    @TotalQuantity bigint,
    @AvailabelQuantity bigint,
    @ReserveQuantity bigint,
    @ReturnQuantity bigint,
    @AdjustQuantity bigint,
    @IsActive bit,
    @IsDeletable bit,
    @Status int,
    @Priority int,
    @BaseUnitId int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[ItemInRepository]
(
    [RepositoryId],
    [ItemId],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [IsActive],
    [IsDeletable],
    [Status],
    [Priority],
    [BaseUnitId],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @RepositoryId,
    @ItemId,
    @TotalQuantity,
    @AvailabelQuantity,
    @ReserveQuantity,
    @ReturnQuantity,
    @AdjustQuantity,
    @IsActive,
    @IsDeletable,
    @Status,
    @Priority,
    @BaseUnitId,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the ItemInRepository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_Update
(
    @RepositoryId int,
    @OriginalRepositoryId int,
    @ItemId bigint,
    @OriginalItemId bigint,
    @TotalQuantity bigint,
    @AvailabelQuantity bigint,
    @ReserveQuantity bigint,
    @ReturnQuantity bigint,
    @AdjustQuantity bigint,
    @IsActive bit,
    @IsDeletable bit,
    @Status int,
    @Priority int,
    @BaseUnitId int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[ItemInRepository]
SET
    [RepositoryId] = @RepositoryId,
    [ItemId] = @ItemId,
    [TotalQuantity] = @TotalQuantity,
    [AvailabelQuantity] = @AvailabelQuantity,
    [ReserveQuantity] = @ReserveQuantity,
    [ReturnQuantity] = @ReturnQuantity,
    [AdjustQuantity] = @AdjustQuantity,
    [IsActive] = @IsActive,
    [IsDeletable] = @IsDeletable,
    [Status] = @Status,
    [Priority] = @Priority,
    [BaseUnitId] = @BaseUnitId,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [RepositoryId] = @OriginalRepositoryId 
AND [ItemId] = @OriginalItemId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the ItemInRepository table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_Delete
(
    @RepositoryId int,
    @ItemId bigint
)
AS


DELETE FROM dbo.[ItemInRepository] WITH (ROWLOCK) 
WHERE
    [RepositoryId] = @RepositoryId
    AND [ItemId] = @ItemId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemInRepository table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_GetByItemId
(
    @ItemId bigint
)
AS


SET ANSI_NULLS OFF

SELECT
    [RepositoryId],
    [ItemId],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [IsActive],
    [IsDeletable],
    [Status],
    [Priority],
    [BaseUnitId],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInRepository]
WHERE
    [ItemId] = @ItemId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_GetByRepositoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_GetByRepositoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_GetByRepositoryId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemInRepository table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_GetByRepositoryId
(
    @RepositoryId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [RepositoryId],
    [ItemId],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [IsActive],
    [IsDeletable],
    [Status],
    [Priority],
    [BaseUnitId],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInRepository]
WHERE
    [RepositoryId] = @RepositoryId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_GetByRepositoryIdItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_GetByRepositoryIdItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_GetByRepositoryIdItemId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemInRepository table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_GetByRepositoryIdItemId
(
    @RepositoryId int,
    @ItemId bigint
)
AS


SELECT
    [RepositoryId],
    [ItemId],
    [TotalQuantity],
    [AvailabelQuantity],
    [ReserveQuantity],
    [ReturnQuantity],
    [AdjustQuantity],
    [IsActive],
    [IsDeletable],
    [Status],
    [Priority],
    [BaseUnitId],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInRepository]
WHERE
    [RepositoryId] = @RepositoryId
    AND [ItemId] = @ItemId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInRepository_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInRepository_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInRepository_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the ItemInRepository table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInRepository_Find
(
    @SearchUsingOR bit = null,
    @RepositoryId int = null,
    @ItemId bigint = null,
    @TotalQuantity bigint = null,
    @AvailabelQuantity bigint = null,
    @ReserveQuantity bigint = null,
    @ReturnQuantity bigint = null,
    @AdjustQuantity bigint = null,
    @IsActive bit = null,
    @IsDeletable bit = null,
    @Status int = null,
    @Priority int = null,
    @BaseUnitId int = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [RepositoryId], 
        [ItemId], 
        [TotalQuantity], 
        [AvailabelQuantity], 
        [ReserveQuantity], 
        [ReturnQuantity], 
        [AdjustQuantity], 
        [IsActive], 
        [IsDeletable], 
        [Status], 
        [Priority], 
        [BaseUnitId], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[ItemInRepository]
    WHERE 
     ([RepositoryId] = @RepositoryId OR @RepositoryId is null)
    AND ([ItemId] = @ItemId OR @ItemId is null)
    AND ([TotalQuantity] = @TotalQuantity OR @TotalQuantity is null)
    AND ([AvailabelQuantity] = @AvailabelQuantity OR @AvailabelQuantity is null)
    AND ([ReserveQuantity] = @ReserveQuantity OR @ReserveQuantity is null)
    AND ([ReturnQuantity] = @ReturnQuantity OR @ReturnQuantity is null)
    AND ([AdjustQuantity] = @AdjustQuantity OR @AdjustQuantity is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([Status] = @Status OR @Status is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([BaseUnitId] = @BaseUnitId OR @BaseUnitId is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [RepositoryId], 
            [ItemId], 
            [TotalQuantity], 
            [AvailabelQuantity], 
            [ReserveQuantity], 
            [ReturnQuantity], 
            [AdjustQuantity], 
            [IsActive], 
            [IsDeletable], 
            [Status], 
            [Priority], 
            [BaseUnitId], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[ItemInRepository]
        WHERE
     ([RepositoryId] = @RepositoryId AND @RepositoryId is not null)
    OR ([ItemId] = @ItemId AND @ItemId is not null)
    OR ([TotalQuantity] = @TotalQuantity AND @TotalQuantity is not null)
    OR ([AvailabelQuantity] = @AvailabelQuantity AND @AvailabelQuantity is not null)
    OR ([ReserveQuantity] = @ReserveQuantity AND @ReserveQuantity is not null)
    OR ([ReturnQuantity] = @ReturnQuantity AND @ReturnQuantity is not null)
    OR ([AdjustQuantity] = @AdjustQuantity AND @AdjustQuantity is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([Status] = @Status AND @Status is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([BaseUnitId] = @BaseUnitId AND @BaseUnitId is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the ItemInProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_Get_List

AS



SELECT
    [ItemInProjectId],
    [ItemId],
    [ProjectId],
    [ContractId],
    [Quantity],
    [UnitPrice],
    [Total],
    [IsActive],
    [IsApprove],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInProject]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the ItemInProject table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[ItemInProjectId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [ItemInProjectId]'
SET @SQL = @SQL + ', [ItemId]'
SET @SQL = @SQL + ', [ProjectId]'
SET @SQL = @SQL + ', [ContractId]'
SET @SQL = @SQL + ', [Quantity]'
SET @SQL = @SQL + ', [UnitPrice]'
SET @SQL = @SQL + ', [Total]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsApprove]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[ItemInProject]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [ItemInProjectId],'
SET @SQL = @SQL + ' [ItemId],'
SET @SQL = @SQL + ' [ProjectId],'
SET @SQL = @SQL + ' [ContractId],'
SET @SQL = @SQL + ' [Quantity],'
SET @SQL = @SQL + ' [UnitPrice],'
SET @SQL = @SQL + ' [Total],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsApprove],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[ItemInProject]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the ItemInProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_Insert
(
    @ItemInProjectId int OUTPUT,
    @ItemId bigint,
    @ProjectId int,
    @ContractId int,
    @Quantity float,
    @UnitPrice money,
    @Total money,
    @IsActive bit,
    @IsApprove bit,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[ItemInProject]
(
    [ItemId],
    [ProjectId],
    [ContractId],
    [Quantity],
    [UnitPrice],
    [Total],
    [IsActive],
    [IsApprove],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @ItemId,
    @ProjectId,
    @ContractId,
    @Quantity,
    @UnitPrice,
    @Total,
    @IsActive,
    @IsApprove,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @ItemInProjectId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the ItemInProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_Update
(
    @ItemInProjectId int,
    @ItemId bigint,
    @ProjectId int,
    @ContractId int,
    @Quantity float,
    @UnitPrice money,
    @Total money,
    @IsActive bit,
    @IsApprove bit,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[ItemInProject]
SET
    [ItemId] = @ItemId,
    [ProjectId] = @ProjectId,
    [ContractId] = @ContractId,
    [Quantity] = @Quantity,
    [UnitPrice] = @UnitPrice,
    [Total] = @Total,
    [IsActive] = @IsActive,
    [IsApprove] = @IsApprove,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [ItemInProjectId] = @ItemInProjectId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the ItemInProject table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_Delete
(
    @ItemInProjectId int
)
AS


DELETE FROM dbo.[ItemInProject] WITH (ROWLOCK) 
WHERE
    [ItemInProjectId] = @ItemInProjectId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_GetByContractId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_GetByContractId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_GetByContractId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemInProject table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_GetByContractId
(
    @ContractId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ItemInProjectId],
    [ItemId],
    [ProjectId],
    [ContractId],
    [Quantity],
    [UnitPrice],
    [Total],
    [IsActive],
    [IsApprove],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInProject]
WHERE
    [ContractId] = @ContractId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_GetByProjectId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_GetByProjectId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_GetByProjectId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemInProject table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_GetByProjectId
(
    @ProjectId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ItemInProjectId],
    [ItemId],
    [ProjectId],
    [ContractId],
    [Quantity],
    [UnitPrice],
    [Total],
    [IsActive],
    [IsApprove],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInProject]
WHERE
    [ProjectId] = @ProjectId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemInProject table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_GetByItemId
(
    @ItemId bigint
)
AS


SET ANSI_NULLS OFF

SELECT
    [ItemInProjectId],
    [ItemId],
    [ProjectId],
    [ContractId],
    [Quantity],
    [UnitPrice],
    [Total],
    [IsActive],
    [IsApprove],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInProject]
WHERE
    [ItemId] = @ItemId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_GetByItemInProjectId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_GetByItemInProjectId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_GetByItemInProjectId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemInProject table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_GetByItemInProjectId
(
    @ItemInProjectId int
)
AS


SELECT
    [ItemInProjectId],
    [ItemId],
    [ProjectId],
    [ContractId],
    [Quantity],
    [UnitPrice],
    [Total],
    [IsActive],
    [IsApprove],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemInProject]
WHERE
    [ItemInProjectId] = @ItemInProjectId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemInProject_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemInProject_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemInProject_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the ItemInProject table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemInProject_Find
(
    @SearchUsingOR bit = null,
    @ItemInProjectId int = null,
    @ItemId bigint = null,
    @ProjectId int = null,
    @ContractId int = null,
    @Quantity float = null,
    @UnitPrice money = null,
    @Total money = null,
    @IsActive bit = null,
    @IsApprove bit = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [ItemInProjectId], 
        [ItemId], 
        [ProjectId], 
        [ContractId], 
        [Quantity], 
        [UnitPrice], 
        [Total], 
        [IsActive], 
        [IsApprove], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[ItemInProject]
    WHERE 
     ([ItemInProjectId] = @ItemInProjectId OR @ItemInProjectId is null)
    AND ([ItemId] = @ItemId OR @ItemId is null)
    AND ([ProjectId] = @ProjectId OR @ProjectId is null)
    AND ([ContractId] = @ContractId OR @ContractId is null)
    AND ([Quantity] = @Quantity OR @Quantity is null)
    AND ([UnitPrice] = @UnitPrice OR @UnitPrice is null)
    AND ([Total] = @Total OR @Total is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsApprove] = @IsApprove OR @IsApprove is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [ItemInProjectId], 
            [ItemId], 
            [ProjectId], 
            [ContractId], 
            [Quantity], 
            [UnitPrice], 
            [Total], 
            [IsActive], 
            [IsApprove], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[ItemInProject]
        WHERE
     ([ItemInProjectId] = @ItemInProjectId AND @ItemInProjectId is not null)
    OR ([ItemId] = @ItemId AND @ItemId is not null)
    OR ([ProjectId] = @ProjectId AND @ProjectId is not null)
    OR ([ContractId] = @ContractId AND @ContractId is not null)
    OR ([Quantity] = @Quantity AND @Quantity is not null)
    OR ([UnitPrice] = @UnitPrice AND @UnitPrice is not null)
    OR ([Total] = @Total AND @Total is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsApprove] = @IsApprove AND @IsApprove is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Get_List

AS



SELECT
    [PartnerId],
    [GroupId],
    [Code],
    [Name],
    [NameInEng],
    [TaxCode],
    [Priority],
    [Address],
    [Phone],
    [Fax],
    [Email],
    [IsDeletable],
    [IsActive],
    [Comment],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Partner]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Partner table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[PartnerId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [PartnerId]'
SET @SQL = @SQL + ', [GroupId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [NameInEng]'
SET @SQL = @SQL + ', [TaxCode]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [Address]'
SET @SQL = @SQL + ', [Phone]'
SET @SQL = @SQL + ', [Fax]'
SET @SQL = @SQL + ', [Email]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [Comment]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Partner]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [PartnerId],'
SET @SQL = @SQL + ' [GroupId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [NameInEng],'
SET @SQL = @SQL + ' [TaxCode],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [Address],'
SET @SQL = @SQL + ' [Phone],'
SET @SQL = @SQL + ' [Fax],'
SET @SQL = @SQL + ' [Email],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [Comment],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Partner]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Insert
(
    @PartnerId int OUTPUT,
    @GroupId int,
    @Code nvarchar(50),
    @Name nvarchar(500),
    @NameInEng varchar(500),
    @TaxCode varchar(50),
    @Priority int,
    @Address nvarchar(500),
    @Phone varchar(200),
    @Fax varchar(200),
    @Email varchar(200),
    @IsDeletable bit,
    @IsActive bit,
    @Comment ntext,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Partner]
(
    [GroupId],
    [Code],
    [Name],
    [NameInEng],
    [TaxCode],
    [Priority],
    [Address],
    [Phone],
    [Fax],
    [Email],
    [IsDeletable],
    [IsActive],
    [Comment],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @GroupId,
    @Code,
    @Name,
    @NameInEng,
    @TaxCode,
    @Priority,
    @Address,
    @Phone,
    @Fax,
    @Email,
    @IsDeletable,
    @IsActive,
    @Comment,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @PartnerId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Update
(
    @PartnerId int,
    @GroupId int,
    @Code nvarchar(50),
    @Name nvarchar(500),
    @NameInEng varchar(500),
    @TaxCode varchar(50),
    @Priority int,
    @Address nvarchar(500),
    @Phone varchar(200),
    @Fax varchar(200),
    @Email varchar(200),
    @IsDeletable bit,
    @IsActive bit,
    @Comment ntext,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Partner]
SET
    [GroupId] = @GroupId,
    [Code] = @Code,
    [Name] = @Name,
    [NameInEng] = @NameInEng,
    [TaxCode] = @TaxCode,
    [Priority] = @Priority,
    [Address] = @Address,
    [Phone] = @Phone,
    [Fax] = @Fax,
    [Email] = @Email,
    [IsDeletable] = @IsDeletable,
    [IsActive] = @IsActive,
    [Comment] = @Comment,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [PartnerId] = @PartnerId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Partner table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Delete
(
    @PartnerId int
)
AS


DELETE FROM dbo.[Partner] WITH (ROWLOCK) 
WHERE
    [PartnerId] = @PartnerId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_GetByPartnerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_GetByPartnerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_GetByPartnerId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Partner table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_GetByPartnerId
(
    @PartnerId int
)
AS


SELECT
    [PartnerId],
    [GroupId],
    [Code],
    [Name],
    [NameInEng],
    [TaxCode],
    [Priority],
    [Address],
    [Phone],
    [Fax],
    [Email],
    [IsDeletable],
    [IsActive],
    [Comment],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Partner]
WHERE
    [PartnerId] = @PartnerId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Partner_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Partner_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Partner_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Partner table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Partner_Find
(
    @SearchUsingOR bit = null,
    @PartnerId int = null,
    @GroupId int = null,
    @Code nvarchar(50) = null,
    @Name nvarchar(500) = null,
    @NameInEng varchar(500) = null,
    @TaxCode varchar(50) = null,
    @Priority int = null,
    @Address nvarchar(500) = null,
    @Phone varchar(200) = null,
    @Fax varchar(200) = null,
    @Email varchar(200) = null,
    @IsDeletable bit = null,
    @IsActive bit = null,
    @Comment ntext = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [PartnerId], 
        [GroupId], 
        [Code], 
        [Name], 
        [NameInEng], 
        [TaxCode], 
        [Priority], 
        [Address], 
        [Phone], 
        [Fax], 
        [Email], 
        [IsDeletable], 
        [IsActive], 
        [Comment], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[Partner]
    WHERE 
     ([PartnerId] = @PartnerId OR @PartnerId is null)
    AND ([GroupId] = @GroupId OR @GroupId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([NameInEng] = @NameInEng OR @NameInEng is null)
    AND ([TaxCode] = @TaxCode OR @TaxCode is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([Address] = @Address OR @Address is null)
    AND ([Phone] = @Phone OR @Phone is null)
    AND ([Fax] = @Fax OR @Fax is null)
    AND ([Email] = @Email OR @Email is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [PartnerId], 
            [GroupId], 
            [Code], 
            [Name], 
            [NameInEng], 
            [TaxCode], 
            [Priority], 
            [Address], 
            [Phone], 
            [Fax], 
            [Email], 
            [IsDeletable], 
            [IsActive], 
            [Comment], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[Partner]
        WHERE
     ([PartnerId] = @PartnerId AND @PartnerId is not null)
    OR ([GroupId] = @GroupId AND @GroupId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([NameInEng] = @NameInEng AND @NameInEng is not null)
    OR ([TaxCode] = @TaxCode AND @TaxCode is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([Address] = @Address AND @Address is not null)
    OR ([Phone] = @Phone AND @Phone is not null)
    OR ([Fax] = @Fax AND @Fax is not null)
    OR ([Email] = @Email AND @Email is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Role_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Role_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Role_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Role table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Role_Get_List

AS



SELECT
    [RoleId],
    [Code],
    [Name],
    [IsActive],
    [IsDeletable],
    [Type],
    [CreationDate],
    [CreationUserId],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Role]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Role_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Role_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Role_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Role table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Role_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[RoleId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [RoleId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [Type]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ' FROM dbo.[Role]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [RoleId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [Type],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationUserId],'
SET @SQL = @SQL + ' [LastModificationDate]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Role]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Role_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Role_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Role_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Role table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Role_Insert
(
    @RoleId int OUTPUT,
    @Code nvarchar(50),
    @Name nvarchar(100),
    @IsActive bit,
    @IsDeletable bit,
    @Type int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationUserId int,
    @LastModificationDate datetime
)
AS


					
INSERT INTO dbo.[Role]
(
    [Code],
    [Name],
    [IsActive],
    [IsDeletable],
    [Type],
    [CreationDate],
    [CreationUserId],
    [LastModificationUserId],
    [LastModificationDate]
)
VALUES
(
    @Code,
    @Name,
    @IsActive,
    @IsDeletable,
    @Type,
    @CreationDate,
    @CreationUserId,
    @LastModificationUserId,
    @LastModificationDate
)
				
-- Get the identity value
SET @RoleId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Role_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Role_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Role_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Role table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Role_Update
(
    @RoleId int,
    @Code nvarchar(50),
    @Name nvarchar(100),
    @IsActive bit,
    @IsDeletable bit,
    @Type int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationUserId int,
    @LastModificationDate datetime
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Role]
SET
    [Code] = @Code,
    [Name] = @Name,
    [IsActive] = @IsActive,
    [IsDeletable] = @IsDeletable,
    [Type] = @Type,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationUserId] = @LastModificationUserId,
    [LastModificationDate] = @LastModificationDate
WHERE
    [RoleId] = @RoleId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Role_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Role_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Role_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Role table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Role_Delete
(
    @RoleId int
)
AS


DELETE FROM dbo.[Role] WITH (ROWLOCK) 
WHERE
    [RoleId] = @RoleId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Role_GetByRoleId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Role_GetByRoleId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Role_GetByRoleId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Role table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Role_GetByRoleId
(
    @RoleId int
)
AS


SELECT
    [RoleId],
    [Code],
    [Name],
    [IsActive],
    [IsDeletable],
    [Type],
    [CreationDate],
    [CreationUserId],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[Role]
WHERE
    [RoleId] = @RoleId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Role_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Role_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Role_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Role table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Role_Find
(
    @SearchUsingOR bit = null,
    @RoleId int = null,
    @Code nvarchar(50) = null,
    @Name nvarchar(100) = null,
    @IsActive bit = null,
    @IsDeletable bit = null,
    @Type int = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationUserId int = null,
    @LastModificationDate datetime = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [RoleId], 
        [Code], 
        [Name], 
        [IsActive], 
        [IsDeletable], 
        [Type], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationUserId], 
        [LastModificationDate]
    FROM
        dbo.[Role]
    WHERE 
     ([RoleId] = @RoleId OR @RoleId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([Type] = @Type OR @Type is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
END
ELSE
    BEGIN
        SELECT
            [RoleId], 
            [Code], 
            [Name], 
            [IsActive], 
            [IsDeletable], 
            [Type], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationUserId], 
            [LastModificationDate]
        FROM
            dbo.[Role]
        WHERE
     ([RoleId] = @RoleId AND @RoleId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([Type] = @Type AND @Type is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the UnitConvertor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_Get_List

AS



SELECT
    [FromUnitId],
    [ToUnitId],
    [Quantity],
    [IsDeletable],
    [IsActive],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[UnitConvertor]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the UnitConvertor table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[FromUnitId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [FromUnitId]'
SET @SQL = @SQL + ', [ToUnitId]'
SET @SQL = @SQL + ', [Quantity]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[UnitConvertor]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [FromUnitId],'
SET @SQL = @SQL + ' [ToUnitId],'
SET @SQL = @SQL + ' [Quantity],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[UnitConvertor]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the UnitConvertor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_Insert
(
    @FromUnitId int,
    @ToUnitId int,
    @Quantity float,
    @IsDeletable bit,
    @IsActive bit,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[UnitConvertor]
(
    [FromUnitId],
    [ToUnitId],
    [Quantity],
    [IsDeletable],
    [IsActive],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @FromUnitId,
    @ToUnitId,
    @Quantity,
    @IsDeletable,
    @IsActive,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the UnitConvertor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_Update
(
    @FromUnitId int,
    @OriginalFromUnitId int,
    @ToUnitId int,
    @OriginalToUnitId int,
    @Quantity float,
    @IsDeletable bit,
    @IsActive bit,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[UnitConvertor]
SET
    [FromUnitId] = @FromUnitId,
    [ToUnitId] = @ToUnitId,
    [Quantity] = @Quantity,
    [IsDeletable] = @IsDeletable,
    [IsActive] = @IsActive,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [FromUnitId] = @OriginalFromUnitId 
AND [ToUnitId] = @OriginalToUnitId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the UnitConvertor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_Delete
(
    @FromUnitId int,
    @ToUnitId int
)
AS


DELETE FROM dbo.[UnitConvertor] WITH (ROWLOCK) 
WHERE
    [FromUnitId] = @FromUnitId
    AND [ToUnitId] = @ToUnitId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_GetByFromUnitId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_GetByFromUnitId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_GetByFromUnitId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the UnitConvertor table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_GetByFromUnitId
(
    @FromUnitId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [FromUnitId],
    [ToUnitId],
    [Quantity],
    [IsDeletable],
    [IsActive],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[UnitConvertor]
WHERE
    [FromUnitId] = @FromUnitId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_GetByToUnitId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_GetByToUnitId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_GetByToUnitId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the UnitConvertor table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_GetByToUnitId
(
    @ToUnitId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [FromUnitId],
    [ToUnitId],
    [Quantity],
    [IsDeletable],
    [IsActive],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[UnitConvertor]
WHERE
    [ToUnitId] = @ToUnitId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_GetByFromUnitIdToUnitId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_GetByFromUnitIdToUnitId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_GetByFromUnitIdToUnitId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the UnitConvertor table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_GetByFromUnitIdToUnitId
(
    @FromUnitId int,
    @ToUnitId int
)
AS


SELECT
    [FromUnitId],
    [ToUnitId],
    [Quantity],
    [IsDeletable],
    [IsActive],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[UnitConvertor]
WHERE
    [FromUnitId] = @FromUnitId
    AND [ToUnitId] = @ToUnitId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UnitConvertor_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UnitConvertor_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UnitConvertor_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the UnitConvertor table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UnitConvertor_Find
(
    @SearchUsingOR bit = null,
    @FromUnitId int = null,
    @ToUnitId int = null,
    @Quantity float = null,
    @IsDeletable bit = null,
    @IsActive bit = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [FromUnitId], 
        [ToUnitId], 
        [Quantity], 
        [IsDeletable], 
        [IsActive], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[UnitConvertor]
    WHERE 
     ([FromUnitId] = @FromUnitId OR @FromUnitId is null)
    AND ([ToUnitId] = @ToUnitId OR @ToUnitId is null)
    AND ([Quantity] = @Quantity OR @Quantity is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [FromUnitId], 
            [ToUnitId], 
            [Quantity], 
            [IsDeletable], 
            [IsActive], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[UnitConvertor]
        WHERE
     ([FromUnitId] = @FromUnitId AND @FromUnitId is not null)
    OR ([ToUnitId] = @ToUnitId AND @ToUnitId is not null)
    OR ([Quantity] = @Quantity AND @Quantity is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Get_List

AS



SELECT
    [UserId],
    [UserGroupId],
    [Email],
    [Pwd],
    [PwdFormat],
    [FullName],
    [Phone],
    [IsDeletable],
    [IsActive],
    [IsFirstLoggedIn],
    [IsLocked],
    [LogInFail],
    [LastLoginDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[User]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the User table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[UserId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [UserId]'
SET @SQL = @SQL + ', [UserGroupId]'
SET @SQL = @SQL + ', [Email]'
SET @SQL = @SQL + ', [Pwd]'
SET @SQL = @SQL + ', [PwdFormat]'
SET @SQL = @SQL + ', [FullName]'
SET @SQL = @SQL + ', [Phone]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsFirstLoggedIn]'
SET @SQL = @SQL + ', [IsLocked]'
SET @SQL = @SQL + ', [LogInFail]'
SET @SQL = @SQL + ', [LastLoginDate]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[User]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [UserId],'
SET @SQL = @SQL + ' [UserGroupId],'
SET @SQL = @SQL + ' [Email],'
SET @SQL = @SQL + ' [Pwd],'
SET @SQL = @SQL + ' [PwdFormat],'
SET @SQL = @SQL + ' [FullName],'
SET @SQL = @SQL + ' [Phone],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsFirstLoggedIn],'
SET @SQL = @SQL + ' [IsLocked],'
SET @SQL = @SQL + ' [LogInFail],'
SET @SQL = @SQL + ' [LastLoginDate],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[User]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Insert
(
    @UserId int OUTPUT,
    @UserGroupId int,
    @Email varchar(100),
    @Pwd varchar(50),
    @PwdFormat int,
    @FullName nvarchar(200),
    @Phone varchar(100),
    @IsDeletable bit,
    @IsActive bit,
    @IsFirstLoggedIn bit,
    @IsLocked bit,
    @LogInFail int,
    @LastLoginDate datetime,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[User]
(
    [UserGroupId],
    [Email],
    [Pwd],
    [PwdFormat],
    [FullName],
    [Phone],
    [IsDeletable],
    [IsActive],
    [IsFirstLoggedIn],
    [IsLocked],
    [LogInFail],
    [LastLoginDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @UserGroupId,
    @Email,
    @Pwd,
    @PwdFormat,
    @FullName,
    @Phone,
    @IsDeletable,
    @IsActive,
    @IsFirstLoggedIn,
    @IsLocked,
    @LogInFail,
    @LastLoginDate,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @UserId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Update
(
    @UserId int,
    @UserGroupId int,
    @Email varchar(100),
    @Pwd varchar(50),
    @PwdFormat int,
    @FullName nvarchar(200),
    @Phone varchar(100),
    @IsDeletable bit,
    @IsActive bit,
    @IsFirstLoggedIn bit,
    @IsLocked bit,
    @LogInFail int,
    @LastLoginDate datetime,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[User]
SET
    [UserGroupId] = @UserGroupId,
    [Email] = @Email,
    [Pwd] = @Pwd,
    [PwdFormat] = @PwdFormat,
    [FullName] = @FullName,
    [Phone] = @Phone,
    [IsDeletable] = @IsDeletable,
    [IsActive] = @IsActive,
    [IsFirstLoggedIn] = @IsFirstLoggedIn,
    [IsLocked] = @IsLocked,
    [LogInFail] = @LogInFail,
    [LastLoginDate] = @LastLoginDate,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [UserId] = @UserId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the User table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Delete
(
    @UserId int
)
AS


DELETE FROM dbo.[User] WITH (ROWLOCK) 
WHERE
    [UserId] = @UserId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_GetByUserGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_GetByUserGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_GetByUserGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the User table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_GetByUserGroupId
(
    @UserGroupId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [UserId],
    [UserGroupId],
    [Email],
    [Pwd],
    [PwdFormat],
    [FullName],
    [Phone],
    [IsDeletable],
    [IsActive],
    [IsFirstLoggedIn],
    [IsLocked],
    [LogInFail],
    [LastLoginDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[User]
WHERE
    [UserGroupId] = @UserGroupId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the User table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_GetByUserId
(
    @UserId int
)
AS


SELECT
    [UserId],
    [UserGroupId],
    [Email],
    [Pwd],
    [PwdFormat],
    [FullName],
    [Phone],
    [IsDeletable],
    [IsActive],
    [IsFirstLoggedIn],
    [IsLocked],
    [LogInFail],
    [LastLoginDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[User]
WHERE
    [UserId] = @UserId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.User_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.User_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.User_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the User table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.User_Find
(
    @SearchUsingOR bit = null,
    @UserId int = null,
    @UserGroupId int = null,
    @Email varchar(100) = null,
    @Pwd varchar(50) = null,
    @PwdFormat int = null,
    @FullName nvarchar(200) = null,
    @Phone varchar(100) = null,
    @IsDeletable bit = null,
    @IsActive bit = null,
    @IsFirstLoggedIn bit = null,
    @IsLocked bit = null,
    @LogInFail int = null,
    @LastLoginDate datetime = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [UserId], 
        [UserGroupId], 
        [Email], 
        [Pwd], 
        [PwdFormat], 
        [FullName], 
        [Phone], 
        [IsDeletable], 
        [IsActive], 
        [IsFirstLoggedIn], 
        [IsLocked], 
        [LogInFail], 
        [LastLoginDate], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[User]
    WHERE 
     ([UserId] = @UserId OR @UserId is null)
    AND ([UserGroupId] = @UserGroupId OR @UserGroupId is null)
    AND ([Email] = @Email OR @Email is null)
    AND ([Pwd] = @Pwd OR @Pwd is null)
    AND ([PwdFormat] = @PwdFormat OR @PwdFormat is null)
    AND ([FullName] = @FullName OR @FullName is null)
    AND ([Phone] = @Phone OR @Phone is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsFirstLoggedIn] = @IsFirstLoggedIn OR @IsFirstLoggedIn is null)
    AND ([IsLocked] = @IsLocked OR @IsLocked is null)
    AND ([LogInFail] = @LogInFail OR @LogInFail is null)
    AND ([LastLoginDate] = @LastLoginDate OR @LastLoginDate is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [UserId], 
            [UserGroupId], 
            [Email], 
            [Pwd], 
            [PwdFormat], 
            [FullName], 
            [Phone], 
            [IsDeletable], 
            [IsActive], 
            [IsFirstLoggedIn], 
            [IsLocked], 
            [LogInFail], 
            [LastLoginDate], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[User]
        WHERE
     ([UserId] = @UserId AND @UserId is not null)
    OR ([UserGroupId] = @UserGroupId AND @UserGroupId is not null)
    OR ([Email] = @Email AND @Email is not null)
    OR ([Pwd] = @Pwd AND @Pwd is not null)
    OR ([PwdFormat] = @PwdFormat AND @PwdFormat is not null)
    OR ([FullName] = @FullName AND @FullName is not null)
    OR ([Phone] = @Phone AND @Phone is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsFirstLoggedIn] = @IsFirstLoggedIn AND @IsFirstLoggedIn is not null)
    OR ([IsLocked] = @IsLocked AND @IsLocked is not null)
    OR ([LogInFail] = @LogInFail AND @LogInFail is not null)
    OR ([LastLoginDate] = @LastLoginDate AND @LastLoginDate is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AttachFile_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AttachFile_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AttachFile_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the AttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AttachFile_Get_List

AS



SELECT
    [AttachFileId],
    [Name],
    [FilePath],
    [Type],
    [ResourceId],
    [ResourceType],
    [IsActive],
    [Comment],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[AttachFile]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AttachFile_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AttachFile_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AttachFile_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the AttachFile table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AttachFile_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[AttachFileId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [AttachFileId]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [FilePath]'
SET @SQL = @SQL + ', [Type]'
SET @SQL = @SQL + ', [ResourceId]'
SET @SQL = @SQL + ', [ResourceType]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [Comment]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ' FROM dbo.[AttachFile]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [AttachFileId],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [FilePath],'
SET @SQL = @SQL + ' [Type],'
SET @SQL = @SQL + ' [ResourceId],'
SET @SQL = @SQL + ' [ResourceType],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [Comment],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [LastModificationUserId],'
SET @SQL = @SQL + ' [LastModificationDate]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[AttachFile]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AttachFile_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AttachFile_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AttachFile_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the AttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AttachFile_Insert
(
    @AttachFileId int OUTPUT,
    @Name nvarchar(500),
    @FilePath nvarchar(500),
    @Type int,
    @ResourceId int,
    @ResourceType int,
    @IsActive bit,
    @Comment ntext,
    @CreationUserId int,
    @CreationDate datetime,
    @LastModificationUserId int,
    @LastModificationDate datetime
)
AS


					
INSERT INTO dbo.[AttachFile]
(
    [Name],
    [FilePath],
    [Type],
    [ResourceId],
    [ResourceType],
    [IsActive],
    [Comment],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
)
VALUES
(
    @Name,
    @FilePath,
    @Type,
    @ResourceId,
    @ResourceType,
    @IsActive,
    @Comment,
    @CreationUserId,
    @CreationDate,
    @LastModificationUserId,
    @LastModificationDate
)
				
-- Get the identity value
SET @AttachFileId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AttachFile_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AttachFile_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AttachFile_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the AttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AttachFile_Update
(
    @AttachFileId int,
    @Name nvarchar(500),
    @FilePath nvarchar(500),
    @Type int,
    @ResourceId int,
    @ResourceType int,
    @IsActive bit,
    @Comment ntext,
    @CreationUserId int,
    @CreationDate datetime,
    @LastModificationUserId int,
    @LastModificationDate datetime
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[AttachFile]
SET
    [Name] = @Name,
    [FilePath] = @FilePath,
    [Type] = @Type,
    [ResourceId] = @ResourceId,
    [ResourceType] = @ResourceType,
    [IsActive] = @IsActive,
    [Comment] = @Comment,
    [CreationUserId] = @CreationUserId,
    [CreationDate] = @CreationDate,
    [LastModificationUserId] = @LastModificationUserId,
    [LastModificationDate] = @LastModificationDate
WHERE
    [AttachFileId] = @AttachFileId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AttachFile_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AttachFile_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AttachFile_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the AttachFile table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AttachFile_Delete
(
    @AttachFileId int
)
AS


DELETE FROM dbo.[AttachFile] WITH (ROWLOCK) 
WHERE
    [AttachFileId] = @AttachFileId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AttachFile_GetByAttachFileId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AttachFile_GetByAttachFileId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AttachFile_GetByAttachFileId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the AttachFile table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AttachFile_GetByAttachFileId
(
    @AttachFileId int
)
AS


SELECT
    [AttachFileId],
    [Name],
    [FilePath],
    [Type],
    [ResourceId],
    [ResourceType],
    [IsActive],
    [Comment],
    [CreationUserId],
    [CreationDate],
    [LastModificationUserId],
    [LastModificationDate]
FROM
    dbo.[AttachFile]
WHERE
    [AttachFileId] = @AttachFileId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.AttachFile_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.AttachFile_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.AttachFile_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the AttachFile table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.AttachFile_Find
(
    @SearchUsingOR bit = null,
    @AttachFileId int = null,
    @Name nvarchar(500) = null,
    @FilePath nvarchar(500) = null,
    @Type int = null,
    @ResourceId int = null,
    @ResourceType int = null,
    @IsActive bit = null,
    @Comment ntext = null,
    @CreationUserId int = null,
    @CreationDate datetime = null,
    @LastModificationUserId int = null,
    @LastModificationDate datetime = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [AttachFileId], 
        [Name], 
        [FilePath], 
        [Type], 
        [ResourceId], 
        [ResourceType], 
        [IsActive], 
        [Comment], 
        [CreationUserId], 
        [CreationDate], 
        [LastModificationUserId], 
        [LastModificationDate]
    FROM
        dbo.[AttachFile]
    WHERE 
     ([AttachFileId] = @AttachFileId OR @AttachFileId is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([FilePath] = @FilePath OR @FilePath is null)
    AND ([Type] = @Type OR @Type is null)
    AND ([ResourceId] = @ResourceId OR @ResourceId is null)
    AND ([ResourceType] = @ResourceType OR @ResourceType is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
END
ELSE
    BEGIN
        SELECT
            [AttachFileId], 
            [Name], 
            [FilePath], 
            [Type], 
            [ResourceId], 
            [ResourceType], 
            [IsActive], 
            [Comment], 
            [CreationUserId], 
            [CreationDate], 
            [LastModificationUserId], 
            [LastModificationDate]
        FROM
            dbo.[AttachFile]
        WHERE
     ([AttachFileId] = @AttachFileId AND @AttachFileId is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([FilePath] = @FilePath AND @FilePath is not null)
    OR ([Type] = @Type AND @Type is not null)
    OR ([ResourceId] = @ResourceId AND @ResourceId is not null)
    OR ([ResourceType] = @ResourceType AND @ResourceType is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Staff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_Get_List

AS



SELECT
    [StaffId],
    [UserId],
    [Code],
    [FirstName],
    [LastName],
    [MiddleName]
FROM
    dbo.[Staff]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Staff table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[StaffId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [StaffId]'
SET @SQL = @SQL + ', [UserId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [FirstName]'
SET @SQL = @SQL + ', [LastName]'
SET @SQL = @SQL + ', [MiddleName]'
SET @SQL = @SQL + ' FROM dbo.[Staff]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [StaffId],'
SET @SQL = @SQL + ' [UserId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [FirstName],'
SET @SQL = @SQL + ' [LastName],'
SET @SQL = @SQL + ' [MiddleName]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Staff]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Staff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_Insert
(
    @StaffId int OUTPUT,
    @UserId int,
    @Code nchar(10),
    @FirstName nchar(10),
    @LastName nchar(10),
    @MiddleName nchar(10)
)
AS


					
INSERT INTO dbo.[Staff]
(
    [UserId],
    [Code],
    [FirstName],
    [LastName],
    [MiddleName]
)
VALUES
(
    @UserId,
    @Code,
    @FirstName,
    @LastName,
    @MiddleName
)
				
-- Get the identity value
SET @StaffId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Staff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_Update
(
    @StaffId int,
    @UserId int,
    @Code nchar(10),
    @FirstName nchar(10),
    @LastName nchar(10),
    @MiddleName nchar(10)
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Staff]
SET
    [UserId] = @UserId,
    [Code] = @Code,
    [FirstName] = @FirstName,
    [LastName] = @LastName,
    [MiddleName] = @MiddleName
WHERE
    [StaffId] = @StaffId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Staff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_Delete
(
    @StaffId int
)
AS


DELETE FROM dbo.[Staff] WITH (ROWLOCK) 
WHERE
    [StaffId] = @StaffId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_GetByUserId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_GetByUserId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_GetByUserId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Staff table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_GetByUserId
(
    @UserId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [StaffId],
    [UserId],
    [Code],
    [FirstName],
    [LastName],
    [MiddleName]
FROM
    dbo.[Staff]
WHERE
    [UserId] = @UserId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_GetByStaffId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_GetByStaffId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_GetByStaffId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Staff table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_GetByStaffId
(
    @StaffId int
)
AS


SELECT
    [StaffId],
    [UserId],
    [Code],
    [FirstName],
    [LastName],
    [MiddleName]
FROM
    dbo.[Staff]
WHERE
    [StaffId] = @StaffId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Staff_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Staff_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Staff_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Staff table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Staff_Find
(
    @SearchUsingOR bit = null,
    @StaffId int = null,
    @UserId int = null,
    @Code nchar(10) = null,
    @FirstName nchar(10) = null,
    @LastName nchar(10) = null,
    @MiddleName nchar(10) = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [StaffId], 
        [UserId], 
        [Code], 
        [FirstName], 
        [LastName], 
        [MiddleName]
    FROM
        dbo.[Staff]
    WHERE 
     ([StaffId] = @StaffId OR @StaffId is null)
    AND ([UserId] = @UserId OR @UserId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([FirstName] = @FirstName OR @FirstName is null)
    AND ([LastName] = @LastName OR @LastName is null)
    AND ([MiddleName] = @MiddleName OR @MiddleName is null)
END
ELSE
    BEGIN
        SELECT
            [StaffId], 
            [UserId], 
            [Code], 
            [FirstName], 
            [LastName], 
            [MiddleName]
        FROM
            dbo.[Staff]
        WHERE
     ([StaffId] = @StaffId AND @StaffId is not null)
    OR ([UserId] = @UserId AND @UserId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([FirstName] = @FirstName AND @FirstName is not null)
    OR ([LastName] = @LastName AND @LastName is not null)
    OR ([MiddleName] = @MiddleName AND @MiddleName is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the RoleOfStaff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_Get_List

AS



SELECT
    [RoleOfStaffId],
    [StaffId],
    [RoleId],
    [ResourceId],
    [ResourceType],
    [IsApprove],
    [IsActive],
    [Status],
    [FromDate],
    [ToDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[RoleOfStaff]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the RoleOfStaff table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[RoleOfStaffId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [RoleOfStaffId]'
SET @SQL = @SQL + ', [StaffId]'
SET @SQL = @SQL + ', [RoleId]'
SET @SQL = @SQL + ', [ResourceId]'
SET @SQL = @SQL + ', [ResourceType]'
SET @SQL = @SQL + ', [IsApprove]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [Status]'
SET @SQL = @SQL + ', [FromDate]'
SET @SQL = @SQL + ', [ToDate]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[RoleOfStaff]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [RoleOfStaffId],'
SET @SQL = @SQL + ' [StaffId],'
SET @SQL = @SQL + ' [RoleId],'
SET @SQL = @SQL + ' [ResourceId],'
SET @SQL = @SQL + ' [ResourceType],'
SET @SQL = @SQL + ' [IsApprove],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [Status],'
SET @SQL = @SQL + ' [FromDate],'
SET @SQL = @SQL + ' [ToDate],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[RoleOfStaff]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the RoleOfStaff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_Insert
(
    @RoleOfStaffId int,
    @StaffId int,
    @RoleId int,
    @ResourceId int,
    @ResourceType int,
    @IsApprove bigint,
    @IsActive bit,
    @Status int,
    @FromDate datetime,
    @ToDate datetime,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[RoleOfStaff]
(
    [RoleOfStaffId],
    [StaffId],
    [RoleId],
    [ResourceId],
    [ResourceType],
    [IsApprove],
    [IsActive],
    [Status],
    [FromDate],
    [ToDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @RoleOfStaffId,
    @StaffId,
    @RoleId,
    @ResourceId,
    @ResourceType,
    @IsApprove,
    @IsActive,
    @Status,
    @FromDate,
    @ToDate,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the RoleOfStaff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_Update
(
    @RoleOfStaffId int,
    @OriginalRoleOfStaffId int,
    @StaffId int,
    @RoleId int,
    @ResourceId int,
    @ResourceType int,
    @IsApprove bigint,
    @IsActive bit,
    @Status int,
    @FromDate datetime,
    @ToDate datetime,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[RoleOfStaff]
SET
    [RoleOfStaffId] = @RoleOfStaffId,
    [StaffId] = @StaffId,
    [RoleId] = @RoleId,
    [ResourceId] = @ResourceId,
    [ResourceType] = @ResourceType,
    [IsApprove] = @IsApprove,
    [IsActive] = @IsActive,
    [Status] = @Status,
    [FromDate] = @FromDate,
    [ToDate] = @ToDate,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [RoleOfStaffId] = @OriginalRoleOfStaffId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the RoleOfStaff table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_Delete
(
    @RoleOfStaffId int
)
AS


DELETE FROM dbo.[RoleOfStaff] WITH (ROWLOCK) 
WHERE
    [RoleOfStaffId] = @RoleOfStaffId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_GetByRoleId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_GetByRoleId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_GetByRoleId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the RoleOfStaff table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_GetByRoleId
(
    @RoleId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [RoleOfStaffId],
    [StaffId],
    [RoleId],
    [ResourceId],
    [ResourceType],
    [IsApprove],
    [IsActive],
    [Status],
    [FromDate],
    [ToDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[RoleOfStaff]
WHERE
    [RoleId] = @RoleId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_GetByStaffId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_GetByStaffId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_GetByStaffId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the RoleOfStaff table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_GetByStaffId
(
    @StaffId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [RoleOfStaffId],
    [StaffId],
    [RoleId],
    [ResourceId],
    [ResourceType],
    [IsApprove],
    [IsActive],
    [Status],
    [FromDate],
    [ToDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[RoleOfStaff]
WHERE
    [StaffId] = @StaffId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_GetByRoleOfStaffId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_GetByRoleOfStaffId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_GetByRoleOfStaffId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the RoleOfStaff table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_GetByRoleOfStaffId
(
    @RoleOfStaffId int
)
AS


SELECT
    [RoleOfStaffId],
    [StaffId],
    [RoleId],
    [ResourceId],
    [ResourceType],
    [IsApprove],
    [IsActive],
    [Status],
    [FromDate],
    [ToDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[RoleOfStaff]
WHERE
    [RoleOfStaffId] = @RoleOfStaffId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.RoleOfStaff_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.RoleOfStaff_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.RoleOfStaff_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the RoleOfStaff table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.RoleOfStaff_Find
(
    @SearchUsingOR bit = null,
    @RoleOfStaffId int = null,
    @StaffId int = null,
    @RoleId int = null,
    @ResourceId int = null,
    @ResourceType int = null,
    @IsApprove bigint = null,
    @IsActive bit = null,
    @Status int = null,
    @FromDate datetime = null,
    @ToDate datetime = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [RoleOfStaffId], 
        [StaffId], 
        [RoleId], 
        [ResourceId], 
        [ResourceType], 
        [IsApprove], 
        [IsActive], 
        [Status], 
        [FromDate], 
        [ToDate], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[RoleOfStaff]
    WHERE 
     ([RoleOfStaffId] = @RoleOfStaffId OR @RoleOfStaffId is null)
    AND ([StaffId] = @StaffId OR @StaffId is null)
    AND ([RoleId] = @RoleId OR @RoleId is null)
    AND ([ResourceId] = @ResourceId OR @ResourceId is null)
    AND ([ResourceType] = @ResourceType OR @ResourceType is null)
    AND ([IsApprove] = @IsApprove OR @IsApprove is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([Status] = @Status OR @Status is null)
    AND ([FromDate] = @FromDate OR @FromDate is null)
    AND ([ToDate] = @ToDate OR @ToDate is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [RoleOfStaffId], 
            [StaffId], 
            [RoleId], 
            [ResourceId], 
            [ResourceType], 
            [IsApprove], 
            [IsActive], 
            [Status], 
            [FromDate], 
            [ToDate], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[RoleOfStaff]
        WHERE
     ([RoleOfStaffId] = @RoleOfStaffId AND @RoleOfStaffId is not null)
    OR ([StaffId] = @StaffId AND @StaffId is not null)
    OR ([RoleId] = @RoleId AND @RoleId is not null)
    OR ([ResourceId] = @ResourceId AND @ResourceId is not null)
    OR ([ResourceType] = @ResourceType AND @ResourceType is not null)
    OR ([IsApprove] = @IsApprove AND @IsApprove is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([Status] = @Status AND @Status is not null)
    OR ([FromDate] = @FromDate AND @FromDate is not null)
    OR ([ToDate] = @ToDate AND @ToDate is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Get_List

AS



SELECT
    [UnitId],
    [Name],
    [Description],
    [IsActive],
    [IsDeletable],
    [Priority],
    [IsBaseUnit],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Unit]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Unit table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[UnitId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [UnitId]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [Description]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsDeletable]'
SET @SQL = @SQL + ', [Priority]'
SET @SQL = @SQL + ', [IsBaseUnit]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Unit]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [UnitId],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [Description],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsDeletable],'
SET @SQL = @SQL + ' [Priority],'
SET @SQL = @SQL + ' [IsBaseUnit],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Unit]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Insert
(
    @UnitId int OUTPUT,
    @Name nvarchar(300),
    @Description ntext,
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @IsBaseUnit bit,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Unit]
(
    [Name],
    [Description],
    [IsActive],
    [IsDeletable],
    [Priority],
    [IsBaseUnit],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @Name,
    @Description,
    @IsActive,
    @IsDeletable,
    @Priority,
    @IsBaseUnit,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @UnitId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Update
(
    @UnitId int,
    @Name nvarchar(300),
    @Description ntext,
    @IsActive bit,
    @IsDeletable bit,
    @Priority int,
    @IsBaseUnit bit,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Unit]
SET
    [Name] = @Name,
    [Description] = @Description,
    [IsActive] = @IsActive,
    [IsDeletable] = @IsDeletable,
    [Priority] = @Priority,
    [IsBaseUnit] = @IsBaseUnit,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [UnitId] = @UnitId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Unit table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Delete
(
    @UnitId int
)
AS


DELETE FROM dbo.[Unit] WITH (ROWLOCK) 
WHERE
    [UnitId] = @UnitId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_GetByUnitId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_GetByUnitId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_GetByUnitId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Unit table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_GetByUnitId
(
    @UnitId int
)
AS


SELECT
    [UnitId],
    [Name],
    [Description],
    [IsActive],
    [IsDeletable],
    [Priority],
    [IsBaseUnit],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Unit]
WHERE
    [UnitId] = @UnitId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_GetByToUnitIdFromUnitConvertor procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_GetByToUnitIdFromUnitConvertor') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_GetByToUnitIdFromUnitConvertor
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_GetByToUnitIdFromUnitConvertor
(
    @ToUnitId int
)
AS


SELECT dbo.[Unit].[UnitId]
       ,dbo.[Unit].[Name]
       ,dbo.[Unit].[Description]
       ,dbo.[Unit].[IsActive]
       ,dbo.[Unit].[IsDeletable]
       ,dbo.[Unit].[Priority]
       ,dbo.[Unit].[IsBaseUnit]
       ,dbo.[Unit].[CreationDate]
       ,dbo.[Unit].[CreationUserId]
       ,dbo.[Unit].[LastModificationDate]
       ,dbo.[Unit].[LastModificationUserId]
  FROM dbo.[Unit]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[UnitConvertor] 
                WHERE dbo.[UnitConvertor].[ToUnitId] = @ToUnitId
                  AND dbo.[UnitConvertor].[FromUnitId] = dbo.[Unit].[UnitId]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_GetByFromUnitIdFromUnitConvertor procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_GetByFromUnitIdFromUnitConvertor') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_GetByFromUnitIdFromUnitConvertor
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records through a junction table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_GetByFromUnitIdFromUnitConvertor
(
    @FromUnitId int
)
AS


SELECT dbo.[Unit].[UnitId]
       ,dbo.[Unit].[Name]
       ,dbo.[Unit].[Description]
       ,dbo.[Unit].[IsActive]
       ,dbo.[Unit].[IsDeletable]
       ,dbo.[Unit].[Priority]
       ,dbo.[Unit].[IsBaseUnit]
       ,dbo.[Unit].[CreationDate]
       ,dbo.[Unit].[CreationUserId]
       ,dbo.[Unit].[LastModificationDate]
       ,dbo.[Unit].[LastModificationUserId]
  FROM dbo.[Unit]
 WHERE EXISTS (SELECT 1
                 FROM dbo.[UnitConvertor] 
                WHERE dbo.[UnitConvertor].[FromUnitId] = @FromUnitId
                  AND dbo.[UnitConvertor].[ToUnitId] = dbo.[Unit].[UnitId]
                  )
				Select @@ROWCOUNT			
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Unit_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Unit_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Unit_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Unit table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Unit_Find
(
    @SearchUsingOR bit = null,
    @UnitId int = null,
    @Name nvarchar(300) = null,
    @Description ntext = null,
    @IsActive bit = null,
    @IsDeletable bit = null,
    @Priority int = null,
    @IsBaseUnit bit = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [UnitId], 
        [Name], 
        [Description], 
        [IsActive], 
        [IsDeletable], 
        [Priority], 
        [IsBaseUnit], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[Unit]
    WHERE 
     ([UnitId] = @UnitId OR @UnitId is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsDeletable] = @IsDeletable OR @IsDeletable is null)
    AND ([Priority] = @Priority OR @Priority is null)
    AND ([IsBaseUnit] = @IsBaseUnit OR @IsBaseUnit is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [UnitId], 
            [Name], 
            [Description], 
            [IsActive], 
            [IsDeletable], 
            [Priority], 
            [IsBaseUnit], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[Unit]
        WHERE
     ([UnitId] = @UnitId AND @UnitId is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsDeletable] = @IsDeletable AND @IsDeletable is not null)
    OR ([Priority] = @Priority AND @Priority is not null)
    OR ([IsBaseUnit] = @IsBaseUnit AND @IsBaseUnit is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the Project table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_Get_List

AS



SELECT
    [ProjectId],
    [GroupId],
    [ContractId],
    [Code],
    [Name],
    [DesignedPrice],
    [FinalPrice],
    [IsActive],
    [IsApprove],
    [Status],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Project]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the Project table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[ProjectId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [ProjectId]'
SET @SQL = @SQL + ', [GroupId]'
SET @SQL = @SQL + ', [ContractId]'
SET @SQL = @SQL + ', [Code]'
SET @SQL = @SQL + ', [Name]'
SET @SQL = @SQL + ', [DesignedPrice]'
SET @SQL = @SQL + ', [FinalPrice]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsApprove]'
SET @SQL = @SQL + ', [Status]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[Project]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [ProjectId],'
SET @SQL = @SQL + ' [GroupId],'
SET @SQL = @SQL + ' [ContractId],'
SET @SQL = @SQL + ' [Code],'
SET @SQL = @SQL + ' [Name],'
SET @SQL = @SQL + ' [DesignedPrice],'
SET @SQL = @SQL + ' [FinalPrice],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsApprove],'
SET @SQL = @SQL + ' [Status],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[Project]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the Project table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_Insert
(
    @ProjectId int,
    @GroupId int,
    @ContractId int,
    @Code nvarchar(100),
    @Name nvarchar(500),
    @DesignedPrice money,
    @FinalPrice money,
    @IsActive bigint,
    @IsApprove bigint,
    @Status int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[Project]
(
    [ProjectId],
    [GroupId],
    [ContractId],
    [Code],
    [Name],
    [DesignedPrice],
    [FinalPrice],
    [IsActive],
    [IsApprove],
    [Status],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @ProjectId,
    @GroupId,
    @ContractId,
    @Code,
    @Name,
    @DesignedPrice,
    @FinalPrice,
    @IsActive,
    @IsApprove,
    @Status,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the Project table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_Update
(
    @ProjectId int,
    @OriginalProjectId int,
    @GroupId int,
    @ContractId int,
    @Code nvarchar(100),
    @Name nvarchar(500),
    @DesignedPrice money,
    @FinalPrice money,
    @IsActive bigint,
    @IsApprove bigint,
    @Status int,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[Project]
SET
    [ProjectId] = @ProjectId,
    [GroupId] = @GroupId,
    [ContractId] = @ContractId,
    [Code] = @Code,
    [Name] = @Name,
    [DesignedPrice] = @DesignedPrice,
    [FinalPrice] = @FinalPrice,
    [IsActive] = @IsActive,
    [IsApprove] = @IsApprove,
    [Status] = @Status,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [ProjectId] = @OriginalProjectId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the Project table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_Delete
(
    @ProjectId int
)
AS


DELETE FROM dbo.[Project] WITH (ROWLOCK) 
WHERE
    [ProjectId] = @ProjectId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_GetByContractId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_GetByContractId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_GetByContractId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Project table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_GetByContractId
(
    @ContractId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ProjectId],
    [GroupId],
    [ContractId],
    [Code],
    [Name],
    [DesignedPrice],
    [FinalPrice],
    [IsActive],
    [IsApprove],
    [Status],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Project]
WHERE
    [ContractId] = @ContractId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_GetByGroupId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_GetByGroupId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_GetByGroupId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Project table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_GetByGroupId
(
    @GroupId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [ProjectId],
    [GroupId],
    [ContractId],
    [Code],
    [Name],
    [DesignedPrice],
    [FinalPrice],
    [IsActive],
    [IsApprove],
    [Status],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Project]
WHERE
    [GroupId] = @GroupId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_GetByProjectId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_GetByProjectId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_GetByProjectId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the Project table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_GetByProjectId
(
    @ProjectId int
)
AS


SELECT
    [ProjectId],
    [GroupId],
    [ContractId],
    [Code],
    [Name],
    [DesignedPrice],
    [FinalPrice],
    [IsActive],
    [IsApprove],
    [Status],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[Project]
WHERE
    [ProjectId] = @ProjectId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Project_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Project_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Project_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the Project table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Project_Find
(
    @SearchUsingOR bit = null,
    @ProjectId int = null,
    @GroupId int = null,
    @ContractId int = null,
    @Code nvarchar(100) = null,
    @Name nvarchar(500) = null,
    @DesignedPrice money = null,
    @FinalPrice money = null,
    @IsActive bigint = null,
    @IsApprove bigint = null,
    @Status int = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [ProjectId], 
        [GroupId], 
        [ContractId], 
        [Code], 
        [Name], 
        [DesignedPrice], 
        [FinalPrice], 
        [IsActive], 
        [IsApprove], 
        [Status], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[Project]
    WHERE 
     ([ProjectId] = @ProjectId OR @ProjectId is null)
    AND ([GroupId] = @GroupId OR @GroupId is null)
    AND ([ContractId] = @ContractId OR @ContractId is null)
    AND ([Code] = @Code OR @Code is null)
    AND ([Name] = @Name OR @Name is null)
    AND ([DesignedPrice] = @DesignedPrice OR @DesignedPrice is null)
    AND ([FinalPrice] = @FinalPrice OR @FinalPrice is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsApprove] = @IsApprove OR @IsApprove is null)
    AND ([Status] = @Status OR @Status is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [ProjectId], 
            [GroupId], 
            [ContractId], 
            [Code], 
            [Name], 
            [DesignedPrice], 
            [FinalPrice], 
            [IsActive], 
            [IsApprove], 
            [Status], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[Project]
        WHERE
     ([ProjectId] = @ProjectId AND @ProjectId is not null)
    OR ([GroupId] = @GroupId AND @GroupId is not null)
    OR ([ContractId] = @ContractId AND @ContractId is not null)
    OR ([Code] = @Code AND @Code is not null)
    OR ([Name] = @Name AND @Name is not null)
    OR ([DesignedPrice] = @DesignedPrice AND @DesignedPrice is not null)
    OR ([FinalPrice] = @FinalPrice AND @FinalPrice is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsApprove] = @IsApprove AND @IsApprove is not null)
    OR ([Status] = @Status AND @Status is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_Get_List
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets all records from the ItemMovement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_Get_List

AS



SELECT
    [RepositoryMovementId],
    [ItemId],
    [FromRepositoryId],
    [ToRepositoryId],
    [FromRepositoryManagerId],
    [ToRepositoryManagerId],
    [StranferUserId],
    [ReceiverUserId],
    [UnitPrice],
    [TotalQuantity],
    [TotalAmount],
    [Status],
    [IsActive],
    [IsApprove],
    [DeliveryDate],
    [ReceivedDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemMovement]
					
Select @@ROWCOUNT


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Gets records from the ItemMovement table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_GetPaged
(
    @WhereClause varchar(2000),
    @OrderBy varchar(2000),
    @PageIndex int,
    @PageSize int
)
AS



BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
				
-- Set the page bounds
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize

IF (@OrderBy is null or LEN(@OrderBy) < 1)
BEGIN
    -- default order by to first column
    SET @OrderBy = '[RepositoryMovementId]'
END

-- SQL Server 2005 Paging
declare @SQL as nvarchar(4000)
SET @SQL = 'WITH PageIndex AS ('
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
END
SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
SET @SQL = @SQL + ', [RepositoryMovementId]'
SET @SQL = @SQL + ', [ItemId]'
SET @SQL = @SQL + ', [FromRepositoryId]'
SET @SQL = @SQL + ', [ToRepositoryId]'
SET @SQL = @SQL + ', [FromRepositoryManagerId]'
SET @SQL = @SQL + ', [ToRepositoryManagerId]'
SET @SQL = @SQL + ', [StranferUserId]'
SET @SQL = @SQL + ', [ReceiverUserId]'
SET @SQL = @SQL + ', [UnitPrice]'
SET @SQL = @SQL + ', [TotalQuantity]'
SET @SQL = @SQL + ', [TotalAmount]'
SET @SQL = @SQL + ', [Status]'
SET @SQL = @SQL + ', [IsActive]'
SET @SQL = @SQL + ', [IsApprove]'
SET @SQL = @SQL + ', [DeliveryDate]'
SET @SQL = @SQL + ', [ReceivedDate]'
SET @SQL = @SQL + ', [CreationDate]'
SET @SQL = @SQL + ', [CreationUserId]'
SET @SQL = @SQL + ', [LastModificationDate]'
SET @SQL = @SQL + ', [LastModificationUserId]'
SET @SQL = @SQL + ' FROM dbo.[ItemMovement]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
SET @SQL = @SQL + ' ) SELECT'
SET @SQL = @SQL + ' [RepositoryMovementId],'
SET @SQL = @SQL + ' [ItemId],'
SET @SQL = @SQL + ' [FromRepositoryId],'
SET @SQL = @SQL + ' [ToRepositoryId],'
SET @SQL = @SQL + ' [FromRepositoryManagerId],'
SET @SQL = @SQL + ' [ToRepositoryManagerId],'
SET @SQL = @SQL + ' [StranferUserId],'
SET @SQL = @SQL + ' [ReceiverUserId],'
SET @SQL = @SQL + ' [UnitPrice],'
SET @SQL = @SQL + ' [TotalQuantity],'
SET @SQL = @SQL + ' [TotalAmount],'
SET @SQL = @SQL + ' [Status],'
SET @SQL = @SQL + ' [IsActive],'
SET @SQL = @SQL + ' [IsApprove],'
SET @SQL = @SQL + ' [DeliveryDate],'
SET @SQL = @SQL + ' [ReceivedDate],'
SET @SQL = @SQL + ' [CreationDate],'
SET @SQL = @SQL + ' [CreationUserId],'
SET @SQL = @SQL + ' [LastModificationDate],'
SET @SQL = @SQL + ' [LastModificationUserId]'
SET @SQL = @SQL + ' FROM PageIndex'
SET @SQL = @SQL + ' WHERE RowIndex > ' + convert(nvarchar, @PageLowerBound)
IF @PageSize > 0
BEGIN
    SET @SQL = @SQL + ' AND RowIndex <= ' + convert(nvarchar, @PageUpperBound)
END
exec sp_executesql @SQL
				
-- get row count
SET @SQL = 'SELECT COUNT(*) as TotalRowCount'
SET @SQL = @SQL + ' FROM dbo.[ItemMovement]'
IF LEN(@WhereClause) > 0
BEGIN
    SET @SQL = @SQL + ' WHERE ' + @WhereClause
END
exec sp_executesql @SQL
			
END


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_Insert
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Inserts a record into the ItemMovement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_Insert
(
    @RepositoryMovementId int OUTPUT,
    @ItemId bigint,
    @FromRepositoryId int,
    @ToRepositoryId int,
    @FromRepositoryManagerId int,
    @ToRepositoryManagerId int,
    @StranferUserId int,
    @ReceiverUserId int,
    @UnitPrice money,
    @TotalQuantity bigint,
    @TotalAmount money,
    @Status int,
    @IsActive bigint,
    @IsApprove bit,
    @DeliveryDate datetime,
    @ReceivedDate datetime,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS


					
INSERT INTO dbo.[ItemMovement]
(
    [ItemId],
    [FromRepositoryId],
    [ToRepositoryId],
    [FromRepositoryManagerId],
    [ToRepositoryManagerId],
    [StranferUserId],
    [ReceiverUserId],
    [UnitPrice],
    [TotalQuantity],
    [TotalAmount],
    [Status],
    [IsActive],
    [IsApprove],
    [DeliveryDate],
    [ReceivedDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
)
VALUES
(
    @ItemId,
    @FromRepositoryId,
    @ToRepositoryId,
    @FromRepositoryManagerId,
    @ToRepositoryManagerId,
    @StranferUserId,
    @ReceiverUserId,
    @UnitPrice,
    @TotalQuantity,
    @TotalAmount,
    @Status,
    @IsActive,
    @IsApprove,
    @DeliveryDate,
    @ReceivedDate,
    @CreationDate,
    @CreationUserId,
    @LastModificationDate,
    @LastModificationUserId
)
				
-- Get the identity value
SET @RepositoryMovementId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_Update
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Updates a record in the ItemMovement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_Update
(
    @RepositoryMovementId int,
    @ItemId bigint,
    @FromRepositoryId int,
    @ToRepositoryId int,
    @FromRepositoryManagerId int,
    @ToRepositoryManagerId int,
    @StranferUserId int,
    @ReceiverUserId int,
    @UnitPrice money,
    @TotalQuantity bigint,
    @TotalAmount money,
    @Status int,
    @IsActive bigint,
    @IsApprove bit,
    @DeliveryDate datetime,
    @ReceivedDate datetime,
    @CreationDate datetime,
    @CreationUserId int,
    @LastModificationDate datetime,
    @LastModificationUserId int
)
AS



				
-- Modify the updatable columns
UPDATE
    dbo.[ItemMovement]
SET
    [ItemId] = @ItemId,
    [FromRepositoryId] = @FromRepositoryId,
    [ToRepositoryId] = @ToRepositoryId,
    [FromRepositoryManagerId] = @FromRepositoryManagerId,
    [ToRepositoryManagerId] = @ToRepositoryManagerId,
    [StranferUserId] = @StranferUserId,
    [ReceiverUserId] = @ReceiverUserId,
    [UnitPrice] = @UnitPrice,
    [TotalQuantity] = @TotalQuantity,
    [TotalAmount] = @TotalAmount,
    [Status] = @Status,
    [IsActive] = @IsActive,
    [IsApprove] = @IsApprove,
    [DeliveryDate] = @DeliveryDate,
    [ReceivedDate] = @ReceivedDate,
    [CreationDate] = @CreationDate,
    [CreationUserId] = @CreationUserId,
    [LastModificationDate] = @LastModificationDate,
    [LastModificationUserId] = @LastModificationUserId
WHERE
    [RepositoryMovementId] = @RepositoryMovementId 

				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_Delete
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Deletes a record in the ItemMovement table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_Delete
(
    @RepositoryMovementId int
)
AS


DELETE FROM dbo.[ItemMovement] WITH (ROWLOCK) 
WHERE
    [RepositoryMovementId] = @RepositoryMovementId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemMovement table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_GetByItemId
(
    @ItemId bigint
)
AS


SET ANSI_NULLS OFF

SELECT
    [RepositoryMovementId],
    [ItemId],
    [FromRepositoryId],
    [ToRepositoryId],
    [FromRepositoryManagerId],
    [ToRepositoryManagerId],
    [StranferUserId],
    [ReceiverUserId],
    [UnitPrice],
    [TotalQuantity],
    [TotalAmount],
    [Status],
    [IsActive],
    [IsApprove],
    [DeliveryDate],
    [ReceivedDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemMovement]
WHERE
    [ItemId] = @ItemId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_GetByFromRepositoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_GetByFromRepositoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_GetByFromRepositoryId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemMovement table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_GetByFromRepositoryId
(
    @FromRepositoryId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [RepositoryMovementId],
    [ItemId],
    [FromRepositoryId],
    [ToRepositoryId],
    [FromRepositoryManagerId],
    [ToRepositoryManagerId],
    [StranferUserId],
    [ReceiverUserId],
    [UnitPrice],
    [TotalQuantity],
    [TotalAmount],
    [Status],
    [IsActive],
    [IsApprove],
    [DeliveryDate],
    [ReceivedDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemMovement]
WHERE
    [FromRepositoryId] = @FromRepositoryId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_GetByToRepositoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_GetByToRepositoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_GetByToRepositoryId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemMovement table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_GetByToRepositoryId
(
    @ToRepositoryId int
)
AS


SET ANSI_NULLS OFF

SELECT
    [RepositoryMovementId],
    [ItemId],
    [FromRepositoryId],
    [ToRepositoryId],
    [FromRepositoryManagerId],
    [ToRepositoryManagerId],
    [StranferUserId],
    [ReceiverUserId],
    [UnitPrice],
    [TotalQuantity],
    [TotalAmount],
    [Status],
    [IsActive],
    [IsApprove],
    [DeliveryDate],
    [ReceivedDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemMovement]
WHERE
    [ToRepositoryId] = @ToRepositoryId
				
Select @@ROWCOUNT
SET ANSI_NULLS ON


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_GetByRepositoryMovementId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_GetByRepositoryMovementId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_GetByRepositoryMovementId
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Select records from the ItemMovement table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_GetByRepositoryMovementId
(
    @RepositoryMovementId int
)
AS


SELECT
    [RepositoryMovementId],
    [ItemId],
    [FromRepositoryId],
    [ToRepositoryId],
    [FromRepositoryManagerId],
    [ToRepositoryManagerId],
    [StranferUserId],
    [ReceiverUserId],
    [UnitPrice],
    [TotalQuantity],
    [TotalAmount],
    [Status],
    [IsActive],
    [IsApprove],
    [DeliveryDate],
    [ReceivedDate],
    [CreationDate],
    [CreationUserId],
    [LastModificationDate],
    [LastModificationUserId]
FROM
    dbo.[ItemMovement]
WHERE
    [RepositoryMovementId] = @RepositoryMovementId
Select @@ROWCOUNT
					


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemMovement_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemMovement_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemMovement_Find
GO

/*
----------------------------------------------------------------------------------------------------
-- Date Created: Thursday, November 18, 2010

-- Created By:  ()
-- Purpose: Finds records in the ItemMovement table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemMovement_Find
(
    @SearchUsingOR bit = null,
    @RepositoryMovementId int = null,
    @ItemId bigint = null,
    @FromRepositoryId int = null,
    @ToRepositoryId int = null,
    @FromRepositoryManagerId int = null,
    @ToRepositoryManagerId int = null,
    @StranferUserId int = null,
    @ReceiverUserId int = null,
    @UnitPrice money = null,
    @TotalQuantity bigint = null,
    @TotalAmount money = null,
    @Status int = null,
    @IsActive bigint = null,
    @IsApprove bit = null,
    @DeliveryDate datetime = null,
    @ReceivedDate datetime = null,
    @CreationDate datetime = null,
    @CreationUserId int = null,
    @LastModificationDate datetime = null,
    @LastModificationUserId int = null
)
AS



IF ISNULL(@SearchUsingOR, 0) <> 1
BEGIN
    SELECT
        [RepositoryMovementId], 
        [ItemId], 
        [FromRepositoryId], 
        [ToRepositoryId], 
        [FromRepositoryManagerId], 
        [ToRepositoryManagerId], 
        [StranferUserId], 
        [ReceiverUserId], 
        [UnitPrice], 
        [TotalQuantity], 
        [TotalAmount], 
        [Status], 
        [IsActive], 
        [IsApprove], 
        [DeliveryDate], 
        [ReceivedDate], 
        [CreationDate], 
        [CreationUserId], 
        [LastModificationDate], 
        [LastModificationUserId]
    FROM
        dbo.[ItemMovement]
    WHERE 
     ([RepositoryMovementId] = @RepositoryMovementId OR @RepositoryMovementId is null)
    AND ([ItemId] = @ItemId OR @ItemId is null)
    AND ([FromRepositoryId] = @FromRepositoryId OR @FromRepositoryId is null)
    AND ([ToRepositoryId] = @ToRepositoryId OR @ToRepositoryId is null)
    AND ([FromRepositoryManagerId] = @FromRepositoryManagerId OR @FromRepositoryManagerId is null)
    AND ([ToRepositoryManagerId] = @ToRepositoryManagerId OR @ToRepositoryManagerId is null)
    AND ([StranferUserId] = @StranferUserId OR @StranferUserId is null)
    AND ([ReceiverUserId] = @ReceiverUserId OR @ReceiverUserId is null)
    AND ([UnitPrice] = @UnitPrice OR @UnitPrice is null)
    AND ([TotalQuantity] = @TotalQuantity OR @TotalQuantity is null)
    AND ([TotalAmount] = @TotalAmount OR @TotalAmount is null)
    AND ([Status] = @Status OR @Status is null)
    AND ([IsActive] = @IsActive OR @IsActive is null)
    AND ([IsApprove] = @IsApprove OR @IsApprove is null)
    AND ([DeliveryDate] = @DeliveryDate OR @DeliveryDate is null)
    AND ([ReceivedDate] = @ReceivedDate OR @ReceivedDate is null)
    AND ([CreationDate] = @CreationDate OR @CreationDate is null)
    AND ([CreationUserId] = @CreationUserId OR @CreationUserId is null)
    AND ([LastModificationDate] = @LastModificationDate OR @LastModificationDate is null)
    AND ([LastModificationUserId] = @LastModificationUserId OR @LastModificationUserId is null)
END
ELSE
    BEGIN
        SELECT
            [RepositoryMovementId], 
            [ItemId], 
            [FromRepositoryId], 
            [ToRepositoryId], 
            [FromRepositoryManagerId], 
            [ToRepositoryManagerId], 
            [StranferUserId], 
            [ReceiverUserId], 
            [UnitPrice], 
            [TotalQuantity], 
            [TotalAmount], 
            [Status], 
            [IsActive], 
            [IsApprove], 
            [DeliveryDate], 
            [ReceivedDate], 
            [CreationDate], 
            [CreationUserId], 
            [LastModificationDate], 
            [LastModificationUserId]
        FROM
            dbo.[ItemMovement]
        WHERE
     ([RepositoryMovementId] = @RepositoryMovementId AND @RepositoryMovementId is not null)
    OR ([ItemId] = @ItemId AND @ItemId is not null)
    OR ([FromRepositoryId] = @FromRepositoryId AND @FromRepositoryId is not null)
    OR ([ToRepositoryId] = @ToRepositoryId AND @ToRepositoryId is not null)
    OR ([FromRepositoryManagerId] = @FromRepositoryManagerId AND @FromRepositoryManagerId is not null)
    OR ([ToRepositoryManagerId] = @ToRepositoryManagerId AND @ToRepositoryManagerId is not null)
    OR ([StranferUserId] = @StranferUserId AND @StranferUserId is not null)
    OR ([ReceiverUserId] = @ReceiverUserId AND @ReceiverUserId is not null)
    OR ([UnitPrice] = @UnitPrice AND @UnitPrice is not null)
    OR ([TotalQuantity] = @TotalQuantity AND @TotalQuantity is not null)
    OR ([TotalAmount] = @TotalAmount AND @TotalAmount is not null)
    OR ([Status] = @Status AND @Status is not null)
    OR ([IsActive] = @IsActive AND @IsActive is not null)
    OR ([IsApprove] = @IsApprove AND @IsApprove is not null)
    OR ([DeliveryDate] = @DeliveryDate AND @DeliveryDate is not null)
    OR ([ReceivedDate] = @ReceivedDate AND @ReceivedDate is not null)
    OR ([CreationDate] = @CreationDate AND @CreationDate is not null)
    OR ([CreationUserId] = @CreationUserId AND @CreationUserId is not null)
    OR ([LastModificationDate] = @LastModificationDate AND @LastModificationDate is not null)
    OR ([LastModificationUserId] = @LastModificationUserId AND @LastModificationUserId is not null)
        Select @@ROWCOUNT			
    END
	

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

