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


            CriarLayout();


        }

        // painéis de conteúdo (campos para poder acessá-los nos handlers)
        private Panel menuPanel;
        private Panel contentPanel;
        private Panel pnlHoje;
        private Panel pnlEntrada;
        private Panel pnlProjetos;


        private void CriarLayout()
        {
            // Form principal
            this.Text = "Gerenciador de Rotina";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Menu lateral
            menuPanel = new Panel();
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Width = 220;
            menuPanel.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(menuPanel);

            Label lblMenu = new Label();
            lblMenu.Text = "Menu";
            lblMenu.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblMenu.Dock = DockStyle.Top;
            lblMenu.Padding = new Padding(10);
            menuPanel.Controls.Add(lblMenu);

            // Cria botões e associa eventos de clique
            Button btnHoje = CriarBotaoMenu("Hoje");
            btnHoje.Click += (s, e) => ShowPanel(pnlHoje);
            Button btnEntrada = CriarBotaoMenu("Entrada");
            btnEntrada.Click += (s, e) => ShowPanel(pnlEntrada);
            Button btnProjetos = CriarBotaoMenu("Meus Projetos");
            btnProjetos.Click += (s, e) => ShowPanel(pnlProjetos);

            // Adiciona os botões (ordem visual: top primeiro -> adicionar na ordem desejada)
            menuPanel.Controls.Add(btnProjetos);
            menuPanel.Controls.Add(btnEntrada);
            menuPanel.Controls.Add(btnHoje);

            // Painel de conteúdo principal
            contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.White;
            this.Controls.Add(contentPanel);

            // --- cria os painéis específicos (cada um representa uma "tela" interna) ---
            pnlHoje = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };
            pnlEntrada = new Panel() { Dock = DockStyle.Fill, BackColor = Color.WhiteSmoke };
            pnlProjetos = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };

            // Exemplo de conteúdo em cada painel:
            Label lblHoje = new Label() { Text = "TELA HOJE", Font = new Font("Segoe UI", 18, FontStyle.Bold), Location = new Point(20, 20) };
            pnlHoje.Controls.Add(lblHoje);
            Label lblEntrada = new Label() { Text = "TELA ENTRADA", Font = new Font("Segoe UI", 18, FontStyle.Bold), Location = new Point(20, 20) };
            pnlEntrada.Controls.Add(lblEntrada);
            Label lblProjetos = new Label() { Text = "TELA PROJETOS", Font = new Font("Segoe UI", 18, FontStyle.Bold), Location = new Point(20, 20) };
            pnlProjetos.Controls.Add(lblProjetos);

            // Adiciona os painéis ao contentPanel (na ordem não importa)
            contentPanel.Controls.Add(pnlHoje);
            contentPanel.Controls.Add(pnlEntrada);
            contentPanel.Controls.Add(pnlProjetos);

            // Exibe o painel inicial
            ShowPanel(pnlHoje);
        }

        private Button CriarBotaoMenu(string texto)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btn.Height = 40;
            btn.Dock = DockStyle.Top;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.BackColor = Color.FromArgb(245, 245, 245);
            return btn;
            MessageBox.Show("Você clicou no botão!");
        }

        // Método que mostra um painel e esconde os outros
        private void ShowPanel(Panel painel)
        {
            // se painel for nulo (por segurança) retorna
            if (painel == null) return;

            // traz o painel desejado para frente
            painel.BringToFront();
            painel.Visible = true;

            // opcional: esconder os demais (não estritamente necessário se utilizando BringToFront)
            foreach (Control c in contentPanel.Controls)
            {
                if (c is Panel p && p != painel)
                    p.Visible = false;
            }
        }
    

        private void FrmTelaInicial_Load(object sender, EventArgs e)
        {

        }
    }
}
    

