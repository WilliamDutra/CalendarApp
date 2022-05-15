IF OBJECT_ID('Agendamento') IS NOT NULL
	DROP TABLE Agendamento
GO
CREATE TABLE Agendamento (
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100),
	Descricao VARCHAR(255) NULL,
	Horario DATETIME,
	CadastradoEm DATETIME,
	AtualizadoEm DATETIME
)
GO
IF OBJECT_ID('Comando') IS NOT NULL
	DROP TABLE Comando
GO
CREATE TABLE Comando (
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100),
	NomeArquivo VARCHAR(100) NULL,
	Descricao VARCHAR(100) NULL,
	Caminho VARCHAR(255) NULL,
	Argumento VARCHAR(255) NULL,
	Executavel BIT,
	CadastradoEm DATETIME,
	AtualizadoEm DATETIME
)
GO
IF OBJECT_ID('Execucao') IS NOT NULL
	DROP TABLE Execucao
GO
CREATE TABLE Execucao (
	Id INT PRIMARY KEY IDENTITY,
	AgendamentoId INT,
	ComandoId INT,
	Data DATETIME,
	Horario DATETIME,
	MensagemRetorno VARCHAR(255) NULL,
	Executado BIT NULL,
	CadastradoEm DATETIME,
	AtualizadoEm DATETIME
)
GO
IF OBJECT_ID('spSalvarExecucao') IS NOT NULL
	DROP PROCEDURE spSalvarExecucao
GO
CREATE PROCEDURE spSalvarExecucao (
	@IDAGENDAMENTO INT,
	@IDCOMANDO INT,
	@DATA DATETIME,
	@HORARIO DATETIME,
	@EXECUTADO BIT,
	@CADASTRADOEM DATETIME,
	@ATUALIZADOEM DATETIME
)
AS
	BEGIN
		
		INSERT INTO 
		Execucao 
		(
			AgendamentoId,
			ComandoId,
			Data,
			Horario,
			Executado,
			CadastradoEm,
			AtualizadoEm
		)
		VALUES
		(
			@IDAGENDAMENTO,
			@IDCOMANDO,
			@DATA,
			@HORARIO,
			@EXECUTADO,
			@CADASTRADOEM,
			@ATUALIZADOEM
		)

		SELECT SCOPE_IDENTITY();

	END
GO
IF OBJECT_ID('spSalvarComando') IS NOT NULL
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
GO
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
GO
IF OBJECT_ID('spListarExecucaoAgendamento') IS NOT NULL
	DROP PROCEDURE spListarExecucaoAgendamento
GO
CREATE PROCEDURE spListarExecucaoAgendamento (
	@ID INT = NULL,
	@NOME VARCHAR(100) = NULL,
	@DESCRICAO VARCHAR(255) = NULL
)
AS
	BEGIN
	
		SELECT 
			AGENDAMENTO.Nome,
			AGENDAMENTO.Descricao,
			AGENDAMENTO.Id,
			AGENDAMENTO.Horario,
			COUNT(AGENDAMENTO.Id) AS 'QtdExecucoes'
		FROM 
			Agendamento AGENDAMENTO
		INNER JOIN
			Execucao EXECUCAO
		ON
			AGENDAMENTO.Id = EXECUCAO.AgendamentoId
		WHERE
			AGENDAMENTO.Nome 	  	 = ISNULL(@NOME, AGENDAMENTO.Nome) AND
			AGENDAMENTO.Descricao 	 = ISNULL(@DESCRICAO, AGENDAMENTO.Descricao) AND
			AGENDAMENTO.Id			 = ISNULL(@ID, AGENDAMENTO.Id)
		GROUP BY
			AGENDAMENTO.Nome,
			AGENDAMENTO.Descricao,
			AGENDAMENTO.Id,
			AGENDAMENTO.Horario
		
	END
GO
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
GO
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
GO
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
			COMANDO.NomeArquivo,
			EXECUCAO.AgendamentoId,
			EXECUCAO.Horario,
			Execucao.Data,
			EXECUCAO.AtualizadoEm,
			AGENDAMENTO.Descricao,
			AGENDAMENTO.Id,
			EXECUCAO.Id AS 'ExecucaoId'
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
			AGENDAMENTO.Id			 = ISNULL(@ID, AGENDAMENTO.Id) AND
			EXECUCAO.Executado = 0
		
	END
GO
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
GO
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
GO
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
GO
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
GO