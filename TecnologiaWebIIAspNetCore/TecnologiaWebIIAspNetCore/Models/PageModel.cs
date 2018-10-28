using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecnologiaWebIIAspNetCore.Models
{
    public class PageModel
    {
        private string auxTitle;
        private string title;
        private string projectName;

        public string ProjectName { get => projectName; set => projectName = value; }
        public string Title { get => title; set => title = value; }
        public string AuxTitle { get => auxTitle; set => auxTitle = value; }
        //public string ;

    }
}
