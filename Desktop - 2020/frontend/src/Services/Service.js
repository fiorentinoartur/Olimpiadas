import axios from "axios";

//Rota para o Login
export const loginResource = '/Login';

//Rota para Times
export const timesResource = '/Times';

//Rota para Usuários
export const usuriosResource = '/Usuarios'

//Rota para atualizar Usuarios
export const atualizarUserResource = '/AtualizarUsuario'

//Rota para cadastro Usuarios
export const cadastrarUserResource = '/FirstCadastro'

//Rota para notificacoes
export const notificacoesResource = '/Notificacoes'

//Rota para jogos
export const jogosResource = '/Jogos'

//Rota para rodadas
export const rodadasResource = '/Rodada'

const apiPort = '7099';
const localApiUri = `https://localhost:${apiPort}/api`


const api = axios.create({
    baseURL:localApiUri
})

export default api;