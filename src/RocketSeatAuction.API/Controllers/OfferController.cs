using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketSeatAuction.API.Communication.Request;
using RocketSeatAuction.API.Filters;
using RocketSeatAuction.API.UseCases.Auctions.Offers.CreateOffer;
using System;

namespace RocketSeatAuction.API.Controllers
{
    /*
    Posso remover pois criei uma classe especial para tratar o nome dos controlles no swagger 'MeuProjetoAuctionBaseController'
    [Route("api/v1/PostAuction")]
    [ApiController]     
     */

    //2º modo de usar o jwt fake
    //Aqui o jwt fake sera usado para todos os endpoints abaixo
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : MeuProjetoAuctionBaseController
    {
        #region
        [HttpPost]
        [Route("{itemId}")] // -> passando na url o parametro int itemId usado junto com o[FromRoute] no metodo CreateOffer

        //1º modo de usar o jwt fake
        //O problema é que esse ServiceFilter será somente para esse endpoint
        //[ServiceFilter(typeof(AuthenticationUserAttribute))]


        //[FromRoute] -> passando na url o parametro int itemId
        //[FromBody] -> passando no corpo da requisição o objeto RequestCreateOfferJson
        //[FromServices] -> pegando a injeção de dependencias no arquivo "Program.cs"
        public IActionResult CreateOffer(
            [FromRoute] int itemId,
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);
            return Created(string.Empty, id);
        }
        #endregion
    }
}
