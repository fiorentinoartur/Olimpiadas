import { jwtDecode } from "jwt-decode";

import { createContext, useContext } from "react";

export const UseContext = createContext();

export const userDecodeToken = (theToken) => {
    const decoded = jwtDecode(theToken)

    return {userId: decoded.jti, role: decoded.role, nome: decoded.name, token: theToken}
}


