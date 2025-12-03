using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing; // Adicionado se for usar recursos do Drawing

namespace Gerenciador_rotina
{
    public partial class FrmCreate : Form
    {
        string connectionString = "Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas";

        public FrmCreate()
        {
            InitializeComponent();
        }

        private void FrmCreate_Load(object sender, EventArgs e)
        {
            // Opcional: Adicionar lógica de inicialização da tela aqui
        }

        // 🎯 NOVO MÉTODO: Verifica se o nome de usuário ou e-mail já existem no banco
        private bool VerificarDuplicidade(string usuario, string email, SqlConnection con)
        {
            // 1. Verificar Nome de Usuário
            string checkUserQuery = "SELECT COUNT(1) FROM usuario WHERE USUARIO = @Nome";
            using (SqlCommand cmd = new SqlCommand(checkUserQuery, con))
            {
                cmd.Parameters.AddWithValue("@Nome", usuario);
                int userCount = (int)cmd.ExecuteScalar();
                if (userCount > 0)
                {
                    MessageBox.Show("Nome de usuário já existe. Por favor, escolha outro.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            // 2. Verificar E-mail
            // Esta query garante que o e-mail não foi usado por NENHUM outro usuário.
            string checkEmailQuery = "SELECT COUNT(1) FROM usuario WHERE EMAIL = @Email";
            using (SqlCommand cmd = new SqlCommand(checkEmailQuery, con))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                int emailCount = (int)cmd.ExecuteScalar();
                if (emailCount > 0)
                {
                    MessageBox.Show("E-mail já cadastrado. Por favor, use outro.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false; // Não há duplicatas
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            // Pega valores dos TextBox
            string usuario = txtbCriarNomeUsuario.Text.Trim(); // .Trim() para remover espaços extras
            string email = txtbCriarEmail.Text.Trim();
            string senha = txtbCriarSenha.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de continuar.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 🎯 Passo 1: Verifica se já existe um usuário ou e-mail com os dados fornecidos
                    if (VerificarDuplicidade(usuario, email, con))
                    {
                        // Se for encontrado, a função já mostrou o MessageBox, apenas paramos aqui.
                        return;
                    }

                    // 🎯 Passo 2: Se não houver duplicatas, prossegue com a inserção
                    string insertQuery = "INSERT INTO usuario (USUARIO, EMAIL, SENHA) VALUES (@Nome, @Email, @Senha)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Nome", usuario);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        cmd.ExecuteNonQuery();
                    }
                    // A conexão será fechada automaticamente pelo 'using' ao final do bloco
                }

                MessageBox.Show("Usuário criado com sucesso! Faça seu login.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Fecha a tela de criação e abre a tela de login
                this.Close();
                // ⚠️ NOTE: Certifique-se de que a FrmLog está definida e que essa é a ação desejada.
                // FrmLog frm = new FrmLog(); 
                // frm.ShowDialog(); 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no banco de dados: " + ex.Message);
            }
        }
    }
}