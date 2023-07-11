USE [Policial]
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
