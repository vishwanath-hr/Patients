USE [master]
GO
/****** Object:  Database [Patients]    Script Date: 04-Feb-19 10:47:55 PM ******/
CREATE DATABASE [Patients]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Patients', FILENAME = N'C:\Users\vramegowda\Patients.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Patients_log', FILENAME = N'C:\Users\vramegowda\Patients_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Patients].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Patients] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Patients] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Patients] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Patients] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Patients] SET ARITHABORT OFF 
GO
ALTER DATABASE [Patients] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Patients] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Patients] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Patients] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Patients] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Patients] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Patients] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Patients] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Patients] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Patients] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Patients] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Patients] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Patients] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Patients] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Patients] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Patients] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Patients] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Patients] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Patients] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Patients] SET  MULTI_USER 
GO
ALTER DATABASE [Patients] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Patients] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Patients] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Patients] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [Patients]
GO
/****** Object:  Table [dbo].[PatientPhones]    Script Date: 04-Feb-19 10:47:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientPhones](
	[PhoneId] [int] IDENTITY(1,1) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[PatientId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 04-Feb-19 10:47:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Forename] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[DateofBirth] [datetime] NULL,
	[Gender] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PatientPhones]  WITH CHECK ADD  CONSTRAINT [FK_PatientPhone_ToTable] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[PatientPhones] CHECK CONSTRAINT [FK_PatientPhone_ToTable]
GO
USE [master]
GO
ALTER DATABASE [Patients] SET  READ_WRITE 
GO
