using System.Collections.Generic;

namespace CRIS_VETERINARIA_MVC_BD.Models
{
    public class Servico
   {
       private static List<Contato> listaDeItens = new List<Contato>();

       public static void AdicionarContato(Contato contato){
           listaDeItens.Add(contato);           
       }
       public static  List<Contato> ListarContato(){
            return listaDeItens;
       }

   }   
}