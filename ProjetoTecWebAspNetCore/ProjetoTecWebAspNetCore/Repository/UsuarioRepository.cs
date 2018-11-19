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

        public IEnumerable<UsuarioModel> GetAllUsuarios()
        {
            return _appContextModel.Usuarios;
        }

        public UsuarioModel GetUsuarioById(int usuarioId)
        {
            return _appContextModel.Usuarios.FirstOrDefault(p => p.ID == usuarioId);
        }

        public UsuarioModel GetAutentication(int usuarioId, string senha)
        {
            return _appContextModel.Usuarios.FirstOrDefault(p => p.ID == usuarioId && p.Senha == senha);
        }
    }
}
