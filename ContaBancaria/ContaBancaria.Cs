//####################################################
//                                                   #
//    NOME: MIGUEL FERNANDES SANTOS.                 #
//    DATA: 17/11/2021                               #
//    PROJETO: CONTA BANCARIA.                       #
//                                                   #
//####################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;


namespace ContaBancaria
{

    // Classe para utilizar o banco de dados:
    class BancoDados
    {

        // Cria uma conexao global na classe:
        public SQLiteConnection conexao;

        // Cria o metodo construtor da classe:
        public BancoDados()
        {

            // Faz a conexão:
            conexao = new SQLiteConnection("Data Source = Estatistica.Sqlite3");

            // Verifica se ja existe criado um arquivo com o nome estatistica:
            if (!File.Exists("./Estatistica.sqlite3"))
            {
                // Se não existir ele cria o arquivo:
                SQLiteConnection.CreateFile("Estatistica.sqlite3");

            }

        }

        // Metodo para abrir a conexao com o banco de dados:
        public void AbrirConexao()
        {
            // Se a conexao estiver diferente de aberta ele faz a abertura da conexao:
            if (conexao.State != System.Data.ConnectionState.Open)
            {
                // Abre a conexao:
                conexao.Open();

            }
        }

        public void FecharConexao()
        {
            // Se a conexao estiver diferente de Fechada ele faz o fechamento da conexao:
            if (conexao.State != System.Data.ConnectionState.Closed)
            {
                // Fechamento da conexao:
                conexao.Close();

            }

        }

    }

    class Program
    {


