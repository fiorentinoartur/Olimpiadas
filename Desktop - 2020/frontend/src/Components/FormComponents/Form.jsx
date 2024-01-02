import React from 'react';

export const Input = ({
    type,
    id,
    value,
    required,
    additionalClass,
    name,
    placeholder,
    manipulationFunction,
    onBlur,
    accept,
    checked
}) => {
    return (
        <input
            type={type}
            id={id}
            name={name}
            value={value}
            required={required ? "required" : ""}
            className={`input-component ${additionalClass}`}
            placeholder={placeholder}
            onChange={manipulationFunction}
            autoCapitalize='off'
            onBlur={onBlur}
            accept={accept}
            checked={checked}
        />
    )
}

export const Button = ({
    idButton,
    name,
    type,
    additionalClass,
    manipulationFunction,
    textButton
}) => {
    return (
        <button
            id={idButton}
            name={name}
            type={type}
            className={additionalClass}
            onClick={manipulationFunction}
        >
            {textButton}
        </button>
    )
}


export const Select = ({
    required,
    id,
    name,
    options = [],
    manipulationFunction,
    additionalClass = "",
    defaultValue,

}) => {
    return (
        <select 
            name={name} 
            id={id}
            required={required}
            className= {additionalClass}
            onChange={manipulationFunction}
            value={defaultValue}

        >
            <option value="">Selecione</option>
            {options.map((o) =>{
                return (
                    <option key={Math.random()} value={o.value}>{o.text}</option>
                );
            })}
        </select>
    );
}