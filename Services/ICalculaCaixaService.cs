using EntradaDTO;
using SaidaDTO;

namespace Calcula.Service
{

  public interface ICalculaCaixaService
  {
    List<SaidaJson> Funcaodesaida(Entrada entrada);
  }

}