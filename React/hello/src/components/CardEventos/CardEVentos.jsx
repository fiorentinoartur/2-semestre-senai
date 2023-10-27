import React from 'react';
import './CardEventos.css'
const CardEvento = ({titulo,text}) => {
    return (

<div className="card-evento">
    <h3 className="card-evento__titulo">{titulo}</h3>
    <p className="card-evento__text">{text}</p>
   <a href="" className="card-evento__conection">Conectar</a>
</div>


    );
}


export default CardEvento;