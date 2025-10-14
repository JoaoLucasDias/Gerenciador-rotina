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
    public partial class FrmTelaInicial : Form
    {
        public FrmTelaInicial()
        {
            InitializeComponent();


         


        }

    

        private void FrmTelaInicial_Load(object sender, EventArgs e)
        {
            AbrirTela(new ucHoje());
        }
        private void AbrirTela(UserControl tela)
        {
            pnlConteudo.Controls.Clear(); // Limpa o conteúdo atual
            tela.Dock = DockStyle.Fill;   // Faz ocupar todo o painel
            pnlConteudo.Controls.Add(tela);
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }


        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdicionarTarefa_Click(object sender, EventArgs e)
        {
            AbrirTela(new ucAdicionarTarefa());
        }

        
        private void btnEmBreve_Click(object sender, EventArgs e)
        {
            AbrirTela(new ucEmBreve());
          
        }

        private void btnHoje_Click(object sender, EventArgs e)
        {
            AbrirTela(new ucHoje());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirTela(new ucBuscar());
        }

        private void btnConcluido_Click(object sender, EventArgs e)
        {
            AbrirTela(new ucConcluido());
        }

        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            AbrirTela(new ucEstatisticas());
        }

        private void pnlConteudo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    

