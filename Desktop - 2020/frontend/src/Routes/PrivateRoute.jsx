import { Navigate } from "react-router-dom";

export const PrivateRoute = ({children, redirectTo = "/"}) => {
    const isAuthenticated = localStorage.getItem("token") !== null
    const token = localStorage.getItem("token")    
    console.log(token);
    return isAuthenticated ? children:<Navigate to={redirectTo}/>
}