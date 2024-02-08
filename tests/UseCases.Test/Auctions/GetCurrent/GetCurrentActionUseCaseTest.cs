using Bogus;
using FluentAssertions;
using Moq;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.Enums;
using RocketSeatAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentActionUseCaseTest
    {
        [Fact] //-> test notation
        public void Success()
        {
            //AAA -> metodo de tests

            //Passando informações para classe Auctions para nao ficar tudo vazio
            //Aqui vamos usar um package nugget que se chama 'bogus' para gerar dados fake
            var entity = new Faker<Auction>()
                .RuleFor(i => i.Id, f => f.Random.Number(1, 10))
                .RuleFor(i => i.Name, f => f.Lorem.Word())
                .RuleFor(i => i.Starts, f => f.Date.Past())
                .RuleFor(i => i.Ends, f => f.Date.Future())
                .RuleFor(i => i.Items, (f, i) => new List<Item> //(f, i) -> f = faker, i = instancia da classe auction, para eu poder passa o id da auction no AuctionId ali em baixo no Item
                {
                    new Item
                    {
                        Id = f.Random.Number(1, 10),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        Condition = f.PickRandom<Condition>(),
                        BasePrice = f.Random.Decimal(50,1000),
                        AuctionId = i.Id
                    }
                })
                .Generate();

            //Aqui estamos utilizando o package nugget 'Moq'
            //Repare tambem que só conseguimos tipar com INTERFACE e não classes (por isso é importante ter interfaces)
            //Precisamos realizar esse mock pois não conseguimos instanciar a classe 'Auctionrepository' diretamente aqui
            var mock = new Mock<IAuctionRepository>();
            //mock.Setup(i => i.GetCurrent()).Returns(new Auction()); //Configurando o mock para ele retornar o valor correto da Getcurrent
            mock.Setup(i => i.GetCurrent()).Returns(entity); //Para simular com valores fake

            //Arrange -> inicializa tudo que precisamos para o teste
            var useCase = new GetCurrentActionUseCase(mock.Object );


            //Act -> ação (executar o metodo que queremos testar)
            var auction = useCase.ExecuteTesteNUll();


            //Assert -> testar se não é nulo(Usamos um package nugget que chama FluentAssertions)
            //esses dois cara são iguais o assert e o should, porém o should(package) da muito mais possibilidades
            //Assert.NotNull(auction); 
            auction.Should().NotBeNull();
            auction.Id.Should().Be(entity.Id); //deveria ser do valor do id do id que criou
            auction.Name.Should().Be(entity.Name); //deveria ser do valor do name do name que criou
        }
    }
}
