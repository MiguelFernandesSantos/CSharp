using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace ConsoleApp1
{// Classe para utilizar o banco de dados:
    class BancoDados
    {

        // Cria uma conexao global na classe:
        public SQLiteConnection conexao;

        // Cria o metodo construtor da classe:
        public BancoDados()
        {

            // Faz a conexão:
            conexao = new SQLiteConnection("Data Source = BancoNome.Sqlite3");

            // Verifica se ja existe criado um arquivo com o nome estatistica:
            if (!File.Exists("./BancoNome.sqlite3"))
            {

                // Se não existir ele cria o arquivo:
                SQLiteConnection.CreateFile("BancoNome.sqlite3");

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

        // Metodo para fechar conexao com o banco de dados:
        public void FecharConexao()
        {
            // Se a conexao estiver diferente de Fechada ele faz o fechamento da conexao:
            if (conexao.State != System.Data.ConnectionState.Closed)
            {

                // Fechamento da conexao:
                conexao.Close();

            }

        }
        
        // Metodo login:
        public int Login(string Usuario, string Senha)
        {

            // Declara uma variavel do tipo inteiro para armazenar a quantidade de valores retornados pela query Select:
            int QuantidadeRegistros;

            // Declara um adaptador para a DataTable:
            SQLiteDataAdapter Adaptador = null;

            // Declara uma tabela de dados:
            DataTable TabelaDados = new DataTable();

            // Cria uma string para ser utilizada como uma query SQL:
            string SelectLogin = String.Format("select Tb_Usuario_Email, Tb_Usuario_Senha from Tb_Usuario Where Tb_Usuario_Email = {0}, Tb_Usuario_Senha = {1}", Usuario, Senha);
    
            // Adiciona no adaptador os valores retornados da Query acima:
            Adaptador = new SQLiteDataAdapter(SelectLogin, this.conexao);

            // O adaptador para a tabela de dados:
            Adaptador.Fill(TabelaDados);

            // A variavel quantidadeRegistros recebe o numero de linhas retornados:
            QuantidadeRegistros = TabelaDados.Rows.Count;

            // O metodo retorna o numero de registros:
            return QuantidadeRegistros;

        }
        
        // Metodo para inserir nas tabelas:
        public void Inserir(string TabelaNome ,List<string> ListaOndeInserir, List<string> ListaValoresInserir)
        {

            // String inicial para inserir no banco de dados:
            string inserir = "Insert into" + TabelaNome + "(";

            // Variavel para receber o tamanho da lista:
            int tamanho = ListaOndeInserir.Count;

            // Laço de repetição para percorrer a lista:
            for(int x = 1; x <= tamanho; x++)
            {

                // Se é o primeiro vez dentro do laço:
                if (x == 1)
                {

                    // Adiciona na string a coluna do banco de dados sem a virgula:
                    inserir = inserir + ListaOndeInserir[x];

                }
                else if(x < tamanho) // se nao se:
                {

                    // Se nao ser a ultima vez do laço de repetição adiciona uma virgula na string e o novo local:
                    inserir = inserir + "," + ListaOndeInserir[x];

                }
                else
                {

                    // se for a ultima vez do laço adiciona a virgula, o valor da variavel e por ultima fecha o parenteses:
                    inserir = inserir +"," + ListaOndeInserir[x] + ") Values (";

                }

            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {



        }
    }
}
