using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gerenciador_rotina
{
    // O ucHoje lista tarefas pendentes cuja data é o dia de hoje.
    public partial class ucHoje : UserControl
    {
        public int IdUsuarioLogado { get; set; }

        // **ATENÇÃO:** MANTENHA A SUA STRING DE CONEXÃO CORRETA AQUI!
        // Use a string de conexão que você já utiliza na sua aplicação.
        private string connectionString = @"Data Source=sqlexpress;Initial Catalog=CJ3027716PR2;User ID=aluno;Password=aluno";

        public ucHoje()
        {
            InitializeComponent();
            // Assumimos que você tem um FlowLayoutPanel chamado 'flpHoje' no seu designer.
        }

        // Método para carregar a lista de tarefas de HOJE
        public void CarregarTarefasHoje()
        {
            // 🚨 CORRIGIDO: Usando 'flpHoje' conforme você informou.
            if (flpHoje == null)
            {
                MessageBox.Show("ERRO: O painel 'flpHoje' não foi inicializado no Designer.", "Erro");
                return;
            }

            flpHoje.Controls.Clear();
            int idUsuario = IdUsuarioLogado;

            // SQL: Seleciona tarefas PENDENTES onde a DATA_TAREFA é igual à data de HOJE.
            // CAST(DATA_TAREFA AS DATE) garante que a hora é ignorada, comparando apenas as datas.
            string query = "SELECT ID, TITULO, DESCRICAO, DATA_TAREFA, STATUS, ID_CATEGORIA FROM TAREFA " +
                           "WHERE ID_USUARIO = @ID_USUARIO AND STATUS = 'Pendente' " +
                           "AND CAST(DATA_TAREFA AS DATE) = CAST(GETDATE() AS DATE) " +
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
                                ucCardHoje card = new ucCardHoje();

                                // Preenche as propriedades do Card
                                card.IdTarefa = reader.GetInt32(reader.GetOrdinal("ID"));
                                card.Titulo = GetStringSafe(reader, "TITULO");
                                card.Descricao = GetStringSafe(reader, "DESCRICAO");
                                card.DataTarefa = reader.GetDateTime(reader.GetOrdinal("DATA_TAREFA"));

                                // 🔗 Conecta os eventos do Card com os handlers desta lista
                                card.OnConcluirTarefa += Card_OnConcluirTarefa;
                                card.OnDeletarTarefa += Card_OnDeletarTarefa;
                                card.OnEditarTarefa += Card_OnEditarTarefa;

                                // Adiciona o card ao painel (CORRIGIDO: usando flpHoje)
                                flpHoje.Controls.Add(card);
                            }

                            // Se não houver tarefas (CORRIGIDO: usando flpHoje)
                            if (flpHoje.Controls.Count == 0)
                            {
                                Label lbl = new Label();
                                lbl.Text = "Parabéns! Nenhuma tarefa para hoje. Aproveite o dia!";
                                lbl.AutoSize = true;
                                lbl.Font = new Font(lbl.Font.FontFamily, 12, FontStyle.Bold);
                                // Adiciona a mensagem ao painel (CORRIGIDO: usando flpHoje)
                                flpHoje.Controls.Add(lbl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tarefas de hoje: {ex.Message}", "Erro de Banco de Dados");
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

        // 🏆 HANDLER: Marcar Tarefa como Concluída
        private void Card_OnConcluirTarefa(object sender, EventArgs e)
        {
            ucCardHoje card = sender as ucCardHoje;
            if (card == null) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Altera o STATUS para 'Concluída'
                    string query = "UPDATE TAREFA SET STATUS = 'Concluída' WHERE ID = @ID_TAREFA";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_TAREFA", card.IdTarefa);
                        con.Open();
                        cmd.ExecuteNonQuery();

                        // Recarrega a lista para remover o card concluído
                        CarregarTarefasHoje();
                        // Você pode adicionar um feedback visual aqui, como um MessageBox
                        MessageBox.Show($"Tarefa '{card.Titulo}' concluída com sucesso!", "Sucesso");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao concluir tarefa: {ex.Message}", "Erro de BD");
            }
        }

        // 🗑️ HANDLER: Deletar Tarefa
        private void Card_OnDeletarTarefa(object sender, EventArgs e)
        {
            ucCardHoje card = sender as ucCardHoje;
            if (card == null) return;

            try
            {
                // Implemente aqui um MessageBox customizado para confirmação
                var confirmar = MessageBox.Show($"Deseja realmente apagar a tarefa: '{card.Titulo}'?",
                    "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
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
                            CarregarTarefasHoje();
                            MessageBox.Show("Tarefa deletada com sucesso!", "Sucesso");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao deletar tarefa: {ex.Message}", "Erro de BD");
            }
        }

        // 📝 NOVO HANDLER: Editar Tarefa
        private void Card_OnEditarTarefa(object sender, EventArgs e)
        {
            ucCardHoje card = sender as ucCardHoje;
            if (card == null) return;

            // 💡 Lógica de Edição: 
            // 1. Você precisará de um formulário ou painel de edição (Ex: FrmCadastroTarefa).
            // 2. Você passa o ID da tarefa (card.IdTarefa) para esse formulário/painel.

            MessageBox.Show($"Funcionalidade 'Editar' para a tarefa ID {card.IdTarefa} (Título: {card.Titulo}) será implementada aqui!", "Ação de Edição");

            // Exemplo de como você chamaria o formulário de edição (substitua pelo seu):
            /*
            FrmCadastroTarefa frmEditar = new FrmCadastroTarefa(card.IdTarefa); // Passa o ID
            if (frmEditar.ShowDialog() == DialogResult.OK)
            {
                 // Recarrega a lista se a edição foi bem-sucedida
                 CarregarTarefasHoje();
            }
            */
        }

        // Métodos de eventos do designer (deixe-os vazios ou remova se não for usar)
        private void ucHoje_Load(object sender, EventArgs e)
        {
            // Exemplo: CarregarTarefasHoje(); 
            // Se você chamar aqui, o IdUsuarioLogado deve estar definido antes do Load.
        }
    }
}