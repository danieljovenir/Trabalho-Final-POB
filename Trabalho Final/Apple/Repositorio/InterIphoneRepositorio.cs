using ControleDeIphone.Models;
using System.Collections.Generic;

namespace Apple.Repositorio
{
    public interface InterIphoneRepositorio
    {
        IphoneModel ListarPorId(int id);
        List<IphoneModel> BuscarTodos();
        IphoneModel Adicionar(IphoneModel iphone);
        IphoneModel Atualizar(IphoneModel iphone);
        bool Apagar(int id);
    }
}
