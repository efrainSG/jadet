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
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void bajaClienteTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void bajaEstatusTest() {
            throw new NotImplementedException();
        }

        //[TestMethod()]
        //public void bajaNotaTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void bajaProductoTest()
        //{
        //    throw new NotImplementedException();
        //}

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

        //[TestMethod()]
        //public void cargarNotaTest() {
        //    try {
        //        var response = servicio.cargarNota(new NotaRequest {
        //            Folio = 3,
        //            Fecha = null,
        //            IdEstatus = 0
        //        });
        //        Console.WriteLine("Id: {0}\nSKU: {1}\nId de categoría: {2}\nNombre: {3}\nDescripción: {4}\nAplica existencias: {5}\nExistencias: {6}\nFoto: {7}\nPrecio MXN: {8}\nPrecio USD: {9}\n----------------------------",
        //            response.Id,
        //            response.SKU,
        //            response.IdCategoria,
        //            response.Nombre,
        //            response.Descripcion,
        //            response.AplicaExistencias,
        //            response.Existencias,
        //            response.Foto,
        //            response.PrecioMXN,
        //            response.PrecioUSD
        //            );
        //    } catch (Exception ex) {
        //        Assert.Fail(ex.Message);
        //    }
        //}

        [TestMethod()]
        public void cargarProductoTest() {
            try {
                var response = servicio.cargarProducto(new ProductoRequest {
                    Id = 2
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
        public void guardarCatalogoTest() {
            throw new NotImplementedException();
        }

        //[TestMethod()]
        //public void guardarClienteTest()
        //{
        //    throw new NotImplementedException();
        //}

        [TestMethod()]
        public void guardarEstatusTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void guardarNotaTest() {
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

        //[TestMethod()]
        //public void guardarProductoTest()
        //{
        //    throw new NotImplementedException();
        //}

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