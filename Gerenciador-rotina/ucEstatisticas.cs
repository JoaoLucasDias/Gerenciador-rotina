using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // 🚨 REQUISITO: Você PRECISA adicionar a referência 'System.Windows.Forms.DataVisualization' ao seu projeto para que este código funcione sem erros CS0246.

namespace Gerenciador_rotina
{
    // O ucEstatisticas exibe métricas de produtividade e distribuição de tarefas.
    public partial class ucEstatisticas : UserControl
    {
        public int IdUsuarioLogado { get; set; }

        // **ATENÇÃO:** MANTENHA A SUA STRING DE CONEXÃO CORRETA AQUI!
        private string connectionString = @"Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas";

        public ucEstatisticas()
        {
            InitializeComponent();
        }

        public void CarregarEstatisticas()
        {
            // Verifica se o ID do usuário está definido
            if (IdUsuarioLogado == 0)
            {
                MessageBox.Show("Erro: ID do usuário não definido.", "Erro");
                return;
            }

            // Assumimos que você tem um FlowLayoutPanel chamado 'flpEstatisticas' no Designer
            if (flpEstatisticas == null)
            {
                MessageBox.Show("ERRO: O FlowLayoutPanel 'flpEstatisticas' não foi inicializado no Designer.", "Erro");
                return;
            }

            flpEstatisticas.Controls.Clear(); // Limpa o painel de conteúdo

            // 1. Visão Geral (Números Chave)
            CarregarNumerosChave();

            // 2. Distribuição por Categoria (Gráfico)
            CarregarGraficoPorCategoria();
        }

        private void CarregarNumerosChave()
        {
            // Obtém os dados de total de tarefas criadas e concluídas
            string queryNumeros = @"
                SELECT 
                    COUNT(ID) AS TotalCriadas,
                    SUM(CASE WHEN STATUS = 'Concluída' THEN 1 ELSE 0 END) AS TotalConcluidas,
                    SUM(CASE WHEN STATUS = 'Pendente' THEN 1 ELSE 0 END) AS TotalPendentes
                FROM TAREFA
                WHERE ID_USUARIO = @ID_USUARIO";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryNumeros, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuarioLogado);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalCriadas = reader.GetInt32(reader.GetOrdinal("TotalCriadas"));
                                int totalConcluidas = reader.GetInt32(reader.GetOrdinal("TotalConcluidas"));
                                int totalPendentes = reader.GetInt32(reader.GetOrdinal("TotalPendentes"));

                                // Calcula a taxa de conclusão
                                double taxaConclusao = totalCriadas > 0 ? ((double)totalConcluidas / totalCriadas) * 100 : 0;

                                // Exibe os números em Labels ou Cards customizados
                                ExibirMetrica("Total Criadas", totalCriadas.ToString(), Color.Navy);
                                ExibirMetrica("Total Concluídas", totalConcluidas.ToString(), Color.Green);
                                ExibirMetrica("Taxa de Conclusão", $"{taxaConclusao:F1}%", Color.DarkCyan);
                                ExibirMetrica("Total Pendentes", totalPendentes.ToString(), Color.OrangeRed);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar números chave: {ex.Message}", "Erro de Banco de Dados");
            }
        }

        // Método auxiliar para criar e adicionar um painel de métrica simples
        private void ExibirMetrica(string titulo, string valor, Color cor)
        {
            Panel pnlMetrica = new Panel();
            pnlMetrica.Size = new Size(200, 100);
            pnlMetrica.BackColor = cor;
            pnlMetrica.Margin = new Padding(10);
            pnlMetrica.Padding = new Padding(10);

            Label lblTitulo = new Label();
            lblTitulo.Text = titulo;
            lblTitulo.Font = new Font("Arial", 10, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.AutoSize = true;

            Label lblValor = new Label();
            lblValor.Text = valor;
            lblValor.Font = new Font("Arial", 24, FontStyle.Bold);
            lblValor.ForeColor = Color.White;
            lblValor.Location = new Point(10, 35);
            lblValor.AutoSize = true;

            pnlMetrica.Controls.Add(lblTitulo);
            pnlMetrica.Controls.Add(lblValor);

            flpEstatisticas.Controls.Add(pnlMetrica); // Adiciona ao FlowLayoutPanel
        }


        private void CarregarGraficoPorCategoria()
        {
            // Obtém a contagem de tarefas por categoria, excluindo categorias sem tarefas
            string queryCategorias = @"
                SELECT 
                    C.NOME_CATEGORIA,
                    COUNT(T.ID) AS TotalTarefas
                FROM TAREFA T
                JOIN CATEGORIA C ON T.ID_CATEGORIA = C.ID
                WHERE T.ID_USUARIO = @ID_USUARIO 
                GROUP BY C.NOME_CATEGORIA
                HAVING COUNT(T.ID) > 0";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryCategorias, con))
                    {
                        cmd.Parameters.AddWithValue("@ID_USUARIO", IdUsuarioLogado);
                        con.Open();

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        // Cria um componente de gráfico dinamicamente
                        Chart chartDistribuicao = new Chart();
                        chartDistribuicao.Size = new Size(600, 350);
                        chartDistribuicao.Margin = new Padding(10);

                        // Configura a área do gráfico
                        ChartArea chartArea = new ChartArea();
                        chartDistribuicao.ChartAreas.Add(chartArea);

                        // Configura a Série (o tipo de gráfico)
                        Series series = new Series
                        {
                            Name = "Distribuicao",
                            IsVisibleInLegend = true,
                            ChartType = SeriesChartType.Pie // Gráfico de Pizza é ótimo para distribuição
                        };

                        // Adiciona as colunas como pontos de dados
                        foreach (DataRow row in dt.Rows)
                        {
                            string categoria = row["NOME_CATEGORIA"].ToString();
                            int total = Convert.ToInt32(row["TotalTarefas"]);
                            series.Points.AddXY(categoria, total);

                            // Formata o rótulo para mostrar o nome da categoria e o total
                            series.Points[series.Points.Count - 1].Label = $"{categoria}: {total}";
                            series.Points[series.Points.Count - 1].LegendText = categoria; // A legenda só precisa do nome
                        }

                        // Configura o Título do Gráfico
                        Title title = new Title("Distribuição de Tarefas por Categoria");
                        title.Font = new Font("Arial", 14, FontStyle.Bold);
                        chartDistribuicao.Titles.Add(title);

                        chartDistribuicao.Series.Add(series);
                        flpEstatisticas.Controls.Add(chartDistribuicao); // Adiciona ao FlowLayoutPanel
                    }
                }
            }
            catch (Exception ex)
            {
                // Este erro ocorre se a referência System.Windows.Forms.DataVisualization não for adicionada!
                MessageBox.Show($"Erro ao gerar gráfico: {ex.Message}\n\nINSTRUÇÃO PARA CORREÇÃO:\nPor favor, adicione a referência 'System.Windows.Forms.DataVisualization' ao seu projeto no Visual Studio. (Clique com o botão direito no projeto > Adicionar > Referência > Assemblies > Pesquisar por DataVisualization).", "Erro de Gráfico - Referência Faltando");
            }
        }
    }
}