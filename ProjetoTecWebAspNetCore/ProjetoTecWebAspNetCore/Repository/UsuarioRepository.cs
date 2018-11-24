using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTecWebAspNetCore.Models;

namespace ProjetoTecWebAspNetCore.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppContextModel _appContextModel;

        public UsuarioRepository(AppContextModel appContextModel)
        {
            _appContextModel = appContextModel;
        }

        public IEnumerable<UsuarioModel> GetAllUsuarios()
        {
            return _appContextModel.Usuarios.ToList();
        }

        public UsuarioModel GetUsuarioById(int usuarioId)
        {
            return _appContextModel.Usuarios.FirstOrDefault(p => p.ID == usuarioId);
        }

        public UsuarioModel AutenticationUser(string email, string senha)
        {
            return _appContextModel.Usuarios.FirstOrDefault(p => p.Email == email && p.Senha == senha);
        }
        public List<ContaModel> ContasUsuario(int usuarioID)
        {
            var teste = _appContextModel.Contas.Select(p => p.UsuarioID == usuarioID);
            System.Diagnostics.Debug.Print(teste.ToString());
            
            return _appContextModel.Contas.ToList();
        }
    }
}
