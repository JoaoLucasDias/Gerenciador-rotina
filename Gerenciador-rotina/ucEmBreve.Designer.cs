namespace Gerenciador_rotina
{
    partial class ucEmBreve
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpTarefas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpTarefas
            // 
            this.flpTarefas.AutoScroll = true;
            this.flpTarefas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flpTarefas.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.INSERIR_CÓDIGO3;
            this.flpTarefas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTarefas.Location = new System.Drawing.Point(0, 0);
            this.flpTarefas.Name = "flpTarefas";
            this.flpTarefas.Size = new System.Drawing.Size(1700, 1061);
            this.flpTarefas.TabIndex = 0;
            this.flpTarefas.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTarefas_Paint);
            // 
            // ucEmBreve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpTarefas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucEmBreve";
            this.Size = new System.Drawing.Size(1700, 1061);
            this.ResumeLayout(false);

        }

        #endregion

        // Declaração da variável flpTarefas, que é inicializada acima
        private System.Windows.Forms.FlowLayoutPanel flpTarefas;
    }
}