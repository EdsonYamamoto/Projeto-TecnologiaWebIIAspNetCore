using ProjetoTecWebAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Repository
{
    interface IConversaRepositorycs
    {
        IEnumerable<ConversaModel> GetAllConversas();
        ConversaModel GetConversaById(int conversaId);
        List<ConversaModel> GetConversaByUserID(int usuarioID);
    }
}
