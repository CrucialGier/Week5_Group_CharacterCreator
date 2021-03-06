CREATE DATABASE character_creator_test
GO
USE [character_creator_test]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 7/27/2016 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[characters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[class_id] [int] NULL,
	[bodyType_id] [int] NULL,
	[weapon_id] [int] NULL,
	[armor_id] [int] NULL,
	[special_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[classes]    Script Date: 7/27/2016 3:59:18 PM ******/
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
/****** Object:  Table [dbo].[classes_items]    Script Date: 7/27/2016 3:59:18 PM ******/
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
/****** Object:  Table [dbo].[item_types]    Script Date: 7/27/2016 3:59:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[item_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[items]    Script Date: 7/27/2016 3:59:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[type_id] [int] NULL,
	[image] [varchar](255) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[classes] ON 

INSERT [dbo].[classes] ([id], [name]) VALUES (1, N'Business Man')
INSERT [dbo].[classes] ([id], [name]) VALUES (2, N'Space Dragon')
INSERT [dbo].[classes] ([id], [name]) VALUES (3, N'Alien Cyborg')
SET IDENTITY_INSERT [dbo].[classes] OFF
SET IDENTITY_INSERT [dbo].[classes_items] ON 

INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (1, 1, 1)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (2, 1, 2)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (3, 1, 3)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (4, 1, 4)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (5, 1, 5)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (6, 1, 6)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (7, 2, 7)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (8, 2, 8)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (9, 2, 9)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (10, 2, 10)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (11, 2, 11)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (12, 2, 12)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (13, 3, 13)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (14, 3, 14)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (15, 3, 15)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (16, 3, 16)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (17, 3, 17)
INSERT [dbo].[classes_items] ([id], [class_id], [item_id]) VALUES (18, 3, 18)
SET IDENTITY_INSERT [dbo].[classes_items] OFF
SET IDENTITY_INSERT [dbo].[item_types] ON 

INSERT [dbo].[item_types] ([id], [name]) VALUES (1, N'Weapon')
INSERT [dbo].[item_types] ([id], [name]) VALUES (2, N'Armor')
INSERT [dbo].[item_types] ([id], [name]) VALUES (3, N'Special')
INSERT [dbo].[item_types] ([id], [name]) VALUES (4, N'Body Type')
SET IDENTITY_INSERT [dbo].[item_types] OFF
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (1, N'Brief Case', 3, N'Bizman-Suit-Briefcase.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (2, N'Golf club', 1, N'Bizman-Golf-Golfclub.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (3, N'Business Outfit', 2, N'Bizman-Suit-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (4, N'Golf Outfit', 2, N'Bizman-Golf-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (5, N'Vacation outfit', 2, N'Bizman-Vacay-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (6, N'Vacation Shark', 1, N'Bizman-Vacay-Shark.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (7, N'Dragon gun', 1, N'Dragon-Suit-Gun.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (8, N'Dragon Dress', 2, N'Dragon-Dress-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (9, N'Dragon Shoe', 1, N'Dragon-Dress-Shoe.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (10, N'Dragon Duck', 3, N'Dragon-Swim-Duck.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (11, N'Dragon swimsuit', 2, N'Dragon-Swim-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (12, N'Dragon suit', 2, N'Dragon-Suit-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (13, N'Cyborg axe', 1, N'Cyborg-Grey-Axe.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (14, N'Cyborg grey outfit', 2, N'Cyborg-Grey-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (15, N'Cyborg red outfit', 2, N'Cyborg-Red-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (16, N'Cyborg hair', 3, N'Cyborg-Hair.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (17, N'Cyborg yellow outfit', 2, N'Cyborg-Yellow-Outfit.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (18, N'Cyborg sword', 1, N'Cyborg-Yellow-Sword.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (20, N'Cyborg doubleaxe', 1, N'Cyborg-Red-DoubleAxe.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (21, N'Business body', 4, N'Bizman-Body.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (24, N'Golf body', 4, N'Bizman-Golf-Body.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (25, N'Vacation body', 4, N'Bizman-Vacay-Body.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (26, N'Cyborg Body', 4, N'Cyborg-Body.png')
INSERT [dbo].[items] ([id], [name], [type_id], [image]) VALUES (27, N'Dragon Body', 4, N'Dragon-Body.png')
SET IDENTITY_INSERT [dbo].[items] OFF
