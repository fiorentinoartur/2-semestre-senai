//rsc
import React, { useState } from 'react';

const Contador = () => {
    const[contador, setContador] = useState(0); // dado do componente
   
   function handleIncrementar() {
    setContador(contador + 1);
   }
   function handleDecrementar()
   {
   (contador > 0) ? setContador(contador - 1) : alert("Não é possível decrementar")
   }
   return (
<div>
    <h1>Contador</h1>

    <p>{contador}</p>
    <button onClick={handleIncrementar}>Incrementar</button>
    <button onClick={handleDecrementar}>Decrementar</button>
  
</div>
    );
};

export default Contador;