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
       
        private int _idUsuarioLogado;

  
        private ucHoje telaHoje;
        private ucEmBreve telaEmBreve;
        private ucAdicionarTarefa telaAdicionar; 
        private ucBuscar telaBuscar;
        private ucConcluido telaConcluido;
        private ucEstatisticas telaEstatisticas;

       
        private UserControl telaAtual;

       
        public FrmTelaInicial(int idUsuario)
        {
            InitializeComponent();
            _idUsuarioLogado = idUsuario;
        }

        private void FrmTelaInicial_Load(object sender, EventArgs e)
        {
          
            telaHoje = new ucHoje();
            telaEmBreve = new ucEmBreve();
            telaAdicionar = new ucAdicionarTarefa();
            telaBuscar = new ucBuscar();
            telaConcluido = new ucConcluido();
            telaEstatisticas = new ucEstatisticas();

     
            telaHoje.IdUsuarioLogado = _idUsuarioLogado;
            telaEmBreve.IdUsuarioLogado = _idUsuarioLogado;
            telaBuscar.IdUsuarioLogado = _idUsuarioLogado;
            telaConcluido.IdUsuarioLogado = _idUsuarioLogado;
      ;
            telaEstatisticas.IdUsuarioLogado = _idUsuarioLogado;

          
            AbrirTela(telaHoje);

          
            telaHoje.CarregarTarefasHoje();
        }

       
        private void AbrirTela(UserControl novaTela)
        {
            // Verifica se o painel de conteúdo existe (usando o nome 'pnlConteudo' do seu código anterior)
            // Se o nome no seu designer for diferente (ex: pnlPrincipal), você DEVE renomear pnlConteudo abaixo.
            if (pnlConteudo == null)
            {
                // Em um projeto real, pnlConteudo deve ser um painel no seu designer.
                MessageBox.Show("ERRO: O painel 'pnlConteudo' não foi encontrado. Verifique o nome no Designer.", "Erro de Componente");
                return;
            }

            // Remove a tela anterior (UserControl)
            if (telaAtual != null)
            {
                pnlConteudo.Controls.Remove(telaAtual);
            }

            // Configura e adiciona a nova tela
            novaTela.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(novaTela);
            telaAtual = novaTela; // Define a nova tela atual
        }

        /* ------------------------------------------------------------------ */
        /* IMPLEMENTAÇÃO DOS BOTÕES                                           */
        /* ------------------------------------------------------------------ */

        private void btnHoje_Click(object sender, EventArgs e)
        {
            AbrirTela(telaHoje);
            // Chama o método de carregamento, que agora existe no ucHoje.cs
            telaHoje.CarregarTarefasHoje();
        }

        private void btnEmBreve_Click(object sender, EventArgs e)
        {
            AbrirTela(telaEmBreve);
            // Chama o método de carregamento, que agora existe no ucEmBreve.cs
            telaEmBreve.CarregarTarefasEmBreve();
        }

        private void btnConcluido_Click(object sender, EventArgs e)
        {
            AbrirTela(telaConcluido);
            // Chama o método de carregamento, que agora deve existir no ucConcluido.cs
            telaConcluido.CarregarTarefasConcluidas();
        }

        private void btnAdicionarTarefa_Click(object sender, EventArgs e)
        {
            // Se ucAdicionarTarefa é um UserControl, você o abre no painel
           
            if (telaAdicionar == null)
            {
                telaAdicionar = new ucAdicionarTarefa();
            }

            telaAdicionar.IdUsuarioLogado = _idUsuarioLogado; // <<<< VOCÊ PRECISA TER ID_UsuarioLogado NA FrmTelaInicial

            // 3. Abre a tela
            AbrirTela(telaAdicionar);


            // **OPCIONAL:** Se for um FORM de popup (FrmAdicionar), use o código abaixo:
            // FrmAdicionar formAdicionar = new FrmAdicionar(_idUsuarioLogado);
            // formAdicionar.ShowDialog();
            // Após fechar o form, recarrega a tela atual para atualizar a lista:
            // if (telaAtual == telaHoje) { telaHoje.CarregarTarefasHoje(); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirTela(telaBuscar);
        }

        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            AbrirTela(telaEstatisticas);
            // 🆕 Chamada para carregar os dados de estatística
            telaEstatisticas.CarregarEstatisticas();
            telaEstatisticas.IdUsuarioLogado = _idUsuarioLogado;

            // 🔑 PASSO CRÍTICO 2: Manda o controle carregar os dados
           
        }

        /* ------------------------------------------------------------------ */
        /* EVENTOS DO DESIGNER (Vazios para compatibilidade)                  */
        /* ------------------------------------------------------------------ */

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

        private void pnlConteudo_Paint(object sender, PaintEventArgs e)
        {
            // Implementação do Paint
        }
    }
}