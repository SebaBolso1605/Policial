USE [Policial]
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


