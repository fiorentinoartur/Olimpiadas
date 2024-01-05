import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import LoginPage from '../Pages/LoginPage/LoginPage';
import FirstCadastro from '../Pages/FirstCadastro/FirstCadastro';

import Header from '../Components/Header/Header';
import Footer from '../Components/Footer/Footer';
import { PrivateRoute } from './PrivateRoute';
import NotificacoesPage from '../Pages/NotificacoesPage/NotificacoesPage';
import JogosPage from '../Pages/JogosPage/JogosPage';
import Test from '../Pages/Test/Test';
import UserComum from '../Pages/UserComumPage/UserComum';
const Rotas = () => {
    return (
        <BrowserRouter>
        <Header/>
            <Routes>
                <Route  
                element={<LoginPage />}
                path='/' exact />

                <Route
                element={<FirstCadastro/>}
                path='/first-cadastro'/>


                <Route element ={
                    <PrivateRoute>
                        <NotificacoesPage />
                    </PrivateRoute>
                } path='/notificacoes-page'
                />

                <Route element ={
                    <PrivateRoute>
                        <JogosPage />
                    </PrivateRoute>
                } path='/jogos-page'
                />

                <Route element = {
                    <PrivateRoute>
                        <UserComum />
                    </PrivateRoute>
                } path='/userComum-page'
                />

            <Route element ={<Test />}
            path='/test'/>
            </Routes>
            <Footer/>
        </BrowserRouter>
    );
};

export default Rotas;