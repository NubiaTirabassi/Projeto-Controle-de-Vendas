using MySql.Data.MySqlClient;
using Projeto_Controle_de_Vendas.br.com.projeto.conexaoDB;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.dao
{
    public class ClienteDAO
    {
        private MySqlConnection conexaoDataBase;

        public ClienteDAO()
        {
            this.conexaoDataBase = new ConnectionFactory().getConnection();
        }


        #region CadastrarCliente
        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade, estado)
                                values (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco,@numero, @complemento, @bairro, @cidade, @estado) ";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                MessageBox.Show("Cliente cadastrado com sucesso!");

                conexaoDataBase.Close();

            }

            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }


        }
        #endregion

        #region AlterarCliente
        public void alterarCliente(Cliente obj)
        {
            try
            {
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                              endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                              where id=@id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Alterado com sucesso!");

                conexaoDataBase.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region ExcluirCliente

        public void excluirCliente(Cliente obj)
        {
            try
            {
                string sql = @"delete from tb_clientes where id = @id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Excluido com sucesso!");

                conexaoDataBase.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }

        #endregion

        #region ListarClientes
        public DataTable listarClientes()
        {
            try
            {
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                conexaoDataBase.Close();

                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

        #region BuscarClientePorNome
        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes where nome = @nome";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                conexaoDataBase.Close();

                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

        #region ListarClientesPorNome
        public DataTable ListarClientesPorNome(string nome)
        {
            try
            {
                DataTable tabelacliente = new DataTable();
                string sql = "select * from tb_clientes where nome like @nome";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();


                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                conexaoDataBase.Close();

                return tabelacliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }

        }

        #endregion

        #region Método que retorna um cliente por cpf
        public Cliente retornaClientePorCpf(string cpf)
        {
            try
            {

                Cliente obj = new Cliente();
                string sql = @"select * from tb_clientes where cpf = @cpf";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@cpf", cpf);

                conexaoDataBase.Open();

                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    obj.codigo = rs.GetInt32("id");
                    obj.nome = rs.GetString("nome");


                    conexaoDataBase.Close();
                    return obj;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado!");

                    conexaoDataBase.Close();
                    return null;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);

                conexaoDataBase.Close();
                return null;

            }

        }

        #endregion

    }
}

