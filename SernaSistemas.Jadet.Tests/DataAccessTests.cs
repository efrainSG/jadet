using Microsoft.VisualStudio.TestTools.UnitTesting;
using SernaSistemas.Jadet.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
        }

        [TestMethod()]
        public void borrarCatalogoTest()
        {

            throw new NotImplementedException();
        }

        [TestMethod()]
        public void borrarEstatusTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void borrarUsuarioTest()
        {
            throw new NotImplementedException();
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

        //[TestMethod()]
        //public void borrarProductoTest()
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
                    Nombre = "prueba01"
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
                    Nombre = "prueba01"
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
                    Id = Guid.NewGuid(),
                    Nombre = "prueba01",
                    Direccion = "Conocida",
                    IdEstatus = 1
                });
                //Console.WriteLine("Id: {0}\nNombre: {1}\nTipo de estatus: {2}\n",
                //    resultado.Id, resultado.Nombre, resultado.IdTipoEstatus);
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
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarCatalogoTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarEstatusTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarUsuarioTest()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarTipoCatalogoTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarTipoEstatusTest()
        {
            try
            {
                var resultado = da.listarTipoEstatus(0);
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
            throw new NotImplementedException();
        }
    }
}