using Aula8.Fiap.Exceptions;
using Aula8.Fiap.Models;
using System;
using System.Collections.Generic;

namespace Aula8.Fiap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criar um lista de cliente
            var clientes = new List<Cliente>();

            Console.WriteLine("Digite a quantidade de clientes:");
            var qtd = int.Parse(Console.ReadLine());

            /*Esse loop for, lê o valor da variavel 'qtd' que é a quantidade de clientes na conta
            e itera sobre esse valor para criar a quantidade de cadastros informada*/ 

            for (int i = 1; i <= qtd; i++)
            {
                // Le os dados do cliente
                Console.WriteLine($"Digite o Id do cliente {i}");
                long id = long.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o Nome do cliente {i}");
                string nome = Console.ReadLine();

                Console.WriteLine($"Digite o CPF do cliente {i}");
                string cpf = Console.ReadLine();

                //Instanciando o cliente
                Cliente cliente = new Cliente(id, nome) { Cpf = cpf };

                //Adicionando cliente criado à lista
                clientes.Add(cliente);
            }

            Console.WriteLine("Digite o número da conta corrente:");
            var numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da agencia conta corrente:");
            var agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o data de abertura da conta corrente:");
            var dataAbertura = DateTime.Parse(Console.ReadLine());

            // var varivelName = (cast) -> Converte a string para os valores do Enum TipoConta, true -> Não diferencia maíúsculas de minúsculas
            TipoConta tipo = (TipoConta) Enum.Parse(typeof(TipoConta), Console.ReadLine(), true);

            // Instanciando o objeto do tipo Conta Corrente
            ContaCorrente cc = new ContaCorrente(agencia: agencia, numero: numero, clientes: clientes, tipo: tipo)
            {
                DataAbertura = dataAbertura
            };

            //Exibir os dados da conta corrente
            Console.WriteLine($"Conta Corrente: \n{cc}");

            // Le os dados da conta poupança
            Console.WriteLine("Digite o número da conta poupança:");
            numero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a agência da conta poupança:");
            agencia = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de abertura da conta poupança:");
            dataAbertura = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite a taxa de retirada da conta poupança:");
            var taxa = decimal.Parse(Console.ReadLine());

            // Instanciar a conta Poupança
            ContaPoupanca poupanca = new ContaPoupanca(agencia: agencia, numero: numero, clientes: clientes, taxa: taxa)
            {
                DataAbertura = dataAbertura
            };

            Console.WriteLine($"Conta Poupança: \n{poupanca}");

        }
    }
}
