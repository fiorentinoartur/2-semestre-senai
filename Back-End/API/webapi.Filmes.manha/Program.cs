using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de Controller
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//Adiciona mapeamento dos COntrollers
var app = builder.Build();

//Aqui começa a configuração do swagger
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
//Aqui finaliza a configuração do swagger
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
