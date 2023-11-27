import React, { useContext } from 'react';
import Title from '../../components/Title/Title'
import { ThemeContext } from '../../context/ThemeContext';
const ImportantePage = () => {
    const {theme} = useContext(ThemeContext)

    return (
        <div>
            <h1>Página de Dados Importantes</h1>
            <span>{theme}</span>
        </div>
    );
};

export default ImportantePage;