using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_rotina
{
    public partial class FrmLog : Form
    {
        // Variável estática para manter o ID do usuário em toda a aplicação (boa alternativa, mas vamos passar via construtor!)
        public static int UsuarioLogadoId;

        public FrmLog()
        {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            FrmCreate novaJanela = new FrmCreate();
            novaJanela.Show();
        }

        // Método btnLogin_Click original (vazio), o código real está em btnLogin_Click_1

        private void btnEsqueceuSenha_Click(object sender, EventArgs e)
        {
            FrmForgotKey frmForgotKey = new FrmForgotKey();

            frmForgotKey.Show();

        }

        private void FrmLog_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string email = txtbLogEmail.Text.Trim();
            string senha = txtbLogSenha.Text.Trim();

            // 🔹 Verifica se os campos estão preenchidos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de continuar.");
                return;
            }

            // ATENÇÃO: Verifique se o nome da fonte de dados (NOTE_JOAO) e a senha estão corretos no seu ambiente!
            //  string connectionString = @"Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas";
            string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // PRIMEIRA CONSULTA: Verifica se o login é válido E captura o ID na mesma query (Mais eficiente!)
                    string query = "SELECT id FROM usuario WHERE email=@Email AND senha=@Senha";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Usa ExecuteScalar para tentar buscar o ID. Se não encontrar, retorna null.
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int idUsuario = Convert.ToInt32(result); // O ID é o resultado da consulta!

                        MessageBox.Show("Login realizado com sucesso!");
                        this.Hide();

                        // 🔑 CORREÇÃO CRÍTICA: Passa o ID do usuário logado para o construtor da tela principal.
                        FrmTelaInicial frmTelaInicial = new FrmTelaInicial(idUsuario);
                        frmTelaInicial.Show();

                        // O código a seguir (para pegar o ID novamente e inserir categorias) pode ser otimizado, 
                        // mas vamos deixá-lo aqui, pois o ID já foi armazenado na variável local 'idUsuario'.

                        // UsuarioLogadoId = idUsuario; // Esta linha não é mais estritamente necessária se usarmos o construtor

                        // O bloco de inserção de categorias deve vir depois da primeira consulta, se for a primeira vez do usuário.
                        // Mas como já foi validado o login, o usuário já existe.
                        string queryCategorias = @"
INSERT INTO categoria (id_usuario, nome_categoria)
VALUES
(@id, 'Estudos'),
(@id, 'Trabalho'),
(@id, 'Hobbie')";

                        // Este código está incompleto no arquivo de origem.
                        // Se você quiser inserir categorias padrão APENAS se não existirem,
                        // precisará de uma lógica de verificação antes deste INSERT.
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void txtbLogSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}