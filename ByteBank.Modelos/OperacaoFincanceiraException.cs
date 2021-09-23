using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class OperacaoFincanceiraException : Exception
    {
        public OperacaoFincanceiraException()
        {}

        public OperacaoFincanceiraException(string mensagem) : base(mensagem)
        {}

        public OperacaoFincanceiraException(string mensagem, Exception excecaoInterna) : base (mensagem, excecaoInterna)
        {}
    }
}