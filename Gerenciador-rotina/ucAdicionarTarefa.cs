using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_rotina
{
    public partial class ucAdicionarTarefa : UserControl
    {
        // 🚨 1. PROPRIEDADE PARA RECEBER O ID DO USUÁRIO LOGADO 
        public int IdUsuarioLogado { get; set; }

        // Sua string de conexão (AJUSTE SE NECESSÁRIO)
        private string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

        public ucAdicionarTarefa()
        {
            InitializeComponent();
            this.Load += ucAdicionarTarefa_Load;

            pnlNovaCategoria.Visible = false;
        }

        private void ucAdicionarTarefa_Load(object sender, EventArgs e)
        {
            // Verifica se o ID do usuário foi passado antes de carregar
            if (IdUsuarioLogado > 0)
            {
                CarregarCategorias();
            }
            else
            {
                MessageBox.Show("Erro: ID do usuário logado não foi fornecido.", "Erro de Autenticação");
            }
        }

        // Agora o método usa a propriedade local 'IdUsuarioLogado'
        private void CarregarCategorias()
        {
            // Usamos a propriedade IdUsuarioLogado
            int idUsuario = IdUsuarioLogado;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 1️⃣ Verifica se já existem categorias para o usuário logado
                string checkQuery = "SELECT COUNT(*) FROM Categoria WHERE Id_Usuario = @id_usuario";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                // 💥 CORREÇÃO AQUI: Usa IdUsuarioLogado, não FrmLog.UsuarioLogadoId
                checkCmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                // 2️⃣ Se não houver nenhuma, cria as 3 categorias padrão
                if (count == 0)
                {
                    string insertPadrao = @"
                    INSERT INTO Categoria (Nome_categoria, Id_Usuario) VALUES 
                    ('Estudos', @id_usuario),
                    ('Trabalho', @id_usuario),
                    ('Hobby', @id_usuario)";

                    SqlCommand insertCmd = new SqlCommand(insertPadrao, con);
                    // 💥 CORREÇÃO AQUI
                    insertCmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                    insertCmd.ExecuteNonQuery();
                }

                // 3️⃣ Carrega todas as categorias do usuário
                string query = "SELECT Id, Nome_categoria FROM Categoria WHERE Id_Usuario = @id_usuario";
                SqlCommand cmd = new SqlCommand(query, con);
                // 💥 CORREÇÃO AQUI
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                cmbCategoria.DataSource = dt;
                cmbCategoria.DisplayMember = "Nome_categoria";
                cmbCategoria.ValueMember = "Id";
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            DateTime data = dtpData.Value;

            // Verifica se um valor foi selecionado no ComboBox
            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecione uma categoria válida.", "Erro de Seleção");
                return;
            }

            int idCategoria = (int)cmbCategoria.SelectedValue;
            // 💥 CORREÇÃO AQUI: Usa a propriedade local 'IdUsuarioLogado'
            int idUsuario = IdUsuarioLogado;

            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("Informe um título para a tarefa.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Tarefa (Titulo, Descricao, Data_tarefa, Id_Categoria, Id_Usuario, Status) VALUES (@titulo, @descricao, @data, @id_categoria, @id_usuario, 'Pendente')";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@id_categoria", idCategoria);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario); // ID já corrigido

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tarefa adicionada com sucesso!");
            txtTitulo.Clear();
            txtDescricao.Clear();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seu código aqui, se necessário
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Seu código aqui, se necessário
        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            MostrarPopUpCategoria();
        }

        private void MostrarPopUpCategoria()
        {
            pnlNovaCategoria.Visible = true;
            pnlNovaCategoria.Location = new Point(
                (this.Width - pnlNovaCategoria.Width) / 2,
                (this.Height - pnlNovaCategoria.Height) / 2
            );
            pnlNovaCategoria.BringToFront();
            txtNovaCategoria.Focus();

            pnlNovaCategoria.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void btnSalvarNovaCategoria_Click(object sender, EventArgs e)
        {
            string novaCategoria = txtNovaCategoria.Text.Trim();

            if (string.IsNullOrEmpty(novaCategoria))
            {
                MessageBox.Show("Digite o nome da nova categoria!");
                return;
            }

            // 💥 CORREÇÃO AQUI: Usa a propriedade local 'IdUsuarioLogado'
            int idUsuario = IdUsuarioLogado;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Categoria (Nome_categoria, Id_Usuario) VALUES (@nome, @id_usuario)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nome", novaCategoria);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario); // ID já corrigido
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Categoria adicionada com sucesso!");
            txtNovaCategoria.Clear();
            pnlNovaCategoria.Visible = false;
            CarregarCategorias(); // Recarrega as categorias após adicionar
        }

        private void btnCancelarNovaCategoria_Click(object sender, EventArgs e)
        {
            pnlNovaCategoria.Visible = false;
            txtNovaCategoria.Clear();
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            // Seu código aqui, se necessário
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Seu código aqui, se necessário
        }

        private void pnlNovaCategoria_Paint(object sender, PaintEventArgs e)
        {
            // Seu código aqui, se necessário
        }
    }
}