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
            return View();
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
    }
}