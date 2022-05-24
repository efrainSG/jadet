using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.DataAccess;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Configuration;
using System.Linq;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Cliente : ICliente
    {
        private readonly DataAccess da;
        public Cliente()
        {
            da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
        }
    public Cliente(string connStr)
    {
        da = new DataAccess
        {
            CadenaConexion = string.IsNullOrEmpty(connStr) ? ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString : connStr
        };
    }
    public CarritoResponse nuevoCarrito(CarritoRequest request)
    {
        Nota _nota = da.guardarNota(Nota.ToModel(request));
        return NotaResponse.ToResponse(_nota) as CarritoResponse;
    }

    public ItemCarritoResponse agregarACarrito(ItemCarritoRequest request)
    {
        var _respuesta = da.guardarDetalle(DetalleNota.ToModel(request));
        return DetalleNotaResponse.ToResponse(_respuesta) as ItemCarritoResponse;
    }

    public BaseResponse quitarDelCarrito(ItemCarritoRequest request)
    {
        var _respuesta = da.borrarDetalle(request.Id);
        return new BaseResponse
        {
            ErrorMensaje = _respuesta.ErrorMensaje,
            ErrorNumero = _respuesta.ErrorNumero
        };
    }

    public CarritoResponse vaciarCarrito(CarritoRequest request)
    {
        var _respuesta = da.vaciarCarrito(request.Folio);
        return new CarritoResponse
        {
            ErrorMensaje = _respuesta.ErrorMensaje,
            ErrorNumero = _respuesta.ErrorNumero
        };
    }

    public ArchivoResponse subirFoto(ArchivoRequest request)
    {
        return new ArchivoResponse
        {
            ErrorMensaje = "No implementado",
            ErrorNumero = 1
        };
    }

    public BaseResponse generarPedido(CarritoRequest request)
    {
        var _nota = da.listarNota(Nota.ToModel(request)).FirstOrDefault();
        _nota.IdEstatus = 7;
        da.guardarNota(Nota.ToModel(_nota));
        return new BaseResponse
        {
            ErrorMensaje = string.Empty,
            ErrorNumero = 0
        };
    }

    public ColeccionCarritoResponse listarPedidos(CarritoRequest request)
    {
        var _response = da.listarNota(Nota.ToModel(request));
        ColeccionCarritoResponse respuesta = new ColeccionCarritoResponse
        {
            ErrorMensaje = string.Empty,
            ErrorNumero = 0
        };
        respuesta.Items.AddRange(_response.Select(i => NotaResponse.ToResponse(i) as CarritoResponse));
        return respuesta;
    }

    public CarritoResponse verPedido(CarritoRequest request)
    {
        var _response = da.listarDetalle(DetalleNota.ToModel(request));
        var _pedido = da.listarNota(new Nota { Folio = request.Folio }).FirstOrDefault();
        CarritoResponse respuesta = new CarritoResponse
        {
            ErrorMensaje = "No implementado",
            ErrorNumero = 1,
            Fecha = _pedido.Fecha,
            FechaEnvio = _pedido.FechaEnvio,
            Folio = _pedido.Folio,
            Guia = _pedido.Guia,
            IdCliente = _pedido.IdCliente,
            IdEstatus = _pedido.IdEstatus,
            IdPaqueteria = _pedido.IdPaqueteria,
            IdTipo = _pedido.IdTipo,
            MontoMXN = _pedido.MontoMXN,
            MontoUSD = _pedido.MontoUSD,
            SaldoMXN = _pedido.SaldoMXN,
            SaldoUSD = _pedido.SaldoUSD
        };
        respuesta.Items.AddRange(_response.Select(i => new ItemCarritoResponse
        {
            Id = i.Id,
            Cantidad = i.Cantidad,
            IdNota = i.IdNota,
            IdProducto = i.IdProducto,
            PrecioMXN = i.PrecioMXN,
            PrecioUSD = i.PrecioUSD
        }));
        return respuesta;
    }

    public NotaTicketResponse guardarTicket(NotaTicketRequest request)
    {
        var _response = da.guardarTicket(TicketNota.ToModel(request));
        return NotaTicketResponse.ToResponse(_response);
    }

    public NotaComentarioResponse guardarComentario(NotaComentarioRequest request)
    {
        var _response = da.guardarComentario(ComentarioNota.ToModel(request));
        return NotaComentarioResponse.ToResponse(_response);
    }

    public ColeccionNotaTicketResponse listarTickets(NotaTicketRequest request)
    {
        var _response = da.listarTicket(TicketNota.ToModel(request));
        ColeccionNotaTicketResponse respuesta = new ColeccionNotaTicketResponse();
        respuesta.Items.AddRange(_response.Select(r => NotaTicketResponse.ToResponse(r)));
        return respuesta;
    }

    public ColeccionNotaComentarioResponse listarComentarios(NotaComentarioRequest request)
    {
        var _response = da.listarComentario(ComentarioNota.ToModel(request));
        ColeccionNotaComentarioResponse respuesta = new ColeccionNotaComentarioResponse();
        respuesta.Items.AddRange(_response.Select(r => NotaComentarioResponse.ToResponse(_response)));
        return respuesta;
    }
}
}
