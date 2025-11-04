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
        private string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";
        public ucEmBreve()
        {
            InitializeComponent();
            this.Load += ucEmBreve_Load;
        }

        private void ucEmBreve_Load(object sender, EventArgs e)
        {
            CarregarTarefasEmBreve();
        }

        public void CarregarTarefasEmBreve()
        {
            flpTarefas.Controls.Clear();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"
                        SELECT id, titulo, descricao, data_tarefa, status
                        FROM tarefa
                        WHERE id_usuario = @id_usuario
                        AND status <> 'Concluída'
                        AND CAST(data_tarefa AS DATE) > CAST(GETDATE() AS DATE)
                        ORDER BY data_tarefa ASC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", FrmLog.UsuarioLogadoId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Label lbl = new Label
                                {
                                    Text = "Nenhuma tarefa 'Em breve' encontrada!",
                                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                                    ForeColor = Color.Gray,
                                    AutoSize = true,
                                    Margin = new Padding(20)
                                };
                                flpTarefas.Controls.Add(lbl);
                                return;
                            }

                            while (reader.Read())
                            {
                                var card = new ucCardTarefa
                                {
                                    IdTarefa = Convert.ToInt32(reader["id"]),
                                    Titulo = reader["titulo"].ToString(),
                                    Descricao = reader["descricao"].ToString(),
                                    Status = reader["status"].ToString()
                                };

                                if (DateTime.TryParse(reader["data_tarefa"].ToString(), out DateTime dt))
                                    card.DataTarefa = dt;

                                // Ajustes visuais do card
                                card.Width = Math.Max(300, flpTarefas.ClientSize.Width - 40);
                                card.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                                card.Margin = new Padding(10);

                                // Subscrição dos eventos (usa closure para capturar IdTarefa)
                                card.OnDeletarTarefa += (s, ev) => DeletarTarefa(card.IdTarefa);
                                card.OnConcluirTarefa += (s, ev) => ConcluirTarefa(card.IdTarefa);
                                card.OnEditarTarefa += (s, ev) => EditarTarefa(card.IdTarefa);

                                flpTarefas.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tarefas: " + ex.Message);
            }
        }

        private void DeletarTarefa(int id)
        {
            var confirmar = MessageBox.Show("Deseja realmente excluir esta tarefa?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tarefa WHERE id = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tarefa excluída com sucesso!");
                CarregarTarefasEmBreve();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar tarefa: " + ex.Message);
            }
        }

        private void ConcluirTarefa(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE tarefa SET status = 'Concluída' WHERE id = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tarefa marcada como concluída!");
                CarregarTarefasEmBreve();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao concluir tarefa: " + ex.Message);
            }
        }

        private void EditarTarefa(int id)
        {
            // Se tiver um formulário de edição, abra aqui. Exemplo básico sem formulário:
            /*using (FrmEditarTarefa frm = new FrmEditarTarefa(id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    CarregarTarefasEmBreve();
            }*/
        }
    }
}
