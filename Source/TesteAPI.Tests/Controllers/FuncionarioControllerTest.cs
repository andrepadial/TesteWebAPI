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
    public class FuncionarioControllerTest
    {

        [TestMethod]
        public void getFuncionarios()
        {
            FuncionarioController func = new FuncionarioController();
            IEnumerable<Funcionario> funcionarios = func.getFuncionarios();

            // Declarar
            Assert.IsNotNull(funcionarios);
            Assert.AreEqual(22, funcionarios.Count());
            //Assert.AreEqual("value1", funcionarios.ElementAt(0));
            //Assert.AreEqual("value2", funcionarios.ElementAt(1));
        }

        [TestMethod]
        public void getFuncionarioByMatricula()
        {
            FuncionarioController funcController = new FuncionarioController();
            Funcionario func = new Funcionario();

            func = funcController.getFuncionarioByMatricula("0009968");
            Assert.AreEqual("Victor Wilson", func.nome);
        }

        //[TestMethod]
        //public void getFuncionarioByArea()
        //{
        //    FuncionarioController func = new FuncionarioController();
        //    IEnumerable<Funcionario> funcionarios = func.getFuncionariosByArea("Contabilidade");

        //    // Declarar
        //    Assert.IsNotNull(funcionarios);
        //    Assert.AreEqual(2, funcionarios.Count());
        //    Assert.AreEqual("value1", funcionarios.ElementAt(0));
        //    Assert.AreEqual("value2", funcionarios.ElementAt(1));
        //}

        //[TestMethod]
        //public void getFuncionarioByCargo()
        //{
        //    FuncionarioController func = new FuncionarioController();
        //    IEnumerable<Funcionario> funcionarios = func.getFuncionariosByCargo("Estagiário");

        //    // Declarar
        //    Assert.IsNotNull(funcionarios);
        //    Assert.AreEqual(2, funcionarios.Count());
        //    Assert.AreEqual("value1", funcionarios.ElementAt(0));
        //    Assert.AreEqual("value2", funcionarios.ElementAt(1));
        //}

        //[TestMethod]
        //public void getFuncionarioByDataAdmissao()
        //{
        //    FuncionarioController func = new FuncionarioController();
        //    IEnumerable<Funcionario> funcionarios = func.getFuncionariosByDataAdmissao("2014-07-15");

        //    // Declarar
        //    Assert.IsNotNull(funcionarios);
        //    Assert.AreEqual(2, funcionarios.Count());
        //    Assert.AreEqual("value1", funcionarios.ElementAt(0));
        //    Assert.AreEqual("value2", funcionarios.ElementAt(1));
        //}

    }
}
