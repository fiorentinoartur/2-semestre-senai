const url = "https://viacep.com.br/ws/09182020/json"

//get
fetch(url)
.then((resposta) => {
    //objeto promisse resolvido (headers, body, other)
    return resposta.json();
})
.then((dados) => {
console.log(
    `Endereço:     ${dados.logradouro}
     Cidade:       ${dados.localidade}
     Estado:       ${dados.uf}
    `
    );
})
.catch()









// fetch('https://viacep.com.br/ws/09182020/json/')
// .then((resp) => { //promisse resolvida
//     return resp.json();//retorna os dados
// })
// .then((dados) => {
//     console.log(dados)//os dados do corpo da promisse
// })
// .catch
// ((e) => {
//     console.log(e)
// })