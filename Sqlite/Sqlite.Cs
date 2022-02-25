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

        public void CriarTabelaUsuario()
        {

            // String para criar tabela de login:
            string CriarTabelaLogin = "Create table if not exists Tb_usuario" +
                                      "(Tb_Usuario_Id integer not null primary key autoincrement," +
                                      "Tb_Usuario_Email varchar(255) not null," +
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

        public void CriarTabelaProduto()
        {

            // String utilizada para criar a tabela no banco de dados:
            string CriarTabela = "Create Table If Not Exists Tb_Produto (" +
                                 "Tb_Produto_Id Integer Primary Key AutoIncrement," +
                                 "Tb_Produto_Fornecedor int Not Null," +
                                 "Tb_Produto_Nome Varchar(125) Not null," +
                                 "FOREIGN key(Tb_Produto_Fornecedor) " +
                                 "REFERENCES Tb_Fornecedor(Tb_Fornecedor_Id))";

            // criançao de um comando em sqlite para criar a tabela:
            SQLiteCommand QueryCriarTabela = new SQLiteCommand(CriarTabela, this.conexao);

            // Abrir a conexao com o banco de dados:
            this.AbrirConexao();

            // execulta a query:
            QueryCriarTabela.ExecuteNonQuery();

            // Fecha a conexao com o banco de dados:
            this.FecharConexao();

        }

        public void CriarTabelaFornecedor()
        {

            // string para criar a tabela:
            string CriarTabela = "Create Table if not exists Tb_Fornecedor (" +
                                 "Tb_Fornecedor_Id integer primary key autoincrement," +
                                 "Tb_Fornecedor_Nome Varchar(150) Not null," +
                                 "Tb_Fornecedor_Cep Varchar(25) Not null," +
                                 "Tb_Fornecedor_Logradouro Varchar(100) Not null," +
                                 "Tb_Fornecedor_Bairro Varchar(100) Not null," +
                                 "Tb_Fornecedor_Uf char(2) Not null)";

            // criando um comando em sqlite:
            SQLiteCommand QueryCriarTabela = new SQLiteCommand(CriarTabela, this.conexao);

            // abrir a conexao com o banco de dados:
            this.AbrirConexao();

            // execulta a query atual:
            QueryCriarTabela.ExecuteNonQuery();

            // Fecha a conexao com o banco de dados:
            this.FecharConexao();

        }

        // Metodo para criar a tabela cliente:
        public void CriarTabelaCliente()
        {

            // string utilizada para criar a tabela cliente:
            string CriarTabela = "Create Table If Not Exists Tb_Cliente (" +
                                 "Tb_Cliente_Id Integer Primary Key autoincrement," +
                                 "Tb_Cliente_Nome Varchar(150) Not null, " +
                                 "Tb_Cliente_Cep Varchar(25) Not null," +
                                 "Tb_Cliente_Bairro Varchar(100) Not Null," +
                                 "Tb_Cliente_Logradouro Varchar(100) Not Null," +
                                 "Tb_Cliente_Uf char(2) Not null)";

            // cria uma query em sql para criar a tabela:
            SQLiteCommand QueryCriarTabela = new SQLiteCommand(CriarTabela, this.conexao);

            // Abre a conexao com o banco de dados:
            this.AbrirConexao();

            // Execulta a query:
            QueryCriarTabela.ExecuteNonQuery();

            // Fecha a conexao com o banco de dados:
            this.FecharConexao();

        }

        public void CriarTabelaVenda()
        {

            // Criando a tabela venda:
            string CriarTabela = "Create Table If not exists Tb_Venda (" +
                                 "Tb_Venda_Id Integer Primary Key Autoincrement, " +
                                 "Tb_Venda_Produto Int Not null, " +
                                 "Tb_Venda_Cliente Int Not null, " +
                                 "Tb_Venda_Valor double(10,2) Not null, " +
                                 "FOREIGN key(Tb_Venda_Produto) " +
                                 "REFERENCES tb_produto(tb_produto_Id), " +
                                 "FOREIGN key(Tb_Venda_Cliente) " +
                                 "REFERENCES tb_cliente(tb_cliente_Id))";

            // Criando a query para criar a tabela venda:
            SQLiteCommand QueryCriarTabela = new SQLiteCommand(CriarTabela, this.conexao);

            // Abre a conexao com o banco de dados:
            this.AbrirConexao();

            // Execulta a query:
            QueryCriarTabela.ExecuteNonQuery();

            // Fecha a conexao com o banco de dados:
            this.FecharConexao();

        }

        public string CadastrarUsuario(string Usuario, string Senha)
        {

            // chama o metodo para ver se o usuario existe no banco de dados:
            int Verificar = UsuarioExiste(Usuario, Senha, "Cadastrar");

            // Verifica se o usuario ja existe:
            if (Verificar >= 1)
            {

                // Retorna uma string falando que o usuario ja existe no banco de dados:
                return "Ja Cadastrado";

            }
            else
            {

                // String para fazer o cadastro do usuario no banco de dados:
                string Cadastrar = "Insert into Tb_usuario (Tb_usuario_Email, Tb_usuario_Senha) Values ( @Usuario, @Senha)";

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

                // Retorna uma string falando que foi realizado com sucesso o cadastro no banco de dados:
                return "Cadastro realizado";

            }

        }

        public void CadastrarClienteFornecedor(string tabela, string nome, string cep, string bairro, string logradouro, string uf)
        {

            // string para adicionar:
            string AdicionarCliente = "Insert into Tb_" + tabela + "( Tb_" + tabela + "_Nome," +
                                      "Tb_" + tabela + "_Cep, Tb_" + tabela + "_Bairro," +
                                      "Tb_" + tabela + "_Logradouro, Tb_" + tabela + "_Uf) values (" +
                                      "@Nome, @Cep, @Bairro, @Logradouro, @Uf)";

            // criançao de uma query em sqlite:
            SQLiteCommand QueryAdicionarCliente = new SQLiteCommand(AdicionarCliente, this.conexao);

            // adicionando o parametro tabela:
            QueryAdicionarCliente.Parameters.AddWithValue("@tabela", tabela);

            // adicionando o parametro Nome:
            QueryAdicionarCliente.Parameters.AddWithValue("@Nome", nome);

            // adicionando o parametro Cep:
            QueryAdicionarCliente.Parameters.AddWithValue("@Cep", cep);

            // Adicionando o parametro Bairro:
            QueryAdicionarCliente.Parameters.AddWithValue("@Bairro", bairro);

            // Adicionando o parametro Logradouro:
            QueryAdicionarCliente.Parameters.AddWithValue("@Logradouro", logradouro);

            // adicionando o parametro Uf:
            QueryAdicionarCliente.Parameters.AddWithValue("@Uf", uf);

            // Abrindo a conexao com o banco de dados:
            this.AbrirConexao();

            // execultando o comando sql:
            QueryAdicionarCliente.ExecuteNonQuery();

            // Fechando a conexao:
            this.FecharConexao();

        }

        public void AdicionarProduto(int fornecedor, string nome)
        {

            // String para inserir produto:
            string InserirProduto = "Insert into Tb_Produto ( Tb_Produto_Fornecedor," +
                                    "Tb_Produto_Nome) values (@Fornecedor, @Nome)";

            // comando sql para inserir produtos:
            SQLiteCommand QueryInserirProduto = new SQLiteCommand(InserirProduto, this.conexao);

            // passando os parametro fornecedor:
            QueryInserirProduto.Parameters.AddWithValue("@Fornecedor", fornecedor);

            // passando o parametro Nome:
            QueryInserirProduto.Parameters.AddWithValue("@Nome", nome);

            // abrir a conexao com o banco de dados:
            this.AbrirConexao();

            // execulta o comando sql:
            QueryInserirProduto.ExecuteNonQuery();

            // Fecha a conexao com o banco de dados:
            this.FecharConexao();

        }

        // Metodo para adicionar venda:
        public void AdicionarVenda(int produto, int cliente, double valor)
        {

            // string utilizada para adicionar a venda:
            string inserirVenda = "Insert into Tb_Venda (" +
                                  "Tb_Venda_Produto, Tb_Venda_Cliente, Tb_Venda_Valor)" +
                                  "values ( @Produto, @Cliente, @Valor)";

            // query para ser execultada:
            SQLiteCommand QueryInserirVenda = new SQLiteCommand(inserirVenda, this.conexao);

            // adiciona o parametro produto:
            QueryInserirVenda.Parameters.AddWithValue("@Produto", produto);

            // adiciona o parametro cliente:
            QueryInserirVenda.Parameters.AddWithValue("@Cliente", cliente);

            // adiciona o parametro valor:
            QueryInserirVenda.Parameters.AddWithValue("@Valor", valor);

            // Abre a conexao com o banco de dados:
            this.AbrirConexao();

            // Execulta a query:
            QueryInserirVenda.ExecuteNonQuery();

            // Fecha a conexao com o banco de dados:
            this.FecharConexao();

        }

        // Metodo login:
        public int UsuarioExiste(string Usuario, string Senha, string Tipo)
        {

            // Declara uma variavel do tipo inteiro para armazenar a quantidade de valores retornados pela query Select:
            int QuantidadeRegistros;

            // Declara um adaptador para a DataTable:
            SQLiteDataAdapter Adaptador = null;

            // Declara uma tabela de dados:
            DataTable TabelaDados = new DataTable();

            // Cria uma string para ser utilizada como uma query SQL:
            string SelectLogin = String.Format("select Tb_Usuario_Id ,Tb_Usuario_Email, Tb_Usuario_Senha from Tb_Usuario Where Tb_Usuario_Email = '{0}' and Tb_Usuario_Senha = '{1}'", Usuario, Senha);

            // Adiciona no adaptador os valores retornados da Query acima:
            Adaptador = new SQLiteDataAdapter(SelectLogin, this.conexao);

            // O adaptador para a tabela de dados:
            Adaptador.Fill(TabelaDados);

            // A variavel quantidadeRegistros recebe o numero de linhas retornados:
            QuantidadeRegistros = TabelaDados.Rows.Count;

            if (Tipo == "Cadastrar")
            {

                // O metodo retorna o numero de registros:
                return QuantidadeRegistros;

            }
            else // Login ou Update:
            {

                // O select retorna 3 colunas da tabela e a primeira é o ID
                // O codigo abaixo retorna o ID do usuario atual:
                int id = Convert.ToInt32(TabelaDados.Rows[0][0]);

                // retorna o id:
                return id;

            }

        }

        public void UpdateUsuario(string usuario, string senha, string novaSenha)
        {

            // Chama o metodo que retorna o id do usuario:
            int Id = this.UsuarioExiste(usuario, senha, "Update");

            // cria uma string para atualizar os dados:
            string Atualizar = "Update Tb_Usuario Set Tb_Usuario_Senha = @Senha Where Tb_Usuario_Id = @Id";

            // Cria uma query para atualizar o banco de dados:
            SQLiteCommand QueryAtualizar = new SQLiteCommand(Atualizar, this.conexao);

            // troca o @Senha pela variavel nova senha:
            QueryAtualizar.Parameters.AddWithValue("@Senha", novaSenha);

            // troca o @Id pela variavel Id:
            QueryAtualizar.Parameters.AddWithValue("@Id", Id);

            // Abre a conexao com o banco de dados:
            this.AbrirConexao();

            // Execulta a query:
            QueryAtualizar.ExecuteNonQuery();

            // Fecha a conexao com o banco de dados:
            this.FecharConexao();

        }

        // Metodo para inserir nas tabelas:
        public void InserirGeral(string TabelaNome, List<string> ListaOndeInserir, List<List<string>> ListaValoresInserir)
        {

            // String inicial para inserir no banco de dados:
            string inserir = "Insert into" + TabelaNome + "(";

            // string usada para criar a query para inserir no banco de dados:
            string inserirBanco = "";

            // Variavel para receber o tamanho da lista:
            int tamanho = ListaOndeInserir.Count;

            int tamanhoValores;

            // Laço de repetição para percorrer a lista:
            for (int x = 1; x <= tamanho; x++)
            {

                // Se é o primeiro vez dentro do laço:
                if (x == 1)
                {

                    // Adiciona na string a coluna do banco de dados sem a virgula:
                    inserir = inserir + ListaOndeInserir[x];

                }
                else if (x < tamanho) // se nao se:
                {

                    // Se nao ser a ultima vez do laço de repetição adiciona uma virgula na string e o novo local:
                    inserir = inserir + "," + ListaOndeInserir[x];

                }
                else
                {

                    // se for a ultima vez do laço adiciona a virgula, o valor da variavel e por ultima fecha o parenteses:
                    inserir = inserir + "," + ListaOndeInserir[x] + ") Values (";

                }

            }

            // tamanho recebe a quantidade de listas que existem dentro da lista Listavalores:
            tamanho = ListaValoresInserir.Count();

            // laço de repetição para percorrer a lista:
            for (int x = 1; x <= tamanho; x++)
            {

                // a string inserirBanco recebe a variavel inserir e é utilizada para desenvolver a query final:
                inserirBanco = inserir;

                // conta quantos valores existem dentro da nova lista:
                tamanhoValores = ListaValoresInserir[x].Count();

                // um laço de repetição para percorrer os valores dentro da 2 lista:
                for (int a = 1; a <= tamanhoValores; a++)
                {

                    // verifica se é o primeiro valor a ser inserido na string:
                    if (a == 1)
                    {

                        // concatena o valor atual da lista com a string:
                        inserirBanco = inserirBanco + ListaValoresInserir[x][a];

                    }
                    else if (a < tamanhoValores) // verifica se nao é a ultima vez do laço de repetição:
                    {

                        // adiciona uma virgula e o valor atual da lista na string:
                        inserirBanco = inserirBanco + "," + ListaValoresInserir[x][a];

                    }
                    else // se for a ultima vez do laço de repetição:
                    {

                        // adiciona uma virgula, o valor atual da lista e fecha o parenteses:
                        inserirBanco = inserirBanco + "," + ListaValoresInserir[x][a] + ")";

                    }

                }

                // cria uma query em sqlite utilizando a string anterior e a conexao da class:
                SQLiteCommand QueryInserirBanco = new SQLiteCommand(inserirBanco, this.conexao);

                // utiliza o metodo da classe para abrir a conexao com o banco de dados:
                this.AbrirConexao();

                // execulta a query:
                QueryInserirBanco.ExecuteNonQuery();

                // fecha a conexao com o banco de dados:
                this.FecharConexao();

            }

        }

        // metodo para deletar valores no banco de dados:
        public void Deletar(string tabela, string Coluna, string condicao)
        {

            // cria uma string para ser utilizada para deletar valores no banco de dados:
            string bancoDeletar = "Delete from " + tabela + " where " + Coluna + "=" + condicao;

            // cria uma query em sqlite para ser execultada:
            SQLiteCommand QueryBancoDeletar = new SQLiteCommand(bancoDeletar, this.conexao);

            // abre a conexao com o banco de dados:
            this.AbrirConexao();

            // execulta a query:
            QueryBancoDeletar.ExecuteNonQuery();

            // fecha a conexao com o banco de dados:
            this.FecharConexao();

        }


        // Selecionar com join:
        public DataTable SelecionarVendas()
        {

            // declaração de um adaptador:
            SQLiteDataAdapter Adapatador = null;

            // declaração de uma tabela de dados:
            DataTable TabelaDados = new DataTable();

            // declaração de uma string para ser utilizada para a criação do comando sql:
            string SelecionarVendas = "select Tb_Cliente.Tb_Cliente_Nome, Tb_Produto.tb_produto_nome, tb_venda_valor Tb from Tb_Venda " +
                                      "inner Join Tb_Cliente on Tb_Cliente.Tb_Cliente_Id = Tb_Venda.Tb_venda_Cliente " +
                                      "Inner Join Tb_Produto on Tb_Produto.tb_produto_id = Tb_Venda.tb_venda_produto";

            // faz o adapatador receber valores retornados do comando sql:
            Adapatador = new SQLiteDataAdapter(SelecionarVendas, this.conexao);

            // passa para a tabela de dados o conteudo do adaptador:
            Adapatador.Fill(TabelaDados);

            // retorna a tabela de dados:
            return TabelaDados;

        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            // Cria o objeto banco de dados:
            BancoDados MeuBanco = new BancoDados();

            // Cria a tabela usuario:
            MeuBanco.CriarTabelaUsuario();

            // cria a tabela cliente:
            MeuBanco.CriarTabelaCliente();

            // cria a tabela fornecedor:
            MeuBanco.CriarTabelaFornecedor();

            // cria a tabela produto:
            MeuBanco.CriarTabelaProduto();

            // cria a tabela venda:
            MeuBanco.CriarTabelaVenda();

            // Cadastra no banco de dados um usuario:
            MeuBanco.CadastrarUsuario("Miguel", "MiguelFernandes");

            // verifica se existe no banco de dados:
            MeuBanco.UsuarioExiste("Miguel", "MiguelFernandes", "Login");

            // Cadastrar um cliente:
            MeuBanco.CadastrarClienteFornecedor("Cliente", "Lojinha do seu antonio", "06535-030", "São pedro", "Rua jose pedroso filho", "Sp");

            // adicionando um fornecedor:
            MeuBanco.CadastrarClienteFornecedor("Fornecedor", "Aqui tem caro", "06535-030", "São luiz", "Rua marcio filho", "Sp");

            // adicionando um fornecedor:
            MeuBanco.CadastrarClienteFornecedor("Fornecedor", "luizinho", "06535-030", "São luiz", "Rua marcio filho", "Sp");

            // adicionando um produto:
            MeuBanco.AdicionarProduto(1, "Carro");

            // adicionando um produto:
            MeuBanco.AdicionarProduto(2, "Moto");

            // adicionando vendas:
            MeuBanco.AdicionarVenda(1, 1, 500.00);

            // adicionando vendas:
            MeuBanco.AdicionarVenda(1, 2, 500.00);

            // deletar a 2 venda:
            MeuBanco.Deletar("Tb_Venda", "Tb_Venda_Id", "2");

            // recebe a tabela de dados:
            DataTable Tabela = MeuBanco.SelecionarVendas();

            // Laço para percorrer cada linha da tabela::
            for (int x = 0; x <= (Convert.ToInt16(Tabela.Rows.Count) - 1); x++)
            {

                // laço para percorrer os 3 valores das linhas:
                for (int i = 0; i <= 2; i++)
                {

                    // Mostra no console:
                    Console.WriteLine("Valor: " + Convert.ToString(Tabela.Rows[x][i]));

                }

                // coloca uma linha para separar:
                Console.WriteLine("-----------------------\n\n\n");

            }

            // mostra no console que rodo:
            Console.WriteLine("Rodo tudo familia");

            Console.ReadLine();
        }
    }
}
