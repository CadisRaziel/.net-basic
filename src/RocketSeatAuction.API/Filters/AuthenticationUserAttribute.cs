using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketSeatAuction.API.Contracts;
using RocketSeatAuction.API.Repositories;

namespace RocketSeatAuction.API.Filters
{
    //Classe para simular o token jwt
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationUserAttribute(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           try
            {
                var token = TokenOnRequest(context.HttpContext);              

                var email = FromBase64String(token);

                //Any -> se existe algum usuario com o email informado
                var exist = _userRepository.ExistUserWithEmail(email);

                if (exist == false)
                {
                    context.Result = new UnauthorizedObjectResult("E-mail não é valido");
                }
            } 
            catch (Exception ex) 
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();


            if(string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token não informado");
            }

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
