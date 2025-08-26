namespace Gerenciador_rotina
{
    partial class FrmLog
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbLogEmail = new System.Windows.Forms.TextBox();
            this.txtbLogSenha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbLogEmail
            // 
            this.txtbLogEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbLogEmail.BackColor = System.Drawing.Color.OldLace;
            this.txtbLogEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbLogEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbLogEmail.Location = new System.Drawing.Point(1144, 415);
            this.txtbLogEmail.Name = "txtbLogEmail";
            this.txtbLogEmail.Size = new System.Drawing.Size(709, 62);
            this.txtbLogEmail.TabIndex = 0;
            // 
            // txtbLogSenha
            // 
            this.txtbLogSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbLogSenha.BackColor = System.Drawing.Color.OldLace;
            this.txtbLogSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbLogSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbLogSenha.Location = new System.Drawing.Point(1144, 638);
            this.txtbLogSenha.Name = "txtbLogSenha";
            this.txtbLogSenha.Size = new System.Drawing.Size(709, 62);
            this.txtbLogSenha.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.Inserir_um_título__8_;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Navy;
            this.btnLogin.Location = new System.Drawing.Point(1337, 743);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(331, 113);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ENTRAR";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCriar
            // 
            this.btnCriar.BackColor = System.Drawing.Color.Transparent;
            this.btnCriar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCriar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCriar.ForeColor = System.Drawing.Color.Transparent;
            this.btnCriar.Location = new System.Drawing.Point(1269, 904);
            this.btnCriar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(469, 48);
            this.btnCriar.TabIndex = 4;
            this.btnCriar.UseVisualStyleBackColor = false;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // FrmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.Inserir_um_título__7_;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtbLogSenha);
            this.Controls.Add(this.txtbLogEmail);
            this.Name = "FrmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbLogEmail;
        private System.Windows.Forms.TextBox txtbLogSenha;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCriar;
    }
}

