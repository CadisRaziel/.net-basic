using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Contracts
{
    public interface IAuctionRepository
    {
        public Auction? GetCurrent();
    }
}
