//Essa é a classe principal do projeto, onde é feita a configuração do servidor web e a injeção de dependências.
//É a primeira classe a ser executada quando rodamos o projeto

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Filters;
using RocketSeatAuction.API.Repositories;
using RocketSeatAuction.API.Repositories.DataAccess;
using RocketSeatAuction.API.Services;
using RocketSeatAuction.API.UseCases.Auctions.GetCurrent;
using RocketSeatAuction.API.UseCases.Auctions.Offers.CreateOffer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Inserindo o token no swagger
//normalmente ele vem assim quando cria o projeto builder.Services.AddSwaggerGen();
//abaixo estamos configurando para que o swagger aceite o token
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Essa descrição esta no arquivo Program.cs.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
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
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

//configuração do jwt fake(ANTES DO var app = buider.build())
builder.Services.AddScoped<AuthenticationUserAttribute>();

//Aqui é um serviço de injeção de dependencia do .net (assim eu nao preciso fazer diretamente na classe, eu falo pro .net se virar)
//Porém eu só fiz aqui por conta do HttpContext que eu nao posso passar por parametro nas classes
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentActionUseCase>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>(); //Quando alguem fazer a herança do 'IAuctionRepository' voce vai fazer o new 'AuctionRepository' ou seja criar uma instancia e injetar a dependencia
builder.Services.AddScoped<IOfferRepository, OfferRepository>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddScoped<ILoggedUser, LoggedUser>(); 

//configuração da injeção de dependencia do banco de dados(caso um dia eu quiser mudar  eu só mudo em um lugar)
builder.Services.AddDbContext<RockerSeatAuctionDbContext>(options =>
{
    options.UseSqlite("Data Source=C:\\Users\\Lenovo\\Downloads\\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
