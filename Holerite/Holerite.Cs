//####################################################
//                                                   #
//    NOME: MIGUEL FERNANDES SANTOS.                 #
//    DATA: 19/09/2021                               #
//    PROJETO: CALCULO DE HOLERITE (DIDATICO).       #
//                                                   #
//####################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        class Funcionario
        {

            public Dictionary <string, double> Info{ get; set; }
            public Dictionary <string, double> MesTrabalhado { get; set; }
            public Dictionary <string, double> Calculo { get; set; }

        }

        class Impostos
        {

            public Dictionary<string, Dictionary<string, double>> INSS { get; set; }
            public Dictionary<string, Dictionary<string, double>> IRRF { get; set; }
            public Dictionary<string, double> Base_Calculo { get; set; }
            public double FGTS { get; set; }

        }

        static void Main(string[] args)
        {

            Funcionario funcionario = new Funcionario();

            funcionario.Info = new Dictionary<string, double> {

                             {"Salario",  5000 },
                             {"HoraExtra", 75 },
                             {"Dependentes", 1 },
                             {"Insalubridade", 0 },
                             {"Periculosidade", 0 },
                             {"ValeTransporte", 6 }

                        };

            funcionario.MesTrabalhado = new Dictionary<string, double> {

                            {"QtsHrsEx", 5},
                            {"QtsFaltas", 2},
                            {"QtsAtrasos", 1},

                        };

            funcionario.Calculo = new Dictionary<string, double> {

                            {"SalarioDia", 0 },
                            {"SalarioHora" , 0 },
                            {"HrExtra" , 0},
                            {"DsrHrExtra" , 0},
                            {"ValorInsalubridade" , 0 },
                            {"ValorPericulosidade" , 0 },
                            {"Falta" , 0 },
                            {"DsrFalta" , 0 },
                            {"ValorVt" , 0 },
                            {"Atraso ", 0 },
                            {"ValorDependente" , 0 },
                            {"INSS" , 0 },
                            {"FGTS" , 0 },
                            {"IRRF" , 0 },
                            {"SalarioLiquido" , 0 },
                        };

            Impostos imposto = new Impostos();

            imposto.INSS = new Dictionary<string, Dictionary<string, double>>{

                            {"FaixaInss", new Dictionary <string, double>(){

                                    {"Faixa1.1", 1100.00},
                                    {"Faixa2.1", 1100.01},
                                    {"Faixa2.2", 2203.48},
                                    {"Faixa3.1", 2203.49},
                                    {"Faixa3.2", 3305.22},
                                    {"Faixa4.1", 3305.23},
                                    {"Faixa4.2", 6433.57},
                                    {"Teto", 6433.27},

                            }},

                            {"Porcentagem", new Dictionary<string, double>(){

                                    {"Faixa1", 7.5},
                                    {"Faixa2", 9.0},
                                    {"Faixa3", 12},
                                    {"Faixa4", 14},
                                    {"Valor_Teto", 751.97},

                            }},

                            {"Deduzir", new Dictionary<string, double>(){

                                    {"Faixa1", 0},
                                    {"Faixa2", 16.50},
                                    {"Faixa3", 82.604},
                                    {"Faixa4", 148.708},

                            } }
                        };

            imposto.IRRF = new Dictionary<string, Dictionary<string, double>> {

                            {"Faixa_IRRF", new Dictionary<string, double>(){


                                    {"Faixa1.1", 1903.98},
                                    {"Faixa2.1", 1903.99},
                                    {"Faixa2.2", 2826.65},
                                    {"Faixa3.1", 2826.66},
                                    {"Faixa3.2", 3751.05},
                                    {"Faixa4.1", 3751.06},
                                    {"Faixa4.2", 4664.68},
                                    {"Teto", 4664.68},


                            }},

                            {"Porcentagem", new Dictionary<string, double>(){

                                    {"Faixa1", 0},
                                    {"Faixa2", 7.5},
                                    {"Faixa3", 15},
                                    {"Faixa4", 22.5},
                                    {"Valor_Teto", 27.5},


                            }},

                            {"Deduzir", new Dictionary<string, double>(){

                                    {"Faixa1", 0},
                                    {"Faixa2", 142.80},
                                    {"Faixa3", 354.80},
                                    {"Faixa4", 636.13},
                                    {"Faixa5", 869.36},

                            }},

                };

            imposto.Base_Calculo = new Dictionary<string, double> {
                                                                        { "Base_INSS", 0 },
                                                                        { "Base_IRRF", 0 },
                                                                   };

            imposto.FGTS = 8;

            // SALARIO DIA:
            funcionario.Calculo["SalarioDia"] = funcionario.Info["Salario"] / 30;
            funcionario.Calculo["SalarioDia"] = Math.Round(funcionario.Calculo["SalarioDia"], 2);

            // SALARIO HORA:
            funcionario.Calculo["SalarioHora"] = funcionario.Info["Salario"] / 220;
            funcionario.Calculo["SalarioHora"] = Math.Round(funcionario.Calculo["SalarioHora"], 2);

            // HORA EXTRA:
            funcionario.Calculo["HrExtra"] = (((funcionario.Calculo["SalarioHora"] / 100) * funcionario.Info["HoraExtra"]) + funcionario.Calculo["SalarioHora"]) * funcionario.MesTrabalhado["QtsHrsEx"] ;
            funcionario.Calculo["HrExtra"] = Math.Round(funcionario.Calculo["HrExtra"], 2);

            // DSR HORA EXTRA:
            funcionario.Calculo["DsrHrExtra"] = (funcionario.Calculo["HrExtra"] / 26) * 4;
            funcionario.Calculo["DsrHrExtra"] = Math.Round(funcionario.Calculo["DsrHrExtra"],2);

            // INSALUBRIDADE:
            funcionario.Calculo["ValorInsalubridade"] = (1100 / 100)* funcionario.Info["Insalubridade"];
            funcionario.Calculo["ValorInsalubridade"] = Math.Round(funcionario.Calculo["ValorInsalubridade"], 2);

            // PERICULOSIDADE:
            funcionario.Calculo["ValorPericulosidade"] = (funcionario.Info["Salario"] /100) * funcionario.Info["Periculosidade"];
            funcionario.Calculo["ValorPericulosidade"] = Math.Round(funcionario.Calculo["ValorPericulosidade"],2);

            // VALE TRANSPORTE:
            funcionario.Calculo["ValorVt"] = (funcionario.Info["Salario"] / 100) * funcionario.Info["ValeTransporte"];
            funcionario.Calculo["ValorVt"] = Math.Round(funcionario.Calculo["ValorVt"], 2);

            // FALTA:
            funcionario.Calculo["Falta"] = funcionario.Calculo["SalarioDia"] * funcionario.MesTrabalhado["QtsFaltas"];
            funcionario.Calculo["Falta"] = Math.Round(funcionario.Calculo["Falta"],2);

            // DSR FALTA:
            funcionario.Calculo["DsrFalta"] = funcionario.Calculo["Falta"];

            // ATRASO:
            funcionario.Calculo["Atraso"] = funcionario.Calculo["SalarioHora"] * funcionario.MesTrabalhado["QtsAtrasos"];
            funcionario.Calculo["Atraso"] = Math.Round(funcionario.Calculo["Atraso"], 2);

            // DEPENDENTES:
            funcionario.Calculo["ValorDependente"] = funcionario.Info["Dependentes"] * 189.59;
            funcionario.Calculo["ValorDependente"] = Math.Round(funcionario.Calculo["ValorDependente"], 2);

            // BASE INSS:
            imposto.Base_Calculo["BaseINSS"] = funcionario.Info["Salario"] +
                                               funcionario.Calculo["ValorInsalubridade"] +
                                               funcionario.Calculo["ValorPericulosidade"] +
                                               funcionario.Calculo["HrExtra"] +
                                               funcionario.Calculo["DsrHrExtra"] -
                                               funcionario.Calculo["Falta"] -
                                               funcionario.Calculo["DsrFalta"] -
                                               funcionario.Calculo["Atraso"];

            // ARREDONDA O VALOR DA BASE DO INSS:
            imposto.Base_Calculo["BaseINSS"] = Math.Round(imposto.Base_Calculo["BaseINSS"], 2);

            // CHAMA A FUNÇÃO PARA CALCULAR O INSS:
            funcionario.Calculo["INSS"] = CalcularInss(imposto.INSS, imposto.Base_Calculo["BaseINSS"]);

            // FGTS:
            funcionario.Calculo["FGTS"] = (imposto.Base_Calculo["BaseINSS"] / 100) * imposto.FGTS;
            funcionario.Calculo["FGTS"] = Math.Round(funcionario.Calculo["FGTS"], 2); 

            // BASE IRRF:
            imposto.Base_Calculo["BaseIRRF"] = imposto.Base_Calculo["BaseINSS"] - 
                                               funcionario.Calculo["INSS"] -
                                               funcionario.Calculo["ValorDependente"];

            // ARREDONDA O VALOR DA BASE DO IRRF
            imposto.Base_Calculo["BaseIRRF"] = Math.Round(imposto.Base_Calculo["BaseIRRF"], 2);

            // CHAMA A FUNÇÃO PARA CALCULAR O IRRF:
            funcionario.Calculo["IRRF"] = CalcularIrrf(imposto.IRRF, imposto.Base_Calculo["BaseIRRF"]);

            // SALARIO LIQUIDO:
            funcionario.Calculo["SalarioLiquido"] = funcionario.Info["Salario"] +
                                                    funcionario.Calculo["HrExtra"] +
                                                    funcionario.Calculo["DsrHrExtra"] +
                                                    funcionario.Calculo["ValorInsalubridade"] +
                                                    funcionario.Calculo["ValorPericulosidade"] -
                                                    funcionario.Calculo["ValorVt"] -
                                                    funcionario.Calculo["Falta"] -
                                                    funcionario.Calculo["DsrFalta"] -
                                                    funcionario.Calculo["Atraso"] -
                                                    funcionario.Calculo["INSS"] -
                                                    funcionario.Calculo["IRRF"];

            // ARREDONDAR O SALARIO LIQUIDO:
            funcionario.Calculo["SalarioLiquido"] = Math.Round(funcionario.Calculo["SalarioLiquido"], 2);

            foreach (var Att in funcionario.Calculo)
            {

                Console.WriteLine(Att);

            }

            Console.Read();


            // FUNÇÃO QUE RETORNA O VALOR DO INSS:
            double CalcularInss(Dictionary<string, Dictionary<string, double>> Imposto, double BaseINSS)
            {


                if (BaseINSS < Imposto["FaixaInss"]["Faixa1.1"])
                {

                    // PRIMEIRA FAIXA DO INSS:
                    BaseINSS = (BaseINSS / 100) * Imposto["Porcentagem"]["Faixa1"];
                    BaseINSS = BaseINSS - Imposto["Deduzir"]["Faixa1"];

                }
                else if (BaseINSS > Imposto["FaixaInss"]["Faixa2.1"] && BaseINSS < Imposto["FaixaInss"]["Faixa2.2"])
                {

                    // SEGUNDA FAIXA DO INSS:
                    BaseINSS = (BaseINSS / 100) * Imposto["Porcentagem"]["Faixa2"];
                    BaseINSS = BaseINSS - Imposto["Deduzir"]["Faixa2"];

                }
                else if (BaseINSS > Imposto["FaixaInss"]["Faixa3.1"] && BaseINSS < Imposto["FaixaInss"]["Faixa3.2"])
                {

                    // TERCEIRA FAIXA DO INSS:
                    BaseINSS = (BaseINSS / 100) * Imposto["Porcentagem"]["Faixa3"];
                    BaseINSS = BaseINSS - Imposto["Deduzir"]["Faixa3"];

                }
                else if (BaseINSS > Imposto["FaixaInss"]["Faixa4.1"] && BaseINSS < Imposto["FaixaInss"]["Faixa4.2"])
                {

                    // QUARTA FAIXA DO INSS:
                    BaseINSS = (BaseINSS / 100) * Imposto["Porcentagem"]["Faixa4"];
                    BaseINSS = BaseINSS - Imposto["Deduzir"]["Faixa4"];

                }
                else
                {

                    // TETO DO INSS:
                    BaseINSS = Imposto["Porcentagem"]["Valor_Teto"];

                }

                BaseINSS = Math.Round(BaseINSS, 2);

                return BaseINSS;

            }



            // FUNÇÃO QUE RETORNA O VALOR DO IRRF:
            double CalcularIrrf(Dictionary<string, Dictionary<string, double>> Imposto, double BaseIrrf)
            {

                if (BaseIrrf < Imposto["Faixa_IRRF"]["Faixa1.1"])
                {

                    // ISENTO DO IRRF:
                    BaseIrrf = 0;

                }
                else if (BaseIrrf > Imposto["Faixa_IRRF"]["Faixa2.1"] && BaseIrrf < Imposto["Faixa_IRRF"]["Faixa2.2"])
                {

                    // PRIMEIRA FAIXA DO IRRF:
                    BaseIrrf = (BaseIrrf / 100) * Imposto["Porcentagem"]["Faixa2"];
                    BaseIrrf = BaseIrrf - Imposto["Deduzir"]["Faixa2"];

                }
                else if (BaseIrrf > Imposto["Faixa_IRRF"]["Faixa3.1"] && BaseIrrf < Imposto["Faixa_IRRF"]["Faixa3.2"])
                {

                    // SEGUNDA FAIXA DO IRRF:
                    BaseIrrf = (BaseIrrf / 100) * Imposto["Porcentagem"]["Faixa3"];
                    BaseIrrf = BaseIrrf - Imposto["Deduzir"]["Faixa3"];

                }
                else if (BaseIrrf > Imposto["Faixa_IRRF"]["Faixa4.1"] && BaseIrrf < Imposto["Faixa_IRRF"]["Faixa4.2"])
                {

                    // TERCEIRA FAIXA DO IRRF:
                    BaseIrrf = (BaseIrrf / 100) * Imposto["Porcentagem"]["Faixa4"];
                    BaseIrrf = BaseIrrf - Imposto["Deduzir"]["Faixa4"];

                }
                else
                {

                    // QUARTA FAIXA DO IRRF:
                    BaseIrrf = (BaseIrrf / 100) * Imposto["Porcentagem"]["Faixa5"];
                    BaseIrrf = BaseIrrf - Imposto["Deduzir"]["Faixa5"];

                }

                BaseIrrf = Math.Round(BaseIrrf, 2);

                return BaseIrrf;

            }
        }
    }
}
