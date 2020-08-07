using Microsoft.VisualStudio.TestTools.UnitTesting;
using SernaSistemas.Jadet.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace SernaSistemas.Jadet.DataAccess.Tests
{
    [TestClass()]
    public class DataAccessTests
    {
        DataAccess da;
        [TestInitialize]
        public void init()
        {
            da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
        }

        [TestMethod()]
        public void borrarCatalogoTest()
        {
            try
            {
                var item = da.listarCatalogo(new Catalogo { Id = 0, IdTipoCatalogo = 0 })
                    .OrderByDescending(c => c.Id)
                    .FirstOrDefault();
                var resultado = da.borrarCatalogo(item.Id);
                Console.WriteLine("Error número: {0}\nMensaje: {1}\n",
                    resultado.ErrorNumero,
                    resultado.ErrorMensaje
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void borrarEstatusTest()
        {
            try
            {
                var item = da.listarEstatus(new Estatus { Id = 0, IdTipoEstatus = 0 })
                    .OrderByDescending(c => c.Id)
                    .FirstOrDefault();
                var resultado = da.borrarEstatus(item.Id);
                Console.WriteLine("Error número: {0}\nMensaje: {1}\n",
                    resultado.ErrorNumero,
                    resultado.ErrorMensaje
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void borrarUsuarioTest()
        {
            try
            {
                var usuarioId = da.listarUsuario(new Usuario { Id = new Guid(), IdRol = 2 })
                    .OrderByDescending(u => u.Id).FirstOrDefault().Id;

                var item = da.borrarUsuario(usuarioId);

                Console.WriteLine("Error número: {0}\nMensaje: {1}\n",
                    item.ErrorNumero,
                    item.ErrorMensaje
                    );
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void borrarProductoTest()
        {
            try
            {
                var producto = da.listarProductos(0).OrderByDescending(i => i.Id).FirstOrDefault();
                if (producto != null)
                {
                    var resultado = da.borrarProducto(producto.Id);
                    Console.WriteLine("Error número: {0}\nMensaje: {1}\n",
                        resultado.ErrorNumero,
                        resultado.ErrorMensaje
                        );
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod()]
        //public void borrarDetalleTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void borrarNotaTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void borrarComentarioTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void borrarTicketTest()
        //{
        //    throw new NotImplementedException();
        //}

        [TestMethod()]
        public void guardarCatalogoTest()
        {
            try
            {
                var resultado = da.guardarCatalogo(new Catalogo
                {
                    Id = 0,
                    IdTipoCatalogo = 1,
                    Nombre = "prueba catálogo " + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()
                });
                Console.WriteLine("Id: {0}\nNombre: {1}\nTipo de catálogo: {2}\n",
                    resultado.Id, resultado.Nombre, resultado.IdTipoCatalogo);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarEstatusTest()
        {
            try
            {
                var resultado = da.guardarEstatus(new Estatus
                {
                    Id = 0,
                    IdTipoEstatus = 1,
                    Nombre = "prueba estatus " + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()
                });
                Console.WriteLine("Id: {0}\nNombre: {1}\nTipo de estatus: {2}\n",
                    resultado.Id, resultado.Nombre, resultado.IdTipoEstatus);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void guardarUsuarioTest()
        {
            try
            {
                var resultado = da.guardarUsuario(new Usuario
                {
                    Id = new Guid("25079902-9FAA-4B66-9093-43029827F2FD"),
                    Nombre = "USUARIO ADMINISTRADOR",
                    Direccion = "Conocida",
                    IdEstatus = 1,
                    Foto = Encoding.UTF8.GetBytes("0"),
                    IdRol = 1,
                    Password = Encoding.UTF8.GetBytes("123"),
                    Telefono = "12345367890",
                    UserName = "admin",// + DateTime.Now.Ticks.ToString(),
                    ZonaPaqueteria = 6
                });
                Console.WriteLine("Id: {0}\nNombre: {1}\nDirección: {2}\nId de estátus: {3}\nId de rol: {4}\nNombre de usuario: {5}\nContraseña: {6}\nTeléfono: {7}\nZona de paquetería: {8}\n",
                    resultado.Id, resultado.Nombre, resultado.Direccion,
                    resultado.IdEstatus, resultado.IdRol, resultado.UserName,
                    Encoding.UTF8.GetString(resultado.Password), resultado.Telefono, resultado.ZonaPaqueteria);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod()]
        //public void guardarDetalleTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void guardarNotaTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void guardarComentarioTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void guardarTicketTest()
        //{
        //    throw new NotImplementedException();
        //}

        [TestMethod()]
        public void guardarProductoTest()
        {
            try
            {
                var resultado = da.guardarProducto(new Producto
                {
                    Id = 0,
                    SKU = DateTime.Now.Ticks.ToString(),
                    AplicaExistencias = true,
                    Nombre = "prueba producto " + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString(),
                    Descripcion = "prueba descripción de producto " + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString(),
                    Existencias = DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second,
                    IdCatalogo = (DateTime.Now.Second % 3) + 1,
                    PrecioMXN = DateTime.Now.Second * 20,
                    PrecioUSD = DateTime.Now.Second,
                    Foto = Encoding.UTF8.GetBytes("0"),
                    IdEstatus = 4
                });
                Console.WriteLine("Id: {0}\nSKU: {1}\nNombre: {2}\nDescripcion: {3}\nAplica existencias: {4}\nExistencias: {5}\nId de catálogo: {6}\nPrecio MXN: {7}\nPrecio USD: {8}\nId de estátus: {9}\n",
                    resultado.Id, resultado.SKU, resultado.Nombre, resultado.Descripcion,
                    resultado.AplicaExistencias, resultado.Existencias, resultado.IdCatalogo,
                    resultado.PrecioMXN, resultado.PrecioUSD, resultado.IdEstatus);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarCatalogoTest()
        {
            try
            {
                var resultado = da.listarCatalogo(new Catalogo
                {
                    Id = 0,
                    IdTipoCatalogo = 0
                });
                Console.WriteLine("--------------- Catálogo ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("Id: {0}\nNombre: {1}\nId de Tipo de catálogo:{2}\n",
                        item.Id, item.Nombre, item.IdTipoCatalogo);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarEstatusTest()
        {
            try
            {
                var resultado = da.listarEstatus(new Estatus
                {
                    Id = 0,
                    IdTipoEstatus = 0
                });
                Console.WriteLine("--------------- Estátus ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("Id: {0}\nNombre: {1}\n",
                        item.Id, item.Nombre);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarUsuarioTest()
        {
            try
            {
                var resultado = da.listarUsuario(new Usuario
                {
                    Id = new Guid(),
                    IdRol = 0
                });
                Console.WriteLine("--------------- Tipo de usuarios ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("--------------------------\nId: {0}\nNombre: {1}\nDirección: {2}\nId de estátus: {3}\nId de rol: {4}\nNombre de usuario: {5}\nContraseña: {6}\nTeléfono: {7}\nZona de paquetería: {8}\n",
                        item.Id, item.Nombre, item.Direccion, item.IdEstatus,
                        item.IdRol, item.UserName, Encoding.UTF8.GetString(item.Password), item.Telefono,
                        item.ZonaPaqueteria);

                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod()]
        //public void listarDetalleTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void listarNotaTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void listarComentarioTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void listarTicketTest()
        //{
        //    throw new NotImplementedException();
        //}

        [TestMethod()]
        public void listarProductoTest()
        {
            try
            {
                var resultado = da.listarProductos(0);
                Console.WriteLine("--------------- Productos ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("Id: {0}\nSKU: {1}\nNombre: {2}\nDescripcion: {3}\nExistencias: {4}\nAplica Existencias: {5}\nId Catalogo: {6}\nPrecio MXN: {7}\nPrecio: {8}\n Id de estátus: {9}\n",
                        item.Id, item.SKU, item.Nombre, item.Descripcion,
                        item.Existencias, item.AplicaExistencias, item.IdCatalogo,
                        item.PrecioMXN, item.PrecioUSD, item.IdEstatus);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarTipoCatalogoTest()
        {
            try
            {
                var resultado = da.listarTipoCatalogo(0);
                Console.WriteLine("--------------- Tipo de catálogos ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("Id: {0}\nNombre: {1}\n",
                        item.Id, item.Nombre);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarTipoEstatusTest()
        {
            try
            {
                var resultado = da.listarTipoEstatus(0);
                Console.WriteLine("--------------- Tipos de estátus ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("Id: {0}\nNombre: {1}\n",
                        item.Id, item.Nombre);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarRolTest()
        {
            try
            {
                var resultado = da.listarRol(0);
                Console.WriteLine("--------------- Roles ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("Id: {0}\nNombre: {1}\n",
                        item.Id, item.Nombre);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void listarProductosTest()
        {
            try
            {
                var resultado = da.listarProductos(0);
                Console.WriteLine("--------------- Roles ---------------");
                foreach (var item in resultado)
                {
                    Console.WriteLine("Id: {0}\nSKU: {1}\nNombre: {2}\nDescripcion: {3}\nAplica existencias: {4}\nExistencias: {5}\nId de catálogo: {6}\nPrecio MXN: {7}\nPrecio USD: {8}\nId de estátus: {9}\n",
                       item.Id, item.SKU, item.Nombre, item.Descripcion, item.AplicaExistencias,
                       item.Existencias, item.IdCatalogo, item.PrecioMXN, item.PrecioUSD,
                       item.IdEstatus);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void iniciarSesionTest()
        {
            try
            {
                var resultado = da.iniciarSesion(new Usuario
                {
                    UserName = "admin",
                    Password = Encoding.UTF8.GetBytes("123")
                });

                Console.WriteLine("--------------- Inicio de sesión ---------------");
                Console.WriteLine("Id: {0}\nUsuario: {1}\nNombre: {2}\nId de rol: {3}\nNúmero de error: {4}\nMensaje: {5}\n",
                   resultado.Id.ToString(), resultado.UserName, resultado.Nombre, resultado.IdRol,
                   resultado.ErrorNumero, resultado.ErrorMensaje);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}