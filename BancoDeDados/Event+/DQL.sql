--DQL CONSULTAR
/*
Nome do usuário
Tipo do usuário
Data do evento
Local do evento (Instituição)
Titulo do evento
Nome do evento
Descrição do evento
Situação do evento
Comentário do evento
*/
SELECT 
Usuario.Nome,
TipoUsuario.Titulo,
Evento.DataEvento,
Instituicao.Endereco,
TipoEvento.Titulo,
Evento.Nome,
Evento.Descricao,
CASE WHEN PresencasEvento.Situacao = 1 THEN 'Presente' Else 'Ausente' END AS [Situação] ,
ComentarioEvento.Descricao
FROM
Usuario 
inner join TipoUsuario on Usuario.IdUsuario = TipoUsuario.IdTipoUsuario
inner join Evento on TipoUsuario.IdTipoUsuario = Evento.IdEvento
inner join Instituicao on Evento.IdEvento = Instituicao.IdInstituicao
inner join TipoEvento on Instituicao.IdInstituicao = TipoEvento.IdTipoEvento
inner join PresencasEvento on TipoEvento.IdTipoEvento = PresencasEvento.IdPresencasEvento
inner join ComentarioEvento on PresencasEvento.IdPresencasEvento = ComentarioEvento.IdComentarioEvento


