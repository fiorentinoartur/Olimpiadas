import React, { useEffect, useState } from 'react';
import { useNavigate} from 'react-router-dom';
import './FirstCadastro.css'
import './CadastroPage.css'
import Header from '../../Components/Header/Header';
import Footer from '../../Components/Footer/Footer';
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import IconUser from '../../Assests/Icones/user.svg'
import { Link } from 'react-router-dom';
import { Button, Input, Select } from '../../Components/FormComponents/Form';
import api, { timesResource, cadastrarUserResource } from '../../Services/Service'

import IconEmail from '../../Assests/Icones/email.svg'
import IconSenha from '../../Assests/Icones/password.svg'

const FirstCadastro = () => {
    const navigate = useNavigate()
    const [times, setTimes] = useState([]);
    const [dados, setDados] = useState({
        nomeUser: "",
        sexo: "",
        time: null,
        nascimento: "",
        foto: null,
        email: "",
        senha: "",
        perfil: "1"
    });
    const [showSecondPart, setShowSecondPart] = useState(false)
    useEffect(() => {
        const loadTimes = async () => {
            try {
                const promiseTimes = await api.get(timesResource)

                const arrayTimes = [];

                promiseTimes.data.forEach((times) => {
                    arrayTimes.push({ value: times.id, text: times.nome })
                });

                setTimes(arrayTimes);



            } catch (error) {
                console.log("Erro" + error.message);
            }

        }
        loadTimes()
    }, []);
    const handleSalvar = () => {
        setShowSecondPart(true)
    }
    const handleUpdate = async (e) => {
        e.preventDefault();
        try {
            const formData = new FormData();
            formData.append("nome", dados.nomeUser);
            formData.append("sexo", dados.sexo);
            formData.append("timeFavoritoId", dados.time);
            formData.append("nascimento", dados.nascimento);
            formData.append("foto", dados.foto);  
            formData.append("email", dados.email);
            formData.append("senha", dados.senha);
            formData.append("perfil", dados.perfil);
    
            const promise = await api.post(cadastrarUserResource, formData, {
                headers: {
                    "Content-Type": "multipart/form-data",
                },
            });
    
            alert("Cadastrado com sucesso");
          navigate('/')
        } catch (error) {
            console.log("Erro ao cadastrar:", error);
            console.log("Resposta do servidor:", error.response);
        }
    };
    
    

    return (
        <>
            <Main>
                <Container additionalClass="cadastro-first-flex d-flex">
                    {showSecondPart ? (
                        <form action="" className='cadastro-form' onSubmit={handleUpdate} >
                            <h1>Cadastrar-se</h1>
                            <hr className='hr-cadastro' />
                            <div className="registrtion-progress">
                                <div className='d-flex-colunm'>
                                    <div className='circle circle1-page2 '>
                                        <p>1</p>
                                    </div>
                                </div>
                                <hr className='progress-line' />
                                <div className="circle circle2-page2">
                                    <p>2</p>
                                </div>
                                <p className='first-text-page2'>Indentificação</p>
                                <p className='second-text-page2'>Dados Pessoais</p>
                            </div>


                            <label htmlFor="" className='label-email'>Email</label>
                            <div className="input-login input-email">
                                <img className='icon-email' src={IconEmail} alt="" />
                                <Input
                                    placeholder="Digite seu email:"
                                    value={dados.email}
                                    manipulationFunction={(e) => {
                                        setDados({
                                            ...dados,
                                            email: e.target.value
                                        })
                                    }}
                                />
                            </div>

                            <label htmlFor="">Senha</label>
                            <div className="input-login">
                                <img className='icon-email' src={IconSenha} alt="" />
                                <Input
                                    required={true}
                                    type="password"
                                    placeholder="Digite sua senha:"
                                />
                            </div>

                            <label htmlFor="">Confirmar Senha</label>
                            <div className="input-login input-confirm">
                                <img className='icon-email' src={IconSenha} alt="" />
                                <Input
                                    required={true}
                                    type="password"
                                    placeholder="Confirme sua senha:"
                                    value={dados.senha}
                                    manipulationFunction={(e) => {
                                        setDados({
                                            ...dados,
                                            senha: e.target.value
                                        })
                                    }}
                                />
                            </div>

                            <Button
                                additionalClass="btn-Cadastro"
                                textButton="Cadastrar"
                                type="submit"
                            />
                            <div className="exists-account d-flex">
                                <p>Já tem uma Conta?</p>
                                <Link to="/">
                                    Login
                                </Link>
                            </div>
                        </form>) :
                        (<form action="" className="cadastro-first" >
                            <h1>Cadastrar-se</h1>
                            <hr className='hr-cadastro' />
                            <div className="registrtion-progress">
                                <div className='d-flex-colunm'>
                                    <div className='circle circle1 '>
                                        <p>1</p>
                                    </div>
                                </div>
                                <hr className='progress-line' />
                                <div className="circle circle2">
                                    <p>2</p>
                                </div>
                                <p className='first-text'>Indentificação</p>
                                <p className='second-text'>Dados Pessoais</p>
                            </div>

                            <label htmlFor="" className='label-email'>Nome</label>
                            <div className="input-login input-email">
                                <img className='icon-user' src={IconUser} alt="" />
                                <Input
                                    placeholder='Digite seu nome completo:'
                                    type='text'
                                    required={true}
                                    value={setDados.nomeUser}
                                    manipulationFunction={(e) => {
                                        setDados({
                                            ...dados,
                                            nomeUser: e.target.value
                                        })
                                    }}
                                />
                            </div>
                            <label htmlFor="">Selecione o Sexo</label>
                            <div className="container-sexo d-flex">
                                <div className="input-masculino d-flex">
                                    <p>Masculino</p>
                                    <Input
                                        value={dados.sexo}
                                        type="radio"
                                        manipulationFunction={() => {
                                            setDados({
                                                ...dados,
                                                sexo: "M"
                                            })
                                        }}
                                    />
                                </div>
                                <div className="input-masculino d-flex">
                                    <p>Feminino</p>
                                    <Input
                                        value={dados.sexo}
                                        type="radio"
                                        manipulationFunction={() => {
                                            setDados({
                                                ...dados,
                                                sexo: "F"
                                            })
                                        }}
                                    />
                                </div>
                            </div>
                            <div className="container-time-nascimento d-flex">
                                <div className="time d-flex-column">
                                    <label htmlFor="">Time Favorito</label>
                                    <Select
                                        value={dados.time}
                                        options={times}
                                        manipulationFunction={(e) => {
                                            setDados({
                                                ...dados,
                                                time: e.target.value
                                            })
                                        }}
                                        defaultValue={dados.time}
                                    />
                                </div>

                                <div className="nascimento d-flex-column">
                                    <label htmlFor="">Data Nascimento</label>
                                    <Input
                                        type="date"
                                        value={dados.nascimento}
                                        manipulationFunction={(e) => {
                                            setDados({
                                                ...dados,
                                                nascimento: e.target.value
                                            })
                                        }}

                                    />
                                </div>
                            </div>

                            <div className="user-foto d-flex">
                                <label htmlFor="arquivo" className='label-foto'>Enviar o foto</label>
                                <Input
                                    id="arquivo"
                                    name="arquivo"
                                    type="file"
                                    accept="image/*"
                                    manipulationFunction={(e) => {
                                        setDados({
                                            ...dados,
                                            foto: e.target.files[0]
                                        })
                                    }}
                                />


                                <p>Nenhuma foto selecionada...</p>
                            </div>
                            <div className='salvar-form d-flex'>

                                <Button
                                    textButton="Salvar"
                                    additionalClass="btn-salvar"
                                    manipulationFunction={handleSalvar}
                                />
                                <div className='d-flex'>

                                    <p>Já tem uma Conta?</p>
                                    <Link to="/">
                                        Login
                                    </Link>
                                </div>
                            </div>
                        </form>)
                    }

                </Container>
            </Main>

        </>
    );
};

export default FirstCadastro;