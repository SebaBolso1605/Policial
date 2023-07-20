USE [master]
GO

/****** Object:  Database [Policial]    Script Date: 9/4/2022 15:14:04 ******/
CREATE DATABASE [Policial]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Policial', 
--Para SQL Sebastian
--FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Policial.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
--Para SQL Fernando
FILENAME = 'C:\Bases\Policial.mdf', SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Policial_log', 
--Para SQL Sebastian
--FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Policial_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--Para SQL Fernando
FILENAME = 'C:\Bases\Policial_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Policial].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Policial] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Policial] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Policial] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Policial] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Policial] SET ARITHABORT OFF 
GO

ALTER DATABASE [Policial] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Policial] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Policial] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Policial] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Policial] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Policial] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Policial] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Policial] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Policial] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Policial] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Policial] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Policial] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Policial] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Policial] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Policial] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Policial] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Policial] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Policial] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Policial] SET  MULTI_USER 
GO

ALTER DATABASE [Policial] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Policial] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Policial] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Policial] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Policial] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Policial] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Policial] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Policial] SET  READ_WRITE 
GO


-- INTEGRACIÓN DE LOS SCRIPTS

USE [Policial]
GO


/****** Object:  Table [dbo].[Usuario]    Script Date: 9/4/2022 15:13:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[UsuId] [int] IDENTITY(1,1) NOT NULL,
	[UsuClaveAcceso] [nchar](50) NOT NULL,
	[UsuPass] [nchar](8) NOT NULL,
	[UsuNombre] [nchar](100) NOT NULL,
	[UsuActivo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[Socio]    Script Date: 9/4/2022 15:23:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Socio](
	[SocId] [int] IDENTITY(1,1) NOT NULL,
	[SocPrimerApellido] [nchar](50) NOT NULL,
	[SocSegundoApellido] [nchar](50) NULL,
	[SocPrimerNombre] [nchar](50) NULL,
	[SocSegundoNombre] [nchar](50) NOT NULL,
	[SocFechaNacimiento] [datetime] NULL,
	[SocDireccion] [nchar](100) NULL,
	[SocTel] [nchar](20) NULL,
	[SocEmail] [nchar](50) NULL,
	[FecAlta] [datetime] NOT NULL,
	[FecModif] [datetime] NOT NULL,
	[UsuIdModif] [int] NOT NULL,
	[UsuIdAlta] [int] NOT NULL,
	[UsuObservaciones] [nchar](250) NULL,
 CONSTRAINT [PK_Socio] PRIMARY KEY CLUSTERED 
(
	[SocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Cuota]    Script Date: 9/4/2022 15:23:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cuota](
	[CuotaId] [int] IDENTITY(1,1) NOT NULL,
	[CuotaFechaDesde] [datetime] NOT NULL,
	[CuotaFechaHasta] [datetime] NOT NULL,
	[CuotaTipo] [int] NOT NULL,
	[FecAlta] [datetime] NOT NULL,
	[FecModif] [datetime] NOT NULL,
	[UsuIdAlta] [int] NOT NULL,
	[UsuIdModif] [int] NOT NULL,
 CONSTRAINT [PK_Cuota] PRIMARY KEY CLUSTERED 
(
	[CuotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TipoCuota]    Script Date: 9/4/2022 15:32:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoCuota](
	[TCId] [int] IDENTITY(1,1) NOT NULL,
	[TCDescripcion] [nchar](100) NOT NULL,
	[TCMonto] [int] NOT NULL,
	[FecAlta] [datetime] NOT NULL,
	[FecModif] [datetime] NOT NULL,
	[UsuIdAlta] [int] NOT NULL,
	[UsuIdModif] [int] NOT NULL,
 CONSTRAINT [PK_TipoCuota] PRIMARY KEY CLUSTERED 
(
	[TCId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[alta_usuario]    Script Date: 9/4/2022 20:58:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[alta_usuario]
--ALTER PROCEDURE alta_usuario
@usuClaveAcceso nchar (50),
@usuNombre nchar (100),
@pass nchar (8),
@usuActivo bit
AS
BEGIN 
	INSERT Usuario (UsuClaveAcceso,UsuNombre,UsuPass,UsuActivo) VALUES (@usuClaveAcceso,@usuNombre,@pass,@usuActivo)
		IF @@ERROR <> 0
		BEGIN
			RETURN -1
		END		
		RETURN 1	
END

GO

exec alta_Usuario 'seba', 'Sebastian', '1234', 1

GO

/****** Object:  StoredProcedure [dbo].[loguin]    Script Date: 9/4/2022 20:15:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--////////// Loguin /////////////
Create PROC [dbo].[login]
--ALTER PROC loguin
 @usuario nchar(50),
 @pass nchar(8)
AS
BEGIN
	SELECT * FROM Usuario u 
	WHERE u.UsuClaveAcceso = @usuario AND u.UsuPass = @pass
END


