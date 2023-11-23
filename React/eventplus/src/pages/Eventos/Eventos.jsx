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
import api,  {eventsResource} from '../../Services/Service'

//Componente principal Eventos
const Eventos = () => {

    // Estados para controle
    const [titulo, setTitulo] = useState("");
    const [descricao, setDescricao] = useState("")
    const [data, setData] = useState("")
    const [options, setOptions] = useState([])
    const [tiposEvento, setTiposEvento] = useState(null)
    const [eventos, setNextEvents] = useState([])



    //Efeito após redenrização para carregar eventos
    useEffect(() => {
        async function loadEvents()
        {
            try {
                const promise = await api.get(eventsResource)
                setNextEvents(promise.data)
            } catch (error) {
                console.log("Erro na API", error);
            }
        }
        loadEvents();
    },[]);

    useEffect(() => {
        dePara();
      }, []);

    function dePara() {
        const arrayOptions = []
        eventos.forEach((e) => {
            arrayOptions.push({value: e.idEvento, text: e.nomeEvento})
        })
        setOptions(arrayOptions);
    }
    
    function handleSubmit(e)
    {
        e.preventDefault()
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
                                onSubmit={handleSubmit}
                            >
                                {/* Form de Edição */}
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
                                        additionalClass= "btn-cadastrar"
                                        name="cadastrar"
                                        type="submit"
                                    />
                                </>
                            </form>
                        </div>
                    </Container>
                </section>

                <section className="lista-eventos-section">
                    <Container>
                        <Titulo titleText={"Lista Eventos"} color='white'/>
                        <Table
                        dados={eventos}
                        />
                        
                    </Container>
                </section>
            </Main>
        </>



    );
};

export default Eventos;