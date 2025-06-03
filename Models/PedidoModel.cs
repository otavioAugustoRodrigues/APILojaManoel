using Itens.Model;
using System.Text.Json.Serialization;

namespace Pedidos.Model
{
  public class Pedido
  {
    public int pedido_id { get; set; }

    public List<Produto> produtos { get; set; }

    [JsonIgnore]
    public int caixa { get; set; }
  }

}

