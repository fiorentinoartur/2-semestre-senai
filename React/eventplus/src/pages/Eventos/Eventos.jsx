// Importações necessárias
import React, { useEffect, useState } from 'react';
import './Eventos.css';
import Titulo from "../../Components/Titulo/Titulo";
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import typeEventImage from '../../assets/icons/evento.svg';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import { Button, Input, Select } from '../../Components/Form/Form';
import Table from './Table/Table';
import api, { eventsResource, eventsTypeResource } from '../../Services/Service';
import { dateFormatDbToView } from '../../Utils/stringFunctions';
import Notification from '../../Components/Notification/Notification';
import Spinner from '../../Components/Spinner/Spinner';

// Componente principal Eventos
const Eventos = () => {
    // Estados para controle
    const idInstituicao = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState("");
    const [descricao, setDescricao] = useState("");
    const [data, setData] = useState("");
    const [options, setOptions] = useState([]);
    const [tiposEvento, setTiposEvento] = useState("");
    const [eventos, setNextEvents] = useState([]);
    const [idEvento, setidEvento] = useState("");
    const [notifyUser, setNotifyUser] = useState();
    const [showSpinner, setShowSpinner] = useState(false);

    // Efeito após redenrização para carregar eventos
    useEffect(() => {
        async function loadEvents() {
            setShowSpinner(true);
            try {
                // Obter tipos de eventos
                const promise = await api.get(eventsTypeResource);
                dePara(promise.data);

                // Buscar eventos
                const promiseEvent = await api.get(eventsResource);
                setNextEvents(promiseEvent.data);
            } catch (error) {
                console.log("Erro na API", error);
            }
            setShowSpinner(false);
        }
        loadEvents();
    }, []);

    // Função para mapear tipos de evento para opções do Select
    function dePara(eventos) {
        const arrayOptions = [];
        eventos.forEach((e) => {
            arrayOptions.push({ value: e.idTipoEvento, text: e.titulo });
        });
        setOptions(arrayOptions);
    }

    // Função para lidar com o envio do formulário de cadastro
    async function handleSubmit(e) {
        e.preventDefault();

        // Validação do título
        if (titulo.trim().length < 3) {
            // Notificação de aviso
            setNotifyUser({
                titleNote: "Aviso",
                textNote: "O título deve conter pelo menos 3 caracteres",
                imgIcon: "warning",
                imgAlt: "Ilustração de aviso. Moça em frente a um símbolo de exclamação.",
                showMessage: true
            });
            return;
        }

        // Exibição do spinner durante o envio
        setShowSpinner(true);
        try {
            // Requisição POST para cadastrar o evento
            await api.post(eventsResource, {
                nomeEvento: titulo,
                idTipoEvento: tiposEvento,
                dataEvento: data,
                descricao: descricao,
                idInstituicao: idInstituicao
            });

            // Notificação de sucesso
            setNotifyUser({
                titleNote: "Sucesso",
                textNote: "Evento cadastrado com sucesso!",
                imgIcon: "success",
                imgAlt: "Ilustração de sucesso. Moça em frente a um símbolo de exclamação",
                showMessage: true
            });

            // Atualização da lista de eventos
            const searchEvents = api.get(eventsResource);
            setNextEvents((await searchEvents).data);

            // Limpeza dos campos do formulário
            setTitulo("");
            setDescricao("");
            setTiposEvento("");
            setData("");
        } catch (e) {
            // Notificação de erro
            setNotifyUser({
                titleNote: "Erro",
                textNote: "Não foi possível cadastrar o evento!",
                imgIcon: "danger",
                imgAlt: "Ilustração de erro. Moço em frente a um símbolo de erro",
                showMessage: true
            });
        }
        // Ocultar o spinner após o envio
        setShowSpinner(false);
    }

    // Função para lidar com a atualização de um evento
    async function handleUpdate(e) {
        e.preventDefault();
        setShowSpinner(true);
        try {
            // Requisição PUT para atualizar o evento
            const retorno = await api.put(`${eventsResource}/${idEvento}`, {
                nomeEvento: titulo,
                idTipoEvento: tiposEvento,
                dataEvento: data,
                descricao: descricao,
                idInstituicao: idInstituicao
            });

            // Notificação de sucesso
            if (retorno.status === 204) {
                setNotifyUser({
                    titleNote: "Sucesso",
                    textNote: "Evento atualizado com sucesso",
                    imgIcon: "success",
                    imgAlt: "Ilustração de sucesso. Moça em frente a um símbolo de exclamação.",
                    showMessage: true
                });
            }
            editActionAbort(true)

            // Atualização da lista de eventos
            const searchEvents = await api.get(eventsResource);
            setNextEvents(searchEvents.data);
            
        } catch (error) {
            // Notificação de erro
            setNotifyUser({
                titleNote: "Erro",
                textNote: "Não foi possível atualizar o evento",
                imgIcon: "danger",
                imgAlt: "Ilustração de erro. Moço em frente a um símbolo X se referindo a um erro.",
                showMessage: true
            });
        }
        setShowSpinner(false);
    }

    // Função para exibir o formulário de edição
    async function showUpdateForm(idElement) {
        setidEvento(idElement);
        setShowSpinner(true);
        try {
            // Requisição GET para obter os detalhes do evento
            const promise = await api.get(`${eventsResource}/${idElement}`);
            setTitulo(promise.data.nomeEvento);
            setDescricao(promise.data.descricao);
            setTiposEvento(promise.data.idTipoEvento);
            setData(new Date((promise.data.dataEvento)).toLocaleDateString('sv-SE'));
        } catch (error) {
            // Tratamento de erro
        }
        setShowSpinner(false);
        setFrmEdit(true);
    }

    // Função para cancelar a edição
    function editActionAbort() {
        setFrmEdit(false);
        // Limpeza dos campos do formulário
        setTitulo("");
        setDescricao("");
        setTiposEvento("");
        setData("");
    }

    // Função para lidar com a exclusão de um evento
    async function handleDelete(idElement) {
        if (!window.confirm("Confirma a exclusão")) {
            return;
        }
        setShowSpinner(true);
        try {
            // Requisição DELETE para excluir o evento
            const promise = await api.delete(`${eventsResource}/${idElement}`);

            // Atualização da lista de eventos
            const searchEvents = await api.get(eventsResource);
            setNextEvents(searchEvents.data);
        } catch (error) {
            console.log("Erro na exclusão");
        }
        setShowSpinner(false);
    }
    
    return (
        <>
            {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}
            {showSpinner ? <Spinner /> : null}
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
                                           // defaultValue={tiposEvento}
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