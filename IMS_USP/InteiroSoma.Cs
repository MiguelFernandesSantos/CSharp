//####################################################
//                                                   #
//   NOME: MIGUEL FERNANDES SANTOS.                  #
//   DATA: 04/10/2021                                #
//   PROJETO: NATURAL TRIANGULAR.                    #
//                                                   #
//####################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARAÇÃO DE UM ARRAY:
            int[] numeros = new int[13];

            // VARIAVEL UTILIZADA PARA PERCORRER O ARRAY E ADICIONAR VALORES:
            int tamanho = numeros.Length - 1;

            // DECLARAÇÃO DE UMA VARIAVEL PARA FAZER A SOMA:
            int soma = 0;

            // DECLARAÇÃO DE UM GERADOR DE VALORES ALEATORIOS:
            Random valor = new Random();

            Console.WriteLine("Numeros: ");

            for (int i = 0; i <= tamanho; i++)
            {
                // A POSIÇÃO DO VALOR I RECEBE UM VALOR ENTRE 10 E 99
                numeros[i] = valor.Next(10, 100);

                // ADICIONA O NUMERO GERADO NA VARIAVEL SOMA:
                soma += numeros[i];

                // MOSTRA NO CONSOLE SEM PULAR LINHA O VALOR GERADO ALEATORIO:
                Console.WriteLine(numeros[i]);
                
            }

            // MOSTRA NO CONSOLE O VALOR DA SOMA:
            Console.WriteLine("\nSoma: " + soma);

            Console.Read();
        }
    }
}
