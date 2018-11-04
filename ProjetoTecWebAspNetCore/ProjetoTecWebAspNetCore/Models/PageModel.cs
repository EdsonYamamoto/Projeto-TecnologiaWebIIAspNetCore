using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTecWebAspNetCore.Models
{
    public class PageModel
    {
        private string title;
        private string auxTitle;

        public string Title { get => title; set => title = value; }
        public string AuxTitle { get => auxTitle; set => auxTitle = value; }
    }
}
