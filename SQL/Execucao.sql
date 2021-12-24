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