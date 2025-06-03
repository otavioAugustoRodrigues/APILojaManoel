using Microsoft.AspNetCore.Mvc;
using EntradaDTO;
using Saida;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Produtos.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProdutosController : ControllerBase
  {
    [HttpPost("teste")]
    public IActionResult Principal([FromBody] Entrada Pedi)
    {
      var listOut = new List<SaidaJson>();

      foreach (var i in Pedi.pedidos)
      {
        int id_ped_novo = i.pedido_id;
        string caixa_nova = $"Caixa {i.caixa}";

        var listProd = new List<string>();
        foreach (var p in i.produtos)
        {
          string prod = p.produto_id;
          listProd.Add(prod);
        }

        var novaCaixa = new Caixa(
          caixa_nova,
          listProd);
        var saidaItem = new SaidaJson(
          id_ped_novo,
          novaCaixa
        );

        listOut.Add(saidaItem);
      }

      return Ok(new { listOut });
    }
  }
}
