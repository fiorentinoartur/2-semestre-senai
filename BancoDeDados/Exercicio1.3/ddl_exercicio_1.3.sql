--DDL CRIA BANCOS E TABELAS

--CRIAR UM BANCO
CREATE DATABASE ClinicaPet

--USAR O BANCO
USE ClinicaPet

--CRIAR TABELAS

--CLINICA
CREATE TABLE Clinica
(
IdClinica INT PRIMARY KEY IDENTITY,
Endereco VARCHAR(20) NOT NULL UNIQUE
)

--------------------------------------

--DONO
CREATE TABLE Dono
(
IdDono INT PRIMARY KEY IDENTITY,
Nome VARCHAR(10) NOT NULL 
)

--------------------------------------

--TIPOPET
CREATE TABLE TipoPet
(
IdTipoPet INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(10) NOT NULL 
)

--------------------------------------

--RACA
CREATE TABLE Raca
(
IdRaca INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(10) NOT NULL 
)

----------------------------------------------

--VETERINARIO
CREATE TABLE Veterinario
(
IdVeterinario INT PRIMARY KEY IDENTITY,
IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
Nome VARCHAR(10) NOT NULL UNIQUE,
CRMV VARCHAR(10) NOT NULL UNIQUE,
)
-------------------------------------------

--PET
CREATE TABLE Pet
(
IdPet INT PRIMARY KEY IDENTITY,
IdTipoPet INT FOREIGN KEY REFERENCES TipoPet(IdTipoPet) NOT NULL,
IdRaca INT FOREIGN KEY REFERENCES Raca(IdRaca) NOT NULL,
IdDono INT FOREIGN KEY REFERENCES Dono(IdDono) NOT NULL,
Nome VARCHAR(10) NOT NULL,
DataNascimento VARCHAR(8) NOT NULL,
)
----------------------------------------------

--VETERINARIO
CREATE TABLE Atendimentos
(
IdAtendimento INT PRIMARY KEY IDENTITY,
IdVeterinario INT FOREIGN KEY REFERENCES Veterinario(IdVeterinario) NOT NULL,
IdPet INT FOREIGN KEY REFERENCES Pet(IdPet) NOT NULL,
Descricao VARCHAR(10) NOT NULL,
_Data VARCHAR(8) NOT NULL,
)

----------------------------------------------




