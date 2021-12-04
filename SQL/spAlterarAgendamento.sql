IF OBJECT_ID('spAlterarAgendamento') IS NOT NULL
	DROP PROCEDURE spAlterarAgendamento
GO
CREATE PROCEDURE spAlterarAgendamento (
	@ID INT,
	@NOME VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL,
	@HORARIO DATETIME = NULL,
	@ATUALIZADOEM DATETIME = NULL
)
AS
	BEGIN
	
		UPDATE 
			Agendamento 
		SET
			Nome 	  	 = ISNULL(@NOME, Nome),
			Descricao 	 = ISNULL(@DESCRICAO, Descricao),
			Horario   	 = ISNULL(@HORARIO, Horario),
			AtualizadoEM = ISNULL(@ATUALIZADOEM, AtualizadoEm)
		WHERE
			Id = @ID
	
	END