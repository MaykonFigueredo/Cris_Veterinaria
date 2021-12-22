using System;
namespace CRIS_VETERINARIA_MVC_BD.Models
{
    public class Usuario
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Login {get;set;}
        public string Senha {get;set;}
        public DateTime DataNascimento {get;set;}
    }
}