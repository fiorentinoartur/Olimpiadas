import React, { useContext, useEffect, useState } from 'react';
import './LoginPage.css'
import Container from '../../Components/Container/Container'
import Header from '../../Components/Header/Header';
import Main from '../../Components/Main/Main';
import IconEmail from '../../Assests/Icones/email.svg'
import IconSenha from '../../Assests/Icones/password.svg'
import Footer from '../../Components/Footer/Footer';
import { Link, useNavigate, Navigate } from 'react-router-dom';
import { UseContext, userDecodeToken } from '../../Context/AuthContext';
import api, { loginResource } from '../../Services/Service'
import { Button, Input } from '../../Components/FormComponents/Form';

import ModalSenha from '../../Components/ModalAlterarSenha/ModalSenha';
import ModalNotificacao from '../../Components/ModalNotificacoes/ModalNotificacao';
const LoginPage = () => {

    //Criar um state pra usuario
    const [user, setUser] = useState({
        email: "administrador@email.com",
        senha: ""
    })
    const { userData, setUserData } = useContext(UseContext)
    const [manterConectado, setManterConectado] = useState()
    const [showModal, setShowModal] = useState(false)
    const navigate = useNavigate();


    // useEffect(() => {
    //     if(userData.nome) Navigate('/login')
    // },[userData])


    const handleSubmit = async (e) => {
        e.preventDefault();

        if (user.senha.length >= 3) {
            try {
                
                const promise = await api.post(loginResource, {
                    email: user.email,
                    senha: user.senha
                });

                console.log("Dados do Usuário");

                console.log(promise.data.token);

                const userFullToken = userDecodeToken(promise.data.token);
                setUserData(userFullToken)
                localStorage.setItem("token", JSON.stringify(userFullToken))
                navigate('/notificacoes-page')
                

                

            } catch (error) {
                alert('Preencha os dados corretamentes')
            console.log(error);
            }
        }
    }

    const showHideModal =async () => {
        try {
            const encodedEmail = encodeURIComponent(user.email);
            const promise = await api.get(`?email=${encodedEmail}`);
            if (promise.data != null && promise.data != "") {
                
                setShowModal(showModal ? false : true);
            }
            else{
                alert("Digite um email válido")
            }
        } catch (error) {
            alert(error.message);
            console.log(error.message); // use 'message' em minúsculas
        }
        
        
            
      

    }
    return (
        <>
            <Main>
                <Container additionalClass="section-login">
                    <form className='form-fut d-flex-column' onSubmit={handleSubmit}>
                        <h1>Faça login na sua conta</h1>
                        <hr className='first-hr' />
                        <p className='text-inform'>Faça login para ter acesso as útimas notícias dos campeonatos mais formentados da galera. Explore diversas funcionalidades, tenha acesso simultâneos a placares dos jogos e fique por dentro de todas as novidades!!!</p>

                        <label htmlFor="">Email</label>
                        <div className="input-login input-email">
                            <img className='icon-email' src={IconEmail} alt="" />
                            <Input
                                placeholder="Digite seu email"
                                type="email"
                                name="login"
                                required={true}
                                value={user.email}
                                manipulationFunction={(e) => {
                                    setUser({ ...user, email: e.target.value.trim() })
                                }}
                            />

                        </div>

                        <label htmlFor="">Senha</label>
                        <div className="input-login">
                            <img className='icon-email' src={IconSenha} alt="" />
                            <Input
                                placeholder="Digite sua senha:"
                                value={user.senha}
                                type="password"
                                required={true}
                                manipulationFunction={(e) => {
                                    setUser({ ...user, senha: e.target.value.trim() })
                                }}
                            />
                        </div>

                        <div className="actions-form">
                            <div className='checkbox-conectado'>
                               <Input
                               type="checkbox"
                             checked={manterConectado}
                               
                               manipulationFunction={(e) => {
                                setManterConectado(e.target.checked)
                               }}
                               />
                                <p>Manter-me conectado</p>
                            </div>
                            <p 
                            onClick={() => {
                                showHideModal()
                            }}
                            
                            >Esqueceu a senha?</p>
                        </div>
                        <Button
                            textButton="Login"
                            additionalClass="btn-login"
                            name="btn-login"
                            type="submit"
                        />

                        <hr className='second-hr' />
                        <div className='rodape-form'>
                            <p>Não tem uma conta ainda?</p>
                            <Link to="first-cadastro">
                                Cadastre-se
                            </Link>
                        </div>
                    </form>
                </Container>

            </Main>
{showModal ? (

    <ModalSenha
    showHideModal={showHideModal}
    emailUser={user.email}
    />
) : null}
        </>

    );
};

export default LoginPage;