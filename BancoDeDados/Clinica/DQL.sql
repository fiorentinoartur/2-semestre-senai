--DQL

CREATE FUNCTION QtdMedico(@IdEspecialidade INT)
RETURNS TABLE
AS 
RETURN
(SELECT 
Medico.Nome,Clinica.NomeFantasia AS [Clínica], Especialidade.Titulo AS [Especialidade]
FROM 
Medico
left  join Clinica on Clinica.IdClinica = Medico.IdClinica
left join Especialidade on Especialidade.IdEspecialidade =  Medico.IdEspecialidade
where Medico.IdEspecialidade = @IdEspecialidade
)

SELECT * FROM QtdMedico(1)
SELECT * FROM Medico
DROP FUNCTION QtdMedico


SELECT 
Consulta.IdConsulta,Consulta.DataConsulta,Consulta.HoraConsulta,Clinica.NomeFantasia AS [Clínica],Paciente.Nome AS [Paciente],Medico.Nome AS [Médico],
Especialidade.Titulo AS[Especialidade],Medico.CRM,Prontuario.Descricao AS [Prontuário],FeedBacks.Descricao AS [FeedBack]
FROM
Consulta
left join Clinica on Clinica.IdClinica = Consulta.IdClinica
left join Paciente on Paciente.IdPaciente = Consulta.IdPresencaConsulta
left join Medico on Medico.IdMedico = Consulta.IdMedico
left join Especialidade on Especialidade.IdEspecialidade = Medico.IdEspecialidade
left join Prontuario on Prontuario.IdProntuario = Consulta.IdProntuario
left join FeedBacks on Prontuario.IdProntuario = FeedBacks.IdFeedBacks




