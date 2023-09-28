using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //valida quem está solicitando
            ValidateIssuer = true,

            //Validar quem está recebendo
            ValidateAudience = true,

            //Define se o tempo de expiração será validado
            ValidateLifetime = true,

            //Forma de criptografia e valida a chave de autenticação
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("health-chave-autenticacao-webapi-dev")),

            //Valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //nome do issuer (de onde está vindo)
            ValidIssuer = "webapi.health",

            //nome do audience (para onde está vindo)
            ValidAudience = "webapi.health"
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informações sobre  API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Health_Clinic",
        Description = "API para gerenciamento de Consultas ",
        Contact = new OpenApiContact
        {
            Name = "Senai de Informática - Turma Manhã",
            Url = new Uri("https://github.com/fiorentinoartur")
        },
    });

    // Configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";


    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });



});

var app = builder.Build();

// Configure the HTTP request pipeline.
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


app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();

app.Run();
