using ControleDeIphone.Models;
using ControleDeIphones.Data;
using System.Collections.Generic;
using System.Linq;

namespace Apple.Repositorio
{
    public class IphoneRepositorio : InterIphoneRepositorio
    {
        private readonly BancoContext _bancoContext;

        public IphoneRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public IphoneModel ListarPorId(int id)
        {
            return _bancoContext.Iphones.FirstOrDefault(x => x.Id == id);
        }

        public List<IphoneModel> BuscarTodos()
        {
            return _bancoContext.Iphones.ToList();
        }

        public IphoneModel Adicionar(IphoneModel iphone)
        {
            _bancoContext.Iphones.Add(iphone);
            _bancoContext.SaveChanges();
            return iphone;
        }

        public IphoneModel Atualizar(IphoneModel iphone)
        {
            IphoneModel iphoneDB = ListarPorId(iphone.Id);
            if (iphoneDB == null) throw new Exception("Houve um erro na atualização do iPhone.");

            iphoneDB.Nome = iphone.Nome;
            iphoneDB.Cor = iphone.Cor;
            iphoneDB.Preco = iphone.Preco;

            _bancoContext.Iphones.Update(iphoneDB);
            _bancoContext.SaveChanges();

            return iphoneDB;
        }

        public bool Apagar(int id)
        {
            IphoneModel iphoneDB = ListarPorId(id);
            if (iphoneDB == null) throw new Exception("Houve um erro na exclusão do iPhone.");

            _bancoContext.Iphones.Remove(iphoneDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
