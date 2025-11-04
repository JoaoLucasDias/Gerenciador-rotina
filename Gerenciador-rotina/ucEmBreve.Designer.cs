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
            this.flpTarefas = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTarefasEmBreve.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpTarefasEmBreve
            // 
            this.flpTarefasEmBreve.AllowDrop = true;
            this.flpTarefasEmBreve.AutoScroll = true;
            this.flpTarefasEmBreve.Controls.Add(this.flpTarefas);
            this.flpTarefasEmBreve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTarefasEmBreve.Location = new System.Drawing.Point(0, 0);
            this.flpTarefasEmBreve.Name = "flpTarefasEmBreve";
            this.flpTarefasEmBreve.Size = new System.Drawing.Size(1700, 1061);
            this.flpTarefasEmBreve.TabIndex = 1;
            this.flpTarefasEmBreve.WrapContents = false;
           
            // 
            // flpTarefas
            // 
            this.flpTarefas.AutoScroll = true;
            this.flpTarefas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTarefas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTarefas.Location = new System.Drawing.Point(3, 3);
            this.flpTarefas.Name = "flpTarefas";
            this.flpTarefas.Size = new System.Drawing.Size(200, 0);
            this.flpTarefas.TabIndex = 0;
            this.flpTarefas.WrapContents = false;
            // 
            // ucEmBreve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpTarefasEmBreve);
            this.Name = "ucEmBreve";
            this.Size = new System.Drawing.Size(1700, 1061);
            this.Load += new System.EventHandler(this.ucEmBreve_Load);
            this.flpTarefasEmBreve.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpTarefasEmBreve;
        private System.Windows.Forms.FlowLayoutPanel flpTarefas;
    }
}
