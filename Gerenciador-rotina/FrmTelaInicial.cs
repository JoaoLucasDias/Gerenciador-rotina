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
        // Campos para armazenar as instâncias únicas dos UserControls
        private ucHoje telaHoje;
        private ucEmBreve telaEmBreve;
        private ucAdicionarTarefa telaAdicionar;
        private ucBuscar telaBuscar;
        private ucConcluido telaConcluido;
        private ucEstatisticas telaEstatisticas;

        public FrmTelaInicial()
        {
            InitializeComponent();
        }

        private void FrmTelaInicial_Load(object sender, EventArgs e)
        {
            // Inicializa as instâncias dos UserControls UMA VEZ ao carregar o formulário
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
            // O pnlConteudo precisa ser um painel existente no seu formulário

            // 1. Limpa todos os controles existentes no painel
            pnlConteudo.Controls.Clear();

            // 2. Define o tamanho e ancoragem do novo UserControl
            tela.Dock = DockStyle.Fill;

            // 3. Adiciona o UserControl ao painel
            // É neste momento que o InitializeComponent() do UserControl é garantido.
            pnlConteudo.Controls.Add(tela);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Implementação do Calendar
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {
            // Implementação do Paint
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Implementação do Click
        }

        private void btnHoje_Click(object sender, EventArgs e)
        {
            AbrirTela(telaHoje);
            // Se 'ucHoje' precisar de carregamento de dados, adicione: 
            // telaHoje.CarregarTarefasHoje();
        }

        private void btnEmBreve_Click(object sender, EventArgs e)
        {
            // 1. Reutiliza a instância existente
            AbrirTela(telaEmBreve);

            // 2. Chama o método de carregamento de dados (RESOLVE O NULLREFERENCEEXCEPTION)
            // A chamada acontece DEPOIS que a tela (com seus componentes internos) é adicionada ao Form pai.
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
            // Implementação do Paint
        }
    }
}