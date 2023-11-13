import React from 'react';
import typeEventImage from '../../assets/icons/tipo-evento.svg'
import eventoImage  from '../../assets/icons/evento.svg'
import dafaultImage from '../../assets/images/default-image.jpeg'
const ImageIlustrator = ({altText, imageName, additionalClass, imageRender = dafaultImage}) => {
    // switch (imageName) {
    //     case 'tipo-evento':
    //         imageResource = typeEventImage
    //         break;
    
    //     case 'evento':
    //         imageResource = eventoImage
    //         break;
    
    //     default:
    //         imageResource = dafaultImage
    //         break;
    // }
    return (
    <figure className='ilustrador-brox'>
        <img 
        src={imageRender} 
        alt={altText}
        className={`ilustrator-box__image ${additionalClass}`} />
    </figure>
    );
};

export default ImageIlustrator;