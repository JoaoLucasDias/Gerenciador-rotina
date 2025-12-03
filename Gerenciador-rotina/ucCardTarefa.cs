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
    public partial class ucCardTarefa : UserControl
    {
        public event EventHandler OnDeletarTarefa;
        public event EventHandler OnConcluirTarefa;
        public event EventHandler OnEditarTarefa;

        private bool expandido = false;
        private DateTime _dataTarefa; // Campo de suporte para armazenar a data com segurança

        // Propriedades públicas para configurar o card
        public int IdTarefa { get; set; }

        public string Titulo
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }

        public string Descricao
        {
            get => lblDescricao.Text;
            set => lblDescricao.Text = value;
        }

        public DateTime DataTarefa
        {
            get => _dataTarefa; // Retorna o valor seguro armazenado
            set
            {
                _dataTarefa = value;
                lblData.Text = value.ToShortDateString();
                AtualizarDiasRestantes(value); // Atualiza o rótulo de dias restantes
            }
        }

        public string Status { get; set; }

        public ucCardTarefa()
        {
            InitializeComponent();
            pnlDescricao.Visible = false;
            // Configuração visual padrão para melhor leitura
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.WhiteSmoke;
        }

        private void ucCardTarefa_Load(object sender, EventArgs e)
        {
            // O código do construtor já está tratando o visual
        }

        private void btnExpandir_Click(object sender, EventArgs e)
        {
            expandido = !expandido;
            pnlDescricao.Visible = expandido;
        }

        // Botão de deletar
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("Tem certeza que deseja excluir esta tarefa?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
                OnDeletarTarefa?.Invoke(this, EventArgs.Empty);
        }

        // Botão de concluir
        private void btnConcluir_Click(object sender, EventArgs e)
        {
            OnConcluirTarefa?.Invoke(this, EventArgs.Empty);
        }


      
        private void AtualizarDiasRestantes(DateTime dataTarefa)
        {
          
            DateTime hoje = DateTime.Today;

            // Calcula a diferença em dias (considerando apenas a data)
            TimeSpan diferenca = dataTarefa.Date - hoje;
            int diasRestantes = (int)diferenca.TotalDays;

            if (diasRestantes > 0)
                lblFaltam.Text = $"Faltam {diasRestantes} dias";
            else if (diasRestantes == 0)
                lblFaltam.Text = "É hoje!"; // Esta tarefa seria vista na tela 'Hoje'
            else
            {
                // Embora esta tela seja 'Em Breve' (> GETDATE()), 
                // é bom ter a condição de atrasada por segurança.
                lblFaltam.Text = "Tarefa atrasada!";
            }
        }

        // Métodos de eventos vazios (mantidos por compatibilidade com o designer)
        private void pnlTopo_Paint(object sender, PaintEventArgs e) { }
        private void lblFaltam_Click(object sender, EventArgs e) { }
        private void lblTitulo_Click(object sender, EventArgs e) { }
        private void lblData_Click(object sender, EventArgs e) { }
    }
}