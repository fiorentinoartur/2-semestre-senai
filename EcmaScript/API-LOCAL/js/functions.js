const urlViaCep = "https://viacep.com.br/ws"
const urlCepProfessor = "http://172.16.35.155:3000/myceps"
const urlContatos = "http://172.16.35.155:3000/contatos"

async function cadastrar(e) {
    e.preventDefault();

    //pegar os valores dis campos de formulário
    const nome = document.getElementById('nome').value.trim();
    const email = document.getElementById('email').value.trim();
    const cep = document.getElementById('cep').value;
    const endereco = document.getElementById('endereo').value.trim();
    const numero = document.getElementById('numero').value;
    const cidade = document.getElementById('cidade').value.trim();
    const estado = document.getElementById('estado').value.trim();


    //extra - fazer a validação (dica - crie uma função : bool)
    //validaForm(nome,endereco,cep)

    objCadastro =
    {
        nome,
        email,
        cep,
        endereco,
        numero,
        cidade,
        estado
    }
try {
    const promise = await fetch(urlContatos, {
        body: JSON.stringify(objCadastro),
        method: "post",
        headers: {"Content-type" : "application/json"}
    });
    const dados = await promise.json();
    console.log(dados)
} catch (error) {
    console.log("Deu ruim");
    console.log(error);
}
}

function validaForm(nome, endereco, cep) {
    if (nome.length == 0 || endereco.length == 0 || cep < 8) {
        return false;
    }
    return true
}

async function buscarEndereco(cep) {
    //complemento do endereço da api
    //const resource = `/${cep}/json/`

    try {
        //      const promise = await fetch(urlViaCep + resource);

        const promise = await fetch(`${urlCepProfessor}/${cep}`)
        const endereco = await promise.json();

        console.log(endereco)

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