const filme =
[
    {
        genero: "Comédia",
        titulo: "As White",
        Descricao: "É um filme muito engraçadão"
    }
    ,
    {
        genero: "Comédia",
        Descricao: "É um gênero que faz as pessoas dar risadas"
    }
] 

filme.forEach(({titulo,genero}, i) => {
  

    console.log(titulo,genero)
})

// const {genero,titulo,Descricao} = filme[0]


// console.log(genero,titulo,Descricao)