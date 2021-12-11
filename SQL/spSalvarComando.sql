﻿IF OBJECT_ID('spSalvarComando') IS NOT NULL
	DROP PROCEDURE spSalvarComando
GO
CREATE PROCEDURE spSalvarComando (
	@NOME VARCHAR(100),
	@NOMEARQUIVO VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL,
	@CAMINHO VARCHAR(255) = NULL,
	@ARGUMENTO VARCHAR(255) = NULL,
	@EXECUTAVEL BIT,
	@CADASTRADOEM DATETIME,
	@ATUALIZADOEM DATETIME
)
AS
	BEGIN
		
		INSERT INTO
		Comando 
		(
			Nome,
			NomeArquivo,
			Descricao,
			Caminho,
			Argumento,
			Executavel,
			CadastradoEm,
			AtualizadoEm
		)
		VALUES
		(
			@NOME,
			@NOMEARQUIVO,
			@DESCRICAO,
			@CAMINHO,
			@ARGUMENTO,
			@EXECUTAVEL,
			@CADASTRADOEM,
			@ATUALIZADOEM
		)

		SELECT SCOPE_IDENTITY();

	END