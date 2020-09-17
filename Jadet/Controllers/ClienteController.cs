using Jadet.AdministradorServicio;
using Jadet.ClienteServicio;
using Jadet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Jadet.Controllers {
    public class ClienteController : Controller {
        // GET: Cliente
        [HttpGet]
        public ActionResult Index() {
            if (Session["usuario"] != null)
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
        public ActionResult Carrito() {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var servicio = new ClienteClient();
            
            return View();
        }

        /// <summary>
        /// Muestra un listado de los pedidos hechos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Pedidos() {
            if (Session["usuario"] == null) {
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
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            AdministradorClient servicio = new AdministradorClient();
            var response = servicio.listarProductos(new ProductoRequest {
                Id = 0
            });
            listaproductosmodel model = new listaproductosmodel();
            ViewBag.TipoVenta = idTipo;
            switch (idTipo) {
                case 1:
                    ViewBag.Title = "Preventa";
                    model.Items.AddRange(
                        response.Items.Where(p => !p.AplicaExistencias).Select(p => new productomodel {
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
                            IdTipo = idTipo,
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
                            IdTipo = idTipo,
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
                            IdTipo = idTipo,
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
                            IdTipo = idTipo,
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
                            IdTipo = idTipo,
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
            if (Session["usuario"] == null) {
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
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Perfil(clientemodel modelo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View(modelo);
        }

        [HttpPost]
        public JsonResult agregarProducto(ItemCarritomodel model) {
            ClienteClient servicio = new ClienteClient();
            AdministradorClient admin = new AdministradorClient();
            var _carrito = (Session["carritos"] as Dictionary<int, int?>)[model.IdTipo];
            var _producto = admin.cargarProducto(new ProductoRequest { Id = model.IdProducto });

            if (!_carrito.HasValue) {
                CarritoResponse _nuevoCarrito = servicio.nuevoCarrito(new CarritoRequest {
                    IdTipo = model.IdTipo,
                    Fecha = DateTime.Today,
                    IdCliente = (Session["usuario"] as loginmodel).usrguid,
                    IdEstatus = 6,
                    IdPaqueteria = 7
                });
                (Session["carritos"] as Dictionary<int, int?>)[model.IdTipo] = _nuevoCarrito.Folio;
            }
            var _agregado = servicio.agregarACarrito(new ItemCarritoRequest {
                IdNota = (Session["carritos"] as Dictionary<int, int?>)[model.IdTipo].Value,
                IdProducto = model.IdProducto,
                PrecioMXN = _producto.PrecioMXN,
                PrecioUSD = _producto.PrecioUSD,
                Cantidad = model.Cantidad
            });
            return Json(new { data = _agregado }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult quitarProducto(productomodel modelo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult subirTicket(Ticketmodel modelo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult agregarComentario(Comentariomodel modelo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}