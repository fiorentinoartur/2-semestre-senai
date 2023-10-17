const numeros = [10,12,20];
 const somatorio = numeros.reduce((total,n) => {
    return total + n
 },0)

 console.log(somatorio)