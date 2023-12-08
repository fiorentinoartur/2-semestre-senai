import React, { useEffect, useState } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";

import { Button, Input } from "../Form/Form";
import "./Modal.css";
import { commentaryEvent } from "../../Services/Service";
import { useContext } from "react";
import { UserContext } from "../../context/AuthContext";

const Modal = ({
  modalTitle = "Feedback",
  comentaryText = "Não informado. Não informado. Não informado.",
  // userId = null,
  showHideModal = null,
  //idEvento = null,
  fnDelete = null,
  fnNewCommentary = null,
  fnGet = null,
  fnPost = null

}) => {
  const { userData } = useContext(UserContext)
  const [comentaryDesc, setComentaryDesc] = useState("");


  useEffect(() => {
    async function carregarDados() {
      fnGet()
    }

    carregarDados();
  }, [])

  return (
    <div className="modal">
      <article className="modal__box">

        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={() => showHideModal(true)}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={() => {
              fnDelete()
            }}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          className="comentary__entry"
          value={comentaryDesc}
          manipulationFunction={(e) => {
            setComentaryDesc(e.target.value)
          }}
        />

        <Button
          textButton="Comentar"
          additionalClass="comentary__button"
          manipulationFunction={() => {
            fnPost(comentaryDesc, userData.userId, userData.idEvento)
          }}
        />
      </article>
    </div>
  );
};

export default Modal;
