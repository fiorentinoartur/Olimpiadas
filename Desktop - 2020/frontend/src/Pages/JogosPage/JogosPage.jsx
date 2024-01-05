import React, { useEffect, useState } from 'react';
import './JogosPage.css'
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import ArrowRight from '../../Assests/Icones/arrow-right.svg'
import ArrowLeft from '../../Assests/Icones/arrow-left.svg'
import Adicionar from '../../Assests/Icones/adicionarRodada.svg'
import Editar from '../../Assests/Icones/editPen.svg'
import api, { jogosResource, rodadasResource } from '../../Services/Service'

const JogosPage = () => {
    const [jogos, setJogos] = useState([]);
    const [rodadaAtual, setRodadaAtual] = useState(0)
    const [rodada, setRodada] = useState([]);
    const [inicioRodada, setInicioRodada] = useState(null)
    const [terminoRodada, setTerminoRodada] = useState(null)
    useEffect(() => {
        const loadJogos = async () => {
            const promiseRodadas = await api.get(rodadasResource);

            setRodada(promiseRodadas.data.map(rodada => rodada.id));
   
            const promiseJogos = await api.get(`${jogosResource}?rodada=${promiseRodadas.data[rodadaAtual].id}`);
            console.log(promiseJogos.data);

            setInicioRodada(promiseJogos.data[0].inicioRodada);
            setTerminoRodada(promiseJogos.data[0].dataTerminoRodada);
            console.log(rodadaAtual);
            setJogos(promiseJogos.data);
            
            
            
        }
        
        loadJogos();
    }, []);
    
    
    const nextPrev = async (direction) => {
        try {
            console.log(rodada[1]);
            let novaRodada;
            if(direction == 'next')
            {
                novaRodada = rodadaAtual + 1;

                
            }
            else if(direction === 'prev')
            {
                novaRodada = rodadaAtual - 1 


            }
            
            if(novaRodada >= 0 && novaRodada < rodada.length)
            {
                setRodadaAtual(novaRodada)

                const novaRodadaId = rodada[novaRodada]

                const promiseJogos = await api.get(`${jogosResource}?rodada=${novaRodadaId}`)

                setInicioRodada(promiseJogos.data[0].inicioRodada);
                setTerminoRodada(promiseJogos.data[0].dataTerminoRodada);
                console.log(promiseJogos.data);
                setJogos(promiseJogos.data)
            }
            else{
                alert("Rodada não Existe")
            }
        } catch (error) {
            
        }
    }
    const handleUpdate = async () => {
        try {
     const promise = api.post(jogosResource);


     alert("Rodada adicionada com sucesso!!!");

        } catch (error) {

        }
    }

    // const atualizarPlacar = async (idJogo) => {
    //     try {
    //         const promise = api.put(`${jogosResource}?jogo=${idJogo}`)
    //     } catch (error) {
            
    //     }
    // }
    return (
        <>

            <Main>
                <Container>

                    <>
                        <div className="container-title d-flex-column">
                            <h1>Tabela de Jogos</h1>
                            <hr />
                        </div>
                        <div className="container-table">
                            <div className="rodada-section d-flex">
                                <img src={ArrowLeft} 
                            
                                onClick={() => {
                                    nextPrev('prev')
                                }}
                                alt="" />
                                <h2>Rodada {rodadaAtual + 1}</h2>
                                <img src={ArrowRight}

                                onClick={() => {
                                    nextPrev("next")
                                }}
                                alt="" />
                            </div>
                            <div className="datas-inicioTermino d-flex">
                                <div className='d-flex datas_items'>
                                    <p>{new Date(inicioRodada).toLocaleDateString("pt-Br")} </p>
                                    <p>/</p>
                                    <p>{new Date(terminoRodada).toLocaleDateString("pt-Br")}</p>
                                </div>
                                <img
                                    src={Adicionar}
                                    onClick={handleUpdate}
                                    alt="" />
                            </div>

                            <table className='table-jogos'>
                                <thead>
                                    <tr className='table-head-row'>
                                        <th className='table-head-title'>Data</th>
                                        <th className='table-head-title'>Hora</th>
                                        <th className='table-head-title'>Mandante</th>
                                        <th className='table-head-title'>Placar</th>
                                        <th className='table-head-title'></th>
                                        <th className='table-head-title'>Placar</th>
                                        <th className='table-head-title'>Visitante</th>
                                        <th className='table-head-title'>Status</th>
                                        <th className='table-head-title'>Editar</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {jogos.map((e) => (

                                        <tr className='table-body-row'>
                                            <td className='table-body-title'>{new Date(e.data).toLocaleDateString('pt-BR')}</td>
                                            <td className='table-body-title'>{new Date('2000-01-01T' + e.horarioJogo).toLocaleTimeString('pt-BR', { hour: 'numeric', minute: 'numeric' })}</td>
                                            <td className='table-body-title'>{e.nomeSelecaoCasa}</td>
                                            <td className='table-body-title'>{e.placarCasa}</td>
                                            <td className='table-body-title placarX'>X</td>
                                            <td className='table-body-title'>{e.placarVisitante}</td>
                                            <td className='table-body-title'>{e.nomeSelecaoVisitante}</td>
                                            <td className='table-body-title'>Andamento</td>
                                            <td className='table-body-title'>
                                                <img src={Editar} alt="" defaultValue={""}/></td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </>

                </Container>
            </Main>
        </>
    );
};

export default JogosPage;