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
import Notification from '../../Components/Notification/Notification';
import eventImage  from '../../assets/icons/evento.svg'
import dafaultImage from '../../assets/images/default-image.jpeg'
const TiposEvento = () => {
  const [frmEdit, setNextEvents] = useState(false); //está em modo de edição
  const [titulo, setTitulo] = useState("")
  const [tiposEvento, setTiposEvento ] = useState([]);
  const[notifyUser, setNotifyUser] = useState();
  //Função que após a página/DOM
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



// function atualizaEventosTela(idEvent)
// {
//   const xpto = tiposEvento.filter((t) => {
//     return t.idEvent !== idEvent 
//   });
//   setTiposEvento(xpto)
// }

//cadastrar a atualização
 async function handleUpdate(e) {
   e.preventDefault();


  }

  
  //mostra o form de edição
 async function showUpdateForm(idElement)
 {
   try {
      const promise = await api.get(eventsTypeResource+'/'+idElement)
      console.log(promise.data.titulo)
      setTitulo(promise.data.titulo)
      
    } catch (error) {
      
    }
   setNextEvents(true)
  }
  //cancela a tela/ação de edição (volta pra o form de Cadastro)
  function editActionAbort() {
    setNextEvents(false)
  }
  
  //apaga o tipo de evento na api
  async function handleDelete(idEelement) {    
   if (!window.confirm("Confirma a exclusão")) {
    return;
   }
    try {
      const promise = await api.delete(eventsTypeResource+'/'+idEelement)
     if (promise.status == 204) {
     // setTiposEvento([]) //Atualiza a variável e roda o useStatete novamente
     setNotifyUser({
      titleNote:"Sucesso",
       textNote:"Cadastro excluido com sucesso",
       imgIcon:"sucess",
       imgAlt:
       "Imagem de ilustração de sucesso. Moça segurando um balção com símbolo de confirmação ok",
       showMessage: true
   }) 

        //DESAFIO: Fazer uma função para retirar o retirar apagado do array tipoEventos
        const buscaEventos = await api.get(eventsTypeResource)
        // console log(BuscaEvetosData)
        setTiposEvento(buscaEventos.data)
     }
    } catch (error) {
      alert('Cadastrado com sucesso')
    }
   alert('Deletado com suceeso')
  }
  return (
    <>
    {<Notification {...notifyUser} setNotifyUser={setNotifyUser}/>}
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
                    className=""
                     additionalClass="button-component--middle"
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