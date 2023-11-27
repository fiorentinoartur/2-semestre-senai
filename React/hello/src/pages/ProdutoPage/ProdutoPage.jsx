import React from 'react';
import { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';
import CardEvent from '../../components/CardEventos/CardEVentos'

const ProdutoPage = () => {
    const {theme} = useContext(ThemeContext)
    return (
        <div>
            <h1>Página de Produtos</h1>
            <CardEvent />
            <span>{theme}</span>
        </div>
    );
};

export default ProdutoPage;