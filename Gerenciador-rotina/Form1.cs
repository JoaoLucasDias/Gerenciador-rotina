using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
