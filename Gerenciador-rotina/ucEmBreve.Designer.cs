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
            this.flpTarefasEmBreve = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpTarefasEmBreve
            // 
            this.flpTarefasEmBreve.AutoScroll = true;
            this.flpTarefasEmBreve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTarefasEmBreve.Location = new System.Drawing.Point(0, 0);
            this.flpTarefasEmBreve.Name = "flpTarefasEmBreve";
            this.flpTarefasEmBreve.Size = new System.Drawing.Size(1700, 1061);
            this.flpTarefasEmBreve.TabIndex = 1;
            this.flpTarefasEmBreve.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTarefasEmBreve_Paint);
            // 
            // ucEmBreve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpTarefasEmBreve);
            this.Name = "ucEmBreve";
            this.Size = new System.Drawing.Size(1700, 1061);
            this.Load += new System.EventHandler(this.ucEmBreve_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpTarefasEmBreve;
    }
}
