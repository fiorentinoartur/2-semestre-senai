import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

//Import das paginas
import Home from '../pages/Home/Home';
import Login from '../pages/Login/Login';
import Eventos from '../pages/Eventos/Eventos';
import TiposEvento from '../pages/TiposEvento/TiposEvento';
import Teste from '../pages/Teste/Teste';
import Header from '../Components/Header/Header';
import Footer from '../Components/Footer/Footer';
import { PrivateRoute } from './PrivateRoute';
import EventosAlunos from '../pages/EventosAlunos/EventosAlunos';

const Rotas = () => (
    <BrowserRouter>
        <Header />
        <Routes>
            <Route element={<Home />} path="/" exact></Route>
            <Route
                element={
                    <PrivateRoute>
                        <Eventos />
                    </PrivateRoute>
                }
                path={"/eventos"}
                />
                <Route
          element={
            <PrivateRoute>
              <EventosAlunos />
            </PrivateRoute>
          }
          path={"/eventos-aluno"}
        />
                <Route element={
                <PrivateRoute>
                    <TiposEvento />
                </PrivateRoute>       
                } path="/tipos-evento" />
      
            <Route element={<Login />} path="/login" />
            <Route element={<Teste />} path="/teste" />
        </Routes>
        <Footer />
    </BrowserRouter>
);

export default Rotas;