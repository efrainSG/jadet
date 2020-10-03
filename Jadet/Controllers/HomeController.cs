using Jadet.AdministradorServicio;
using Jadet.Models;
using Jadet.SeguridadServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jadet.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult hazLogin(loginmodel model) {
            string accion = "Index", controlador = "Home";
            if (!string.IsNullOrEmpty(model.usuario) && !string.IsNullOrEmpty(model.password)) {
                var servicio = new SeguridadClient();
                var response = servicio.IniciarSesion(new LoginRequest {
                    Usuario = model.usuario,
                    password = model.password
                });

                if (response.ErrorNumero == 0) {
                    Session.Clear();
                    Session.Add("usuario", new loginmodel {
                        usuario = response.Usuario,
                        password = "****",
                        usrguid = response.IdUsuario
                    });
                    switch (response.RolUsuario.IdRol) {
                        case 1:
                            controlador = "Administrador";
                            break;
                        case 2:
                            controlador = "Cliente";
                            Dictionary<int, int?> _carritos = new Dictionary<int, int?>();
                            var _admin = new AdministradorClient();
                            var _lista = _admin.listarCatalogo(new CatalogoRequest { IdTipoCatalogo = 1 });
                            var _carritosactuales = _admin.listarNotas(new NotaRequest {
                                IdCliente = (Session["usuario"] as loginmodel).usrguid,
                                IdEstatus = 6
                            });
                            foreach (var item in _lista.Items) {
                                var _carrito = _carritosactuales.Items.FirstOrDefault(c => c.IdTipo.Equals(item.Id)
                                && c.IdCliente.Equals((Session["usuario"] as loginmodel).usrguid));
                                if (_carrito != null)
                                    _carritos.Add(item.Id, _carrito.Folio);
                                else
                                    _carritos.Add(item.Id, null);
                            }
                            Session.Add("carritos", _carritos);
                            break;
                        default:
                            break;
                    }
                    return RedirectToAction(accion, controlador);
                }
                return View("Index", new loginmodel() {
                    ErrorNumero = response.ErrorNumero,
                    ErrorMensaje = response.ErrorMensaje
                });
            } else {
                return View("Index", new loginmodel() {
                    ErrorNumero = 2,
                    ErrorMensaje = "Falta usuario o contraseña"
                });
            }
        }
    }
}
