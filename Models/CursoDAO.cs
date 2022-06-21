using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System_Escola.Database;
using System_Escola.Helpers;

namespace System_Escola.Models
{
    internal class CursoDAO
    {
        private static Conexao _conn = new Conexao();


        public void Delete(Curso t)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM curso WHERE id_cur = @id";

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

        public void Insert(Curso cadastro)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO curso VALUES" +
                "(null, @nome, @descricao, @carga_horaria, @turno);";

                comando.Parameters.AddWithValue("@nome", cadastro.Nome);
                comando.Parameters.AddWithValue("@descricao", cadastro.Descricao);
                comando.Parameters.AddWithValue("@carga_horaria", cadastro.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", cadastro.Turno);

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

        public List<Curso> List()
        {
            try
            {
                var lista = new List<Curso>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM curso";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var cadastro = new Curso();

                    cadastro.Id = reader.GetInt32("id_cur");
                    cadastro.Nome = DAOHelpr.GetString(reader, "nome_cur");
                    cadastro.Descricao = DAOHelpr.GetString(reader, "descricao_cur");
                    cadastro.CargaHoraria = DAOHelpr.GetString(reader, "carga_horaria_cur");
                    cadastro.Turno = DAOHelpr.GetString(reader, "turno_cur");

                    lista.Add(cadastro);
                }
                reader.Close();
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Curso cadastro)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Curso SET " +
                    "Nome_cur = @nome, carga_horaria_cur = @cargaHoraria, descricao_cur = @descricao, turno_cur = @turno" +
                    " Where id_cur = @id";

                comando.Parameters.AddWithValue("@id", cadastro.Id);
                comando.Parameters.AddWithValue("@nome", cadastro.Nome);
                comando.Parameters.AddWithValue("@cargaHoraria", cadastro.CargaHoraria);
                comando.Parameters.AddWithValue("@descricao", cadastro.Descricao);
                comando.Parameters.AddWithValue("@turno", cadastro.Turno);



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
    }
}
