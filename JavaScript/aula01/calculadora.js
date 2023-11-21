function Operacao(numberA, numberB, operacao) {
    event.preventDefault(); //Capturarar o evento do formulário

    let n1 = Number(document.getElementById('n1').value)
    let n2 = Number(document.getElementById('n2').value)
    let op = document.getElementById('operacao').value

    switch (operacao) {
        case '+':
            return ` O resultado da soma = ${numberA + numberB}`

        case '-':
            return ` O resultado da subtração = ${numberA - numberB}`

        case '*':
            return ` O resultado da multiplicação = ${numberA * numberB}`

        case '/':
            if (numberB == 0) {
                return "Não existe divisão por zero"
            }
            return ` O resultadado da divisão = ${numberA / numberB}`


        default:

            break;
    }
    let resultado = Operacao(n1, n2, op)
    document.getElementById('result').innerText = resultado
    alert(` ${resultado}`)
}
