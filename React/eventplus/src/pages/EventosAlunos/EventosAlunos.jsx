import React, { useEffect } from "react";
import './EventosAlunos.css'
import { useContext } from "react";
import { useState } from "react";
import { UserContext } from "../../context/AuthContext"
import api, { eventsResource, myEventsResource, presenceEventResource, commentaryEvent } from "../../Services/Service"
import Main from "../../Components/Main/Main";
import Container from "../../Components/Container/Container"
import Titulo from "../../Components/Titulo/Titulo"
import { Select } from "../../Components/Form/Form"
import TableEvA from "./TableEva/TableEva";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal"
import { isExists } from "date-fns";
const EventosAlunos = () => {

    const [eventos, setEventos] = useState([]);

    const [quaisEventos, setQuaisEventos] = useState([
        { value: 1, text: "Todos os eventos" },
        { value: 2, text: "Meus eventos" },
    ]);

    const [tipoEvento, setTipoEvento] = useState("1");

    const [showSpinner, setShowSpinner] = useState(false);
    const [showModal, setShowModal] = useState(false)
    const [comentary, setComentary] = useState("")
 

    const { userData, setUserData } = useContext(UserContext);


    useEffect(() => {



        setShowModal();

        loadEventsType();
    }, [tipoEvento, userData.userId]);

    async function loadEventsType() {

        if (tipoEvento === "1") {
            //chamar api de todos os eventos
            setShowSpinner(true)
            try {
                const todosEventos = await api.get(eventsResource);
                const meusEventos = await api.get(`${myEventsResource}/${userData.userId}`)

                const eventosMarcados = verificaPresenca(
                    todosEventos.data,
                    meusEventos.data);

                setEventos(eventosMarcados)

                console.clear();
                console.log("TODOS EVENTOS");
                console.log(todosEventos.data);
                console.log("Meus eventos");

                console.log(meusEventos.data);
                console.log("EVENTOS MARCADOS");
                console.log(eventosMarcados);

            } catch (err) {
                //colocar o notification
                console.log("Erro na APi aqui no useEffect");
                console.log(err);
            }
            setShowSpinner(false)

        }
        else if (tipoEvento === "2") {
            //chamar a api dos meus eventos
            setShowSpinner(true)
            try {
                const retorno = await api.get(`${myEventsResource}/${userData.userId}`)
                console.log(`${myEventsResource}/${userData.userId}`);
                console.log(retorno.data);
                const arrEventos = [];

                retorno.data.forEach(e => {
                    arrEventos.push({ ...e.evento, situacao: e.situacao, idPresencaEvento: e.idPresencaEvento })
                });

                setEventos(arrEventos)

            } catch (error) {
                console.log("Erro na API");
                console.log(error);
            }
            setShowSpinner(false)
        }
        else {
            setEventos([]);
        }
    }

    const verificaPresenca = (arrAllEvents, eventsUser) => {
        for (let x = 0; x < arrAllEvents.length; x++) {
            for (let i = 0; i < eventsUser.length; i++) {
                if (arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
                    arrAllEvents[x].situacao = true;
                    arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento
                    break;
                }

            }

        }
        return arrAllEvents;
    }
    function myEvents(tpEvent) {
        setTipoEvento(tpEvent)
    }



    const showHideModal = (idEvent) => {
        setShowModal(showModal ? false : true)
        setUserData({ ...userData, idEvento: idEvent })
    };

    async function loadMyComentary() {
        try {
            const promise = await api.get(`${commentaryEvent}?idUsuario=${userData.userId}&idEvento=${userData.idEvento}`)

            (promise.data[0].descricao == "Não informado. Não informado. Não informado.") ? "teste" : setComentary(promise.data[0].descricao)
          


        } catch (error) {
            console.log("Deu erro aqui");
        }
    }

    const commentaryRemove = () => {
        alert("Remover comentário");
    }


    // const postMyCommentary = async (eventId, commentarysEvent) => {
    //     try {
    //         console.log(commentarysEvent);
    //         const promise = await api.post(commentaryEvent,{
    //           idUsuario: userData.userId,
    //           idEvento: eventId,
    //           exibe:true,
    //           descricao: commentarysEvent
    //         })
    //     } catch (error) {
    //         console.log(error);
    //     }

    // }
    async function handleConnect(eventId, whatTheFunction, presencaId = null) {
        if (whatTheFunction === "connect") {
            try {
                const promise = await api.post(presenceEventResource, {
                    situacao: true,
                    idUsuario: userData.userId,
                    idEvento: eventId
                })

                if (promise.status === 201) {
                    loadEventsType()
                    alert("Presença confirmada, parabéns")
                }

                setTipoEvento("1")
                const todosEventos = await api.get(eventsResource)
                setEventos(todosEventos.data);
            } catch (error) {

            }
            return;
        }
        console.clear();

        try {
            const unconnect = await api.delete(`${presenceEventResource}/${presencaId}`)
            if (unconnect.status === 204) {
                loadEventsType()
                alert("Desconectado evento")
            }
        } catch (error) {
            console.log("Erroa ao desconectar o usuário do evento");
            console.log(error);
        }
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
                        className="select-tp-evento"
                    />
                    <TableEvA
                        dados={eventos}
                        fnConnect={handleConnect}
                        fnShowModal={
                            showHideModal
                        }
                    />
                </Container>
            </Main>
            {/* SPINNER -Feito com position */}
            {showSpinner ? <Spinner /> : null}

            {showModal ? (
                <Modal
                    showHideModal={showHideModal}
                    fnGet={loadMyComentary}
                    //   fnPost={postMyCommentary}
                    fnDelete={commentaryRemove}
                    comentaryText={comentary}

                />
            ) : null}
        </>
    );
};

export default EventosAlunos;