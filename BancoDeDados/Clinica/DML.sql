--DML DATA MANIPULATION LANGUAGE

INSERT INTO TipoDeUsuario VALUES('Administrador'),('Paciente'),('M�dico')

INSERT INTO Usuario VALUES(3,'medico@health.com','1234'),(2,'paciente@health.com','4567')

INSERT INTO Paciente VALUES(2,'Artur','49957976885')

INSERT INTO Clinica VALUES('FioreLife','00008957384792','Rua Niter�i 180','Seg � Sex 8h �s 17h','Sa�de Brasil LTDA')

INSERT INTO Especialidade VALUES('Pediatra'),('Oftalmologista')

INSERT INTO Medico VALUES(1,1,1,'Carl�o','536768')

INSERT INTO PresencaConsulta VALUES(2,1)

INSERT INTO Prontuario VALUES('Infec��o na garganta')

INSERT INTO Consulta VALUES(2,2,1,1,'2023-08-31')

INSERT INTO FeedBacks VALUES(2,'Exelente atendimento, �timos profissionais!!!.')

select * from Consulta
select * from TipoDeUsuario
select * from Usuario
select * from Paciente
select * from Clinica
select * from Medico
select * from PresencaConsulta
select * from Prontuario
select * from FeedBacks
select * from Especialidade

