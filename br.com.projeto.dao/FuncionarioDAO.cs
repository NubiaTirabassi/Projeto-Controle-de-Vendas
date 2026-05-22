using MySql.Data.MySqlClient;
using Projeto_Controle_de_Vendas.br.com.projeto.conexaoDB;
using Projeto_Controle_de_Vendas.br.com.projeto.model;
using Projeto_Controle_de_Vendas.br.com.projeto.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Controle_de_Vendas.br.com.projeto.dao
{
    public class FuncionarioDAO
    {

        private MySqlConnection conexaoDataBase;

        public FuncionarioDAO()
        {
            this.conexaoDataBase = new ConnectionFactory().getConnection();
        }


        #region Método Cadastrar Funcionario
        public void cadastrarFuncionario(Funcionario obj)
        {
            try
            {
                string sql = "insert into tb_funcionarios (nome,rg,cpf,email,senha,cargo,nivel_acesso,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)" +
                             " values (@nome,@rg,@cpf,@email,@senha,@cargo,@nivel,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";
            
                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);

                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);

                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel", obj.nivel_acesso);

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

                MessageBox.Show("Funcionário cadastrado com sucesso!");

                conexaoDataBase.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }


        #endregion

        #region Método Alterar Funcionario
        public void alterarFuncionario(Funcionario obj)
        {
            try
            {
                string sql = "update tb_funcionarios set nome=@nome,rg=@rg,cpf=@cpf,email=@email,senha=@senha,cargo=@cargo,nivel_acesso=@nivel," +
                                "telefone=@telefone,celular=@celular,cep=@cep,endereco=@endereco,numero=@numero," +
                                "complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado where id = @codigo";
           
                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);

                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);

                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel", obj.nivel_acesso);

                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                executacmd.Parameters.AddWithValue("@codigo", obj.codigo);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário alterado com sucesso!");
                conexaoDataBase.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }

        #endregion

        #region Método Excluir Funcionario
        public void deletarFuncionario(Funcionario obj)
        {
            try
            {
                string sql = "delete from tb_funcionarios where id = @codigo";
                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);

                executacmd.Parameters.AddWithValue("@codigo", obj.codigo);

                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário excluido com sucesso!");
                conexaoDataBase.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
            }

        }

        #endregion


        #region Método ListarFuncionarios
        public DataTable listarFuncionarios()
        {
            try
            {
                DataTable tabelafuncionario = new DataTable();
                string sql = "select * from tb_funcionarios";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                conexaoDataBase.Close();

                return tabelafuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }
        }
        #endregion

        #region Método BuscaFuncionariosPorNome por Nome
        public DataTable BuscaFuncionariosPorNome(string nome)
        {
            try
            {
                DataTable tabelafuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome = @nome";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                conexaoDataBase.Close();

                return tabelafuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }
        }

        #endregion

        #region Método que ListaFuncionariosPorNome
        public DataTable listarFuncionariosPorNome(string nome)
        {
            try
            {
                DataTable tabelafuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome like @nome";

                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexaoDataBase.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                conexaoDataBase.Close();

                return tabelafuncionario;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);
                return null;
            }
        }

        #endregion

        #region Método que Efetua Login
        public bool EfetuarLogin(string email, string senha)
        {
            try
            {
                string sql = @"select * from tb_funcionarios 
                                     where email = @email and senha = @senha";
                MySqlCommand executacmd = new MySqlCommand(sql, conexaoDataBase);
                executacmd.Parameters.AddWithValue("@email", email);
                executacmd.Parameters.AddWithValue("@senha", senha);

                conexaoDataBase.Open();

                MySqlDataReader reader = executacmd.ExecuteReader();

                if (reader.Read())
                {

                    string nivel = reader.GetString("nivel_acesso");
                    string nome = reader.GetString("nome");

                    MessageBox.Show("Seja bem vindo ao sistema, " + nome);

                    FrmMenu telamenu = new FrmMenu();

                    telamenu.txtusuario.Text = nome;

                    if (nivel.Equals("Administrador"))
                    {

                        telamenu.Show();
                    }

                    else if (nivel.Equals("Vendedor"))
                    {
                        telamenu.menuProdutos.Visible = false;
                        telamenu.menuHistorico.Enabled = false;
                        telamenu.Show();
                    }





                    return true;
                }

                else
                {
                    MessageBox.Show("Email ou senha incorreto!");
                    return false;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu o erro: " + erro);
                return false;
            }

        }

        #endregion

    }
}
