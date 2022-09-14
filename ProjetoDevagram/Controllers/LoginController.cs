using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoDevagram.Dto;
using ProjetoDevagram.Model;
using ProjetoDevagram.Services;

namespace ProjetoDevagram.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]

        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto loginRequisicao)
        {
            try
            {
                if (!string.IsNullOrEmpty(loginRequisicao.Senha) && !string.IsNullOrEmpty(loginRequisicao.Email) &&
                    !string.IsNullOrWhiteSpace(loginRequisicao.Senha) && !string.IsNullOrWhiteSpace(loginRequisicao.Email))
                {
                    string email = "fpontes006@gmail.com";
                    string senha = "Senha@123";

                    if (loginRequisicao.Email == email && loginRequisicao.Senha == senha)
                    {

                        Usuario usuario = new Usuario()
                        {
                            Email = loginRequisicao.Email,
                            Id = 12,
                            Nome = "Felipe Pontes"
                        };

                        return Ok(new LoginRespostaDto()
                        {
                            Email = usuario.Email,
                            Nome = usuario.Nome,
                            Token = TokenService.CriarToken(usuario)

                        });
                    }
                    else
                    {
                        return BadRequest(new ErrorRespostaDto()
                        {
                            Desricao = "Email ou senha invalido!",
                            Status = StatusCodes.Status400BadRequest
                        });
                    }
                }
                else
                {

                    return BadRequest(new ErrorRespostaDto()
                    {
                        Desricao = "Usuario não preencheu os campos de login corretamente",
                        Status = StatusCodes.Status400BadRequest
                    });

                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocorreu um erro no login: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorRespostaDto()
                {
                    Desricao = "Ocorreu um erro ao fazer o login",
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }


    }
}
