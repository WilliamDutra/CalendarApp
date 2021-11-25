IF OBJECT_ID('spSalvarAgendamento') IS NOT NULL
	DROP PROCEDURE spSalvarAgendamento
GO
CREATE PROCEDURE spSalvarAgendamento (
	@NOME VARCHAR(100),
	@DESCRICAO VARCHAR(255) = NULL,
	@HORARIO DATETIME,
	@CADASTRADOEM DATETIME,
	@ATUALIZADOEM DATETIME
)
AS
	BEGIN 
		INSERT INTO Agendamento 
			( 
				Nome, 
				Descricao, 
				Horario,
				CadastradoEm, 
				AtualizadoEm 
			) 
		VALUES ( 
					@NOME,
					@DESCRICAO,
					@HORARIO, 
					@CADASTRADOEM,
					@ATUALIZADOEM 
				)

	SELECT SCOPE_IDENTITY();
END