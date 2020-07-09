using Jadet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jadet.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            if (Session["usuario"] != null && (Session["usuario"] as loginmodel).usuario == "Root")
                return View();
            else
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Productos()
        {
            return View();
        }

        public ActionResult Guias()
        {
            return View();
        }

        public ActionResult Clientes()
        {
            listaclientesmodel clientes = new listaclientesmodel();
            clientes.Items.Add(new clientenmodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario uno",
                usuario = "user1",
                password = string.Empty
            });
            clientes.Items.Add(new clientenmodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario dos",
                usuario = "user2",
                password = string.Empty
            });
            clientes.Items.Add(new clientenmodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario tres",
                usuario = "user3",
                password = string.Empty
            });
            clientes.Items.Add(new clientenmodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario cuatro",
                usuario = "user4",
                password = string.Empty
            });
            clientes.Items.Add(new clientenmodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario cinco",
                usuario = "user5",
                password = string.Empty
            });
            return View(clientes);
        }

        public ActionResult Notas()
        {
            return View();
        }

    }
}