const urlViaCep = "https://viacep.com.br/ws"

function cadastrar(e) {
    e.preventDefault();
    alert("Cadastrar...")
}

async function buscarEndereco(cep) {
    //complemento do endereço da api
    const resource = `/${cep}/json/`

    try {
        const promise = await fetch(urlViaCep + resource);
        const endereco = await promise.json();

        //preencher o formulário
        preencherCampos(endereco)

    } catch (error) {
        console.log(error)

        document.getElementById("not-found").innerHTML = "CEP inválido"
    }
}

function preencherCampos(object) {
    document.getElementById("endereco").value = object.logradouro
    document.getElementById("cidade").value = object.localidade
    document.getElementById("estado").value = object.uf
}