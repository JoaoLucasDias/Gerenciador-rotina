using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // Importa a biblioteca para conexão com o banco de dados SQL Server
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Importa a biblioteca para trabalhar com a interface gráfica

namespace Gerenciador_rotina
{
    // Define a classe do formulário de Login
    public partial class FrmLog : Form
    {
       
        public static int UsuarioLogadoId;

        // Construtor do formulário
        public FrmLog()
        {
          
            InitializeComponent();
        }

        
        private void btnCriar_Click(object sender, EventArgs e)
        {
           
            FrmCreate novaJanela = new FrmCreate();
           
            novaJanela.Show();
        }

       
        private void btnEsqueceuSenha_Click(object sender, EventArgs e)
        {
         
            FrmForgotKey frmForgotKey = new FrmForgotKey();
          
            frmForgotKey.Show();
        }

     
        private void FrmLog_Load(object sender, EventArgs e)
        {
            // Este método está vazio e pode ser usado para inicializações futuras
        }

        // Evento principal de clique para realizar o Login
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // Pega o texto dos campos de email e senha e remove espaços em branco extras
            string email = txtbLogEmail.Text.Trim();
            string senha = txtbLogSenha.Text.Trim();

            // Verifica se os campos de email ou senha estão vazios
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                // Exibe uma mensagem de erro se algum campo não foi preenchido
                MessageBox.Show("Por favor, preencha todos os campos antes de continuar.");
                return; // Encerra a execução do método
            }

            // String de conexão com o banco de dados SQL Server
            string connectionString = @"Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas";

            // Cria uma conexão com o banco de dados usando o 'using' para garantir o fechamento
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Query SQL para buscar o ID do usuário onde o email E a senha correspondem aos valores digitados
                    string query = "SELECT id FROM usuario WHERE email=@Email AND senha=@Senha";

                    // Cria o comando SQL com a query e a conexão
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Adiciona os valores de email e senha como parâmetros (evita SQL Injection)
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Executa a query e tenta retornar o primeiro valor da primeira linha (o ID). 
                    // Se nenhum usuário for encontrado, retorna null.
                    object result = cmd.ExecuteScalar();

                    // Verifica se a consulta retornou um ID (login bem-sucedido)
                    if (result != null)
                    {
                       
                        int idUsuario = Convert.ToInt32(result);

                        // Exibe uma mensagem de sucesso
                        MessageBox.Show("Login realizado com sucesso!");

                        // Oculta o formulário de login atual
                        this.Hide();

                        // Cria uma nova instância do formulário principal, PASSANDO o ID do usuário para o construtor
                        FrmTelaInicial frmTelaInicial = new FrmTelaInicial(idUsuario);

                        // Exibe o formulário principal
                        frmTelaInicial.Show();

                        // Trecho de código que tenta inserir categorias padrão:
                        string queryCategorias = @"
INSERT INTO categoria (id_usuario, nome_categoria)
VALUES
(@id, 'Estudos'),
(@id, 'Trabalho'),
(@id, 'Hobbie')";

                        // Este bloco precisa de mais lógica (e de um SqlCommand e execução) para ser funcional.
                        // Ele deveria verificar se as categorias já existem antes de tentar inserir novamente.
                    }
                    else
                    {
                        // Se 'result' for nulo, o email ou a senha estão incorretos
                        MessageBox.Show("Usuário ou senha incorretos!");
                    }
                }
                catch (Exception ex)
                {
                    // Captura e exibe qualquer erro que ocorra durante o processo de conexão ou execução da query
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        // Evento disparado quando o texto da caixa de senha muda (sem lógica implementada aqui)
        private void txtbLogSenha_TextChanged(object sender, EventArgs e)
        {
            // Este método está vazio
        }
    }
}