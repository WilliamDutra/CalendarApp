IF OBJECT_ID('spListarExecucao') IS NOT NULL
	DROP PROCEDURE spListarExecucao
GO
CREATE PROCEDURE spListarExecucao (
	@ID INT = NULL,
	@IDAGENDAMENTO INT = NULL,
	@IDCOMANDO INT = NULL
)
AS
	BEGIN
		
		SELECT 
			Id,
			AgendamentoId,
			ComandoId,		
			Data,			
			Executado,		
			Horario,			
			AtualizadoEm	
		FROM
			Execucao
		WHERE
			Id			  = ISNULL(@ID, Id) AND
			AgendamentoId = ISNULL(@IDAGENDAMENTO, AgendamentoId) AND
			ComandoId	  = ISNULL(@IDCOMANDO, ComandoId)

	END
