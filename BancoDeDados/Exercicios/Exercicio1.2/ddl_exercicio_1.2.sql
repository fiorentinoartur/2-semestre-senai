--DDL CRIAR BANCOS E TABELAS

--CRIAR UM BANCO
CREATE DATABASE Exercicio_1_2

--USAR O BANCO
USE Exercicio_1_2

--CRIAR TABELAS

--CLIENTE
CREATE TABLE Cliente
(
IdCliente INT PRIMARY KEY IDENTITY,
Nome VARCHAR(20) NOT NULL,
CPF VARCHAR(10) NOT NULL UNIQUE
)

----------------------------------------

--EMPRESA
CREATE TABLE Empresa
(
IdEmpresa INT PRIMARY KEY IDENTITY,
Nome VARCHAR(10) NOT NULL 
)

----------------------------------------

--MARCA
CREATE TABLE Marca
(
IdMarca INT PRIMARY KEY IDENTITY,
Nome VARCHAR(10) NOT NULL 
)

----------------------------------------

--MODELO
CREATE TABLE Modelo
(
IdModelo INT PRIMARY KEY IDENTITY,
Nome VARCHAR(10) NOT NULL 
)
---------------------------------------------------------

--VEICULO
CREATE TABLE Veiculo
(
IdVeiculo INT PRIMARY KEY IDENTITY,
IdEmpresa INT FOREIGN KEY REFERENCES Empresa(IdEmpresa) NOT NULL,
IdModelo INT FOREIGN KEY REFERENCES Modelo(IdModelo) NOT NULL,
IdMarca INT FOREIGN KEY REFERENCES Marca(IdMarca) NOT NULL,
Placa VARCHAR(7) NOT NULL UNIQUE
)

--------------------------------------------

--ALUGUEL
CREATE TABLE Aluguel
(
IdAluguel INT PRIMARY KEY IDENTITY,
IdVeiculo INT FOREIGN KEY REFERENCES Veiculo(IdVeiculo) NOT NULL,
IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente) NOT NULL,
Protocolo VARCHAR(10) NOT NULL UNIQUE
)

-----------------------------------------------


SELECT * FROM Cliente
SELECT * FROM Empresa

