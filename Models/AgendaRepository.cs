using System.Collections.Generic;
using MySqlConnector;
using System;

namespace CRIS_VETERINARIA_MVC_BD.Models
{
    public class AgendaRepository
    {
        private const string DadosConexao = "Database =Veterinaria ; Data Source=localhost ; User = root";


         public Agenda BuscarPorId(int Id)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "select * from agenda WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Agenda AgendaEncontrado = new Agenda();

            if (Reader.Read())
            {

                AgendaEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    AgendaEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Animal")))
                    AgendaEncontrado.Animal = Reader.GetString("Animal");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    AgendaEncontrado.Telefone = Reader.GetString("Telefone");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Necessidade")))
                    AgendaEncontrado.Necessidade = Reader.GetString("Necessidade");

                AgendaEncontrado.Data = Reader.GetDateTime("Data");
                
            }


            Conexao.Close();

            return AgendaEncontrado;

        }

        public List<Agenda> Listar()
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "select * from agenda";


            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Agenda> Lista = new List<Agenda>();


            while (Reader.Read())
            {

              Agenda AgendaEncontrado = new Agenda();

                AgendaEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    AgendaEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Animal")))
                    AgendaEncontrado.Animal = Reader.GetString("Animal");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    AgendaEncontrado.Telefone = Reader.GetString("Telefone");
               if (!Reader.IsDBNull(Reader.GetOrdinal("Necessidade")))
                    AgendaEncontrado.Necessidade = Reader.GetString("Necessidade");

                AgendaEncontrado.Data = Reader.GetDateTime("Data");

                Lista.Add(AgendaEncontrado);
            }

            Conexao.Close();

            return Lista;

        }

        public void Inserir(Agenda agendamento)
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "insert into agenda (Id,Nome,Animal,Telefone,Necessidade,Data) values (@Id,@Nome,@Animal,@Telefone,@Necessidade,@Data)";


            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@Id", agendamento.Id);
            Comando.Parameters.AddWithValue("@Nome", agendamento.Nome);
            Comando.Parameters.AddWithValue("@Animal", agendamento.Animal);
            Comando.Parameters.AddWithValue("@Telefone", agendamento.Telefone);
            Comando.Parameters.AddWithValue("@Necessidade", agendamento.Necessidade);
            Comando.Parameters.AddWithValue("@Data", agendamento.Data);            
            Console.Out.WriteLine("InserirRepository");

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

       public void Alterar(Agenda agendamento)
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "update agenda set id=@id,nome=@nome, animal=@animal,telefone=@telefone, necessidade=@necessidade,data=@data WHERE id=@id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

             Comando.Parameters.AddWithValue("@id", agendamento.Id);
            Comando.Parameters.AddWithValue("@nome", agendamento.Nome);
            Comando.Parameters.AddWithValue("@animal", agendamento.Animal);
            Comando.Parameters.AddWithValue("@telefone", agendamento.Telefone);
            Comando.Parameters.AddWithValue("@necessidade", agendamento.Necessidade);
            Comando.Parameters.AddWithValue("@data", agendamento.Data);
            Console.Out.WriteLine("AlterarRepository!!!");

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Excluir(Agenda agendamento)
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "delete from agenda WHERE id=@id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);


            Comando.Parameters.AddWithValue("@Id", agendamento.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

    }
}