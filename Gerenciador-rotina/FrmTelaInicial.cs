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
        private ucHoje telaHoje;
        private ucEmBreve telaEmBreve;
        private ucAdicionarTarefa telaAdicionar;
        private ucBuscar telaBuscar;
        private ucConcluido telaConcluido;
        private ucEstatisticas telaEstatisticas;



        private void FrmTelaInicial_Load(object sender, EventArgs e)
        {
            telaHoje = new ucHoje();
            telaEmBreve = new ucEmBreve();
            telaAdicionar = new ucAdicionarTarefa();
            telaBuscar = new ucBuscar();
            telaConcluido = new ucConcluido();
            telaEstatisticas = new ucEstatisticas();

            // Exibe a tela "Hoje" por padrão
            AbrirTela(telaHoje);
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
        private void btnHoje_Click(object sender, EventArgs e)
        {
            AbrirTela(telaHoje);
        }

        private void btnEmBreve_Click(object sender, EventArgs e)
        {
            AbrirTela(telaEmBreve);
            telaEmBreve.CarregarTarefasEmBreve();
        }

        private void btnAdicionarTarefa_Click(object sender, EventArgs e)
        {
            AbrirTela(telaAdicionar);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirTela(telaBuscar);
        }

        private void btnConcluido_Click(object sender, EventArgs e)
        {
            AbrirTela(telaConcluido);
        }

        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            AbrirTela(telaEstatisticas);
        }

        private void pnlConteudo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    

