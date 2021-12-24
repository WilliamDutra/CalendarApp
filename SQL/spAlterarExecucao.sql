IF OBJECT_ID('spAlterarExecucao') IS NOT NULL
	DROP PROCEDURE spAlterarExecucao
GO
CREATE PROCEDURE spAlterarExecucao (
	@ID INT,
	@IDAGENDAMENTO INT = NULL,
	@IDCOMANDO INT = NULL,
	@DATA DATETIME = NULL,
	@HORARIO DATETIME = NULL,
	@EXECUTADO BIT = NULL,
	@MENSAGEMRETORNO VARCHAR(255) = NULL,
	@ATUALIZADOEM DATETIME
)
AS
	BEGIN
		
		UPDATE 
			Execucao
		SET
			AgendamentoId	= ISNULL(@IDAGENDAMENTO, AgendamentoId),
			ComandoId		= ISNULL(@IDCOMANDO, ComandoId),
			Data			= ISNULL(@DATA, Data),
			Executado		= ISNULL(@EXECUTADO, Executado),
			Horario			= ISNULL(@HORARIO, Horario),
			AtualizadoEm	= ISNULL(@ATUALIZADOEM, AtualizadoEm)
		WHERE
			Id = @ID

	END