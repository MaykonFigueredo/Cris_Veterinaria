using CRIS_VETERINARIA_MVC_BD.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySqlConnector;
using System;

namespace CRIS_VETERINARIA_MVC_BD.Controllers
{
    public class ContatoController : Controller
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

        public IActionResult Alterar_Contato(int Id)
        {
            ContatoRepository ct = new ContatoRepository();
            Contato ctLocalizado = ct.BuscarPorId(Id);
             
            return View(ctLocalizado);

        }

        [HttpPost]
        public IActionResult Alterar_Contato(Contato co)
        {

            ContatoRepository ct = new ContatoRepository();
            ct.Alterar(co);
             Console.Out.WriteLine(co.Id);
            return RedirectToAction("Listagem_Contato", "Contato");

        }
        
        public IActionResult Remover(int Id)
        {
            
            ContatoRepository ct = new ContatoRepository();
            Contato ctLocalizado = ct.BuscarPorId(Id);
            ct.Excluir(ctLocalizado);
            return RedirectToAction("Listagem_Contato", "Contato");

        }

      public IActionResult Listagem_Contato(){
           
                   
            ContatoRepository ct = new ContatoRepository();
            List<Contato> ListaDeContato = ct.Listar();

            Console.Out.WriteLine("Listagem");
            return View(ListaDeContato);

            
        }

        public IActionResult Cadastro_Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro_Contato(Contato co)
        {
            ContatoRepository ct = new ContatoRepository();
            ct.Inserir(co);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }

    }
}