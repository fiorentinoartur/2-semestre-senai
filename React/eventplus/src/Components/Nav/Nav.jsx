import React from 'react';
import logoMobile from "../../assets/icons/logo-white.svg";
import logoDesktop from "../../assets/icons/logo-pink.svg";
import "./Nav.css"
const Nav = () => {
    return (
        <nav className='navbar'>
            <span className='navbar__close'>x</span>
            <a href="" className='eventlogo'>
                <img
                className='eventlogo__logo-image' 
                src={window.innerWidth >= 992 ? logoDesktop : logoMobile}
                alt="Event Plus Logo"/>
            </a>

            <div className='navbar__items-box'>
                <a href="">Home</a>
                <a href="">Tipos de Evento</a>
                <a href="">Usuários</a>
            </div>
        </nav>
    );
};

export default Nav;