using System;
using System.Collections.Generic;
using System.Text;

namespace Aula8.Fiap.Models
{
    class Cliente
    {
        // Criando propiredades
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        // Construtor 
        public Cliente(long id, string nome)
        {
            Id = id;
            Nome = nome;
            
        }
        
        // Criação de método que retorna as informações sobre as propriedades do Cliente
        public override string ToString()
        {
            return $"Id: {Id}\nNome: {Nome}\nCPF: {Cpf}";
        }

    }
}
