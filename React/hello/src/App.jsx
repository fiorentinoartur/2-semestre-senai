
import './App.css';
import Title from './components/Title/Title';
import CardEvento from './components/CardEventos/CardEVentos';
import Container from './components/Container/Container';
function App() {
  return (
    <div className="App">
      
      <Title nome="Artur" sobrenome="Fiorentino" />
      <br /> <br />
 

    <Container>
      <CardEvento titulo="Introdução a C#" text="Aprenda C# com Carlão de Ribeirão"/>
      <CardEvento />
      <CardEvento />
      <CardEvento />
    </Container>

      <h2></h2>
    </div>
  );
}

export default App;
