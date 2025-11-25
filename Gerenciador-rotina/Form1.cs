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

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

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

            string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT COUNT(1) FROM usuario WHERE email=@Email AND senha=@Senha";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Login realizado com sucesso!");
                        this.Hide();


                        FrmTelaInicial frmTelaInicial = new FrmTelaInicial();
                        frmTelaInicial.Show();
                        string queryId = "SELECT id FROM usuario WHERE email=@email";
                        SqlCommand cmdId = new SqlCommand(queryId, con);
                        cmdId.Parameters.AddWithValue("@email", email);
                        int idUsuario = Convert.ToInt32(cmdId.ExecuteScalar());

                        UsuarioLogadoId = idUsuario;
                        string queryCategorias = @"
INSERT INTO categoria (id_usuario, nome_categoria)
VALUES
(@id, 'Estudos'),
(@id, 'Trabalho'),
(@id, 'Hobbie')";

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
