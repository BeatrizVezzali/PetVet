using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetVet_MVC.Models;

namespace PetVet_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Serviços()
        {
            return View();
        }
        
       
        public IActionResult Agendamento()
        {
        
            return View();
        }

        [HttpPost]

        public IActionResult Agendamento(PreAgendamento agendamento)
        {
            try
            {
                Dados.AgendaAtual.Inserir(agendamento);
                return Json(new {status = "Ok", mensagem = "Sucesso!"});
            }
            catch (Exception e)
            {
                _logger.LogError("Erro no cadastro" + e.Message);

				return Json(new {status = "ERR", mensagem = "Tente novamente!"}); 
            }

           
        }


        public IActionResult Lista()
        {
            List<PreAgendamento> agendamentos = Dados.AgendaAtual.Listar();
            return View(agendamentos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
