using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Repository
{
    public class ContaRepository : IContaRepositorycs
    {

        private readonly AppContextModel _appContextModel;

        public ContaRepository(AppContextModel appContextModel)
        {
            _appContextModel = appContextModel;
        }

        public IEnumerable<ContaModel> GetAllContas()
        {
            return _appContextModel.Contas;
        }

        public ContaModel GetContaById(int contaId)
        {
           return _appContextModel.Contas.FirstOrDefault(p => p.ID == contaId);
        }

        public List<ContaModel> GetContaByUserID(int usuarioID)
        {
            List<ContaModel> a = new List<ContaModel>();
            //System.Diagnostics.Debug.Print(_appContextModel.Contas.Select(p => p.UsuarioID == usuarioID));
            return a;
        }
    }
}
