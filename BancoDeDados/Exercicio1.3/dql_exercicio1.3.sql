--DQL - 

/*
listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
- listar todas as ra�as que come�am com a letra S
- listar todos os tipos de pet que terminam com a letra O
- listar todos os pets mostrando os nomes dos seus donos
- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, 
o nome do dono do pet e o nome da cl�nica onde o pet foi atendido
*/
USE ClinicaPet
INSERT INTO Raca(Descricao)
VALUES('Shiba')
 
SELECT 
Clinica.IdClinica, Veterinario.Nome, Veterinario.CRMV
FROM
Clinica
inner join Veterinario on Clinica.IdClinica = Veterinario.IdClinica

SELECT 
Raca.Descricao 
From
Raca
WHERE
Raca.Descricao LIKE 'S%';

SELECT
TipoPet.Descricao
FROM
TipoPet
WHERE
TipoPet.Descricao LIKE '%O';

SELECT 
Dono.Nome AS Dono, Pet.Nome
FROM
Pet 
inner join Dono on Pet.IdDono = Dono.IdDono


SELECT
IdAtendimento,Veterinario.Nome,Pet.Nome,Raca.Descricao,TipoPet.Descricao,Dono.Nome,Clinica.Endereco
FROM
Atendimentos
inner join Veterinario on Atendimentos.IdAtendimento = Veterinario.IdVeterinario
inner join Pet on Atendimentos.IdAtendimento = Pet.IdPet
inner join Raca on Pet.IdRaca = Raca.IdRaca
inner join TipoPet on Pet.IdTipoPet = TipoPet.IdTipoPet
inner join Dono on Pet.IdDono = Dono.IdDono
inner join Clinica on Veterinario.IdClinica = Clinica.IdClinica

SELECT * FROM Raca