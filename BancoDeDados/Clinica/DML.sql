--DML DATA MANIPULATION LANGUAGE

INSERT INTO TipoDeUsuario VALUES('Administrador'),('Paciente'),('Médico')

INSERT INTO Usuario VALUES(3,'Carlão','medico@health.com','1234','1980-08-03'),(2,'Artur','paciente@health.com','4567','2006-12-15')

INSERT INTO Paciente VALUES(2,'49957976885')

INSERT INTO Clinica VALUES('FioreLife','00008957384792','Rua Niterói 180','Seg à Sex 8h às 17h','Saúde Brasil LTDA')

INSERT INTO Especialidade VALUES('Pediatra'),('Oftalmologista')

INSERT INTO Medico VALUES(1,1,1,'536768')

INSERT INTO Situacao VALUES(1)

INSERT INTO Prontuario VALUES('Infecção na garganta')

INSERT INTO Consulta VALUES(1,1,1,1,1,'2023-08-31','09:00:00')

INSERT INTO FeedBacks VALUES(1,'Exelente atendimento, ótimos profissionais!!!.')

select * from Consulta
select * from TipoDeUsuario
select * from Usuario
select * from Paciente
select * from Clinica
select * from Medico
select * from Situacao
select * from Prontuario
select * from FeedBacks
select * from Especialidade

