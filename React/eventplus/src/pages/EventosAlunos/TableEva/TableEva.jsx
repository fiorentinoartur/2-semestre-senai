import React from "react";
import comentaryIcon from "../../../assets/icons/comentary-icon.svg";

import { dateFormatDbToView } from "../../../Utils/stringFunctions";
import Toggle from "../../../Components/Toggle/Toggle";
// importa a biblioteca de tootips ()
import "react-tooltip/dist/react-tooltip.css";


import "./TableEva.css";

const TableEvA = ({ dados, fnConnect = null, fnShowModal = null }) => {
  
  return (
    <table className="tbal-data">
      <thead className="tbal-data__head">
        <tr className="tbal-data__head-row tbal-data__head-row--red-color">
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Evento
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Data
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        {dados.map((e) => {
          return (
            <tr className="tbal-data__head-row" key={Math.random()}>
              <td className="tbal-data__data tbal-data__data--big">
                {e.nomeEvento}
              </td>
              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                 {dateFormatDbToView(e.dataEvento)} 
              </td>

              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
               {new Date(e.dataEvento) < Date.now()? (

                 <img
                   className="tbal-data__icon"
                   // idevento={e.idEvento}
                   src={comentaryIcon}
                   alt=""
                   onClick={() => {fnShowModal(e.idEvento)}}
                 />
               ): null}

                <Toggle 
                toggleActive={e.situacao}
                manipulationFunction={() => {
                  fnConnect(
                    e.idEvento, 
                    e.situacao ? "unconnect" : "connect",
                    e.idPresencaEvento 
                    )}} />
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default TableEvA;