import React, { useEffect } from "react";
import './EventosAlunos.css'
import { useContext } from "react";
import { useState } from "react";
import { UserContext } from "../../context/AuthContext"
import api, { eventsResource } from "../../Services/Service"
import Main from "../../Components/Main/Main";
import Container from "../../Components/Container/Container"
import Titulo from "../../Components/Titulo/Titulo"
import { Select } from "../../Components/Form/Form"
import TableEvA from "./TableEva/TableEva";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal"
const EventosAlunos = () => {

    const [eventos, setEventos] = useState([]);

    const [quaisEventos, setQuaisEventos] = useState([
        { value: 1, text: "Todos os eventos" },
        { value: 2, text: "Meus eventos" },
    ]);

    const [tipoEvento, setTipoEvento] = useState(1)

    const [showSpinner, setShowSpinner] = useState(false);
    const [showModal, setShowModal] = useState(false)

    const { userData, setUserData } = useContext(UserContext);

    useEffect(() => {
        async function loadEventsType() {
            if ((tipoEvento === 1)) {
                //chamar api de todos os eventos
                try {
                    const retorno = await api.get;
                } catch (err) {

                }
            }
            else {
                //chamar a api dos meus eventos
            }
        }
        setShowModal(true);
        setEventos([]);

        loadEventsType();
        setShowSpinner(false);
    }, [tipoEvento]);

    async function loadEventsType() {
        try {
            const retorno = api.get(eventsResource);
            const dados = (await retorno).data;
            setEventos(dados);
            console.log(dados);
        }
        catch (error) {
            console.log("Deu ruim na api");
        }
    }
    function myEvents(tpEvent) {
        setTipoEvento(tpEvent)
    }
    async function loadMyComentary(idComentary) {
        return "????";
    }

    const showHidelModal = () => {
        setShowModal(showModal ? false : true)
    };

    const comentaryRemove = () => {
        alert("Remover comentário");
    }
    function handleConnect() {
        alert("Desenvolver a função conectaR evento")
    }
    return (
        <>
            <Main>
            <Container>
                <Titulo 
                titleText={"Eventos"}
                potatoClass="custom-title"
                />
                <Select
                id="id-tipo-evento"
                name="tipo-evento"
                required={true}
                options={quaisEventos}
                defaultValue={tipoEvento}
                manipulationFunction={(e) => myEvents(e.target.value)}
                />
                <TableEvA
                dados={eventos}
                fnConnect={handleConnect}
                fnShowModal={() => {
                    showHidelModal();
                }}
                />
                </Container>
            </Main>
          {/* SPINNER -Feito com position */}
          {showSpinner ? <Spinner /> : null}

{showModal ? (
  <Modal
    userId={userData.userId}
    showHideModal={showHidelModal}
    fnDelete={comentaryRemove}
  />
) : null}
</>
);
};

export default EventosAlunos;