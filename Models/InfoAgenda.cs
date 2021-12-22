using System.Collections.Generic;

namespace CRIS_VETERINARIA_MVC_BD.Models
{
    
    public class InfoAgenda
    {
        private static List<Agenda> lista = new List<Agenda>();

        public static void Incluir(Agenda item){
            lista.Add(item);

        }

        public static List<Agenda> Listar(){
            return lista;
        }

    }
}