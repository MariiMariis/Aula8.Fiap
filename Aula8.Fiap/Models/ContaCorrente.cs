using Aula8.Fiap.Exceptions;
using Aula8.Fiap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula8.Fiap.Models
{
    class ContaCorrente : Conta
    {
        //propriedades da classe Conta corrente
        public TipoConta Tipo { get; set; }
        public decimal Limite { get; set; }


        // Construtor que recebe propriedades da classe base (Conta) e suas próprias propriedades
        public ContaCorrente(int agencia, int numero, IList<Cliente> clientes, TipoConta tipo) : base(agencia, numero, clientes)
        {
            Tipo = tipo;
            ConfigurarLimite();
        }

        //Método que configura limite estabelecido

        private void ConfigurarLimite()
        {
            // Dtermina um limite de crédito para a conta caso seja do tipo especial ou premium

            Limite = Tipo == TipoConta.Especial ? 500 : Tipo == TipoConta.Premium ? 1000 : 0;

            //if (Tipo == TipoConta.Especial)
            //    Limite = 500;
            //else if (Tipo == TipoConta.Premium)
            //    Limite = 1000;

        }

        //método que é herdado obrigatoriamente da classe base
        public override void Retirar(decimal valor)
        {
            if (valor > Saldo + Limite)
            {
                throw new SaldoInsuficienteException("Saldo Insuficiente");
            }
            Saldo -= valor;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTipo de conta: {Tipo}\nLimite: {Limite.ToString("c")}";
        }

    }
}
