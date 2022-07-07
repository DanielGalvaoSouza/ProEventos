using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using ProEventos.API.Repositories;
using ProEventos.API.Services;
using System;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [Route("v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autheticate([FromBody] User model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);
            await Task.Delay(0);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated()
        {
            _logger.LogInformation($"Authenticated: {String.Format("Autenticado - {0}", User.Identity.Name)}");

            return String.Format("Autenticado - {0}", User.Identity.Name);
        }

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee()
        {
            _logger.LogInformation($"Liberado acesso para ambos os tipos de acesso.");

            return "Funcionário";
        }

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager()
        {
            _logger.LogInformation($"Liberado o acesso siomente para o administrador.");

            return "Gerente";
        }

    }
}
