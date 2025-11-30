using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Gerenciador_rotina
{
    // Este UserControl representa um Card de Tarefa Pendente para ser exibido na tela "Hoje".
    public partial class ucCardHoje : UserControl
    {
        // 🏆 Evento disparado ao clicar em "Concluir"
        public event EventHandler OnConcluirTarefa;

        // 🗑️ Evento disparado ao clicar em "Deletar"
        public event EventHandler OnDeletarTarefa;

        // 📝 NOVO: Evento disparado ao clicar em "Editar"
        public event EventHandler OnEditarTarefa;

        private bool expandido = false;
        private DateTime _dataTarefa;

        // Propriedades Públicas
        public int IdTarefa { get; set; }

        // Propriedades Visuais (ajustadas para os nomes do seu Designer)
        public string Titulo
        {
            get => lblTituloHoje.Text;
            set => lblTituloHoje.Text = value;
        }

        // ⚠️ ATENÇÃO: Usando lblDescricao conforme o seu Designer
        public string Descricao
        {
            get => lblDescricao.Text; // CORRIGIDO: usa lblDescricao
            set => lblDescricao.Text = value; // CORRIGIDO: usa lblDescricao
        }

        // NOVO: Propriedade para mostrar a Urgência/Faltam
        public string Urgencia
        {
            get => lblFaltamHoje.Text;
            set => lblFaltamHoje.Text = value;
        }


        public DateTime DataTarefa
        {
            get => _dataTarefa;
            set
            {
                _dataTarefa = value;
                // Exibe apenas a data (já que é "Hoje")
                lblDataHoje.Text = value.ToShortDateString();

                // Exibe a urgência ou um indicador visual
                lblFaltamHoje.Text = "🚨 HOJE!"; // Usando lblFaltamHoje para a urgência
                this.BackColor = Color.LightYellow; // Cor de alerta
            }
        }

        public ucCardHoje()
        {
            InitializeComponent();
            // Assumimos um painel de descrição chamado 'pnlDescricaoHoje'
            pnlDescricaoHoje.Visible = false;
            this.BorderStyle = BorderStyle.FixedSingle;

            // 🔗 CONEXÃO DOS EVENTOS DE CLIQUE (Se você não fez no Designer):
            btnExpandirHoje.Click += btnExpandirHoje_Click;
            btnConcluirHoje.Click += btnConcluirHoje_Click;
            btnDeletarHoje.Click += btnDeletarHoje_Click;
            btnEditarHoje.Click += btnEditarHoje_Click; // NOVO
        }

        private void btnExpandirHoje_Click(object sender, EventArgs e)
        {
            expandido = !expandido;
            // Ajusta o tamanho total do Card se expandido/recolhido
            this.Height = expandido ? 150 : 70;
            pnlDescricaoHoje.Visible = expandido;
        }

        // 🏆 MÉTODO PARA CONCLUIR
        private void btnConcluirHoje_Click(object sender, EventArgs e)
        {
            // Dispara o evento de Concluir para que o ucHoje (pai) lide com o BD.
            OnConcluirTarefa?.Invoke(this, EventArgs.Empty);
        }

        // 🗑️ MÉTODO PARA DELETAR
        private void btnDeletarHoje_Click(object sender, EventArgs e)
        {
            // Dispara o evento de Deletar para que o ucHoje (pai) lide com o BD.
            OnDeletarTarefa?.Invoke(this, EventArgs.Empty);
        }

        // 📝 NOVO: MÉTODO PARA EDITAR
        private void btnEditarHoje_Click(object sender, EventArgs e)
        {
            // Dispara o evento de Editar
            OnEditarTarefa?.Invoke(this, EventArgs.Empty);
        }
    }
}