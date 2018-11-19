using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Repository
{
    public class GastosRepository : IGastosRepository
    {
        private readonly AppContextModel _appContextModel;

        public IEnumerable<GastosModel> GetAllGastos()
        {
            return _appContextModel.Gastos;
        }

        public GastosModel GetGastosById(int gastosId)
        {
            return _appContextModel.Gastos.FirstOrDefault(p => p.ID == gastosId);
        }
    }
}
