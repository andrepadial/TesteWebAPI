using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAPI.Models
{
    public class Participacao
    {
        public string matricula { set; get; }
        public string nome { set; get; }
        public string valor_da_participacao { set; get; }

        public Participacao()
        {

        }
        public Participacao(string matriculaFunc, string nomeFunc, string vlrParticipacao)
        {
            matricula = matriculaFunc;
            nome = nomeFunc;
            valor_da_participacao = vlrParticipacao;
        }
    }
}