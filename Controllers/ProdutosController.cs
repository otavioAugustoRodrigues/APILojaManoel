using Microsoft.AspNetCore.Mvc;
using EntradaDTO;
using SaidaDTO;
using Calcula.Service;

namespace Produtos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProdutosController : ControllerBase
  {
    private readonly ICalculaCaixaService _calculaCaixaService;

    public ProdutosController(ICalculaCaixaService calculaCaixaService)
    {
      _calculaCaixaService = calculaCaixaService;
    }

    [HttpPost("teste")]
    public IActionResult Principal([FromBody] Entrada Pedi)
    {
      var output = _calculaCaixaService.Funcaodesaida(Pedi);
      return Ok(new { output });
    }
  }
}
