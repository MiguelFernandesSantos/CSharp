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

            Dictionary<string, double> Parametros = new Dictionary<string, double>()
            {
                // VALOR INICIAL DO LAÇO DE REPETIÇÃO:
                {"Inicio", 1 },

                // VALOR FINAL DO LAÇO DE REPETIÇÃO:
                {"Fim", 100 },

                // O NUMERO USADO PARA VER SE OS NUMEROS SÃO MULTIPLO DELE:
                {"NumerosMultipho", 10 }

            };

            // LAÇO DE REPETIÇÃO PARA VERIFICAR UM INTERVALO DE NUMEROS:
            while(Parametros["Inicio"] <= Parametros["Fim"]){

                if (Parametros["Inicio"] % Parametros["NumerosMultipho"] == 0)
                {

                    Console.WriteLine("O numero " + Parametros["Inicio"] + " é multiplo de " + Parametros["NumerosMultipho"] + ".\n");

                }

                Parametros["Inicio"] += 1;

            }

            Console.Read();

        }
    }
}
