namespace Gerenciador_rotina
{
    partial class ucConcluido
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
            this.flpConcluidas = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLimparTudo = new System.Windows.Forms.Button();
            this.flpConcluidas.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpConcluidas
            // 
            this.flpConcluidas.AutoScroll = true;
            this.flpConcluidas.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.INSERIR_CÓDIGO2;
            this.flpConcluidas.Controls.Add(this.btnLimparTudo);
            this.flpConcluidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpConcluidas.Location = new System.Drawing.Point(0, 0);
            this.flpConcluidas.Name = "flpConcluidas";
            this.flpConcluidas.Size = new System.Drawing.Size(1700, 1061);
            this.flpConcluidas.TabIndex = 1;
            this.flpConcluidas.Paint += new System.Windows.Forms.PaintEventHandler(this.flpConcluidas_Paint);
            // 
            // btnLimparTudo
            // 
            this.btnLimparTudo.Location = new System.Drawing.Point(3, 3);
            this.btnLimparTudo.Name = "btnLimparTudo";
            this.btnLimparTudo.Size = new System.Drawing.Size(75, 23);
            this.btnLimparTudo.TabIndex = 1;
            this.btnLimparTudo.Text = "LIMPAR TUDO";
            this.btnLimparTudo.UseVisualStyleBackColor = true;
            // 
            // ucConcluido
            // 
            this.Controls.Add(this.flpConcluidas);
            this.Name = "ucConcluido";
            this.Size = new System.Drawing.Size(1700, 1061);
            this.flpConcluidas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpConcluidas;
        private System.Windows.Forms.Button btnLimparTudo;
    }
}
