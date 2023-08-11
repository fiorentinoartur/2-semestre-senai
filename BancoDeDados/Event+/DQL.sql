--DQL CONSULTAR
/*
Nome do usu�rio
Tipo do usu�rio
Data do evento
Local do evento (Institui��o)
Titulo do evento
Nome do evento
Descri��o do evento
Situa��o do evento
Coment�rio do evento
*/
SELECT 
Usuario.Nome,
TipoUsuario.Titulo,
Evento.DataEvento,
Instituicao.Endereco,
TipoEvento.Titulo,
Evento.Nome,
Evento.Descricao,
CASE WHEN PresencasEvento.Situacao = 1 THEN 'Presente' Else 'Ausente' END AS [Situa��o] ,
ComentarioEvento.Descricao
FROM
Usuario 
inner join TipoUsuario on Usuario.IdUsuario = TipoUsuario.IdTipoUsuario
inner join Evento on TipoUsuario.IdTipoUsuario = Evento.IdEvento
inner join Instituicao on Evento.IdEvento = Instituicao.IdInstituicao
inner join TipoEvento on Instituicao.IdInstituicao = TipoEvento.IdTipoEvento
inner join PresencasEvento on TipoEvento.IdTipoEvento = PresencasEvento.IdPresencasEvento
inner join ComentarioEvento on PresencasEvento.IdPresencasEvento = ComentarioEvento.IdComentarioEvento


