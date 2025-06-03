using SaidaDTO;
using EntradaDTO;
using Pedidos.Model;

namespace Calcula.Service
{
  public class CalculaCaixaService : ICalculaCaixaService
  {
    public CalculaCaixaService()
    {
    }
    public List<SaidaJson> Funcaodesaida(Entrada entrada)
    {
      var listOut = new List<SaidaJson>();

      foreach (var i in entrada.pedidos)
      {

        int defCaixa = DefineEmbalagem(i);

        if (defCaixa != 0)
        {
          i.caixa = defCaixa;
        }

        string? caixa_nova = null;
        string? obs = null;
        int id_ped_novo = i.pedido_id;

        if (defCaixa != 0)
        {
          caixa_nova = $"Caixa {i.caixa}";
        }
        else
        {
          obs = "Produto não cabe em nenhuma caixa disponível.";
        }

        var listprod = new List<string>();
        foreach (var p in i.produtos)
        {
          string prod = p.produto_id;
          listprod.Add(prod);
        }

        var novaCaixa = new Caixa(caixa_nova, listprod);

        // Supondo que SaidaJson precise de id_ped_novo, novaCaixa e obs
        var saidaItem = new SaidaJson(
            id_ped_novo,
            novaCaixa
        );

        if (obs != null)
        {
          saidaItem.observacao = obs;
        }

        listOut.Add(saidaItem);
      }
      return listOut;

    }

    public int DefineEmbalagem(Pedido pedido)
    {
      int volume_t = 0;
      int largMax = 0;
      int altMax = 0;
      int compMax = 0;

      foreach (var prod in pedido.produtos)
      {
        int volume = prod.dimensoes.altura * prod.dimensoes.comprimento * prod.dimensoes.largura;
        volume_t += volume;

        if (prod.dimensoes.altura > altMax) altMax = prod.dimensoes.altura;
        if (prod.dimensoes.comprimento > compMax) compMax = prod.dimensoes.comprimento;
        if (prod.dimensoes.largura > largMax) largMax = prod.dimensoes.largura;
      }
      Console.Write($"{volume_t}");

      if (volume_t <= 96000 && altMax < 30 && largMax < 40 && compMax < 80)
      {
        return 1;
      }
      else if (volume_t <= 160000 && altMax < 80 && largMax < 50 && compMax < 40)
      {
        return 2;
      }
      else if (volume_t <= 240000 && altMax < 50 && largMax < 80 && compMax < 60)
      {
        return 3;
      }
      else
      {
        return 0;
      }
    }

  }

}
