const  camisaLacoste = {
    descricao: "Camisa Lacoste",
    preco: "589.97",
    tamanho: "M",
    cor: "Amarela",
    presente: true
}

const {descricao, preco} = camisaLacoste

console.log("PRODUTO")
console.log();

console.log(`
PRODUTO:
    Descrição: ${descricao}
    Preço: ${preco}
    Presente: ${presente ? "Sim" : "Não" }
`)
