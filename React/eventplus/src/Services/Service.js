import axios from 'axios';

//Rota para o recurso evento
export const eventsResource = '/Evento'

//Rota pra o próximos eventos
export const nextEventsResource = 'Evento/ListarProximos';

//Rota para o recurso Tipos de Eventos
export const eventsTypeResource = '/TiposEvento'

const apiPort = '7118';
const localApiUri = `https://localhost:${apiPort}/api/`;
const externalApiUri = null;

const api = axios.create({
    baseURL:localApiUri
})

export default api;