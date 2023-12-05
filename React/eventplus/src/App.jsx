// Importa a folha de estilos principal do aplicativo
import './App.css';

// Importa o componente de rotas definido em './routes'
import Rotas from './routes/routes';

// Importa o contexto de usuário 'UserContext'
import { UserContext } from './context/AuthContext';

// Importa a função 'useState' do React
import { useEffect, useState } from 'react';

// Componente principal do aplicativo
const App = () => {
    // Define um estado local 'userData' e uma função 'setUserData' usando o hook 'useState'
    const [userData, setUserData] = useState({});

    useEffect(() => {
            const token = localStorage.getItem("token");
                setUserData(token === null ? {} : JSON.parse(token))                                                                                           
    },[])
    // Renderiza o componente 'Rotas' dentro do contexto de usuário 'UserContext.Provider'
    return (
        <UserContext.Provider value={{ userData, setUserData }}>
            <Rotas />
        </UserContext.Provider>
    );
}

// Exporta o componente principal 'App'
export default App;
