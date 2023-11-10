import React from 'react';
import typeEventImage from '../../assets/icons/tipo-evento.svg '
const ImageIlustrator = ({altText, imageName, additionalClass}) => {
    switch (imageName) {
        case 'tipo-evento':
            imageResource = typeEventImage
            break;
    
        case 'evento':
            imageResource = eventoImage
            break;
    
        default:
            break;
    }
    return (
    <figure className='ilustrador-brox'>
        <img 
        src={imageResource} 
        alt={altText}
        className={`ilustrator-box__image ${additionalClass}`} />
    </figure>
    );
};

export default ImageIlustrator;