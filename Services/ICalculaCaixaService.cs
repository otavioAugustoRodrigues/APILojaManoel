using EntradaDTO;
using SaidaDTO;
using DbProdutos.Models;

namespace Calcula.Service
{
  public interface ICalculaCaixaService
  {
    List<SaidaJson> Funcaodesaida(Entrada entrada);

    Task<DbProduto> CriarProduto(int caixa);
  }
}
