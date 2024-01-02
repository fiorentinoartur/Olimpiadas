import React, { useContext } from 'react';
import './PerfilUsuario.css'
import { UseContext } from '../../Context/AuthContext';
import { useNavigate } from 'react-router-dom';
import Logout from '../../Assests/Icones/logout.svg';

const PerfilUsuario = () => {
    const {userData, setUserData} = useContext(UseContext);

    const navigate = useNavigate();

    const logout = () => {
        localStorage.removeItem("token");
        setUserData({});
        navigate("/")
    }
    return (
        <div className="perfil-usuario">
            {userData.nome ? (
               
                <div className="perfil-user-flex d-flex">

                    <span className="perfil-usuario">{userData.nome}</span>
                    <img
                    title='Deslogar'
                    className='perfil-usuario__icon'
                    src={Logout}
                    onClick={logout}
    
                    />
                </div>
             
            ): (
                ""
            )}
        </div>
    );
};

export default PerfilUsuario;