using Projeto_Controle_de_Vendas.br.com.projeto.dao;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.view
{
    public partial class FrmCadastroClientes : Form
    {
        public FrmCadastroClientes()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void FrmCadastroClientes_Load(object sender, EventArgs e)
        {
            tabelaCliente.DefaultCellStyle.ForeColor = Color.Black;
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text.Replace(",", ".");
            obj.cpf = txtcpf.Text.Replace(",", ".");
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomp.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void TabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          
            txtcodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtrg.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtcpf.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txttelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtcelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtcep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtendereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtnumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtcomp.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtbairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtcidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            cbuf.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

           
            tabelaClientes.SelectedTab = tabPage1;

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();

            obj.nome = txtnome.Text;
            obj.rg = txtrg.Text;
            obj.cpf = txtcpf.Text;
            obj.email = txtemail.Text;
            obj.telefone = txttelefone.Text;
            obj.celular = txtcelular.Text;
            obj.cep = txtcep.Text;
            obj.endereco = txtendereco.Text;
            obj.numero = int.Parse(txtnumero.Text);
            obj.complemento = txtcomp.Text;
            obj.bairro = txtbairro.Text;
            obj.cidade = txtcidade.Text;
            obj.estado = cbuf.Text;

            obj.codigo = int.Parse(txtcodigo.Text);

        }
    }
}
