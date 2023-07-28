--Reliza la consulta de un Registro 
CREATE PROCEDURE dbo.Consulta_Registro_Grafica
	@Tabla nvarchar(MAX),
	@Columna nvarchar(MAX),
	@Intervalo_Entre_Dato int = 0,
	@Puntero_inicio int= 0,
	@Puntero_final int= 0
AS
BEGIN
SELECT @Columna FROM @Tabla WHERE Puntero>=@Puntero_inicio  and Puntero<=@Puntero_final and  (Puntero % @Intervalo_Entre_Dato)=0
end 


