using MySql.Data.MySqlClient;
using Projeto_Controle_de_Vendas.br.com.projeto.conexaoDB;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.dao
{
    public class FornecedorDAO
    {
        private MySqlConnection conexaoDataBase;

        public FornecedorDAO()
        {
            this.conexaoDataBase = new ConnectionFactory().getConnection();
        }

        #region Método para alterar um fornecedor
        public void alterarFornecedor(Fornecedor obj)
        {
            try
            {
                string sql = @"update tb_fornecedores set nome = @nome, cnpj = @cnpj, email = @email, telefone = @telefone,
                                                                 celular = @celular, cep = @cep, endereco = @endereco, 
                                                                 numero = @numero, complemento = @comp, bairro = @bairro,
                                                                 cidade = @cidade, estado = @estado where id = @id";


                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);

                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);

                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);

                executacmd.Parameters.AddWithValue("@cep", obj.cep);

                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@comp", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Dados alterados com Sucesso!");

                conexaoDataBase.Close();

            }


            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region Método Excluir fornecedor
        public void excluirFornecedor(Fornecedor obj)
        {
            try
            {
                string sql = @"delete from tb_fornecedores where id = @id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluido com Sucesso!");
                conexaoDataBase.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }

        #endregion

        #region Exemplo de criação de um region

        #endregion

        #region Método para cadastrar um Fornecedor
        public void cadastrarFornecedor(Fornecedor obj)
        {
            try
            {
                string sql = @"insert into tb_fornecedores (nome,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade, estado)
                                values (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco,@numero, @complemento, @bairro, @cidade, @estado) ";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);

                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);

                executacmd.Parameters.AddWithValue("@cep", obj.cep);

                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");

                conexaoDataBase.Close();
            }

            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }


        }

        #endregion

        #region Método que listar todos os fornecedores
        public DataTable listarFornecedores()
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();
                string sql = "select * from tb_fornecedores";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                conexaoDataBase.Close();

                return tabelafornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

        #region Método que listar todos os fornecedores por nome
        public DataTable listarFornecedorPorNome(string nome)
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where nome like @nome";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                conexaoDataBase.Close();

                return tabelafornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }



        #endregion

        #region Método que busca um fornecedores por nome
        public DataTable buscarFornecedorPorNome(string nome)
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where nome = @nome";


                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                conexaoDataBase.Close();

                return tabelafornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

    }
}

