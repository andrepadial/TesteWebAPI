using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TesteAPI.Models
{
    public class FuncionarioRepositorio
    {
        public List<Funcionario> funcionarios = new List<Funcionario>();


        public FuncionarioRepositorio()
        {
            try
            {
                string filePath = Path.GetFullPath(Path.Combine(@"C:\temp\Funcionarios\Funcionarios.json"));
                string funcionariosJSON = File.ReadAllText(filePath);
                funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(funcionariosJSON);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Funcionario> getFuncionarios()
        {
            return funcionarios;
        }

        public Funcionario getFuncionarioByMatricula(string matricula)
        {
            return funcionarios.Where(x => x.matricula.ToUpper() == matricula.ToUpper()).FirstOrDefault<Funcionario>();
        }

        public List<Funcionario> getFuncionariosByArea(string area)
        {
            return funcionarios.Where(x => x.area.ToUpper() == area.ToUpper()).ToList<Funcionario>();
        }

        public List<Funcionario> getFuncionariosByCargo(string cargo)
        {
            return funcionarios.Where(x => x.cargo.ToUpper() == cargo.ToUpper()).ToList<Funcionario>();
        }

        public List<Funcionario> getFuncionariosByDataAdmissao(string dataAdmissao)
        {
            return funcionarios.Where(x => x.data_de_admissao == dataAdmissao).ToList<Funcionario>();
        }
    }
}