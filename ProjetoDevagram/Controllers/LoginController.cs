using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoDevagram.Dto;

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
                throw new ArgumentException("Erro ao preencher os dados");
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
