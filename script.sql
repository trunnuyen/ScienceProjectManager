USE [master]
GO
/****** Object:  Database [DBProjectManagement]    Script Date: 08/01/2022 9:56:55 CH ******/
CREATE DATABASE [DBProjectManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBProjectManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBProjectManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBProjectManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBProjectManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBProjectManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBProjectManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBProjectManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBProjectManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBProjectManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBProjectManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBProjectManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBProjectManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBProjectManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBProjectManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBProjectManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBProjectManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBProjectManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBProjectManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBProjectManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBProjectManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBProjectManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBProjectManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBProjectManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBProjectManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBProjectManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBProjectManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBProjectManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DBProjectManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBProjectManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [DBProjectManagement] SET  MULTI_USER 
GO
ALTER DATABASE [DBProjectManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBProjectManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBProjectManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBProjectManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBProjectManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBProjectManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBProjectManagement', N'ON'
GO
ALTER DATABASE [DBProjectManagement] SET QUERY_STORE = OFF
GO
USE [DBProjectManagement]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [nchar](10) NOT NULL,
	[Password] [ntext] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[name] [nvarchar](128) NOT NULL,
	[listMajor] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Faculty] PRIMARY KEY CLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Progress]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Progress](
	[idProject] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[dateStart] [datetime] NOT NULL,
	[finishTime] [datetime] NOT NULL,
	[submitTime] [datetime] NOT NULL,
	[expense] [real] NOT NULL,
	[finished] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Progress] PRIMARY KEY CLUSTERED 
(
	[idProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[idProject] [nvarchar](128) NOT NULL,
	[name] [nvarchar](max) NULL,
	[subject] [nvarchar](max) NULL,
	[course] [nvarchar](max) NULL,
	[source] [nvarchar](max) NULL,
	[dateStart] [datetime] NULL,
	[dateEnd] [datetime] NULL,
	[expense] [real] NOT NULL,
	[type] [nvarchar](max) NULL,
	[rank] [nvarchar](max) NULL,
	[host] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Project] PRIMARY KEY CLUSTERED 
(
	[idProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectInstructors]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectInstructors](
	[Project_idProject] [nvarchar](128) NOT NULL,
	[Instructor_id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.ProjectInstructors] PRIMARY KEY CLUSTERED 
(
	[Project_idProject] ASC,
	[Instructor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[id] [nvarchar](128) NOT NULL,
	[comment] [nvarchar](max) NULL,
	[Project_idProject] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Report] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[MSSV] [nvarchar](128) NOT NULL,
	[name] [nvarchar](max) NULL,
	[gender] [nvarchar](max) NULL,
	[birthday] [datetime] NOT NULL,
	[address] [nvarchar](max) NULL,
	[numberPhone] [nvarchar](max) NULL,
	[faculty] [nvarchar](max) NULL,
	[major] [nvarchar](max) NULL,
	[Class] [nvarchar](max) NULL,
	[course] [nvarchar](max) NULL,
	[Progress_idProject] [nvarchar](128) NULL,
	[password] [nvarchar](max) NULL,
	[access] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Student] PRIMARY KEY CLUSTERED 
(
	[MSSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentProjects]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentProjects](
	[Student_MSSV] [nvarchar](128) NOT NULL,
	[Project_idProject] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.StudentProjects] PRIMARY KEY CLUSTERED 
(
	[Student_MSSV] ASC,
	[Project_idProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] NOT NULL,
	[subject] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Subject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 08/01/2022 9:56:55 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [nvarchar](128) NOT NULL,
	[name] [nvarchar](max) NULL,
	[gender] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[birthday] [datetime] NOT NULL,
	[subject] [nvarchar](max) NULL,
	[password] [varchar](max) NULL,
	[access] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Instructor_id]    Script Date: 08/01/2022 9:56:55 CH ******/
CREATE NONCLUSTERED INDEX [IX_Instructor_id] ON [dbo].[ProjectInstructors]
(
	[Instructor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Project_idProject]    Script Date: 08/01/2022 9:56:55 CH ******/
CREATE NONCLUSTERED INDEX [IX_Project_idProject] ON [dbo].[ProjectInstructors]
(
	[Project_idProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Project_idProject]    Script Date: 08/01/2022 9:56:55 CH ******/
CREATE NONCLUSTERED INDEX [IX_Project_idProject] ON [dbo].[Report]
(
	[Project_idProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Progress_idProject]    Script Date: 08/01/2022 9:56:55 CH ******/
CREATE NONCLUSTERED INDEX [IX_Progress_idProject] ON [dbo].[Student]
(
	[Progress_idProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Project_idProject]    Script Date: 08/01/2022 9:56:55 CH ******/
CREATE NONCLUSTERED INDEX [IX_Project_idProject] ON [dbo].[StudentProjects]
(
	[Project_idProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Student_MSSV]    Script Date: 08/01/2022 9:56:55 CH ******/
CREATE NONCLUSTERED INDEX [IX_Student_MSSV] ON [dbo].[StudentProjects]
(
	[Student_MSSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProjectInstructors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProjectInstructors_dbo.Project_Project_idProject] FOREIGN KEY([Project_idProject])
REFERENCES [dbo].[Project] ([idProject])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectInstructors] CHECK CONSTRAINT [FK_dbo.ProjectInstructors_dbo.Project_Project_idProject]
GO
ALTER TABLE [dbo].[ProjectInstructors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProjectInstructors_dbo.Teacher_Instructor_id] FOREIGN KEY([Instructor_id])
REFERENCES [dbo].[Teacher] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectInstructors] CHECK CONSTRAINT [FK_dbo.ProjectInstructors_dbo.Teacher_Instructor_id]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Report_dbo.Project_Project_idProject] FOREIGN KEY([Project_idProject])
REFERENCES [dbo].[Project] ([idProject])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_dbo.Report_dbo.Project_Project_idProject]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Student_dbo.Progress_Progress_idProject] FOREIGN KEY([Progress_idProject])
REFERENCES [dbo].[Progress] ([idProject])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_dbo.Student_dbo.Progress_Progress_idProject]
GO
ALTER TABLE [dbo].[StudentProjects]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentProjects_dbo.Project_Project_idProject] FOREIGN KEY([Project_idProject])
REFERENCES [dbo].[Project] ([idProject])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentProjects] CHECK CONSTRAINT [FK_dbo.StudentProjects_dbo.Project_Project_idProject]
GO
ALTER TABLE [dbo].[StudentProjects]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentProjects_dbo.Student_Student_MSSV] FOREIGN KEY([Student_MSSV])
REFERENCES [dbo].[Student] ([MSSV])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentProjects] CHECK CONSTRAINT [FK_dbo.StudentProjects_dbo.Student_Student_MSSV]
GO
USE [master]
GO
ALTER DATABASE [DBProjectManagement] SET  READ_WRITE 
GO
