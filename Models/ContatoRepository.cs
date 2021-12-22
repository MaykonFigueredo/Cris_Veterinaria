using System.Collections.Generic;
using MySqlConnector;
using System;

namespace CRIS_VETERINARIA_MVC_BD.Models
{
    public class ContatoRepository
   {
        private const string DadosConexao = "Database =Veterinaria ; Data Source=localhost ; User = root";


         public Contato  BuscarPorId(int Id)
        {

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "select * from contato WHERE Id=@Id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Contato ContatoEncontrado = new Contato();

            if (Reader.Read())
            {

                ContatoEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    ContatoEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    ContatoEncontrado.Email = Reader.GetString("Email");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Assunto")))
                    ContatoEncontrado.Assunto = Reader.GetString("Assunto");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Mensagem")))
                    ContatoEncontrado.Mensagem = Reader.GetString("Mensagem");

                
                
            }


            Conexao.Close();

            return ContatoEncontrado;

        }

        public List<Contato> Listar()
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "select * from contato ";


            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Contato> Lista = new List<Contato>();


            while (Reader.Read())
            {

              Contato ContatoEncontrado = new Contato();

                ContatoEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    ContatoEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    ContatoEncontrado.Email = Reader.GetString("Email");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Assunto")))
                    ContatoEncontrado.Assunto = Reader.GetString("Assunto");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Mensagem")))
                    ContatoEncontrado.Mensagem = Reader.GetString("Mensagem");
               
                Lista.Add(ContatoEncontrado);
            }

            Conexao.Close();

            return Lista;

        }

        public void Inserir(Contato cont)
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "insert into contato (Id,Nome,Email,Assunto,Mensagem) values (@Id,@Nome,@Email,@Assunto,@Mensagem)";


            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@Id", cont.Id);
            Comando.Parameters.AddWithValue("@Nome", cont.Nome);
            Comando.Parameters.AddWithValue("@Email", cont.Email);
            Comando.Parameters.AddWithValue("@Assunto", cont.Assunto);
            Comando.Parameters.AddWithValue("@Mensagem", cont.Mensagem);
           Console.Out.WriteLine("InserirContato");
            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

       public void Alterar(Contato cont)
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "update contato set id=@id,nome=@nome, email=@email,assunto=@assunto, mensagem=@mensagem WHERE id=@id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);

            Comando.Parameters.AddWithValue("@id", cont.Id);
            Comando.Parameters.AddWithValue("@nome", cont.Nome);
            Comando.Parameters.AddWithValue("@email", cont.Email);
            Comando.Parameters.AddWithValue("@Assunto", cont.Assunto);
            Comando.Parameters.AddWithValue("@mensagem", cont.Mensagem);            
            Comando.ExecuteNonQuery();
            Console.Out.WriteLine("Alterar_Contato");
            
            Conexao.Close();
        }

        public void Excluir(Contato cont)
        {


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();


            String QuerySql = "delete from contato WHERE id=@id";

            MySqlCommand Comando = new MySqlCommand(QuerySql, Conexao);


            Comando.Parameters.AddWithValue("@Id", cont.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

    }
}