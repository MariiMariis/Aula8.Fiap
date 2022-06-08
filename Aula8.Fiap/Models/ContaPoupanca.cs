using System;
using System.Collections.Generic;
using System.Text;
using Aula8.Fiap.Exceptions;
using Aula8.Fiap.Models;

namespace Aula8.Fiap.Models
{
    class ContaPoupanca : Conta, IContaInvestimento
    {
        //Propriedade da classe ContaPoupanca
        public decimal Taxa { get; set; }

        //Implementando os membros da classe, e também os membros da classe base (Conta)
        public ContaPoupanca(int agencia, int numero, IList<Cliente> clientes, decimal taxa) : base(agencia, numero, clientes)
        {
            Taxa = taxa;
        }

        // Implementação dos membros da Interface IContaInvestimento 
        // Quando implementando uma interface, a implementação de TODOS os seus métodos é OBRIGATÓRIA
        public decimal CalcularRetornoInvestimento()
        {
            return Saldo * 0.05m;
        }

        public override void Retirar(decimal valor)
        {
            if (valor + Taxa > Saldo)
                throw new SaldoInsuficienteException("Saldo Insuficiente");
            Saldo -= valor + Taxa;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTaxa: {Taxa}";

        }
    }
}
