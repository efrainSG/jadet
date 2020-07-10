using Microsoft.VisualStudio.TestTools.UnitTesting;
using SernaSisitemas.Jadet.WCF.Implementaciones;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSisitemas.Jadet.WCF.Implementaciones.Tests
{
    [TestClass()]
    public class AdministradorTests
    {
        Administrador servicio;

        [TestInitialize]
        public void init()
        {
            servicio = new Administrador();
        }

        [TestMethod()]
        public void bajaClienteTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void bajaProductoTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void borrarNotaTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void cambiarEstatusPaginaTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void cargarClienteTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void cargarHistorialClienteTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void cargarProductoTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void enviarRecordatoriosTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void generarGuiasTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void guardarClienteTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void guardarProductoTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarNotasTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarClientesTest()
        {
            var response = servicio.listarClientes(new ClienteRequest());
            foreach (var item in response.Items)
            {
                Console.WriteLine("-------------------------------\nError número: {0}\nMensaje de error: {1}\nId de cliente: {2}\nNombre: {3}\nContraseña: {4}\nRuta de la foto: {5}\n-------------------------------",
                    item.ErrorNumero,
                    item.ErrorMensaje,
                    item.IdCliente,
                    item.Nombre,
                    item.Password,
                    item.Foto);
            }
        }

        [TestMethod()]
        public void listarProductosTest()
        {
            var response = servicio.listarProductos(new BaseRequest());
            foreach (var item in response.Items)
            {
                Console.WriteLine("-------------------------------\nError número: {0}\nMensaje de error: {1}\nId de categoría: {2}\nCategoría: {3}\nProducto: {4}\nDescripción: {5}\nExistencias: {6}\nPrecio M. N.: {7}\nPrecio USD: {8}\nImágen: {9}\n-------------------------------",
                    item.ErrorNumero,
                    item.ErrorMensaje,
                    item.Categoria.Id,
                    item.Categoria.Nombre,
                    item.Nombre,
                    item.Descripcion,
                    item.Existencias,
                    item.PrecioMXN,
                    item.PrecioUSD,
                    item.RutaImagen);
            }
        }

        [TestMethod()]
        public void subirFotosTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void verNotaTest()
        {
            throw new NotImplementedException();
        }
    }
}