namespace Gerenciador_rotina
{
    partial class ucHoje
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
            this.flpHoje = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpHoje
            // 
            this.flpHoje.AutoScroll = true;
            this.flpHoje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpHoje.Location = new System.Drawing.Point(0, 0);
            this.flpHoje.Name = "flpHoje";
            this.flpHoje.Size = new System.Drawing.Size(150, 150);
            this.flpHoje.TabIndex = 0;
            //this.flpHoje.Paint += new System.Windows.Forms.PaintEventHandler(this.flpHoje_Paint);
            // 
            // ucHoje
            // 
            this.Controls.Add(this.flpHoje);
            this.Name = "ucHoje";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpHoje;
    }
}
