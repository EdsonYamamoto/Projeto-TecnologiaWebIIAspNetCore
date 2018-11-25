using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class BalancoModel
    {
        public int ID { get; set; }
        public int ContaID { get; set; }
        public ContaModel Conta { get; set; }
        public double Valor { get; set; }
        public string TipoGasto { get; set; }
        public DateTime Data { get; set; }

        public override string ToString()
        {
            return Valor+" "+ TipoGasto+ " "+ Data;
        }
    }
}
