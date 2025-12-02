using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; // Necessário para List

namespace Gerenciador_rotina
{
    // Este card é usado apenas para exibir tarefas que já foram concluídas.
    public partial class ucCardConcluido : UserControl
    {
        // 🗑️ Evento para deletar a tarefa (opcional)
        public event EventHandler OnDeletarTarefa;

        // ↩️ EVENTO NECESSÁRIO PARA RESTAURAR A TAREFA (Chamado pelo ucConcluido.cs)
        public event EventHandler OnRestaurarTarefa; // <-- DECLARAÇÃO ADICIONADA

        private bool expandido = false;
        private DateTime _dataTarefa;

        // 🏆 LISTA DE FRASES DE PARABÉNS (Adicionada)
        private static readonly List<string> FrasesParabens = new List<string>
        {
            "Missão cumprida! Você arrasou!",
            "Uau, que conquista! Parabéns pelo foco.",
            "Mandou bem! Mais um objetivo alcançado.",
            "Incrível! Você fez isso parecer fácil.",
            "Continue assim! O sucesso é feito de pequenas vitórias.",
            "Parabéns! Sua rotina agradece.",
            "Mais um degrau subido! Excelente trabalho.",
            "Parabéns pelo seu esforço!",
            "Feito! O poder da organização está com você.",
            "Você é 10! Tarefa concluída com sucesso."
        };

        // Objeto Random para escolher frases aleatórias
        private static readonly Random random = new Random();

        // Propriedades públicas (assumindo que o designer tem lblTitulo, lblDescricao, lblData, pnlDescricao, etc.)
        public int IdTarefa { get; set; }

        public string Titulo
        {
            get => lblTituloConcluido.Text;
            set => lblTituloConcluido.Text = value;
        }

        public string Descricao
        {
            get => lblDescricaoConcluido.Text;
            set => lblDescricaoConcluido.Text = value;
        }

        public DateTime DataTarefa
        {
            get => _dataTarefa;
            set
            {
                _dataTarefa = value;
                lblData.Text = value.ToShortDateString();
                // Nenhuma necessidade de calcular 'Faltam X dias' para tarefas concluídas.
                lblDiasConcluido.Text = "Concluído em: " + value.ToShortDateString();
                lblDiasConcluido.ForeColor = Color.DarkGreen; // Cor de texto verde
            }
        }

        public ucCardConcluido()
        {
            InitializeComponent();
            pnlDescricaoConcluido.Visible = false;

            // DIFERENCIAL VISUAL
            this.BackColor = Color.LightGreen; // Fundo verde claro para indicar conclusão
            this.BorderStyle = BorderStyle.FixedSingle;

            //  ATRIBUI A FRASE ALEATÓRIA 
            AtribuirFraseParabens();
        }

        // Novo método para atribuir a frase
        private void AtribuirFraseParabens()
        {
            // Escolhe um índice aleatório
            int index = random.Next(FrasesParabens.Count);
            string frase = FrasesParabens[index];

            // Apenas um lblFraseParabens é necessário, removendo a duplicação no código anterior
            if (lblFraseParabens != null)
            {
                lblFraseParabens.Text = frase;
                lblFraseParabens.ForeColor = Color.BlueViolet; // Deixa em destaque!
            }

        }


        private void btnExpandirConcluido_Click(object sender, EventArgs e)
        {
            expandido = !expandido;
            pnlDescricaoConcluido.Visible = expandido;
        }

        // Botão de deletar (se você tiver um botão no designer chamado 'btnDeletar')
        private void btnDeletarConcluido_Click(object sender, EventArgs e)
        {
            // Dispara o evento de deletar para que o ucConcluido (pai) lide com o BD
            OnDeletarTarefa?.Invoke(this, EventArgs.Empty);
        }

     


        private void pnlTopoConcluido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFrasesParabens_Click(object sender, EventArgs e)
        {

        }

        // ↩️ ESTE É O MÉTODO DO SEU BOTÃO DE RESTAURAR!
        private void btnRestaurarConcluido_Click_1(object sender, EventArgs e)
        {
            // Dispara o evento de restaurar para que o ucConcluido (pai) lide com o BD
            OnRestaurarTarefa?.Invoke(this, EventArgs.Empty);
        }
    }
}