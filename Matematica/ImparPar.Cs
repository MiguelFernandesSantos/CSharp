//####################################################
//                                                   #
//   NOME: MIGUEL FERNANDES SANTOS.                  #
//   DATA: 02/10/2021                                #
//   PROJETO: DESCOBRIR SE É IMPAR OU PAR (DIDATICO) #
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
            // DECLARAÇÃO DE UMA MATRIZ COM N VALORES:
            int[] numeros = {44, 86, 15, 16, 75, 90, 656, 25, 153, 165, 813, 32, 36 };

            // DECLARAÇÃO DE UM DICIONARIO QUE GUARDA OS VALORES:
            Dictionary<string, double> ImparPar = new Dictionary<string, double>()
            {
                // QUANTIDADE DE NUMEROS IMPARES:
                {"Impar", 0},

                // A SOMA DOS NUMEROS IMPARES:
                {"ImparSoma", 0 },

                // A MEDIA DOS NUMEROS IMPARES:
                {"ImparMedia", 0 },

                // QUANTIDADE DE NUMEROS PARES:
                {"Par", 0 },

                // A SOMA DOS NUMEROS PARES:
                {"ParSoma", 0 },

                // A MEDIA DOS NUMEROS PARES:
                {"ParMedia", 0 }

            };

            // LAÇO PARA ACESSAR CADA VALOR DO DICIONARIO:
            foreach (int numero in numeros)
            {

                // SE O RESTO SER IGUAL A 0 ENTÃO É PAR:
                if (numero % 2 == 0)
                {

                    ImparPar["Par"] += 1;
                    ImparPar["ParSoma"] += numero;

                }
                else // SE NAO É IMPAR:
                {

                    ImparPar["Impar"] += 1;
                    ImparPar["ImparSoma"] += numero;

                }

            }

            // CALCULA A MEDIA DOS NUMEROS IMPARES:
            ImparPar["ImparMedia"] = Math.Round((ImparPar["ImparSoma"] / ImparPar["Impar"]), 2);

            // CALCULA A MEDIA DOS NUMEROS PARES:
            ImparPar["ParMedia"] = Math.Round((ImparPar["ParSoma"] / ImparPar["Par"]), 2);


            foreach(var item in ImparPar)
            {
                // EXIBE CADA CHAVE E SEU VALOR:
                Console.WriteLine(item.Key + ": " + item.Value + "\n");

            }

            Console.Read();

        }
    }
}
