using Jadet.AdministradorServicio;
using Jadet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebGrease.Configuration;

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
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            listaproductosmodel productos = new listaproductosmodel();
            var servicio = new AdministradorClient();
            var response = servicio.listarProductos(new ProductoRequest
            {
                Id = 0
            });
            var responseCategorias = servicio.listarCatalogo(new CatalogoRequest { IdTipoCatalogo = 0 });
            productos.Items.AddRange(
                response.Items.Select(p => new productomodel
                {
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
                    Categoria = responseCategorias.Items.First(c => c.Id.Equals(p.IdCategoria)).Nombre
                }));
            return View(productos);
        }

        [HttpPost]
        public JsonResult guardarProducto(productomodel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.guardarProducto(new ProductoRequest
                {
                    AplicaExistencias = model.AplicaExistencias,
                    Descripcion = model.Descripcion,
                    Existencias = model.Existencias,
                    Id = model.Id,
                    IdCategoria = model.IdCategoria,
                    Nombre = model.Nombre,
                    PrecioMXN = model.PrecioMXN,
                    PrecioUSD = model.PrecioUSD,
                    Foto = Encoding.UTF8.GetBytes(model.Nombre),
                    SKU = model.Sku
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarProducto(productomodel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new ProductoResponse(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.guardarProducto(new ProductoRequest
                {
                    AplicaExistencias = model.AplicaExistencias,
                    Descripcion = model.Descripcion,
                    Existencias = model.Existencias,
                    Id = model.Id,
                    IdCategoria = model.IdCategoria,
                    Nombre = model.Nombre,
                    PrecioMXN = model.PrecioMXN,
                    PrecioUSD = model.PrecioUSD,
                    Foto = Encoding.UTF8.GetBytes(model.Nombre),
                    SKU = model.Sku
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult guardarCatalogo(catalogoModel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new { respuesta = new CatalogoResponse() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.guardarCatalogo(new CatalogoRequest
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    IdTipoCatalogo = model.IdTipoCatalogo
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarCatalogo(catalogoModel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.bajaCatalogo(new CatalogoRequest
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    IdTipoCatalogo = model.IdTipoCatalogo
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult guardarEstatus(catalogoModel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new { respuesta = new ProductoResponse() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.guardarEstatus(new EstatusRequest
                {
                    Id = model.Id,
                    Nombre = model.Nombre,
                    IdTipoEstatus = model.IdTipoCatalogo
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult eliminarEstatus(productomodel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new ProductoResponse(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.guardarProducto(new ProductoRequest
                {
                    AplicaExistencias = model.AplicaExistencias,
                    Descripcion = model.Descripcion,
                    Existencias = model.Existencias,
                    Id = model.Id,
                    IdCategoria = model.IdCategoria,
                    Nombre = model.Nombre,
                    PrecioMXN = model.PrecioMXN,
                    PrecioUSD = model.PrecioUSD,
                    Foto = Encoding.UTF8.GetBytes(model.Nombre),
                    SKU = model.Sku
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult guardarCliente(clientemodel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.guardarCliente(new ClienteRequest
                {
                    Direccion = model.Direccion,
                    IdCliente = model.IdCliente,
                    IdEstatus = model.IdEstatus,
                    IdRol = model.IdRol,
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
        public JsonResult eliminarCliente(clientemodel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return Json(new { respuesta = new ClienteResponse() }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var servicio = new AdministradorClient();
                var response = servicio.bajaCliente(new ClienteRequest
                {
                    Direccion = model.Direccion,
                    IdCliente = model.IdCliente,
                    IdEstatus = model.IdEstatus,
                    IdRol = model.IdRol,
                    Nombre = model.Nombre,
                    Foto = Encoding.UTF8.GetBytes(model.Nombre),
                    Password = Encoding.UTF8.GetBytes(model.password),
                    Telefono = model.Telefono,
                    UserName = model.usuario,
                    ZonaPaqueteria = model.ZonaPaqueteria
                });
                return Json(new { respuesta = response }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Guias()
        {
            return View();
        }

        public ActionResult Clientes()
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            listaclientesmodel clientes = new listaclientesmodel();
            var servicio = new AdministradorServicio.AdministradorClient();
            var response = servicio.listarClientes(new ClienteRequest
            {
                IdCliente = new Guid(),
                IdRol = 2
            });
            clientes.Items.AddRange(
                response.Items.Select(p => new clientemodel
                {
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

        public ActionResult Notas()
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Configuracion()
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var servicio = new AdministradorClient();
            var response = servicio.listarCatalogo(new CatalogoRequest
            {
                Id = 0,
                IdTipoCatalogo = 0
            });
            var resultado = new listacatalogoModel();
            resultado.Items.AddRange(response.Items.Select(i => new catalogoModel
            {
                Id = i.Id,
                IdTipoCatalogo = i.IdTipoCatalogo,
                Nombre = i.Nombre,
                Tabla = "CATÁLOGO"
            }));
            var response2 = servicio.listarEstatus(new EstatusRequest { Id = 0, IdTipoEstatus = 0 });
            resultado.Items.AddRange(response2.Items.Select(i => new catalogoModel
            {
                Id = i.Id,
                IdTipoCatalogo = i.IdTipoEstatus,
                Nombre = i.Nombre,
                Tabla = "ESTÁTUS"
            }));
            return View(resultado);
        }

        public JsonResult obtenerDiccionario(int IdTipo)
        {
            var servicio = new AdministradorClient();
            var response = servicio.listarCatalogo(new CatalogoRequest
            {
                IdTipoCatalogo = IdTipo
            });

            return Json(response.Items.Select(e => new { id = e.Id, nombre = e.Nombre }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerTiposCatalogos(int IdTipo)
        {
            var servicio = new AdministradorClient();
            var response = servicio.listarTipoCatalogo(new TipoCatalogoRequest
            {
                Id = IdTipo
            });
            return Json(response.Items.Select(e => new { id = e.Id, nombre = e.Nombre }).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerEstatus(int IdTipo)
        {
            var servicio = new AdministradorClient();
            var response = servicio.listarEstatus(new EstatusRequest
            {
                Id = IdTipo
            });
            return Json(response.Items.Select(e => new { id = e.Id, nombre = e.Nombre, Tipo = e.IdTipoEstatus }).ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}