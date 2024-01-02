
import { useEffect, useState } from 'react';
import './App.css';
import Header from './Components/Header/Header';
import FirstCadastro from './Pages/FirstCadastro/FirstCadastro';
import LoginPage from './Pages/LoginPage/LoginPage';
import Rotas from './Routes/route';
import { UseContext } from './Context/AuthContext';

function App() {
  const [userData, setUserData] = useState({});

  useEffect(() => {
    const token = localStorage.getItem("token");
    setUserData(token === null ? {} : JSON.parse(token))
  }, [])
  return (
    <>
      <UseContext.Provider value={{ userData, setUserData }}>
        <Rotas />
      </UseContext.Provider>
    </>
  );
}

export default App;
