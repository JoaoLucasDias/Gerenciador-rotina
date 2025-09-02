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
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gerenciador_rotina
{
    public partial class FrmForgotKey : Form
    {
        public FrmForgotKey()
        {
            InitializeComponent();
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
           


            string email = txtbCodigoVerificacao.Text;

            // Gera código
            string codigo = new Random().Next(100000, 999999).ToString();

            using (SqlConnection con = new SqlConnection("Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;Integrated Security=True"))
            {
                con.Open();

                // Verifica se existe usuário com esse e-mail
                string queryUsuario = "SELECT Id FROM Usuario WHERE EMAIL = @Email";
                SqlCommand cmdUsuario = new SqlCommand(queryUsuario, con);
                cmdUsuario.Parameters.AddWithValue("@Email", email);

                object usuarioIdObj = cmdUsuario.ExecuteScalar();
                if (usuarioIdObj == null)
                {
                    MessageBox.Show("E-mail não encontrado!");
                    return;
                }

                int usuarioId = Convert.ToInt32(usuarioIdObj);

                // Salva código na tabela ResetSenha
                string queryInsert = @"INSERT INTO ResetSenha (UsuarioId, Codigo, ExpiraEm) 
                               VALUES (@UsuarioId, @Codigo, @ExpiraEm)";
                SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                cmdInsert.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cmdInsert.Parameters.AddWithValue("@Codigo", codigo);
                cmdInsert.Parameters.AddWithValue("@ExpiraEm", DateTime.Now.AddMinutes(15));
                cmdInsert.ExecuteNonQuery();

                // Envia e-mail
                EmailHelper.EnviarEmailRedefinicao(email, codigo);
            }

            MessageBox.Show("Um código foi enviado para seu e-mail!");
        }

    }
}

