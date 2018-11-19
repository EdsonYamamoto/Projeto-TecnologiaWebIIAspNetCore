using ProjetoTecWebAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Repository
{
    interface IUsuarioRepository
    {
        IEnumerable<UsuarioModel> GetAllUsuarios();
        UsuarioModel GetUsuarioById(int usuarioId);
        UsuarioModel GetAutentication(int usuarioId, string senha);

    }
}
