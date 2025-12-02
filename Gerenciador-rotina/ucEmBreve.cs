using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Adicionado para operações de banco de dados

namespace Gerenciador_rotina
{
    public partial class ucEmBreve : UserControl
    {
        // 1. PROPRIEDADE PÚBLICA CORRIGIDA
        public int IdUsuarioLogado { get; set; }

        // Sua string de conexão (certifique-se de que está correta)
        private string connectionString = @"Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas";

        public ucEmBreve()
        {
            InitializeComponent();
        }

        // Lógica para marcar a tarefa como concluída no BD
        private void Card_OnConcluirTarefa(object sender, EventArgs e)
        {
            ucCardTarefa card = sender as ucCardTarefa;
            if (card == null) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Query para mudar o status da tarefa para 'Concluída'
                    string query = "UPDATE TAREFA SET STATUS = 'Concluída' WHERE ID = @ID_TAREFA AND ID_USUARIO = @ID_USUARIO";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_TAREFA", card.IdTarefa);
                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuarioLogado);
                        con.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Tarefa concluída com sucesso!", "Parabéns!");

                        // 💥 RECARREGA A LISTA: Isso fará com que a tarefa desapareça da tela atual
                        CarregarTarefasEmBreve();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao concluir tarefa: {ex.Message}", "Erro de Banco de Dados");
            }
        }

        public void CarregarTarefasEmBreve()
        {
            // PONTO CRÍTICO CORRIGIDO: O flpTarefas DEVE existir no designer.
            // Certifique-se de que o FlowLayoutPanel no designer se chama 'flpTarefas'.
            // (Assumindo que flpTarefas foi declarado no seu designer.cs)
            // if (flpTarefas == null) { /* ... (mensagem de erro) ... */ return; }

            // Limpa o painel antes de carregar novos dados
            flpTarefas.Controls.Clear();

            // Variável Local 
            int idUsuario = IdUsuarioLogado; // Usa a propriedade pública

            // SQL para selecionar tarefas que não estão concluídas e estão no futuro
            string query = "SELECT ID, TITULO, DESCRICAO, DATA_TAREFA, STATUS, ID_CATEGORIA FROM TAREFA " +
                           "WHERE ID_USUARIO = @ID_USUARIO AND STATUS = 'Pendente' AND DATA_TAREFA > GETDATE() " +
                           "ORDER BY DATA_TAREFA ASC";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_USUARIO", idUsuario);

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Cria o Card de Tarefa
                                ucCardTarefa card = new ucCardTarefa();

                                // Preenche as propriedades do Card, usando GetStringSafe para DESCRICAO
                                card.IdTarefa = reader.GetInt32(reader.GetOrdinal("ID"));
                                card.Titulo = GetStringSafe(reader, "TITULO");
                                card.Descricao = GetStringSafe(reader, "DESCRICAO");
                                card.DataTarefa = reader.GetDateTime(reader.GetOrdinal("DATA_TAREFA"));
                                // card.Status = reader.GetString(reader.GetOrdinal("STATUS")); // Não necessário se o status é fixo

                                // 🔑 CONEXÃO DO EVENTO: Quando o botão Concluir no card for clicado, 
                                // ele chamará Card_OnConcluirTarefa, que atualiza o BD e recarrega a lista.
                                card.OnConcluirTarefa += Card_OnConcluirTarefa;

                                // Adiciona o card ao painel
                                flpTarefas.Controls.Add(card);
                            }

                            // Adiciona uma mensagem se não houver tarefas
                            if (flpTarefas.Controls.Count == 0)
                            {
                                Label lbl = new Label();
                                lbl.Text = "Nenhuma tarefa 'Em Breve' encontrada. Que tal adicionar uma?";
                                lbl.AutoSize = true;
                                lbl.Font = new Font(lbl.Font.FontFamily, 12, FontStyle.Italic);
                                flpTarefas.Controls.Add(lbl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe o erro de forma mais amigável
                MessageBox.Show($"Erro ao carregar tarefas 'Em Breve': {ex.Message}", "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função auxiliar para lidar com valores DBNull e evitar crashes (MUITO IMPORTANTE)
        private string GetStringSafe(SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);
            // Verifica se o valor é nulo no banco de dados
            if (reader.IsDBNull(colIndex))
                return string.Empty; // Retorna string vazia em caso de NULL
            return reader.GetString(colIndex);
        }

        // Evento de carregamento do UserControl (manter vazio)
        private void ucEmBreve_Load(object sender, EventArgs e) { }

        private void flpTarefas_Paint(object sender, PaintEventArgs e) { }
    }
}