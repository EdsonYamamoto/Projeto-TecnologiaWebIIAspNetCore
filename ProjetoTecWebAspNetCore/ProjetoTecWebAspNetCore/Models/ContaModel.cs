using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class ContaModel
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public UsuarioModel Usuario { get; set; }
        public int NumeroConta { get; set; }
        public List<BalancoModel> Balanco { get; set; }

        public override string ToString()
        {
            return Usuario.ToString()+' '+NumeroConta;
        }
    }
}
