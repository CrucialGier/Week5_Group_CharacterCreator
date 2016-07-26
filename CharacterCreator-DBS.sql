CREATE DATABASE [character_creator]
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
INSERT INTO classes (name) VALUES ('Business Man');
INSERT INTO classes (name) VALUES ('Space Dragon');
INSERT INTO classes (name) VALUES ('Alien Cyborg');
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
INSERT INTO classes_items (class_id, item_id) VALUES (1,1);
INSERT INTO classes_items (class_id, item_id) VALUES (1,2);
INSERT INTO classes_items (class_id, item_id) VALUES (1,3);
INSERT INTO classes_items (class_id, item_id) VALUES (1,4);
INSERT INTO classes_items (class_id, item_id) VALUES (1,5);
INSERT INTO classes_items (class_id, item_id) VALUES (1,6);
GO
INSERT INTO classes_items (class_id, item_id) VALUES (2,7);
INSERT INTO classes_items (class_id, item_id) VALUES (2,8);
INSERT INTO classes_items (class_id, item_id) VALUES (2,9);
INSERT INTO classes_items (class_id, item_id) VALUES (2,10);
INSERT INTO classes_items (class_id, item_id) VALUES (2,11);
INSERT INTO classes_items (class_id, item_id) VALUES (2,12);
GO
INSERT INTO classes_items (class_id, item_id) VALUES (3,13);
INSERT INTO classes_items (class_id, item_id) VALUES (3,14);
INSERT INTO classes_items (class_id, item_id) VALUES (3,15);
INSERT INTO classes_items (class_id, item_id) VALUES (3,16);
INSERT INTO classes_items (class_id, item_id) VALUES (3,17);
INSERT INTO classes_items (class_id, item_id) VALUES (3,18);
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
INSERT INTO items (name, type_id) VALUES ('Brief Case', 1);
INSERT INTO items (name, type_id) VALUES ('Spectacles', 2);
INSERT INTO items (name, type_id) VALUES ('Dapper Jacket', 2);
INSERT INTO items (name, type_id) VALUES ('Dapper Cuffs', 2);
INSERT INTO items (name, type_id) VALUES ('Dapper Pants', 2);
INSERT INTO items (name, type_id) VALUES ('Umbrella', 3);
GO
INSERT INTO items (name, type_id) VALUES ('Dragon Breath', 1);
INSERT INTO items (name, type_id) VALUES ('Dragon Head', 2);
INSERT INTO items (name, type_id) VALUES ('Space Shirt', 2);
INSERT INTO items (name, type_id) VALUES ('Dragon Arms', 2);
INSERT INTO items (name, type_id) VALUES ('Space Pants', 2);
INSERT INTO items (name, type_id) VALUES ('Space Thing', 3);
GO
INSERT INTO items (name, type_id) VALUES ('Laser Gun', 1);
INSERT INTO items (name, type_id) VALUES ('Alien Head', 2);
INSERT INTO items (name, type_id) VALUES ('Robot Arms', 2);
INSERT INTO items (name, type_id) VALUES ('Alien Chest', 2);
INSERT INTO items (name, type_id) VALUES ('Robot Legs', 2);
INSERT INTO items (name, type_id) VALUES ('Fabio Hair', 3);
GO
CREATE TABLE [dbo].[item_types](
	[id] [int] IDENTITY(1,1),
	[name] VARCHAR(255)
) ON [PRIMARY]

GO
INSERT INTO item_types (name) VALUES ('Weapon');
INSERT INTO item_types (name) VALUES ('Armor');
INSERT INTO item_types (name) VALUES ('Special');
GO
SET ANSI_PADDING OFF
GO
