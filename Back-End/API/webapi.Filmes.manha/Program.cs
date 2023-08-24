using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de Controller
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//Adiciona mapeamento dos COntrollers
var app = builder.Build();

//Aqui come�a a configura��o do swagger
if (app.Environment.IsDevelopment())
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
