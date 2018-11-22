using ProjetoTecWebAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Repository
{
    interface IBalancoRepository
    {
        IEnumerable<BalancoModel> GetAllBalancos();
        BalancoModel GetBalancoById(int balancoId);
    }
}
