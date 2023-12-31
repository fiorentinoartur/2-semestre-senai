import axios from 'axios';

//Rota para o recurso evento
export const eventsResource = '/Evento'

//Rota pra o próximos eventos
export const nextEventsResource = '/Evento/ListarProximos';

//Rota para o recurso Tipos de Eventos
export const eventsTypeResource = '/TiposEvento'

//Rota para as próximas instituições
export const instituicoesResource = '/Instituicao'

//Rota para o Login
export const loginResource = '/Login'

//Rota para evento do alunos
export const myEventsResource = '/PresencasEventos/ListarMinhas'

//Rota para presencas
export const presenceEventResource = "/PresencasEventos"

//Rota para comentários
export const commentaryEvent = "/ComentariosEvento"

//const apiPort = '7118';
//const localApiUri = `https://localhost:${apiPort}/api`;
const externalApiUri = "https://eventwebapi-artur.azurewebsites.net/api";

const api = axios.create({
    baseURL:localApiUri
})

export default api;