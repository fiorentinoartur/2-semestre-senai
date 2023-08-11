--DDL DATA DEFINITION LANGUAGE

--CRIAR BANCO DE DADOS E TABELAS
CREATE DATABASE [Event+_Manha]

--USAR BANCO
USE [Event+_Manha]


--CRIAR TABELAS
CREATE TABLE TipoUsuario
(
IdTipoUsuario INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(20) NOT NULL UNIQUE
)

-----------------------------------------------------------

CREATE TABLE TipoEvento
(
IdTipoEvento INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(20) NOT NULL UNIQUE
)

-----------------------------------------------------------

CREATE TABLE Instituicao
(
IdInstituicao INT PRIMARY KEY IDENTITY,
CNPJ CHAR(14) NOT NULL UNIQUE,
Endereco VARCHAR(100) NOT NULL,
NomeFantasia VARCHAR(50) NOT NULL
)

DROP TABLE Instituicao

-----------------------------------------------------------

CREATE TABLE Usuario
(
IdUsuario INT PRIMARY KEY IDENTITY,
IdTiPoUsario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario) NOT NULL,
Nome VARCHAR(50) NOT NULL,
Email VARCHAR(256) NOT NULL UNIQUE,
Senha VARCHAR (100) NOT NULL
)

-----------------------------------------------------------------

CREATE TABLE Evento
(
IdEvento INT PRIMARY KEY IDENTITY,
IdTiPoEvento INT FOREIGN KEY REFERENCES TipoEvento(IdTipoEvento) NOT NULL,
IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao) NOT NULL,
Nome VARCHAR(50) NOT NULL,
Descricao VARCHAR(100) NOT NULL,
DataEvento DATE NOT NULL,
HorarioEvento TIME NOT NULL
)
DROP TABLE Evento
-----------------------------------------------------------------

CREATE TABLE PresencasEvento
(
IdPresencasEvento INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
Situacao BIT DEFAULT(0)
)
DROP TABLE PresencasEvento
------------------------------------------------------------------

CREATE TABLE ComentarioEvento
(
IdComentarioEvento INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
Descricao VARCHAR(256) NOT NULL,
Exibe BIT DEFAULT(0)
)
DROP TABLE ComentarioEvento