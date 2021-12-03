IF OBJECT_ID('spListarComando') IS NOT NULL
	DROP PROCEDURE spListarComando
GO
CREATE PROCEDURE spListarComando (
	@ID INT,
	@NOME VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL,
	@CAMINHO VARCHAR(255) = NULL,
	@ARGUMENTO VARCHAR(255) = NULL,
	@EXECUTAVEL BIT = NULL,
	@ATUALIZADOEM DATETIME = NULL
)
AS
	BEGIN
	
		SELECT 
			Id, 
			Nome, 
			Descricao,
			Caminho, 
			Executavel, 
			CadastradoEm,
			AtualizadoEm 
		FROM
			Comando 
		WHERE
			Nome = ISNULL(@NOME, Nome)
		AND
			Descricao = ISNULL(@DESCRICAO, Descricao)
		AND
			Caminho = ISNULL(@CAMINHO, Caminho)
		AND
			Executavel = ISNULL(@EXECUTAVEL, Executavel)
		AND
			Argumento = ISNULL(@ARGUMENTO, Argumento)
		AND
			AtualizadoEM = ISNULL(@ATUALIZADOEM, AtualizadoEm)
		AND
			Id = @ID
	
	END