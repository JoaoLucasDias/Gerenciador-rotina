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
            // 1. Pega o e-mail do usuário
            string emailDestino = txtbCodigoVerificacao.Text;

            // 2. Gera um código aleatório de 6 dígitos
            string codigo = new Random().Next(100000, 999999).ToString();

            try
            {
                // 3. Usa a classe auxiliar para enviar
                EmailHelper.EnviarEmailRedefinicao(emailDestino, codigo);

                MessageBox.Show("Um código foi enviado para o e-mail informado!");
                this.Close();
                FrmAuthentication frmAuthentication = new FrmAuthentication();
                    frmAuthentication.Show();
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

