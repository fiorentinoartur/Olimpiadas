import React, { useContext, useEffect, useState } from 'react';
import './PerfilUsuario.css';
import { UseContext } from '../../Context/AuthContext';
import { useNavigate } from 'react-router-dom';
import Logout from '../../Assests/Icones/logout.svg';
import api, { usuriosResource } from '../../Services/Service';
import UserFoto from '../../Assests/Images/SemFoto 1.png'
import Settings from '../../Assests/Icones/setting.svg'
import Sound from '../../Assests/Icones/sound.svg'
import Notification from '../../Assests/Icones/notification.svg'
import YellowLogout from '../../Assests/Icones/logout-yellow.svg'

const PerfilUsuario = () => {
    const [showHideModal,setShowHideModal] = useState(false);
    const { userData, setUserData } = useContext(UseContext);
    const [user, setUser] = useState();
    const navigate = useNavigate();

    useEffect(() => {
        const loadUsuario = async () => {
            try {
                const promise = await api.get(`${usuriosResource}/${userData.userId}`);
                const data = promise.data;
                console.log(data.nome);

                setUser(data)
                const arrayDeBytes = [data.foto];

                const blob = new Blob([new Uint8Array(arrayDeBytes)], {type: 'image/*'});

                const imageUrl = URL.createObjectURL(blob)
                console.log(imageUrl);
            } catch (error) {
                console.error("Erro ao carregar usuário:", error);
            }
        };
        loadUsuario();
    }, [userData.userId]);

    const logout = () => {
        localStorage.removeItem("token");
        setUserData({});
        navigate("/");
    };
    const hideModal = () => {
            showHideModal ? setShowHideModal(false) : setShowHideModal(true)
    }

    return (
        <div className="perfil-usuario">
            {userData.nome && userData.role === '0' ? (
                <div className="perfil-user-flex d-flex">
                    <span className="perfil-usuario">{userData.nome}</span>
                    <img
                        title='Deslogar'
                        className='perfil-usuario__icon'
                        src={Logout}
                        onClick={logout}
                    />
                </div>
            ) : (
                <>
                  <div className="perfil-user-flex d-flex">

                    <span className="perfil-usuario">{userData.nome}</span>
                    <img
                        title='Deslogar'
                        className='perfil-usuario__icon'
                        src={UserFoto}
                        onClick={hideModal}
                    />
                  </div>

                  {showHideModal ? (
                        <div className='options-modal d-flex-column'>
                            <img src={Notification} alt="" />
                            <img src={Sound} alt="" />
                            <img src={Settings} alt="" />
                            <img
                             src={YellowLogout} 
                             alt=""
                             onClick={logout}
                             />
                        </div>

                  ) : null}
                </>
            )}
        </div>
    );
};

export default PerfilUsuario;
