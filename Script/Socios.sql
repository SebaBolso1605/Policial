USE [Policial]
GO

/****** Object:  Table [dbo].[Socios]    Script Date: 10/4/2022 0:02:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Socios](
	[SocId] [int] NOT NULL,
	[SocPrimerApellido] [varchar](50) NOT NULL,
	[SocSegundoApellido] [varchar](50) NULL,
	[SocPrimerNombre] [varchar](50) NOT NULL,
	[SocSegundoNombre] [varchar](50) NULL,
	[SocCI] [varchar](10) NOT NULL,
	[SocFechaNacimiento] [datetime] NULL,
	[SocDireccion] [varchar](100) NULL,
	[SocTel] [varchar](20) NULL,
	[SocEmail] [varchar](50) NULL,
	[SocAtivo] [bit] NOT NULL,
	[SocObservaciones] [varchar](250) NULL,
	[FecAlta] [datetime] NOT NULL,
	[FecModif] [datetime] NOT NULL,
	[UsuIdModif] [int] NOT NULL,
	[UsuIdAlta] [int] NOT NULL
) ON [PRIMARY]
GO

