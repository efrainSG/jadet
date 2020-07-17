using Jadet.AdministradorServicio;
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
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            listaproductosmodel productos = new listaproductosmodel();
            var servicio = new AdministradorServicio.AdministradorClient();
            var response = servicio.listarProductos(new ProductoRequest
            {
                Id = 0
            });
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
                    IdCategoria = p.IdCategoria
                }));
            return View(productos);
        }

        [HttpPost]
        public ActionResult guardarProducto(productomodel model)
        {
            if (Session["usuario"] == null || (Session["usuario"] as loginmodel).usuario != "Root")
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Productos");
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

    }
}