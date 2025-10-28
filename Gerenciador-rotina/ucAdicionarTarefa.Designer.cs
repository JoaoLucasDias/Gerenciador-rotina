namespace Gerenciador_rotina
{
    partial class ucAdicionarTarefa
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAddCategoria = new System.Windows.Forms.Button();
            this.pnlNovaCategoria = new System.Windows.Forms.Panel();
            this.btnCancelarNovaCategoria = new System.Windows.Forms.Button();
            this.btnSalvarNovaCategoria = new System.Windows.Forms.Button();
            this.txtNovaCategoria = new System.Windows.Forms.TextBox();
            this.lblNovaCategoria = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlNovaCategoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(388, 595);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(119, 43);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(50, 595);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(121, 43);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(48, 462);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoria.TabIndex = 2;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // dtpData
            // 
            this.dtpData.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData.Location = new System.Drawing.Point(50, 339);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(417, 36);
            this.dtpData.TabIndex = 3;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(50, 182);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(457, 91);
            this.txtDescricao.TabIndex = 4;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtTitulo.Location = new System.Drawing.Point(50, 96);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(457, 35);
            this.txtTitulo.TabIndex = 5;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(27, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(295, 37);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Adicionar nova tarefa";
            // 
            // btnAddCategoria
            // 
            this.btnAddCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategoria.Location = new System.Drawing.Point(205, 462);
            this.btnAddCategoria.Name = "btnAddCategoria";
            this.btnAddCategoria.Size = new System.Drawing.Size(74, 30);
            this.btnAddCategoria.TabIndex = 7;
            this.btnAddCategoria.Text = "Adicionar";
            this.btnAddCategoria.UseVisualStyleBackColor = true;
            this.btnAddCategoria.Click += new System.EventHandler(this.btnAddCategoria_Click);
            // 
            // pnlNovaCategoria
            // 
            this.pnlNovaCategoria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlNovaCategoria.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlNovaCategoria.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.AZUL;
            this.pnlNovaCategoria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNovaCategoria.Controls.Add(this.btnCancelarNovaCategoria);
            this.pnlNovaCategoria.Controls.Add(this.btnSalvarNovaCategoria);
            this.pnlNovaCategoria.Controls.Add(this.txtNovaCategoria);
            this.pnlNovaCategoria.Controls.Add(this.lblNovaCategoria);
            this.pnlNovaCategoria.Location = new System.Drawing.Point(643, 96);
            this.pnlNovaCategoria.Name = "pnlNovaCategoria";
            this.pnlNovaCategoria.Size = new System.Drawing.Size(300, 150);
            this.pnlNovaCategoria.TabIndex = 9;
            this.pnlNovaCategoria.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNovaCategoria_Paint);
            // 
            // btnCancelarNovaCategoria
            // 
            this.btnCancelarNovaCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarNovaCategoria.Location = new System.Drawing.Point(21, 108);
            this.btnCancelarNovaCategoria.Name = "btnCancelarNovaCategoria";
            this.btnCancelarNovaCategoria.Size = new System.Drawing.Size(107, 29);
            this.btnCancelarNovaCategoria.TabIndex = 3;
            this.btnCancelarNovaCategoria.Text = "CANCELAR";
            this.btnCancelarNovaCategoria.UseVisualStyleBackColor = true;
            this.btnCancelarNovaCategoria.Click += new System.EventHandler(this.btnCancelarNovaCategoria_Click);
            // 
            // btnSalvarNovaCategoria
            // 
            this.btnSalvarNovaCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarNovaCategoria.Location = new System.Drawing.Point(178, 108);
            this.btnSalvarNovaCategoria.Name = "btnSalvarNovaCategoria";
            this.btnSalvarNovaCategoria.Size = new System.Drawing.Size(107, 29);
            this.btnSalvarNovaCategoria.TabIndex = 2;
            this.btnSalvarNovaCategoria.Text = "SALVAR";
            this.btnSalvarNovaCategoria.UseVisualStyleBackColor = true;
            this.btnSalvarNovaCategoria.Click += new System.EventHandler(this.btnSalvarNovaCategoria_Click);
            // 
            // txtNovaCategoria
            // 
            this.txtNovaCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNovaCategoria.Location = new System.Drawing.Point(21, 53);
            this.txtNovaCategoria.Name = "txtNovaCategoria";
            this.txtNovaCategoria.Size = new System.Drawing.Size(264, 27);
            this.txtNovaCategoria.TabIndex = 1;
            // 
            // lblNovaCategoria
            // 
            this.lblNovaCategoria.AutoSize = true;
            this.lblNovaCategoria.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNovaCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovaCategoria.Location = new System.Drawing.Point(76, 14);
            this.lblNovaCategoria.Name = "lblNovaCategoria";
            this.lblNovaCategoria.Size = new System.Drawing.Size(155, 21);
            this.lblNovaCategoria.TabIndex = 0;
            this.lblNovaCategoria.Text = "Adicionar Categoria";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1073, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 1061);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "Título";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 30);
            this.label3.TabIndex = 13;
            this.label3.Text = "Vencimento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 30);
            this.label4.TabIndex = 14;
            this.label4.Text = "Categoria";
            // 
            // ucAdicionarTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Gerenciador_rotina.Properties.Resources.INSERIR_CÓDIGO3;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlNovaCategoria);
            this.Controls.Add(this.btnAddCategoria);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Name = "ucAdicionarTarefa";
            this.Size = new System.Drawing.Size(1700, 1061);
            this.Load += new System.EventHandler(this.ucAdicionarTarefa_Load);
            this.pnlNovaCategoria.ResumeLayout(false);
            this.pnlNovaCategoria.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAddCategoria;
        private System.Windows.Forms.Panel pnlNovaCategoria;
        private System.Windows.Forms.Button btnCancelarNovaCategoria;
        private System.Windows.Forms.Button btnSalvarNovaCategoria;
        private System.Windows.Forms.TextBox txtNovaCategoria;
        private System.Windows.Forms.Label lblNovaCategoria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
