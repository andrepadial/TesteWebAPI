using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAPI.Models
{
    public class ParticipacaoRepositorio
    {
        static readonly FuncionarioRepositorio repositorioFuncionario = new FuncionarioRepositorio();
        static readonly ParticipacaoRepositorio repositorioParticipacao = new ParticipacaoRepositorio();

        public List<Participacao> participacoes = new List<Participacao>();
        public List<Funcionario> funcionarios = new List<Funcionario>();

        public ParticipacaoRepositorio()
        {
            funcionarios = repositorioFuncionario.getFuncionarios();            

            foreach (Funcionario func in funcionarios)
            {
                participacoes.Add(new Participacao(func.matricula,
                                                    func.nome,
                                                    String.Concat(
                                                                 getValorParticipacaoFuncionario(func).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"))
                                                                 )
                                                   )
                                 );
            }

        }

        public List<Participacao> getParticipacoes()
        {
            return participacoes;
        }

        public Participacao getParticipacaoFuncionario(string matricula)
        {
            return participacoes.Where(x => x.matricula == matricula).FirstOrDefault<Participacao>();
        }

        private double getValorParticipacaoFuncionario(Funcionario func)
        {
            ParticipacaoBusiness p = new ParticipacaoBusiness();
            return p.getParticipacaoFuncionario(func);
        }

        private double getTotalParticipacoes()
        {
            ParticipacaoBusiness p = new ParticipacaoBusiness();
            return p.getTotalParticipacoes(participacoes);
        }

        public string getJSONParticipacoes(double totalDisponibilizado)
        {
            double totalParticipacoes = getTotalParticipacoes();
            string strserialize = JsonConvert.SerializeObject(participacoes);
            string retFinal = String.Concat("participacoes:", strserialize);
            retFinal = String.Concat(retFinal,
                                        "'total_de_funcionarios': ",
                                        "'",
                                        funcionarios.Count().ToString(),
                                        "'", ",",
                                        "'total_distribuido': ",
                                        totalParticipacoes.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")),
                                        "'", ",",
                                        "'total_disponibilizado': ",
                                        "'",
                                        totalDisponibilizado.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")),
                                        "'", ",",
                                        "'saldo_total_disponibilizado:' ",
                                        "'",
                                        getSaldo(totalDisponibilizado, totalParticipacoes).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")),
                                        "'"
                                    );
            
            retFinal = retFinal.Replace("\"", "'");            
            return retFinal;
        }

        public string getJSONParticipacoesMatricula(double totalDisponibilizado, string matricula)
        {
            double totalParticipacoes = getTotalParticipacoes();
            string strserialize = JsonConvert.SerializeObject(participacoes.Where(x => x.matricula == matricula).FirstOrDefault<Participacao>());

            string retFinal = String.Concat("participacoes:", strserialize);
            retFinal = String.Concat(retFinal,
                                        "'total_de_funcionarios': ",
                                        "'",
                                        funcionarios.Count().ToString(),
                                        "'", ",",
                                        "'total_distribuido': ",
                                        totalParticipacoes.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")),
                                        "'", ",",
                                        "'total_disponibilizado': ",
                                        "'",
                                        totalDisponibilizado.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")),
                                        "'", ",",
                                        "'saldo_total_disponibilizado:' ",
                                        "'",
                                        getSaldo(totalDisponibilizado, totalParticipacoes).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")),
                                        "'"
                                    );
            retFinal = retFinal.Replace("\"", "'");
            return retFinal;
        }

        public double getSaldo(double totalDisponibilizado, double totalParticipacoes)
        {
            return (totalDisponibilizado - totalParticipacoes);
        }

    }
}