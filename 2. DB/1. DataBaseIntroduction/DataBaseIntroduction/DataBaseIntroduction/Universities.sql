USE [Student]
GO

/****** Object:  Table [dbo].[Universities]    Script Date: 3/14/2019 9:53:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Universities](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Address] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[Contact] [varchar](64) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_University] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Universities]  WITH NOCHECK ADD  CONSTRAINT [CHK_Age] CHECK  (([Age]>(0)))
GO

ALTER TABLE [dbo].[Universities] CHECK CONSTRAINT [CHK_Age]
GO


