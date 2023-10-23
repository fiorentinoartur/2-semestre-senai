
let frutas = [];
function cadastrarFruta(e) {
    e.preventDefault();

    let fruit = document.getElementById('fruit').value
    fruit.trim()


    frutas.push(fruit);
    frutas.sort();
    let template = ""
    frutas.forEach(f => {
        template +=
            `<li>${f}</li>`;
    });

    document.getElementById('listaFruta').innerHTML = template
}
