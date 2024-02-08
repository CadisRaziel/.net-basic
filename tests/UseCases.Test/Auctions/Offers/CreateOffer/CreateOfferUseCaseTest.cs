using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatAuction.API.Communication.Request;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Services;
using RocketSeatAuction.API.UseCases.Auctions.GetCurrent;
using RocketSeatAuction.API.UseCases.Auctions.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Auctions.Offers.CreateOffer
{
    public class GetCurrentActionUseCaseTest
    {
        [Fact] //-> test notation
        public void Success()
        {

            //OBS: JAMAIS FAÇA LOOP EM TESTES !!!!
            
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(i => i.Price, f => f.Random.Decimal(1, 700))              
                .Generate();

            var offerRepository = new Mock<IOfferRepository>();
            //Na minha interface 'IOfferRepository' a minha função é void então eu nao preciso fazer o mock.setup abaixo
            //mock.Setup(i => i.GetCurrent()).Returns(entity);

            var loggerUser = new Mock<ILoggedUser>();
            loggerUser.Setup(i => i.User()).Returns(new User());


            var useCase = new CreateOfferUseCase(loggerUser.Object, offerRepository.Object); ;

            //var id = useCase.Execute(0, request); 
            var act = () => useCase.Execute(0, request); //estou salvando na variavel uma função que retorna um inteiro

            //Não fizemos o assert com o id pois no banco de dados é um id de autoincremento e o mock nao faz isso
            //porém podemos fazer isso var act = () => useCase.Execute(0, request);
            act.Should().NotThrow(); //Se não lançar nenhuma exceção o teste passa (NotThrow só pode ser usada com função por isso tivemos que fazer 'var act = () => useCase.Execute(0, request);')
            //act.Should().Throw<Exception>(); //Se lançar uma exceção o teste passa
        }


        [Theory] //-> faz o teste varias vezes trocando o parametro
        [InlineData(1)] //InlineData -> quantidade de parametros (nao executa na ordem)
        [InlineData(2)]
        [InlineData(3)]
        public void SuccessVariandoItemId(int itemId)
        {

            //OBS: JAMAIS FAÇA LOOP EM TESTES !!!!

            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(i => i.Price, f => f.Random.Decimal(1, 700))
                .Generate();

            var offerRepository = new Mock<IOfferRepository>();        

            var loggerUser = new Mock<ILoggedUser>();
            loggerUser.Setup(i => i.User()).Returns(new User());


            var useCase = new CreateOfferUseCase(loggerUser.Object, offerRepository.Object); ;

            var act = () => useCase.Execute(itemId, request); 
                        
            act.Should().NotThrow(); 
            
        }
    }
}
