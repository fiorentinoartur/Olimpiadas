import { Navigate } from "react-router-dom";

export const PrivateRouteAdministrador = ({ children }) => {
    const isAutorized = localStorage.getItem("token")
    const parseToken = JSON.parse(isAutorized)

    if (isAutorized !== null && parseToken.role == '0') {

        return children
    }
}
export const PrivateRouteComum = ({ children }) => {
    const isAuthorized = localStorage.getItem("token");
console.log('autorizado',isAuthorized);
    if (isAuthorized !== null) {
        console.log('cheguei aqui');
        const parseToken = JSON.parse(isAuthorized);
        const userRole = parseToken.role;

        if (userRole === '1') {
            return children;
        }
    }

    alert("Usuário não autorizado");
    return null;
}
