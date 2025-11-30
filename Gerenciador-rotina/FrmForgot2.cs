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
    public partial class FrmForgot2 : Form
    {
        private int _usuarioId;
        public FrmForgot2(int usuarioId)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
        }

        private void txtbNovaSenhaConfirmar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            string senha = txtbNovaSenha.Text;
            string confirmarSenha = txtbNovaSenhaConfirmar.Text;

            // 1. Verifica se os campos foram preenchidos
            if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            // 2. Verifica se as senhas são iguais
            if (senha != confirmarSenha)
            {
                MessageBox.Show("As senhas não conferem!");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas"))
                {
                    con.Open();

                    string query = "UPDATE Usuario SET Senha = @Senha WHERE Id = @UsuarioId";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Senha", senha); // ⚠ Aqui está em texto puro
                    cmd.Parameters.AddWithValue("@UsuarioId", _usuarioId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Senha alterada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar senha: " + ex.Message);
            }
        }

        private void FrmForgot2_Load(object sender, EventArgs e)
        {

        }
    }
}
