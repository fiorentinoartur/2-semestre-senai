// Importando a função jwtDecode do pacote "jwt-decode" para decodificar tokens JWT
import { jwtDecode } from "jwt-decode";

// Importando a função createContext do React para criar um contexto de usuário
import { createContext } from "react";

// Criando um contexto de usuário usando a função createContext
export const UserContext = createContext(null);

// Função que decodifica o token JWT e retorna um objeto com informações relevantes
export const userDecodeToken = (theToken) => {
    // Decodificando o token JWT usando a função jwtDecode
    const decoded = jwtDecode(theToken);

    // Retornando um objeto com informações do usuário, incluindo papel (role), nome e o próprio token
    return { role: decoded.role, nome: decoded.name, token: theToken };
}



