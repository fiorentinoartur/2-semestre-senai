using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de Controller
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informa��es sobre  API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API InLock_Games",
        Description = "API para gerenciamento de Jogos ",
        Contact = new OpenApiContact
        {
            Name = "Senai de Inform�tica - Turma Manh�",
            Url = new Uri("https://github.com/fiorentinoartur")
        },
    });

    // Configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";


});

//Adiciona mapeamento dos Controllers
var app = builder.Build();

//Aqui come�a a configura��o do swagger
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Aqui finaliza a configura��o do swagger
app.MapControllers();


app.UseHttpsRedirection();

app.Run();
