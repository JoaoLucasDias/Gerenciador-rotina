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
    public partial class FrmAuthentication : Form
    {
        private string _email;
        public FrmAuthentication(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private void btnAutenticar_Click(object sender, EventArgs e)
        {
            {
                string codigoDigitado = txtbCodigoAutenticacao.Text;

                if (string.IsNullOrEmpty(codigoDigitado))
                {
                    MessageBox.Show("Digite o código recebido por e-mail.");
                    return;
                }

                using (SqlConnection con = new SqlConnection("Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno"))
                {
                    con.Open();

                    // 1. Buscar o Id do usuário pelo e-mail
                    string queryUsuario = "SELECT Id FROM Usuario WHERE Email = @Email";
                    SqlCommand cmdUsuario = new SqlCommand(queryUsuario, con);
                    cmdUsuario.Parameters.AddWithValue("@Email", _email);
                    object usuarioIdObj = cmdUsuario.ExecuteScalar();

                    if (usuarioIdObj == null)
                    {
                        MessageBox.Show("Usuário não encontrado.");
                        return;
                    }

                    int usuarioId = Convert.ToInt32(usuarioIdObj);

                    // 2. Verificar se o código confere e se ainda não expirou
                    string queryCodigo = @"SELECT TOP 1 Codigo, ExpiraEm 
                                       FROM ResetSenha 
                                       WHERE UsuarioId = @UsuarioId AND Codigo = @Codigo
                                       ORDER BY ExpiraEm DESC";

                    SqlCommand cmdCodigo = new SqlCommand(queryCodigo, con);
                    cmdCodigo.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    cmdCodigo.Parameters.AddWithValue("@Codigo", codigoDigitado);

                    SqlDataReader reader = cmdCodigo.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime expiraEm = Convert.ToDateTime(reader["ExpiraEm"]);
                        if (DateTime.Now <= expiraEm)
                        {
                            MessageBox.Show("Código válido! Agora você pode redefinir sua senha.");

                            // abre o form para redefinição de senha
                            FrmForgot2 frm = new FrmForgot2(usuarioId);
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Código expirado! Solicite um novo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Código inválido!");
                    }
                }
            }
        }

        private void txtbCodigoAutenticacao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
