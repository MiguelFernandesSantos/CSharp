//####################################################
//                                                   #
//   NOME: MIGUEL FERNANDES SANTOS.                  #
//   DATA: 03/10/2021                                #
//   PROJETO: ENTRADA DE VALORES.                    #
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
            // DICIONARIO QUE CONTEM OS VALORES UTILIZADOS:
            Dictionary<string, double> numeros = new Dictionary<string, double>() {

                {"MenorQueDez", 0 },
                {"MenorQueCem", 0 },
                {"MenorQueMil", 0 },
                {"MenorQueDezMil", 0 },
                {"MaiorQueDezMil", 0 },
                {"QtsTotal", 0 },
                {"Soma", 0 },
                {"Media", 0 }

            };

            // VARIAVEL USADA PARA O LAÇO DE REPETIÇÃO:
            int num = 1;

            while (num != 0)
            {
               
                Console.Write("Digite um numero: ");

                // LER UMA INFORMAÇÃO DO CONSOLE:
                string texto = Console.ReadLine();

                // CONVERTER PARA INTEIRO:
                num = Convert.ToInt32(texto);

                // SE FOR IGUAL A 0 TERMINA O LAÇÕ:
                if(num == 0){

                    break;

                }else if (num < 0)
                {
                    // MENOR QUE 0 NUMERO INVALIDO:
                    Console.WriteLine("O numero " + num + " é um numero negativo o que o torna invalido.");

                }else if (num >= 1 && num <= 9)
                {
                    // ADICIONA 1 NA VARIAVEL:
                    numeros["MenorQueDez"] += 1;

                }else if(num >= 10 && num <= 99)
                {
                    // ADICIONA 1 NA VARIAVEL:
                    numeros["MenorQueCem"] += 1;

                }else if(num >= 100 && num <= 999)
                {
                    // ADICIONA 1 NA VARIAVEL:
                    numeros["MenorQueMil"] += 1;

                }else if (num >= 1000 && num <= 10000)
                {
                    // ADICIONA 1 NA VARIAVEL:
                    numeros["MenorQueDezMil"] += 1;

                }else
                {
                    // ADICIONA 1 NA VARIAVEL:
                    numeros["MaiorQueDezMil"] += 1;

                }

                if (num > 0 && num != 0)
                {
                    // ADICIONA 1 NA VARIAVEL USADA PARA A MEDIA:
                    numeros["QtsTotal"] += 1;

                    // ADICIONA NA VARIAVEL O VALOR DO NUMERO INSERIDO PELO USUARIO:
                    numeros["Soma"] += num;

                }

            }

            // SE NAO DIGITAR NENHUM NUMERO:
            if (numeros["QtsTotal"] == 0)
            {

                Console.WriteLine("Voce nao digitou nenhum numero.");

            }
            else
            {
                // CALCULA A MEDIA:
                numeros["Media"] = numeros["Soma"] / numeros["QtsTotal"];

                // MOSTRA NO CONSOLE EM QUAL INTERVALO ENTRA OS NUMEROS DIGITADOS:
                Console.WriteLine("\nVoce digitou " + numeros["MenorQueDez"] + " numeros que estao entre 1 e 9.");
                Console.WriteLine("\nVoce digitou " + numeros["MenorQueCem"] + " numeros que estao entre 10 e 99.");
                Console.WriteLine("\nVoce digitou " + numeros["MenorQueMil"] + " numeros que estao entre 100 e 999.");
                Console.WriteLine("\nVoce digitou " + numeros["MenorQueDezMil"] + " numeros que estao entre 1000 e 10000.");
                Console.WriteLine("\nVoce digitou " + numeros["MaiorQueDezMil"] + " numeros maiores que 10000.");
                Console.WriteLine("\nA soma dos numeros é de " + numeros["Soma"]);
                Console.WriteLine("\nA media dos numeros é de " + numeros["Media"]);

            }

            Console.Read();

        }
    }
}
