import React, { useEffect, useState } from 'react';
import './ModalSenha.css'
import Header from '../Header/Header';
import Container from '../Container/Container';
import { Button, Input, Select } from '../FormComponents/Form';
import api, { atualizarUserResource, timesResource, usuriosResource } from '../../Services/Service'
import { truncateDateFromDb } from '../../Utils/stringFunctions';
import { Navigate } from 'react-router-dom';

const ModalSenha = ({
    emailUser = "",
    showHideModal = false
}) => {
    const [time, setTime] = useState("");
    const [times, setTimes] = useState([]);
    const [senhaAntiga, setSenhaAntiga] = useState()
    const [senhaIdentica, setSenhaIdenticaUser] = useState(false);
    const [newSenha, setNewSenha] = useState()
    const [frmEditData, setFrmEditData] = useState({});

    
    useEffect(() => {
        const loadTimes = async () => {
            try {

                const promiseTimes = await api.get(timesResource)
                const encodedEmail = encodeURIComponent(emailUser);
                const promiseUser = await api.get(`?email=${encodedEmail}`);

                setSenhaAntiga(promiseUser.data.senha)
                setFrmEditData(
                    promiseUser.data
                )

                console.log(frmEditData);

                const arrayTimes = [];
                promiseTimes.data.forEach((time) => {
                    arrayTimes.push({ value: time.id, text: time.nome });
                });

                setTimes(arrayTimes)


            } catch (error) {
                console.log('Erro' + error);
            }
        }
        loadTimes()
    }, [])

    const handleUpdate = async (e) => {
        e.preventDefault()

        const senhaRegex = /^(?=.*\d)[a-z0-9]{8,15}$/
        if (senhaIdentica == false || !senhaRegex.test(frmEditData.senha)) {
            if (senhaIdentica == false) {
                alert("Senhas diferentes");
            } else {
                alert("Senha deve conter entre 8 a 15 caracteres,apenas letras minúsculas e números, e pelo menos 1 número.");
            }
            return;
        }
        try {
            const promise = await api.put(`${atualizarUserResource}/${emailUser}`, {
                senha: frmEditData.senha,
                nascimento: frmEditData.nascimento,
                timeFavoritoId: frmEditData.timeFavoritoId
            });
            alert("Atualizado com sucesso!!!")
            showHideModal();
        } catch (error) {
            console.error(error);
        }
    }
    const confirmSenha = () => {
        validarSenhasIguais(newSenha, frmEditData.senha)
    }
    // const confirmNivelSenha = () => {
    //     verificarSenhaForte(frmEditData.senha)
    // }
    const validarSenhasIguais = (senha, confirmSenha) => {
        const spanConfirmSenha = document.getElementById('confirm-senha');

        if (senha == confirmSenha) {
            spanConfirmSenha.textContent = "Idênticas";
            spanConfirmSenha.style.backgroundColor = 'green';
            setSenhaIdenticaUser(true);
        }
        else {
            spanConfirmSenha.textContent = 'Diferente';
            spanConfirmSenha.style.backgroundColor = 'red';
            setSenhaIdenticaUser(false);
        }
    }

    // const verificarSenhaForte = (senha) => {
    //     const spanSenha = document.getElementById('new-senha');
    //     const repeticoes = {};
    
    //     let todasDiferentes = true;
    
    //     for (const char of senha) {
    //         if (repeticoes[char]) {
    //             repeticoes[char]++;
    //             todasDiferentes = false;
    //         } else {
    //             repeticoes[char] = 1;
    //         }
    //     }
    
    //     if (todasDiferentes) {
    //         spanSenha.textContent = "Forte";
    //         spanSenha.style.backgroundColor = "Green";
    //     } else if (Object.values(repeticoes).some(count => count >= 2)) {
    //         spanSenha.textContent = "Fraca";
    //         spanSenha.style.backgroundColor = "Red";
    //     } else {
    //         spanSenha.textContent = "Média";
    //         spanSenha.style.backgroundColor = "Yellow";
    //     }
    // };
    return (
        <>
            <div className='modal'>
                <form action="" className="recuperar-conta" onSubmit={handleUpdate}>
                    <span className='fechar-modal'
                        onClick={() => showHideModal()}>x</span>

                    <h1 className='title-form'>Recuperação de conta</h1>
                    <hr className='hr-form-senha' />
                    <div className="d-flex-column inputs-form-senha">
                        <div className='d-flex input-senha-item'>
                            <label htmlFor="">Data nascimento: </label>
                            <Input
                                type="date"
                                value={new Date(frmEditData.nascimento).toLocaleDateString('sv-SE')}
                                manipulationFunction={(e) => {
                                    setFrmEditData({
                                        ...frmEditData,
                                        nascimento: e.target.value
                                    })
                                }}

                            />
                            <span></span>
                        </div>
                        <div className='d-flex input-senha-item'>
                            <label htmlFor="">Time Favorito: </label>
                            <Select

                             
                                options={times}
                                manipulationFunction={(e) => {
                                    setFrmEditData({
                                        ...frmEditData,
                                        timeFavoritoId: e.target.value
                                    })
                                }}
                                defaultValue={frmEditData.timeFavoritoId}
                            />
                            <span></span>
                        </div>
                        <div className='d-flex input-senha-item'>
                            <label htmlFor="">Nova Senha: </label>
                            <Input
                                required={true}
                                type="password"
                                value={newSenha}
                                manipulationFunction={(e) => {
                                    setNewSenha(e.target.value)
                                }}
                                // onBlur={confirmNivelSenha}
                            />
                            <span id='new-senha'></span>
                        </div>
                        <div className='d-flex input-senha-item'>
                            <label htmlFor="">Confirma Senha: </label>
                            <Input
                                required={true}

                                manipulationFunction={(e) => {
                                    setFrmEditData({
                                        ...frmEditData,
                                        senha: e.target.value
                                    })
                                }}
                                type="password"
                                onBlur={() => {
                                    confirmSenha()
                                }}
                            />
                            <span id='confirm-senha'></span>
                        </div>
                    </div>
                    <Button
                        textButton="Concluir"
                        type="submit"
                        additionalClass="btn-trocarSenha"
                    />

                </form>
            </div>
        </>


    );
};

export default ModalSenha;