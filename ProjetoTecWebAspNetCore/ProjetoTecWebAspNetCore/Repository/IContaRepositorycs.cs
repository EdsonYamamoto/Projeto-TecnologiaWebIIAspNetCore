using ProjetoTecWebAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Repository
{
    interface IContaRepositorycs
    {
        IEnumerable<ContaModel> GetAllContas();
        ContaModel GetContaById(int contaId);
        List<ContaModel> GetContaByUserID(int usuarioID);
    }
}
