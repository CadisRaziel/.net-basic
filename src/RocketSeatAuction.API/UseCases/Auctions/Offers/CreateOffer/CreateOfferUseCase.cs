using RocketSeatAuction.API.Communication.Request;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Repositories;
using RocketSeatAuction.API.Services;

namespace RocketSeatAuction.API.UseCases.Auctions.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        //readonly -> somente o construtor dessa classe pode alterar o valor dela
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;
        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {
           
            var user = _loggedUser.User(); //Me devolve um usuario

            var offer = new Offer
            {
                //id -> o banco que vai criar
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };
            
            _offerRepository.Add(offer);

            return offer.Id;
        }
    }
}

