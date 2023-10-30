import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

const Rotas = () => {
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route element={<Home/>} path={"/"}></Route>
                    <Route element={<Login/>} path={"/Login"}></Route>
                </Routes>
            </BrowserRouter>
        </div>
    );
};

export default Rotas;