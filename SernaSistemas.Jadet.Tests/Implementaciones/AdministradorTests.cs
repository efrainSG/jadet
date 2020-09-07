using Microsoft.VisualStudio.TestTools.UnitTesting;
using SernaSisitemas.Jadet.WCF.Implementaciones;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSisitemas.Jadet.WCF.Implementaciones.Tests {
    [TestClass()]
    public class AdministradorTests {
        Administrador servicio;

        [TestInitialize]
        public void init() {
            servicio = new Administrador();
        }

        [TestMethod()]
        public void bajaCatalogoTest() {
            try {
                var catalogo = servicio.listarCatalogo(new CatalogoRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.bajaCatalogo(new CatalogoRequest {
                    Id = catalogo.Id
                });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void bajaClienteTest() {
            try {
                var icliente = servicio.listarClientes(new ClienteRequest()).Items.Where(i => i.Nombre.Contains("prueba")).FirstOrDefault();
                var response = servicio.bajaCliente(new ClienteRequest { IdCliente = icliente.IdCliente });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void bajaComentarioNotaTest() {
            try {
                var icomentario = servicio.listarComentarioNota(new NotaComentarioRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.bajaComentarioNota(new NotaComentarioRequest { Id = icomentario.Id });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void bajaDetalleNotaTest() {
            try {
                var idetalle = servicio.listarDetalleNota(new DetalleNotaRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.bajaDetalleNota(new DetalleNotaRequest { Id = idetalle.Id });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void bajaTicketNotaTest() {
            try {
                var iticket = servicio.listarTicketNota(new NotaTicketRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.bajaTicketNota(new NotaTicketRequest { Id = iticket.Id });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void bajaEstatusTest() {
            try {
                var estatus = servicio.listarEstatus(new EstatusRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.bajaEstatus(new EstatusRequest {
                    Id = estatus.Id
                });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void bajaNotaTest() {
            try {
                var Nota = servicio.listarNotas(new NotaRequest { Folio = 0, IdEstatus = 0 }).Items
                    .OrderByDescending(n => n.Folio)
                    .FirstOrDefault();
                var response = servicio.bajaNota(new NotaRequest { Folio = Nota.Folio });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void bajaProductoTest() {
            try {
                var producto = servicio.listarProductos(new ProductoRequest { Id = 0, IdEstatus = 0 }).Items
                .OrderByDescending(n => n.Id)
                .FirstOrDefault();
                var response = servicio.bajaProducto(new ProductoRequest { Id = producto.Id });
                Console.WriteLine("{0}\n{1}\n", response.ErrorNumero, response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod()]
        //public void cambiarEstatusPaginaTest()
        //{
        //    throw new NotImplementedException();
        //}

        [TestMethod()]
        public void cargarCatalogoTest() {
            try {
                var response = servicio.cargarCatalogo(new CatalogoRequest {
                    Id = 8,
                    IdTipoCatalogo = 0
                });
                Console.WriteLine("Id: {0}\nId de Tipo de Catálogo: {1}\nNombre: {2}\n----------------------------",
                    response.Id,
                    response.IdTipoCatalogo,
                    response.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void cargarClienteTest() {
            try {
                var response = servicio.cargarCliente(new ClienteRequest {
                    IdCliente = new Guid("010cb561-0372-4c6f-b533-8373c103de30"),
                    IdRol = 0
                });
                Console.WriteLine("Id: {0}\nId de rol: {1}\nNombre: {2}\nDirección: {3}\nTeléfono: {4}\nFoto: {5}\nID de estátus: {6}\nZona de paquetería: {7}\nNombre de usuario: {8}\nContraseña: {9}\n----------------------------------\n",
                    response.IdCliente,
                    response.IdRol,
                    response.Nombre,
                    response.Direccion,
                    response.Telefono,
                    Encoding.UTF8.GetString(response.Foto),
                    response.IdEstatus,
                    response.ZonaPaqueteria,
                    response.UserName,
                    Encoding.UTF8.GetString(response.Password)
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void cargarComentarioNotaTest() {
            try {
                var response = servicio.cargarComentarioNota(new NotaComentarioRequest {
                    Id = 1
                });
                Console.WriteLine("Id: {0}\nId de nota: {1}\nFecha: {2}\nComentario: {3}\nError número: {4}\nMensaje de error: {5}\n",
                    response.Id,
                    response.IdNota,
                    response.Fecha,
                    response.Comentario,
                    response.ErrorNumero,
                    response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void cargarDetalleNotaTest() {
            try {
                var response = servicio.cargarDetalleNota(new DetalleNotaRequest {
                    Id = 1
                });
                Console.WriteLine("Id: {0}\nId de nota: {1}\nId de producto: {2}\nPrecio MXN: {3}\nPrecio USD: {4}\nCantidad: {5}\nError número: {6}\nMensaje de error: {7}\n",
                    response.Id,
                    response.IdNota,
                    response.IdProducto,
                    response.PrecioMXN,
                    response.PrecioUSD,
                    response.Cantidad,
                    response.ErrorNumero,
                    response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void cargarEstatusTest() {
            try {
                var response = servicio.cargarEstatus(new EstatusRequest {
                    Id = 5,
                    IdTipoEstatus = 0
                });
                Console.WriteLine("Id: {0}\nNombre: {1}\n----------------------------",
                    response.Id,
                    response.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod()]
        //public void cargarHistorialClienteTest()
        //{
        //    throw new NotImplementedException();
        //}

        [TestMethod()]
        public void cargarNotaTest() {
            try {
                var _id = servicio.listarNotas(new NotaRequest { Folio = 0, IdEstatus = 0 }).Items.FirstOrDefault().Folio;
                var nota = servicio.cargarNota(new NotaRequest { Folio = _id });
                Console.WriteLine("Folio: {0}\nFecha: {1}\nFecha de envio: {2}\nGuía: {3}\nId de cliente: {4}\nId de estátus:{5}\nId de paquetería: {6}\nId de tipo: {7}\nMonto MXN: {8}\nMonto USD: {9}\nSaldo MXN:{10}\nSaldo USD: {11}\n",
                        nota.Folio, nota.Fecha, nota.FechaEnvio,
                        nota.Guia, nota.IdCliente, nota.IdEstatus,
                        nota.IdPaqueteria, nota.IdTipo, nota.MontoMXN,
                        nota.MontoUSD, nota.SaldoMXN, nota.SaldoUSD);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void cargarProductoTest() {
            try {
                var item = servicio.listarProductos(new ProductoRequest { Id = 0, IdCategoria = 0, IdEstatus = 0 }).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.cargarProducto(new ProductoRequest {
                    Id = item.Id
                });
                Console.WriteLine("Id: {0}\nSKU: {1}\nId de categoría: {2}\nNombre: {3}\nDescripción: {4}\nAplica existencias: {5}\nExistencias: {6}\nFoto: {7}\nPrecio MXN: {8}\nPrecio USD: {9}\n----------------------------",
                    response.Id,
                    response.SKU,
                    response.IdCategoria,
                    response.Nombre,
                    response.Descripcion,
                    response.AplicaExistencias,
                    response.Existencias,
                    response.Foto,
                    response.PrecioMXN,
                    response.PrecioUSD
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void cargarTicketNotaTest() {
            try {
                var item = servicio.listarTicketNota(new NotaTicketRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.cargarTicketNota(new NotaTicketRequest {
                    Id = item.Id
                });
                Console.WriteLine("Id: {0}\nId de nota: {1}\nTicket: {2}\nError número: {3}\nMensaje de error: {4}\n",
                    response.Id,
                    response.IdNota,
                    Encoding.UTF8.GetString(response.Ticket),
                    response.ErrorNumero,
                    response.ErrorMensaje
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void cargarTipoEstatusTest() {
            try {
                var response = servicio.cargarTipoEstatus(new TipoEstatusRequest {
                    Id = 2
                });
                Console.WriteLine("Id: {0}\nNombre: {1}\n----------------------------",
                    response.Id,
                    response.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod()]
        //public void enviarRecordatoriosTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void generarGuiasTest()
        //{
        //    throw new NotImplementedException();
        //}

        [TestMethod()]
        public void guardarNuevoCatalogoTest() {
            var response = servicio.guardarCatalogo(new CatalogoRequest {
                Id = 0,
                IdTipoCatalogo = 3,
                Nombre = "Elemento de catálogo " + DateTime.Today.ToString("yyyyMMddhhmm")
            });
            Console.WriteLine("Id: {0}\nId de Tipo de catálogo: {1}\nNombre: {2}\nError número: {3}\nMensaje: {4}\n",
                response.Id,
                response.IdTipoCatalogo,
                response.Nombre,
                response.ErrorNumero,
                response.ErrorMensaje);
        }

        [TestMethod()]
        public void guardarNuevoClienteTest() {
            try {
                var responseNuevo = servicio.guardarCliente(new ClienteRequest {
                    IdCliente = new Guid(),
                    Direccion = "Dirección nueva " + DateTime.Today.ToString("yyyyMMddhhmm"),
                    Foto = Encoding.UTF8.GetBytes("FOTO"),
                    IdEstatus = 1,
                    IdRol = 2,
                    Nombre = "Usuario nuevo de prueba " + DateTime.Today.ToString("yyyyMMddhhmm"),
                    Password = Encoding.UTF8.GetBytes("password"),
                    Telefono = "1234567890",
                    UserName = "usuario01",
                    ZonaPaqueteria = 8
                });
                Console.WriteLine("Id: {0}\nId de rol: {1}\nNombre: {2}\nDirección: {3}\nTeléfono: {4}\nFoto: {5}\nID de estátus: {6}\nZona de paquetería: {7}\nNombre de usuario: {8}\nContraseña: {9}\n----------------------------------\n",
                    responseNuevo.IdCliente,
                    responseNuevo.IdRol,
                    responseNuevo.Nombre,
                    responseNuevo.Direccion,
                    responseNuevo.Telefono,
                    Encoding.UTF8.GetString(responseNuevo.Foto),
                    responseNuevo.IdEstatus,
                    responseNuevo.ZonaPaqueteria,
                    responseNuevo.UserName,
                    Encoding.UTF8.GetString(responseNuevo.Password)
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarNuevoComentarioNotaTest() {
            try {
                var nota = servicio.listarNotas(new NotaRequest()).Items.FirstOrDefault();
                var responseNuevo = servicio.guardarComentarioNota(new NotaComentarioRequest {
                    Id = 0,
                    IdNota = nota.Folio,
                    Comentario = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                    Fecha = DateTime.Today
                });
                Console.WriteLine("Id: {0}\nId de nota: {1}\nFecha: {2}\nComentario: {3}\nError número: {4}\nMensaje de error: {5}\n",
                    responseNuevo.Id,
                    responseNuevo.IdNota,
                    responseNuevo.Fecha,
                    responseNuevo.Comentario,
                    responseNuevo.ErrorNumero,
                    responseNuevo.ErrorMensaje
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarNuevoDetalleNotaTest() {
            try {
                var nota = servicio.listarNotas(new NotaRequest()).Items.FirstOrDefault();
                var producto = servicio.listarProductos(new ProductoRequest()).Items.FirstOrDefault();
                var responseNuevo = servicio.guardarDetalleNota(new DetalleNotaRequest {
                    Id = 0,
                    IdNota = nota.Folio,
                    Cantidad = 10,
                    IdProducto = producto.Id,
                    PrecioMXN = producto.PrecioMXN,
                    PrecioUSD = producto.PrecioUSD
                });
                Console.WriteLine("Id: {0}\nId de nota: {1}\nId de producto: {2}\nCantidad: {3}\nPrecio MXN: {4}\nPrecio USD: {5}\nError número: {6}\nMensaje de error: {7}\n",
                    responseNuevo.Id,
                    responseNuevo.IdNota,
                    responseNuevo.IdProducto,
                    responseNuevo.Cantidad,
                    responseNuevo.PrecioMXN,
                    responseNuevo.PrecioUSD,
                    responseNuevo.ErrorNumero,
                    responseNuevo.ErrorMensaje
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarNuevoEstatusTest() {
            try {
                var response = servicio.guardarEstatus(new EstatusRequest {
                    Id = 0,
                    IdTipoEstatus = 2,
                    Nombre = "Tipo de estátus de prueba " + DateTime.Today.ToString("yyyyMMddhhmm")
                });
                Console.WriteLine("Id: {0}\nId de tipo de estátus: {1}\nNombre: {2}",
                    response.Id, response.IdTipoEstatus, response.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarNuevaNotaTest() {
            try {
                var response = servicio.guardarNota(new NotaRequest {
                    Fecha = DateTime.Today,
                    FechaEnvio = null,
                    Folio = 0,
                    Guia = string.Empty,
                    IdCliente = new Guid("010cb561-0372-4c6f-b533-8373c103de30"),
                    IdEstatus = 7,
                    IdPaqueteria = 6,
                    IdTipo = 1,
                    MontoMXN = 150m,
                    MontoUSD = 8m,
                    SaldoMXN = 150m,
                    SaldoUSD = 8m
                });
                Console.WriteLine("Folio: {0}\nFecha: {1}\nFecha de envio: {2}\nGuía: {3}\nId de cliente: {4}\nId de estátus:{5}\nId de paquetería: {6}\nId de tipo: {7}\nMonto MXN: {8}\nMonto USD: {9}\nSaldo MXN:{10}\nSaldo USD: {11}\n",
                    response.Folio, response.Fecha, response.FechaEnvio,
                    response.Guia, response.IdCliente, response.IdEstatus,
                    response.IdPaqueteria, response.IdTipo, response.MontoMXN,
                    response.MontoUSD, response.SaldoMXN, response.SaldoUSD);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarNuevoProductoTest() {
            try {
                var response = servicio.guardarProducto(new ProductoRequest {
                    Id = 0,
                    Nombre = "Producto " + DateTime.Today.ToString("yyyyMMddhhmm"),
                    AplicaExistencias = false,
                    Descripcion = "Descripción de prueba " + DateTime.Today.ToString("yyyyMMddhhmm"),
                    Existencias = 0,
                    Foto = Encoding.UTF8.GetBytes("0"),
                    IdCategoria = 10,
                    IdEstatus = 5,
                    PrecioMXN = 150m,
                    PrecioUSD = 7.5m,
                    SKU = DateTime.Today.ToString("yyyyMMddhhmm")
                });
                Console.WriteLine("Id: {0}\nSKU: {1}\nId de categoría: {2}\nNombre: {3}\nDescripción: {4}\nAplica existencias: {5}\nExistencias: {6}\nFoto: {7}\nPrecio MXN: {8}\nPrecio USD: {9}\n----------------------------",
                    response.Id,
                    response.SKU,
                    response.IdCategoria,
                    response.Nombre,
                    response.Descripcion,
                    response.AplicaExistencias,
                    response.Existencias,
                    response.Foto,
                    response.PrecioMXN,
                    response.PrecioUSD
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarCatalogoTest() {
            try {
                var item = servicio.listarCatalogo(new CatalogoRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.guardarCatalogo(new CatalogoRequest {
                    Id = item.Id,
                    IdTipoCatalogo = 3,
                    Nombre = "Elemento editado de catálogo " + DateTime.Today.ToString("yyyyMMddhhmm")
                });
                Console.WriteLine("Id: {0}\nId de Tipo de catálogo: {1}\nNombre: {2}\nError número: {3}\nMensaje: {4}\n",
                    response.Id,
                    response.IdTipoCatalogo,
                    response.Nombre,
                    response.ErrorNumero,
                    response.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarClienteTest() {
            try {
                var cliente = servicio.listarClientes(new ClienteRequest()).Items.OrderByDescending(c => c.IdCliente).FirstOrDefault();
                var response = servicio.guardarCliente(new ClienteRequest {
                    Direccion = "Nueva dirección " + DateTime.Today.ToString("yyyyMMddhhmm"),
                    Foto = cliente.Foto,
                    IdCliente = cliente.IdCliente,
                    IdEstatus = cliente.IdEstatus,
                    IdRol = cliente.IdRol,
                    Nombre = cliente.Nombre,
                    Password = cliente.Password,
                    Telefono = cliente.Telefono,
                    UserName = cliente.UserName,
                    ZonaPaqueteria = cliente.ZonaPaqueteria
                });
                Console.WriteLine("Id: {0}\nId de rol: {1}\nNombre: {2}\nDirección: {3}\nTeléfono: {4}\nFoto: {5}\nID de estátus: {6}\nZona de paquetería: {7}\nNombre de usuario: {8}\nContraseña: {9}\n----------------------------------\n",
                    response.IdCliente,
                    response.IdRol,
                    response.Nombre,
                    response.Direccion,
                    response.Telefono,
                    Encoding.UTF8.GetString(response.Foto),
                    response.IdEstatus,
                    response.ZonaPaqueteria,
                    response.UserName,
                    Encoding.UTF8.GetString(response.Password)
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarComentarioNotaTest() {
            try {
                var comentario = servicio.listarComentarioNota(new NotaComentarioRequest()).Items.FirstOrDefault();
                var response = servicio.guardarComentarioNota(new NotaComentarioRequest {
                    Id = 0,
                    IdNota = comentario.IdNota,
                    Comentario = string.Format("Editado: {0}",comentario.Comentario).Substring(0,200),
                    Fecha = DateTime.Today
                });
                Console.WriteLine("Id: {0}\nId de nota: {1}\nComentario: {2}\nfecha: {3}\nError número: {4}\nMensaje de error: {5}\n",
                    response.Id,
                    response.IdNota,
                    response.Comentario,
                    response.Fecha,
                    response.ErrorNumero,
                    response.ErrorMensaje
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarDetalleNotaTest() {
            try {
                var detalle = servicio.listarDetalleNota(new DetalleNotaRequest()).Items.FirstOrDefault();
                var response = servicio.guardarDetalleNota(new DetalleNotaRequest {
                    Id = detalle.Id,
                    IdNota = detalle.IdNota,
                    Cantidad = 19,
                    IdProducto = detalle.IdProducto,
                    PrecioMXN = detalle.PrecioMXN * 1.16m,
                    PrecioUSD = detalle.PrecioUSD * 1.16m
                });
                Console.WriteLine("Id: {0}\nId de nota: {1}\nId de producto: {2}\nCantidad: {3}\nPrecio MXN: {4}\nPrecio USD: {5}\nError número: {6}\nMensaje de error: {7}\n",
                    response.Id,
                    response.IdNota,
                    response.IdProducto,
                    response.Cantidad,
                    response.PrecioMXN,
                    response.PrecioUSD,
                    response.ErrorNumero,
                    response.ErrorMensaje
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarEstatusTest() {
            try {
                var item = servicio.listarEstatus(new EstatusRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.guardarEstatus(new EstatusRequest {
                    Id = item.Id,
                    IdTipoEstatus = 2,
                    Nombre = "Tipo editado de estátus de prueba " + DateTime.Today.ToString("yyyyMMddhhmm")
                });
                Console.WriteLine("Id: {0}\nId de tipo de estátus: {1}\nNombre: {2}",
                    response.Id, response.IdTipoEstatus, response.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarNotaTest() {
            try {
                var item = servicio.listarNotas(new NotaRequest()).Items.OrderByDescending(i => i.Folio).FirstOrDefault();
                var response = servicio.guardarNota(new NotaRequest {
                    Fecha = DateTime.Today,
                    FechaEnvio = DateTime.Today,
                    Folio = item.Folio,
                    Guia = string.Empty,
                    IdCliente = new Guid("010cb561-0372-4c6f-b533-8373c103de30"),
                    IdEstatus = 7,
                    IdPaqueteria = 6,
                    IdTipo = 1,
                    MontoMXN = 1000m,
                    MontoUSD = 8m,
                    SaldoMXN = 1000m,
                    SaldoUSD = 8m
                });
                Console.WriteLine("Folio: {0}\nFecha: {1}\nFecha de envio: {2}\nGuía: {3}\nId de cliente: {4}\nId de estátus:{5}\nId de paquetería: {6}\nId de tipo: {7}\nMonto MXN: {8}\nMonto USD: {9}\nSaldo MXN:{10}\nSaldo USD: {11}\n",
                    response.Folio, response.Fecha, response.FechaEnvio,
                    response.Guia, response.IdCliente, response.IdEstatus,
                    response.IdPaqueteria, response.IdTipo, response.MontoMXN,
                    response.MontoUSD, response.SaldoMXN, response.SaldoUSD);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarProductoTest() {
            try {
                var item = servicio.listarProductos(new ProductoRequest()).Items.OrderByDescending(i => i.Id).FirstOrDefault();
                var response = servicio.guardarProducto(new ProductoRequest {
                    Id = item.Id,
                    Nombre = "Producto editado" + DateTime.Today.ToString("yyyyMMddhhmm"),
                    AplicaExistencias = false,
                    Descripcion = "Descripción de prueba " + DateTime.Today.ToString("yyyyMMddhhmm"),
                    Existencias = 0,
                    Foto = Encoding.UTF8.GetBytes("0"),
                    IdCategoria = 10,
                    IdEstatus = 5,
                    PrecioMXN = 150m,
                    PrecioUSD = 7.5m,
                    SKU = DateTime.Today.ToString("yyyyMMddhhmm")
                });
                Console.WriteLine("Id: {0}\nSKU: {1}\nId de categoría: {2}\nNombre: {3}\nDescripción: {4}\nAplica existencias: {5}\nExistencias: {6}\nFoto: {7}\nPrecio MXN: {8}\nPrecio USD: {9}\n----------------------------",
                    response.Id,
                    response.SKU,
                    response.IdCategoria,
                    response.Nombre,
                    response.Descripcion,
                    response.AplicaExistencias,
                    response.Existencias,
                    response.Foto,
                    response.PrecioMXN,
                    response.PrecioUSD
                    );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarCatalogoTest() {
            try {
                var response = servicio.listarCatalogo(new CatalogoRequest {
                    Id = 0,
                    IdTipoCatalogo = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id: {0}\nId de Tipo de Catálogo: {1}\nNombre: {2}\n----------------------------", item.Id, item.IdTipoCatalogo, item.Nombre);

                Console.WriteLine("\n*****************************\n");

                response = servicio.listarCatalogo(new CatalogoRequest {
                    Id = 0,
                    IdTipoCatalogo = 3
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id: {0}\nId de Tipo de Catálogo: {1}\nNombre: {2}\n----------------------------", item.Id, item.IdTipoCatalogo, item.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarClientesTest() {
            try {
                var response = servicio.listarClientes(new ClienteRequest {
                    IdCliente = new Guid(),
                    IdRol = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id: {0}\nId de rol: {1}\nNombre: {2}\nDirección: {3}\nTeléfono: {4}\nFoto: {5}\nID de estátus: {6}\nZona de paquetería: {7}\nNombre de usuario: {8}\nContraseña: {9}\n----------------------------------\n",
                        item.IdCliente,
                        item.IdRol,
                        item.Nombre,
                        item.Direccion,
                        item.Telefono,
                        Encoding.UTF8.GetString(item.Foto),
                        item.IdEstatus,
                        item.ZonaPaqueteria,
                        item.UserName,
                        Encoding.UTF8.GetString(item.Password)
                        );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarEstatusTest() {
            try {
                var response = servicio.listarEstatus(new EstatusRequest {
                    Id = 0,
                    IdTipoEstatus = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id: {0}\nId de Tipo de Estátus: {1}\nNombre: {2}\n----------------------------", item.Id, item.IdTipoEstatus, item.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarNotasTest() {
            try {
                var response = servicio.listarNotas(new NotaRequest {
                    Folio = 0,
                    Fecha = null,
                    IdEstatus = 0
                });
                Console.WriteLine("--------------- Lista de notas ---------------");
                foreach (var item in response.Items) {
                    Console.WriteLine("Folio: {0}\nFecha: {1}\nFecha de envio: {2}\nGuía: {3}\nId de cliente: {4}\nId de estátus:{5}\nId de paquetería: {6}\nId de tipo: {7}\nMonto MXN: {8}\nMonto USD: {9}\nSaldo MXN:{10}\nSaldo USD: {11}\n",
                        item.Folio, item.Fecha, item.FechaEnvio,
                        item.Guia, item.IdCliente, item.IdEstatus,
                        item.IdPaqueteria, item.IdTipo, item.MontoMXN,
                        item.MontoUSD, item.SaldoMXN, item.SaldoUSD);
                }
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarProductosTest() {
            try {
                var response = servicio.listarProductos(new ProductoRequest {
                    Id = 0,
                    IdCategoria = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id: {0}\nSKU: {1}\nId de categoría: {2}\nNombre: {3}\nDescripción: {4}\nAplica existencias: {5}\nExistencias: {6}\nFoto: {7}\nPrecio MXN: {8}\nPrecio USD: {9}\n----------------------------",
                        item.Id,
                        item.SKU,
                        item.IdCategoria,
                        item.Nombre,
                        item.Descripcion,
                        item.AplicaExistencias,
                        item.Existencias,
                        item.Foto,
                        item.PrecioMXN,
                        item.PrecioUSD
                        );
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarTipoCatalogoTest() {
            try {
                var response = servicio.listarTipoCatalogo(new TipoCatalogoRequest {
                    Id = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id de Tipo de Estátus: {0}\nNombre: {1}\n----------------------------", item.Id, item.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarComentarioNotaTest() {
            try {
                var response = servicio.listarComentarioNota(new NotaComentarioRequest {
                    Id = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id: {0}\nId de nota: {1}\nComentario: {2}\nFecha: {3}\nError número: {4}\nMensaje de error: {5}\n----------------------------\n",
                        item.Id,
                        item.IdNota,
                        item.Comentario,
                        item.Fecha,
                        item.ErrorNumero,
                        item.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarDetalleNotaTest() {
            try {
                var response = servicio.listarDetalleNota(new DetalleNotaRequest {
                    Id = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id: {0}\nId de nota: {1}\nId de producto: {2}\nCantidad: {3}\nPrecio MXN: {4}\nPrecio USD:{5}\nError número: {6}\nMensaje de error: {7}\n----------------------------\n",
                        item.Id,
                        item.IdNota,
                        item.IdProducto,
                        item.Cantidad,
                        item.PrecioMXN,
                        item.PrecioUSD,
                        item.ErrorNumero,
                        item.ErrorMensaje);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarTipoEstatusTest() {
            try {
                var response = servicio.listarTipoEstatus(new TipoEstatusRequest {
                    Id = 0
                });
                foreach (var item in response.Items)
                    Console.WriteLine("Id de Tipo de Estátus: {0}\nNombre: {1}\n----------------------------", item.Id, item.Nombre);
            } catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod()]
        //public void subirFotosTest()
        //{
        //    throw new NotImplementedException();
        //}
    }
}