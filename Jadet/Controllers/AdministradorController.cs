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
            productos.Items.Add(new productomodel
            {
                Sku = "A00000",
                Nombre = "Producto 1",
                Descripcion = "Producto uno",
                Existencias = 10,
                RutaImagen = "../Content/imgs/103373701_745367459536215_6683955577034642454_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00001",
                Nombre = "Producto 2",
                Descripcion = "Producto dos",
                Existencias = 10,
                RutaImagen = "../Content/imgs/106726574_619939592236905_8451229284513577533_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00002",
                Nombre = "Producto 3",
                Descripcion = "Producto tres",
                Existencias = 10,
                RutaImagen = "../Content/imgs/106925028_276980433358784_3564958967851603976_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00003",
                Nombre = "Producto 4",
                Descripcion = "Producto cuatro",
                Existencias = 10,
                RutaImagen = "../Content/imgs/107100168_575722183139154_7671637487869851358_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00004",
                Nombre = "Producto 5",
                Descripcion = "Producto cinco",
                Existencias = 10,
                RutaImagen = "../Content/imgs/107343952_285192662700377_4387108442096812264_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00005",
                Nombre = "Producto 6",
                Descripcion = "Producto seis",
                Existencias = 10,
                RutaImagen = "../Content/imgs/107485999_761173144656157_7653469568639381490_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00006",
                Nombre = "Producto 7",
                Descripcion = "Producto siete",
                Existencias = 10,
                RutaImagen = "../Content/imgs/107700091_605326170114874_5692240400939541068_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00007",
                Nombre = "Producto 8",
                Descripcion = "Producto ocho",
                Existencias = 10,
                RutaImagen = "../Content/imgs/107728691_741771619931603_148549030520414310_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00008",
                Nombre = "Producto 9",
                Descripcion = "Producto nueve",
                Existencias = 10,
                RutaImagen = "../Content/imgs/107761698_275912170409017_4174448911657339959_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            productos.Items.Add(new productomodel
            {
                Sku = "A00009",
                Nombre = "Producto 10",
                Descripcion = "Producto diez",
                Existencias = 10,
                RutaImagen = "../Content/imgs/107856000_702503103934248_1656178707960925460_n.jpg",
                ErrorNumero = 0,
                ErrorMensaje = string.Empty,
                PrecioMXN = 150m,
                PrecioUSD = 7.5m
            });
            return View(productos);
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
            clientes.Items.Add(new clientemodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario uno",
                usuario = "user1",
                password = string.Empty
            });
            clientes.Items.Add(new clientemodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario dos",
                usuario = "user2",
                password = string.Empty
            });
            clientes.Items.Add(new clientemodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario tres",
                usuario = "user3",
                password = string.Empty
            });
            clientes.Items.Add(new clientemodel
            {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Nombre = "Usuario cuatro",
                usuario = "user4",
                password = string.Empty
            });
            clientes.Items.Add(new clientemodel
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