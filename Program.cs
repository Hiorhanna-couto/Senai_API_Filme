
using System.Reflection.Metadata;
using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filme_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adicionar o repositorio e a interface ao containes de injcao de dependencia
builder.Services.AddScoped<IGeneroRepository,GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Adicionar o serviço de controllers
builder.Services.AddControllers();

//Adicionar o serviço de jwt bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = " JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";

})
.AddJwtBearer("JwtBearer", Options =>
{
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filme-chaver-autenticacao-webapi-dev")),

        //valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //valida de onde está vindo
        ValidIssuer = "api_filmes_senai",

        ValidAudience = "api_filmes_senai"

    };

 }); 

var app = builder.Build();   

//Adicionar o mapeamento dos controllers
app.MapControllers();

app.UseAuthentication();
//Adicionar a auto
app.UseAuthorization();

app.Run(); 