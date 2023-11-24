import React from 'react';
import Titulo from '../../Components/Titulo/Titulo';
import Logo from '../../assets/icons/logo-pink.svg'
import Container from '../../Components/Container/Container';
const Login = () => {

    return (
        <>
        <section className="login">
            <Container>
            <form action="">
                <img
                    src={Logo}
                    alt="" />
            </form>

            </Container>
        </section>
        </>
    );
};

export default Login;