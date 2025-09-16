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
            string emailDestino = txtbCodigoVerificacao.Text;

            if (string.IsNullOrEmpty(emailDestino))
            {
                MessageBox.Show("Informe um e-mail válido!");
                return;
            }

            string codigo = new Random().Next(100000, 999999).ToString();

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno"))
                {
                    con.Open();

                    // 1. Verifica se existe usuário com esse e-mail
                    string queryUsuario = "SELECT Id FROM Usuario WHERE Email = @Email";
                    SqlCommand cmdUsuario = new SqlCommand(queryUsuario, con);
                    cmdUsuario.Parameters.AddWithValue("@Email", emailDestino);

                    object usuarioIdObj = cmdUsuario.ExecuteScalar();

                    if (usuarioIdObj == null)
                    {
                        MessageBox.Show("E-mail não encontrado!");
                        return;
                    }

                    int usuarioId = Convert.ToInt32(usuarioIdObj);

                    // 2. Salva código na tabela ResetSenha
                    string queryInsert = @"INSERT INTO ResetSenha (UsuarioId, Codigo, ExpiraEm) 
                                   VALUES (@UsuarioId, @Codigo, @ExpiraEm)";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                    cmdInsert.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    cmdInsert.Parameters.AddWithValue("@Codigo", codigo);
                    cmdInsert.Parameters.AddWithValue("@ExpiraEm", DateTime.Now.AddMinutes(15));
                    cmdInsert.ExecuteNonQuery();
                }

                // 3. Envia o e-mail
                EmailHelper.EnviarEmailRedefinicao(emailDestino, codigo);

                MessageBox.Show("Um código foi enviado para o e-mail informado!");

                // 4. Abre o próximo formulário
                FrmAuthentication frmAuthentication = new FrmAuthentication(emailDestino);
                frmAuthentication.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        

        private void FrmForgotKey_Load(object sender, EventArgs e)
        {

        }

        private void txtbCodigoVerificacao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

