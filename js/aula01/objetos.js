let artur = {
    nome : "Artur",
    sobrenome: "Fiorentino",
    idade: 16
};

artur.cpf = '123456'

let carlos = new Object();
carlos.nome = "Carlos";
carlos.sobrenome = "Roque"

console.log(artur)
console.log(carlos)


let nomes  = [artur,carlos]

for (let i = 0; i < nomes.length; i++) {
console.log(nomes[i].nome)
}
