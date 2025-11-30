namespace Gerenciador_rotina
{
    partial class ucEstatisticas
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
            this.flpEstatisticas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpEstatisticas
            // 
            this.flpEstatisticas.AutoScroll = true;
            this.flpEstatisticas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpEstatisticas.Location = new System.Drawing.Point(0, 0);
            this.flpEstatisticas.Name = "flpEstatisticas";
            this.flpEstatisticas.Size = new System.Drawing.Size(150, 150);
            this.flpEstatisticas.TabIndex = 0;
            //this.flpEstatisticas.Paint += new System.Windows.Forms.PaintEventHandler(this.flpEstatisticas_Paint);
            // 
            // ucEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpEstatisticas);
            this.Name = "ucEstatisticas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpEstatisticas;
    }
}
