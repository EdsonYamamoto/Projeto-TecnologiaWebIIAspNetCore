using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class ConversaModel
    {
        public int ID { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }
        public string Mensagem { get; set; }
        public DateTime Horiario { get; set; }
    }
}
