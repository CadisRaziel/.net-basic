using Microsoft.EntityFrameworkCore;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Repositories;

namespace RocketSeatAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentActionUseCase
    {      
        private readonly IAuctionRepository _auctionRepository; //No program.cs eu fiz a injeção de dependencia, quando o 'IAuctionRepository' for chamado ele fazer uma instancia da classe 'AuctionRepository'

        public GetCurrentActionUseCase(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        public Auction? ExecuteTesteNUll()
        {            
          return _auctionRepository.GetCurrent();
        }
    }
}

/*
  return new AuctionEntitie
            {
                Id = 1,
                Name = "Leilão de um carro",
                Starts = DateTime.Now,
                Ends = DateTime.Now
            };  
 */

/*
        public Auction Execute()
      {
          var repository = new RockerSeatAuctionDbContext();
          return repository
              .Auctions
              .Include(x => x.Items) //Incluindo os items no get (lembrando que o includes nao da auto complete e parece que ta errado)
              .First(); //estou dizendo que sempre vai existir um dado         
      }

       */