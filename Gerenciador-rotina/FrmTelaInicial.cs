using System;
using System.Data.SqlClient; // Importa a biblioteca necessária para trabalhar com SQL Server (conexão e comandos)
using System.Windows.Forms; // Importa a biblioteca para criar a interface gráfica (formulários, botões, etc.)
using System.Drawing; // Importa a biblioteca para trabalhar com elementos visuais (cores, pontos, etc.)

namespace Gerenciador_rotina
{
    // Define a classe principal do formulário, que é a tela inicial da aplicação
    public partial class FrmTelaInicial : Form
    {
        // 1. Variável para armazenar o ID do usuário que acabou de fazer login
        private int _idUsuarioLogado;

        // 2. Declaração das variáveis para cada uma das telas de conteúdo (UserControls)
        private ucHoje telaHoje;
        private ucEmBreve telaEmBreve;
        private ucAdicionarTarefa telaAdicionar;
        private ucBuscar telaBuscar;
        private ucConcluido telaConcluido;
        private ucEstatisticas telaEstatisticas;

        // 3. Variável de controle para rastrear qual tela (UserControl) está sendo exibida no momento
        private UserControl telaAtual;

        // Construtor do formulário: ele exige o ID do usuário como parâmetro para saber quem está logado
        public FrmTelaInicial(int idUsuario)
        {
            // Inicializa os componentes visuais do formulário (criados no Designer)
            InitializeComponent();
            // Atribui o ID recebido à variável interna do formulário
            _idUsuarioLogado = idUsuario;
        }

        // Evento que é disparado quando o formulário é carregado (inicia)
        private void FrmTelaInicial_Load(object sender, EventArgs e)
        {
            // A. Cria uma nova instância de cada UserControl (tela de conteúdo)
            telaHoje = new ucHoje();
            telaEmBreve = new ucEmBreve();
            telaAdicionar = new ucAdicionarTarefa();
            telaBuscar = new ucBuscar();
            telaConcluido = new ucConcluido();
            telaEstatisticas = new ucEstatisticas();

            // B. Passa o ID do usuário logado para CADA uma das telas
            // Isso garante que cada tela só carregue dados pertencentes a este usuário
            telaHoje.IdUsuarioLogado = _idUsuarioLogado;
            telaEmBreve.IdUsuarioLogado = _idUsuarioLogado;
            telaBuscar.IdUsuarioLogado = _idUsuarioLogado;
            telaConcluido.IdUsuarioLogado = _idUsuarioLogado;
            telaAdicionar.IdUsuarioLogado = _idUsuarioLogado;
            telaEstatisticas.IdUsuarioLogado = _idUsuarioLogado;

            // C. Chama a função para exibir a tela de "Hoje" como tela inicial
            AbrirTela(telaHoje);

            // D. Chama a função para carregar as tarefas e as informações do usuário
            telaHoje.CarregarTarefasHoje();
            CarregarInformacoesUsuario();
        }

