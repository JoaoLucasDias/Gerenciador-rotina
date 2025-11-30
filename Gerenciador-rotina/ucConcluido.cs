using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gerenciador_rotina
{
    // A classe ucConcluido deve ser 'partial'
    public partial class ucConcluido : UserControl
    {
        // Propriedade para receber o ID do usuário logado (MANTIDA AQUI)
        public int IdUsuarioLogado { get; set; }

        // Sua string de conexão (MANTIDA AQUI)
        // **ATENÇÃO:** MANTENHA A SUA STRING DE CONEXÃO CORRETA AQUI!
        private string connectionString = @"Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas"; 

        public ucConcluido()
        {
            InitializeComponent();
            // Assumimos que você tem um FlowLayoutPanel chamado 'flpConcluidas' no seu designer.
        }

        // Método chamado pela FrmTelaInicial para carregar a lista
        public void CarregarTarefasConcluidas()
        {
            // Verifica se o FlowLayoutPanel existe (boa prática)
            // 🚨 ATENÇÃO: Certifique-se de que 'flpConcluidas' está declarado no ucConcluido.Designer.cs
            if (flpConcluidas == null)
            {
                MessageBox.Show("ERRO: O painel 'flpConcluidas' não foi inicializado no Designer.", "Erro");
                return;
            }

            flpConcluidas.Controls.Clear();
            int idUsuario = IdUsuarioLogado;
            
            // SQL para selecionar todas as tarefas CONCLUÍDAS
            string query = "SELECT ID, TITULO, DESCRICAO, DATA_TAREFA, STATUS, ID_CATEGORIA FROM TAREFA " +
                           "WHERE ID_USUARIO = @ID_USUARIO AND STATUS = 'Concluída' " +
                           "ORDER BY DATA_TAREFA DESC"; 

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
                                // 💡 INSTANCIANDO O NOVO CARD!
                                // 🚨 ATENÇÃO: Certifique-se de que 'ucCardConcluido' está no namespace 'Gerenciador_rotina' (CS0246)
                                // O ucCardConcluido deve ter a funcionalidade visual de "Concluído"
                                ucCardConcluido card = new ucCardConcluido();
                                
                                // Preenche as propriedades do Card
                                card.IdTarefa = reader.GetInt32(reader.GetOrdinal("ID"));
                                card.Titulo = GetStringSafe(reader, "TITULO");
                                card.Descricao = GetStringSafe(reader, "DESCRICAO");
                                card.DataTarefa = reader.GetDateTime(reader.GetOrdinal("DATA_TAREFA"));
                                
                                // Conecta o evento de deletar
                                card.OnDeletarTarefa += Card_OnDeletarTarefa; 
                                // 🆕 Conecta o evento de restaurar (IMPORTANTE: Garante que este evento exista no ucCardConcluido)
                                card.OnRestaurarTarefa += Card_OnRestaurarTarefa;
                                
                                // Adiciona o card ao painel
                                flpConcluidas.Controls.Add(card);
                            }
                            
                            if (flpConcluidas.Controls.Count == 0)
                            {
                                Label lbl = new Label();
                                lbl.Text = "Nenhuma tarefa concluída encontrada.";
                                lbl.AutoSize = true;
                                lbl.Font = new Font(lbl.Font.FontFamily, 12, FontStyle.Bold);
                                flpConcluidas.Controls.Add(lbl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tarefas concluídas: {ex.Message}", "Erro de Banco de Dados");
            }
        }
        
        // Função auxiliar para lidar com valores DBNull
        private string GetStringSafe(SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);
            if (reader.IsDBNull(colIndex))
                return string.Empty;
            return reader.GetString(colIndex);
        }

        // 🗑️ Deletar Tarefa individualmente - Usa o evento OnDeletarTarefa
        private void Card_OnDeletarTarefa(object sender, EventArgs e)
        {
            ucCardConcluido card = sender as ucCardConcluido;
            if (card == null) return;
            
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM TAREFA WHERE ID = @ID_TAREFA";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_TAREFA", card.IdTarefa);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        
                        // Recarrega a lista após deletar
                        CarregarTarefasConcluidas();
                    }
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show($"Erro ao deletar tarefa: {ex.Message}", "Erro de BD");
            }
        }

        // ↩️ Lógica de Restaurar Tarefa - Usa o evento OnRestaurarTarefa
        private void Card_OnRestaurarTarefa(object sender, EventArgs e)
        {
            ucCardConcluido card = sender as ucCardConcluido;
            if (card == null) return;
            
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Atualiza o STATUS da tarefa para 'Pendente'
                    string query = "UPDATE TAREFA SET STATUS = 'Pendente' WHERE ID = @ID_TAREFA";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_TAREFA", card.IdTarefa);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Tarefa restaurada com sucesso! Ela voltará para a lista 'Em Breve'.", "Sucesso");
                        
                        // Recarrega a lista, removendo o card restaurado
                        CarregarTarefasConcluidas();
                    }
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show($"Erro ao restaurar tarefa: {ex.Message}", "Erro de BD");
            }
        }
        
        // Se você tem um botão "Limpar Tudo" no ucConcluido, você pode usar este evento:
        private void btnLimparTudo_Click(object sender, EventArgs e)
        {
            // O erro CS0102 indica que este método pode estar definido mais de uma vez.
            // Verifique se ele só existe UMA vez.
            var confirmar = MessageBox.Show("ATENÇÃO: Deseja apagar permanentemente TODAS as tarefas concluídas?",
                "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
            {
                ApagarTodasConcluidas();
            }
        }

        // Lógica para apagar todas as tarefas concluídas do usuário
        private void ApagarTodasConcluidas()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Deleta todas as tarefas onde o STATUS é 'Concluída' para o usuário logado
                    string query = "DELETE FROM TAREFA WHERE ID_USUARIO = @ID_USUARIO AND STATUS = 'Concluída'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuarioLogado);
                        con.Open();
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                        MessageBox.Show($"{rowsAffected} tarefas concluídas foram apagadas.", "Limpeza Concluída");
                        
                        // Recarrega a lista
                        CarregarTarefasConcluidas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao apagar tarefas concluídas: {ex.Message}", "Erro de Banco de Dados");
            }
        }

        private void flpConcluidas_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}