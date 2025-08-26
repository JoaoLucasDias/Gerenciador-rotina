namespace Gerenciador_rotina
{
    partial class FrmCreate
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
            this.txtbCreateEmail = new System.Windows.Forms.TextBox();
            this.txtbCreateSenha = new System.Windows.Forms.TextBox();
            this.txtbCreateSenha2 = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbCreateEmail
            // 
            this.txtbCreateEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCreateEmail.BackColor = System.Drawing.Color.OldLace;
            this.txtbCreateEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCreateEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCreateEmail.Location = new System.Drawing.Point(1134, 280);
            this.txtbCreateEmail.Name = "txtbCreateEmail";
            this.txtbCreateEmail.Size = new System.Drawing.Size(709, 62);
            this.txtbCreateEmail.TabIndex = 1;
            // 
            // txtbCreateSenha
            // 
            this.txtbCreateSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCreateSenha.BackColor = System.Drawing.Color.OldLace;
            this.txtbCreateSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCreateSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCreateSenha.Location = new System.Drawing.Point(1134, 497);
            this.txtbCreateSenha.Name = "txtbCreateSenha";
            this.txtbCreateSenha.Size = new System.Drawing.Size(709, 62);
            this.txtbCreateSenha.TabIndex = 2;
            // 
            // txtbCreateSenha2
            // 
            this.txtbCreateSenha2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCreateSenha2.BackColor = System.Drawing.Color.OldLace;
            this.txtbCreateSenha2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCreateSenha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCreateSenha2.Location = new System.Drawing.Point(1134, 697);
            this.txtbCreateSenha2.Name = "txtbCreateSenha2";
            this.txtbCreateSenha2.Size = new System.Drawing.Size(709, 62);
            this.txtbCreateSenha2.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.Inserir_um_título__10_;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLogin.Location = new System.Drawing.Point(1324, 782);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(331, 113);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "ENTRAR";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // FrmCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.Inserir_um_título__9_;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtbCreateSenha2);
            this.Controls.Add(this.txtbCreateSenha);
            this.Controls.Add(this.txtbCreateEmail);
            this.Name = "FrmCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRIAR CONTA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbCreateEmail;
        private System.Windows.Forms.TextBox txtbCreateSenha;
        private System.Windows.Forms.TextBox txtbCreateSenha2;
        private System.Windows.Forms.Button btnLogin;
    }
}