
USE master
GO

IF EXISTS (SELECT*FROM SYSDATABASES WHERE NAME='Policial')
BEGIN
	DROP DATABASE Policial
END

/****** Object:  Database [Policial]    Script Date: 9/4/2022 15:14:04 ******/
CREATE DATABASE Policial
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

USE [Policial]
GO

/****** Object:  Table [dbo].[Socios]    Script Date: 10/4/2022 0:02:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Socios](
	[SocId] [int] IDENTITY(1,1) NOT NULL,
	[SocPrimerApellido] [varchar](50) NOT NULL,
	[SocSegundoApellido] [varchar](50) NOT NULL,
	[SocPrimerNombre] [varchar](50) NOT NULL,
	[SocSegundoNombre] [varchar](50) NULL,
	[SocCI] [int] NOT NULL,
	[SocFechaNacimiento] [datetime] NOT NULL,
	[SocDireccion] [varchar](100) NULL,
	[SocTel] [varchar](20) NULL,
	[SocCelular] [varchar](10) NULL,
	[SocEmail] [varchar](50) NULL,
	[SocObservaciones] [varchar](250) NULL,
	[SocAtivo] [bit] NOT NULL,
	[SocFechaIngreso] [datetime] NOT NULL,
	[SocTipoCuota] [int] NOT NULL,
	[SocFechaEgreso] [datetime] NULL,
	[SocMotivoEgreso] [varchar](250) NULL,
	[FecAlta] [datetime] NOT NULL,
	[FecModif] [datetime] NOT NULL,
	[UsuIdModif] [int] NOT NULL,
	[UsuIdAlta] [int] NOT NULL,
 CONSTRAINT [PK_Socios] PRIMARY KEY CLUSTERED 
(
	[SocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

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

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NucleoFamiliar](
	[NFId] [int] IDENTITY(1,1) NOT NULL,
	[SocId] [int] NOT NULL,
	[NFPrimerApellido] [varchar](50) NOT NULL,
	[NFSegundoApellido] [varchar](50) NOT NULL,
	[NFPrimerNombre] [varchar](50) NOT NULL,
	[NFSegundoNombre] [varchar](50) NULL,
	[NFCI] [int] NOT NULL,
	[NFFechaNacimiento] [datetime] NOT NULL,
	[NFTel] [varchar](20) NULL,
	[NFCelular] [varchar](10) NULL,
	[NFTipoVinculo] [varchar](50) NULL,
	[NFObservaciones] [varchar](250) NULL,
	[NFActivo] [bit] NOT NULL,
	[FecAlta] [datetime] NOT NULL,
	[FecModif] [datetime] NOT NULL,
	[UsuIdModif] [int] NOT NULL,
	[UsuIdAlta] [int] NOT NULL,
 CONSTRAINT [PK_NucleoFamiliar] PRIMARY KEY CLUSTERED 
(
	[NFId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CuotaSocio](
	[CuotaId] [int] IDENTITY(1,1) NOT NULL,
	[SocId] [int] NOT NULL,
	[CuotaFechaDesde] [datetime] NOT NULL,
	[CuotaFechaHasta] [datetime] NULL,
	[CuotaTipo] [int] NOT NULL,
	[CuotaPaga] [bit] NULL,
	[CuotaFechaPaga] [datetime] NULL,
	[CuotaAAAAMM] [varchar](10) NULL,
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

ALTER TABLE [dbo].[CuotaSocio] ADD  CONSTRAINT [DF_CuotaSocio_CuotaFechaHasta]  DEFAULT (NULL) FOR [CuotaFechaHasta]
GO

ALTER TABLE [dbo].[CuotaSocio] ADD  CONSTRAINT [DF_CuotaSocio_CuotaPaga]  DEFAULT ((0)) FOR [CuotaPaga]
GO

ALTER TABLE [dbo].[CuotaSocio] ADD  CONSTRAINT [DF_CuotaSocio_CuotaAAAAMM]  DEFAULT ((0)) FOR [CuotaAAAAMM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoCuota](
	[TCId] [int] IDENTITY(1,1) NOT NULL,
	[TCDescripcion] [nchar](100) NOT NULL,
	[TCMonto] [int] NOT NULL,
	[TCActivo] [bit] NULL,
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

ALTER TABLE [dbo].[TipoCuota] ADD  CONSTRAINT [DF_TipoCuota_TCActivo]  DEFAULT ((1)) FOR [TCActivo]
GO

/****** Object:  StoredProcedure [dbo].[alta_usuario]    Script Date: 9/4/2022 20:58:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[alta_usuario]
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

/****** Object:  StoredProcedure [dbo].[listar_socios_todos]    Script Date: 19/7/2023 22:02:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROC [dbo].[listar_socios_todos]
--ALTER PROC listar_socios_todos
AS
BEGIN
	SELECT *
	FROM Socios
END
GO

/****** Object:  StoredProcedure [dbo].[listar_tipoCuota]    Script Date: 19/7/2023 22:03:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[listar_tipoCuota]
--ALTER PROC listar_tipoCuenta
AS
BEGIN
	SELECT * FROM TipoCuota	
	where TCActivo = 1
	order by TCDescripcion
END
					
GO

/****** Object:  StoredProcedure [dbo].[listar_tipoCuenta]    Script Date: 19/7/2023 22:02:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[listar_tipoCuenta]
--ALTER PROC listar_tipoCuenta
AS
BEGIN
	SELECT * FROM TipoCuota	
	where TCActivo = 1
	order by TCDescripcion
END
GO

/****** Object:  StoredProcedure [dbo].[alta_cuenta_socio]    Script Date: 13/7/2023 12:20:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--create PROC [dbo].[alta_cuenta_socio]
CREATE PROC [dbo].[alta_cuenta_socio]
@SocId INT,
@CuotaFechaDesde datetime,
@CuotaTipo int,
@CuotaPaga bit,
@CuotaFechaPaga datetime,
@CuotaAAAAMM varchar(10),
@UsuIdAlta INT,
@CuotaId INT OUTPUT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Socios WHERE SocId = @SocId)
		BEGIN
			RETURN -1 --NO EXISTE UN SOCIO CON ESE NÚMERO
		END
	ELSE
	BEGIN TRAN
		INSERT CuotaSocio(SocId,CuotaFechaDesde, CuotaTipo,CuotaPaga,CuotaFechaPaga,CuotaAAAAMM, FecAlta, FecModif, UsuIdAlta, UsuIdModif) 
					VALUES (@SocId,@CuotaFechaDesde,@CuotaTipo,@CuotaPaga,@CuotaFechaPaga,@CuotaAAAAMM,GETDATE(),GETDATE(),@UsuIdAlta,@UsuIdAlta)
					SET @CuotaId = (SELECT IDENT_CURRENT('CuotaSocio'))
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			RETURN -2
		END
	COMMIT TRAN
	RETURN 1
END

--update CuotaSocio set CuotaTipo = 3 where CuotaId = 4


--select * from CuotaSocio
GO

/****** Object:  StoredProcedure [dbo].[alta_TC]    Script Date: 13/7/2023 12:59:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--create PROCEDURE [dbo].[alta_TC]
CREATE PROCEDURE [dbo].[alta_TC]
@TCDescripcion nchar(100),
@TCMonto int,
@UsuIdAlta INT
AS
BEGIN
	IF EXISTS(SELECT * FROM TipoCuota WHERE TCDescripcion = @TCDescripcion and TCMonto = @TCMonto)
	BEGIN
		RETURN -1
	END
	ELSE
	BEGIN 
		INSERT TipoCuota(TCDescripcion,TCMonto,FecAlta,FecModif,UsuIdAlta,UsuIdModif) 
		VALUES (@TCDescripcion,@TCMonto,getdate(),GETDATE(),@UsuIdAlta,@UsuIdAlta)			
			IF @@ERROR <> 0
			BEGIN
				RETURN -2
			END	
			RETURN 1	
	END	
END

GO

/****** Object:  StoredProcedure [dbo].[alta_socio]    Script Date: 13/7/2023 12:59:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--////////// Alta Socios /////////////
--create PROCEDURE [dbo].[alta_socio]
CREATE PROCEDURE [dbo].[alta_socio]
@SocCI int,
@SocPrimerApellido VARCHAR (50),
@SocSegundoApellido VARCHAR (50),
@SocPrimerNombre VARCHAR (50),
@SocSegundoNombre VARCHAR (50),
@SocFechaNacimiento DATETIME,
@SocDireccion varchar(100),
@SocTel varchar(20),
@SocCelular varchar(10),
@SocEmail varchar(50),
@SocObservaciones varchar(250),
@SocAtivo bit,
@SocFechaIngreso DATETIME,
@SocTipoCuota int,
--@SocFechaEgreso DATETIME,
--@SocMotivoEgreso varchar(250),
@FecAlta DATETIME,
@FecModif DATETIME,
@UsuIdModif INT,
@UsuIdAlta INT,
@SocId INT OUTPUT
AS
BEGIN
	IF EXISTS(SELECT * FROM Socios WHERE SocCI = @SocCI)
	BEGIN
		RETURN -1
	END
	ELSE
	BEGIN 
		INSERT Socios(SocPrimerApellido,SocSegundoApellido,SocPrimerNombre,SocSegundoNombre,SocCI,SocFechaNacimiento,SocDireccion,SocTel
					,SocCelular,SocEmail,SocObservaciones,SocAtivo,SocFechaIngreso,SocTipoCuota,FecAlta,FecModif,UsuIdModif,UsuIdAlta) 
		VALUES (@SocPrimerApellido,@SocSegundoApellido,@SocPrimerNombre,@SocSegundoNombre,@SocCI,@SocFechaNacimiento,@SocDireccion,@SocTel,@SocCelular,@SocEmail,@SocObservaciones,
				@SocAtivo,@SocFechaIngreso,@SocTipoCuota,@FecAlta,@FecModif,@UsuIdModif,@UsuIdAlta)
			
			IF @@ERROR <> 0
			BEGIN
				RETURN -2
			END	
			SET @SocId = (SELECT IDENT_CURRENT('Socios'))
			RETURN 1	
	END	
END

GO

/****** Object:  StoredProcedure [dbo].[alta_nucleofamiliar]    Script Date: 13/7/2023 12:59:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--create PROC [dbo].[alta_nucleofamiliar]
CREATE PROC [dbo].[alta_nucleofamiliar]
@SocId int,
@NFPrimerApellido VARCHAR (50),
@NFSegundoApellido VARCHAR (50),
@NFPrimerNombre VARCHAR (50),
@NFSegundoNombre VARCHAR (50),
@NFCI int, 
@NFFechaNacimiento datetime,
@NFTipoVinculo varchar(50),
@NFTel VARCHAR (20),
@NFCelular VARCHAR (10),
@FecAlta datetime,
@NFObservaciones varchar(250),
@UsuIdAlta int
AS
BEGIN
	IF NOT EXISTS(SELECT SocId FROM Socios WHERE SocId = @SocId)
	BEGIN
		RETURN -1
	END
		BEGIN 
			INSERT INTO NucleoFamiliar(SocId,NFPrimerApellido,NFSegundoApellido,NFPrimerNombre,NFSegundoNombre,NFCI,NFFechaNacimiento,NFTipoVinculo,NFTel, NFCelular,NFObservaciones,NFActivo,FecAlta,FecModif,UsuIdAlta,UsuIdModif) 
			VALUES (@SocId,@NFPrimerApellido,@NFSegundoApellido,@NFPrimerNombre,@NFSegundoNombre,@NFCI,@NFFechaNacimiento,@NFTipoVinculo,@NFTel,@NFCelular,@NFObservaciones,1,@FecAlta,getdate(),@UsuIdAlta, @UsuIdAlta) 
			IF @@ERROR <> 0
				RETURN -1 -- ERROR AL AGREGAR NF
			RETURN 1 -- SE INSERTO CORRECTAMENTE
		END 
		RETURN -2 -- YA EXISTE Y ESTA ASOCIADA
END
GO

/****** Object:  StoredProcedure [dbo].[baja_TC]    Script Date: 13/7/2023 13:00:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--create PROCEDURE [dbo].[baja_TC]
CREATE PROCEDURE [dbo].[baja_TC]
@Id int,
@UsuIdModif INT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM TipoCuota WHERE TCid = @Id)
	BEGIN
		RETURN -1
	END
	ELSE
	BEGIN 
		update TipoCuota set TCActivo = 0 , FecModif = GETDATE(), UsuIdAlta = @UsuIdModif
						where TCId = @Id
			IF @@ERROR <> 0
			BEGIN
				RETURN -2
			END	
			RETURN 1	
	END	
END
GO

/****** Object:  StoredProcedure [dbo].[baja_nf]    Script Date: 13/7/2023 13:00:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--create PROC [dbo].[baja_nf]
CREATE PROC [dbo].[baja_nf]
@NFId INT
AS
BEGIN
		IF EXISTS(SELECT * FROM NucleoFamiliar WHERE NFId = @NFId)
		BEGIN
			update NucleoFamiliar set NFActivo = 0
			WHERE NFId= @NFId
			IF @@ERROR <> 0
					RETURN -2 
			RETURN 1 -- SE DIO DE BAJA CORRECTAMENTE
		END
		ELSE
			RETURN -1 
END

--exec baja_nf 2
--select * from NucleoFamiliar

GO


/****** Object:  StoredProcedure [dbo].[baja_socio]    Script Date: 13/7/2023 13:00:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--create PROC [dbo].[baja_socio]
CREATE PROC [dbo].[baja_socio]
@SocCI INT,
@SocFechaEgreso DATETIME,
@SocMotivoEgreso varchar(250)
AS
BEGIN
		IF EXISTS(SELECT * FROM Socios WHERE SocCI = @SocCI)
		BEGIN
			update Socios set SocAtivo = 0,
			SocFechaEgreso = @SocFechaEgreso,
			@SocMotivoEgreso = @SocMotivoEgreso
			WHERE SocCI= @SocCI
			IF @@ERROR <> 0
					RETURN -2 
			RETURN 1 -- SE DIO DE BAJA CORRECTAMENTE
		END
		ELSE
			RETURN -1 
END

GO

/****** Object:  StoredProcedure [dbo].[buscar_nf]    Script Date: 13/7/2023 13:00:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--create PROC [dbo].[buscar_nf]
CREATE PROC [dbo].[buscar_nf]
--ALTER PROC [dbo].[buscar_nf]
@Documento INT
AS
BEGIN
	SELECT * FROM NucleoFamiliar P
	left join Socios on p.SocId = Socios.SocId 
	WHERE P.SocId = @Documento
	and NFActivo = 1
	and Socios.SocAtivo = 1
END


--select * from Socios
GO

/****** Object:  StoredProcedure [dbo].[buscar_cuotaSocio]    Script Date: 13/7/2023 13:00:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[buscar_cuotaSocio]
--ALTER PROC [dbo].[buscar_cuotaSocio]
@Documento INT
AS
BEGIN
	SELECT P.* FROM CuotaSocio P
	left join Socios on p.SocId = Socios.SocId 
	WHERE p.SocId = @Documento
	and socios.SocAtivo = 1
END
GO

/****** Object:  StoredProcedure [dbo].[buscar_socio_x_cedula]    Script Date: 19/7/2023 22:02:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--create PROC [dbo].[buscar_socio_x_cedula]
CREATE PROC [dbo].[buscar_socio_x_cedula]
@Documento INT
AS
BEGIN
	SELECT * FROM Socios P
	WHERE SocCI = @Documento
END
GO

/****** Object:  StoredProcedure [dbo].[modificar_TC]    Script Date: 19/7/2023 22:04:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--create PROCEDURE [dbo].[modificar_TC]
CREATE PROCEDURE [dbo].[modificar_TC]
@Id int,
@TCDescripcion nchar(100),
@TCMonto int,
@UsuIdModif INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM TipoCuota WHERE TCId = @Id)
	BEGIN
		RETURN -1
	END
	ELSE
	BEGIN 
		UPDATE TipoCuota set TCDescripcion = @TCDescripcion,TCMonto = @TCMonto,
							FecModif = getdate(), UsuIdModif = @UsuIdModif	
						where TCId = @Id
			IF @@ERROR <> 0
			BEGIN
				RETURN -2
			END	
			RETURN 1	
	END	
END
GO

/****** Object:  StoredProcedure [dbo].[modificar_cuota]    Script Date: 19/7/2023 22:03:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--create PROCEDURE [dbo].[modificar_cuota]
CREATE PROCEDURE [dbo].[modificar_cuota]
@SocId int,
@CuotaTipo int,
@UsuIdModif int,
@CuotaId INT OUTPUT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Socios WHERE SocCI = @SocId)
	BEGIN
		RETURN -1
	END
	--SET @CuotaId = (SELECT S.SocId FROM Socios S  WHERE S.SocId = @SocId)	
	--IF NOT EXISTS(SELECT * FROM Socios S WHERE S.SocId = @SocCI)
	--	BEGIN
	--		RETURN -2
	--	END
	--ELSE
	BEGIN TRAN			
		UPDATE CuotaSocio SET CuotaTipo = @CuotaTipo,
							FecModif = GETDATE(),
							UsuIdModif = @UsuIdModif
							WHERE SocId = @SocId	
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			RETURN -2
		END	
	COMMIT TRAN
	RETURN 1	
END

GO

/****** Object:  StoredProcedure [dbo].[modificar_nf]    Script Date: 19/7/2023 22:03:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[modificar_nf]
--ALTER PROCEDURE [dbo].[modificar_nf]

@Id int,
@NFCI int,
@SocId int,
@NFPrimerApellido VARCHAR (50),
@NFSegundoApellido VARCHAR (50),
@NFPrimerNombre VARCHAR (50),
@NFSegundoNombre VARCHAR (50),
@NFTipoVinculo VARCHAR (50),
@NFTel VARCHAR (20),
@NFCelular VARCHAR (10),
@NFObservaciones VARCHAR (250),
@NFFechaNacimiento datetime,
@FecModif datetime,
@UsuIdModif int,
@NFId INT OUTPUT
AS
BEGIN
	IF NOT EXISTS(SELECT socid FROM Socios WHERE SocId = @SocId)
	BEGIN
		RETURN -1
	END
	SET @NFId = (SELECT NFId FROM NucleoFamiliar WHERE NFId = @Id)	
	IF NOT EXISTS(SELECT * FROM NucleoFamiliar nf WHERE nf.NFId = @Id)
		BEGIN
			RETURN -2
		END
	ELSE
	BEGIN TRAN			
		UPDATE NucleoFamiliar SET NFCI = @NFCI, NFPrimerApellido = @NFPrimerApellido, NFSegundoApellido = @NFSegundoApellido,
						  NFPrimerNombre = @NFPrimerNombre, NFSegundoNombre = @NFSegundoNombre, NFTipoVinculo = @NFTipoVinculo,
						  NFTel = @NFTel, NFCelular = @NFCelular, NFObservaciones = @NFObservaciones,
						  NFFechaNacimiento = @NFFechaNacimiento, FecModif = @FecModif, UsuIdModif = @UsuIdModif
					  WHERE NFId = @NFId	
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			RETURN -3
		END	
	COMMIT TRAN
	RETURN 1	
END

--select * from NucleoFamiliar
GO

/****** Object:  StoredProcedure [dbo].[modificar_socio]    Script Date: 19/7/2023 22:03:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[modificar_socio]
--ALTER PROCEDURE [dbo].[modificar_socio]
@SocCI int,
@SocPrimerApellido VARCHAR (50),
@SocSegundoApellido VARCHAR (50),
@SocPrimerNombre VARCHAR (50),
@SocSegundoNombre VARCHAR (50),
@SocDireccion varchar(100),
@SocTel varchar(20),
@SocCelular varchar(10),
@SocEmail varchar(50),
@SocObservaciones varchar(250),
@SocTipoCuota int,
@UsuIdModif INT,
@SocId INT OUTPUT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Socios WHERE SocCI = @SocCI)
	BEGIN
		RETURN -1
	END
	--SET @SocCI = (SELECT S.SocCI FROM Socios S  WHERE S.SocId = @SocCI)	
	--IF NOT EXISTS(SELECT * FROM Socios S WHERE S.SocCI = @SocCI)
	--	BEGIN
	--		RETURN -2
	--	END
	ELSE
	BEGIN TRAN			
		UPDATE Socios SET SocPrimerApellido = @SocPrimerApellido, SocSegundoApellido = @SocSegundoApellido,
						  SocPrimerNombre = @SocPrimerNombre, SocSegundoNombre = @SocSegundoNombre,
						  SocDireccion = @SocDireccion, SocObservaciones = @SocObservaciones,
						  SocTel = @SocTel, SocCelular = @SocCelular,
						  SocEmail = @SocEmail, SocTipoCuota = @SocTipoCuota,
						  FecModif = GETDATE(), UsuIdModif = @UsuIdModif
					  WHERE SocCI = @SocCI	
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			RETURN -4
		END	
	COMMIT TRAN
	RETURN 1	
END

GO

/****** Object:  StoredProcedure [dbo].[PagoCuotaSocio]    Script Date: 19/7/2023 22:04:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--create PROC [dbo].[PagoCuotaSocio]
--CREATE PROC [dbo].[PagoCuotaSocio]
--@IdCuota INT,
--@IdSocio INT,
--@CuotaFechaPaga datetime,
--@FechaModifica DATE,
--@UsuIdModifica INT

--AS
--BEGIN
--	IF NOT EXISTS(SELECT * FROM CuotaSocio WHERE SocId = @IdSocio and CuotaId = @IdCuota)
--	BEGIN
--		RETURN -1
--	END
--	ELSE
--	BEGIN 
--		UPDATE CuotaSocio SET CuotaPaga = 1, FecModif = @FechaModifica, UsuIdModif = @UsuIdModifica, CuotaFechaPaga = @CuotaFechaPaga 
--		where SocId = @IdSocio and CuotaId = @IdCuota 
--		IF @@ERROR <> 0
--		BEGIN
--			RETURN -2
--		END		
--		RETURN 1	
--	END
--END
--GO

--create PROC [dbo].[PagoCuotaSocio]
ALTER PROC [dbo].[PagoCuotaSocio]
@IdCuota INT,
@IdSocio INT,
@UsuIdModifica INT
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM CuotaSocio WHERE SocId = @IdSocio and CuotaId = @IdCuota)
	BEGIN
		RETURN -1
	END
	ELSE
	BEGIN 
		UPDATE CuotaSocio SET CuotaPaga = 1, FecModif = SYSDATETIME(), UsuIdModif = @UsuIdModifica, CuotaFechaPaga = SYSDATETIME()
		where SocId = @IdSocio and CuotaId = @IdCuota 
		IF @@ERROR <> 0
		BEGIN
			RETURN -2
		END		
		RETURN 1	
	END
END
GO
CREATE PROCEDURE [dbo].[activar_socio]
--ALTER PROCEDURE [dbo].[activar_socio]
@SocCI int,
@UsuIdModif int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Socios WHERE SocCI = @SocCI)
	BEGIN
		RETURN -1
	END
	BEGIN TRAN			
		UPDATE Socios SET SocAtivo = 1,
						  FecModif = GETDATE(),
						  UsuIdModif = @UsuIdModif
					   WHERE SocCI = @SocCI	
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			RETURN -2
		END	
	COMMIT TRAN
	RETURN 1	
END
GO

exec alta_TC 'Policial', 850, 1
GO
exec alta_TC 'Civil', 950, 1
GO
exec alta_TC 'Policlínica', 600, 1
GO
exec alta_TC 'Retirado Policial', 800, 1
GO
exec alta_TC 'Socio Policial', 700, 1
GO


--select * from TipoCuota

select * from NucleoFamiliar