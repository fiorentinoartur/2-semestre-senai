var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de Controller
builder.Services.AddControllers();

//Adiciona mapeamento dos COntrollers
var app = builder.Build();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
