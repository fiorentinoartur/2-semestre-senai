CREATE DATABASE HealthClinic

USE HealthClinic

CREATE TABLE TipoDeUsuario
(
IdTipoDeUsuario INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(20) NOT NULL
)

CREATE TABLE Clinica
(
IdClinica INT PRIMARY KEY IDENTITY,
NomeFantasia VARCHAR(30) NOT NULL ,
CNPJ CHAR(14) NOT NULL,
Endereco VARCHAR(50) NOT NULL,
Funcionamento VARCHAR(80) NOT NULL ,
RazaoSocial VARCHAR(256) NOT NULL
)

CREATE TABLE Usuario
(
IdUsuario INT PRIMARY KEY IDENTITY,
IdTipoDeUsuario INT FOREIGN KEY REFERENCES TipoDeUsuario(IdTipoDeUsuario) NOT NULL,
Email VARCHAR(256) UNIQUE NOT NULL,
Senha VARCHAR(256) NOT NULL
)

CREATE TABLE Medico
(
IdMedico INT PRIMARY KEY IDENTITY,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
Nome VARCHAR(50) NOT NULL,
CRM CHAR(6) UNIQUE NOT NULL 
)
CREATE TABLE Paciente
(
IdPaciente INT PRIMARY KEY IDENTITY, 
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
Nome VARCHAR(50) NOT NULL,
CPF CHAR(11) NOT NULL
)
CREATE TABLE PresencaConsulta
(
IdPresencaConsulta INT PRIMARY KEY IDENTITY,
IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
Situacao BIT NOT NULL
)
CREATE TABLE Prontuario
(
IdProntuario INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(256) NOT NULL
)
CREATE TABLE Consulta
(
IdConsulta INT PRIMARY KEY IDENTITY,
IdPresencaConsulta INT FOREIGN KEY REFERENCES PresencaConsulta(IdPresencaConsulta) NOT NULL,
IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
IdProntuario INT FOREIGN KEY REFERENCES Prontuario(IdProntuario) NOT NULL,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
DataConsulta DATE NOT NULL
)
CREATE TABLE FeedBacks
(
IdFeedBacks INT PRIMARY KEY IDENTITY,
IdConsulta INT FOREIGN KEY REFERENCES Consulta(IdConsulta) NOT NULL,
Descricao VARCHAR(256) NOT NULL
)
