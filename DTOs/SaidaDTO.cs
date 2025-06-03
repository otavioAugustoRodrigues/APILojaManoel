using System.Text.Json.Serialization;

namespace SaidaDTO
{
  public class SaidaJson
  {
    public int pedido_id { get; set; }

    public Caixa caixas { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? observacao { get; set; }

    public SaidaJson(int pedidoId, Caixa caixas)
    {
      pedido_id = pedidoId;
      this.caixas = caixas;
      observacao = null;
    }
  }

  public class Caixa
  {
    public string caixa_id { get; set; }

    public List<string> produtos { get; set; }
    public Caixa(string id, List<string> prods)
    {
      caixa_id = id;
      produtos = prods;
    }
  }
}
