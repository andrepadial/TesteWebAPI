using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAPI.Models
{
    public class Funcionario
    {
        public string matricula { set; get; }
        public string nome { set; get; }
        public string area { set; get; }
        public string cargo { set; get; }
        public string salario_bruto { set; get; }
        public string data_de_admissao { set; get; }
    }
}