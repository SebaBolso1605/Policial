USE [Policial]
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

