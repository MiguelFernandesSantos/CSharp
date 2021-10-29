using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
 
            // Função para que retorna os creditos:
            double[] SeuCredito(double Salario)
            {
 
                double[] dados = new double[3];
 
                dados[0] = ((Salario / 100) * 50) + Salario;
                dados[1] = ((Salario / 100) * 75) + Salario;
                dados[2] = ((Salario / 100) * 100) + Salario;
 
                return dados;
 
            }
 
            // Função para converter uma string:
            double converter(string value)
            {
                double retorno = 0;
 
                try
                {
 
                    retorno = Convert.ToDouble(value);
 
                }
                catch
                {
 
                    Console.WriteLine("\nO valor inserido anteriormente não é um numero!!!!!");
                    return 0;
 
                }
 
                return retorno;
 
            }
 
            string nome = "";
            double[] opcoes;
 
            Dictionary<string, double> Pessoa = new Dictionary<string, double>()
            {
 
                {"Salario", 0 },
                {"Menu", 0 },
 
            };
 

            Dictionary<string, double> Dados = new Dictionary<string, double>()
            {
 
                {"Saldo", 5000 },
                {"Credito", 0 },
                {"CreditoPagar", 0 },
                {"AuxiliarRetirar", 0 },
                {"AuxiliarCOlocar", 0 },
                {"Menu", 0 }
 
            };
 
            Console.WriteLine("---------- Cadastro Pessoal ---------");
 
            // Faz a leitura do nome:
            Console.WriteLine("Por favor, insira seu Nome: ");
            nome = Console.ReadLine();
 
            // Faz a leitura do salario:
            while (Pessoa["Salario"] <= 0) {
 
                Console.WriteLine("\n\nPor favor insira seu Salario: ");
                Pessoa["Salario"] = converter(Console.ReadLine());
 
            }
 
            // Chama a função que descobre o seu credito:
            opcoes = SeuCredito(Pessoa["Salario"]);
 
            // laço que obriga o usuario a digitar uma das opções:
            while(Pessoa["Menu"] < 1 && Pessoa["Menu"] > 3){
 
                Console.WriteLine("\nBaseado em seu salario você tem direito a creditos de: \n");
                Console.WriteLine(" 1 - " + Convert.ToString(opcoes[0]));
                Console.WriteLine(" 2 - " + Convert.ToString(opcoes[1]));
                Console.WriteLine(" 3 - " + Convert.ToString(opcoes[2]));
 
            }
 
            Console.WriteLine("Qual das opões acima você deseja?");
            Pessoa["Menu"] = converter(Console.ReadLine());
 
            if(Pessoa["Menu"] == 1)
            {
 
                Dados["Credito"] = opcoes[0];
 
            }else if (Pessoa["Menu"] == 2)
            {
 
                Dados["Credito"] = opcoes[1];
 
            }else if (Pessoa["Menu"] == 3)
            {
 
                Dados["Credito"] = opcoes[2];
 
            }
            else
            {
 
                Console.WriteLine("Opção invalida!!!");
 
            }
 
            // --- FIM DO CADASTRO DA PESSOA --- //
 
            Console.WriteLine("---------- Bem Vindo ----------");
        }
    }
}
