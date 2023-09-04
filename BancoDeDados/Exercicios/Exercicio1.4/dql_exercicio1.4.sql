--DDL
/*
- listar todos os usuários administradores, sem exibir suas senhas
- listar todos os álbuns lançados após o um determinado ano de lançamento
- listar os dados de um usuário através do e-mail e senha
- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 
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

