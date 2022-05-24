using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.DataAccess;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Configuration;
using System.Linq;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Administrador : IAdministrador
    {
        private readonly DataAccess da;

        public Administrador()
        {
            da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
        }

        public Administrador(string connStr)
        {
            da = new DataAccess
            {
                CadenaConexion = string.IsNullOrEmpty(connStr) ? ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString : connStr
            };
        }

        public BaseResponse bajaCatalogo(CatalogoRequest request)
        {
            ResultadoBorrado resultado = da.borrarCatalogo(request.Id);
            return new BaseResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse bajaCliente(ClienteRequest request)
        {
            var resultado = da.borrarUsuario(request.IdCliente);
            return new BaseResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public NotaComentarioResponse bajaComentarioNota(NotaComentarioRequest request)
        {
            var resultado = da.borrarComentario(request.Id);
            return new NotaComentarioResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public DetalleNotaResponse bajaDetalleNota(DetalleNotaRequest request)
        {
            var resultado = da.borrarDetalle(request.Id);
            return new DetalleNotaResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse bajaEstatus(EstatusRequest request)
        {
            var resultado = da.borrarEstatus(request.Id);
            return new BaseResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public NotaResponse bajaNota(NotaRequest request)
        {
            var resultado = da.borrarNota(request.Folio);
            return new NotaResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public ProductoResponse bajaProducto(ProductoRequest request)
        {
            var resultado = da.borrarProducto(request.Id);
            return new ProductoResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public NotaTicketResponse bajaTicketNota(NotaTicketRequest request)
        {
            var resultado = da.borrarTicket(request.Id);
            return new NotaTicketResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse cambiarEstatusPagina(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public CatalogoResponse cargarCatalogo(CatalogoRequest request)
        {
            var resultado = da.listarCatalogo(Catalogo.ToModel(request)).FirstOrDefault();
            return CatalogoResponse.ToResponse(resultado);
        }

        public ClienteResponse cargarCliente(ClienteRequest request)
        {
            var resultado = da.listarUsuario(Usuario.ToModel(request)).FirstOrDefault();
            return ClienteResponse.ToResponse(resultado);
        }

        public NotaComentarioResponse cargarComentarioNota(NotaComentarioRequest request)
        {
            var resultado = da.listarComentario(ComentarioNota.ToModel(request)).FirstOrDefault();
            return NotaComentarioResponse.ToResponse(resultado);
        }

        public DetalleNotaResponse cargarDetalleNota(DetalleNotaRequest request)
        {
            var resultado = da.listarDetalle(DetalleNota.ToModel(request)).FirstOrDefault();
            return DetalleNotaResponse.ToResponse(resultado);
        }

        public EstatusResponse cargarEstatus(EstatusRequest request)
        {
            var resultado = da.listarEstatus(Estatus.ToModel(request)).FirstOrDefault();
            return EstatusResponse.ToResponse(resultado);
        }

        public HistorialClienteResponse cargarHistorialCliente(ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public NotaResponse cargarNota(NotaRequest request)
        {
            var resultado = da.listarNota(Nota.ToModel(request)).FirstOrDefault();
            return NotaResponse.ToResponse(resultado);
        }

        public ProductoResponse cargarProducto(ProductoRequest request)
        {
            var resultado = da.listarProductos(request.Id).FirstOrDefault();
            return ProductoResponse.ToResponse(resultado);
        }

        public NotaTicketResponse cargarTicketNota(NotaTicketRequest request)
        {
            var resultado = da.listarTicket(TicketNota.ToModel(request)).FirstOrDefault();
            return NotaTicketResponse.ToResponse(resultado);
        }

        public TipoEstatusResponse cargarTipoEstatus(TipoEstatusRequest request)
        {
            var resultado = da.listarTipoEstatus(request.Id).FirstOrDefault();
            return TipoEstatusResponse.ToRequest(resultado);
        }

        public BaseResponse enviarRecordatorios(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public GuiaResponse generarGuias(GuiaRequest request)
        {
            throw new NotImplementedException();
        }

        public CatalogoResponse guardarCatalogo(CatalogoRequest request)
        {
            var resultado = da.guardarCatalogo(Catalogo.ToModel(request));
            return CatalogoResponse.ToResponse(resultado);
        }

        public ClienteResponse guardarCliente(ClienteRequest request)
        {
            var resultado = da.guardarUsuario(Usuario.ToModel(request));
            return ClienteResponse.ToResponse(resultado);
        }

        public NotaComentarioResponse guardarComentarioNota(NotaComentarioRequest request)
        {
            var resultado = da.guardarComentario(ComentarioNota.ToModel(request));
            return NotaComentarioResponse.ToResponse(resultado);
        }

        public DetalleNotaResponse guardarDetalleNota(DetalleNotaRequest request)
        {
            var resultado = da.guardarDetalle(DetalleNota.ToModel(request));
            return DetalleNotaResponse.ToResponse(resultado);
        }

        public EstatusResponse guardarEstatus(EstatusRequest request)
        {
            var resultado = da.guardarEstatus(Estatus.ToModel(request));
            return EstatusResponse.ToResponse(resultado);
        }

        public NotaResponse guardarNota(NotaRequest request)
        {
            var resultado = da.guardarNota(Nota.ToModel(request));
            return NotaResponse.ToResponse(resultado);
        }

        public ProductoResponse guardarProducto(ProductoRequest request)
        {
            var resultado = da.guardarProducto(Producto.ToModel(request));
            return ProductoResponse.ToResponse(resultado);
        }

        public NotaTicketResponse guardarTicketNota(NotaTicketRequest request)
        {
            throw new NotImplementedException();
        }

        public ColeccionCatalogoResponse listarCatalogo(CatalogoRequest request)
        {
            ColeccionCatalogoResponse response = new ColeccionCatalogoResponse();
            var resultado = da.listarCatalogo(Catalogo.ToModel(request));
            response.Items.AddRange(
                resultado.Select(i => CatalogoResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionClientesResponse listarClientes(ClienteRequest request)
        {
            ColeccionClientesResponse response = new ColeccionClientesResponse();
            var resultado = da.listarUsuario(Usuario.ToModel(request));
            response.Items.AddRange(
                resultado.Select(i => ClienteResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionNotaComentarioResponse listarComentarioNota(NotaComentarioRequest request)
        {
            ColeccionNotaComentarioResponse response = new ColeccionNotaComentarioResponse();
            var resultado = da.listarComentario(ComentarioNota.ToModel(request));
            response.Items.AddRange(
                resultado.Select(i => NotaComentarioResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionDetalleNotaResponse listarDetalleNota(DetalleNotaRequest request)
        {
            ColeccionDetalleNotaResponse response = new ColeccionDetalleNotaResponse();
            var resultado = da.listarDetalle(DetalleNota.ToModel(request));
            response.Items.AddRange(
                resultado.Select(i => DetalleNotaResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionEstatusResponse listarEstatus(EstatusRequest request)
        {
            ColeccionEstatusResponse response = new ColeccionEstatusResponse();
            var resultado = da.listarEstatus(Estatus.ToModel(request));
            response.Items.AddRange(
                resultado.Select(i => EstatusResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionNotasResponse listarNotas(NotaRequest request)
        {
            ColeccionNotasResponse response = new ColeccionNotasResponse();
            var resultado = da.listarNota(Nota.ToModel(request));
            response.Items.AddRange(
                resultado.Select(i => NotaResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionProductoResponse listarProductos(ProductoRequest request)
        {
            ColeccionProductoResponse response = new ColeccionProductoResponse();
            var resultado = da.listarProductos(request.Id);
            response.Items.AddRange(
                resultado.Select(i => ProductoResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionNotaTicketResponse listarTicketNota(NotaTicketRequest request)
        {
            ColeccionNotaTicketResponse response = new ColeccionNotaTicketResponse();
            var resultado = da.listarTicket(TicketNota.ToModel(request));
            response.Items.AddRange(
                resultado.Select(r => NotaTicketResponse.ToResponse(r))
                );
            return response;
        }

        public ColeccionTipoCatalogoResponse listarTipoCatalogo(TipoCatalogoRequest request)
        {
            ColeccionTipoCatalogoResponse response = new ColeccionTipoCatalogoResponse();
            var resultado = da.listarTipoCatalogo(request.Id);
            response.Items.AddRange(
                resultado.Select(i => TipoCatalogoResponse.ToResponse(i))
                );
            return response;
        }

        public ColeccionTipoEstatusResponse listarTipoEstatus(TipoEstatusRequest request)
        {
            ColeccionTipoEstatusResponse response = new ColeccionTipoEstatusResponse();
            var resultado = da.listarTipoEstatus(request.Id);
            response.Items.AddRange(
                resultado.Select(i => TipoEstatusResponse.ToRequest(i))
                );
            return response;
        }

        public ArchivoResponse subirFotos(ArchivoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
