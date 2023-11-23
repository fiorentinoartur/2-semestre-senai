//Importações necessários
import React, { useEffect, useState } from 'react';
import './Eventos.css'
import Titulo from "../../Components/Titulo/Titulo"
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import typeEventImage from '../../assets/icons/evento.svg';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import { Button, Input, Select } from '../../Components/Form/Form';
import Table from './Table/Table';
import api, { eventsResource, eventsTypeResource }
    from '../../Services/Service'
import { dateFormatDbToView } from '../../Utils/stringFunctions';
import Notification from '../../Components/Notification/Notification';

//Componente principal Eventos
const Eventos = () => {

    // Estados para controle
    const idInstituicao = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    const [frmEdit, setFrmEdit] = useState(false)
    const [titulo, setTitulo] = useState("");
    const [descricao, setDescricao] = useState("")
    const [data, setData] = useState("")
    const [options, setOptions] = useState([])
    const [tiposEvento, setTiposEvento] = useState("")
    const [eventos, setNextEvents] = useState([])
    const [idEvento, setidEvento] = useState("")
    const [notifyUser, setNotifyUser] = useState();



    //Efeito após redenrização para carregar eventos
    useEffect(() => {
        async function loadEvents() {
            try {
                //Obter tipos de eventos
                const promise = await api.get(eventsTypeResource)
                dePara(promise.data)

                //buscar eventos
                const promiseEvent = await api.get(eventsResource)
                setNextEvents(promiseEvent.data)


            } catch (error) {
                console.log("Erro na API", error);
            }
        }
        loadEvents();
    }, []);



    function dePara(eventos) {
        const arrayOptions = []
        eventos.forEach((e) => {
            arrayOptions.push({ value: e.idTipoEvento, text: e.titulo })
        })
        setOptions(arrayOptions);

    }

    async function handleSubmit(e) {
        e.preventDefault()


        try {
            const retorno = await api.post(eventsResource,
                {
                    nomeEvento: titulo,
                    idTipoEvento: tiposEvento,
                    dataEvento: data,
                    descricao: descricao,
                    idInstituicao: idInstituicao
                });

            const searchEvents = api.get(eventsResource)
            setNextEvents((await searchEvents).data)
        } catch (e) {
            setNotifyUser({
                titleNote: "Aviso",
                textNote: "Não foi possível cadastrar um evento"
            })
        }
    }

    async function handleUpdate(e) {
        e.preventDefault()
        try {
            const retorno = await api.put(`${eventsResource}/${idEvento}`, {
                nomeEvento: titulo, idTipoEvento: tiposEvento, dataEvento: data, descricao: descricao,
                idInstituicao: idInstituicao
            });


            const searchEvents = await api.get(eventsResource)
            setNextEvents(searchEvents.data)

        } catch (error) {

        }
    }

    async function showUpdateForm(idElement) {
        setidEvento(idElement)
        try {
            const promise = await api.get(`${eventsResource}/${idElement}`)
            setTitulo(promise.data.nomeEvento)
            setDescricao(promise.data.descricao)
            setTiposEvento(promise.data.idTipoEvento)
            setData(dateFormatDbToView(promise.data.dataEvento))

        } catch (error) {

        }
        setFrmEdit(true)
    }

    function editActionAbort() {
        setFrmEdit(false)

    }
    async function handleDelete(idElement) {
        console.log(idElement);
        if (!window.confirm("Confirma a exlusão")) {
            return;
        }

        try {
            const promise = await api.delete(`${eventsResource}/${idElement}`)

            const searchEvents = await api.get(eventsResource)
            setNextEvents(searchEvents.data)
        } catch (error) {
            console.log("Erro na exlusão");
        }
    }
    return (
        <>
            <Main>
                <section className='cadastro-evento-section'>
                    <Container>
                        <div className="cadastro-evento__box">
                            <Titulo titleText={"Cadastro de Eventos"} />
                            <ImageIlustrator imageRender={typeEventImage} />
                            <form
                                action=""
                                className='ftipo-evento'
                                onSubmit={frmEdit ? handleUpdate : handleSubmit}
                            >
                                {/* Form de Edição */}
                                {!frmEdit ? (
                                    <>
                                        <Input
                                            id="Titulo"
                                            placeholder="Titulo"
                                            name="Titulo"
                                            type="Text"
                                            required="required"
                                            value={titulo}
                                            manipulationFunction={(e) => setTitulo(e.target.value)}
                                        />
                                        <Input
                                            id="Descricao"
                                            placeholder="Descrição"
                                            name="Descricao"
                                            type="text"
                                            required="required"
                                            value={descricao}
                                            manipulationFunction={(e) => setDescricao(e.target.value)}
                                        />
                                        <Select
                                            name="Eventos"
                                            id="eventos"
                                            required="required"
                                            options={options}
                                            value={tiposEvento}
                                            defaultValue={tiposEvento}
                                            manipulationFunction={(e) => setTiposEvento(e.target.value)}
                                        />


                                        <Input
                                            id="data"
                                            placeholder="Data do Evento"
                                            name="data"
                                            type="date"
                                            required="required"
                                            value={data}
                                            manipulationFunction={(e) => setData(e.target.value)}
                                        />

                                        <Button
                                            textButton="Cadastrar"
                                            id="cadastrar"
                                            additionalClass="btn-cadastrar"
                                            name="cadastrar"
                                            type="submit"
                                        />
                                    </>
                                ) : (
                                    <>
                                        <Input
                                            id="Titulo"
                                            placeholder="Titulo"
                                            name="Titulo"
                                            type="Text"
                                            required="required"
                                            value={titulo}
                                            manipulationFunction={(e) => setTitulo(e.target.value)}
                                        />
                                        <Input
                                            id="Descricao"
                                            placeholder="Descrição"
                                            name="Descricao"
                                            type="text"
                                            required="required"
                                            value={descricao}
                                            manipulationFunction={(e) => setDescricao(e.target.value)}
                                        />
                                        <Select
                                            name="Eventos"
                                            id="eventos"
                                            required="required"
                                            options={options}
                                            value={tiposEvento}
                                            defaultValue={tiposEvento}
                                            manipulationFunction={(e) => setTiposEvento(e.target.value)}
                                        />


                                        <Input
                                            id="data"
                                            placeholder="Data do Evento"
                                            name="data"
                                            type="date"
                                            required="required"
                                            value={data}
                                            manipulationFunction={(e) => setData(e.target.value)}
                                        />
                                        <div className="buttons-editbox">

                                            <Button
                                                textButton="Atualizar"
                                                id="atualizar"
                                                additionalClass="btn-cadastrar"
                                                name="atualizar"
                                                type="submit"
                                            />
                                            <Button
                                                textButton="Cancelar"
                                                id="cancelar"
                                                additionalClass="btn-cadastrar"
                                                name="cancelar"
                                                type="button"
                                                manipulationFunction={(e) => {
                                                    { editActionAbort() }
                                                }}
                                            />
                                        </div>
                                    </>
                                )}
                            </form>
                        </div>
                    </Container>
                </section>

                <section className="lista-eventos-section">
                    <Container>
                        <Titulo titleText={"Lista Eventos"} color='white' />
                        <Table
                            dados={eventos}
                            fnDelete={handleDelete}
                            fnUpdate={showUpdateForm}
                        />

                    </Container>
                </section>
            </Main>
        </>



    );
};

export default Eventos;