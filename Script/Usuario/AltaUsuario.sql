USE [Policial]
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


exec alta_Usuario 'seba', 'Sebastian', '1234', 1