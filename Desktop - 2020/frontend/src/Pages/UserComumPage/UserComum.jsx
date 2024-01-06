
import React, { useEffect, useState } from 'react';
import './UserComum.css'
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import ArrowRight from '../../Assests/Icones/arrow-right.svg'
import ArrowLeft from '../../Assests/Icones/arrow-left.svg'
import Adicionar from '../../Assests/Icones/adicionarRodada.svg'
import Editar from '../../Assests/Icones/editPen.svg'
import api, { jogadoresResource, jogosResource, rodadasResource } from '../../Services/Service'
import CommentaryIcon from '../../Assests/Icones/comentary-icon.svg'

const UserComum = () => {
    const [jogos, setJogos] = useState([]);
    const [rodadaAtual, setRodadaAtual] = useState()
    const [idJogo, setIdJogo] = useState()
   const [nomeSelecao, setNomeSelecao] = useState();
    const [modal, setModal] = useState(true);
    const [rodada, setRodada] = useState([]);
    const [jogadores, setJogadores] = useState([]);

    useEffect(() => {
        const loadJogos = async () => {
            const promiseRodadas = await api.get(rodadasResource);
            setRodada(promiseRodadas.data.map(rodada => rodada.id));
            setRodadaAtual(promiseRodadas.data.length - 1);
            const promiseJogos = await api.get(`${jogosResource}?rodada=${promiseRodadas.data[promiseRodadas.data.length - 1].id}`);
            setJogos(promiseJogos.data);

            console.log(promiseJogos.data);



        }

        loadJogos();
    }, []);


  
   

    const showHideModalCasa = async (idJogo) => {
        const indiceDoId = jogos.findIndex(x => x.id === idJogo);

        if (indiceDoId !== -1 && jogos[indiceDoId].selecaoCasaId) {
            const idSelecaoCasa = jogos[indiceDoId].selecaoCasaId;

            try {
                console.log(`${jogadoresResource}/${idSelecaoCasa}`);
                const promiseJogadores = await api.get(`${jogadoresResource}/${idSelecaoCasa}`);
                console.log(promiseJogadores.data);
                setJogadores(promiseJogadores.data)
            } catch (error) {
                console.log('Deu erro');
                console.log(error.message);
            }
            setNomeSelecao(jogos[indiceDoId].nomeSelecaoCasa)
        }

        modal ? setModal(false) : setModal(true);
    }




    const showHideModalVisitante = async (idJogo) => {
        const indiceDoId = jogos.findIndex(x => x.id === idJogo)
 
         if (indiceDoId !== - 1 && jogos[indiceDoId].selecaoVisitanteId) {
            const idSelecaoVisitante = jogos[indiceDoId].selecaoVisitanteId
            try {
                const promise = await api.get(`${jogadoresResource}/${idSelecaoVisitante}`)

                setJogadores(promise.data)
            } catch (error) {
                
            }

            setNomeSelecao(jogos[indiceDoId].nomeSelecaoVisitante)
         }
  
        modal ? setModal(false) : setModal(true)
    }

    return (

        <Main>
            <Container>
                {modal ? (
                    <>
                        <div className="container-title d-flex-column margin-text">
                            <h1>Página de Notificações</h1>
                            <hr />
                        </div>
                        <div className="container-table container-table-user">
                            <div className="rodada-section d-flex table-user-classificacao">



                                <h2>Rodada {rodadaAtual + 1}</h2>



                            </div>

                            <table className='table-jogos'>
                                <thead>
                                    <tr className='table-head-row'>
                                        <th className='table-head-title'>Mandante</th>
                                        <th className='table-head-title'>Placar</th>
                                        <th className='table-head-title'></th>
                                        <th className='table-head-title'>Placar</th>
                                        <th className='table-head-title'>Visitante</th>
                                        <th className='table-head-title'>Comentar</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {jogos.map((e) => (

                                        <tr className='table-body-row' key={e.id}>

                                            <td className='table-body-title'
                                                onClick={() => {
                                                    showHideModalCasa(e.id)
                                                }}
                                            >{e.nomeSelecaoCasa}</td>
                                            <td className='table-body-title'>{e.placarCasa}</td>
                                            <td className='table-body-title placarX'>X</td>
                                            <td className='table-body-title'>{e.placarVisitante}</td>
                                            <td
                                                className='table-body-title'
                                                onClick={() => {
                                                    showHideModalVisitante(e.id)
                                                }}
                                            >{e.nomeSelecaoVisitante}</td>

                                            <td className='table-body-title'>
                                                <img src={CommentaryIcon} alt="" defaultValue={""} /></td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </>
                ) :
                    (<>
                        <div className="container-title d-flex-column margin-text">
                            <h1>{nomeSelecao}</h1>
                            <hr />
                        </div>
                        <div className="container-table container-table-user">
                            <div className="rodada-section d-flex table-header-user">
                                <h1 onClick={showHideModalCasa}>
                                    X
                                </h1>
                            </div>

                            <table className='table-jogos table-jogos-user'>
                                <thead>
                                    <tr className='table-head-row'>
                                        <th className='table-head-title'>Num</th>
                                        <th className='table-head-title'>Nome</th>
                                        <th className='table-head-title'>Posicao</th>


                                    </tr>
                                </thead>
                                <tbody>
                                    {jogadores.map((e) => (

                                        <tr className='table-body-row' key={e.id}>

                         
                                            <td className='table-body-title'>{e.numeroCamisa}</td>
                                            <td className='table-body-title'
                                            >{e.nomeJogador}</td>

                                            <td className='table-body-title'>
                                            {e.nomePosicao}
                                            </td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                            <h1 className='pontos-selecao'>Pontos: 737</h1>
                        </div>
                    </>
                    )}

            </Container>
        </Main>
    );
};

export default UserComum;