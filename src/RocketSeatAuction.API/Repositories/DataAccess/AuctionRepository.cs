using Microsoft.EntityFrameworkCore;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository 
    {
        private readonly RockerSeatAuctionDbContext _dbContext;
        public AuctionRepository(RockerSeatAuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Auction? GetCurrent()
        {
            var today = DateTime.Now;

            return _dbContext
                .Auctions
                .Include(x => x.Items) //Incluindo os items no get (lembrando que o includes nao da auto complete e parece que ta errado)
                .FirstOrDefault(x => today >= x.Starts && today <= x.Ends); //Se voce encontra faça, se voce nao encontrar retorne nullo   (maior ou igual a data que o leilao começa ou menor igual a data que o leilao termina)       
        }
    }
}
