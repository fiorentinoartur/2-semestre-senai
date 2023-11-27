import React, { useContext } from 'react';
import {Link} from 'react-router-dom'
import {ThemeContext}  from '../../context/ThemeContext'
const Nav = () => {

    const {theme, setTheme} = useContext(ThemeContext)

    const toggleTheme = () => {
        setTheme(theme === 'light' ? 'dark' : 'light')
    }
    return (
        <div>
            {/* dd */}
            <Link  to="/">Home</Link> | &nbsp;
            <Link to="/produtos">Produto</Link> | &nbsp;
            <Link to="/importante">Dados importantes</Link> | &nbsp;
            <Link to="/meus-pedidos">Meus pedidos</Link> | &nbsp;
            <Link to="/login">Login</Link> | &nbsp;
            <span>Tema Atual: {theme}</span>
            <button onClick={toggleTheme}>{theme}</button>
        </div>
    );
};

export default Nav;