--DQL
--drop database FioreLife
/*CREATE FUNCTION QtdMedico(@IdEspecialidade INT)
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

SELECT Paciente.IdPaciente
FROM Usuario.Nome AS Paciente
     JOIN Usuario.Nome AS Medico
       ON (Paciente.IdUsuario= Medico.IdUsuario)
WHERE Medico.IdUsuario = Tip;

SELECT Usuario.Nome
FROM Paciente.IdUsuario AS Paciente
     JOIN Medico.IdUsuario AS Medico
       ON (Prd1.ListPrice = Prd2.ListPrice)
WHERE Prd2.[Name] = 'Chainring Bolts';
SELECT * FROM Medico
*/

SELECT 
	Consulta.IdConsulta,
	Consulta.DataConsulta,
	Consulta.HoraConsulta,
	Clinica.NomeFantasia AS [Clínica],
	UsuarioPaciente.Nome AS UsuarioPaciente,
	UsuarioMedico.Nome AS UsuarioMedico,
	Especialidade.Titulo AS[Especialidade],
	Medico.CRM,Prontuario.Descricao AS [Prontuário],
	FeedBacks.Descricao AS [FeedBack]
FROM
	Consulta

	left join Paciente 
	on Paciente.IdPaciente = Consulta.IdPaciente

	left join Usuario as UsuarioPaciente
	on Paciente.IdUsuario = UsuarioPaciente.IdUsuario

	left join Clinica 
	on Clinica.IdClinica = Consulta.IdClinica

	left join Medico 
	on Medico.IdClinica = Clinica.IdClinica

	LEFT join Usuario as UsuarioMedico 
	on Medico.IdUsuario = UsuarioMedico.IdUsuario

	left join Especialidade 
	on Especialidade.IdEspecialidade = Medico.IdEspecialidade

	left join Prontuario 
	on Prontuario.IdProntuario = Consulta.IdProntuario

	left join FeedBacks 
	on Prontuario.IdProntuario = FeedBacks.IdFeedBacks
