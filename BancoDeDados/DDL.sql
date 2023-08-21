--DDL
CREATE DATABASE Filmes_Manha

USE Filmes_Manha

CREATE TABLE Genero
(
IdGenero INT PRIMARY KEY IDENTITY,
Nome VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Filme
(
IdFilme INT PRIMARY KEY IDENTITY,
IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero) NOT NULL,
Titulo VARCHAR(50) NOT NULL 
)

select * from Genero