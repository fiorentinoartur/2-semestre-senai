--DML  DATA MANIPULATION LANGUAGE

 USE [Event+_Manha]

 --INSERIR DADOS NAS TABELAS 
INSERT INTO TipoUsuario VALUES('Administrador'),('Comum')

INSERT INTO TipoEvento VALUES('SQL Server')

INSERT INTO Instituicao VALUES('12345678901234','Rua Niterói 180','DevSchool')

INSERT INTO Usuario VALUES(1,'Artur','admin@admin.com','admin1234')

INSERT INTO Evento VALUES(1,1,'Introdução ao Banco de Dados SQL Server','Aprenda conceitos básicos do SQL Server','2023-08-10','10:00:00')

INSERT INTO PresencasEvento VALUES(1,1,0)

INSERT INTO ComentarioEvento VALUES(1,1,'Excelente Evento, Professores top!',1)