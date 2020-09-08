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
        [HttpGet]
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
        /// <summary>
        /// Muestra el contenido del carrito activo según su tipo.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult verCarrito(Carritomodel modelo)
        {
            return View();
        }

        /// <summary>
        /// Muestra un listado de los pedidos hechos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Pedidos()
        {
            return View();
        }

        /// <summary>
        /// Muestra el listado de productos que entran como preventa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Productos(listaproductosmodel modelo) {
            return View();
        }

        /// <summary>
        /// Muestra el listado de comentarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Comentarios(listaproductosmodel modelo) {
            return View();
        }

        /// <summary>
        /// Muestra el listado de tickets de una compra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Tickets(listaproductosmodel modelo) {
            return View();
        }

        [HttpPost]
        public JsonResult agregarProducto(Carritomodel model) {
            return new JsonResult();
        }
        
        [HttpGet]
        public ActionResult Perfil(clientemodel modelo) {
            return View(modelo);
        }

        [HttpPost]
        public ActionResult quitarProducto(productomodel modelo) {
            return View();
        }

        [HttpPost]
        public ActionResult subirTicket(Ticketmodel modelo) {
            return View();
        }

        [HttpPost]
        public ActionResult agregarComentario(Comentariomodel modelo) {
            return View();
        }
    }
}