import React from 'react';
import './Footer.css'
const Footer = ({text = "Escola Senai de Informática"}) => {
    return (
 <footer className='footer'>
    <p className='footer-text'>{text}</p>
 </footer>
    );
};

export default Footer;