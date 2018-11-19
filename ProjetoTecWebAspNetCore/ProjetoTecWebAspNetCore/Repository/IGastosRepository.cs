using ProjetoTecWebAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Repository
{
    interface IGastosRepository
    {
        IEnumerable<GastosModel> GetAllGastos();
        GastosModel GetGastosById(int gastosId);
    }
}
