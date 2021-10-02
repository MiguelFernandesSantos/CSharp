//####################################################
//                                                   #
//    NOME: MIGUEL FERNANDES SANTOS.                 #
//    DATA: 02/10/2021                               #
//    PROJETO: CALCULO AREA E PERIMETRO (DIDATICO).  #
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

            // DECLARAÇÃO DO DICIONARIO COM TODAS AS FORMAS GEOMETRICAS:
            Dictionary<string, Dictionary<string, double>> GeometriaPlana = new Dictionary<string, Dictionary<string, double>>() {

                // DICIONARIO QUE CONTEM OS VALORES DO QUADRADO:
                {"Quadrado", new Dictionary<string, double>()
                {
                    {"Base", 10 },
                    {"Altura", 10 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },
                
                // DICIONARIO QUE CONTEM OS VALORES DO TRIANGULO:
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
                
                // DICIONARIO QUE CONTEM OS VALORES DO RETANGULO:
                {"Retangulo", new Dictionary<string, double>()
                {

                    {"Base", 10 },
                    {"Altura", 10 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },
                
                // DICIONARIO QUE CONTEM OS VALORES DO CIRCULO:
                {"Circulo", new Dictionary<string, double>()
                {

                    {"Diametro", 20 },
                    {"Raio", 0 },
                    {"Pi", 3.14 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },
                
                // DICIONARIO QUE CONTEM OS VALORES DO LOSANGO:
                {"Losango", new Dictionary<string, double>()
                {

                    {"DiagonalMaior", 10 },
                    {"DiagonalMenor", 10 },
                    {"Lado", 5 },
                    {"Area", 0 },
                    {"Perimetro", 0 }

                } },
                
                // DICIONARIO QUE CONTEM OS VALORES DO TRAPEZIO:
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
                
                // DICIONARIO QUE CONTEM OS VALORES DO PARALELOGRAMO:
                {"Paralelogramo", new Dictionary<string, double>()
                {

                    {"Base", 10 },
                    {"Altura", 10 },
                    {"Area", 0 },
                    {"Perimetro", 10 },

                } }


            };

            // DECLARAÇÃO DE UM DICIONARIO QUE RECEBER O RETORNO DE UM DICIONARIO DA FUNÇÃO TUDO:
            Dictionary<string, double[]> Calculos = tudo(GeometriaPlana);

            // LAÇO DE REPETIÇÃO QUE ACESSA OS ITEMS DO DICIONARIO:
            foreach(var item in Calculos)
            {

                // EXIBE A CHAVE E O VALOR NUMERO 1 DO DICIONARIO:
                Console.WriteLine(item.Key + " Area: " + item.Value[0]);
                
                // EXIBE A CHAVE E O VALOR NUMERO 2 DO DICIONARIO:
                Console.WriteLine(item.Key + " Perimetro: " + item.Value[1] + "\n\n");

            }

            Console.Read();


            // FUNÇÃO QUE RETORNA UM DICIONARIO QUE CONTEM UMA MATRIZ DE MEDIA E PERIMETRO DO CALCULO DAS FORMAS GEOMETRICAS:
            Dictionary<string, double[]> tudo (Dictionary<string, Dictionary<string, double>> formas)
            {

                // CONJUNTO DE DECLARAÇÕES DE MATRIZ QUE RECEBER UM ARRAY DE SUAS FUNÇOES:
                double[] quadrado = calcularQuadrado(formas["Quadrado"]);
                double[] triangulo = calcularTriangulo(formas["Triangulo"]);
                double[] retangulo = CalcularRetangulo(formas["Retangulo"]);
                double[] circulo = CalcularCirculo(formas["Circulo"]);
                double[] losango = CalcularLosango(formas["Losango"]);
                double[] trapezio = CalcularTrapezio(formas["Trapezio"]);
                double[] paralelogramo = CalcularParalelogramo(formas["Paralelogramo"]);

                // DECLARAÇÃO DE UM DICIONARIO QUE RECEBE AS MATRIZES DE CADA UMA DAS FORMULAS GEOMETRICAS:
                Dictionary<string, Double[]> Tudo = new Dictionary<string, double[]>()
                {
                    {"Quadrado", quadrado },
                    {"Triangulo", triangulo },
                    {"Retangulo", retangulo },
                    {"Circulo", circulo },
                    {"Losango", losango },
                    {"Trapezio", trapezio },
                    {"Paralelogramo", paralelogramo }

                };

                // RETORNA O DICIONARIO COM AS MATRIZES:
                return Tudo;

            }

            double[] calcularQuadrado(Dictionary<string, double> quadrado)
            {

                // CALCULA A AREA DO QUADRADO ( BASE * ALTURA):
                quadrado["Area"] = quadrado["Base"] * quadrado["Altura"];

                // CALCULA O PERIMETRO DO QUADRADO (BASE * 2) + ( ALTURA * 2):
                quadrado["Perimetro"] = (quadrado["Base"] * 2) + (quadrado["Altura"] * 2);

                // DECLARAÇÃO DE UMA MATRIZ:
                double[] AreaPerimetro = new double[2];

                // O PRIMEIRO VALOR DO ARRAY (INDICE 0) RECEBE O VALOR DA AREA:
                AreaPerimetro[0] = quadrado["Area"];

                // O SEGUNDO VALOR DO ARRAY (INDICE 1) RECEBE O VALOR DO PERIMETRO:
                AreaPerimetro[1] = quadrado["Perimetro"];


                return AreaPerimetro;

            } 

            double[] calcularTriangulo (Dictionary<string, double> triangulo)
            {

                // CALCULA A AREA DO TRIANGULO ((BASE * ALTURA) / 2):
                triangulo["Area"] = (triangulo["Base"] * triangulo["Altura"]) / 2;

                // CALCULA O PERIMETRO DO TRIANGULO (LADO1 + LADO2 + LADO3):
                triangulo["Perimetro"] = triangulo["Lado1"] + triangulo["Lado2"] + triangulo["Lado3"];

                // DECLARAÇÃO DE UMA MATRIZ:
                double[] AreaPerimetro = new double[2];

                // O PRIMEIRO VALOR DO ARRAY (INDICE 0) RECEBE O VALOR DA AREA:
                AreaPerimetro[0] = triangulo["Area"];

                // O SEGUNDO VALOR DO ARRAY (INDICE 1) RECEBE O VALOR DO PERIMETRO:
                AreaPerimetro[1] = triangulo["Perimetro"];

                return AreaPerimetro;
            }

            double[] CalcularRetangulo (Dictionary<string, double> retangulo)
            {
                // CALCULA A AREA DO RETANGULO (BASE * ALTURA):
                retangulo["Area"] = retangulo["Base"] * retangulo["Altura"];

                // CALCULA O PERIMETRO DO RETANGULO ((BASE * 2) + (ALTURA * 2)):
                retangulo["Perimetro"] = (retangulo["Base"] * 2) + (retangulo["Altura"] * 2);

                // DECLARAÇÃO DE UM ARRAY:
                double[] AreaPerimetro = new double[2];

                // O PRIMEIRO VALOR (INDICE 0) RECEBE O VALOR DA AREA:
                AreaPerimetro[0] = retangulo["Area"];

                // O SEGUNDO VALOR (INDICE 1) RECEBE O VALOR DO PERIMETRO:
                AreaPerimetro[1] = retangulo["Perimetro"];

                return AreaPerimetro;
            }

            double[] CalcularCirculo (Dictionary<string, double> circulo)
            {
                // CALCULA A AREA DO CIRCULO (PI *(DIAMETRO / 2) * (DIAMETRO / 2)):
                circulo["Area"] = circulo["Pi"] * ( (circulo["Diametro"] / 2) * (circulo["Diametro"] / 2 ));

                // CALCULA O PERIMETRO DO CIRCULO ((2 * PI) * (DIAMETRO / 2)):
                circulo["Perimetro"] = (2 * circulo["Pi"]) * (circulo["Diametro"] / 2);

                // DECLARAÇÃO DE UM ARRAY:
                double[] MediaPerimetro = new double[2];

                // O PRIMEIRO VALOR (INDICE 0) RECEBE O VALOR DA AREA:
                MediaPerimetro[0] = circulo["Area"];

                // O SEGUNDO VALOR (INDICE 1) RECEBE O VALOR DO PERIMETRO:
                MediaPerimetro[1] = circulo["Perimetro"];

                return MediaPerimetro;
            }

            double[] CalcularLosango (Dictionary<string, double> losango)
            {
                // CALCULA A AREA DO LOSANGO ((DIAGONAL MENOR * DIAGONAL MAIOR) / 2):
                losango["Area"] = (losango["DiagonalMenor"] * losango["DiagonalMaior"]) / 2;

                // CALCULA O PERIMETRO DO LOSANGO (LADO * 4):
                losango["Perimetro"] = losango["Lado"] * 4;

                // DECLARAÇÃO DE UM ARRAY:
                double[] AreaPerimetro = new double[2];

                // O PRIMEIRO VALOR (INDICE 0) RECEBE O VALOR DA AREA:
                AreaPerimetro[0] = losango["Area"];

                // O SEGUNDO VALOR (INDICE 1) RECEBE O VALOR DO PERIMTRO:
                AreaPerimetro[1] = losango["Perimetro"];

                return AreaPerimetro;
            }

            double[] CalcularTrapezio (Dictionary<string, double> trapezio)
            {
                // CALCULA O VALOR DA AREA DO TRAPEZIO (((BASE MAIOR + BASE MENOR) / 2) * ALTURA))):
                trapezio["Area"] = ((trapezio["BaseMaior"] + trapezio["BaseMenor"]) / 2) * trapezio["Altura"];

                // CALCULA O VALOR DO PERIMETRO DO TRAPEZIO (BASE MAIOR + BASE MENOR + LADO1 + LADO2):
                trapezio["Perimetro"] = trapezio["BaseMaior"] + trapezio["BaseMenor"] + trapezio["Lado1"] + trapezio["Lado2"];

                // DECLARAÇÃO DE UM ARRAY:
                double[] AreaPerimetro = new double[2];

                // O PRIMEIRO VALOR (INDICE 0) DO ARRAY RECEBE O VALOR DA AREA:
                AreaPerimetro[0] = trapezio["Area"];

                // O SEGUNDO VALOR (INDICE 1) DO ARRAY RECEBE O VALOR DO PERIMETRO:
                AreaPerimetro[1] = trapezio["Perimetro"];

                return AreaPerimetro;
            }

            double[] CalcularParalelogramo (Dictionary<string, double> paralelogramo)
            {
                // CALCULA A AREA DO PARALELOGRAMO (BASE * ALTURA):
                paralelogramo["Area"] = paralelogramo["Base"] * paralelogramo["Altura"];

                // CALCULA O PERIMETRO DO PARALELOGRAMO ((BASE * 2) + (ALTURA * 2)):
                paralelogramo["Perimetro"] = (paralelogramo["Base"] * 2) + (paralelogramo["Altura"] * 2);

                // DECLARAÇÃO DE UM ARRAY:
                double[] AreaPerimetro = new double[2];

                // O PRIMERIO VALOR (INDICE 0) RECEBE O VALOR DA AREA:
                AreaPerimetro[0] = paralelogramo["Area"];

                // O SEGUNDO VALOR (INDICE 1) RECEBE O VALOR DO PERIMETRO:
                AreaPerimetro[1] = paralelogramo["Perimetro"];

                return AreaPerimetro;

            }
        }
    }
}
