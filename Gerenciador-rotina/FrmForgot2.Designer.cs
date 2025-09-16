namespace Gerenciador_rotina
{
    partial class FrmForgot2
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
            this.btnAlterarSenha = new System.Windows.Forms.Button();
            this.txtbNovaSenhaConfirmar = new System.Windows.Forms.TextBox();
            this.txtbNovaSenha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAlterarSenha
            // 
            this.btnAlterarSenha.BackColor = System.Drawing.Color.Transparent;
            this.btnAlterarSenha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAlterarSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterarSenha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlterarSenha.ForeColor = System.Drawing.Color.Transparent;
            this.btnAlterarSenha.Location = new System.Drawing.Point(1181, 731);
            this.btnAlterarSenha.Margin = new System.Windows.Forms.Padding(0);
            this.btnAlterarSenha.Name = "btnAlterarSenha";
            this.btnAlterarSenha.Size = new System.Drawing.Size(510, 123);
            this.btnAlterarSenha.TabIndex = 7;
            this.btnAlterarSenha.UseVisualStyleBackColor = false;
            this.btnAlterarSenha.Click += new System.EventHandler(this.btnAlterarSenha_Click);
            // 
            // txtbNovaSenhaConfirmar
            // 
            this.txtbNovaSenhaConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbNovaSenhaConfirmar.BackColor = System.Drawing.Color.OldLace;
            this.txtbNovaSenhaConfirmar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbNovaSenhaConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbNovaSenhaConfirmar.Location = new System.Drawing.Point(1078, 570);
            this.txtbNovaSenhaConfirmar.Name = "txtbNovaSenhaConfirmar";
            this.txtbNovaSenhaConfirmar.Size = new System.Drawing.Size(709, 62);
            this.txtbNovaSenhaConfirmar.TabIndex = 8;
            this.txtbNovaSenhaConfirmar.TextChanged += new System.EventHandler(this.txtbNovaSenhaConfirmar_TextChanged);
            // 
            // txtbNovaSenha
            // 
            this.txtbNovaSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtbNovaSenha.BackColor = System.Drawing.Color.OldLace;
            this.txtbNovaSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbNovaSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbNovaSenha.Location = new System.Drawing.Point(1078, 375);
            this.txtbNovaSenha.Name = "txtbNovaSenha";
            this.txtbNovaSenha.Size = new System.Drawing.Size(709, 62);
            this.txtbNovaSenha.TabIndex = 9;
            // 
            // FrmForgot2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.REDEFINIÇÃO;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.txtbNovaSenha);
            this.Controls.Add(this.txtbNovaSenhaConfirmar);
            this.Controls.Add(this.btnAlterarSenha);
            this.Name = "FrmForgot2";
            this.Text = "FrmForgot2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAlterarSenha;
        private System.Windows.Forms.TextBox txtbNovaSenhaConfirmar;
        private System.Windows.Forms.TextBox txtbNovaSenha;
    }
}