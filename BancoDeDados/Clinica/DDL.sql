--DDL DATA DEFINITION LANGUAGE
drop DATABASE FioreLife
CREATE DATABASE FioreLife

USE FioreLife

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
Nome VARCHAR(50) NOT NULL,
Email VARCHAR(256) UNIQUE NOT NULL,
Senha VARCHAR(256) NOT NULL,
DataNascimento DATE NOT NULL
)
CREATE TABLE Especialidade
(
IdEspecialidade INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Medico
(
IdMedico INT PRIMARY KEY IDENTITY,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) UNIQUE NOT NULL,
IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade) NOT NULL,
CRM CHAR(6) UNIQUE NOT NULL 
)
CREATE TABLE Paciente
(
IdPaciente INT PRIMARY KEY IDENTITY, 
IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) UNIQUE NOT NULL,
CPF CHAR(11) NOT NULL
)
CREATE TABLE Situacao
(
IdSituacao INT PRIMARY KEY IDENTITY,
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
IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
IdProntuario INT FOREIGN KEY REFERENCES Prontuario(IdProntuario) NOT NULL,
IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao) NOT NULL,
IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
DataConsulta DATE NOT NULL,
HoraConsulta TIME NOT NULL

)

CREATE TABLE FeedBacks
(
IdFeedBacks INT PRIMARY KEY IDENTITY,
IdConsulta INT FOREIGN KEY REFERENCES Consulta(IdConsulta) NOT NULL,
Descricao VARCHAR(256) NOT NULL
)

