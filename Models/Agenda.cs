using System;
namespace CRIS_VETERINARIA_MVC_BD.Models
{
    public class Agenda
   {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Animal {get;set;}
        public string Telefone {get;set;}
        public DateTime  Data {get;set;}
        public string Necessidade{get;set;}

    }
}