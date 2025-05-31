using Microsoft.AspNetCore.Mvc;

namespace Produtos.Controllers
{
  [ApiController]
  [Route("api/produtos")]
  public class ProdutosController : ControllerBase
  {
    [HttpPost("teste")]
    public IActionResult Teste()
    {
      return Ok(new { mensagem = "endpoint funcionando" });
    }
  }
}
