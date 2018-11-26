using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Repository
{
    public class ConversaRepository : IConversaRepositorycs
    {

        private readonly AppContextModel _appContextModel;

        public ConversaRepository(AppContextModel appContextModel)
        {
            _appContextModel = appContextModel;
        }

        public IEnumerable<ConversaModel> GetAllConversas()
        {
            return _appContextModel.Conversas.ToList();
        }

        public ConversaModel GetConversaById(int conversaId)
        {
            return _appContextModel.Conversas.FirstOrDefault(p => p.ID == conversaId);
        }

        public List<ConversaModel> GetConversaByUserID(int usuarioID)
        {
            return _appContextModel.Conversas.Where(p => p.IdUsuario == usuarioID).ToList();
        }
    }
}
