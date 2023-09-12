CREATE  DATABASE inlock_games;
GO

USE inlock_games;
GO

CREATE TABLE Estudio
(
	IdEstudio INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Jogo
(
	IdJogo INT PRIMARY KEY IDENTITY
	,IdEstudio INT FOREIGN KEY REFERENCES Estudio(IdEstudio)
	,Nome VARCHAR(100) NOT NULL
	,Descricao VARCHAR(100) NOT NULL
	,DataLancamento DATE NOT NULL
	,Valor SMALLMONEY NOT NULL
);
GO

CREATE TABLE TiposUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,Titulo VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
	,Email VARCHAR(100) NOT NULL UNIQUE
	,Senha VARCHAR (100) NOT NULL
);
GO
SELECT * FROM TiposUsuario
SELECT * FROM Usuario

SELECT IdUsuario, Email,Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario 
WHERE Email = 'cliente@cliente.com'  AND Senha = 'cliente'