        // Função responsável por buscar o nome do usuário no banco de dados e mostrá-lo na tela
        private void CarregarInformacoesUsuario()
        {
            // Define a string de conexão com o banco de dados SQL Server
            string connectionString = @"Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas";
            // Define um nome padrão ("Usuário") para ser usado caso a busca falhe
            string nomeUsuario = "Usuário";

            // 1. Query SQL para buscar o nome do usuário na tabela 'usuario' onde o ID corresponde ao ID logado
            // ATENÇÃO: A coluna 'USUARIO' foi usada aqui, assumindo que é a correta.
            string query = "SELECT USUARIO FROM usuario WHERE ID = @ID_USUARIO";

            try
            {
                // Abre a conexão com o banco de dados usando o 'using' para garantir que ela seja fechada
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Cria um comando SQL com a query e a conexão
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Adiciona o ID do usuário logado como parâmetro para a query SQL (proteção contra SQL Injection)
                        cmd.Parameters.AddWithValue("@ID_USUARIO", _idUsuarioLogado);
                        // Abre a conexão
                        con.Open();
                        // Executa a query e busca o primeiro valor retornado (o nome)
                        object result = cmd.ExecuteScalar();

                        // Verifica se algum resultado foi encontrado e se não é nulo
                        if (result != null && result != DBNull.Value)
                        {
                            // Converte o resultado para string e armazena
                            nomeUsuario = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro (ex: falha de conexão), registra a mensagem de erro no console de Debug
                System.Diagnostics.Debug.WriteLine("Erro ao buscar nome do usuário: " + ex.Message);
                // Exibe a mensagem de erro para o usuário em uma caixa de diálogo
                MessageBox.Show("Erro ao carregar nome do usuário: " + ex.Message, "Erro de Conexão com o Banco de Dados");
            }

            // 2. Exibe a mensagem de saudação na interface
            // Verifica se o componente de Label chamado 'lblNomeUsuario' existe
            if (lblNomeUsuario != null)
            {
                // Verifica se o nome do usuário não está vazio
                if (!string.IsNullOrEmpty(nomeUsuario))
                {
                    // Formata o nome do usuário para que apenas a primeira letra seja maiúscula, para uma aparência limpa
                    nomeUsuario = nomeUsuario.Substring(0, 1).ToUpper() + (nomeUsuario.Length > 1 ? nomeUsuario.Substring(1).ToLower() : "");
                }

                // Define o texto final de saudação no Label
                lblNomeUsuario.Text = $"OLÁ, {nomeUsuario}!";
            }
            else
            {
                // Se o Label não for encontrado, registra um aviso no console de Debug
                System.Diagnostics.Debug.WriteLine("ATENÇÃO: O Label 'lblNomeUsuario' não foi encontrado no Designer. A saudação não será exibida.");
            }
        }

        // Método genérico para trocar a tela de conteúdo principal
        private void AbrirTela(UserControl novaTela)
        {
            // Verifica se o painel que contém as telas existe (nome esperado: 'pnlConteudo')
            if (pnlConteudo == null)
            {
                // Exibe erro se o painel principal não for encontrado
                MessageBox.Show("ERRO: O painel 'pnlConteudo' não foi encontrado. Verifique o nome no Designer.", "Erro de Componente");
                return;
            }

            // Remove a tela anterior (UserControl) que estava sendo exibida
            if (telaAtual != null)
            {
                pnlConteudo.Controls.Remove(telaAtual);
            }

            // Configura a nova tela para preencher todo o painel de conteúdo
            novaTela.Dock = DockStyle.Fill;
            // Adiciona a nova tela ao painel de conteúdo
            pnlConteudo.Controls.Add(novaTela);
            // Atualiza a variável de controle para a nova tela
            telaAtual = novaTela;
        }

        /* ------------------------------------------------------------------ */
        /* IMPLEMENTAÇÃO DOS BOTÕES DE NAVEGAÇÃO                              */
        /* ------------------------------------------------------------------ */

        // Evento de clique para o botão "Hoje"
        private void btnHoje_Click(object sender, EventArgs e)
        {
            // Abre a tela de tarefas de hoje
            AbrirTela(telaHoje);
            // Manda o UserControl recarregar as tarefas atualizadas
            telaHoje.CarregarTarefasHoje();
        }

        // Evento de clique para o botão "Em Breve"
        private void btnEmBreve_Click(object sender, EventArgs e)
        {
            // Abre a tela de tarefas futuras
            AbrirTela(telaEmBreve);
            // Manda o UserControl recarregar as tarefas futuras
            telaEmBreve.CarregarTarefasEmBreve();
        }

        // Evento de clique para o botão "Concluído"
        private void btnConcluido_Click(object sender, EventArgs e)
        {
            // Abre a tela de tarefas concluídas
            AbrirTela(telaConcluido);
            // Manda o UserControl recarregar as tarefas concluídas
            telaConcluido.CarregarTarefasConcluidas();
        }

        // Evento de clique para o botão "Adicionar Tarefa"
        private void btnAdicionarTarefa_Click(object sender, EventArgs e)
        {
            // Abre a tela de adição de tarefas (o ID já foi passado no Load)
            AbrirTela(telaAdicionar);
        }

        // Evento de clique para o botão "Buscar"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Abre a tela de busca
            AbrirTela(telaBuscar);
            // Se houver uma função de carregamento inicial em ucBuscar, ela seria chamada aqui
        }

        // Evento de clique para o botão "Estatísticas"
        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            // Abre a tela de estatísticas
            AbrirTela(telaEstatisticas);
            // Manda o UserControl carregar os gráficos e dados de estatísticas
            telaEstatisticas.CarregarEstatisticas();
        }

        // Lógica para o botão "SAIR" (permite voltar para a tela de login)
        private void btnSair_Click(object sender, EventArgs e)
        {
            // Exibe uma caixa de diálogo de confirmação ao usuário
            DialogResult result = MessageBox.Show(
              "Tem certeza que deseja sair e voltar para a tela de login?",
              "Mudar de Conta",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            // Se o usuário confirmar
            if (result == DialogResult.Yes)
            {
                // 1. Cria e mostra uma nova instância do formulário de Login
                FrmLog frmLogin = new FrmLog();
                frmLogin.Show();

                // 2. Fecha este formulário da tela inicial
                this.Close();
            }
        }

        /* ------------------------------------------------------------------ */
        /* EVENTOS DO DESIGNER (Vazios para compatibilidade)                  */
        /* ------------------------------------------------------------------ */
        // Métodos que existem no Designer, mas não possuem lógica implementada neste arquivo
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }
        private void pnlMenu_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void pnlConteudo_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}