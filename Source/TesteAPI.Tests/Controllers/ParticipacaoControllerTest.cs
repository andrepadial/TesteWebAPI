using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAPI.Controllers;
using TesteAPI.Models;

namespace TesteAPI.Tests.Controllers
{

    [TestClass]
    public class ParticipacaoControllerTest
    {

        [TestMethod]
        public void getParticipacoes()
        {
            ParticipacaoController participacao = new ParticipacaoController();
            IEnumerable<Participacao> participacoes = participacao.getParticipacoes();
                        
            Assert.IsNotNull(participacoes);
            Assert.AreEqual(22, participacoes.Count());
            //Assert.AreEqual("value1", participacoes.ElementAt(0));
            //Assert.AreEqual("value2", participacoes.ElementAt(1));
        }


        //[TestMethod]
        //public void getParticipacaoByMatricula()
        //{
        //    ParticipacaoController participacao = new ParticipacaoController();
        //    Participacao part = new Participacao();

        //    string teste = participacao.getParticipacoesMatricula(4000000, "0009968");
        //    Assert.AreEqual("value", teste);
        //}

    }
}
