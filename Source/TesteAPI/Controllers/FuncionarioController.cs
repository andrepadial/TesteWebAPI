using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteAPI.Models;

namespace TesteAPI.Controllers
{
    public class FuncionarioController : ApiController
    {
        static readonly FuncionarioRepositorio repositorio = new FuncionarioRepositorio();

        [AcceptVerbs("GET")]
        [Route("Funcionarios")]
        public IEnumerable<Funcionario> getFuncionarios()
        {
            return repositorio.getFuncionarios();
        }


        [AcceptVerbs("GET")]
        [Route("FuncionarioPorMatricula/{matricula}")]
        public Funcionario getFuncionarioByMatricula(string matricula)
        {
            return repositorio.getFuncionarioByMatricula(matricula);
        }

        [AcceptVerbs("GET")]
        [Route("FuncionariosPorArea/{area}")]
        public IEnumerable<Funcionario> getFuncionariosByArea(string area)
        {
            return repositorio.getFuncionariosByArea(area);
        }

        [AcceptVerbs("GET")]
        [Route("FuncionariosPorCargo/{cargo}")]
        public IEnumerable<Funcionario> getFuncionariosByCargo(string cargo)
        {
            return repositorio.getFuncionariosByCargo(cargo);
        }

        [AcceptVerbs("GET")]
        [Route("FuncionariosPorDataAdmissao/{dataAdmissao}")]
        public IEnumerable<Funcionario> getFuncionariosByDataAdmissao(string dataAdmissao)
        {
            return repositorio.getFuncionariosByDataAdmissao(dataAdmissao);
        }
    }
}
