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
    public partial class ucEmBreve : UserControl
    {
        public ucEmBreve()
        {
            InitializeComponent();
        }

        private void ucEmBreve_Load(object sender, EventArgs e)
        {
            CarregarTarefasEmBreve();
        }

        private void CarregarTarefasEmBreve()
        {
            flpTarefasEmBreve.Controls.Clear(); // limpa os cards antigos

            string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"
                        SELECT ID, TITULO, DESCRICAO, DATA_TAREFA, status 
                        FROM tarefa 
                        WHERE ID_USUARIO = @idUsuario 
                        AND DATA_TAREFA > GETDATE()
                        ORDER BY DATA_TAREFA ASC";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idUsuario", FrmLog.UsuarioLogadoId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CriarCardTarefa(
                            reader["ID"].ToString(),
                            reader["TITULO"].ToString(),
                            reader["DESCRICAO"].ToString(),
                            Convert.ToDateTime(reader["DATA_TAREFA"]),
                            reader["status"].ToString()
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar tarefas: " + ex.Message);
                }
            }
        }

        private void CriarCardTarefa(string id, string titulo, string descricao, DateTime data, string status)
        {
            // Painel principal do card
            Panel card = new Panel();
            card.Width = 300;
            card.Height = 160;
            card.BackColor = Color.FromArgb(245, 245, 245);
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Padding = new Padding(10);
            card.Margin = new Padding(10);

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTitulo.AutoSize = false;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 25;

            // Descrição
            Label lblDescricao = new Label();
            lblDescricao.Text = descricao.Length > 60 ? descricao.Substring(0, 60) + "..." : descricao;
            lblDescricao.Font = new Font("Segoe UI", 9);
            lblDescricao.ForeColor = Color.Gray;
            lblDescricao.AutoSize = false;
            lblDescricao.Height = 50;
            lblDescricao.Dock = DockStyle.Top;

            // Data
            Label lblData = new Label();
            lblData.Text = "📅 " + data.ToString("dd/MM/yyyy");
            lblData.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblData.ForeColor = Color.FromArgb(80, 80, 80);
            lblData.Dock = DockStyle.Bottom;

            // Botão "Concluir"
            Button btnConcluir = new Button();
            btnConcluir.Text = "✔ Concluir";
            btnConcluir.BackColor = Color.LightGreen;
            btnConcluir.FlatStyle = FlatStyle.Flat;
            btnConcluir.FlatAppearance.BorderSize = 0;
            btnConcluir.Width = 100;
            btnConcluir.Height = 30;
            btnConcluir.Location = new Point(10, 115);
            btnConcluir.Click += (s, e) => ConcluirTarefa(Convert.ToInt32(id));

            // Botão "Editar"
            Button btnEditar = new Button();
            btnEditar.Text = "✏ Editar";
            btnEditar.BackColor = Color.LightBlue;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.Width = 100;
            btnEditar.Height = 30;
            btnEditar.Location = new Point(130, 115);
            btnEditar.Click += (s, e) => EditarTarefa(Convert.ToInt32(id));

            // Adiciona componentes ao card
            card.Controls.Add(lblData);
            card.Controls.Add(btnConcluir);
            card.Controls.Add(btnEditar);
            card.Controls.Add(lblDescricao);
            card.Controls.Add(lblTitulo);

            // Adiciona o card ao FlowLayoutPanel
            flpTarefasEmBreve.Controls.Add(card);
        }

        private void ConcluirTarefa(int idTarefa)
        {
            string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE tarefa SET status = 'Concluída' WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idTarefa);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Tarefa concluída com sucesso!");
                CarregarTarefasEmBreve();
            }
        }

        private void EditarTarefa(int idTarefa)
        {
            MessageBox.Show($"Abrir tela de edição para a tarefa ID: {idTarefa}");
            // Aqui você pode abrir um pequeno formulário modal para editar o título, descrição e data
        }
        

        private void dgvEmBreve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flpTarefasEmBreve_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
