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
    public class ClienteTests {
        [TestMethod()]
        public void agregarACarritoTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void generarPedidoTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void guardarPedidoTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void listarPedidosTest() {
            Cliente cliente = new Cliente();
            var _respuesta = cliente.listarPedidos(new SernaSistemas.Jadet.WCF.Modelos.CarritoRequest {
                IdCliente = new Guid("71f43393-c695-4b25-8575-6bf6faa85c95"),
                //IdEstatus = 6,
                //IdTipo = 0
            });
            foreach (var item in _respuesta.Items) {
                Console.WriteLine("{0}\n{1}\n{2}\n{3}\n", item.Folio, item.IdCliente, item.IdEstatus, item.IdTipo);
            }
        }

        [TestMethod()]
        public void quitarDelCarritoTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void subirFotoTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void vaciarCarritoTest() {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void verPedidoTest() {
            Cliente cliente = new Cliente();
            var _respuesta = cliente.verPedido(new CarritoRequest { Folio = 7003});
            foreach (var item in _respuesta.Items) {
                Console.WriteLine("Id: {0}\nId de nota: {1}\nId de producto: {2}\nPrecio MXN: {3}\nPrecio USD: {4}", item.Id, item.IdNota, item.IdProducto, item.Cantidad, item.PrecioMXN, item.PrecioUSD);
            }
        }
    }
}