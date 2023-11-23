import React from 'react';
import './NextEvent.css'

//usar o destructuring quando não estamos utilizando o export default
import { dateFormatDbToView } from "../../Utils/stringFunctions"

import { Tooltip } from "react-tooltip";

const NextEvent = ({ title, description, eventDate, idEvento, }) => {

    function conectar(idEvent) {
        alert(`Chamar o recurso para conectar: ${idEvento}`)
    }

    return (
        <article className='event-card'>

            <h2 className="event-card__title">{title}</h2>

            <p 
                className='event-card__description '
                data-tooltip-id={idEvento}
                data-tooltip-content={description}
                data-tooltip-place="top">
               <Tooltip id={idEvento} className='tooltip'/>
                {description.substr(0, 15)}...

            </p>

            <p className='event-card__description '>{dateFormatDbToView(eventDate)}</p>



            <a onClick={() => { conectar(idEvento) }} className="event-card__connect-link">conectar</a>

        </article>
    );
};

export default NextEvent;