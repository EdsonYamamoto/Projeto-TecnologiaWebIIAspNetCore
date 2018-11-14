using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class Emprestimo
    {
        public int ID { get; set; }
        public int IDInvestidor { get; set; }
        public UsuarioModel Investidor { get; set; }
        public int IDTomador { get; set; }
        public UsuarioModel Tomador { get; set; }
        public double Valor { get; set; }
        public double Parcela { get; set; }
        public int QuantidadeParcela { get; set; }
        public DateTime Horario { get; set; }
        public Boolean Autorizacao { get; set; }
    }
}
