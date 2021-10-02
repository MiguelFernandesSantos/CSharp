// EM DESENVOLVIMENTO

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

            Dictionary<string, Dictionary<string, double>> GeometriaPlana = new Dictionary<string, Dictionary<string, double>>() {

                {"Quadrado", new Dictionary<string, double>()
                {
                    {"Base", 10 },
                    {"Altura", 10 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },

                {"Triangulo", new Dictionary<string, double>()
                {

                    {"Base", 10 },
                    {"Altura", 10 },
                    {"Lado1", 5 },
                    {"Lado2", 5 },
                    {"Lado3", 5 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },

                {"Retangulo", new Dictionary<string, double>()
                {

                    {"Base", 10 },
                    {"Altura", 10 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },

                {"Circulo", new Dictionary<string, double>()
                {

                    {"Diametro", 20 },
                    {"Raio", 0 },
                    {"Pi", 3.14 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },

                {"Losango", new Dictionary<string, double>()
                {

                    {"DiagonalMaior", 10 },
                    {"DiagonalMenor", 10 },
                    {"Lado", 5 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },

                {"Trapezio", new Dictionary<string, double>()
                {

                    {"BaseMaior", 10 },
                    {"BaseMenor", 10 },
                    {"Lado1", 5 },
                    {"Lado2", 5 },
                    {"Altura", 10 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },

                {"Paralelogramo", new Dictionary<string, double>()
                {

                    {"Base", 10 },
                    {"Altura", 10 },
                    {"Area", 0 },
                    {"Perimetro", 10 },

                } }


            };

            Dictionary<string, double[]> Calculos = tudo(GeometriaPlana);

            Console.WriteLine(Calculos);
            Console.Read();

            Dictionary<string, double[]> tudo (Dictionary<string, Dictionary<string, double>> formas)
            {
                double[] quadrado = calcularQuadrado(formas["Quadrado"]);
                double[] triangulo = calcularTriangulo(formas["Triangulo"]);
                double[] retangulo = CalcularRetangulo(formas["Retangulo"]);

                Dictionary<string, Double[]> Tudo = new Dictionary<string, double[]>()
                {
                    {"Quadrado", quadrado },
                    {"Triangulo", triangulo },
                    {"Retangulo", retangulo },
                    
                };

                return Tudo;
            }

            double[] calcularQuadrado(Dictionary<string, double> quadrado)
            {

                quadrado["Area"] = quadrado["Base"] * quadrado["Altura"];
                quadrado["Perimetro"] = (quadrado["Base"] * 2) + (quadrado["Altura"] * 2);

                double[] AreaPerimetro = new double[2];
                AreaPerimetro[0] = quadrado["Area"];
                AreaPerimetro[1] = quadrado["Perimetro"];


                return AreaPerimetro;

            } 

            double[] calcularTriangulo (Dictionary<string, double> triangulo)
            {

                triangulo["Area"] = (triangulo["Base"] * triangulo["Altura"]) / 2;
                triangulo["Perimetro"] = triangulo["Lado1"] + triangulo["Lado2"] + triangulo["Lado3"];


                double[] AreaPerimetro = new double[2];
                AreaPerimetro[0] = triangulo["Area"];
                AreaPerimetro[1] = triangulo["Perimetro"];

                return AreaPerimetro;
            }

            double[] CalcularRetangulo (Dictionary<string, double> retangulo)
            {
                retangulo["Area"] = retangulo["Base"] * retangulo["Altura"];
                retangulo["Perimetro"] = (retangulo["Base"] * 2) + (retangulo["Perimetro"] * 2);

                double[] AreaPerimetro = new double[2];
                AreaPerimetro[0] = retangulo["Area"];
                AreaPerimetro[1] = retangulo["Perimetro"];

                return AreaPerimetro;
            }

        }
    }
}