        static void Main(string[] args)
        {
            // Cria um objeto do tipo Banco de dados:
            BancoDados BancoObjeto = new BancoDados();

            // Cria uma função  para criar uma nova tabela no banco de dados:
           void NovaTabela()
            {
                // Cria uma string para ser execultada pelo banco:
               string CriarTabela = "Create table if not exists Tb_Estatistica" +
                                     "(Tb_Estatistica_Id integer not null primary key autoincrement," +
                                     "Tb_Estatistica_Media decimal(10, 5)," +
                                     "Tb_Estatistica_Moda decimal(10, 5)," +
                                     "Tb_Estatistica_Mediana decimal(10, 5)," +
                                     "Tb_Estatistica_PrimeiroQuartil decimal(10, 5)," +
                                     "Tb_Estatistica_TerceiroQuartil decimal(10, 5)," +
                                     "Tb_Estatistica_Amplitude decimal(10, 5)," +
                                     "Tb_Estatistica_DesvioPadrao decimal(10,5))";

               string DeletarValores = "Delete from Tb_Estatistica";

               // Cria uma query do tipo SQLiteCommand usando a conexao do objeto banco e a string:
               SQLiteCommand QueryCriarTabela = new SQLiteCommand(CriarTabela, BancoObjeto.conexao);

               // Cria uma query do tipo SQLiteCommand usando a conexao do objeto banco e a string deletar:
               SQLiteCommand QueryDeletar = new SQLiteCommand(DeletarValores, BancoObjeto.conexao);

               // Abre a conexao com o banco de dados:
               BancoObjeto.AbrirConexao();

               // Execulta a query:
                QueryCriarTabela.ExecuteNonQuery();
                // Execulta a query para limpar a tabela:
                QueryDeletar.ExecuteNonQuery();
                // Fecha a conexao:
                BancoObjeto.FecharConexao();

            }

            void Inserirbanco(List<double> valores)
            {
                // cria um vetor que vai receber o retorno da funçao tudo:
                double[] dados = Tudo(valores);

                // Cria uma variavel que recebe um comando SQL:
                string Inserir = "insert into Tb_Estatistica" +
                                      "(Tb_Estatistica_Media, Tb_Estatistica_Moda," +
                                      "Tb_Estatistica_Mediana, Tb_Estatistica_PrimeiroQuartil," +
                                      "Tb_Estatistica_TerceiroQuartil, Tb_Estatistica_Amplitude," +
                                      "Tb_Estatistica_DesvioPadrao)" +
                                      "values (@media, @primeiroQuartil, @segundoQuartil, @terceiroQuartil , @amplitude, @varianciaSimples, @varianciaQuadrada)";

                // Cria um comando em sql utilizando o variavel inserir e a conexao do objeto banco:
                SQLiteCommand QueryInserir = new SQLiteCommand(Inserir, BancoObjeto.conexao);

                // Modifica os parametros (@) por valores dentro do vetor:
                QueryInserir.Parameters.AddWithValue("@media", dados[0]);
                QueryInserir.Parameters.AddWithValue("@primeiroQuartil", dados[1]);
                QueryInserir.Parameters.AddWithValue("@segundoQuartil", dados[2]);
                QueryInserir.Parameters.AddWithValue("@terceiroQuartil", dados[3]);
                QueryInserir.Parameters.AddWithValue("@amplitude", dados[4]);
                QueryInserir.Parameters.AddWithValue("@varianciaSimples", dados[5]);
                QueryInserir.Parameters.AddWithValue("@varianciaQuadrada", dados[6]);

                BancoObjeto.AbrirConexao();
                QueryInserir.ExecuteNonQuery();
                BancoObjeto.FecharConexao();

            }

            // Função para exibir o banco de dados:
            void ExibirBanco()
            {
                // Cria uma tabela para receber os dados do banco:
                SQLiteDataAdapter da = null;
                DataTable Tabela = new DataTable();

                // Uma query para utilizar no banco de dados:
                string selecionar = "select * from Tb_Estatistica";

                // Cria um comando interpletavel pelo sqlite: 
                SQLiteCommand QuerySelecionar = new SQLiteCommand(selecionar, BancoObjeto.conexao);

                // Abre a conexao com o banco de dados:
                BancoObjeto.AbrirConexao();

                // Executa a query para selecionar os valores da tabela:
                // QuerySelecionar.ExecuteNonQuery();

                da = new SQLiteDataAdapter(selecionar, BancoObjeto.conexao);

                da.Fill(Tabela);

                // Fecha a conexao com o banco de dados:
                BancoObjeto.FecharConexao();

                foreach (DataRow linha in Tabela.Rows)
                {
                    string mostrar;
                    mostrar = string.Format("Media: {0} | 1Q: {1} | 2Q: {2} | 3Q: {3} | Amplitude: {4} | VarSimples: {5} | VarQuadrada: {6}", linha[1], linha[2], linha[3], linha[4], linha[5], linha[6], linha[7]);
                    Console.WriteLine(mostrar);

                }

            }

            // CALCULA E RETORNA A MEDIA:
            double MediaSimples(List<double> estatistica)
            {
                // conta quantos elementos tem dentro da lista:
                int tamanho = estatistica.Count;

                // Declara a variavel media que se inicia com 0:
                double media = 0;

                // Faz um laço de repetição para percorrer cada um dos elementos da lista:
                foreach (double numero in estatistica)
                {
                    // Adiciona na variavel media o numero atual da lista:
                    media += numero;

                }

                // Faz o valor da soma dos numeros dividido pelo tamanho:
                media = media / tamanho;

                // Retorna a media:
                return media;
            }


            // CALCULA E RETORNA O PRIMEIRO QUARTIL:
            double PrimeiroQuartil(List<double> estatistica)
            {

                // Organiza em ordem crescente a lista:
                estatistica.Sort();

                // Declara a variavel indice:
                int indice;

                // Conta quantos elementos tem a lista:
                int quantidade = estatistica.Count;

                // descobre o indice do numero a ser retornado:
                double numeroExato = quantidade / 4;

                // Coloca na variavel min o valor do numero exato:
                double min = Math.Round(numeroExato, 0);

                // Declara a variavel max iniciando em 0:
                double max = 0;

                // se min ser maior que o numero exato:
                if (min > numeroExato)
                {
                    // Max recebe o valor de min:
                    max = min;

                    // Min recebe o valor de min - 1:
                    min = min - 1;

                }
                else // Se não:
                {
                    // max recebe min + 1:
                    max = min + 1;

                }

                // Se o numero exato ser maior que min e menor que max:
                if (numeroExato > min && numeroExato < max)
                {
                    // Arredonda a variavel numeroExato:
                    numeroExato = Math.Floor(numeroExato);

                }

                // converte o numero exato para inteiro e coloca dentro da variavel indice:
                indice = Convert.ToInt32(numeroExato);

                // retorna o numero baseado no indice:
                return estatistica[indice];

            }


            // CALCULA E RETORNA O SEGUNDO QUARTIL:
            double SegundoQuartil(List<double> estatistica)
            {
                // Organiza em ordem crescente a lista:
                estatistica.Sort();

                // Conta quantos numeros tem dentro da lista:
                double quantidade = estatistica.Count;

                // Faz a quantidade dividido por dois:
                double numeroExato = quantidade / 2;

                // Declara a variavel indice com inicio 0:
                int indice = 0;

                // min recebe o valor arredondado de numero exato:
                double min = Math.Round(numeroExato, 0);

                // max inicia com 0:
                double max = 0;

                // Se min ser maior que o numero exato:
                if (min > numeroExato)
                {
                    // max recebe min:
                    max = min;
                    // Min recebe max - 1:
                    min = min - 1;

                }
                else
                {
                    // se nao max recebe min + 1:
                    max = min + 1;

                }

                // Se o numero exato ser maior que min e menor que max:
                if (numeroExato > min && numeroExato < max)
                {
                    // numero exato recebe o inteiro mais proximo:
                    numeroExato = Math.Floor(numeroExato);

                }

                // A variavel indice recebe o valor do numero exato convertido para inteiro:
                indice = Convert.ToInt32(numeroExato);

                // retorna o numero exato:
                return estatistica[indice];

            }

            // CALCULA E RETORNA O TERCEIRO QUARTIL:
            double TerceiroQuartil(List<double> estatistica)
            {
                // Organiza de forma crescente os valroes da lista:
                estatistica.Sort();

                // Conta quantos valores tem dentro da lista:
                int quantidade = estatistica.Count;

                // Quantidade recebe quantidade vezes 3:
                quantidade = quantidade * 3;

                // Numero exato recebe a quantidade dividido por 4:
                double numeroExato = quantidade / 4;

                // Faz o arredondamento da variavel numero exato:
                double min = Math.Round(numeroExato);

                // Max é declarado e se inicia com 0: 
                double max = 0;

                // Se o min ser maior que o numero exato:
                if (min > numeroExato)
                {
                    // Max recebe min:
                    max = min;

                    // min recebe min menos 1:
                    min = min - 1;
                }
                else // se nao:
                {
                    // max recebe min mais 1:
                    max = min + 1;
                }

                // Se o numero exato ser maior que min e menor que max:
                if (numeroExato > min && numeroExato < max)
                {
                    // numero exato recebe o inteiro mais proximo:
                    numeroExato = Math.Floor(numeroExato);

                }

                // Converte o numeroexato para um inteiro e adiciona na variavel indice:
                int indice = Convert.ToInt32(numeroExato);

                // Retorna o numero Exato:
                return estatistica[indice];

            }

            // CALCULA E RETORNA A AMPLITUDE:
            double Amplitude(List<double> estatistica)
            {
                // maior recebe o maior numero da lista:
                double maior = estatistica.Max();

                // Menor recebe o menor numero da lista:
                double min = estatistica.Min();

                // calcula a diferenã do maior para o menor:
                double numero = maior - min;

                // retorna o numero:
                return numero;

            }

            // CALCULA E RETORNA A VARIANCIA SIMPLES:
            double VarianciaSimples(List<double> estatistica)
            {
                // Declara a variavel soma:
                double soma;

                // declara a variavel media e chama a função para calcular a media:
                double media = MediaSimples(estatistica);

                // conta quantos valores tem dentro da lista:
                int tamanho = estatistica.Count;

                // Declara a variavel indice que se inicia com 0:
                int indice = 0;

                // cria um array do tipo double que tem o mesmo tamanho da lista:
                double[] variancias = new double[tamanho];

                // faz um laço para percorre a lista:
                foreach (double numero in estatistica)
                {
                    // o numero atual menos a media:
                    double valor = numero - media;

                    // Adiciona no array o valor calculado:
                    variancias[indice] = valor;

                    // Indice recebe ele mesmo mais 1:
                    indice += 1;

                }

                // Soma recebe a soma do array:
                soma = variancias.Sum();

                // arredonda o valor da soma:
                soma = Math.Floor(soma);

                // Retorna soma:
                return soma;

            }

            // CALCULA E RETORNA A VARIANCIA QUADRADA:
            double VarianciaQuadrada(List<double> estatistica)
            {
                // Declara a variavel soma:
                double soma;

                // DeClara a variavel divisor:
                double divisor;

                double fim;

                // Declara a variavel media e chama a função que calcula a media:
                double media = MediaSimples(estatistica);

                // Conta quantos valores existe dentro da lista:
                int tamanho = estatistica.Count;

                // Declara indice que se incia com 0:
                int indice = 0;

                // Declara um array do tipo double que possui o mesmo tamanho da lista:
                double[] variancias = new double[tamanho];

                // Declara um array do tipo double que possui o mesmo tamanho da lista:
                double[] varianciasQuadrada = new double[tamanho];

                // Percorre cada elemento da lista:
                foreach (double numero in estatistica)
                {
                    // Para cada numero faz o numero menos a media:
                    double valor = numero - media;

                    // Adiciona no array o valor calculado:
                    variancias[indice] = valor;

                    // Indice recebe indice mais 1:
                    indice += 1;

                }

                // Indice se inicia com -:
                indice = 0;

                // Faz um laço que percorre cada uma das variancias:
                foreach (double numero in variancias)
                {
                    // Para cada numero faz ele vezes ele mesmo?
                    double valor = numero * numero;

                    // O segundo array recebe o valor calculado:
                    varianciasQuadrada[indice] = valor;

                    // Indice recebe indice mais 1:
                    indice += 1;

                }

                // Soma recebe a soma das variancias ao quadrado:
                soma = varianciasQuadrada.Sum();

                // Divisor recebe o tamanho do array:
                divisor = varianciasQuadrada.Length;

                // Divisor recebe ele mesmo menos 1:
                divisor -= 1;

                // Fim recebe a soma dividido pelo divisor?
                fim = soma / divisor;

                // Faz a raiz quadrada do valor contido em Fim:
                fim = Math.Sqrt(fim);

                // Retorna fim:
                return fim;
            }


            double[] Tudo(List<Double> estatistica)
            {
                // Declara um vetor de 7 posiçoes:
                double[] dados = new Double[7];

                // Cada uma das posiçoes recebe um valor estatistico:
                dados[0] = MediaSimples(estatistica);
                dados[1] = PrimeiroQuartil(estatistica);
                dados[2] = SegundoQuartil(estatistica);
                dados[3] = TerceiroQuartil(estatistica);
                dados[4] = Amplitude(estatistica);
                dados[5] = VarianciaSimples(estatistica);
                dados[6] = VarianciaQuadrada(estatistica);

                Console.WriteLine(dados[1]);
                // retorna o vetor:
                return dados;

            }

            // função para adicionar valor a sua conta:
            double Adicionar(double valor, double saldo)
            {

                //  adiciona saldo:
                saldo = saldo + valor;

                return saldo;

            }

            // função para retornar o valor do credito que vc possue direito:
            double[] SeuCredito(double Salario)
            {

                // Cria um vetor com 3 valores:
                double[] dados = new double[3];

                // Credito de 50% a mais:
                dados[0] = ((Salario / 100) * 50) + Salario;

                // Credito de 75% a mais:
                dados[1] = ((Salario / 100) * 75) + Salario;

                // Credito de 100% a mais:
                dados[2] = ((Salario / 100) * 100) + Salario;

                return dados;

            }

            // função para pedir credito:
            double[] Credito(double valor, double credito, double saldo, double divida)
            {

                // Cria uma lista com 3 valores:
                double[] dados = new double[3];

                // Se seu credito for menor que o valor que vc deseja retirar:
                if (valor > credito)
                {
                    // Mostra para o usuario que o valor é menor que o necessario:
                    Console.WriteLine("\nInfelizmente seu credito é menor que o necessario!!!");

                    // Retorna dados:
                    return dados;

                }

                // Indice 0 é o saldo atual + o credito:
                dados[0] = valor;
                // indice 1 é o valor de credito que tem que pagar:
                dados[1] = divida + valor;
                // indice 2 é o valor de credito que vc ainda possui:
                dados[2] = credito - valor;

                // Retorna dados:
                return dados;

            }

            // função para descobrir se o que foi digitado é um numero:
            double converter(string value)
            {
                // declara a variavel retorno:
                double retorno = 0;

                // Vai tentar converter o valor passado para float:
                try
                {

                    retorno = Convert.ToDouble(value);

                }
                catch // se nao der certo retorna 0:
                {
                    // Mostra para o usuario que o valor inserido nao é um numero:
                    Console.WriteLine("\nO valor inserido anteriormente não é um numero!!!!!");

                    // Retorna 0:
                    return 0;

                }

                // Retorna o valor convertido:
                return retorno;

            }

            // função para retirar o dinheiro:
            double Retirar(double valor, double saldo)
            {

                // Se o saldo for menor que o valor a retirar:
                if (saldo < valor)
                {
                    // Mostra para o usuario que o valor que deseja retirar é maior que o saldo:
                    Console.WriteLine("Infelizmente o valor que deseja retirar é maior que o seu saldo atual.");

                    // Retorna o saldo:
                    return saldo;

                }
                else // Se nao:
                {
                    // saldo recebe saldo menos o valor:
                    saldo = saldo - valor;

                }

                // retorna saldo:
                return saldo;

            }

            // Adiciona no historico de transaçoes:
            string Historico(string palavra, double valor)
            {

                // Pega a data Atual:
                string data = DateTime.Now.ToString("dd-MM-yyyy");
                //  Declara a variavel frase:
                string frase = "";

                // A variavel frase recebe a data mais o tipo de movimento mais o valor:
                frase = data + " - Foi " + palavra + " um valor de " + Convert.ToString(valor);

                // Retorna a frase:
                return frase;

            }

            double PagarCredito(double Saldo, double CreditoPagar)
            {
                // Declara a variavel opçao que se inicia com 0:
                double Opcao = 0;

                // Declara a variavel Pagar que se inicia com 0:
                double Pagar = 0;

                // Se o credito a pagar ser menor ou igual a 0
                if (CreditoPagar <= 0)
                {
                    // Mostra para o usuario que nao possui creditos a pagar:
                    Console.WriteLine("Você nao possui credito a pagar.\n\n");

                    // retorna 0:
                    return 0;

                }
                else // se nao;
                {
                    // Mostra para o usuario o valor que vc tem a pagar:
                    Console.WriteLine("\nO seu credito a pagar é de " + Convert.ToString(CreditoPagar));

                    // Pagar recebe o valor que o usuario deseja pagar e chama a função que o converte para double:
                    Pagar = converter(Console.ReadLine());

                    // Se pagar ser igual a 0 ou o usuario ter digitado letras:
                    if (Pagar == 0)
                    {
                        // Mostra para o usuario que foi inserido um valor invalido:
                        Console.WriteLine("Infelizmente o valor é invalido ou igual a 0, tente novamente mais tarde!");

                        // retorna 0:
                        return 0;

                    }
                    else if (Pagar > Saldo) // Se pagar ser maior que o saldo atual:
                    {
                        // Mostra para o usuario que o saldo atual é insuficiente:
                        Console.WriteLine("Nao possui saldo suficiente para realizar esse pagamento, tente novamente mais tarde!!");

                        // retorna 0:
                        return 0;

                    }
                    else if (Pagar > CreditoPagar) // se pagar ser maior que o credito a pagar:
                    {

                        // Faz um laço de repetição que obriga o usuario a escolher uma das 2 opçoes:
                        while (Opcao != 1 || Opcao != 2)
                        {

                            // Mostra que o valor que o usuario deseja pagar é maior que o necessario:
                            Console.WriteLine("O valor que deseja pagar é maior que " + Convert.ToString(CreditoPagar));

                            // Pergunta para o usuario se deseja pagar o valor total:
                            Console.WriteLine("Deseja pagar o valor total?\n 1 - Sim\n 2 - Não");

                            // faz a leitura do console e converte para double:
                            Opcao = converter(Console.ReadLine());

                            if (Opcao == 1) // Se for igual a 1:
                            {
                                // Pagar recebe creditoPagar:
                                Pagar = CreditoPagar;

                                // Mostra para o usuario que foi pago o valor total da divida:
                                Console.WriteLine("Okay, foi pago o valor total!");

                                // Return pagar:
                                return Pagar;

                            }
                            else if (Opcao == 2) // Se for igual a 2:
                            {
                                // Mostra para o usuario que não ira ser pago:
                                Console.WriteLine("Okay, não foi realizado o pagamento do credito");

                            }
                            else // Se nao:
                            {
                                // Mostra que a opção é invalida:
                                Console.WriteLine("Opção invalida!!!!\n\n");

                            }

                        }

                    }
                    else // Se nao:
                    {
                        // Mostra para o usuario que foi pago um valor de:
                        Console.WriteLine("Foi pago um valor total de " + Convert.ToString(Pagar));

                        // retorna pagar:
                        return Pagar;

                    }

                }

                // retorna 0:
                return 0.0;

            }

            // função para gerar arquivo txt do extrato na mesma pasta que o arquivo:
            void Extrato(Dictionary<string, double> valores, string Nome, List<string> extrato)
            {

                // Pega a data atual:
                string data = DateTime.Now.ToString("dd-MM-yyyy");

                // Pega a quantidade total de valores no historico:
                int tamanho = valores.Count();

                // Escreve no documento a data atual:
                Console.WriteLine("\n\nData atual: " + data + "\n");
                // Escreve no documento o nome:
                Console.WriteLine("Nome: " + Nome + "\n");
                // Escreve no documento o Saldo atual:
                Console.WriteLine("Saldo Atual: " + Convert.ToString(valores["Saldo"]) + "\n");
                // Escreve no documento o Credito atual:
                Console.WriteLine("Credito Atual: " + Convert.ToString(valores["Credito"]) + "\n");
                // Escreve no documento o credito a pagar atual:
                Console.WriteLine("Credito a pagar: " + Convert.ToString(valores["CreditoPagar"]) + "\n");

                // Se existir algo no historico:
                if (tamanho > 0)
                {

                    Console.WriteLine("\n\n---------- HISTORICO ---------\n");

                    // escrever cada uma das informaçoes do historico:
                    foreach (string item in extrato)
                    {

                        Console.WriteLine(item + "\n");

                    }

                }

            }

            // Declara uma lista do historico de transações:
            List<string> historico = new List<string>();
            List<double> historicoSaldo = new List<double>();

            // Declara uma variavel para o nome:
            string nome = "";
            // Declara um vetor para as 3 opções de credito:
            double[] opcoes;

            // Dicionario das variaveis da pessoa:
            Dictionary<string, double> Pessoa = new Dictionary<string, double>()
            {

                {"Menu", 0 },

            };

            // Dicionario das variaveis que seram usadas na conta:
            Dictionary<string, double> Dados = new Dictionary<string, double>()
            {

                {"Saldo", 0 },
                {"SaldoProvisorio", 0 },
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
            while (Dados["Saldo"] <= 0)
            {

                // Faz a leitura do seu salario ate ser maior que 0:
                Console.WriteLine("\n\nPor favor insira seu Salario: ");
                Dados["Saldo"] = converter(Console.ReadLine());

            }

            // Adiciona o salario inicial no historico:
            historicoSaldo.Add(Dados["Saldo"]);

            // Chama a função que descobre o seu credito:
            opcoes = SeuCredito(Dados["Saldo"]);

            // laço que obriga o usuario a digitar uma das opções:
            while (Pessoa["Menu"] < 1 || Pessoa["Menu"] > 3)
            {

                // Mostra as opções de credito:
                Console.WriteLine("\nBaseado em seu salario você tem direito a creditos de: \n");
                // Mostra 50% a mais:
                Console.WriteLine(" 1 - " + Convert.ToString(opcoes[0]));
                // Mostra 75% a mais:
                Console.WriteLine(" 2 - " + Convert.ToString(opcoes[1]));
                // Mostra 100% a mais:
                Console.WriteLine(" 3 - " + Convert.ToString(opcoes[2]));

                // Pergunta qual das opções o usuario quer:
                Console.WriteLine("Qual das opões acima você deseja?");
                Pessoa["Menu"] = converter(Console.ReadLine());

                if (Pessoa["Menu"] == 1)
                {

                    // Escolheu a primeira opção:
                    Dados["Credito"] = opcoes[0];

                }
                else if (Pessoa["Menu"] == 2)
                {

                    // Escolheu a segunda opção:
                    Dados["Credito"] = opcoes[1];

                }
                else if (Pessoa["Menu"] == 3)
                {

                    // Escolheu a terceira opção:
                    Dados["Credito"] = opcoes[2];

                }
                else
                {

                    Console.WriteLine("Opção invalida!!!");

                }

            }

            // --- FIM DO CADASTRO DA PESSOA --- //

            NovaTabela();

            Console.WriteLine("\n\n---------- Bem Vindo ----------");

            while (Dados["Menu"] != 10)
            {
                double[] valores;

                // Mostra o menu:
                Console.WriteLine("\n---------- MENU ----------");
                Console.WriteLine("\n 1 - Retirar\n 2 - Colocar\n 3 - Credito\n 4 - Pagar Credito\n 5 - Transferencia\n 6 - Extrato\n 7 - Movimentação\n 8 - Estatistica\n 9 - Exibir Banco\n 10 - Sair\n");
                Console.WriteLine("\n---------- MENU ----------\n");

                Dados["Menu"] = 0;
                // Pergunta qual a escolha do usuario:
                Console.WriteLine("\nQual a sua escolha");
                // Faz a leitura da escolha do usuario:
                Dados["Menu"] = converter(Console.ReadLine());

                if (Dados["Menu"] == 1) // Retirar
                {
                    // Mostra no console a frase entre aspas duplas:
                    Console.WriteLine("Digite o valor que deseja sacar: ");
                    // auxiliar retirar recebe o valor convertido lido pelo console:
                    Dados["AuxiliarRetirar"] = converter(Console.ReadLine());
                    // Saldo provisorio recebe o valor retornado da funçao retirar:
                    Dados["SaldoProvisorio"] = Retirar(Dados["AuxiliarRetirar"], Dados["Saldo"]);

                    // Se o saldo provisorio e o saldo atual serem diferentes:
                    if (Dados["SaldoProvisorio"] != Dados["Saldo"])
                    {
                        // Saldo atual recebe saldo provisorio:
                        Dados["Saldo"] = Dados["SaldoProvisorio"];
                        // Adiciona no historico o tipo de transação:
                        historico.Add(Historico("transferido", Dados["AuxiliarRetirar"]));
                        // Adiciona no historico de saldos o saldo atual:
                        historicoSaldo.Add(Dados["Saldo"]);

                    }
                }
                else if (Dados["Menu"] == 2) // Inserir
                {

                    // Pergunta o valor que usuario deseja inserir:
                    Console.WriteLine("Digite o valor que deseja inserir: ");
                    // faz a leitura e converte o valor que o usuario digitar:
                    Dados["AuxiliarColocar"] = converter(Console.ReadLine());
                    // Chama a função adicionar:
                    Dados["Saldo"] = Adicionar(Dados["AuxiliarColocar"], Dados["Saldo"]);
                    // Adiciona no historico:
                    historico.Add(Historico("Adicionado", Dados["AuxiliarColocar"]));
                    // Adiciona no historico de saldos o saldo atual:
                    historicoSaldo.Add(Dados["Saldo"]);

                }
                else if (Dados["Menu"] == 3) // Pedir Credito
                {

                    // Pergunta o valor que o usuario quer de credito:
                    Console.WriteLine("Digite o valor que deseja de credito: ");
                    // Faz a leitura e converte o valor que o usuario digitar:
                    Dados["AuxiliarColocar"] = converter(Console.ReadLine());
                    // Chama a função de credito:
                    valores = Credito(Dados["AuxiliarColocar"], Dados["Credito"], Dados["Saldo"], Dados["CreditoPagar"]);
                    // O saldo recebe o valor do credito:
                    Dados["Saldo"] = Dados["Saldo"] + valores[0];
                    // O credito a pagar recebe o valor:
                    Dados["CreditoPagar"] = Dados["CreditoPagar"] + valores[1];
                    // O credito que tem direito - valor:
                    Dados["Credito"] = Dados["Credito"] - valores[2];
                    // Adiciona no historico:
                    historico.Add(Historico("adicionado um credito em", valores[0]));
                    // Adiciona no historico de saldos o saldo atual:
                    historicoSaldo.Add(Dados["Saldo"]);

                }
                else if (Dados["Menu"] == 4) // Pagar Credito
                {
                    // A varaivel recebe o retorna da funçao pagar credito:
                    Dados["AuxiliarRetirar"] = PagarCredito(Dados["Saldo"], Dados["CreditoPagar"]);
                    // saldo recebe o valor do saldo menos o valor retornado da funçao pagar credito:
                    Dados["Saldo"] = Dados["Saldo"] - Dados["AuxiliarRetirar"];
                    // Credito recebe credito mais os dados de auxiliar retirar:
                    Dados["Credito"] = Dados["Credito"] + Dados["AuxiliarRetirar"];
                    // Creditos a pagar recebe ele mesmo menos auxiliar retirar:
                    Dados["CreditoPagar"] = Dados["CreditoPagar"] - Dados["AuxiliarRetirar"];

                    // Se o valor retornado ser igual a 0:
                    if (Dados["AuxiliarRetirar"] != 0)
                    {
                        // Adiciona o tipo de transação no historico:
                        historico.Add(Historico("pago a divida de credito em", Dados["AuxiliarRetirar"]));
                        // Adiciona no historico de saldos o saldo atual:
                        historicoSaldo.Add(Dados["Saldo"]);

                    }

                }
                else if (Dados["Menu"] == 5) // Transferencia
                {
                    // Mostra no console a frase entre aspas duplas:
                    Console.WriteLine("Digite o valor que deseja transferir");
                    // auxiliar retirar recebe o valor convertido lido pelo console:
                    Dados["AuxiliarRetirar"] = converter(Console.ReadLine());
                    // Saldo provisorio recebe o valor retornado da funçao retirar:
                    Dados["SaldoProvisorio"] = Retirar(Dados["AuxiliarRetirar"], Dados["Saldo"]);

                    // Se o saldo provisorio e o saldo atual serem diferentes:
                    if (Dados["SaldoProvisorio"] != Dados["Saldo"])
                    {
                        // Saldo atual recebe saldo provisorio:
                        Dados["Saldo"] = Dados["SaldoProvisorio"];
                        // Adiciona no historico o tipo de transação:
                        historico.Add(Historico("transferido", (Dados["Saldo"] - Dados["AuxiliarRetirar"])));
                        // Adiciona no historico de saldos o saldo atual:
                        historicoSaldo.Add(Dados["Saldo"]);

                    }

                }
                else if (Dados["Menu"] == 6) // Extrato
                {

                    // Cria o extrato no console:
                    Extrato(Dados, nome, historico);

                }
                else if (Dados["Menu"] == 7) // Graficos
                {

                    Console.WriteLine("Infelizmente ainda nao foi desenvolvido os graficos.");

                }
                else if (Dados["Menu"] == 8) // Estatistica
                {
                    int tamanho = historicoSaldo.Count();

                    if (tamanho > 1)
                    {

                        Inserirbanco(historicoSaldo);
                        Console.WriteLine("Foi feito a analise estatistica, é possivel ver no menu 9\n\n");

                    }

                }
                else if (Dados["Menu"] == 9) // Exibir o banco:
                {

                    ExibirBanco();

                }
                else if (Dados["Menu"] == 10) // Sair
                {

                    // Sai do programa:
                    Console.WriteLine("Saindo...");

                }
                else
                {

                    // Opção invalida:
                    Console.WriteLine("Opção invalida!!!!!!");

                }

            }

        }
    }
}
