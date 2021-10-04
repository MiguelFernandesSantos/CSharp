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
            // DECLARAÇÃO DO GERADOR DE VALORES:
            Random valor = new Random();

            // DECLARAÇÃO DA VARIAVEL UTILIZADA PARA MOSTRAR OS NUMEROS IMPARES_
            // MENORES OU IGUAL A ELA:
            int limite = valor.Next(10, 20);

            // VARIAVEL QUE GUARDA OS NUMEROS IMPARES:
            int auxiliar = 1;

            for (int i = 1; i <= limite; i++)
            {

                // A CADA VEZ QUE O LAÇO SE INICIA É COLOCADO NO CONSOLE O NUMERO:
                Console.WriteLine(auxiliar);

                // A CADA VEZ QUE O LAÇO SE INICIA É ADICIONADO + 2 A VARIAVEL:
                auxiliar += 2;

            }

            Console.Read();
        }
    }
}
