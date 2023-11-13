import React, { useState } from 'react';
import './TiposEvento.css'
import Titulo from '../../Components/Titulo/Titulo';
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import typeEventImage from '../../assets/icons/tipo-evento.svg'
import eventImage  from '../../assets/icons/evento.svg'
import dafaultImage from '../../assets/images/default-image.jpeg'
const TiposEvento = () => {
  const [frmEdit, setNextEvents] = useState(false); //está em modo de edição
  function handleSubmit(params) {
    alert('Bora Cadastrar')
  }
  function handleUpdate(params) {
    alert('Bora Editar')
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
                  !frmEdit ? (<p>Tela de Cadastro</p>) : (<p>Tela de Edição</p>)
                 }
              </form>
            </div>
          </Container>
        </section>
      </Main>
    </>
  );
};

export default TiposEvento;