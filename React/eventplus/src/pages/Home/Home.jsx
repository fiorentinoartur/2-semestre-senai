import React from 'react';
import "./Home.css"
import Banner from '../../Components/Banner/Banner';
import Main from '../../Components/Main/Main'
import VisionSection from '../../Components/VisionSection/VisionSection';
import ContactSection from '../../Components/ContactSection/ContactSection';
import Titulo from '../../Components/Titulo/Titulo';
import NextEvent from '../../Components/NextEvent/NextEvent'
import Container from '../../Components/Container/Container'
const Home = () => {
    return (
            <Main>
            <Banner />
            <section className='proximos-eventos'>
                <Container>
                <Titulo titleText={"Próximos Eventos"}/>

                <div className="events-box">
                    <NextEvent 
                    title={"Evento X"}
                    description={"Lorwmsdfççgsakçkakldsçngonasognoadksnglçnasgdlkndgokgljdsanljfbnasdjlgbjldabgabnsjgbndfjçnagsljçnjadlçsngjçsngjladnljçanlçjnjlançljanlçnsdalçnlgjadnasdknlnfañl~"}
                    eventDate={"10/11/2023"}
                    idEvent={"fdsgsagsa"}
                    />
                    <NextEvent />
                    <NextEvent />
                    <NextEvent />
                    <NextEvent />
                    <NextEvent />
                </div>
                </Container>
                    
                    
               
            </section>
                <VisionSection />
                <ContactSection />
            </Main>
    );
};

export default Home;