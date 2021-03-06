USE [TestingTalmerDb]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 11/1/2015 6:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[Subtitle] [nvarchar](300) NULL,
	[Address1] [nvarchar](300) NOT NULL,
	[Address2] [nvarchar](300) NULL,
	[City] [nvarchar](150) NOT NULL,
	[State] [nvarchar](2) NOT NULL,
	[Zip] [nvarchar](15) NOT NULL,
	[AtmOnly] [bit] NOT NULL,
	[NoAtm] [bit] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[ImageData] [varbinary](max) NULL,
	[ImageMimeType] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[ManagerName] [nvarchar](200) NULL,
 CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocHours]    Script Date: 11/1/2015 6:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocHours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Hours] [nvarchar](150) NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LocHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocPhoneExts]    Script Date: 11/1/2015 6:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocPhoneExts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[LocPhoneNumsId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LocPhoneExts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocPhoneNums]    Script Date: 11/1/2015 6:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocPhoneNums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LocPhoneNums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocServices]    Script Date: 11/1/2015 6:01:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IconClassName] [nvarchar](50) NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LocServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[LocHours]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LocHours_dbo.Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocHours] CHECK CONSTRAINT [FK_dbo.LocHours_dbo.Locations_LocationId]
GO
ALTER TABLE [dbo].[LocPhoneExts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LocPhoneExts_dbo.LocPhoneNums_LocPhoneNumsId] FOREIGN KEY([LocPhoneNumsId])
REFERENCES [dbo].[LocPhoneNums] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocPhoneExts] CHECK CONSTRAINT [FK_dbo.LocPhoneExts_dbo.LocPhoneNums_LocPhoneNumsId]
GO
ALTER TABLE [dbo].[LocPhoneNums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LocPhoneNums_dbo.Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocPhoneNums] CHECK CONSTRAINT [FK_dbo.LocPhoneNums_dbo.Locations_LocationId]
GO
ALTER TABLE [dbo].[LocServices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LocServices_dbo.Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LocServices] CHECK CONSTRAINT [FK_dbo.LocServices_dbo.Locations_LocationId]
GO
