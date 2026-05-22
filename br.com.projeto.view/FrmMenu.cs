using System;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.view
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frmfuncionarios tela = new Frmfuncionarios();
            tela.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            txtdata.Text = DateTime.Now.ToShortDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Programação dtentro do timer
            //Pegando a hora
            txthora.Text = DateTime.Now.ToLongTimeString();
        }

        private void cadastroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmclientes tela = new Frmclientes();

            tela.ShowDialog();
        }

        private void consultaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmclientes tela = new Frmclientes();
            tela.tabClientes.SelectedTab = tela.tabPage2;
            tela.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Frmfuncionarios tela = new Frmfuncionarios();
            tela.tabFuncionario.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void cadastroDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmfornecedores tela = new Frmfornecedores();
            tela.ShowDialog();
        }

        private void consultaDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmfornecedores tela = new Frmfornecedores();
            tela.tabFornecedor.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroProdutos_Click(object sender, EventArgs e)
        {
            Frmprodutos tela = new Frmprodutos();
            tela.ShowDialog();
        }

        private void consultaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmprodutos tela = new Frmprodutos();
            tela.tabProdutos.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmvendas tela = new Frmvendas();
            tela.ShowDialog();
        }

        private void menuHistorico_Click(object sender, EventArgs e)
        {
            Frmhistorico tela = new Frmhistorico();
            tela.ShowDialog();
        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja Sair?", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void trocarDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja Trocar de usuário?", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                new Frmlogin().Show();
                this.Dispose();
            }
        }
    }
}
