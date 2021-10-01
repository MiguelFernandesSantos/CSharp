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

            Dictionary<string, double> Dados = new Dictionary<string, double>()
            {

                {"Peso", 80 },
                {"Altura", 1.75 },
                {"IMC", 0 },
                
            };

            Dados["IMC"] = Dados["Peso"] / (Dados["Altura"] * 2);
            Dados["IMC"] = Math.Round(Dados["IMC"], 2);

            if (Dados["IMC"] < 18.5)
            {

                Console.WriteLine("O seu IMC é Classificado como: Magreza.");
                Console.WriteLine("Seu IMC é: " + Dados["IMC"]);

            }
            else if (Dados["IMC"] < 24.9)
            {

                Console.WriteLine("O seu IMC é Classificado como: Normal.");
                Console.WriteLine("Seu IMC é: " + Dados["IMC"]);

            }
            else if (Dados["IMC"] < 29.9)
            {

                Console.WriteLine("O seu IMC é Classificado como: Sobrepeso.");
                Console.WriteLine("Seu IMC é: " + Dados["IMC"]);

            }
            else
            {

                Console.WriteLine("O seu IMC é Classificado como: Obesidade grave.");
                Console.WriteLine("Seu IMC é: " + Dados["IMC"]);

            }

            Console.Read();

        }
    }
}
