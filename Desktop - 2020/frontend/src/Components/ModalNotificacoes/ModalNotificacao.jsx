import React, { useEffect, useState } from 'react';
import './ModalNotificacao.css'
import { Button, Input, Select } from '../FormComponents/Form';
import api, { notificacoesResource, timesResource } from '../../Services/Service'
const ModalNotificacao = ({ showHideModal = false }) => {

    const [dados, setDados] = useState({
        titulo: "",
        descricao: "",
        selecaoId: "",
        dataHoraCadastro: "",
        dataHoraEnvio: "",
        importancia: "",

    })
    const [times, setTimes] = useState([]);
    useEffect(() => {
        const loadTimes = async () => {
            const promiseTimes = await api.get(timesResource)

            const arrayAux = []

            promiseTimes.data.forEach((time) => {
                arrayAux.push({
                    value: time.id,
                    text: time.nome
                })
            });

            setTimes(arrayAux)
        }
        loadTimes();
    }, [])

    const handleUpdate = async (e) => {
        e.preventDefault();
        try {
            const promise = await api.post(notificacoesResource, {
                titulo: dados.titulo,
                descricao: dados.descricao,
                selecaoId: dados.selecaoId,
                importancia: dados.importancia,
                dataNotificacao: dados.dataHoraCadastro,
                horaNotificacao: dados.dataHoraEnvio
            })
            alert("deu certo")
            showHideModal();

            await api.get(notificacoesResource);
        } catch (error) {
            alert("deu ruim")
            console.log(error.message);
        }
    }

    return (
        <>
            <div className="modal">

                <form action="" className='atualizar-notificacao d-flex-column'>
                    <span
                        className='span-notificacao'
                        onClick={() => {
                            showHideModal()
                        }}

                    >x</span>
                    <h1>Adicionar notificação</h1>
                    <div className="d-flex-column container-inputs">

                        <div className='d-flex'>
                            <label htmlFor="">Título</label>
                            <Input
                                placeholder="Digite um título"
                                required={true}
                                value={dados.titulo}
                                manipulationFunction={(e) => {
                                    setDados({
                                        ...dados,
                                        titulo: e.target.value
                                    })
                                }}
                            />

                        </div>
                        <div className='d-flex'>

                            <label htmlFor="">Descrição</label>
                            <textarea
                                placeholder='Digite a descrição: '
                                required={true}
                                value={dados.descricao}
                                onChange={(e) => {
                                    setDados({
                                        ...dados,
                                        descricao: e.target.value
                                    })
                                }}

                            />
                        </div>
                        <div className='d-flex'>
                            <label htmlFor="">Time da Notificação</label>
                            <Select
                                options={times}
                                defaultValue={dados.selecaoId}
                                manipulationFunction={(e) => {
                                    setDados({
                                        ...dados,
                                        selecaoId: e.target.value
                                    })
                                }}
                            />

                        </div>
                        <div className='d-flex'>
                            <label htmlFor="">Grau da importância</label>
                            <select
                                required={true}
                                onChange={(e) => {
                                    setDados({
                                        ...dados,
                                        importancia: e.target.value
                                    })
                                }}
                                value={dados.importancia}
                            >
                                <option value="" disabled>Selecione</option>
                                <option value="padrão">Padrão</option>
                                <option value="urgente">Urgente</option>
                            </select>

                        </div>
                        <div className='d-flex'>
                            <label htmlFor="">Data notificacao</label>
                            <Input
                                type="date"
                                value={dados.dataHoraCadastro}
                                manipulationFunction={(e) => {
                                    setDados({
                                        ...dados,
                                        dataHoraCadastro: e.target.value
                                    })
                                }}
                            />

                        </div>
                        <div className='d-flex'>

                            <label htmlFor="">Hora Notificação</label>
                            <Input
                                type="time"
                                value={dados.dataHoraEnvio}
                                manipulationFunction={(e) => {
                                    setDados({
                                        ...dados,
                                        dataHoraEnvio: e.target.value
                                    })
                                }}
                            />

                        </div>
                    </div>

                    <Button
                        textButton="Salvar"
                        additionalClass="btn-salvar-notification"
                        manipulationFunction={handleUpdate}
                    />

                </form>
            </div>
        </>
    );
};

export default ModalNotificacao;