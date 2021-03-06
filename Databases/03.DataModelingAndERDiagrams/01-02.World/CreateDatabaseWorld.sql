USE [master]
GO
/****** Object:  Database [HomeworkCheck.01-02.World]    Script Date: 12.7.2013 г. 2:58:11 ******/
CREATE DATABASE [HomeworkCheck.01-02.World]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeworkCheck.01-02.World', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeworkCheck.01-02.World.mdf' , SIZE = 5072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HomeworkCheck.01-02.World_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeworkCheck.01-02.World_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeworkCheck.01-02.World].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET RECOVERY FULL 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET  MULTI_USER 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HomeworkCheck.01-02.World', N'ON'
GO
USE [HomeworkCheck.01-02.World]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 12.7.2013 г. 2:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](50) NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 12.7.2013 г. 2:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 12.7.2013 г. 2:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 12.7.2013 г. 2:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 12.7.2013 г. 2:58:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (1, N'Erste Strasse No1', 1)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (2, N'First Street No2', 2)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (3, N'Pushkin No3', 4)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (2, N'North America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (3, N'South America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (4, N'Africa')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (5, N'Asia')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (1, N'Germany', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (2, N'Great Britain', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (3, N'Mexico', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (4, N'Peru', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (5, N'Nigeria', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (6, N'Russia', 5)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (1, N'Hans', N'Stark', 1)
INSERT [dbo].[People] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (3, N'Andy', N'Murray', 2)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (1, N'Munich', 1)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (2, N'London', 2)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (3, N'Mexico City', 3)
INSERT [dbo].[Towns] ([TownID], [Name], [CountryID]) VALUES (4, N'Moskow', 6)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([TownID])
REFERENCES [dbo].[Towns] ([TownID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([AddressID])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [HomeworkCheck.01-02.World] SET  READ_WRITE 
GO
