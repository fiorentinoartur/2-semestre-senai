let frutas = ['banana','maça','morango']

console.log(frutas)

console.log(`Quantidade de frutas: ${frutas.length}`)

frutas.push('uva')
frutas.push('mamão')
frutas.push('amora')

console.log(`Quantidade de frutas: ${frutas.length}`)

frutas.sort();

console.log(frutas)
console.log(frutas)

// for (let i = 0; i < frutas.length; i++) {
//  console.log(`Fruta${i + 1} ${frutas[i]}`)
    
// }

frutas.forEach((x, i) => {
console.log(`Fruta ${i} ${x}`);
})


let pratileira = ["Cerveja","Coca-Cola","Água","Gatorade","Corote","Guaraná","Tubaina"];
let bebida = pratileira[6]

switch (bebida) {
    case "Cerveja":
        console.log("Achei sua Cerveja")
        break;
    case "Guaraná":
        console.log("Achei sua Guaraná")
        break;
    case "Tubaina":
        console.log("Achei sua Tubaina")
        break;

    default:
        console.log("Bebida indisponivel")
        break;
}