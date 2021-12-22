 
namespace CRIS_VETERINARIA_MVC_BD.Models
{
    public static class Dados
    {
        public static Contato contatoAtual{get;set;}

        static Dados(){
            contatoAtual = new Contato();
        }
    }
}
