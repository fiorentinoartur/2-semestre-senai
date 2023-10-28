//Consumir API Via Cep
const urlViaCep = "https://viacep.com.br/ws/"

async function cadastrar(e)
{
    e.preventDefault();
    alert("Cadastrado com Sucesso!!!")
}
async function buscarEndereco(cep)
{
    try {
        const promise = await fetch(`${urlViaCep}/${cep}/json/`);
        const dados = await promise.json();
        console.log(dados);
        preencherForm(dados);
    
    } catch (error) {
        alert("Dados Inválidos")
        console.log(error)
    }
}

function preencherForm(endereco) {

    document.getElementById('rua').value = endereco.logradouro;
    document.getElementById('cidade').value = endereco.localidade;
    document.getElementById('estado').value = endereco.uf;
    document.getElementById('bairro').value = endereco.bairro;

}
