//####################################################
//                                                   #
//   NOME: MIGUEL FERNANDES SANTOS.                  #
//   DATA: 03/10/2021                                #
//   PROJETO: IMPAR E PAR ALEATORIO.                 #
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
            // DICIONARIO PARA GUARDAR OS VALORES:
            Dictionary<string, double> valores = new Dictionary<string, double>()
            {

                {"Aleatorio", 0 },
                {"SomaPares", 0 },
                {"SomaImpares", 0 }

            };

            // DECLARAÇÃO DA VARIAVEL QUE IRA CRIAR NUMEROS ALEATORIOS:
            Random valor = new Random();

            for (int i = 1; i <= 10; i += 1)
            {
                // A VARIAVEL ALEATORIO RECEBE O NOVO NUMERO ALEATORIO ENTRE 1 E 100
                valores["Aleatorio"] = valor.Next(101);
                Console.WriteLine("O numero aleatorio gerado é: " + valores["Aleatorio"]);

                // SE O RESTO FOR IGUAL A ZERO ENTAO É PAR:
                if (valores["Aleatorio"] % 2 == 0)
                {

                    valores["SomaPares"] += valores["Aleatorio"];
                    Console.WriteLine("E ele é um numero par.\n\n");

                }
                else // SE NÃO É IMPAR
                {

                    valores["SomaImpares"] += valores["Aleatorio"];
                    Console.WriteLine("E ele é um numero impar.\n\n");

                }

            }

            // MOSTRA A SOMA DOS PARES E IMPARES:
            Console.WriteLine("A soma dos numeros Pares é de: " + valores["SomaPares"]);
            Console.WriteLine("A soma dos numeros Impares é de: " + valores["SomaImpares"]);
            Console.Read();

        }
    }
}
