USE [master]
GO
/****** Object:  Database [SUPERZAPATOS]    Script Date: 03/02/2017 0:41:59 ******/
CREATE DATABASE [SUPERZAPATOS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SUPERZAPATOS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\SUPERZAPATOS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SUPERZAPATOS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\SUPERZAPATOS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SUPERZAPATOS] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SUPERZAPATOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SUPERZAPATOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SUPERZAPATOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SUPERZAPATOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SUPERZAPATOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SUPERZAPATOS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SUPERZAPATOS] SET  MULTI_USER 
GO
ALTER DATABASE [SUPERZAPATOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SUPERZAPATOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SUPERZAPATOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SUPERZAPATOS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SUPERZAPATOS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SUPERZAPATOS] SET QUERY_STORE = OFF
GO
USE [SUPERZAPATOS]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SUPERZAPATOS]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 03/02/2017 0:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[total_in_shelf] [int] NOT NULL,
	[total_in_vault] [int] NOT NULL,
	[store_id] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stores]    Script Date: 03/02/2017 0:42:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Stores] FOREIGN KEY([store_id])
REFERENCES [dbo].[Stores] ([id])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Stores]
GO
USE [master]
GO
ALTER DATABASE [SUPERZAPATOS] SET  READ_WRITE 
GO
