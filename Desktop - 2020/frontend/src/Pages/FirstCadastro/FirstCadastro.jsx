import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
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
    const [sexoMasculino, setSexoMasculino] = useState(false);
    const [sexoFeminino, setSexoFeminino] = useState(false);
    const [dados, setDados] = useState({
        nomeUser: "",
        sexo: "",
        time: "",
        nascimento: "",
        foto: null,
        email: "",
        senha: "admin123",
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
console.log(dados.nascimento.trim());
        if (dados.nomeUser.trim() == "" || dados.sexo.trim() == "" || dados.nascimento.trim() == "" ) {
            alert("Preencha todos os campos corretamente");
            return;
        }

        const date = new Date();
        const nascimentoDate = new Date(dados.nascimento)

        if (date.getFullYear() - nascimentoDate.getFullYear() < 18
            || (date.getFullYear - nascimentoDate.getFullYear() === 18
                && date.getMonth() < nascimentoDate.getMonth)
            || (date.getFullYear() - date.getFullYear() === 18
                && date.getMonth() === nascimentoDate.getMonth()
                && date.getDate() < nascimentoDate.getDate())
        ) {
            alert("O usuário deve ter no mínimo 18 anos!!!")
            return;
        }
        if(dados.foto != null)
        {
            const extensaoImage = ['bmp','png','jpg','jpeg']
            const fileName = dados.foto.name
            //pop é usado para obter o último elemento do array
            const fileExtesion = fileName.split('.').pop().toLowerCase();

            if (extensaoImage.indexOf(fileExtesion)  === - 1) {
                alert ("Por favor, escolha um arquivo de imagem válido bmp, png, jpg, jpeg");
                return;
            }
        }
        setShowSecondPart(true)

    }

    const handleUpdate = async (e) => {
        e.preventDefault();
const patternEmail = /^[a-zA-Z]{1}[a-zA-Z0-9]{3,}(?:[._-][a-zA-Z0-9]{4,})?@[a-zA-Z]{3,}\.[a-zA-Z]{2,}$/
if (!patternEmail.test(dados.email)) {
    alert
    (`
   1º O email deve começar com uma letra não importando maiúscula e minúscula e ter no mínimo 4 caracteres
   2º O email pode conter somente um dos seguintes caracteres especiais sendo eles:
        Traço (-)
        Traço baixo (_)
        Ponto (.)
   3º Antes e depois do caractere especial deve conter pelo menos 4 caracteres.
   4º Após o @ não são permitidos caracteres numéricos ou especiais.
   5º O domínio deve conter pelo menos 3 caracteres.
   6º Após o domínio no mínimo 2 caracteres.

    `)
    return;
}
const isEmaiValid = await validarEmail();

console.log(isEmaiValid);
if(isEmaiValid)
{
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

        alert("Usuário Cadastrado com sucesso");
        navigate('/')
    } catch (error) {
        alert('Erro no servidor!')
        console.log("Erro ao cadastrar:", error);
        console.log("Resposta do servidor:", error.response);
    }
};
}

    const validarEmail = async () => {
        const encodingEmail = encodeURIComponent(dados.email);
        
        const textMessageEmail = document.getElementById('textMessageEmail');
        try {
            const response = await api.get(`?email=${encodingEmail}`);
            
            if (response.data !== null && response.data !== "") {
                textMessageEmail.innerText = 'Email já cadastrado';
                textMessageEmail.style.backgroundColor = 'red';
                textMessageEmail.style.color = 'white';
              
            return false;
            } else {
                textMessageEmail.innerText = ''
                textMessageEmail.style.backgroundColor = 'transparent';
                return true
            }
        } catch (error) {
            console.error("Erro ao validar e-mail:", error);
       
        }
    };
const extensaoImage = () => {
const textFile = document.getElementById('textFile')

if (dados.foto != null) {
    textFile.innerHTML = dados.foto.name
}

}
    return (
        <>
            <Main>
                <Container additionalClass="cadastro-first-flex d-flex">
                    {showSecondPart ? (
                        <form action="" className='form-cadastrar cadastro-form ' onSubmit={handleUpdate} >
                            <h1>Cadastrar-se</h1>
                            <hr className='hr-cadastro' />
                            <div className="registrtion-progress registrtion-progress-dados-pessoais">
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
                            <div className=" input-email-cadastro input-email d-flex input-login ">
                                <img className='icon-email' src={IconEmail} alt="" />
                                <Input
                                id="email-cadastro"
                                onBlur={validarEmail}
                                    placeholder="Digite seu email:"
                                    value={dados.email}
                                    manipulationFunction={(e) => {
                                        setDados({
                                            ...dados,
                                            email: e.target.value
                                        })
                                  
                                    }}
                                />
                                 <p id='textMessageEmail'></p>
                            </div>

                            {/* <label htmlFor="">Senha</label>
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
                            </div> */}

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
                            <div className="input-login  input-email ">
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
                                        type="radio"
                                        checked={sexoMasculino}
                                        manipulationFunction={() => {
                                            setSexoMasculino(true);
                                            setSexoFeminino(false)
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
                                        type="radio"
                                        checked={sexoFeminino}
                                        manipulationFunction={() => {
                                          setSexoFeminino(true)
                                          setSexoMasculino(false)
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
                                        required={true}
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
                                    accept="image/bmp,  image/png, image/jpg, image/jpeg"
                                    manipulationFunction={(e) => {
                                        setDados({
                                            ...dados,
                                            foto: e.target.files[0]
                                        })
                                        extensaoImage();
                                    }}
                                />


                                <p id='textFile'>Nenhuma foto selecionada...</p>
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