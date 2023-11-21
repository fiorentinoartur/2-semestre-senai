import React, { useEffect, useState } from 'react';
import "./Home.css"
import Banner from '../../Components/Banner/Banner';
import Main from '../../Components/Main/Main'
import VisionSection from '../../Components/VisionSection/VisionSection';
import ContactSection from '../../Components/ContactSection/ContactSection';
import Titulo from '../../Components/Titulo/Titulo';
import NextEvent from '../../Components/NextEvent/NextEvent'
import Container from '../../Components/Container/Container'
import axios from 'axios';
import api from '../../Services/Service'
import { nextEventsResource } from '../../Services/Service';
import Notification from '../../Components/Notification/Notification';
const Home = () => {
    //dados mocados 
    const [nextEvents, setNextEvents] = useState([]);
    const[notifyUser, setNotifyUser] = useState();
   // roda somente na inicialização do componente
    useEffect(() => {
        async function getNextEvents() {
            try {
                const promise = api.get(nextEventsResource);
                const dados = (await promise).data;
                setNextEvents(dados); //atualiza o state
            }
            catch(error) {
                setNotifyUser({
                    titleNote: "Erro",
                    textNote:"Não foi possível carregar os próximos eventos",
                    imgIcon:"danger",
                    imgAlt:"Imagem de ilustração de erro. Rapaz segurando um balão com símbolo X.",
                    showMessage: true
                  })
            }
        }
        getNextEvents(); //Roda a função
    }, []);
    return (
        <Main>
             {<Notification {...notifyUser} setNotifyUser={setNotifyUser}/>}
            <Banner />
            <section className='proximos-eventos'>
                <Container>
                    <Titulo titleText={"Próximos Eventos"} />

                    <div className="events-box">
                        {
                            nextEvents.map((e) => {
                                return <NextEvent
                                    key={e.idEvent}
                                    title={e.nomeEvento}
                                    description={e.descricao}
                                    eventDate={e.dataEvento}
                                    idEvento={e.idEvento}
                                />
                            })
                        }
                    </div>
                </Container>



            </section>
            <VisionSection />
            <ContactSection />
        </Main>
    );
};

export default Home;