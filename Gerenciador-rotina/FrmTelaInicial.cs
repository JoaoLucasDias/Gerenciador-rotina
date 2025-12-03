using System;
using System.Data.SqlClient; // Importa a biblioteca necessária para trabalhar com SQL Server (conexão e comandos)
using System.Windows.Forms; // Importa a biblioteca para criar a interface gráfica (formulários, botões, etc.)
using System.Drawing; // Importa a biblioteca para trabalhar com elementos visuais (cores, pontos, etc.)

namespace Gerenciador_rotina
{
    
    public partial class FrmTelaInicial : Form
    {
       
        private int _idUsuarioLogado;

        
        private ucHoje telaHoje;
        private ucEmBreve telaEmBreve;
        private ucAdicionarTarefa telaAdicionar;
        private ucBuscar telaBuscar;
        private ucConcluido telaConcluido;
        private ucEstatisticas telaEstatisticas;

   
        private UserControl telaAtual;

      
        public FrmTelaInicial(int idUsuario)
        {
          
            InitializeComponent();
         
            _idUsuarioLogado = idUsuario;
        }

     
        private void FrmTelaInicial_Load(object sender, EventArgs e)
        {
    
            telaHoje = new ucHoje();
            telaEmBreve = new ucEmBreve();
            telaAdicionar = new ucAdicionarTarefa();
            telaBuscar = new ucBuscar();
            telaConcluido = new ucConcluido();
            telaEstatisticas = new ucEstatisticas();

            telaHoje.IdUsuarioLogado = _idUsuarioLogado;
            telaEmBreve.IdUsuarioLogado = _idUsuarioLogado;
            telaBuscar.IdUsuarioLogado = _idUsuarioLogado;
            telaConcluido.IdUsuarioLogado = _idUsuarioLogado;
            telaAdicionar.IdUsuarioLogado = _idUsuarioLogado;
            telaEstatisticas.IdUsuarioLogado = _idUsuarioLogado;

          
            AbrirTela(telaHoje);

       
            telaHoje.CarregarTarefasHoje();
            CarregarInformacoesUsuario();
        }

       
        private void CarregarInformacoesUsuario()
        {
        
            string connectionString = @"Data Source=NOTE_JOAO;Initial Catalog=CJ3027716PR2_LOCAL;User ID=sa;Password=jaojaolucas";
          
            string nomeUsuario = "Usuário";

           
            string query = "SELECT USUARIO FROM usuario WHERE ID = @ID_USUARIO";

            try
            {
               
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                       
                        cmd.Parameters.AddWithValue("@ID_USUARIO", _idUsuarioLogado);
                       
                        con.Open();
                       
                        object result = cmd.ExecuteScalar();

                      
                        if (result != null && result != DBNull.Value)
                        {
                            
                            nomeUsuario = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine("Erro ao buscar nome do usuário: " + ex.Message);
              
                MessageBox.Show("Erro ao carregar nome do usuário: " + ex.Message, "Erro de Conexão com o Banco de Dados");
            }

         
            if (lblNomeUsuario != null)
            {
                
                if (!string.IsNullOrEmpty(nomeUsuario))
                {
                   
                    nomeUsuario = nomeUsuario.Substring(0, 1).ToUpper() + (nomeUsuario.Length > 1 ? nomeUsuario.Substring(1).ToLower() : "");
                }

            
                lblNomeUsuario.Text = $"OLÁ, {nomeUsuario}!";
            }
            else
            {
                
                System.Diagnostics.Debug.WriteLine("ATENÇÃO: O Label 'lblNomeUsuario' não foi encontrado no Designer. A saudação não será exibida.");
            }
        }

        
        private void AbrirTela(UserControl novaTela)
        {
          
            if (pnlConteudo == null)
            {
               
                MessageBox.Show("ERRO: O painel 'pnlConteudo' não foi encontrado. Verifique o nome no Designer.", "Erro de Componente");
                return;
            }

           
            if (telaAtual != null)
            {
                pnlConteudo.Controls.Remove(telaAtual);
            }

            novaTela.Dock = DockStyle.Fill;
        
            pnlConteudo.Controls.Add(novaTela);
          
            telaAtual = novaTela;
        }

        private void btnHoje_Click(object sender, EventArgs e)
        {
            
            AbrirTela(telaHoje);
           
            telaHoje.CarregarTarefasHoje();
        }

      
        private void btnEmBreve_Click(object sender, EventArgs e)
        {
          
            AbrirTela(telaEmBreve);
         
            telaEmBreve.CarregarTarefasEmBreve();
        }

      
        private void btnConcluido_Click(object sender, EventArgs e)
        {
          
            AbrirTela(telaConcluido);
            
            telaConcluido.CarregarTarefasConcluidas();
        }

        private void btnAdicionarTarefa_Click(object sender, EventArgs e)
        {
           
            AbrirTela(telaAdicionar);
        }

     
        private void btnBuscar_Click(object sender, EventArgs e)
        {
        
            AbrirTela(telaBuscar);
           
        }

       
        private void btnEstatistica_Click(object sender, EventArgs e)
        {
       
            AbrirTela(telaEstatisticas);
           
            telaEstatisticas.CarregarEstatisticas();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Tem certeza que deseja sair e voltar para a tela de login?",
              "Mudar de Conta",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            
            if (result == DialogResult.Yes)
            {
                
                FrmLog frmLogin = new FrmLog();
                frmLogin.Show();

            
                this.Close();
            }
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }
        private void pnlMenu_Paint(object sender, PaintEventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void pnlConteudo_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}