using System;
using System.Collections.Generic;
using System.Text;

namespace Aula8.Fiap.Exceptions
{
    [Serializable]
    
    public class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() { }

        public SaldoInsuficienteException(string message) : base(message) { }

        public SaldoInsuficienteException(string message, Exception innerException) : base(message, innerException) { }

        protected SaldoInsuficienteException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
