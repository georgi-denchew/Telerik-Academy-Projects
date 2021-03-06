USE [master]
GO
/****** Object:  Database [HomeworkCheck.05-06.Dictionary]    Script Date: 12.7.2013 г. 3:12:39 ******/
CREATE DATABASE [HomeworkCheck.05-06.Dictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeworkCheck.05-06.Dictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeworkCheck.05-06.Dictionary.mdf' , SIZE = 5072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HomeworkCheck.05-06.Dictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeworkCheck.05-06.Dictionary_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeworkCheck.05-06.Dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HomeworkCheck.05-06.Dictionary', N'ON'
GO
USE [HomeworkCheck.05-06.Dictionary]
GO
/****** Object:  Schema [Multilingual HomeworkCheck.05-06.Dictionary]    Script Date: 12.7.2013 г. 3:12:39 ******/
CREATE SCHEMA [Multilingual HomeworkCheck.05-06.Dictionary]
GO
/****** Object:  Table [dbo].[AntonymConnections]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AntonymConnections](
	[WordID] [int] NOT NULL,
	[AntonymWordID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ExplanationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ExplanationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HypernymConnections]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HypernymConnections](
	[WordID] [int] NOT NULL,
	[HypernymWordID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeech]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeech](
	[PartOfSPeechID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartsOfSpeech] PRIMARY KEY CLUSTERED 
(
	[PartOfSPeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SynonymConnections]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SynonymConnections](
	[WordID] [int] NOT NULL,
	[SynonymWordID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TranslationConnections]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TranslationConnections](
	[WordID] [int] NOT NULL,
	[TranslationWordID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PartOfSpeechID] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsAndExplanations]    Script Date: 12.7.2013 г. 3:12:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsAndExplanations](
	[WordID] [int] NOT NULL,
	[ExplanationID] [int] NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[AntonymConnections] ([WordID], [AntonymWordID]) VALUES (4, 6)
SET IDENTITY_INSERT [dbo].[Explanations] ON 

INSERT [dbo].[Explanations] ([ExplanationID], [Name]) VALUES (1, N'материално заможен')
SET IDENTITY_INSERT [dbo].[Explanations] OFF
INSERT [dbo].[HypernymConnections] ([WordID], [HypernymWordID]) VALUES (9, 10)
INSERT [dbo].[HypernymConnections] ([WordID], [HypernymWordID]) VALUES (9, 11)
INSERT [dbo].[HypernymConnections] ([WordID], [HypernymWordID]) VALUES (9, 12)
SET IDENTITY_INSERT [dbo].[PartsOfSpeech] ON 

INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (1, N'Noun')
INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (2, N'Verb')
INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (3, N'Adjective')
INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (4, N'Pronoun')
INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (5, N'Adverb')
INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (6, N'Preposition')
INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (7, N'Conjunction')
INSERT [dbo].[PartsOfSpeech] ([PartOfSPeechID], [Name]) VALUES (1004, N'Interjection')
SET IDENTITY_INSERT [dbo].[PartsOfSpeech] OFF
INSERT [dbo].[SynonymConnections] ([WordID], [SynonymWordID]) VALUES (2, 3)
INSERT [dbo].[TranslationConnections] ([WordID], [TranslationWordID]) VALUES (4, 8)
SET IDENTITY_INSERT [dbo].[Words] ON 

INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (2, N'Tissue', 1)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (3, N'Napkin', 1)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (4, N'Rich', 3)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (6, N'Poor', 3)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (8, N'Богат', 3)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (9, N'Tree', 1)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (10, N'Oak tree', 1)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (11, N'Pine', 1)
INSERT [dbo].[Words] ([WordID], [Name], [PartOfSpeechID]) VALUES (12, N'Walnut-tree', 1)
SET IDENTITY_INSERT [dbo].[Words] OFF
INSERT [dbo].[WordsAndExplanations] ([WordID], [ExplanationID]) VALUES (4, 1)
ALTER TABLE [dbo].[AntonymConnections]  WITH CHECK ADD  CONSTRAINT [FK_AntonymConnections_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[AntonymConnections] CHECK CONSTRAINT [FK_AntonymConnections_Words]
GO
ALTER TABLE [dbo].[AntonymConnections]  WITH CHECK ADD  CONSTRAINT [FK_AntonymConnections_Words1] FOREIGN KEY([AntonymWordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[AntonymConnections] CHECK CONSTRAINT [FK_AntonymConnections_Words1]
GO
ALTER TABLE [dbo].[HypernymConnections]  WITH CHECK ADD  CONSTRAINT [FK_HypernymConnections_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[HypernymConnections] CHECK CONSTRAINT [FK_HypernymConnections_Words]
GO
ALTER TABLE [dbo].[HypernymConnections]  WITH CHECK ADD  CONSTRAINT [FK_HypernymConnections_Words1] FOREIGN KEY([HypernymWordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[HypernymConnections] CHECK CONSTRAINT [FK_HypernymConnections_Words1]
GO
ALTER TABLE [dbo].[SynonymConnections]  WITH CHECK ADD  CONSTRAINT [FK_SynonymConnections_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[SynonymConnections] CHECK CONSTRAINT [FK_SynonymConnections_Words]
GO
ALTER TABLE [dbo].[SynonymConnections]  WITH CHECK ADD  CONSTRAINT [FK_SynonymConnections_Words1] FOREIGN KEY([SynonymWordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[SynonymConnections] CHECK CONSTRAINT [FK_SynonymConnections_Words1]
GO
ALTER TABLE [dbo].[TranslationConnections]  WITH CHECK ADD  CONSTRAINT [FK_TranslationConnections_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[TranslationConnections] CHECK CONSTRAINT [FK_TranslationConnections_Words]
GO
ALTER TABLE [dbo].[TranslationConnections]  WITH CHECK ADD  CONSTRAINT [FK_TranslationConnections_Words1] FOREIGN KEY([TranslationWordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[TranslationConnections] CHECK CONSTRAINT [FK_TranslationConnections_Words1]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartsOfSpeech1] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[PartsOfSpeech] ([PartOfSPeechID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartsOfSpeech1]
GO
ALTER TABLE [dbo].[WordsAndExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsAndExplanations_Explanations] FOREIGN KEY([ExplanationID])
REFERENCES [dbo].[Explanations] ([ExplanationID])
GO
ALTER TABLE [dbo].[WordsAndExplanations] CHECK CONSTRAINT [FK_WordsAndExplanations_Explanations]
GO
ALTER TABLE [dbo].[WordsAndExplanations]  WITH CHECK ADD  CONSTRAINT [FK_WordsAndExplanations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[WordsAndExplanations] CHECK CONSTRAINT [FK_WordsAndExplanations_Words]
GO
USE [master]
GO
ALTER DATABASE [HomeworkCheck.05-06.Dictionary] SET  READ_WRITE 
GO
