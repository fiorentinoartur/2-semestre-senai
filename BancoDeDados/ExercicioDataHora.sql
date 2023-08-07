--DDL CRIAR TABELAS E BANCO DE DADOS

--CRIAR BANCO 
CREATE DATABASE Exercicio

--USAR BANCO
USE Exercicio

--CRIAR TABELAS

--Manipulação de Datas e Horas


CREATE TABLE eventos (
    id INT PRIMARY KEY,
    nome TEXT,
    data_evento DATE,
    hora_evento TIME
);

INSERT INTO eventos (id, nome, data_evento, hora_evento)
VALUES
    (1, 'Evento A', '2023-08-10', '15:00:00'),
    (2, 'Evento B', '2023-08-12', '18:30:00'),
    (3, 'Evento C', '2023-08-15', '09:45:00'),
    (4, 'Evento D', '2023-08-18', '14:15:00');



--Selecionar eventos nos próximos 7 dias:

	SELECT *
FROM eventos
WHERE data_evento BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 7 DAY)
ORDER BY data_evento, hora_evento;


--Calcular a diferença em horas e minutos entre a hora atual e a hora do próximo evento:
SELECT 
    nome,
    TIMEDIFF(hora_evento, CURTIME()) AS diferenca
FROM eventos
WHERE data_evento >= CURDATE() AND hora_evento >= CURTIME()
ORDER BY data_evento, hora_evento
LIMIT 1;




--Atualizar o nome de um evento específico para " - Adiado":

UPDATE eventos
SET nome = CONCAT(nome, ' - Adiado')
WHERE id = 1;

SELECT*FROM eventos