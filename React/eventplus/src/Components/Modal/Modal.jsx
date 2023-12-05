import React from "react"
import './Modal.css'
import trashDelete from "../../assets/icons/trash-delete.svg"
import {Button, Input} from '../Form/Form';

const Modal = ({
    modalTitle = 'FeedBack',
    comentaryText = "Não informado. Não informado. Não informada.",
    userId = null,
    showHideModal = false,
    fnDelete = null,
    fnNewCommentary = null
}) => {

    return(

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
                    alt="Ícone de uma lixeira" 
                    className="comentary__icon-delete" 
                    onClick={fnDelete}
                    />

                    <p className="commentary__text">{comentaryText}</p>

                    <hr className="comentary__separator" />   
                </div>

                <Input 
                placeholder="Escreva seu comentário..."
                className="comentary__entry" />

                <Button 
                buttonText="Comentar"
                className="comentary__button"
                onClick={fnNewCommentary}
                />
            </article>
        </div>
    
    )
}

export default Modal;