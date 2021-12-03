﻿IF OBJECT_ID('Comando') IS NOT NULL
	DROP TABLE Comando
GO
CREATE TABLE Comando (
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100),
	Descricao VARCHAR(100) NULL,
	Caminho VARCHAR(255),
	Argumento VARCHAR(255) NULL,
	Executavel BIT,
	CadastradoEm DATETIME,
	AtualizadoEm DATETIME
)