using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace ConsoleApp3
{
    class BancoDados
    {

        // Cria uma conexao global na classe:
        public SQLiteConnection conexao;

        // Cria o metodo construtor da classe:
        public BancoDados()
        {

            // Faz a conexão:
            conexao = new SQLiteConnection("Data Source = BancoText.Sqlite3");

            // Verifica se ja existe criado um arquivo com o nome estatistica:
            if (!File.Exists("./BancoText.sqlite3"))
            {
                // Se não existir ele cria o arquivo:
                SQLiteConnection.CreateFile("BancoText.sqlite3");

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

        public void CriarTabela()
        {

            // String para criar tabela de login:
            string CriarTabelaLogin = "Create table if not exists Tb_usuario" +
                                      "(Tb_usuario_ID integer not null primary key autoincrement," +
                                      "Tb_usuario_Nome varchar(255) not null," +
                                      "Tb_usuario_Senha varchar(255) not null)";

            // Cria uma query do tipo SQLiteCommand usando a conexao do objeto banco e a string:
            SQLiteCommand QueryCriarTabelaLogin = new SQLiteCommand(CriarTabelaLogin, this.conexao);

            // Abre a conexao com o banco de dados:
            this.AbrirConexao();

            // Execulta a query:
            QueryCriarTabelaLogin.ExecuteNonQuery();

            // Fecha a conexao:
            this.FecharConexao();

        }

        public void Cadastrar(string Usuario, string Senha)
        {

            // String para fazer o cadastro do usuario no banco de dados:
            string Cadastrar = "Insert into Tb_usuario (Tb_usuario_Nome, Tb_usuario_Senha) Values ( @Usuario, @Senha)";

            // Cria um comando em sql para fazer o cadastro, utilizando a string anterior:
            SQLiteCommand QueryCadastrar = new SQLiteCommand(Cadastrar, this.conexao);

            // Adiciona o parametro usuario:
            QueryCadastrar.Parameters.AddWithValue("@Usuario", Usuario);

            // Adiciona o parametro senha:
            QueryCadastrar.Parameters.AddWithValue("@Senha", Senha);

            // Abre a conexao com o banco de dados:
            this.AbrirConexao();

            // Execulta o comando:
            QueryCadastrar.ExecuteNonQuery();

            // Fecha a conexão com o banco de dados:
            this.FecharConexao();

        }

        public void Login(string Usuario, string Senha)
        {

            // String usada para procurar no banco de dados o usuario:
            string SelectLogin = string.Format("Select * From Tb_usuario where Tb_usuario_Nome = '{0}' And Tb_usuario_Senha = '{1}'", Usuario, Senha);

            // Cria um Adaptador de banco de dados:
            SQLiteDataAdapter Adaptador = null;

            // Cria uma tabela virtual para guarda os valores retornado do banco de dados:
            DataTable Tabela = new DataTable();

            // Execulta o comando sql e guarda no adaptador:
            Adaptador = new SQLiteDataAdapter(SelectLogin, this.conexao);

            // Faz a adaptação para a tabela virtual:
            Adaptador.Fill(Tabela);

            // Conta quantas linhas foram retornado no comando sql: 
            int retornado = Tabela.Rows.Count;

            // Abre a conexão com o banco de dados:
            this.AbrirConexao();

            // Se ele retornou algo signifca que aquele determinado usuario existe no banco de dados:
            if(retornado >= 1)
            {

                // Mostra no console que o usuario existe no banco de dados:
                Console.WriteLine("Login realizado com sucesso!!!");

            }
            else // Caso não retorne nenhum:
            {

                // Mostra no console que nao existe esse usuario cadastrado no banco de dados:
                Console.WriteLine("Erro!! usuario não cadastrado no banco de dados");

            }

            // Fecha a conexão com o banco de dados:
            this.FecharConexao();

        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            // Cria um objeto do tipo banco de dados:
            BancoDados banco = new BancoDados();

            // Execulta o metodo para criar as tabelas:
            banco.CriarTabela();

            // Variaveis usadas para fazer o login/cadastro:
            string usuario;
            string senha;

            //  Variavel para o menu:
            int menu = 0;

            // laço para continuar ate o usuario decaidir sair:
            while(menu != 3)
            {

                // Menu das possiveis opções do usuario:
                Console.WriteLine("O que deseja fazer?\n 1 - Cadastrar um usuario\n 2 - login\n 3 - Sair");

                // Faz a leitura do que o usuario deseja:
                menu = Convert.ToInt32(Console.ReadLine());

                // Se for igual a 1:
                if(menu == 1)
                {

                    // Faz a leitura do nome do usuario:
                    Console.WriteLine("Digite aqui o nome do seu usuario: ");
                    usuario = Console.ReadLine();

                    // Faz a leitura da senha do usuario:
                    Console.WriteLine("\nDigite aqui a sua senha: ");
                    senha = Console.ReadLine();

                    // Chama o metodo para cadastrar no banco de dados:
                    banco.Cadastrar(usuario, senha);

                }else if (menu == 2) // Se for igual a 2:
                {

                    // Faz a leitura do nome do usuario:
                    Console.WriteLine("Digite aqui o nome do seu usuario: ");
                    usuario = Console.ReadLine();

                    // Faz a leitura da senha do usuario:
                    Console.WriteLine("\nDigite aqui a sua senha: ");
                    senha = Console.ReadLine();

                    // Chama o metodo para fazer login:
                    banco.Login(usuario, senha);

                }else if(menu == 3) // se for igual a 3:
                {

                    // sai do programa:
                    Console.WriteLine("\nSaindo...");

                }
                else // se for diferente de um deles:
                {

                    Console.WriteLine("Erro!! opção invalida.");

                }

            }

        }
    }
}
