
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteAPI.Models;

namespace TesteAPI.Controllers
{
    public class ParticipacaoController : ApiController
    {
        static readonly ParticipacaoRepositorio repositorio = new ParticipacaoRepositorio();

        [AcceptVerbs("GET")]
        [Route("Participacoes")]
        public IEnumerable<Participacao> getParticipacoes()
        {           
            return repositorio.getParticipacoes();
        }

       
        [AcceptVerbs("GET")]
        [Route("Participacao/{totalDisponibilizado}")]
        public string getParticipacoes(double totalDisponibilizado)
        {
            return repositorio.getJSONParticipacoes(totalDisponibilizado);
        }

        [AcceptVerbs("GET")]
        [Route("Participacao/{totalDisponibilizado}/{matricula}")]
        public string getParticipacoesMatricula(double totalDisponibilizado, string matricula)
        {
            return repositorio.getJSONParticipacoesMatricula(totalDisponibilizado, matricula);
        }

        [AcceptVerbs("GET")]
        [Route("ParticipacaoPorMatricula/{matricula}")]
        public Participacao getParticipacaoByMatricula(string matricula)
        {
            return repositorio.getParticipacaoFuncionario(matricula);
        }
    }
}
