// Importações necessárias
import React, { useEffect, useState } from 'react';
import './TiposEvento.css';
import Titulo from '../../Components/Titulo/Titulo';
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import Table from './TableTP/Table';
import typeEventImage from '../../assets/icons/tipo-evento.svg';
import { Button, Input } from '../../Components/Form/Form';
import api, { eventsTypeResource } from '../../Services/Service';
import Notification from '../../Components/Notification/Notification';
import dafaultImage from '../../assets/images/default-image.jpeg';
import Spinner from '../../Components/Spinner/Spinner';

// Componente principal TiposEvento
const TiposEvento = () => {
  // Estados para controle
  const [frmEdit, setNextEvents] = useState(false); // Modo de edição
  const [titulo, setTitulo] = useState("");
  const [idEvento, setidEvento] = useState(null); // ID do evento para edição
  const [tiposEvento, setTiposEvento] = useState([]);
  const [notifyUser, setNotifyUser] = useState();
  const [showSpinner, setShowSpinner] = useState(false);

  // Efeito após a renderização para carregar tipos de eventos
  useEffect(() => {
    async function loadEventsType() {
      setShowSpinner(true);
      try {
        const promise = await api.get(eventsTypeResource);
        setTiposEvento(promise.data);
      } catch (error) {
        console.log("Erro na API", error);
      }
      setShowSpinner(false);
    }
    loadEventsType();
  }, []);

  // Função para lidar com o envio do formulário de cadastro
  async function handleSubmit(e) {
    e.preventDefault();

    if (titulo.trim().length < 3) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote: "O título deve conter pelo menos 3 caracteres",
        imgIcon: "warning",
        imgAlt: "Ilustração de aviso. Moça em frente a um símbolo de exclamação.",
        showMessage: true
      });
      return;
    }

    setShowSpinner(true);

    try {
      await api.post(eventsTypeResource, { titulo });
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: "Tipo de Evento cadastrado com sucesso",
        imgIcon: "success",
        imgAlt: "Ilustração de sucesso. Moça em frente a um símbolo de exclamação.",
        showMessage: true
      });
      setTitulo("");
      const buscaEventos = await api.get(eventsTypeResource);
      setTiposEvento(buscaEventos.data);
    } catch (e) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote: "Não foi possível cadastrar um tipo de evento",
        imgIcon: "warning",
        imgAlt: "Ilustração de aviso. Moça em frente a um símbolo de exclamação.",
        showMessage: true
      });
    } finally {
      setShowSpinner(false);
    }
  }

  // Função para lidar com a atualização de eventos
  async function handleUpdate(e) {
    e.preventDefault();
    setShowSpinner(true);

    try {
      const retorno = await api.put(`${eventsTypeResource}/${idEvento}`, { titulo });
      if (retorno.status === 204) {
        setNotifyUser({
          titleNote: "Sucesso",
          textNote: "Atualizado com sucesso",
          imgIcon: "success",
          imgAlt: "Ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok",
          showMessage: true
        });
        const buscaEventos = await api.get(eventsTypeResource);
        setTiposEvento(buscaEventos.data);
        editActionAbort();
      }
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: "Não foi possível atualizar o tipo de evento",
        imgIcon: "danger",
        imgAlt: "Ilustração de erro. Rapaz segurando um balão com símbolo X.",
        showMessage: true
      });
    } finally {
      setShowSpinner(false);
    }
  }

  // Função para mostrar o formulário de edição
  async function showUpdateForm(idElement) {
    setidEvento(idElement);
    try {
      const promise = await api.get(`${eventsTypeResource}/${idElement}`);
      setTitulo(promise.data.titulo);
    } catch (error) { }

    setNextEvents(true);
  }

  // Função para cancelar a edição
  function editActionAbort() {
    setNextEvents(false);
    setidEvento(null);
  }

  // Função para lidar com a exclusão de eventos
  async function handleDelete(idElement) {
    if (!window.confirm("Confirma a exclusão")) {
      return;
    }

    setShowSpinner(true);

    try {
      const promise = await api.delete(`${eventsTypeResource}/${idElement}`);
      if (promise.status === 204) {
        setNotifyUser({
          titleNote: "Sucesso",
          textNote: "Cadastro excluído com sucesso",
          imgIcon: "success",
          imgAlt: "Ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok",
          showMessage: true
        });

        const buscaEventos = await api.get(eventsTypeResource);
        setTiposEvento(buscaEventos.data);

        editActionAbort();
      }
    } catch (error) {
      console.log("Erro na exclusão", error);
    } finally {
      setShowSpinner(false);
    }

  }

  // Renderização do componente
  return (
    <>
      {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}
      {showSpinner ? <Spinner /> : null}

      <Main>
        <section className="cadastro-evento-section">
          <Container>
            <div className="cadastro-evento__box">
              <Titulo titleText={"Cadastro Tipo de Eventos"} />
              <ImageIlustrator imageRender={typeEventImage} />
              <form
                action=""
                className="ftipo-evento"
                onSubmit={frmEdit ? handleUpdate : handleSubmit}
              >
                {!frmEdit ? (
                  // Formulário de Edição
                  <>
                    <Input
                      id="Titulo"
                      placeholder="Titulo"
                      name="titulo"
                      type="text"
                      required="required"
                      value={titulo}
                      manipulationFunction={(e) => setTitulo(e.target.value)}
                    />
                    <Button
                      textButton="Cadastrar"
                      id="cadastrar"
                      name="cadastrar"
                      type="submit"
                    />
                  </>
                ) : (

                  //Editar
                  <>
                    <Input
                      id="Titulo"
                      placeholder={titulo}
                      name="titulo"
                      type="text"
                      required="required"
                      value={titulo}
                      manipulationFunction={(e) => {
                        setTitulo(e.target.value);
                      }}
                    />
                    <div className='buttons-editbox'>
                      <Button
                        textButton="Atualizar"
                        id="atualizar"
                        name="atualizar"
                        type="button"
                        className="Atualizar"
                        additionalClass="button-component--middle"
                        manipulationFunction={(event) => handleUpdate(event)}
                      />
                      <Button
                        textButton="Cancelar"
                        id="cancelar"
                        name="cancelar"
                            type="button"
                        manipulationFunction={editActionAbort}
                        additionalClass="button-component--middle"
                      />
                    </div>
                  </>
                )
                }
              </form>
            </div>
          </Container>
        </section>

        {/* Seção de Lista de Eventos */}
        <section className="lista-eventos-section">
          <Container>
            <Titulo titleText={"Lista Tipo de Eventos"} color='white' />
            <Table
              dados={tiposEvento}
              fnUpdate={showUpdateForm}
              fnDelete={handleDelete}
            />
          </Container>
        </section>
      </Main>
    </>
  );
};

export default TiposEvento;

/*
Comentários Adicionais:

useEffect: O hook useEffect é usado para buscar os tipos de eventos após a renderização da página.

handleSubmit: Lida com o envio do formulário para cadastrar um novo tipo de evento.

handleUpdate: Lida com o envio do formulário para atualizar um tipo de evento existente.

showUpdateForm: Mostra o formulário de edição, pré-preenchendo os campos com os dados existentes.

editActionAbort: Cancela a ação de edição, revertendo para o formulário de cadastro.

handleDelete: Lida com a exclusão de um tipo de evento, solicitando confirmação ao usuário.

Renderização do Componente: Estrutura a renderização do componente com diferentes seções para cadastro e lista de eventos. Usa componentes como Titulo, Container, ImageIlustrator, Button, Input, Notification, Table e Spinner.
*/