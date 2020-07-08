using Jadet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jadet.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            if (Session["usuario"] != null && (Session["usuario"] as loginmodel).usuario == "User")
                return View();
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}