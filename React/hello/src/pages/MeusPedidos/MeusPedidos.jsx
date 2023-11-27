import React, { useContext } from 'react';
import Title from '../../components/Title/Title'
import { ThemeContext } from '../../context/ThemeContext';
const MeusPedidos = () => {
    const {theme} = useContext(ThemeContext)
    return (
        <>
            <h1>Meus Pedidos</h1>
            <h2>Página Privada</h2>
            <span>{theme}</span>
        </>
    );
};

export default MeusPedidos;