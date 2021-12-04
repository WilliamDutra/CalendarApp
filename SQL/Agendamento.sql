﻿IF OBJECT_ID('Agendamento') IS NOT NULL
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