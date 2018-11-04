using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class GastosModel
    {
        public int ID { get; set; }
        public int ContaID { get; set; }
        public ContaModel Conta { get; set; }
        public double Custo { get; set; }
        public string Categoria { get; set; }
    }
}
