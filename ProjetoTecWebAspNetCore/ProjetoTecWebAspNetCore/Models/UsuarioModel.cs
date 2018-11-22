using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string TipoUsuario { get; set; }
        public string Obs { get; set; }


        public override string ToString()
        {
            return "nome: "+this.Nome+" obs:"+this.Obs;
        }
    }
}
