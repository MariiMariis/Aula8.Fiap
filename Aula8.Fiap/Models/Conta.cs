using System;
using System.Collections.Generic;
using System.Text;

namespace Aula8.Fiap.Models
{
    abstract class Conta
    {
        // Criando propriedades de Conta
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
        public IList<Cliente> Clientes { get; set; }

        //Criando construtor que recebe como parâmetro, agência, numero e Clientes
        public Conta(int agencia, int numero, IList<Cliente> clientes)
        {
            Agencia = agencia;
            Numero = numero;
            Clientes = clientes;
        }

        // Método to tipo cirtual (que pode ser sobreposto por suas classes filhas) 
        // para depositar algum valor na conta
        public virtual void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        //método do tipo abstract (Não permite que seja utilizado por sí só. Apenas herdado de classes filhas)
        // Retira algum valor da conta
        public abstract void Retirar (decimal valor);

        //Método que imprime todos os cliente vinculados a conta e exibe as informações gerais desta conta
        public override string ToString()
        {
            var detalhes = "";

            // Percorrer a lista de cliente para exibi-los na conta
            foreach (var item in Clientes)
            {
                detalhes += $"{item} \n";
            }
            detalhes += $"Agencia: {Agencia}\nNúmero: {Numero}\nSaldo: {Saldo.ToString("c")}\nData abertura: {DataAbertura} ";

            return detalhes;
        }
    }
}
