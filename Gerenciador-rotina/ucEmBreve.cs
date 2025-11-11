using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gerenciador_rotina
{
    public partial class ucEmBreve : UserControl
    {
        // Conexão mais limpa, baseada no nome da instância 'SQLEXPRESS'.
        private string connectionString = @"Data Source=SQLEXPRESS;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

        public ucEmBreve()
        {
            InitializeComponent();
        }

        private void ucEmBreve_Load(object sender, EventArgs e)
        {
            // A chamada deve ser feita pelo FrmTelaInicial
        }

        public void CarregarTarefasEmBreve()
        {
            flpTarefas.Controls.Clear();

            // Função auxiliar para lidar com valores DBNull e evitar crashes
            Func<SqlDataReader, string, string> safeGetString = (reader, colName) =>
            {
                int colIndex = reader.GetOrdinal(colName);
                if (reader.IsDBNull(colIndex))
                    return string.Empty;
                return reader.GetString(colIndex);
            };

            try
            {
                // *** ID FORÇADO PARA TESTE ***
                int idUsuario = 3;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Tenta abrir a conexão.
                    con.Open();

                    // Se a conexão abrir, este log aparece na Janela de Saída do Visual Studio
                    System.Diagnostics.Debug.WriteLine("DEBUG: Conexão SQL aberta com sucesso!");

                    // MUDANÇA: Query de TESTE: BUSCA QUALQUER TAREFA (PENDENTE OU CONCLUÍDA) do ID 3
                    string query = @"
                        SELECT id, titulo, descricao, data_tarefa, status
                        FROM tarefa
                        WHERE id_usuario = @id_usuario
                        ORDER BY data_tarefa ASC"; // Removida a condição de status


                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Label lbl = new Label
                                {
                                    // Mensagem em vermelho de DEBUG para saber se a conexão abriu
                                    Text = "DEBUG: Conexão OK, mas nenhuma tarefa foi encontrada para o ID 3 (Adicione uma tarefa no DB)",
                                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                                    ForeColor = Color.Red,
                                    AutoSize = true,
                                    Margin = new Padding(20)
                                };
                                flpTarefas.Controls.Add(lbl);
                            }

                            while (reader.Read()) // 🛑 COLOQUE O BREAKPOINT AQUI
                            {
                                var card = new ucCardTarefa
                                {
                                    IdTarefa = reader.GetInt32(reader.GetOrdinal("id")),
                                    Titulo = safeGetString(reader, "titulo"),
                                    Descricao = safeGetString(reader, "descricao"),
                                    Status = safeGetString(reader, "status")
                                };

                                // TRATAMENTO DE DATA: Evita quebra se a data estiver nula ou inválida
                                DateTime dataLida = DateTime.Today.AddDays(1); // Valor padrão de fallback
                                try
                                {
                                    // Tenta obter a data; se for DBNull, a exceção é pega e o fallback é usado.
                                    if (reader["data_tarefa"] != DBNull.Value)
                                    {
                                        dataLida = reader.GetDateTime(reader.GetOrdinal("data_tarefa"));
                                    }
                                }
                                catch (Exception)
                                {
                                    // Ignora exceções de conversão (se o tipo da coluna estiver errado) e usa o fallback.
                                    dataLida = DateTime.Today.AddDays(1);
                                }

                                card.DataTarefa = dataLida; // Atribui a data (lida ou fallback)

                                card.Width = Math.Max(300, flpTarefas.ClientSize.Width - 10);
                                card.Margin = new Padding(5, 5, 5, 10);

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
                // Se esta caixa de erro aparecer, o nome do servidor ainda está incorreto!
                MessageBox.Show("ERRO CRÍTICO DE CONEXÃO. Por favor, verifique se o nome do servidor SQL é 'SQLEXPRESS' (sem ponto). Detalhes: " + ex.Message, "Erro de Conexão SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flpTarefas.PerformLayout();
                flpTarefas.Refresh();
            }
        }

        // Métodos DeletarTarefa, ConcluirTarefa e EditarTarefa (não alterados)
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
            // O código de edição deve ser implementado aqui.
        }

        private void flpTarefasEmBreve_Paint(object sender, PaintEventArgs e)
        {
            // Método de Paint não precisa de código
        }
    }
}