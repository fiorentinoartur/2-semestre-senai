let nome = ["Guilhermezzete","Artur","Lucas","Henrique","Carlos"]
let sobrenome = ["Amorim","Fiorentino","Lacerda","Bayer","Roque"]

const nomeCompleto = nome.map((nome,indice) => {
    return `${nome} ${sobrenome[indice]}`
})

nomeCompleto.forEach((nc) => {
    console.log(nc)
})

// let nomeCompleto = [];

// for (let i = 0; i < nome.length; i++) {
   
//     nomeCompleto[i] = `${nome[i]} ${sobrenome[i]}`
// }

// nomeCompleto.map((nomeCompleto) => {
// console.log(nomeCompleto)
// })