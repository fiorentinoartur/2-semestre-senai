--DQL
/*
--Selecionar eventos nos próximos 7 dias
--Calcular a diferença em DIAS do próximo evento
--Atualizar o nome de um evento específico para " - Adiado"
*/

SELECT *
FROM Eventos
WHERE DataEvento BETWEEN GETDATE() AND DATEADD(DAY,7, GETDATE())



SELECT 
    Nome,
    DATEDIFF(DAY, GETDATE(),DataEvento)AS Dias
FROM Eventos



UPDATE Eventos
SET nome = CONCAT( Nome,'- Adiado')
WHERE IdEvento = 1;

SELECT*FROM Eventos