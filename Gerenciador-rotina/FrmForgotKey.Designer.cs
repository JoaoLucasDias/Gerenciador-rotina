namespace Gerenciador_rotina
{
    partial class FrmForgotKey
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
            this.btnEnviarCodigo = new System.Windows.Forms.Button();
            this.txtbCodigoVerificacao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEnviarCodigo
            // 
            this.btnEnviarCodigo.BackColor = System.Drawing.Color.Transparent;
            this.btnEnviarCodigo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEnviarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarCodigo.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnEnviarCodigo.FlatAppearance.BorderSize = 0;
            this.btnEnviarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnviarCodigo.ForeColor = System.Drawing.Color.Transparent;
            this.btnEnviarCodigo.Location = new System.Drawing.Point(307, 723);
            this.btnEnviarCodigo.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnviarCodigo.Name = "btnEnviarCodigo";
            this.btnEnviarCodigo.Size = new System.Drawing.Size(509, 126);
            this.btnEnviarCodigo.TabIndex = 6;
            this.btnEnviarCodigo.UseVisualStyleBackColor = false;
            this.btnEnviarCodigo.Click += new System.EventHandler(this.btnEnviarCodigo_Click);
            // 
            // txtbCodigoVerificacao
            // 
            this.txtbCodigoVerificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCodigoVerificacao.BackColor = System.Drawing.Color.OldLace;
            this.txtbCodigoVerificacao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCodigoVerificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCodigoVerificacao.Location = new System.Drawing.Point(209, 463);
            this.txtbCodigoVerificacao.Name = "txtbCodigoVerificacao";
            this.txtbCodigoVerificacao.Size = new System.Drawing.Size(709, 62);
            this.txtbCodigoVerificacao.TabIndex = 7;
            this.txtbCodigoVerificacao.TextChanged += new System.EventHandler(this.txtbCodigoVerificacao_TextChanged);
            // 
            // FrmForgotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.REDEFINIR_SENHA;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.txtbCodigoVerificacao);
            this.Controls.Add(this.btnEnviarCodigo);
            this.Name = "FrmForgotKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmForgotKey";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmForgotKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviarCodigo;
        private System.Windows.Forms.TextBox txtbCodigoVerificacao;
    }
}