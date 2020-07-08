using Jadet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jadet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        [HttpPost]
        public ActionResult hazLogin(loginmodel model)
        {
            string accion = "Index", controlador = "Home";
            if (!string.IsNullOrEmpty(model.usuario) && !string.IsNullOrEmpty(model.password))
            {
                var servicio = new SeguridadServicio.SeguridadClient();
                var response = servicio.IniciarSesion(new SeguridadServicio.LoginRequest
                {
                    Usuario = model.usuario,
                    password = model.password
                });

                if (response.ErrorNumero == 0)
                {
                    switch (response.RolUsuario.IdRol)
                    {
                        case 1:
                            Session.Clear();
                            Session.Add("usuario", new loginmodel { usuario = "Root", password = "****" });
                            controlador = "Administrador";
                            return RedirectToAction(accion, controlador);
                            break;
                        case 2:
                            Session.Clear();
                            Session.Add("usuario", new loginmodel { usuario = "User", password = "xxxx" });
                            controlador = "Cliente";
                            return RedirectToAction(accion, controlador);
                            break;
                        default:
                            Session.Clear();
                            break;
                    }
                }
                Session.Clear();
                return View("Index", new loginmodel()
                {
                    ErrorNumero = response.ErrorNumero,
                    ErrorMensaje = response.ErrorMensaje
                });
            }
            else
            {
                return View("Index", new loginmodel()
                {
                    ErrorNumero = 2,
                    ErrorMensaje = "Falta usuario o contraseña"
                });
            }
        }
    }
}
