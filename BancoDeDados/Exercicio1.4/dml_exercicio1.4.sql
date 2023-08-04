--DML INSERIR DADOS NAS TABELAS

--USAR BANCO
USE Optus
 
--INSERIR DADOS NAS TABELAS
INSERT INTO Artistas(Nome)
VALUES('Artur'),('Edu')

INSERT INTO Estilos(Nome)
VALUES('Artur'),('Edu')

INSERT INTO Usuarios(Nome,Email,Senha,Permissao)
VALUES('turzin','turzin@gmail.com','32442','comum'),('dudu','dudu@gmail.com','25445','adm')

INSERT INTO Albuns(IdArtista,Titulo,DataLancamento,Localizacao,QtdMinutos,Ativo)
VALUES(1,'Fé','20/02/2023','Copacabana','60','sim'),(2,'Senai','20/05/2023','Cotia','120','não')

INSERT INTO AlbunsEstilos(IdAlbum,IdEstilo)
VALUES(1,1),(2,2)

SELECT * FROM  Artistas
SELECT * FROM  Estilos
SELECT * FROM  Usuarios
SELECT * FROM  Albuns
SELECT * FROM  AlbunsEstilos