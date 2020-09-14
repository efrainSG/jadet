using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.DataAccess;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;

namespace SernaSisitemas.Jadet.WCF.Implementaciones {
    public class Cliente : ICliente {

        public CarritoResponse nuevoCarrito(CarritoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _nota = da.guardarNota(new Nota {
                Fecha = DateTime.Today,
                FechaEnvio = null,
                Folio = 0,
                Guia = string.Empty,
                IdCliente = request.IdCliente,
                IdEstatus = request.IdEstatus,
                IdPaqueteria = request.IdPaqueteria,
                IdTipo = request.IdTipo,
                MontoMXN = request.MontoMXN,
                MontoUSD = request.MontoUSD,
                SaldoMXN = request.SaldoMXN,
                SaldoUSD = request.SaldoUSD
            });
            return new CarritoResponse {
                Fecha = _nota.Fecha,
                FechaEnvio = _nota.FechaEnvio,
                SaldoUSD = _nota.SaldoUSD,
                SaldoMXN = _nota.SaldoMXN,
                MontoUSD = _nota.MontoUSD,
                MontoMXN = _nota.MontoMXN,
                Folio = _nota.Folio,
                Guia = _nota.Guia,
                IdCliente = _nota.IdCliente,
                IdEstatus = _nota.IdEstatus,
                IdPaqueteria = _nota.IdPaqueteria,
                IdTipo = _nota.IdTipo
            };
        }

        public ItemCarritoResponse agregarACarrito(ItemCarritoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _respuesta = da.guardarDetalle(new DetalleNota {
                Cantidad = request.Cantidad,
                IdNota = request.IdNota,
                IdProducto = request.IdProducto,
                PrecioMXN = request.PrecioMXN,
                PrecioUSD = request.PrecioUSD
            });
            return new ItemCarritoResponse {
                Cantidad = _respuesta.Cantidad,
                Id = _respuesta.Id,
                PrecioUSD = _respuesta.PrecioUSD,
                PrecioMXN = _respuesta.PrecioMXN,
                IdProducto = _respuesta.IdProducto,
                IdNota = _respuesta.IdNota
            };
        }

        public BaseResponse quitarDelCarrito(ItemCarritoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _respuesta = da.borrarDetalle(request.Id);
            return new BaseResponse {
                ErrorMensaje = _respuesta.ErrorMensaje,
                ErrorNumero = _respuesta.ErrorNumero
            };
        }

        public CarritoResponse vaciarCarrito(CarritoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _respuesta = da.vaciarCarrito(request.Folio);
            return new CarritoResponse {
                ErrorMensaje = _respuesta.ErrorMensaje,
                ErrorNumero = _respuesta.ErrorNumero
            };
        }

        public ArchivoResponse subirFoto(ArchivoRequest request) {
            return new ArchivoResponse {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public BaseResponse generarPedido(CarritoRequest request) {
            return new BaseResponse {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public BaseResponse guardarPedido(CarritoRequest request) {
            return new BaseResponse {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public ColeccionCarritoResponse listarPedidos(BaseRequest request) {
            return new ColeccionCarritoResponse {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1,
                Items = new List<CarritoResponse>()
            };
        }

        public CarritoResponse verPedido(CarritoRequest request) {
            return new CarritoResponse {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }
    }
}
