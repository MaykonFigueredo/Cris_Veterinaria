using CRIS_VETERINARIA_MVC_BD.Models;
using System.Collections.Generic;
using MySqlConnector;
using System;



namespace CRIS_VETERINARIA_MVC_BD.Models
{
    public class UsuarioRepository
    {
    
   
        
        private const string DadosConexao = "Database=Veterinaria;Data Source=localhost;User Id=root";

       

        public void TestarConexao(){

            
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            
            
            Conexao.Open();
            
            
            Console.WriteLine("Banco de dados funcionando!");

               
            Conexao.Close();

        }

        public Usuario ValidarLogin(Usuario user){

           
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open(); 

            
            String QuerySql = "select * from usuario WHERE login=@login and senha=@senha";

            
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            
            Comando.Parameters.AddWithValue("@login",user.Login);            
            Comando.Parameters.AddWithValue("@senha",user.Senha);         

            
            MySqlDataReader Reader =  Comando.ExecuteReader();
            
            Usuario UsuarioEncontrado = null;

            
            if (Reader.Read()) {                
                
                UsuarioEncontrado = new Usuario();
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
                
                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            //fechar a conexao com o banco
            Conexao.Close();

            //retornar o UsuarioEncontrado
            return UsuarioEncontrado;
        }


        public Usuario BuscarPorId(int Id){

            //abrir a conexao com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open(); 

            //query em sql para buscar por ID (select)
            String QuerySql = "select * from usuario WHERE id=@id";

            //preparar um comando, passando: sql + conexao com o banco de dados
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            //tratamento devido ao sql injection
            Comando.Parameters.AddWithValue("@id",Id);            

            //executo no banco de dados, que retorna um unico usuario QUANDO encontrado
            MySqlDataReader Reader =  Comando.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();

            if (Reader.Read()) {
                
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    UsuarioEncontrado.Login = Reader.GetString("Login");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
                
                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            //fechar a conexao com o banco
            Conexao.Close();

            //retornar o UsuarioEncontrado
            return UsuarioEncontrado;

        }

        public List<Usuario> Listar(){

            //abrir a conexao com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open(); 

            //query em sql para listagem (select)
            String QuerySql = "select * from usuario";

            //preparar um comando, passando: sql + conexao com o banco de dados
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            //executo no banco de dados, que retorna uma lista de dados
            MySqlDataReader Reader =  Comando.ExecuteReader();

            //simplesmente criando uma lista de usuario
            List<Usuario> Lista = new List<Usuario>();

            //percorre todos os registros retornados no banco de dados(obj. Reader)
            while(Reader.Read()){

                Usuario userEncontrado = new Usuario();

                userEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    userEncontrado.Nome = Reader.GetString("Nome");
                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    userEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))    
                    userEncontrado.Senha = Reader.GetString("Senha");

                userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento"); 

                //add na lista de usuarios
                Lista.Add(userEncontrado);
            }

            //fechar a conexao com o banco
            Conexao.Close();

            //retornamos a lista com todos os registros armazenados no banco de dados
            return Lista;

        }

        public void Inserir(Usuario user){

            //abrir a conexao com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open(); 

            //query em sql para alterar (insert)
            String QuerySql = "insert into usuario (nome,login,senha,dataNascimento) values (@nome,@login,@senha,@dataNascimento)";

            //preparar um comando, passando: sql + conexao com o banco de dados
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            //tratamento devido ao sql injection
            Comando.Parameters.AddWithValue("@nome",user.Nome);
            Comando.Parameters.AddWithValue("@login",user.Login);
            Comando.Parameters.AddWithValue("@senha",user.Senha);
            Comando.Parameters.AddWithValue("@dataNascimento",user.DataNascimento);

            //executar o comando no banco de dados
            Comando.ExecuteNonQuery();

            //fechar a conexao com o banco
            Conexao.Close();
        }

        public void Alterar(Usuario user){

            //abrir a conexao com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open(); 

            //query em sql para alterar (update)
            String QuerySql = "update usuario set nome=@nome, login=@login, senha=@senha, dataNascimento=@dataNascimento WHERE id=@id";

            //preparar um comando, passando: sql + conexao com o banco de dados
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            //tratamento devido ao sql injection
            Comando.Parameters.AddWithValue("@id",user.Id);
            Comando.Parameters.AddWithValue("@nome",user.Nome);
            Comando.Parameters.AddWithValue("@login",user.Login);
            Comando.Parameters.AddWithValue("@senha",user.Senha);
            Comando.Parameters.AddWithValue("@dataNascimento",user.DataNascimento);

            //executar o comando no banco de dados
            Comando.ExecuteNonQuery();

            //fechar a conexao com o banco
            Conexao.Close();
        }

        public void Excluir(Usuario user){

            //abrir a conexao com o banco de dados
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open(); 

            //query em sql para excluir (delete)
            String QuerySql = "delete from Usuario WHERE id=@id";

            //preparar um comando, passando: sql + conexao com o banco de dados
            MySqlCommand Comando = new MySqlCommand(QuerySql,Conexao); 

            //tratamento devido ao sql injection
            Comando.Parameters.AddWithValue("@id",user.Id);

            //executar o comando no banco de dados
            Comando.ExecuteNonQuery();

            //fechar a conexao com o banco
            Conexao.Close();
        }

    }
}
