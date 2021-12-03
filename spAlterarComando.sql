IF OBJECT_ID('spAlterarComando') IS NOT NULL
	DROP PROCEDURE spAlterarComando
GO
CREATE PROCEDURE spAlterarComando (
	@ID INT,
	@NOME VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL,
	@ARGUMENTO VARCHAR(255) = NULL,
	@CAMINHO VARCHAR(255) = NULL,
	@EXECUTAVEL BIT = NULL,
	@ATUALIZADOEM DATETIME = NULL
)
AS
	BEGIN
	
		UPDATE 
			Comando 
		SET
			Nome 	  	 = ISNULL(@NOME, Nome),
			Descricao 	 = ISNULL(@DESCRICAO, Descricao),
			Caminho   	 = ISNULL(@CAMINHO, Caminho),
			Executavel	 = ISNULL(@EXECUTAVEL, Executavel),
			Argumento	 = ISNULL(@ARGUMENTO, Argumento),
			AtualizadoEM = ISNULL(@ATUALIZADOEM, AtualizadoEm)
		WHERE
			Id = @ID
	
	END