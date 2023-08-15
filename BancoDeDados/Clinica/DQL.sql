--DQL

CREATE FUNCTION QtdMedico(@IdEspecialidade INT)
RETURNS TABLE
AS 
RETURN
(SELECT 
Medico.Nome,Clinica.NomeFantasia AS [Clínica], Especialidade.Titulo AS [Especialidade]
FROM 
Medico
inner  join Clinica on Clinica.IdClinica = Medico.IdClinica
inner join Especialidade on Especialidade.IdEspecialidade =  Medico.IdEspecialidade
where Medico.IdEspecialidade = @IdEspecialidade
)

SELECT * FROM QtdMedico(1)
SELECT * FROM Medico
DROP FUNCTION QtdMedico

