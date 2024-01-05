import React, { useContext } from 'react';
import './Nav.css'
import { UseContext } from '../../Context/AuthContext';
import { Link } from 'react-router-dom';

const Nav = ({}) => {

  const { userData, setUserData } = useContext(UseContext);
  return (
    <nav className='navbar d-flex'>
      {userData.nome && userData.role === '0' ? (
        <>
          <Link to="jogos-page">Jogos</Link>
          <Link to="/notificacoes-page">Notificacoes</Link>
        </>
      ) : (
        null
      )}
    </nav>
  );
};

export default Nav;