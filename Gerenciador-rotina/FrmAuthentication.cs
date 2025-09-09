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
        public FrmAuthentication()
        {
            InitializeComponent();
        }

        private void btnAutenticar_Click(object sender, EventArgs e)
        {
            {
                string email = txtbCodigoAutenticacao.Text;
                string codigo = txtbCodigoAutenticacao.Text;

                using (SqlConnection con = new SqlConnection("Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno; Password=aluno"))
                {
                    con.Open();

                    string query = @"SELECT r.Id, r.ExpiraEm, r.Usado
                         FROM ResetSenha r
                         JOIN Usuario u ON r.UsuarioId = u.Id
                         WHERE u.Email = @Email AND r.Codigo = @Codigo";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Codigo", codigo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime expiraEm = reader.GetDateTime(1);
                        bool usado = reader.GetBoolean(2);

                        if (usado)
                        {
                            MessageBox.Show("Esse código já foi usado!");
                        }
                        else if (DateTime.Now > expiraEm)
                        {
                            MessageBox.Show("Esse código expirou!");
                        }
                        else
                        {
                            MessageBox.Show("Código válido! Agora você pode redefinir a senha.");
                            this.Close();
                            FrmForgot2 frmForgot2 = new FrmForgot2();
                            frmForgot2.ShowDialog();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Código inválido!");
                    }
                }
            }
        }
    }
}
