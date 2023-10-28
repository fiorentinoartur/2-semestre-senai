let frutas = []
function cadastrarFruta(e) {
    e.preventDefault();
    
    let fruta = document.getElementById('fruit').value

    let frutaJaCadastrada = false;

    for (let i = 0; i < frutas.length; i++) {
        if (frutas[i] == fruta) {
            frutaJaCadastrada = true;
            break;
        }
    }
    if (frutaJaCadastrada) {
        alert("Fruta já cadastrada, Tente cadastrar outra fruta!!!")
    }
    else {
        frutas.push(fruta)
    }

    let template = "";

    frutas.forEach(element => {
      template += 
      `<li>${element}</li>`  
    });
    document.getElementById('listaFruta').innerHTML = template
}