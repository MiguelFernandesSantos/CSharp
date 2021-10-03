//####################################################
//                                                   #
//   NOME: MIGUEL FERNANDES SANTOS.                  #
//   DATA: 03/10/2021                                #
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
            // DICIONARIO PARA OS VALORES:
            Dictionary<string, double> valores = new Dictionary<string, double>()
            {

                {"Numero", 0 },
                {"Num1", 0 },
                {"Num2", 1 },
                {"Num3", 0 },
                {"Valor", 0 },

            };
            
            // DECLARAÇÃO DE UMA VARIAVEL QUE GERA VALORES ALEATORIOS
            Random aleatorio = new Random();

            // GUARDAR NA VARIAVEL NUMERO UM NOVO NUMERO ALEATORIO ENTRE 1 E 10:
            valores["Numero"] = aleatorio.Next(10);

            while (valores["Valor"] < valores["Numero"])
            {

                valores["Num1"] = valores["Num2"];
                valores["Num2"] = valores["Num1"] + 1;
                valores["Num3"] = valores["Num2"] + 1;

                // FAZ A MULTIPLICAÇÃO DE 3 NUMEROS SEGUIDOS (1 * 2 * 3):
                valores["Valor"] = valores["Num1"] * valores["Num2"] * valores["Num3"];

                if (valores["Valor"] == valores["Numero"])
                {
                    // COLOCA NO CONSOLE A MENSAGEM QUE O PRODUTO DA MULTIPLICAÇÃO DE 3 NUMEROS SEGUIDOS É IGUAL O VALOR GERADO ALEATORIO:
                    Console.WriteLine(valores["Num1"] + " * " + valores["Num2"] + " * " + valores["Num3"] + " = " + valores["Numero"]);
                    Console.Read();
                    return;

                }

            }
            // COLOCA NO CONSOLE QUE O NUMERO GERADO ALEATORIO NAO É UM PRODUTO DA MULTIPLICAÇÃO DE 3 NUMEROS SEGUIDOS:
            Console.WriteLine("O numero "+ valores["Numero"] + " não é um natural triangular.");
            Console.Read();

        }
    }
}
