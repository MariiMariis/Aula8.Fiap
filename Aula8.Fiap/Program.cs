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
                Console.WriteLine($"\nDigite o Id do cliente {i}");
                long id = long.Parse(Console.ReadLine());

                Console.WriteLine($"\nDigite o Nome do cliente {i}");
                string nome = Console.ReadLine();

                Console.WriteLine($"\nDigite o CPF do cliente {i}");
                string cpf = Console.ReadLine();

                //Instanciando o cliente
                Cliente cliente = new Cliente(id, nome) { Cpf = cpf };

                //Adicionando cliente criado à lista
                clientes.Add(cliente);
            }

            Console.WriteLine("\nDigite o número da conta corrente:");
            var numero = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite o número da agencia conta corrente:");
            var agencia = int.Parse(Console.ReadLine());

            var dataAbertura = DateTime.Today;

            Console.WriteLine("\nDigite o tipo da conta corrente:");
            // var varivelName = (cast) -> Converte a string para os valores do Enum TipoConta, true -> Não diferencia maíúsculas de minúsculas
            TipoConta tipo = (TipoConta) Enum.Parse(typeof(TipoConta), Console.ReadLine(), true);

            // Instanciando o objeto do tipo Conta Corrente
            ContaCorrente cc = new ContaCorrente(agencia: agencia, numero: numero, clientes: clientes, tipo: tipo)
            {
                DataAbertura = dataAbertura
            };

            //Exibir os dados da conta corrente
            Console.WriteLine($"\nConta Corrente: \n{cc}");

            // Le os dados da conta poupança
            Console.WriteLine("\nDigite o número da conta poupança:");
            numero = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite a agência da conta poupança:");
            agencia = int.Parse(Console.ReadLine());

            //o método today do datetime chama automaticamente a data do dia de hoje

            dataAbertura = DateTime.Today;

            Console.WriteLine("\nDigite a taxa de retirada da conta poupança:");
            var taxa = decimal.Parse(Console.ReadLine());

            // Instanciar a conta Poupança
            ContaPoupanca poupanca = new ContaPoupanca(agencia: agencia, numero: numero, clientes: clientes, taxa: taxa)
            {
                DataAbertura = dataAbertura
            };

            Console.WriteLine($"\nConta Poupança: \n{poupanca}");

            int opcao;

            //Inicia a execução do menu
            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("\nEscolha uma das opções abaixo: \n1-Depósito em conta \n2-Retirada - Conta Corrente \n3-Depósito - Conta Poupança" +
                    "\n4-Retirada - Conta Poupança \n5-Exibir dados das contas \n6-Calcular retorno Investimento \n0-Sair");
                Console.WriteLine("\n------------------------------");

                opcao = int.Parse(Console.ReadLine());

                // Realiza um determinada ação, a depender da opção escolhida.
                //Opção essa, armazenada pela variável opcao
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o valor para depósito");
                        cc.Depositar(decimal.Parse(Console.ReadLine()));
                        Console.WriteLine($"Novo saldo: {cc.Saldo}");
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Digite o valor para retirada:");
                            cc.Retirar(decimal.Parse(Console.ReadLine()));
                            Console.WriteLine($"Novo saldo: {cc.Saldo}");
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            Console.WriteLine($"Não foi possível realizar a retirada: {e.Message} ");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite o valor a ser depositado:");
                        poupanca.Depositar(decimal.Parse(Console.ReadLine()));
                        Console.WriteLine($"Novo saldo: {poupanca.Saldo}");
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Digite o valor da retirada:");
                            poupanca.Retirar(decimal.Parse(Console.ReadLine()));
                            Console.WriteLine($"Novo saldo: {poupanca.Saldo}");
                        }
                        catch (SaldoInsuficienteException e)
                        {
                            Console.WriteLine($"Não foi possível realizar a retirada: {e.Message} ");
                        }
                        break;
                    case 5:
                        Console.WriteLine($"Conta corrente: \n{cc}");
                        Console.WriteLine($"Conta poupanca: \n{poupanca}");
                        break;

                    case 6:
                        Console.WriteLine($"O retorno do investimento é: {poupanca.CalcularRetornoInvestimento()}");
                        break;
                    case 0:
                        Console.WriteLine("Finalizando o sistema. Obrigada por utilizar o Banco Shift ");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != 0);

        }
    }
}
