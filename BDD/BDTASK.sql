USE [Task]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 11/07/2024 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[IsCompleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TaskActualiza]    Script Date: 11/07/2024 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskActualiza]
    @Id INT,
    @Title NVARCHAR(200),
    @Description NVARCHAR(200),
    @IsCompleted bit
AS
BEGIN
UPDATE Task   SET Title=@Title,Description=@Description,IsCompleted=@IsCompleted
    WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[TaskElimina]    Script Date: 11/07/2024 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskElimina]
    @Id INT
AS
BEGIN
    DELETE Task WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[TaskIngresa]    Script Date: 11/07/2024 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskIngresa]
    @Title NVARCHAR(200),
    @Description NVARCHAR(200),
    @IsCompleted bit
AS
BEGIN
    INSERT INTO Task (Title, Description, IsCompleted)
    VALUES (@Title, @Description, @IsCompleted)
END
GO
/****** Object:  StoredProcedure [dbo].[TaskList]    Script Date: 11/07/2024 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TaskList]
AS
SELECT Id ,Title,Description,
IsCompleted,
CASE 
	 WHEN IsCompleted = 0 Then 'No'
	 WHEN IsCompleted = 1 Then 'Si'
	End  IsCompletedName

FROM Task
GO
/****** Object:  StoredProcedure [dbo].[TaskRetornaTareas]    Script Date: 11/07/2024 20:07:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskRetornaTareas]
    @Id INT
AS
BEGIN
    SELECT Id, Title, Description, IsCompleted
    FROM Task
    WHERE Id = @Id
END
GO
