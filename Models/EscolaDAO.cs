using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System_Escola.Database;
using System_Escola.Helpers;
using System.Threading.Tasks;

namespace System_Escola.Models
{
    internal class EscolaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Update(Escola cadastro)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Escola SET " +
                   "nome_fantasia_esc = @nomeFantasia, razao_social_esc = @razaoSocial, cnpj_esc = @cnpj, insc_estadual_esc = @inscEstadual, tipo_esc = @tipo, " +
                   "data_criacao_esc = @data_criacao, responsavel_esc = @resp, responsavel_telefone_esc = @resp_tel, email_esc = @email, " +
                   "telefone_esc = @telefone, rua_esc = @rua, numero_esc = @numero, bairro_esc = @bairro, complemento_esc = @complemento, cep_esc = " +
                   "@cep, cidade_esc = @cidade, estado_esc = @estado" +
                   " Where id_esc = @id";


                comando.Parameters.AddWithValue("@id", cadastro.Id);
                comando.Parameters.AddWithValue("@nomeFantasia", cadastro.Nome);
                comando.Parameters.AddWithValue("@razaoSocial", cadastro.Razao);
                comando.Parameters.AddWithValue("@cnpj", cadastro.Cnpj);
                comando.Parameters.AddWithValue("@inscEstadual", cadastro.Inscricao_est);
                comando.Parameters.AddWithValue("@tipo", cadastro.Tipo);
                comando.Parameters.AddWithValue("@data_criacao", cadastro.Data_criacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp", cadastro.Responsavel);
                comando.Parameters.AddWithValue("@resp_tel", cadastro.Telefone_res);
                comando.Parameters.AddWithValue("@email", cadastro.Email);
                comando.Parameters.AddWithValue("@telefone", cadastro.Telefone_esc);
                comando.Parameters.AddWithValue("@rua", cadastro.Rua);
                comando.Parameters.AddWithValue("@numero", cadastro.Numero);
                comando.Parameters.AddWithValue("@bairro", cadastro.Bairro);
                comando.Parameters.AddWithValue("@complemento", cadastro.Complemento);
                comando.Parameters.AddWithValue("@cep", cadastro.Cep);
                comando.Parameters.AddWithValue("@cidade", cadastro.Cidade);
                comando.Parameters.AddWithValue("@estado", cadastro.Estado);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Escola t)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM escola WHERE id_esc = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Registro não removido da base de dados. Verifique e tente novamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(Escola cadastro)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO escola VALUES " +
                "(null, @nome, @razao, @cnpj, @inscricao, @tipo, @data_criacao, @resp, @resp_tel, " +
                "@email, @telefone, @rua, @numero, @bairro, @complemento, @cep, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nome", cadastro.Nome);
                comando.Parameters.AddWithValue("@razao", cadastro.Razao);
                comando.Parameters.AddWithValue("@cnpj", cadastro.Cnpj);
                comando.Parameters.AddWithValue("@inscricao", cadastro.Inscricao_est);
                comando.Parameters.AddWithValue("@tipo", cadastro.Tipo);
                comando.Parameters.AddWithValue("@data_criacao", cadastro.Data_criacao?.ToString("yyyy-MM-dd"));

                comando.Parameters.AddWithValue("@resp", cadastro.Responsavel);
                comando.Parameters.AddWithValue("@resp_tel", cadastro.Telefone_res);
                comando.Parameters.AddWithValue("@email", cadastro.Email);
                comando.Parameters.AddWithValue("@telefone", cadastro.Telefone_esc);
                comando.Parameters.AddWithValue("@rua", cadastro.Rua);
                comando.Parameters.AddWithValue("@numero", cadastro.Numero);
                comando.Parameters.AddWithValue("@bairro", cadastro.Bairro);
                comando.Parameters.AddWithValue("@complemento", cadastro.Complemento);
                comando.Parameters.AddWithValue("@cep", cadastro.Cep);
                comando.Parameters.AddWithValue("@cidade", cadastro.Cidade);
                comando.Parameters.AddWithValue("@estado", cadastro.Estado);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Escola> List()
        {
            try
            {
                var lista = new List<Escola>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM escola";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var cadastro = new Escola();

                    cadastro.Id = reader.GetInt32("id_esc");
                    cadastro.Nome = DAOHelpr.GetString(reader, "nome_fantasia_esc");
                    cadastro.Razao = DAOHelpr.GetString(reader, "razao_social_esc");
                    cadastro.Cnpj = DAOHelpr.GetString(reader, "cnpj_esc");
                    cadastro.Inscricao_est = DAOHelpr.GetString(reader, "insc_estadual_esc");
                    cadastro.Tipo = DAOHelpr.GetString(reader, "tipo_esc");
                    cadastro.Data_criacao = DAOHelpr.GetDateTime(reader, "data_criacao_esc");

                    cadastro.Responsavel = DAOHelpr.GetString(reader, "responsavel_esc");
                    cadastro.Telefone_res = DAOHelpr.GetString(reader, "responsavel_telefone_esc");
                    cadastro.Email = DAOHelpr.GetString(reader, "email_esc");
                    cadastro.Telefone_esc = DAOHelpr.GetString(reader, "telefone_esc");
                    cadastro.Numero = DAOHelpr.GetString(reader, "numero_esc");
                    cadastro.Bairro = DAOHelpr.GetString(reader, "bairro_esc");
                    cadastro.Rua = DAOHelpr.GetString(reader, "rua_esc");
                    cadastro.Complemento = DAOHelpr.GetString(reader, "complemento_esc");
                    cadastro.Cep = DAOHelpr.GetString(reader, "cep_esc");
                    cadastro.Cidade = DAOHelpr.GetString(reader, "cidade_esc");
                    cadastro.Estado = DAOHelpr.GetString(reader, "estado_esc");

                    lista.Add(cadastro);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
