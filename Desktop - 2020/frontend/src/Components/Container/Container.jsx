import React from 'react';
import "./Container.css";
const Container = ({children, additionalClass}) => {
    return (
        <div className={`container ${additionalClass}`}>
          {children}  
        </div>
    );
};

export default Container;