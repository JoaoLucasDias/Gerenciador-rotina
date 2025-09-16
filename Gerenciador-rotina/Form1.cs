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
        public FrmLog()
        {
            InitializeComponent();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            FrmCreate novaJanela = new FrmCreate();
            novaJanela.Show();       // Abre o novo formulário
            this.Hide();             // Esconde o formulário atual 


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
            string email = txtbLogEmail.Text;
            string senha = txtbLogSenha.Text;

            // String de conexão (modifique conforme seu servidor e banco)
            string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT COUNT(1) FROM usuario WHERE email=@email AND senha=@senha";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        MessageBox.Show("Login realizado com sucesso!");
                        this.Close();














































































































































































































































































































































































































                        FrmTelaInicial frmTelaInicial = new FrmTelaInicial();
                        frmTelaInicial.ShowDialog();
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
    }
}
