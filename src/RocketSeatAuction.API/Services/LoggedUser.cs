using Microsoft.AspNetCore.Identity;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Entities;

namespace RocketSeatAuction.API.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;
        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            //inversão de dependencia(injeção)
            _httpContext = httpContext;
            _userRepository = userRepository;
        }
        public User User()
        {            

            var token = TokenOnRequest();
            var email = FromBase64String(token);

            return _userRepository.GetUserByEmail(email);
        }

        private string TokenOnRequest()
        {
            var authentication = _httpContext.HttpContext!.Request.Headers.Authorization.ToString();

            //O meu token vem assim: "Bearer "dGF0aWFuYUB0YXRpYW5hLmNvbQ=="
            //Para remover o Bearer e receber apenas o token eu faço o seguinte: return authentication["Bearer ".Length..];
            //["Bearer ".Length..] -> Length pego o tamanho da palavra Bearer e seu espaço até as " ou seja "Bearer " que da 7 caracteres
            //["Bearer ".Length..] -> .. retorna uma string aonde começa na posição 7 até o final da string
            //Uma forma de da um 'split' na palavra "Bearer "
            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64)
        {
            //Convertendo para base64 para o email
            var data = Convert.FromBase64String(base64);

            //Convertendo para string
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
