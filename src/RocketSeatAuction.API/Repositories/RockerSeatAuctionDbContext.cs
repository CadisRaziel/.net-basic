using Microsoft.EntityFrameworkCore;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories
{
    public class RockerSeatAuctionDbContext : DbContext
    {
        //DbContextOptions -> é basicamente o parametro 'options' que eu defini nesse codigo builder.Services.AddDbContext<RockerSeatAuctionDbContext> no programs.cs
        //: base(options) -> estou passando as informações do options para o construtor da classe 'DbContext'
        public RockerSeatAuctionDbContext(DbContextOptions options) : base(options)
        {
            
        }

        //Auctions -> mesmo nome da tabela no sqlite
        //Guarda a referencia da tabela

        //Aqui colocaremos as tabelas que nao tem relacionamentos umas com as outras
        //quando tem relacionamento eu só preciso usar uma tabela
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }      
    }
}

//Posso utilizar com \\ ou @
//optionsBuilder.UseSqlite(@"Data Source=C:\Users\Lenovo\Downloads\leilaoDbNLW.db");

/*
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          //conecta com o banco de dados no meu pc
          optionsBuilder.UseSqlite("Data Source=C:\\Users\\Lenovo\\Downloads\\leilaoDbNLW.db");           
      }
       */