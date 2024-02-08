using Microsoft.AspNetCore.Mvc;
using RocketSeatAuction.API.Entities;
using RocketSeatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketSeatAuction.API.Controllers
{
    /*
       Posso remover pois criei uma classe especial para tratar o nome dos controlles no swagger 'MeuProjetoAuctionBaseController'
       [Route("api/v1/getAuction")]
       [ApiController]     
    */
    public class AuctionController : MeuProjetoAuctionBaseController
    {
        #region
        /*
           [HttpGet]
          [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)] //o swagger vai devolve a entidade 'auction' no status 200 (como exemplo)
          [ProducesResponseType(StatusCodes.Status204NoContent)] //vai dar um exemplo de como mostrar o 204
          public IActionResult GetCurrentAction()
          {
              //Estanciando o useCase
              var useCase = new GetCurrentActionUseCase();
              var result = useCase.Execute();

              if(result == null)
              {
                  return NoContent(); //204 - realizou a operação com sucesso, nao deu nenhum erro, mas não tem nada para retornar
              }

              return Ok(result);
          }
         */
        #endregion


        #region
        [HttpGet("test")]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)] //o swagger vai devolve a entidade 'auction' no status 200 (como exemplo)
        [ProducesResponseType(StatusCodes.Status204NoContent)] //vai dar um exemplo de como mostrar o 204
        public IActionResult GetCurrentActionNullTest([FromServices] GetCurrentActionUseCase useCase)
        {
            
            var result = useCase.ExecuteTesteNUll();

            if(result == null)
            {
                return NoContent(); //204 - realizou a operação com sucesso, nao deu nenhum erro, mas não tem nada para retornar
            }

            return Ok(result);
        }
        #endregion       
    }
}

/*
       //Se eu precisar de mais um get no mesmo endpoint "[Route("api/v1/getAuction")]" eu posso fazer assim:
       [HttpGet("test")]
       public IActionResult GetCurrentActionTest()
       {
           return Ok("Current Auction TESTE");
       }         
*/