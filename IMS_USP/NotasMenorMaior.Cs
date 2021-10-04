//####################################################
//                                                   #
//   NOME: MIGUEL FERNANDES SANTOS.                  #
//   DATA: 04/10/2021                                #
//   PROJETO: INTEIROS IMPARES.                      #
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

            // DECLARAÇÃO DE UM ARRAY DOUBLE COM AS NOTAS DOS ALUNOS:
            Double[] alunosNotas = new double[4];

            // DECLARAÇÃO DE UMA VARIAVEL PARA O LAÇO:
            int tamanho = alunosNotas.Length - 1;

            // DECLARAÇÃO DO GERADOR DE VALORES ALEATORIO:
            Random valor = new Random();

            Console.WriteLine("Notas:");

            // LAÇO DE REPETIÇÃO PARA PERCORRER O ARRAY:
            for (int i = 0; i <= tamanho; i++)
            {

                // ADICIONA O VALOR ALEATORIO NO ARRAY:
                alunosNotas[i] = valor.Next(1, 11);

                // MOSTRA NO CONSOLE O VALOR GERADO ALEATORIO:
                Console.WriteLine(alunosNotas[i]);

            }

            // DECLARAÇÃO DE VARIAVEL PARA GUARDAR A MAIOR NOTA;
            double maior = 0;

            // DECLARAÇÃO DE VARIAVEL PARA GUARDAR A MENOR NOTA;
            double menor = alunosNotas[3];

            for (int i = 0; i <= tamanho; i++)
            {

                // SE O VALOR DA VARIAVEL MAIOR SER MENOR QUE O VALOR DO ARRAY:
                if( maior < alunosNotas[i])
                {
                    
                    // MAIOR RECEBE O VALOR DO ARRAY
                    maior = alunosNotas[i];

                }

                // SE O VALOR DA VARIAVEL MENOR SER MAIOR QUE O VALOR DO ARRAY:
                if (menor > alunosNotas[i])
                {
                    // MENOR RECEBE O VALOR DO ARRAY:
                    menor = alunosNotas[i];

                }

            }

            Console.WriteLine("\nMaior: " + maior + "  Menor: " + menor);

            Console.Read();
        }
    }
}
