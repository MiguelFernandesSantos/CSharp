//####################################################
//                                                   #
//   NOME: MIGUEL FERNANDES SANTOS.                  #
//   DATA: 02/10/2021                                #
//   PROJETO: CALCULO QUE RETORNA O VOLUME(DIDATICO) #
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
            // DICIONARIO QUE CONTEM TODAS AS FORMAS:
            Dictionary<string, Dictionary<string, double>> formas = new Dictionary<string, Dictionary<string, double>>()
            {
                // DICIONARIO QUE CONTEM AS INFORMAÇÕES DO CONE:
                {"Cone", new Dictionary<string, double>()
                {

                    {"Volume", 0 },
                    {"Raio", 3 },
                    {"Altura", 8 },

                } },
                
                // DICIONARIO QUE CONTEM AS INFORMAÇÕES DA PIRAMIDE:
                {"Piramide", new Dictionary<string, double>()
                {

                    {"Volume", 0 },
                    {"Lado1", 6 },
                    {"Lado2", 4 },
                    {"Altura", 8 },
                    {"AreaBase", 0 }

                } },
                
                // DICIONARIO QUE CONTEM AS INFORMAÇÕES DA ESFERA:
                {"Esfera", new Dictionary<string, double>(){

                    {"Volume", 0 },
                    {"Raio", 6 },

                } },
                
                // DICIONARIO QUE CONTEM AS INFORMAÇÕES DO CILINDRO:
                {"Cilindro", new Dictionary<string, double>()
                {

                    {"Volume", 0 },
                    {"Raio", 4 },
                    {"Altura", 10 },

                } }


            };

            // DECLARAÇÃO DE UM DICIONARIO QUE RECEBE O RETORNO DE UMA FUNÇAO QUE É UM NOVO DICIONARIO:
            Dictionary<string, double> Retorno = Tudo(formas);


            // PARA CADA ITEM DO DICIONARIO: 
            foreach (var item in Retorno) {

                // EXIBE A CHAVE E O VOLUME DA FORMA:
                Console.WriteLine("Volume do(a) "+ item.Key + ": " + item.Value);

            }

            Console.Read();

            // UMA FUNÇÃO QUE RETORNA UM DICIONARIO E FAZ TODOS OS CALCULOS DAS FORMAS:
            Dictionary<string, double> Tudo (Dictionary<string, Dictionary<string, double>> all)
            {
                // CONJUNTO DE DECLARAÇOES DE VARIAVEIS QUE RECEBEM O VALOR RETORNADOS DAS FUNÇÕES:
                double cone = CalcularVolumeCone(all["Cone"]);
                double piramide = CalcularVolumePiramide(all["Piramide"]);
                double esfera = CalcularVolumeEsfera(all["Esfera"]);
                double cilindro = CalcularVolumeCilindro(all["Cilindro"]);

                // DICIONARIO A SER RETORNADO CONTENDO OS VALORES DO VOLUME:
                Dictionary<string, double> calculo = new Dictionary<string, double>()
                {

                    {"Cone", cone },
                    {"Piramide", piramide },
                    {"Esfera", esfera },
                    {"Cilindro", cilindro },

                };

                return calculo;
            }

            double CalcularVolumeCone (Dictionary<string, double> cone)
            {
                // CALCULA O VALOR DO RAIO AO QUADRADO DO CONE:
                cone["Raio"] = Math.Pow(cone["Raio"], 2);

                // CALCULA O VALOR DO VOLUME DO CONE ((RAIO * ALTURA) / 3):
                cone["Volume"] = (cone["Raio"] * cone["Altura"]) / 3;
                
                return cone["Volume"];

            }

            double CalcularVolumePiramide (Dictionary<string, double> piramide)
            {
                // CALCULA A AREA DA BASE DA PIRAMIDE (LADO1 * LADO2):
                piramide["AreaBase"] = piramide["Lado1"] * piramide["Lado2"];

                // CALCULA O VOLUME DA PIRAMIDE ((AREA BASE * ALTUA) / 3):
                piramide["Volume"] = (piramide["AreaBase"] * piramide["Altura"]) / 3;

                return piramide["Volume"];

            }

            double CalcularVolumeEsfera (Dictionary<string, double> esfera)
            {
                // CALCULA O VALOR DO RAIO³:
                esfera["Raio"] = Math.Pow(esfera["Raio"], 3);

                // CALCULA O VALOR DO RAIO / 3:
                esfera["Raio"] = esfera["Raio"] / 3;

                // CALCULA O VOLUME DO RAIO (RAIO * 4):
                esfera["Volume"] = esfera["Raio"] * 4;

                return esfera["Volume"];
            }

            double CalcularVolumeCilindro (Dictionary<string, double> cilindro)
            {
                // CALCULA O QUADRADO DO RAIO DO CILINDRO:
                cilindro["Raio"] = Math.Pow(cilindro["Raio"], 2);

                // CALCULA O VOLUME DO CILINDRO (RAIO * ALTURA):
                cilindro["Volume"] = cilindro["Raio"] * cilindro["Altura"];

                return cilindro["Volume"];

            }

        }
    }
}
