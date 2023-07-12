USE [Policial]
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

