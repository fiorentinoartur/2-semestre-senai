--DML INSERIR DADOS NAS TABELAS

--USAR BANCO
USE Optus
 
--INSERIR DADOS NAS TABELAS
INSERT INTO Artistas(Nome)
VALUES('Artur'),('Edu')

INSERT INTO Estilos(Nome)
VALUES('Rap'),('Rock')

INSERT INTO Usuarios(Nome,Email,Senha,Permissao)
VALUES('turzin','turzin@gmail.com','32442','comum'),('dudu','dudu@gmail.com','25445','adm')

INSERT INTO Albuns(IdArtista,Titulo,DataLancamento,Localizacao,QtdMinutos,Ativo)
VALUES(1,'Brasilia','2023-08-10','Copacabana','60','sim'),(2,'Senai','2023-10-08','Cotia','120','não')

INSERT INTO AlbunsEstilos(IdAlbum,IdEstilo)
VALUES(1,1),(2,2)

SELECT * FROM  Artistas
SELECT * FROM  Estilos
SELECT * FROM  Usuarios
SELECT * FROM  Albuns
SELECT * FROM  AlbunsEstilos