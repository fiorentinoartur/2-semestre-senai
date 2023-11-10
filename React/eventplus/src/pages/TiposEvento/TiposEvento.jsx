import React from 'react';
import Titulo from '../../Components/Titulo/Titulo';
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
const TiposEvento = () => {
  return (
    <>
      <main>
        <section className="cadastro-evento-section">
          <Container>
            <div className="cadastro-evento-box">
              {/* titulo */}
              <Titulo titleText={"Cadastro Tipo de Eventos"} />
              {/* imagem de ilustração */}
              <ImageIlustrator />
              {/* componente de formulário */}
              <form action="" className="ftipo-evento">
                <p>Formulário será criado aqui</p>
              </form>
            </div>
          </Container>
        </section>
      </main>
    </>
  );
};

export default TiposEvento;