using ClimaTempoSimples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity ;

namespace ClimaTempoSimples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var Context = new ClimaTempoContext();

            var previsoes = Context.PrevisaoClimas.Include(x => x.Cidade).Include(x => x.Cidade.Estado).Where(x => x.TemperaturaMinima <= 10).ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}