--DML INSERIR OS DADOS NAS TABELAS

--USAR O BANCO
USE ClinicaPet

--INSERIR DADOS NAS TABELAS
INSERT INTO Clinica(Endereco)
VALUES('Rua Niterói 180')

INSERT INTO Dono(Nome)
VALUES('Artur'),('Carlos')

INSERT INTO TipoPet(Descricao)
VALUES('Gato'),('Cachorro')

INSERT INTO Raca(Descricao)
VALUES('Vira-lata'),('Pitbull')

INSERT INTO Veterinario(IdClinica,Nome,CRMV)
VALUES(1,'Edu','435356'),(1,'Miguel','535356')

INSERT INTO Pet(IdTipoPet,IdRaca,IdDono,Nome,DataNascimento)
VALUES(1,1,1,'Fred','15/02/15'),(2,2,2,'Max','04/06/14')

INSERT INTO Atendimentos(IdVeterinario,IdPet,Descricao,_Data)
VALUES(1,1,'Raio X','21/05/23'),(2,2,'Coleta','10/07/22')




Select * From Clinica
Select * From Dono
Select * From TipoPet
Select * From Raca
Select * From Veterinario
Select * From Pet
Select * From Atendimentos









