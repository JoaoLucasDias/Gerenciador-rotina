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
            this.txtbCriarNomeUsuario = new System.Windows.Forms.TextBox();
            this.txtbCriarEmail = new System.Windows.Forms.TextBox();
            this.txtbCriarSenha = new System.Windows.Forms.TextBox();
            this.btnCriarConta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbCriarNomeUsuario
            // 
            this.txtbCriarNomeUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCriarNomeUsuario.BackColor = System.Drawing.Color.OldLace;
            this.txtbCriarNomeUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCriarNomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCriarNomeUsuario.Location = new System.Drawing.Point(1134, 246);
            this.txtbCriarNomeUsuario.Name = "txtbCriarNomeUsuario";
            this.txtbCriarNomeUsuario.Size = new System.Drawing.Size(709, 62);
            this.txtbCriarNomeUsuario.TabIndex = 1;
            // 
            // txtbCriarEmail
            // 
            this.txtbCriarEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCriarEmail.BackColor = System.Drawing.Color.OldLace;
            this.txtbCriarEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCriarEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCriarEmail.Location = new System.Drawing.Point(1134, 445);
            this.txtbCriarEmail.Name = "txtbCriarEmail";
            this.txtbCriarEmail.Size = new System.Drawing.Size(709, 62);
            this.txtbCriarEmail.TabIndex = 2;
            // 
            // txtbCriarSenha
            // 
            this.txtbCriarSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbCriarSenha.BackColor = System.Drawing.Color.OldLace;
            this.txtbCriarSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCriarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCriarSenha.Location = new System.Drawing.Point(1134, 619);
            this.txtbCriarSenha.Name = "txtbCriarSenha";
            this.txtbCriarSenha.PasswordChar = '*';
            this.txtbCriarSenha.Size = new System.Drawing.Size(709, 62);
            this.txtbCriarSenha.TabIndex = 3;
            // 
            // btnCriarConta
            // 
            this.btnCriarConta.BackColor = System.Drawing.Color.Transparent;
            this.btnCriarConta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCriarConta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriarConta.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnCriarConta.FlatAppearance.BorderSize = 0;
            this.btnCriarConta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCriarConta.ForeColor = System.Drawing.Color.Transparent;
            this.btnCriarConta.Location = new System.Drawing.Point(1237, 808);
            this.btnCriarConta.Margin = new System.Windows.Forms.Padding(0);
            this.btnCriarConta.Name = "btnCriarConta";
            this.btnCriarConta.Size = new System.Drawing.Size(504, 126);
            this.btnCriarConta.TabIndex = 5;
            this.btnCriarConta.UseVisualStyleBackColor = false;
            this.btnCriarConta.Click += new System.EventHandler(this.btnCriarConta_Click);
            // 
            // FrmCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.criar2;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.btnCriarConta);
            this.Controls.Add(this.txtbCriarSenha);
            this.Controls.Add(this.txtbCriarEmail);
            this.Controls.Add(this.txtbCriarNomeUsuario);
            this.Name = "FrmCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRIAR CONTA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCreate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbCriarNomeUsuario;
        private System.Windows.Forms.TextBox txtbCriarEmail;
        private System.Windows.Forms.TextBox txtbCriarSenha;
        private System.Windows.Forms.Button btnCriarConta;
    }
}