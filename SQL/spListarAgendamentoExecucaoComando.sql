IF OBJECT_ID('spListarAgendamentoExecucaoComando') IS NOT NULL
	DROP PROCEDURE spListarAgendamentoExecucaoComando
GO
CREATE PROCEDURE spListarAgendamentoExecucaoComando (
	@ID INT = NULL,
	@NOME VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL
)
AS
	BEGIN
	
		SELECT 
			COMANDO.Caminho,
			COMANDO.Argumento,
			COMANDO.Nome,
			EXECUCAO.AgendamentoId,
			AGENDAMENTO.Horario,
			Execucao.Data,
			EXECUCAO.AtualizadoEm,
			AGENDAMENTO.Descricao,
			AGENDAMENTO.Id
		FROM 
			Agendamento AGENDAMENTO
		INNER JOIN
			Execucao EXECUCAO
		ON
			AGENDAMENTO.Id = EXECUCAO.AgendamentoId
		INNER JOIN
			Comando COMANDO
		ON
			COMANDO.Id = EXECUCAO.ComandoId
		WHERE
			AGENDAMENTO.Nome 	  	 = ISNULL(@NOME, AGENDAMENTO.Nome) AND
			AGENDAMENTO.Descricao 	 = ISNULL(@DESCRICAO, AGENDAMENTO.Descricao) AND
			AGENDAMENTO.Id			 = ISNULL(@ID, AGENDAMENTO.Id)
		
	END