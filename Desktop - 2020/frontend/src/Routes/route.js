import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LoginPage from '../Pages/LoginPage/LoginPage';
import FirstCadastro from '../Pages/FirstCadastro/FirstCadastro';
import Header from '../Components/Header/Header';
import Footer from '../Components/Footer/Footer';
import { PrivateRouteAdministrador, PrivateRouteComum } from './PrivateRoute';
import NotificacoesPage from '../Pages/NotificacoesPage/NotificacoesPage';
import JogosPage from '../Pages/JogosPage/JogosPage';
import Test from '../Pages/Test/Test';
import UserComum from '../Pages/UserComumPage/UserComum';

const Rotas = () => {
    const isToken = localStorage.getItem('token');
    const parseToken = JSON.parse(isToken);

    return (
        <BrowserRouter>
            <Header />
            <Routes>
                {isToken !== null && parseToken.role === '0' ? (
                    <>
                        <Route element={

                            <NotificacoesPage />

                        } path="/notificacoes-page" />

                        <Route element={

                            <JogosPage />

                        } path="/" />
                    </>
                ) : isToken !== null && parseToken.role === '1' ? (
                    <>
                        <Route element={

                            <UserComum />

                        } path="/" />
                    </>
                ) : (
                    <>
                        <Route element={<LoginPage />} path="/" />
                        <Route element={<FirstCadastro />} path="/first-cadastro" />
                    </>
                )}
            </Routes>
            <Footer />
        </BrowserRouter>
    );
};

export default Rotas;
