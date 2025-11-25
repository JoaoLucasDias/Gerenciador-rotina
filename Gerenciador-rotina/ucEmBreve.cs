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
        // Certifique-se de que esta string de conexão está correta.
        private string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

        public ucEmBreve()
        {
            InitializeComponent();
        }

        public void CarregarTarefasEmBreve()
        {
            // Limpa o painel antes de carregar novos dados
            flpTarefas.Controls.Clear();
            // ID de usuário fixo para teste, mas deve ser substituído pelo ID do usuário logado.
            int idUsuario = 3;

            // Função auxiliar para lidar com valores DBNull e evitar crashes.
            Func<SqlDataReader, string, string> safeGetString = (reader, colName) =>
            {
                int colIndex = reader.GetOrdinal(colName);
                if (reader.IsDBNull(colIndex))
                    return string.Empty;
                return reader.GetString(colIndex);
            };

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Query: Seleciona tarefas PENDENTES, do usuário logado e com data no FUTURO.
                    string query = @"
                        SELECT id, titulo, descricao, data_tarefa, STATUS
                        FROM tarefa
                        WHERE ID_USUARIO = @id_usuario
                        AND STATUS = 'Pendente' 
                        AND data_tarefa > GETDATE()
                        ORDER BY data_tarefa ASC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                // Mensagem de que não há tarefas futuras, se for o caso.
                                Label lbl = new Label
                                {
                                    Text = $"Nenhuma tarefa PENDENTE com data futura encontrada para o ID {idUsuario}.",
                                    Font = new Font("Segoe UI", 14, FontStyle.Italic),
                                    ForeColor = Color.Gray,
                                    AutoSize = true,
                                    Margin = new Padding(20)
                                };
                                flpTarefas.Controls.Add(lbl);
                            }

                            while (reader.Read())
                            {
                                try
                                {
                                    var card = new ucCardTarefa();

                                    // Atribuição de propriedades
                                    card.IdTarefa = reader.GetInt32(reader.GetOrdinal("id"));
                                    card.Titulo = safeGetString(reader, "titulo");
                                    card.Descricao = safeGetString(reader, "descricao");
                                    card.Status = safeGetString(reader, "STATUS");

                                    // Tratamento de Data
                                    DateTime dataLida = DateTime.Today;
                                    if (reader["data_tarefa"] != DBNull.Value)
                                    {
                                        dataLida = reader.GetDateTime(reader.GetOrdinal("data_tarefa"));
                                    }
                                    card.DataTarefa = dataLida;

                                    // Configurações de layout (CRÍTICO para exibição correta)
                                    // Garante que o card preencha a largura do FlowLayoutPanel, 
                                    // subtraindo um pouco para margem/padding.
                                    card.Width = flpTarefas.ClientSize.Width - 25;
                                    card.Margin = new Padding(5, 5, 5, 10);

                                    // Ligações de Eventos (para que os botões funcionem)
                                    // NOTA: É importante que os métodos DeletarTarefa, ConcluirTarefa e EditarTarefa
                                    // existam na sua classe ucCardTarefa para que estas ligações funcionem.
                                    card.OnDeletarTarefa += (s, ev) => DeletarTarefa(card.IdTarefa);
                                    card.OnConcluirTarefa += (s, ev) => ConcluirTarefa(card.IdTarefa);
                                    card.OnEditarTarefa += (s, ev) => EditarTarefa(card.IdTarefa);

                                    // Adiciona o Card ao painel
                                    flpTarefas.Controls.Add(card);

                                }
                                catch (Exception ex)
                                {
                                    // Exibe um erro claro se o problema for na criação do card
                                    MessageBox.Show("Erro CRÍTICO ao processar e exibir um Card! Verifique se a classe ucCardTarefa está completa (propriedades e métodos) ou se o nome das colunas está correto no SELECT.\nDetalhes: " + ex.Message, "Erro de Renderização", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    // Interrompe o loop após o primeiro erro para evitar mais problemas
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Este bloco captura qualquer erro de conexão ou de SQL que possa ter ocorrido.
                flpTarefas.Controls.Clear();
                MessageBox.Show(
                    "Erro de Conexão ou Execução SQL. Verifique se o servidor está ativo.\n\nDetalhes: " + ex.Message,
                    "Erro Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // Força o FlowLayoutPanel a redesenhar para garantir que o conteúdo seja exibido
                flpTarefas.PerformLayout();
                flpTarefas.Refresh();
            }
        }

        // --- Implementação dos Métodos de Ação ---

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
                CarregarTarefasEmBreve(); // Recarrega a lista
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
                    using (SqlCommand cmd = new SqlCommand("UPDATE tarefa SET STATUS = 'Concluída' WHERE id = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tarefa marcada como concluída!");
                CarregarTarefasEmBreve(); // Recarrega a lista
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao concluir tarefa: " + ex.Message);
            }
        }

        private void EditarTarefa(int id)
        {
            // O código de edição deve ser implementado aqui, 
            // talvez abrindo um novo formulário com os dados da tarefa para edição.
        }

        private void ucEmBreve_Load(object sender, EventArgs e)
        {
            // O carregamento é feito via FrmTelaInicial
        }

        private void ucEmBreve_Load_1(object sender, EventArgs e)
        {
        }
            
        }
    }
