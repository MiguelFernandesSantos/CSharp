//####################################################
//                                                   #
//    NOME: MIGUEL FERNANDES SANTOS.                 #
//    DATA: 25/09/2021                               #
//    PROJETO: ESTATISTICA (DIDATICO).               #
//                                                   #
//####################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estatistica
{
    class Program
    {
        static void Main(string[] args)
        {


            Dictionary<string, double[]> Valores = new Dictionary<string, double[]>() {

                {"Numeros", new double[13]{ 10, 10, 1, 45, 63, 74, 32, 67, 31, 54, 21, 56, 23 } },
                {"Pesos", new double[13]{ 1, 2, 3, 5, 6, 1, 8, 1, 2, 4, 2, 6, 3 } },
                {"Quantidade", new double[13] },
                {"Variancias", new double[13] },
                {"VarianciasQuadrada", new double[13]}
                
            };

            double[] Estatistica;
            Estatistica = calculaTudo(Valores);

            foreach (double valor in Estatistica)
            {
                Console.WriteLine(valor);
            }

            Console.Read();


            // REALIZA TODOS OS CALCULOS E RETORNA UM ARRAY:
            double[] calculaTudo(Dictionary<string, double[]> estatistica)
            {

                double[] Tudo = new double[8];

                Tudo[0] = MediaSimples(estatistica);
                Tudo[1] = MediaPonderada(estatistica);
                Tudo[2] = PrimeiroQuartil(estatistica);
                Tudo[3] = SegundoQuartil(estatistica);
                Tudo[4] = TerceiroQuartil(estatistica);
                Tudo[5] = Amplitude(estatistica);
                Tudo[6] = VarianciaSimples(estatistica);
                Tudo[7] = VarianciaQuadrada(estatistica);

                return Tudo;
            }

            // CALCULA E RETORNA A MEDIA:
            double MediaSimples(Dictionary<string, double[]> estatistica)
            {

                int tamanho = estatistica["Numeros"].Length;
                double media = 0;

                foreach (double numero in estatistica["Numeros"])
                {

                    media += numero;

                }

                media = media / tamanho;
                
                return media;
            }

            // CALCULA E RETORNA A MEDIA PONDERADA:
            double MediaPonderada(Dictionary<string, double[]> estatistica)
            {

                double somaValores = 0;
                double somaPesos = 0;
                double auxiliar = 0;
                int indice = 0;

                foreach (double numero in estatistica["Numeros"])
                {
                    
                    auxiliar = numero * estatistica["Pesos"][indice];

                    somaValores += auxiliar;
                    somaPesos += estatistica["Pesos"][indice];

                    indice += 1;

                }

                auxiliar = somaValores / somaPesos;

                return auxiliar;

            }

            // CALCULA E RETORNA O PRIMEIRO QUARTIL:
            double PrimeiroQuartil (Dictionary<string, double[]> estatistica)
            {
                Array.Sort(estatistica["Numeros"]);

                int quantidade = estatistica["Numeros"].Length;
            
                double numeroExato = quantidade / 4;

                double min = Math.Round(numeroExato, 0);
                double max = 0;

                if (min == numeroExato)
                {

                }
                else if(min > numeroExato)
                {

                    max = min;
                    min = min - 1;

                }
                else
                {

                    max = min + 1;

                }

                if (numeroExato > min && numeroExato < max)
                {

                    numeroExato = Math.Floor(numeroExato);

                }

                int indice = Convert.ToInt32(numeroExato);

                return estatistica["Numeros"][indice];

            }

            // CALCULA E RETORNA O SEGUNDO QUARTIL:
            double SegundoQuartil (Dictionary<string, double[]> estatistica) {

                double quantidade = estatistica["Numeros"].Length;
                double numeroExato = quantidade / 2;
                int indice = 0;

                double min = Math.Round(numeroExato, 0);
                double max = 0;

                if (min == numeroExato)
                {

                }else if(min > numeroExato){

                    max = min;
                    min = min - 1;

                }
                else
                {

                    max = min + 1;

                }

                if (numeroExato > min && numeroExato < max)
                {

                    numeroExato = Math.Floor(numeroExato);
                    indice = Convert.ToInt32(numeroExato);

                }

                return estatistica["Numeros"][indice];

            }

            // CALCULA E RETORNA O TERCEIRO QUARTIL:
            double TerceiroQuartil(Dictionary<string, double[]> estatistica)
            {

                Array.Sort(estatistica["Numeros"]);

                int quantidade = estatistica["Numeros"].Length;

                quantidade = quantidade * 3;

                double numeroExato = quantidade / 4;

                double min = Math.Round(numeroExato);

                double max = 0;

                if (min == numeroExato)
                {

                }
                else if (min > numeroExato)
                {
                    max = min;
                    min = min - 1;
                }
                else
                {
                    max = min + 1;
                }

                if (numeroExato > min && numeroExato < max)
                {

                    numeroExato = Math.Floor(numeroExato);

                }

                int indice = Convert.ToInt32(numeroExato);

                return estatistica["Numeros"][indice];

            }
            
            // CALCULA E RETORNA A AMPLITUDE:
            double Amplitude (Dictionary<string, double[]> estatistica)
            {

                double maior = estatistica["Numeros"].Max();
                double min = estatistica["Numeros"].Min();

                double numero = maior - min;

                return numero;

            }

            // CALCULA E RETORNA A VARIANCIA SIMPLES:
            double VarianciaSimples (Dictionary<string, double[]> estatistica)
            {

                double media = MediaSimples(Valores);
                int tamanho = estatistica["Numeros"].Length;
                int indice = 0;

                double[] variancias = new double[tamanho];


                foreach (double numero in estatistica["Numeros"])
                {
                    double valor = numero - media;
                    variancias[indice] = valor;

                    indice += 1;

                }

                double soma = variancias.Sum();

                soma = Math.Floor(soma);

                return soma;

            }
            
            // CALCULA E RETORNA A VARIANCIA QUADRADA:
            double VarianciaQuadrada(Dictionary<string, double[]> estatistica)
            {

                double media = MediaSimples(Valores);
                int tamanho = estatistica["Numeros"].Length;
                int indice = 0;

                double[] variancias = new double[tamanho];
                double[] varianciasQuadrada = new double[tamanho];



                foreach (double numero in estatistica["Numeros"])
                {
                    double valor = numero - media;
                    variancias[indice] = valor;

                    indice += 1;

                }

                indice = 0;

                foreach (double numero in variancias)
                {
                    double valor = numero * numero;
                    varianciasQuadrada[indice] = valor;

                    indice += 1;

                }

                double soma = varianciasQuadrada.Sum();

                double divisor = varianciasQuadrada.Length;
                divisor -= 1;

                double fim = soma / divisor;

                fim = Math.Sqrt(fim);

                return fim;
            }
        }
    }
}
