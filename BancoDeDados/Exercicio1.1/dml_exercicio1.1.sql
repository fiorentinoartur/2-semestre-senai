--DML - INSERIR DADOS NAS TABELAS

--USAR O BANCO
USE Exercicio_1_1

--INSERIR DADOS NA TABELA
INSERT INTO Pessoa(Nome,CNH)
VALUES('Artur','1234567891'),('Edu','1234567871')

--INSERT INTO Pessoa VALUES('Artur','1234567891')
INSERT INTO Email(IdPessoa, Endereco)
VALUES(5,'artur@email.com'),(6,'edu@email.com')

INSERT INTO Telefone(IdPessoa, Numero)
VALUES(5,'42554525'),(6,'25552354325')


SELECT * FROM Pessoa
SELECT * FROM Email
SELECT * FROM Telefone
