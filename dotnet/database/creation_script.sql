USE [master]
GO
/****** Object:  Database [EletricGuitarChallenge]    Script Date: 2/2/2018 12:51:23 AM ******/
CREATE DATABASE [EletricGuitarChallenge]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EletricGuitarChallenge', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EletricGuitarChallenge.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EletricGuitarChallenge_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EletricGuitarChallenge_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EletricGuitarChallenge] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EletricGuitarChallenge].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EletricGuitarChallenge] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET ARITHABORT OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EletricGuitarChallenge] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EletricGuitarChallenge] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EletricGuitarChallenge] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EletricGuitarChallenge] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EletricGuitarChallenge] SET  MULTI_USER 
GO
ALTER DATABASE [EletricGuitarChallenge] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EletricGuitarChallenge] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EletricGuitarChallenge] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EletricGuitarChallenge] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EletricGuitarChallenge] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EletricGuitarChallenge]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/2/2018 12:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EletricGuitar]    Script Date: 2/2/2018 12:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EletricGuitar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](400) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [varchar](800) NULL,
	[InsertDate] [datetime] NOT NULL,
	[ImageUrl] [varchar](8000) NULL,
	[Sku] [varchar](500) NULL,
 CONSTRAINT [PK_EletricGuitar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EletricGuitars]    Script Date: 2/2/2018 12:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EletricGuitars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [nvarchar](800) NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Sku] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.EletricGuitars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [EletricGuitarChallenge] SET  READ_WRITE 
GO
