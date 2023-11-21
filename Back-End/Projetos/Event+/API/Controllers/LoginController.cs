using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;
using webapi.event_.ViewModels;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuario _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);
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
                    new Claim(ClaimTypes.Role,usuarioBuscado.TipoUsuario.Titulo),

                    //Existe a possibilidade de criar um claim personalizada
                    //new Claim("Claim personalizada","Valor da Claim personalizada")
                };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-chave-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar o token
                var token = new JwtSecurityToken
                (
                 //emissor do token 
                 issuer: "webapi.event+",

                 //destinatário do token
                 audience: "webapi.event+",

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
