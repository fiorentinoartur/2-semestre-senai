import React, { useContext, useState } from "react";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIlustrator";
import logo from "../../assets/icons/logo-pink.svg";
import { Input, Button } from "../../Components/Form/Form";
import man from "../../assets/icons/login.svg"
import api, {loginResource} from '../../Services/Service'
import "./Login.css";
import { UserContext, userDecodeToken } from "../../context/AuthContext";

const LoginPage = () => {
  
const [user, setUser] = useState(
    {
    email: "artur@comum.com",
    senha: ""
});

const {userData, setUserData} = useContext(UserContext) //importa os dados globais

async function handleSubmit(e) {
    e.preventDefault();

    if (user.senha.length >= 3) {
        try {
            const promise = await api.post(loginResource,{
                email: user.email,
                senha: user.senha
            })
            console.log("Dados do Usuário");
            console.log(promise.data.token);

            const userFullToken = userDecodeToken(promise.data.token);
            setUserData(userFullToken)
            localStorage.setItem("token", JSON.stringify(userFullToken))

        } catch (e) {
            return console.log('Erro: ', e);

        }

    }
    else
    {
        alert('Preencha os dados corretamente')
    }
  
}
  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={man}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {setUser({...user, email: e.target.value.trim()})}}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {
                setUser({...user,senha: e.target.value})}}
              placeholder="****"
            />

            <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              buttonText="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
              manipulationFunction={()=>{}}
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
