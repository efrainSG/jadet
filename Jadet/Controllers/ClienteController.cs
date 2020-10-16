using Jadet.AdministradorServicio;
using Jadet.ClienteServicio;
using Jadet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
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
            ClienteClient servicio = new ClienteClient();
            AdministradorClient servicioAdmin = new AdministradorClient();
            var response = servicio.listarPedidos(new CarritoRequest {
                IdCliente = (Session["usuario"] as loginmodel).usrguid,
                IdEstatus = 6
            });
            var responseTipos = servicioAdmin.listarCatalogo(new CatalogoRequest {
                Id = 0,
                IdTipoCatalogo = 0
            });
            var responseEstatus = servicioAdmin.listarEstatus(new EstatusRequest {
                Id = 0,
                IdTipoEstatus = 0
            });

            notacollectionModel pedidos = new notacollectionModel();
            pedidos.Items.AddRange(response.Items.Select(i => new notaModel {
                IdCliente = i.IdCliente,
                Estatus = (i.IdEstatus != 0) ? responseEstatus.Items.FirstOrDefault(e => e.Id == i.IdEstatus).Nombre : string.Empty,
                IdEstatus = i.IdEstatus,
                Fecha = i.Fecha,
                FechaEnvio = i.FechaEnvio,
                Folio = i.Folio,
                Guia = i.Guia,
                IdPaqueteria = i.IdPaqueteria,
                IdTipo = i.IdTipo,
                MontoMXN = i.MontoMXN,
                MontoUSD = i.MontoUSD,
                Paqueteria = (i.IdPaqueteria != 0) ? responseTipos.Items.FirstOrDefault(pa => pa.Id == i.IdPaqueteria).Nombre : string.Empty,
                SaldoMXN = i.SaldoMXN,
                SaldoUSD = i.SaldoUSD,
                Tipo = (i.IdTipo != 0) ? responseTipos.Items.FirstOrDefault(t => t.Id == i.IdTipo).Nombre : string.Empty
            }));
            return View(pedidos);
        }

        [HttpGet]
        public JsonResult JsonDetalleCarrito(int idCarrito) {
            return Json(detalleCarrito(idCarrito), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DetalleCarrito(int idCarrito) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View(detalleCarrito(idCarrito));
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
            ClienteClient servicio = new ClienteClient();
            AdministradorClient servicioAdmin = new AdministradorClient();
            var response = servicio.listarPedidos(new CarritoRequest {
                IdCliente = (Session["usuario"] as loginmodel).usrguid
            });
            var responseTipos = servicioAdmin.listarCatalogo(new CatalogoRequest {
                Id = 0,
                IdTipoCatalogo = 0
            });
            var responseEstatus = servicioAdmin.listarEstatus(new EstatusRequest {
                Id = 0,
                IdTipoEstatus = 0
            });

            notacollectionModel pedidos = new notacollectionModel();
            pedidos.Items.AddRange(response.Items.Where(i => i.IdEstatus != 6).Select(i => new notaModel {
                IdCliente = i.IdCliente,
                Estatus = (i.IdEstatus != 0) ? responseEstatus.Items.FirstOrDefault(e => e.Id == i.IdEstatus).Nombre : string.Empty,
                IdEstatus = i.IdEstatus,
                Fecha = i.Fecha,
                FechaEnvio = i.FechaEnvio,
                Folio = i.Folio,
                Guia = i.Guia,
                IdPaqueteria = i.IdPaqueteria,
                IdTipo = i.IdTipo,
                MontoMXN = i.MontoMXN,
                MontoUSD = i.MontoUSD,
                Paqueteria = (i.IdPaqueteria != 0) ? responseTipos.Items.FirstOrDefault(pa => pa.Id == i.IdPaqueteria).Nombre : string.Empty,
                SaldoMXN = i.SaldoMXN,
                SaldoUSD = i.SaldoUSD,
                Tipo = (i.IdTipo != 0) ? responseTipos.Items.FirstOrDefault(t => t.Id == i.IdTipo).Nombre : string.Empty
            }));
            return View(pedidos);
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
        public ActionResult Comentarios(int folio) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            ClienteClient cliente = new ClienteClient();
            var response = cliente.listarComentarios(new ClienteServicio.NotaComentarioRequest {
                IdNota = folio
            });
            var responseNota = cliente.listarPedidos(new CarritoRequest { Folio = 0 }).Items
                .FirstOrDefault(i => i.Folio == folio);
            listaComentariosmodel lista = new listaComentariosmodel {
                Datos = new notaModel {
                    Fecha = responseNota.Fecha,
                    FechaEnvio = responseNota.FechaEnvio,
                    Folio = responseNota.Folio,
                    Guia = responseNota.Guia,
                    IdCliente = responseNota.IdCliente,
                    IdEstatus = responseNota.IdEstatus,
                    IdPaqueteria = responseNota.IdPaqueteria,
                    IdTipo = responseNota.IdTipo,
                    MontoMXN = responseNota.MontoMXN,
                    MontoUSD = responseNota.MontoUSD,
                    SaldoMXN = responseNota.SaldoMXN,
                    SaldoUSD = responseNota.SaldoUSD
                }
            };

            lista.Items.AddRange(response.Items.Select(i => new Comentariomodel {
                Fecha = i.Fecha,
                FolioNota = i.IdNota,
                Id = i.Id,
                IdPadre = i.IdComentarioAnterior,
                Mensaje = i.Comentario
            }));
            return View(lista);
        }

        /// <summary>
        /// Muestra el listado de tickets de una compra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Tickets(int folio) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            ClienteClient cliente = new ClienteClient();
            AdministradorClient admin = new AdministradorClient();
            var tipos = admin.listarTipoCatalogo(new TipoCatalogoRequest {
                Id = 0
            });
            var carrito = cliente.verPedido(new CarritoRequest {
                Folio = folio
            });
            var response = cliente.listarTickets(new ClienteServicio.NotaTicketRequest {
                IdNota = folio
            });
            listaTicketsmodel listaTicketsmodel = new listaTicketsmodel {
                Folio = folio,
                IdTipo = carrito.IdTipo,
                MontoMXN = carrito.MontoMXN,
                MontoUSD = carrito.MontoUSD,
                Items = response.Items.Select(i => new Ticketmodel {
                    Fecha = i.Fecha,
                    Id = i.Id,
                    IdNota = i.IdNota,
                    MontoMXN = i.MontoMXN,
                    MontoUSD = i.MontoUSD,
                    Ticket = i.Ticket
                }).ToList(),
                SaldoMXN = carrito.SaldoMXN,
                SaldoUSD = carrito.SaldoUSD,
                Tipo = string.Empty // tipos.Items.FirstOrDefault(i => i.Id == carrito.IdTipo).Nombre
            };

            return View(listaTicketsmodel);
        }

        [HttpGet]
        public ActionResult Perfil(clientemodel modelo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            ClienteClient cliente = new ClienteClient();
            AdministradorClient admin = new AdministradorClient();
            var mensajerias = admin.listarCatalogo(new CatalogoRequest { IdTipoCatalogo = 2 });
            var response = admin.cargarCliente(new ClienteRequest { IdCliente = (Session["usuario"] as loginmodel).usrguid });
            modelo = new clientemodel {
                IdCliente = response.IdCliente,
                Nombre = response.Nombre,
                ZonaPaqueteria = response.ZonaPaqueteria
            };
            ViewData.Add("mensajerias", mensajerias.Items.Select(i => new catalogoModel {
                Id = i.Id,
                IdTipoCatalogo = i.IdTipoCatalogo,
                Nombre = i.Nombre
            }));
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
                Id = model.Id,
                IdProducto = model.IdProducto,
                PrecioMXN = _producto.PrecioMXN,
                PrecioUSD = _producto.PrecioUSD,
                Cantidad = model.Cantidad
            });
            return Json(new { data = _agregado }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult quitarProducto(ItemCarritomodel modelo) {
            ClienteClient servicio = new ClienteClient();
            var _quitado = servicio.quitarDelCarrito(new ItemCarritoRequest {
                Id = modelo.Id,
                Cantidad = modelo.Cantidad,
                IdNota = modelo.IdNota,
                IdProducto = modelo.IdProducto,
                PrecioMXN = modelo.PrecioMXN,
                PrecioUSD = modelo.PrecioUSD
            });
            return Json(new { data = _quitado }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult generarPedido(Carritomodel modelo) {
            ClienteClient servicio = new ClienteClient();
            var resultado = servicio.generarPedido(new CarritoRequest {
                Folio = modelo.Folio,
                IdPaqueteria = modelo.IdPaqueteria,
                IdEstatus = modelo.IdEstatus
            });
            return RedirectToAction("Pedidos");
        }

        [HttpPost]
        public ActionResult subirTicket(Ticketmodel modelo, HttpPostedFileBase imgArch) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                string _ruta;
                var servicio = new ClienteClient();
                var archivo = Request.Files[0];
                if (archivo != null && archivo.ContentLength > 0) {
                    string _nomArch = string.Format("{0}-{1}-{2}{3}",
                        (Session["usuario"] as loginmodel).usuario, modelo.IdNota.ToString(),
                        DateTime.Now.ToString("yyyyMMddhhmmss"), archivo.FileName.Substring(archivo.FileName.IndexOf("."))
                        );
                    _ruta = Path.Combine(Server.MapPath("~/Content/tickets/"), _nomArch);
                    archivo.SaveAs(_ruta);
                    var response = servicio.guardarTicket(new ClienteServicio.NotaTicketRequest {
                        Fecha = DateTime.Now,
                        IdNota = modelo.IdNota,
                        MontoMXN = modelo.MontoMXN,
                        Id = modelo.Id,
                        MontoUSD = modelo.MontoUSD,
                        Ticket = Encoding.UTF8.GetBytes(_nomArch)
                    });
                    return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult agregarComentario(Comentariomodel modelo) {
            if (Session["usuario"] == null) {
                Session.Clear();
            }
            ClienteClient servicio = new ClienteClient();
            var _resultado = servicio.guardarComentario(new ClienteServicio.NotaComentarioRequest {
                Comentario = modelo.Mensaje,
                Fecha = DateTime.Now,
                IdComentarioAnterior = 0,
                IdNota = modelo.FolioNota
            });
            return RedirectToAction("Comentarios", new { folio = modelo.FolioNota });
        }

        [HttpPost]
        public ActionResult guardarPerfil(clientemodel modelo) {
            if (Session["usuario"] == null) {
                Session.Clear();
            }
            AdministradorClient admin = new AdministradorClient();
            var resultado = admin.cargarCliente(new ClienteRequest {
                IdCliente = (Session["usuario"] as loginmodel).usrguid
            });
            var response = admin.guardarCliente(new ClienteRequest {
                Direccion = resultado.Direccion,
                ExtensionData =null,
                Foto =resultado.Foto,
                IdCliente = resultado.IdCliente,
                IdEstatus = resultado.IdEstatus,
                IdRol = resultado.IdRol,
                Nombre = resultado.Nombre,
                Password = resultado.Password,
                Telefono = resultado.Telefono,
                UserName = resultado.UserName,
                ZonaPaqueteria = modelo.ZonaPaqueteria
            });
            return RedirectToAction("Perfil");
        }

        private CarritoCompletoModel detalleCarrito(int id) {
            ClienteClient servicio = new ClienteClient();
            AdministradorClient servicioAdmin = new AdministradorClient();

            CarritoResponse response = servicio.verPedido(new CarritoRequest { Folio = id });
            var responseCarrito = servicio.listarPedidos(new CarritoRequest {
                IdEstatus = 6,
                IdCliente = (Session["usuario"] as loginmodel).usrguid
            }).Items.FirstOrDefault(i => i.Folio == id);

            var responseTipos = servicioAdmin.listarCatalogo(new CatalogoRequest { Id = 0, IdTipoCatalogo = 0 });
            var responseEstatus = servicioAdmin.listarEstatus(new EstatusRequest { Id = 0, IdTipoEstatus = 0 });
            var productos = servicioAdmin.listarProductos(new ProductoRequest { Id = 0 });

            CarritoCompletoModel model = new CarritoCompletoModel {
                Cliente = responseCarrito.IdCliente.ToString(),
                Estatus = (responseCarrito.IdEstatus != 0) ? responseEstatus.Items.FirstOrDefault(e => e.Id == responseCarrito.IdEstatus).Nombre : string.Empty,
                Fecha = responseCarrito.Fecha,
                FechaEnvio = responseCarrito.FechaEnvio,
                Folio = responseCarrito.Folio,
                Guia = string.Empty,
                IdCliente = responseCarrito.IdCliente,
                IdEstatus = responseCarrito.IdEstatus,
                IdPaqueteria = responseCarrito.IdPaqueteria,
                IdTipo = responseCarrito.IdTipo,
                MontoMXN = responseCarrito.MontoMXN,
                MontoUSD = responseCarrito.MontoUSD,
                Paqueteria = string.Empty,
                SaldoMXN = responseCarrito.SaldoMXN,
                SaldoUSD = responseCarrito.SaldoUSD,
                Tipo = (responseCarrito.IdTipo != 0) ? responseTipos.Items.FirstOrDefault(t => t.Id == responseCarrito.IdTipo).Nombre : string.Empty
            };
            model.Items.AddRange(response.Items.Select(i => new detallenotaModel {
                Cantidad = i.Cantidad,
                Id = i.Id,
                IdNota = i.IdNota,
                IdProducto = i.IdProducto,
                PrecioMXN = i.PrecioMXN,
                PrecioUSD = i.PrecioUSD,
                Producto = productos.Items.FirstOrDefault(p => p.Id == i.IdProducto).Nombre
            }));
            return model;
        }
    }
}