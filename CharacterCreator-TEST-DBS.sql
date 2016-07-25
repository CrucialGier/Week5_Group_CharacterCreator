CREATE DATABASE [character_creator_test]
GO
USE [character_creator_test]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 7/25/2016 9:49:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[characters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[class_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
