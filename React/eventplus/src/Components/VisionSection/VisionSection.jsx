import React from 'react';
import "./VisionSection.css";
import Title from "../Titulo/Titulo"
const VisionSection = () => {
    return (
        <section className='vision'>
        <div className='vision__box'>
            <Title 
            titleText={"Visão"}
            color="white"
            potatoClass="vision__title"
            />

          
            <p className='vision__text'>lorem</p>
        </div>
        </section>
    );
};

export default VisionSection;