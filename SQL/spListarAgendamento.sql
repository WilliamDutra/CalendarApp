IF OBJECT_ID('spListarAgendamento') IS NOT NULL
	DROP PROCEDURE spListarAgendamento
GO
CREATE PROCEDURE spListarAgendamento (
	@ID INT = NULL,
	@NOME VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL,
	@HORARIO DATETIME = NULL
)
AS
	BEGIN
	
		SELECT 
			Id, 
			Nome, 
			Descricao,
			Horario, 
			CadastradoEm,
			AtualizadoEm 
		FROM
			Agendamento 
		WHERE
			Nome = ISNULL(@NOME, Nome)
		AND
			Descricao = ISNULL(@DESCRICAO, Descricao)
		AND
			Horario = ISNULL(@HORARIO, Horario)
		AND
			Id = ISNULL(@ID, Id)
	
	END