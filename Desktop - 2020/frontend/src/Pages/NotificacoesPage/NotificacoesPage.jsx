import React, { useEffect, useState } from 'react';
import './NotificacoesPage.css';
import Main from '../../Components/Main/Main';
import Container from '../../Components/Container/Container';
import { Button } from '../../Components/FormComponents/Form';
import api, { notificacoesResource } from '../../Services/Service';
import ModalNotificacao from '../../Components/ModalNotificacoes/ModalNotificacao';

const NotificacoesPage = () => {
  const [notificacao, setNotificacao] = useState([]);
  const [countNotificatio, setCountNotificacao] = useState();
  const [showHideModal, setShowHideModal] = useState(false);

  useEffect(() => {
    const loadNotificacao = async () => {
      const promiseNotificacao = await api.get(notificacoesResource);

      setNotificacao(promiseNotificacao.data);
      setCountNotificacao(promiseNotificacao.data.length);
    };

    loadNotificacao();
  }, []);

  const Cadastrar = () => {
    setShowHideModal(!showHideModal);
  };

  const podeAlterarOuExcluir = (dataNotificacao, horaNotificacao) => {
    const dataAtual = new Date();
    const dataAtuall = dataAtual.toLocaleDateString('pt-BR');
    const horaAtual = dataAtual.toLocaleTimeString('pt-BR');

    return (dataNotificacao > dataAtuall) || (dataNotificacao === dataAtuall && horaNotificacao > horaAtual);
  };

  const trocarCor = (dataNotificacao, horaNotificacao, importancia) => {
    const dataAtual = new Date();
    const dataAtuall = dataAtual.toLocaleDateString('pt-BR');
    const dateNotificacao = dataNotificacao;
    const horaAtual = dataAtual.toLocaleTimeString('pt-BR');
    const horaNotificacaoo = horaNotificacao;

    if ((dateNotificacao < dataAtuall) || (dateNotificacao === dataAtuall && horaNotificacaoo < horaAtual)) {
      return '#F18805';
    } else if (dateNotificacao > dataAtuall) {
      return '#04A65B';
    } else if (dateNotificacao === dataAtuall && horaAtual < horaNotificacaoo && importancia === 'urgente') {
      return '#D91136';
    }

    return '#048ABF';
  };

  const handleDelete = async (idNotificacao, dataNotificacao, horaNotificacao) => {
    if (!podeAlterarOuExcluir(dataNotificacao, horaNotificacao)) {
      alert('Você não pode excluir uma notificação já enviada.');
      return;
    }

    const confirmDelete = window.confirm('Tem certeza que deseja excluir esta notificação?');

    if (confirmDelete) {
      try {
        await api.delete(`${notificacoesResource}?id=${idNotificacao}`);
        alert('Deu certo');
      } catch (e) {
        console.log(e.message);
      }
    } else {
      alert('Exclusão cancelada');
    }
  };

  return (
    <>
      <Main>
        <Container>
          <div>
            <div className="container-title d-flex-column">
              <h1>Página de Notificações</h1>
              <hr />
            </div>
            <table className='table-notificacoes'>
              <tbody>
                {notificacao.map((e) => (
                  <tr
                    key={e.id}
                    id={`tr-notificacao-${e.id}`}
                    style={{ backgroundColor: trocarCor(new Date(e.dataHoraCadastro).toLocaleDateString('pt-Br'), new Date(e.dataHoraEnvio).toLocaleTimeString('pt-BR'), e.importancia) }}
                  >
                    <td className="d-flex">
                      <div className="information-notify d-flex-column">
                        <h3>{e.titulo}</h3>
                        <p>{e.descricao}</p>
                        {podeAlterarOuExcluir(new Date(e.dataHoraCadastro).toLocaleDateString('pt-Br'), new Date(e.dataHoraEnvio).toLocaleTimeString('pt-BR')) && (
                          <div className="d-flex actions-notify" id="actions-notify">
                            <p
                              onClick={() => {
                                handleDelete(e.id, new Date(e.dataHoraCadastro).toLocaleDateString('pt-Br'), new Date(e.dataHoraEnvio).toLocaleTimeString('pt-BR'));
                              }}
                            >
                              Excluir
                            </p>
                            <p>Alterar</p>
                          </div>
                        )}
                      </div>
                      <div className="d-flex horario-notify">
                        <p>{new Date(e.dataHoraCadastro).toLocaleDateString('pt-BR')}</p>
                        <p>{new Date(e.dataHoraEnvio).toLocaleTimeString('pt-BR')}</p>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
            <div className="d-flex cadastrar-notificacao-flex">
              <Button textButton="Cadastrar" additionalClass="btn-cadastrar-notificacao" manipulationFunction={Cadastrar} />
              <p>
                <span>{countNotificatio}</span> Notificações
              </p>
            </div>
          </div>
        </Container>
      </Main>
      {showHideModal ? <ModalNotificacao showHideModal={Cadastrar} /> : null}
    </>
  );
};

export default NotificacoesPage;
