USE [master]
GO
/****** Object:  Database [HomeworkCheck.03.EducationSystem]    Script Date: 12.7.2013 г. 3:10:17 ******/
CREATE DATABASE [HomeworkCheck.03.EducationSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeworkCheck.03.EducationSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeworkCheck.03.EducationSystem.mdf' , SIZE = 5072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HomeworkCheck.03.EducationSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HomeworkCheck.03.EducationSystem_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeworkCheck.03.EducationSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET  MULTI_USER 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HomeworkCheck.03.EducationSystem', N'ON'
GO
USE [HomeworkCheck.03.EducationSystem]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UniversityID] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[FacultyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UniversityID] [int] NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[FacultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FacultiesAndDepartments]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacultiesAndDepartments](
	[FacultyID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ProfessorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ProfessorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorsAndCourses]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorsAndCourses](
	[ProfessorID] [int] NOT NULL,
	[CourseID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorsAndDepartments]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorsAndDepartments](
	[ProfessorID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfessorsAndTitles]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorsAndTitles](
	[ProfessorId] [int] NOT NULL,
	[TitleID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FacultyID] [int] NOT NULL,
	[UniversityID] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentsAndCourses]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsAndCourses](
	[StudentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[TitleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[TitleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Universities]    Script Date: 12.7.2013 г. 3:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[UniversityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Universities] PRIMARY KEY CLUSTERED 
(
	[UniversityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Universities] FOREIGN KEY([UniversityID])
REFERENCES [dbo].[Universities] ([UniversityID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Universities]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_Universities] FOREIGN KEY([UniversityID])
REFERENCES [dbo].[Universities] ([UniversityID])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_Universities]
GO
ALTER TABLE [dbo].[FacultiesAndDepartments]  WITH CHECK ADD  CONSTRAINT [FK_FacultiesAndDepartments_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[FacultiesAndDepartments] CHECK CONSTRAINT [FK_FacultiesAndDepartments_Departments]
GO
ALTER TABLE [dbo].[FacultiesAndDepartments]  WITH CHECK ADD  CONSTRAINT [FK_FacultiesAndDepartments_Faculties] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculties] ([FacultyID])
GO
ALTER TABLE [dbo].[FacultiesAndDepartments] CHECK CONSTRAINT [FK_FacultiesAndDepartments_Faculties]
GO
ALTER TABLE [dbo].[ProfessorsAndCourses]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsAndCourses_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[ProfessorsAndCourses] CHECK CONSTRAINT [FK_ProfessorsAndCourses_Courses]
GO
ALTER TABLE [dbo].[ProfessorsAndCourses]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsAndCourses_Professors] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[Professors] ([ProfessorID])
GO
ALTER TABLE [dbo].[ProfessorsAndCourses] CHECK CONSTRAINT [FK_ProfessorsAndCourses_Professors]
GO
ALTER TABLE [dbo].[ProfessorsAndDepartments]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsAndDepartments_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[ProfessorsAndDepartments] CHECK CONSTRAINT [FK_ProfessorsAndDepartments_Departments]
GO
ALTER TABLE [dbo].[ProfessorsAndDepartments]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsAndDepartments_Professors] FOREIGN KEY([ProfessorID])
REFERENCES [dbo].[Professors] ([ProfessorID])
GO
ALTER TABLE [dbo].[ProfessorsAndDepartments] CHECK CONSTRAINT [FK_ProfessorsAndDepartments_Professors]
GO
ALTER TABLE [dbo].[ProfessorsAndTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsAndTitles_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorID])
GO
ALTER TABLE [dbo].[ProfessorsAndTitles] CHECK CONSTRAINT [FK_ProfessorsAndTitles_Professors]
GO
ALTER TABLE [dbo].[ProfessorsAndTitles]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorsAndTitles_Titles] FOREIGN KEY([TitleID])
REFERENCES [dbo].[Titles] ([TitleID])
GO
ALTER TABLE [dbo].[ProfessorsAndTitles] CHECK CONSTRAINT [FK_ProfessorsAndTitles_Titles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Universities] FOREIGN KEY([UniversityID])
REFERENCES [dbo].[Universities] ([UniversityID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Universities]
GO
ALTER TABLE [dbo].[StudentsAndCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsAndCourses_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[StudentsAndCourses] CHECK CONSTRAINT [FK_StudentsAndCourses_Courses]
GO
ALTER TABLE [dbo].[StudentsAndCourses]  WITH CHECK ADD  CONSTRAINT [FK_StudentsAndCourses_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[StudentsAndCourses] CHECK CONSTRAINT [FK_StudentsAndCourses_Students]
GO
USE [master]
GO
ALTER DATABASE [HomeworkCheck.03.EducationSystem] SET  READ_WRITE 
GO
