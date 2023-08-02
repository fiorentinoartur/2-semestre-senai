--DML Inserir os dados nas tabelas

--USAR O BANCO
USE Exercicio_1_2

--INSERIR DADOS NA TABELA
INSERT INTO Cliente(Nome,CPF)
VALUES('Artur','35793574'),('Carlos','424542342')


INSERT INTO Empresa(Nome)
VALUES('ArturCar'),('CarlosCar')

INSERT INTO Marca(Nome)
VALUES('BMW'),('VW')

INSERT INTO Modelo(Nome)
VALUES('X4'),('Nivus')

INSERT INTO Veiculo(IdEmpresa,IdModelo,IdMarca,Placa)
VALUES(1,1,1,'BMW-123'),(2,2,2,'VW-456')

INSERT INTO Aluguel(IdVeiculo,IdCliente,Protocolo)
VALUES(1,1,'5g2ert43'),(2,2,'4t3t3r4')

SELECT * FROM Cliente
SELECT * FROM Empresa
SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Veiculo
SELECT * FROM Aluguel