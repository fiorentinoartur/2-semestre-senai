--DDL
/*
- listar todos os usu�rios administradores, sem exibir suas senhas
- listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
- listar os dados de um usu�rio atrav�s do e-mail e senha
- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 
*/  
USE Optus
SELECT
Usuarios.IdUsuarios,Usuarios.Permissao,Usuarios.Nome,Usuarios.Email
FROM
Usuarios 
Where
Usuarios.Permissao = 'adm';

SELECT
Albuns.IdAlbum, Albuns.DataLancamento,Albuns.Titulo
FROM
Albuns
Where
Albuns.DataLancamento BETWEEN '2023-01-01'  AND '2024-02-01';


SELECT 
Usuarios.IdUsuarios,Usuarios.Permissao,Usuarios.Nome,Usuarios.Email,Usuarios.Senha
FROM
Usuarios 
Where
Usuarios.Email = 'turzin@gmail.com' AND Usuarios.Senha = '32442'

SELECT 
Albuns.IdAlbum,Artistas.Nome,AlbunsEstilos.IdEstilo
FROM
Albuns
inner join Artistas on Albuns.IdArtista = Artistas.IdArtista
inner join AlbunsEstilos on Albuns.IdAlbum= AlbunsEstilos.IdEstilo


SELECT * FROM  Usuarios
SELECT * FROM  Albuns

