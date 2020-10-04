using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.DataAccess;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Configuration;
using System.Linq;

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
                Id = request.Id,
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
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _nota = da.listarNota(new Nota {
                Folio = request.Folio
            }).FirstOrDefault();
            var _respuesta = da.guardarNota(new Nota {
                Fecha = _nota.Fecha,
                Folio = _nota.Folio,
                IdCliente = _nota.IdCliente,
                IdEstatus = 7,
                IdPaqueteria = request.IdPaqueteria,
                IdTipo = _nota.IdTipo,
                MontoMXN = _nota.MontoMXN,
                MontoUSD = _nota.MontoUSD,
                SaldoMXN = _nota.SaldoMXN,
                SaldoUSD = _nota.SaldoUSD
            });
            return new BaseResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public ColeccionCarritoResponse listarPedidos(CarritoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _response = da.listarNota(new Nota {
                IdCliente = request.IdCliente,
                IdEstatus = request.IdEstatus,
                IdTipo = request.IdTipo
            });
            ColeccionCarritoResponse respuesta = new ColeccionCarritoResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
            respuesta.Items.AddRange(_response.Select(i => new CarritoResponse {
                Fecha = i.Fecha,
                FechaEnvio = i.FechaEnvio,
                Folio = i.Folio,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Guia = i.Guia,
                IdCliente = i.IdCliente,
                IdEstatus = i.IdEstatus,
                IdPaqueteria = i.IdPaqueteria,
                IdTipo = i.IdTipo,
                Items = null,
                MontoMXN = i.MontoMXN,
                MontoUSD = i.MontoUSD,
                SaldoMXN = i.SaldoMXN,
                SaldoUSD = i.SaldoUSD
            }));
            return respuesta;
        }

        public CarritoResponse verPedido(CarritoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _response = da.listarDetalle(0, request.Folio, 0);

            CarritoResponse respuesta = new CarritoResponse {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
            respuesta.Items.AddRange(_response.Select(i => new ItemCarritoResponse {
                Id = i.Id,
                Cantidad = i.Cantidad,
                IdNota = i.IdNota,
                IdProducto = i.IdProducto,
                PrecioMXN = i.PrecioMXN,
                PrecioUSD = i.PrecioUSD
            }));
            return respuesta;
        }

        public NotaTicketResponse guardarTicket(NotaTicketRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _response = da.guardarTicket(new TicketNota {
                Fecha = request.Fecha,
                Id = request.Id,
                IdNota = request.IdNota,
                MontoMXN = request.MontoMXN,
                MontoUSD = request.MontoUSD,
                Ticket = request.Ticket
            });

            NotaTicketResponse respuesta = new NotaTicketResponse {
                ErrorMensaje = "",
                ErrorNumero = 0,
                Fecha = _response.Fecha,
                Ticket = _response.Ticket,
                Id = _response.Id,
                IdNota = _response.IdNota,
                MontoUSD = _response.MontoUSD,
                MontoMXN = _response.MontoMXN
            };
            return respuesta;
        }

        public NotaComentarioResponse guardarComentario(NotaComentarioRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _response = da.guardarComentario(new ComentarioNota {
                Fecha = request.Fecha,
                Id = request.Id,
                IdNota = request.IdNota,
                Comentario = request.Comentario,
                IdComentarioAnterior = request.IdComentarioAnterior
            });

            NotaComentarioResponse respuesta = new NotaComentarioResponse {
                ErrorMensaje = "",
                ErrorNumero = 0,
                Fecha = _response.Fecha,
                Id = _response.Id,
                IdNota = _response.IdNota,
                Comentario = _response.Comentario,
                IdComentarioAnterior = _response.IdComentarioAnterior
            };
            return respuesta;
        }

        public coleccionNotaTicketResponse listarTickets(NotaTicketRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _response = da.listarTicket(new TicketNota {
                IdNota = request.IdNota
            });

            coleccionNotaTicketResponse respuesta = new coleccionNotaTicketResponse();
            respuesta.Items.AddRange(_response.Select(r => new NotaTicketResponse {
                Fecha = r.Fecha,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Id = r.Id,
                IdNota = r.IdNota,
                MontoMXN = r.MontoMXN,
                MontoUSD = r.MontoUSD,
                Ticket = r.Ticket
            }));
            return respuesta;
        }

        public coleccionNotaComentarioResponse listarComentarios(NotaComentarioRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var _response = da.listarComentario(new ComentarioNota {
                IdNota = request.IdNota
            });

            coleccionNotaComentarioResponse respuesta = new coleccionNotaComentarioResponse();
            respuesta.Items.AddRange(_response.Select(r => new NotaComentarioResponse {
                Fecha = r.Fecha,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Id = r.Id,
                IdNota = r.IdNota,
                Comentario = r.Comentario,
                IdComentarioAnterior = r.IdComentarioAnterior
            }));
            return respuesta;
        }
    }
}
