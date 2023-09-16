using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using webapi.inlock.codeFirst.Domains;
using webapi.inlock.codeFirst.Interfaces;
using webapi.inlock.codeFirst.Repositories;
using webapi.inlock.codeFirst.ViewModels;
using System.Security.Claims;

namespace webapi.inlock.codeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);
                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha inválido!");
                }

                //Caso encontre o usuário, prossegue para criação do token

                //1º - definir as informações(Claims) que serão fornecidas no toen(PAYLOAD)
                var claims = new[]
                {
                    //formado da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscado.TiposUsuario.Titulo),

                    //Existe a possibilidade de criar um claim personalizada
                    new Claim("Claim personalizada","Valor da Claim personalizada")
                };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogos-chave-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar o token
                var token = new JwtSecurityToken
                (
                 //emissor do token 
                 issuer: "senai.inlock.webApi",

                 //destinatário do token
                 audience: "senai.inlock.webApi",

                 //Dados definidos nas claims(informações)
                 claims: claims,

                 //tempo de expiração do token 
                 expires: DateTime.Now.AddMinutes(5),

                 //credenciais do tolen
                 signingCredentials: creds
                );

                //5º retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
