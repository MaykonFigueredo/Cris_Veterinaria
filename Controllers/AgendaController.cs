using CRIS_VETERINARIA_MVC_BD.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySqlConnector;
using System;


namespace CRIS_VETERINARIA_MVC_BD.Controllers
{
    public class AgendaController : Controller 
{
            private const string DadosConexao = "Database=Veterinaria;Data Source=localhost;User Id=root";
            public void TestarConexao(){

            //informar a credencial de acesso
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            
            //abrir uma conexao
            Conexao.Open();
            
            //imprimir uma mensagem de tudo funcionando
            Console.WriteLine("Banco de dados funcionando!");

            //fechar uma conexao    
            Conexao.Close();
        }

        public IActionResult Alterar(int Id)
        {
            AgendaRepository ag = new AgendaRepository();
            Agenda agLocalizado = ag.BuscarPorId(Id);
             Console.Out.WriteLine("AlterarPTC1!!!!!");
            return View(agLocalizado);

        }

        [HttpPost]
        public IActionResult Alterar(Agenda agen)
        {

            AgendaRepository ag = new AgendaRepository();
            ag.Alterar(agen);
             Console.Out.WriteLine(agen.Id);
            return RedirectToAction("Listagem_Agenda", "Agenda");

        }
        
        public IActionResult Remover(int Id)
        {
            
            AgendaRepository ag = new AgendaRepository();
            Agenda agLocalizado = ag.BuscarPorId(Id);
            ag.Excluir(agLocalizado);
            return RedirectToAction("Listagem_Agenda", "Agenda");

        }

      public IActionResult Listagem_Agenda(){
           
                   
            AgendaRepository ag = new AgendaRepository();
            List<Agenda> ListaDeAgenda = ag.Listar();

            Console.Out.WriteLine("Listagem");
            return View(ListaDeAgenda);

            
        }

        public IActionResult Cadastro_Agenda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro_Agenda(Agenda agen)
        {
            AgendaRepository ag = new AgendaRepository();
            ag.Inserir(agen);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }

    }
}