
import './Header.css'
import Logo from '../../Assests/Icones/logo.svg'
import Container from '../Container/Container';
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario';
import Nav from '../Nav/Nav';
const Header = () => {

    return (
        <header className='header-futnews'>
            <Container additionalClass="header-flex d-flex">
                <img className='logo' src={Logo} alt="" />
                <Nav />

{localStorage.getItem("token") !== null ? (
    <PerfilUsuario />
) : ""}

            </Container>
        </header>
    );
};

export default Header;