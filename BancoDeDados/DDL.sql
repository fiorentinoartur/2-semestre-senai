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
Titulo VARCHAR(50) NOT NULL UNIQUE 
)
delete from Genero where IdGenero = 2;
select * from Genero

drop table Filme

select * from Filme
select * from Genero


INSERT INTO Filme VALUES(4,'Rei Artur')

SELECT 
Filme.Titulo,
Genero.Nome AS [Gênero]
FROM
Filme
join Genero on Filme.IdGenero = Genero.IdGenero