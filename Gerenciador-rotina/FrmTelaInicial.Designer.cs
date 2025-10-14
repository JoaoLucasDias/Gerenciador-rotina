namespace Gerenciador_rotina
{
    partial class FrmTelaInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAdicionarTarefa = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEstatistica = new System.Windows.Forms.Button();
            this.btnConcluido = new System.Windows.Forms.Button();
            this.btnHoje = new System.Windows.Forms.Button();
            this.btnEmBreve = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.INSERIR_CÓDIGO2;
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(224, 0);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(1700, 1061);
            this.pnlConteudo.TabIndex = 4;
            this.pnlConteudo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlConteudo_Paint);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.pnlMenu.Controls.Add(this.btnAdicionarTarefa);
            this.pnlMenu.Controls.Add(this.btnBuscar);
            this.pnlMenu.Controls.Add(this.btnEstatistica);
            this.pnlMenu.Controls.Add(this.btnConcluido);
            this.pnlMenu.Controls.Add(this.btnHoje);
            this.pnlMenu.Controls.Add(this.btnEmBreve);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(224, 1061);
            this.pnlMenu.TabIndex = 3;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
            // 
            // btnAdicionarTarefa
            // 
            this.btnAdicionarTarefa.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.btnAdicionarTarefa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarTarefa.FlatAppearance.BorderSize = 0;
            this.btnAdicionarTarefa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarTarefa.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarTarefa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdicionarTarefa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarTarefa.ImageKey = "(nenhum/a)";
            this.btnAdicionarTarefa.Location = new System.Drawing.Point(0, 121);
            this.btnAdicionarTarefa.Name = "btnAdicionarTarefa";
            this.btnAdicionarTarefa.Size = new System.Drawing.Size(224, 76);
            this.btnAdicionarTarefa.TabIndex = 6;
            this.btnAdicionarTarefa.Text = "➕ Adicionar Tarefa";
            this.btnAdicionarTarefa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarTarefa.UseVisualStyleBackColor = true;
            this.btnAdicionarTarefa.Click += new System.EventHandler(this.btnAdicionarTarefa_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageKey = "(nenhum/a)";
            this.btnBuscar.Location = new System.Drawing.Point(0, 203);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(224, 76);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "🔎 Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEstatistica
            // 
            this.btnEstatistica.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.btnEstatistica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstatistica.FlatAppearance.BorderSize = 0;
            this.btnEstatistica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstatistica.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstatistica.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEstatistica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstatistica.ImageKey = "(nenhum/a)";
            this.btnEstatistica.Location = new System.Drawing.Point(0, 635);
            this.btnEstatistica.Name = "btnEstatistica";
            this.btnEstatistica.Size = new System.Drawing.Size(221, 76);
            this.btnEstatistica.TabIndex = 4;
            this.btnEstatistica.Text = "📈 Estatísticas";
            this.btnEstatistica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstatistica.UseVisualStyleBackColor = true;
            this.btnEstatistica.Click += new System.EventHandler(this.btnEstatistica_Click);
            // 
            // btnConcluido
            // 
            this.btnConcluido.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.btnConcluido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConcluido.FlatAppearance.BorderSize = 0;
            this.btnConcluido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluido.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConcluido.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConcluido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConcluido.ImageKey = "(nenhum/a)";
            this.btnConcluido.Location = new System.Drawing.Point(0, 517);
            this.btnConcluido.Name = "btnConcluido";
            this.btnConcluido.Size = new System.Drawing.Size(221, 76);
            this.btnConcluido.TabIndex = 3;
            this.btnConcluido.Text = "✅ Concluído";
            this.btnConcluido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConcluido.UseVisualStyleBackColor = true;
            this.btnConcluido.Click += new System.EventHandler(this.btnConcluido_Click);
            // 
            // btnHoje
            // 
            this.btnHoje.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.btnHoje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoje.FlatAppearance.BorderSize = 0;
            this.btnHoje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoje.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoje.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHoje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoje.ImageKey = "(nenhum/a)";
            this.btnHoje.Location = new System.Drawing.Point(0, 353);
            this.btnHoje.Name = "btnHoje";
            this.btnHoje.Size = new System.Drawing.Size(221, 76);
            this.btnHoje.TabIndex = 0;
            this.btnHoje.Text = "⌚ Hoje";
            this.btnHoje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoje.UseVisualStyleBackColor = true;
            this.btnHoje.Click += new System.EventHandler(this.btnHoje_Click);
            // 
            // btnEmBreve
            // 
            this.btnEmBreve.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.btnEmBreve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmBreve.FlatAppearance.BorderSize = 0;
            this.btnEmBreve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmBreve.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmBreve.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEmBreve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmBreve.ImageKey = "(nenhum/a)";
            this.btnEmBreve.Location = new System.Drawing.Point(3, 435);
            this.btnEmBreve.Name = "btnEmBreve";
            this.btnEmBreve.Size = new System.Drawing.Size(221, 76);
            this.btnEmBreve.TabIndex = 2;
            this.btnEmBreve.Text = "📅  Em Breve";
            this.btnEmBreve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmBreve.UseVisualStyleBackColor = true;
            this.btnEmBreve.Click += new System.EventHandler(this.btnEmBreve_Click);
            // 
            // FrmTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTelaInicial";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTelaInicial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTelaInicial_Load);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnHoje;
        private System.Windows.Forms.Button btnEmBreve;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Button btnConcluido;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEstatistica;
        private System.Windows.Forms.Button btnAdicionarTarefa;
    }
}