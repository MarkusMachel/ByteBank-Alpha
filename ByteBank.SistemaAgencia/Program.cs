using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
           var contas = new List<ContaCorrente>()
           {
               new ContaCorrente(123, 5234),
               new ContaCorrente(134, 5),
               new ContaCorrente(124, 524),
               null,
               new ContaCorrente(23, 34),
               new ContaCorrente(55, 1)
           };

           // contas.Sort(); ~~> Chama a implementação dada em IComparable

           // contas.Sort(new ComparadorContaCorrentePorAgencia());

           var listaSemNulos = new List<ContaCorrente>();

           foreach (var conta in contas)
           {
               if (conta != null)
               {
                   listaSemNulos.Add(conta);
               }
           }

           IEnumerable<ContaCorrente> contasNaoNulas = contas.Where(conta => conta != null);

           IOrderedEnumerable<ContaCorrente> listaOrdenada = contasNaoNulas.OrderBy(conta => conta.Numero);

           foreach (var conta in listaOrdenada)
           {
               Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
           }

            

        }
    }
}
