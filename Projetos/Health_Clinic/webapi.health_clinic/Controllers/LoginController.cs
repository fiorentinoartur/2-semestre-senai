using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.health_clinic.Domains;
using webapi.health_clinic.Interfaces;
using webapi.health_clinic.Repositories;
using webapi.health_clinic.ViewModel;

namespace webapi.health_clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuario _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPut]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email, usuario.Senha);
                if(usuarioBuscado == null) 
                {
                return NotFound("Email ou senha inválido!");
                }
                //Caso encontre o usuário, prossegue para criação do token

                //1º - definir as informações(Claims) que serão fornecidas no toen(PAYLOAD)
                var claims = new[]
                {
                    //formato da claim
                    new Claim
                    (JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim
                    (JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim
                    (ClaimTypes.Role,usuarioBuscado.TipoDeUsuario.Titulo)
                };
                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey
                    (System.Text.Encoding.UTF8.GetBytes("health-chave-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //4º - Gerar o token
                var token = new JwtSecurityToken
                (
                 //emissor do token 
                 issuer: "webapi.health",

                 //destinatário do token
                 audience: "webapi.health",

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
