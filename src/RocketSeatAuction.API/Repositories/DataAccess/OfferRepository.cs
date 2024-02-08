using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly RockerSeatAuctionDbContext _dbContext;
        public OfferRepository(RockerSeatAuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }
    }
}
