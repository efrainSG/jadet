using Jadet.AdministradorServicio;
using Jadet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jadet.Controllers {
    public class ClienteController : Controller {
        // GET: Cliente
        [HttpGet]
        public ActionResult Index() {
            if (Session["usuario"] != null && (Session["usuario"] as loginmodel).usuario == "User")
                return View();
            else {
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
        public ActionResult Carrito(Carritomodel modelo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// Muestra un listado de los pedidos hechos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Pedidos() {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// Muestra el listado de productos que entran como preventa
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Productos(int idTipo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var servicio = new AdministradorClient();
            var response = servicio.listarProductos(new ProductoRequest {
                Id = 0
            });
            listaproductosmodel model = new listaproductosmodel();
            ViewBag.TipoVenta = idTipo;
            switch (idTipo) {
                case 1:
                    ViewBag.Title = "Preventa";
                    model.Items.AddRange(
                        response.Items.Where(p=>!p.AplicaExistencias).Select(p => new productomodel {
                            Descripcion = p.Descripcion,
                            ErrorMensaje = p.ErrorMensaje,
                            ErrorNumero = p.ErrorNumero,
                            Existencias = p.Existencias,
                            Nombre = p.Nombre,
                            PrecioMXN = p.PrecioMXN,
                            PrecioUSD = p.PrecioUSD,
                            Imagen = p.Foto,
                            Sku = p.SKU,
                            AplicaExistencias = p.AplicaExistencias,
                            Id = p.Id,
                            IdCategoria = p.IdCategoria,
                            Categoria = string.Empty //responseCategorias.Items.First(c => c.Id.Equals(p.IdCategoria)).Nombre
                }));
                    break;
                case 2:
                    ViewBag.Title = "VIP";
                    model.Items.AddRange(
                        response.Items.Where(p => p.AplicaExistencias).Select(p => new productomodel {
                            Descripcion = p.Descripcion,
                            ErrorMensaje = p.ErrorMensaje,
                            ErrorNumero = p.ErrorNumero,
                            Existencias = p.Existencias,
                            Nombre = p.Nombre,
                            PrecioMXN = p.PrecioMXN,
                            PrecioUSD = p.PrecioUSD,
                            Imagen = p.Foto,
                            Sku = p.SKU,
                            AplicaExistencias = p.AplicaExistencias,
                            Id = p.Id,
                            IdCategoria = p.IdCategoria,
                            Categoria = string.Empty //responseCategorias.Items.First(c => c.Id.Equals(p.IdCategoria)).Nombre
                        }));
                    break;
                case 3:
                    ViewBag.Title = "En vivo (live)";
                    model.Items.AddRange(
                        response.Items.Where(p => p.AplicaExistencias).Select(p => new productomodel {
                            Descripcion = p.Descripcion,
                            ErrorMensaje = p.ErrorMensaje,
                            ErrorNumero = p.ErrorNumero,
                            Existencias = p.Existencias,
                            Nombre = p.Nombre,
                            PrecioMXN = p.PrecioMXN,
                            PrecioUSD = p.PrecioUSD,
                            Imagen = p.Foto,
                            Sku = p.SKU,
                            AplicaExistencias = p.AplicaExistencias,
                            Id = p.Id,
                            IdCategoria = p.IdCategoria,
                            Categoria = string.Empty //responseCategorias.Items.First(c => c.Id.Equals(p.IdCategoria)).Nombre
                        }));
                    break;
                case 4:
                    ViewBag.Title = "Existencias";
                    model.Items.AddRange(
                        response.Items.Where(p => p.AplicaExistencias).Select(p => new productomodel {
                            Descripcion = p.Descripcion,
                            ErrorMensaje = p.ErrorMensaje,
                            ErrorNumero = p.ErrorNumero,
                            Existencias = p.Existencias,
                            Nombre = p.Nombre,
                            PrecioMXN = p.PrecioMXN,
                            PrecioUSD = p.PrecioUSD,
                            Imagen = p.Foto,
                            Sku = p.SKU,
                            AplicaExistencias = p.AplicaExistencias,
                            Id = p.Id,
                            IdCategoria = p.IdCategoria,
                            Categoria = string.Empty //responseCategorias.Items.First(c => c.Id.Equals(p.IdCategoria)).Nombre
                        }));
                    break;
                case 5:
                    ViewBag.Title = "Venta exprés";
                    model.Items.AddRange(
                        response.Items.Where(p => p.AplicaExistencias).Select(p => new productomodel {
                            Descripcion = p.Descripcion,
                            ErrorMensaje = p.ErrorMensaje,
                            ErrorNumero = p.ErrorNumero,
                            Existencias = p.Existencias,
                            Nombre = p.Nombre,
                            PrecioMXN = p.PrecioMXN,
                            PrecioUSD = p.PrecioUSD,
                            Imagen = p.Foto,
                            Sku = p.SKU,
                            AplicaExistencias = p.AplicaExistencias,
                            Id = p.Id,
                            IdCategoria = p.IdCategoria,
                            Categoria = string.Empty //responseCategorias.Items.First(c => c.Id.Equals(p.IdCategoria)).Nombre
                        }));
                    break;
            }

            return View(model);
        }

        /// <summary>
        /// Muestra el listado de comentarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Comentarios(listaproductosmodel modelo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// Muestra el listado de tickets de una compra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Tickets(listaproductosmodel modelo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Perfil(clientemodel modelo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View(modelo);
        }

        [HttpPost]
        public JsonResult agregarProducto(Carritomodel model) {
            return new JsonResult();
        }

        [HttpPost]
        public ActionResult quitarProducto(productomodel modelo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult subirTicket(Ticketmodel modelo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult agregarComentario(Comentariomodel modelo) {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root") {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}