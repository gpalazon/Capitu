using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capitu.BLL;
using Capitu.MVC.Models;

namespace Capitu.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HotSite()
        {
            return View();
        }


        [HttpPost]
        public ActionResult HotSite(ContatoVO model)
        {
            try
            {
                ContatoBLL contato = new ContatoBLL();
                contato.Salvar(model.Email);

                ViewBag.Message = "E-mail cadastrado com sucesso!  Em breve lhe enviaremos mais informações...";

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Oops... Não foi possível gravar o contato  =/  Por favor, tente novamente mais tarde. " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult EnviarEmail(string email)
        {
            try
            {
                ContatoBLL contato = new ContatoBLL();
                contato.Salvar(email);

                ViewBag.Message = "E-mail cadastrado com sucesso! Em breve lhe enviaremos mais informações ;)";

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Oops... Não foi possível gravar o contato  =/ Tente novamente mais tarde por favor.";
                return View();
            }
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return RedirectToAction("Mapa");

            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mapa()
        {

            return View();
        }
    }
}
