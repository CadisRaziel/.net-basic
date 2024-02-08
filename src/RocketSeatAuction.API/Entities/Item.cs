using RocketSeatAuction.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketSeatAuction.API.Entities
{
    [Table("Items")] //Dizendo o nome da tabela no DB 
    //Porque fazer isso ? na classe RockerSeatAuctionDbContext eu instancio o DbSet informando o nome da tabela Auctions
    //EU deveria por a tabela Items la tambem, porém o Auctions tem uma chave primaria para Items, entao eu nao preciso
    //quando eu chamar o Auctions eu posso relacionar com o items
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public Condition Condition { get; set; } //Estou passando meu enum para tipar o condition da base de dados(pois la antes estava 0 - 1 - 2, agora eu dei significado aos numeros, 0 = NEW - 1 = GREAT - 2 = GOOD 
        public decimal BasePrice { get; set; } 
        public int AuctionId { get; set; }     
    }
}