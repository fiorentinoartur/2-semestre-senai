import React, { useEffect, useState } from 'react';
import './TiposEvento.css'
import Titulo from '../../Components/Titulo/Titulo';
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import Table from './TableTP/Table';
import typeEventImage from '../../assets/icons/tipo-evento.svg'
import { Button, Input } from '../../Components/Form/Form';
import api, {eventsTypeResource} from '../../Services/Service'
import eventImage  from '../../assets/icons/evento.svg'
import dafaultImage from '../../assets/images/default-image.jpeg'
const TiposEvento = () => {
  const [frmEdit, setNextEvents] = useState(false); //está em modo de edição
  const [titulo, setTitulo] = useState("")
  const [tiposEvento, setTiposEvento ] = useState([]);
  
  useEffect(() => {
    //define a chamada na api
   async function loadEventsType() {
    try {
      const promise = await api.get(eventsTypeResource);
      setTiposEvento(promise.data)
      console.log(promise.data);
    } catch (error) {
      console.log("Erro na api", error);
    }
    }
    loadEventsType()
  }, []);
 async function handleSubmit(e) {
    e.preventDefault();
  
    if (titulo.trim().length < 3) {
      alert("O título dee ter pelo menos 3 caracteres")
    }

    try {
      const retorno = await api.post(eventsTypeResource, {
        titulo: titulo
      });
      setTitulo("");
    } catch (e) {
      alert("Deu ruim no submit")
    }
   
  }
  function handleUpdate(params) {
    alert('Bora Editar')
  }

  //cancela a tela/ação de edição (volta pra o form de Cadastro)
  function editActionAbort() {
    alert("Cancelar a tela de edição de Dados")
  }
  

  //mostra o form de edição
  function showUpdateForm()
  {
    alert("Vamos mostrar o forma de edição")
  }
  //apaga o tipo de evento na api
  function handleDelete(idEelement) {
    alert(`Vamos apagar o evento de id: ${idEelement}`)
  }
  return (
    <>
      <Main>
        <section className="cadastro-evento-section">
          <Container>
            <div className="cadastro-evento__box">
              {/* titulo */}
              <Titulo titleText={"Cadastro Tipo de Eventos"} />
              {/* imagem de ilustração */}
              {/* <ImageIlustrator imageRender={(ImageIlustrator.imageRender === '') ? dafaultImage : typeEventImage}/> */}
              <ImageIlustrator  imageRender={typeEventImage}/>
              <form action="" 
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
              >
                 
                 {/* Cadastrar ou editar? */}
                 {
                  !frmEdit ? 
                  (
                    //Cadastrar
                    <>
                    <Input 
                    id="Titulo"
                    placeholder="Título"
                    name="titulo"
                    type="text"
                    required="required"
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
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
                  <p>Tela de Edição</p>)
                 }
              </form>
            </div>
          </Container>
        </section>

        <section className="lista-eventos-section">
          <Container>
            <Titulo titleText={"Lista Tipo de Eventos"} color='white'/>
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