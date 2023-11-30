// Importando as dependências e componentes necessários de arquivos externos
import React, { useContext, useEffect, useState } from "react";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIlustrator";
import logo from "../../assets/icons/logo-pink.svg";
import { Input, Button } from "../../Components/Form/Form";
import man from "../../assets/icons/login.svg";
import api, { loginResource } from '../../Services/Service'; 
import { Navigate, useNavigate } from "react-router-dom";
import "./Login.css";
import { UserContext, userDecodeToken } from "../../context/AuthContext";

// Definindo o componente LoginPage
const LoginPage = () => {
  
  // Configurando o estado para os dados do usuário com valores padrão
  const [user, setUser] = useState({
    email: "artur@comum.com",
    senha: ""
  });

  // Acessando os dados globais do usuário e a função de definição do contexto
  const { userData, setUserData } = useContext(UserContext);

  const navigate = useNavigate();


  useEffect(() => {
    if(userData.nome) Navigate("/login")
},[userData])
  // Lidando com a submissão do formulário
  async function handleSubmit(e) {
    e.preventDefault();

    // Verificando se a senha atende a um requisito mínimo de comprimento
    if (user.senha.length >= 3) {
      try {
        // Fazendo uma requisição POST para a API para login do usuário
        const promise = await api.post(loginResource, {
          email: user.email,
          senha: user.senha
        });

        // Registrando o token do usuário no console
        console.log("Dados do Usuário");
        console.log(promise.data.token);

        // Decodificando e definindo os dados do usuário a partir do token recebido
        const userFullToken = userDecodeToken(promise.data.token);
        setUserData(userFullToken);

        // Armazenando o token do usuário no armazenamento local
        localStorage.setItem("token", JSON.stringify(userFullToken));

        navigate("/")
      } catch (e) {
        // Lidando com erros na requisição da API
       alert('Verifique os dados e a conexão com a internet')
       console.log("ERROS NO LOGIN DI USUÁRIO");
       console.log(e);
      }
    } else {
      // Alertando o usuário se os dados do formulário estiverem incompletos
      alert('Preencha os dados corretamente');
    }
  }

  // Renderizando a interface do usuário da página de login
  return (
    <div className="layout-grid-login">
      <div className="login">
        {/* Seção de ilustração */}
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={man}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        {/* Seção de formulário */}
        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          {/* Formulário para login do usuário */}
          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            {/* Campo de entrada para nome de usuário (email) */}
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => { setUser({ ...user, email: e.target.value.trim() }) }}
              placeholder="Nome de Usuário"
            />
            
            {/* Campo de entrada para senha */}
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => { setUser({ ...user, senha: e.target.value }) }}
              placeholder="****"
            />

            {/* Link para recuperação de senha */}
            <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a>

            {/* Botão para submissão do formulário */}
            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
              manipulationFunction={() => { }}
            />
          </form>
        </div>
      </div>
    </div>
  );
};

// Exportando o componente LoginPage
export default LoginPage;
