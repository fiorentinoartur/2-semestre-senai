// Importando o componente Navigate da biblioteca "react-router-dom"
import { Navigate } from "react-router-dom";

// Definindo um componente React chamado PrivateRoute, que recebe dois parâmetros: children e redirecTo
export const PrivateRoute = ({children, redirectTo ="/"}) => {
    //verifica se está autenticado
    const isAuthenticated = localStorage.getItem("token") !== null

    //retornar o componente ou navegar para a home
    return isAuthenticated? children:<Navigate to={redirectTo}/>
}