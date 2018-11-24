using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Repository
{
    public class BalancoRepository : IBalancoRepository
    {
        private readonly AppContextModel _appContextModel;
        
        public BalancoRepository(AppContextModel appContextModel)
        {
            _appContextModel = appContextModel;
        }

        public IEnumerable<BalancoModel> GetAllBalancos()
        {
            return _appContextModel.Balancos;
        }

        public BalancoModel GetBalancoById(int balancoId)
        {
            return _appContextModel.Balancos.FirstOrDefault(p => p.ID == balancoId);
        }
    }
}
