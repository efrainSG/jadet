using Jadet.AdministradorServicio;
using Jadet.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Jadet.Controllers {
    public class AdministradorController : Controller {
        // GET: Administrador
        public ActionResult Index() {
            if (Session["usuario"] != null)
                return View();
            else {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
        }
        #region Carga de listas
        public ActionResult Productos() {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            listaproductosmodel productos = new listaproductosmodel();
            var servicio = new AdministradorClient();
            var response = servicio.listarProductos(new ProductoRequest {
                Id = 0
            });
            var responseCategorias = servicio.listarCatalogo(new CatalogoRequest { IdTipoCatalogo = 0 });
            productos.Items.AddRange(
                response.Items.Select(p => new productomodel {
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
                    IdEstatus = p.IdEstatus,
                    
                    Categoria = responseCategorias.Items.First(c => c.Id.Equals(p.IdCategoria)).Nombre
                }));
            return View(productos);
        }

        public ActionResult Guias() {
            return View();
        }

        public ActionResult Clientes() {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            listaclientesmodel clientes = new listaclientesmodel();
            var servicio = new AdministradorServicio.AdministradorClient();
            var response = servicio.listarClientes(new ClienteRequest {
                IdCliente = new Guid(),
                IdRol = 2
            });
            clientes.Items.AddRange(
                response.Items.Select(p => new clientemodel {
                    Nombre = p.Nombre,
                    usuario = p.UserName,
                    Direccion = p.Direccion,
                    ErrorMensaje = p.ErrorMensaje,
                    ErrorNumero = p.ErrorNumero,
                    IdCliente = p.IdCliente,
                    IdEstatus = p.IdEstatus,
                    Telefono = p.Telefono,
                    ZonaPaqueteria = p.ZonaPaqueteria
                }));
            return View(clientes);
        }

        public ActionResult Notas() {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            listaNotaModel notas = new listaNotaModel();
            var servicio = new AdministradorServicio.AdministradorClient();
            var response = servicio.listarNotas(new NotaRequest {
                Folio = 0,
                Fecha = null,
                IdEstatus = 0
            });
            var responseClientes = servicio.listarClientes(new ClienteRequest {
                IdCliente = new Guid(),
                IdRol = 2
            });
            var responseTipos = servicio.listarCatalogo(new CatalogoRequest {
                Id = 0,
                IdTipoCatalogo = 0
            });
            var responseEstatus = servicio.listarEstatus(new EstatusRequest {
                Id = 0,
                IdTipoEstatus = 0
            });

            notas.Items.AddRange(
                response.Items.Select(p => new notaModel {
                    Fecha = p.Fecha,
                    FechaEnvio = p.FechaEnvio,
                    Folio = p.Folio,
                    IdPaqueteria = p.IdPaqueteria,
                    Paqueteria = (p.IdPaqueteria != 0) ? responseTipos.Items.FirstOrDefault(pa => pa.Id == p.IdPaqueteria).Nombre : string.Empty,
                    Guia = p.Guia,
                    IdEstatus = p.IdEstatus,
                    Estatus = (p.IdEstatus != 0) ? responseEstatus.Items.FirstOrDefault(e => e.Id == p.IdEstatus).Nombre : string.Empty,
                    IdCliente = p.IdCliente,
                    Cliente = responseClientes.Items.FirstOrDefault(c => c.IdCliente == p.IdCliente).Nombre,
                    IdTipo = p.IdTipo,
                    Tipo = (p.IdTipo != 0) ? responseTipos.Items.FirstOrDefault(t => t.Id == p.IdTipo).Nombre : string.Empty,
                    MontoMXN = p.MontoMXN,
                    MontoUSD = p.MontoUSD,
                    SaldoMXN = p.SaldoMXN,
                    SaldoUSD = p.SaldoUSD
                }));
            return View(notas);
        }

        public ActionResult Configuracion() {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var servicio = new AdministradorClient();
            var response = servicio.listarCatalogo(new CatalogoRequest {
                Id = 0,
                IdTipoCatalogo = 0
            });
            var resultado = new listacatalogoModel();
            resultado.Items.AddRange(response.Items.Select(i => new catalogoModel {
                Id = i.Id,
                IdTipoCatalogo = i.IdTipoCatalogo,
                Nombre = i.Nombre,
                Tabla = "CATÁLOGO"
            }));
            var response2 = servicio.listarEstatus(new EstatusRequest { Id = 0, IdTipoEstatus = 0 });
            resultado.Items.AddRange(response2.Items.Select(i => new catalogoModel {
                Id = i.Id,
                IdTipoCatalogo = i.IdTipoEstatus,
                Nombre = i.Nombre,
                Tabla = "ESTÁTUS"
            }));
            return View(resultado);
        }

        [HttpGet]
        public ActionResult DetalleNota(int folio) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var servicio = new AdministradorClient();
            notacompletaModel model;
            var response = servicio.cargarNota(new NotaRequest { Folio = folio });
            var responsedetalle = servicio.cargarDetalleNota(new DetalleNotaRequest { IdNota = folio });
            var responseClientes = servicio.listarClientes(new ClienteRequest { IdCliente = new Guid(), IdRol = 2 });
            var responseTipos = servicio.listarCatalogo(new CatalogoRequest { Id = 0, IdTipoCatalogo = 0 });
            var responseEstatus = servicio.listarEstatus(new EstatusRequest { Id = 0, IdTipoEstatus = 0 });
            var responseItems = servicio.listarDetalleNota(new DetalleNotaRequest { IdNota = folio });
            var productos = servicio.listarProductos(new ProductoRequest { Id = 0 });
            var comentarios = servicio.listarComentarioNota(new NotaComentarioRequest { IdNota = folio }).Items;
            //var tickets = servicio.listarTicketNota(new NotaTicketRequest { IdNota = folio }).Items;
            model = new notacompletaModel {
                Fecha = response.Fecha,
                FechaEnvio = response.FechaEnvio,
                Folio = response.Folio,
                Guia = response.Guia,
                IdCliente = response.IdCliente,
                Cliente = responseClientes.Items.FirstOrDefault(c => c.IdCliente == response.IdCliente).Nombre,
                IdEstatus = response.IdEstatus,
                Estatus = (response.IdEstatus != 0) ? responseEstatus.Items.FirstOrDefault(e => e.Id == response.IdEstatus).Nombre : string.Empty,
                IdPaqueteria = response.IdPaqueteria,
                Paqueteria = (response.IdPaqueteria != 0) ? responseTipos.Items.FirstOrDefault(pa => pa.Id == response.IdPaqueteria).Nombre : string.Empty,
                IdTipo = response.IdTipo,
                Tipo = (response.IdTipo != 0) ? responseTipos.Items.FirstOrDefault(t => t.Id == response.IdTipo).Nombre : string.Empty,
                MontoMXN = response.MontoMXN,
                MontoUSD = response.MontoUSD,
                SaldoMXN = response.SaldoMXN,
                SaldoUSD = response.SaldoUSD,
                Comentarios = comentarios.Select(i => new Comentariomodel {
                    Id = i.Id,
                    Fecha = i.Fecha,
                    FolioNota = i.IdNota,
                    Mensaje = i.Comentario
                }).ToList(),
                //Tickets = tickets.Select(i => new Ticketmodel {
                //    Id = i.Id,
                //    Fecha = i.Fecha,
                //    IdNota = i.IdNota,
                //    Ticket = i.Ticket,
                //    MontoUSD = i.MontoUSD,
                //    MontoMXN = i.MontoMXN
                //}).ToList()
            };
            model.Items.AddRange(responseItems.Items.Select(i => new detallenotaModel {
                Cantidad = i.Cantidad,
                Id = i.Id,
                IdNota = i.IdNota,
                IdProducto = i.IdProducto,
                Producto = productos.Items.FirstOrDefault(p => p.Id == i.IdProducto).Nombre,
                PrecioMXN = i.PrecioMXN,
                PrecioUSD = i.PrecioUSD
            }));

            return View(model);
        }

        [HttpGet]
        public ActionResult Tickets(int folio) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var servicio = new AdministradorClient();
            var listatickets = new listaTicketsmodel();
            var response = servicio.listarTicketNota(new NotaTicketRequest { IdNota = folio });
            listatickets.Items.AddRange(response.Items.Select(i => new Ticketmodel {
                Id = i.Id,
                Fecha = i.Fecha,
                IdNota = i.IdNota,
                Ticket = i.Ticket,
                MontoMXN = i.MontoMXN,
                MontoUSD = i.MontoUSD
            }));
            return View(listatickets);
        }

        [HttpGet]
        public ActionResult Comentarios(int folio) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var servicio = new AdministradorClient();
            var listacomentarios = new Models.listaComentariosmodel();
            var response = servicio.listarComentarioNota(new NotaComentarioRequest { IdNota = folio });
            listacomentarios.Items.AddRange(response.Items.Select(i => new Comentariomodel {
                Id = i.Id,
                Fecha = i.Fecha,
                FolioNota = i.IdNota,
                Mensaje = i.Comentario,
                IdPadre = i.IdComentarioAnterior
            }));
            return View(listacomentarios);
        }
        #endregion Carga de listas


        [HttpPost]
        public JsonResult guardarProducto(productomodel model, HttpPostedFileBase imgArch) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var archivo = Request.Files[0];
                if (archivo != null && archivo.ContentLength > 0) {
                    string _nomArch = Path.GetFileName(archivo.FileName);
                    string _ruta = Path.Combine(Server.MapPath("~/Content/productos"), _nomArch);
                    archivo.SaveAs(_ruta);
                }
                var response = servicio.guardarProducto(new ProductoRequest {
                    AplicaExistencias = model.AplicaExistencias,
                    Descripcion = model.Descripcion,
                    Existencias = model.Existencias,
                    Id = model.Id,
                    IdCategoria = model.IdCategoria,
                    Nombre = model.Nombre,
                    PrecioMXN = model.PrecioMXN,
                    IdEstatus = model.IdEstatus,
                    PrecioUSD = model.PrecioUSD,
                    Foto = Encoding.UTF8.GetBytes(archivo.FileName),
                    SKU = model.Sku
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarProducto(productomodel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new ProductoResponse(), JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.bajaProducto(new ProductoRequest {
                    Id = model.Id,
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult guardarCatalogo(catalogoModel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new CatalogoResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.guardarCatalogo(new CatalogoRequest {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    IdTipoCatalogo = model.IdTipoCatalogo
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarCatalogo(catalogoModel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.bajaCatalogo(new CatalogoRequest {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    IdTipoCatalogo = model.IdTipoCatalogo
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult guardarEstatus(catalogoModel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.guardarEstatus(new EstatusRequest {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    IdTipoEstatus = model.IdTipoCatalogo
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarEstatus(catalogoModel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new ProductoResponse(), JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.bajaEstatus(new EstatusRequest {
                    Id = model.Id,
                    Nombre = model.Nombre
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult guardarCliente(clientemodel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.guardarCliente(new ClienteRequest {
                    Direccion = model.Direccion,
                    IdCliente = model.IdCliente,
                    IdEstatus = model.IdEstatus,
                    IdRol = (model.IdRol != 0) ? model.IdRol : 2,
                    Nombre = model.Nombre,
                    Password = Encoding.UTF8.GetBytes(model.password ?? string.Empty),
                    Telefono = model.Telefono,
                    UserName = model.usuario,
                    Foto = Encoding.UTF8.GetBytes(model.Nombre),
                    ZonaPaqueteria = model.ZonaPaqueteria
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarCliente(clientemodel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.bajaCliente(new ClienteRequest {
                    IdCliente = model.IdCliente,
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerNota(int folio) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            }
            var servicio = new AdministradorClient();
            var preresponse = servicio.cargarNota(new NotaRequest {
                Folio = folio
            });
            var responseClientes = servicio.listarClientes(new ClienteRequest {
                IdCliente = preresponse.IdCliente
            });
            var responseTipos = servicio.listarCatalogo(new CatalogoRequest {
                Id = preresponse.IdTipo
            });
            var responseEstatus = servicio.listarEstatus(new EstatusRequest {
                Id = preresponse.IdEstatus
            });
            var responsePaqueterias = servicio.listarCatalogo(new CatalogoRequest {
                Id = preresponse.IdPaqueteria
            });

            notaModel response = new notaModel {
                Cliente = responseClientes.Items.FirstOrDefault().Nombre,
                IdCliente = preresponse.IdCliente,
                Estatus = responseEstatus.Items.FirstOrDefault().Nombre,
                IdEstatus = preresponse.IdEstatus,
                Fecha = preresponse.Fecha,
                FechaEnvio = preresponse.FechaEnvio,
                Folio = preresponse.Folio,
                Guia = preresponse.Guia,
                IdPaqueteria = preresponse.IdPaqueteria,
                Paqueteria = responsePaqueterias.Items.FirstOrDefault().Nombre,
                IdTipo = preresponse.IdTipo,
                Tipo = responseTipos.Items.FirstOrDefault().Nombre,
                MontoMXN = preresponse.MontoMXN,
                MontoUSD = preresponse.MontoUSD,
                SaldoMXN = preresponse.SaldoMXN,
                SaldoUSD = preresponse.SaldoUSD
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult guardarNota(notaModel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.guardarNota(new NotaRequest {
                    Fecha = model.Fecha,
                    FechaEnvio = model.FechaEnvio,
                    Folio = model.Folio,
                    Guia = model.Guia,
                    IdCliente = model.IdCliente,
                    IdEstatus = model.IdEstatus,
                    IdPaqueteria = model.IdPaqueteria,
                    IdTipo = model.IdTipo,
                    MontoMXN = model.MontoMXN,
                    MontoUSD = model.MontoUSD,
                    SaldoMXN = model.SaldoMXN,
                    SaldoUSD = model.SaldoUSD
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarNota(notaModel model) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            } else {
                var servicio = new AdministradorClient();
                var response = servicio.bajaNota(new NotaRequest {
                    Fecha = model.Fecha,
                    FechaEnvio = model.FechaEnvio,
                    Folio = model.Folio,
                    Guia = model.Guia,
                    IdCliente = model.IdCliente,
                    IdEstatus = model.IdEstatus,
                    IdPaqueteria = model.IdPaqueteria,
                    IdTipo = model.IdTipo,
                    MontoMXN = model.MontoMXN,
                    MontoUSD = model.MontoUSD,
                    SaldoMXN = model.SaldoMXN,
                    SaldoUSD = model.SaldoUSD
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult obtenerDiccionario(int IdTipo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            }
            var servicio = new AdministradorClient();
            var response = servicio.listarCatalogo(new CatalogoRequest {
                IdTipoCatalogo = IdTipo
            });

            return Json(response.Items.Select(e => new { id = e.Id, nombre = e.Nombre }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerTiposCatalogos(int IdTipo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            }
            var servicio = new AdministradorClient();
            var response = servicio.listarTipoCatalogo(new TipoCatalogoRequest {
                Id = IdTipo
            });
            return Json(response.Items.Select(e => new { id = e.Id, nombre = e.Nombre }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerEstatus(int IdTipo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            }
            var servicio = new AdministradorClient();
            var response = servicio.listarEstatus(new EstatusRequest {
                Id = IdTipo
            });
            return Json(response.Items.Select(e => new { id = e.Id, nombre = e.Nombre, Tipo = e.IdTipoEstatus }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerTipoEstatus(int IdTipo) {
            if (Session["usuario"] == null) {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            }
            var servicio = new AdministradorClient();
            var response = servicio.listarTipoEstatus(new TipoEstatusRequest {
                Id = IdTipo
            });
            return Json(response.Items.Select(e => new { id = e.Id, nombre = e.Nombre }).ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}