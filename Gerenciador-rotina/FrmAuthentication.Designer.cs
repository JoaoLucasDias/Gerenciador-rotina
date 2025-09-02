namespace Gerenciador_rotina
{
    partial class FrmAuthentication
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
            this.txtbCodigoAutenticacao = new System.Windows.Forms.TextBox();
            this.btnAutenticar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbCodigoAutenticacao
            // 
            this.txtbCodigoAutenticacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCodigoAutenticacao.BackColor = System.Drawing.Color.OldLace;
            this.txtbCodigoAutenticacao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCodigoAutenticacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCodigoAutenticacao.Location = new System.Drawing.Point(618, 483);
            this.txtbCodigoAutenticacao.Name = "txtbCodigoAutenticacao";
            this.txtbCodigoAutenticacao.Size = new System.Drawing.Size(709, 62);
            this.txtbCodigoAutenticacao.TabIndex = 1;
            // 
            // btnAutenticar
            // 
            this.btnAutenticar.BackColor = System.Drawing.Color.Transparent;
            this.btnAutenticar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAutenticar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutenticar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAutenticar.ForeColor = System.Drawing.Color.Transparent;
            this.btnAutenticar.Location = new System.Drawing.Point(708, 611);
            this.btnAutenticar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutenticar.Name = "btnAutenticar";
            this.btnAutenticar.Size = new System.Drawing.Size(504, 126);
            this.btnAutenticar.TabIndex = 7;
            this.btnAutenticar.UseVisualStyleBackColor = false;
            // 
            // FrmAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.INSERIR_CÓDIGO1;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.btnAutenticar);
            this.Controls.Add(this.txtbCodigoAutenticacao);
            this.Name = "FrmAuthentication";
            this.Text = "FrmAuthentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbCodigoAutenticacao;
        private System.Windows.Forms.Button btnAutenticar;
    }
}