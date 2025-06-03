using Microsoft.AspNetCore.Mvc;
using EntradaDTO;

namespace Produtos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProdutosController : ControllerBase
  {
    [HttpPost("teste")]
    public IActionResult Teste([FromBody] Entrada Pedi)
    {
      var mensagens = Pedi.pedidos.Select(p => $"{p.pedido_id} é um dos pedidos").ToList();

      return Ok(new { mensagens });
    }
  }
}
