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
import Spinner from '../../Components/Spinner/Spinner'


const TiposEvento = () => {
  const [frmEdit, setNextEvents] = useState(false); //está em modo de edição
  const [titulo, setTitulo] = useState("")
  const [idEvento, setidEvento] = useState(null); //para editar, por causa do evento
  const [tiposEvento, setTiposEvento ] = useState([]);
  const[notifyUser, setNotifyUser] = useState();
  const [showSpinner, setShowSpinner] = useState(false)
  //Função que após a página/DOM
  useEffect(() => {
    //define a chamada na api
   async function loadEventsType() {
    setShowSpinner(true)
    try {
      const promise = await api.get(eventsTypeResource);
      setTiposEvento(promise.data)
      console.log(promise.data);
    } catch (error) {
      console.log("Erro na api", error);
    }
    setShowSpinner(false)
    }
    loadEventsType()
  }, []);

  
//*************************************CADASTRAR***********************************/
 async function handleSubmit(e) {
    e.preventDefault();
  
    if (titulo.trim().length < 3) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote:"O título deve conter pelo menos 3 caracteres",
        imgIcon:"warning",
        imgAlt:"Imagem de ilustração de aviso. Moça em frente a um símbolo de exclamação.",
        showMessage: true
      })
      //Atualiza a tela
      return;
    }
    setShowSpinner(true)
    try {
      const retorno = await api.post(eventsTypeResource, {
        titulo: titulo
      });
      setNotifyUser({
        titleNote: "Sucesso",
        textNote:"Tipo Evento cadastrado com sucesso",
        imgIcon:"success",
        imgAlt:"Imagem de ilustração de sucesso. Moça em frente a um símbolo de exclamação.",
        showMessage: true
      })
      setTitulo("");
      const buscaEventos = await api.get(eventsTypeResource)
      setTiposEvento(buscaEventos.data); //aqui retorna um array, então de boa!
    } 
    catch (e) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote:"Não foi possível cadastrar um tipo de evento",
        imgIcon:"warning",
        imgAlt:"Imagem de ilustração de aviso. Moça em frente a um símbolo de exclamação.",
        showMessage: true
      })
      setShowSpinner(false)
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
   setShowSpinner(true)
   try {
    //Atualizar na api
    const retorno = await api.put(eventsTypeResource+"/"+idEvento, {
      titulo : titulo
    }) 
  
    //o id está no state
    if (retorno.status == 204) {
      //Reseta o state


      //Notifica o usuário
      setNotifyUser({
         titleNote:"Sucesso",
         textNote:"Atualizado com sucesso",
         imgIcon:"success",
         imgAlt:"Imagem de ilustração de sucesso. Moça segurando um balção com símbolo de confirmação ok",
         showMessage: true
     }) 

     const buscaEventos = await api.get(eventsTypeResource)

     setTiposEvento(buscaEventos.data)
  
     editActionAbort();
    }
   } catch (error) {
    console.log(error);
   }
   setShowSpinner(false)
  }

  
  //mostra o form de edição
 async function showUpdateForm(idElement)
 {
  setidEvento(idElement) //preenche o id do elemento para poder editar
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
    setidEvento(null) //reseta as variáveis
  }
  
  //apaga o tipo de evento na api
  async function handleDelete(idEelement) {    
   if (!window.confirm("Confirma a exclusão")) {
    return;
   }
   setShowSpinner(true)
    try {
      const promise = await api.delete(eventsTypeResource+'/'+idEelement)
     if (promise.status == 204) {
     // setTiposEvento([]) //Atualiza a variável e roda o useStatete novamente
     setNotifyUser({
      titleNote:"Sucesso",
       textNote:"Cadastro excluido com sucesso",
       imgIcon:"success",
       imgAlt:
       "Imagem de ilustração de sucesso. Moça segurando um balção com símbolo de confirmação ok",
       showMessage: true
   }) 

        //DESAFIO: Fazer uma função para retirar o retirar apagado do array tipoEventos
        const buscaEventos = await api.get(eventsTypeResource)
        // console log(BuscaEvetosData)
        setTiposEvento(buscaEventos.data)

        editActionAbort();
     }
    } catch (error) {
      alert('Cadastrado com sucesso')
    }
    setShowSpinner(false)
   alert('Deletado com suceeso')
  }
  return (
    <>
    {<Notification {...notifyUser} setNotifyUser={setNotifyUser}/>}
    {showSpinner ? <Spinner /> : null}

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
                    className="Atualizar"
                    additionalClass="button-component--middle"
                    manipulationFunction={(event) => {
                      handleUpdate(event)
                    }}
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