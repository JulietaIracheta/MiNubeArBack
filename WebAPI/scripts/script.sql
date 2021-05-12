USE [master]
GO
/****** Object:  Database [minubeDB]    Script Date: 12/05/2021 20:26:50 ******/
CREATE DATABASE [minubeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'minubeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\minubeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'minubeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\minubeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [minubeDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [minubeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [minubeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [minubeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [minubeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [minubeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [minubeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [minubeDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [minubeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [minubeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [minubeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [minubeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [minubeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [minubeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [minubeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [minubeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [minubeDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [minubeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [minubeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [minubeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [minubeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [minubeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [minubeDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [minubeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [minubeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [minubeDB] SET  MULTI_USER 
GO
ALTER DATABASE [minubeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [minubeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [minubeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [minubeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [minubeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [minubeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [minubeDB] SET QUERY_STORE = OFF
GO
USE [minubeDB]
GO
/****** Object:  User [admin]    Script Date: 12/05/2021 20:26:51 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/05/2021 20:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/05/2021 20:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rol] [nvarchar](50) NULL,
	[nombre] [nvarchar](100) NULL,
	[apellido] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[edad] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [minubeDB] SET  READ_WRITE 
GO
