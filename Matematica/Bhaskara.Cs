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

            Dictionary<string, double> bhaskara = new Dictionary<string, double>() {

                {"A", 4 },
                {"B", 2 },
                {"C", -6 },
                {"B_elevado", 0 },
                {"Delta", 0 },
                {"Raiz", 0 },
                {"Divisor", 0 },
                {"X1", 0 },
                {"X2", 0 }

            };

            // 4 * A * C:
            bhaskara["Delta"] = 4 * bhaskara["A"] * bhaskara["C"];

            // B²:
            bhaskara["B_elevado"] = Math.Pow(bhaskara["B"], 2);

            // A² + (4 * A * C):
            bhaskara["Delta"] = bhaskara["B_elevado"] - (bhaskara["Delta"]);

            // RAIZ QUADRADA DE DELTA:
            bhaskara["Raiz"] = Math.Sqrt(bhaskara["Delta"]);

            // 2 * A:
            bhaskara["Divisor"] = 2 * bhaskara["A"];

            // ( -B - RAIZ DE DELTA) / ( 2 * A):
            bhaskara["X1"] = ( -bhaskara["B"] + bhaskara["Raiz"]) / bhaskara["Divisor"];

            // ( -B + RAIZ DE DELTA) / ( 2 * A):
            bhaskara["X2"] = ( -bhaskara["B"] - bhaskara["Raiz"]) / bhaskara["Divisor"];


            Console.WriteLine(bhaskara["X1"]);
            Console.WriteLine(bhaskara["X2"]);
            Console.Read();

        }
    }
}
