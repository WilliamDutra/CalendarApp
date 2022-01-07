IF OBJECT_ID('spListarComando') IS NOT NULL
	DROP PROCEDURE spListarComando
GO
CREATE PROCEDURE spListarComando (
	@ID INT,
	@NOME VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL,
	@CAMINHO VARCHAR(255) = NULL,
	@ARGUMENTO VARCHAR(255) = NULL,
	@EXECUTAVEL BIT = NULL
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
			Id = ISNULL(@ID, Id)
	
	END