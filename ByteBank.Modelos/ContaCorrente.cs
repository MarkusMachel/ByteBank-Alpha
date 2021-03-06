using System;

namespace ByteBank.Modelos
{
    public class ContaCorrente : IComparable
    {
        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPerimidas { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }
        public int Numero { get; }
        public int Agencia { get; }
        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        // Construtor 
        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("O argumento Agência deve ser maior que 0.", nameof(agencia));
            }
            else if (numero <= 0)
            {
                throw new ArgumentException("O argumento Número deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
             if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para transferência.", nameof(valor));
            }

            try 
            {
                Sacar(valor);
            }
             catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPerimidas++;
                throw new OperacaoFincanceiraException("Operação não realizada.", ex);                
            }

            contaDestino.Depositar(valor);
        }

        public int CompareTo(object obj)
        {
            // Retornar negativo quando a instância precede o obj;
            // Retornar zero quando nossa instância e obj forem equivalentes;
            // Retornar positive diferente de zero quando a precedencia for de obj;

            ContaCorrente outraConta = obj as ContaCorrente;

            if (outraConta == null)
            {
                return -1;
            }

            if (Numero < outraConta.Numero)
            {
                return -1;
            }

            if (Numero == outraConta.Numero)
            {
                return 0;
            }

            return 1;
        }
    }
}
