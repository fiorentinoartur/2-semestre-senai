import React, { useContext, useState } from "react";
import { Route, BrowserRouter, Routes } from "react-router-dom";

//Imports dos componentes - PÁGINA
import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage";
import Nav from "./components/Nav/Nav";
import ImportantePage from "./pages/ImportantePage/ImportantePage";
import MeusPedidos from "./pages/MeusPedidos/MeusPedidos";
import { ThemeContext } from "./context/ThemeContext";


const Rotas = () => {
const[theme, setTheme] = useState("")

//Verifica se o tema esta no localStorage ou assume o tema light
function getThemeLocalStorage(){
    setTheme(localStorage.getItem("theme") !== null ? localStorage.getItem("theme") : "light")
}
useState()
    return (
        <BrowserRouter>
            <ThemeContext.Provider value={{theme, setTheme}}>
                <Nav />
                <Routes>
                    <Route element={<HomePage />} path={"/"} exact />
                    <Route element={<ProdutoPage />} path={"/produtos"} />
                    <Route element={<LoginPage />} path={"/login"} />
                    <Route element={<LoginPage />} path={"*"} />
                    <Route element={<ImportantePage />} path="importante" />
                    <Route element={<MeusPedidos />} path="meus-pedidos" />
                </Routes>
            </ThemeContext.Provider>
        </BrowserRouter>
    );
}
export default Rotas;
