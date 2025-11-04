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
            get
            {
                DateTime.TryParse(lblData.Text, out DateTime data);
                return data;
            }
            set
            {
                lblData.Text = value.ToShortDateString();
                AtualizarDiasRestantes(value);
            }
        }

        public string Status { get; set; }
        public ucCardTarefa()
        {
            InitializeComponent();
            pnlDescricao.Visible = false;
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

        // Botão de editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            OnEditarTarefa?.Invoke(this, EventArgs.Empty);
        }

        // Atualiza o texto de “faltam X dias”
        private void AtualizarDiasRestantes(DateTime dataTarefa)
        {
            int diasRestantes = (dataTarefa - DateTime.Now).Days;

            if (diasRestantes > 0)
                lblFaltam.Text = $"Faltam {diasRestantes} dias";
            else if (diasRestantes == 0)
                lblFaltam.Text = "É hoje!";
            else
                lblFaltam.Text = "Tarefa atrasada!";
        }

        // (opcional) deixa o card mais bonito visualmente
        private void ucCardTarefa_Load(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.WhiteSmoke;
        }

        private void pnlTopo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFaltam_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblData_Click(object sender, EventArgs e)
        {

        }
    }
}
