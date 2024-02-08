using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RocketSeatAuction.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MeuProjetoAuctionBaseController : ControllerBase
    {
        //Classe criada para passar o nome do controller para o swagger
        //porque criar essa classe? se um dia eu precisar trocar a url, esta tudo em um só local
        //eu venho e só troco aqui [Route("api/[controller]")]
    }
}
