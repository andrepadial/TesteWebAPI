using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAPI.Models
{
    public class ParticipacaoBusiness
    {
        private const int salarioMinimo = 1000;
        private const int mesesParticipacao = 12;

        public ParticipacaoBusiness()
        {
        }
        private int getPesoPorArea(Funcionario func)
        {
            int peso = 1;

            if (func.area == "Contabilidade" || func.area == "Financeiro" || func.area == "Tecnologia")
                peso = 2;
            else if (func.area == "Serviços Gerais")
                peso = 3;
            else if (func.area == "Relacionamento com o Cliente")
                peso = 5;

            return peso;
        }

        private int getPesoFaixaSalarial(Funcionario func)
        {
            int peso = 1;
            int salarios = 1;

            salarios = (Convert.ToInt32(func.salario_bruto.Replace("R$", "").Replace(".", "").Replace(",", "")) / 100) / salarioMinimo;

            if (salarios > 3 && salarios < 5)
                peso = 2;
            else if (salarios > 5 && salarios < 8)
                peso = 3;
            else if (salarios > 8)
                peso = 5;

            return peso;
         }

        private int getPesoTempoAdmissao(Funcionario func)
        {
            int peso = 1;
            int anos = new DateTime((DateTime.Now - (Convert.ToDateTime(func.data_de_admissao))).Ticks).Year;

            if (anos > 1 && anos < 3)
                peso = 2;
            else if (anos > 3 && anos < 8)
                peso = 3;
            else if (anos > 8)
                peso = 5;

            return peso;
        }

        public double getParticipacaoFuncionario(Funcionario func)
        {
            double participacao = 0.00;

            int pesoFxSalarial = getPesoFaixaSalarial(func);
            int pesoTempo = getPesoTempoAdmissao(func);
            int pesoArea = getPesoPorArea(func);

            double salarioBruto = Convert.ToDouble((func.salario_bruto.Replace("R$", "").Replace(".", "").Replace(",", ""))) / 100;
            
            participacao = Math.Round( (
                            ( (salarioBruto * pesoTempo) + (salarioBruto * pesoArea) ) / pesoFxSalarial
                           ) * mesesParticipacao, 2)
                            ;

            return participacao;
        }

        public double getTotalParticipacoes (List<Participacao> participacoes)
        {
            double soma = 0.00;

            foreach (Participacao p in participacoes)
            {
                soma += (Convert.ToDouble((p.valor_da_participacao.Replace("R$", "").Replace(".", "").Replace(",", ""))) / 100);
            }

            return soma;
        }
    }
}