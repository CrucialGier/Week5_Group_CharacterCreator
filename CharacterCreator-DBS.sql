CREATE DATABASE [charactor_creator]
GO
USE [character_creator]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 7/25/2016 10:40:24 AM ******/
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
/****** Object:  Table [dbo].[classes]    Script Date: 7/25/2016 10:40:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[classes_items]    Script Date: 7/25/2016 10:40:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes_items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[class_id] [int] NULL,
	[item_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[items]    Script Date: 7/25/2016 10:40:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[type_id] int
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
