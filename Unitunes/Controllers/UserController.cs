using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unitunes.Models;
using Unitunes.Repositories;
using Unitunes.Services;

namespace Unitunes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            // Recupera o usuário
            var user = UserRepository.Get(model.Firstname, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
