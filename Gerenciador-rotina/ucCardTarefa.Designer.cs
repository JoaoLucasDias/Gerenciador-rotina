﻿namespace Gerenciador_rotina
{
    partial class ucCardTarefa
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
            this.pnlDescricao = new System.Windows.Forms.Panel();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblFaltam = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.btnExpandir = new System.Windows.Forms.Button();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.pnlDescricao.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDescricao
            // 
            this.pnlDescricao.AutoScroll = true;
            this.pnlDescricao.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlDescricao.Controls.Add(this.lblDescricao);
            this.pnlDescricao.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlDescricao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescricao.Location = new System.Drawing.Point(0, 70);
            this.pnlDescricao.Name = "pnlDescricao";
            this.pnlDescricao.Size = new System.Drawing.Size(1698, 29);
            this.pnlDescricao.TabIndex = 1;
            this.pnlDescricao.Visible = false;
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.White;
            this.pnlTopo.Controls.Add(this.btnExpandir);
            this.pnlTopo.Controls.Add(this.btnConcluir);
            this.pnlTopo.Controls.Add(this.btnDeletar);
            this.pnlTopo.Controls.Add(this.btnEditar);
            this.pnlTopo.Controls.Add(this.lblFaltam);
            this.pnlTopo.Controls.Add(this.lblData);
            this.pnlTopo.Controls.Add(this.lblTitulo);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlTopo.Size = new System.Drawing.Size(1698, 70);
            this.pnlTopo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label1";
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(300, 10);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(120, 20);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "label1";
            // 
            // lblFaltam
            // 
            this.lblFaltam.Location = new System.Drawing.Point(440, 10);
            this.lblFaltam.Name = "lblFaltam";
            this.lblFaltam.Size = new System.Drawing.Size(100, 20);
            this.lblFaltam.TabIndex = 2;
            this.lblFaltam.Text = "label1";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(560, 10);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 30);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(650, 10);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(80, 30);
            this.btnDeletar.TabIndex = 4;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // btnConcluir
            // 
            this.btnConcluir.Location = new System.Drawing.Point(740, 10);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(90, 30);
            this.btnConcluir.TabIndex = 5;
            this.btnConcluir.Text = "CONCLUIR";
            this.btnConcluir.UseVisualStyleBackColor = true;
            // 
            // btnExpandir
            // 
            this.btnExpandir.Location = new System.Drawing.Point(3, 41);
            this.btnExpandir.Name = "btnExpandir";
            this.btnExpandir.Size = new System.Drawing.Size(75, 23);
            this.btnExpandir.TabIndex = 6;
            this.btnExpandir.Text = "Expandir";
            this.btnExpandir.UseVisualStyleBackColor = true;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(9, 3);
            this.lblDescricao.MaximumSize = new System.Drawing.Size(1500, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(52, 21);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "label1";
            // 
            // ucCardTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlDescricao);
            this.Controls.Add(this.pnlTopo);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "ucCardTarefa";
            this.Size = new System.Drawing.Size(1698, 98);
            this.pnlDescricao.ResumeLayout(false);
            this.pnlDescricao.PerformLayout();
            this.pnlTopo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDescricao;
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnExpandir;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblFaltam;
        private System.Windows.Forms.Label lblDescricao;
    }
}
