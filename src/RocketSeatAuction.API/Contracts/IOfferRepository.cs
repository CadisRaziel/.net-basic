using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Contracts
{
    public interface IOfferRepository
    {
        public void Add(Offer offer);
    }
}
