﻿using SernaSistemas.Jadet.WCF.Modelos;
using System.ServiceModel;

namespace SernaSisitemas.Jadet.WCF.Contratos {
    [ServiceContract]
    public interface IAdministrador {
        [OperationContract]
        CatalogoResponse guardarCatalogo(CatalogoRequest request);
        [OperationContract]
        BaseResponse bajaCatalogo(CatalogoRequest request);
        [OperationContract]
        CatalogoResponse cargarCatalogo(CatalogoRequest request);
        [OperationContract]
        ColeccionCatalogoResponse listarCatalogo(CatalogoRequest request);
        [OperationContract]
        ColeccionTipoCatalogoResponse listarTipoCatalogo(TipoCatalogoRequest request);

        [OperationContract]
        EstatusResponse guardarEstatus(EstatusRequest request);
        [OperationContract]
        BaseResponse bajaEstatus(EstatusRequest request);
        [OperationContract]
        EstatusResponse cargarEstatus(EstatusRequest request);
        [OperationContract]
        ColeccionEstatusResponse listarEstatus(EstatusRequest request);

        [OperationContract]
        ColeccionTipoEstatusResponse listarTipoEstatus(TipoEstatusRequest request);
        [OperationContract]
        TipoEstatusResponse cargarTipoEstatus(TipoEstatusRequest request);

        [OperationContract]
        ClienteResponse guardarCliente(ClienteRequest request);
        [OperationContract]
        BaseResponse bajaCliente(ClienteRequest request);
        [OperationContract]
        ClienteResponse cargarCliente(ClienteRequest request);
        [OperationContract]
        coleccionClientesResponse listarClientes(ClienteRequest request);
        [OperationContract]
        HistorialClienteResponse cargarHistorialCliente(ClienteRequest request);

        [OperationContract]
        ArchivoResponse subirFotos(ArchivoRequest request);

        [OperationContract]
        ProductoResponse guardarProducto(ProductoRequest request);
        [OperationContract]
        ProductoResponse bajaProducto(ProductoRequest request);
        [OperationContract]
        ProductoResponse cargarProducto(ProductoRequest request);
        [OperationContract]
        coleccionProductoResponse listarProductos(ProductoRequest request);

        [OperationContract]
        NotaResponse guardarNota(NotaRequest request);
        [OperationContract]
        coleccionNotasResponse listarNotas(NotaRequest request);
        [OperationContract]
        NotaResponse cargarNota(NotaRequest request);
        [OperationContract]
        NotaResponse bajaNota(NotaRequest request);

        [OperationContract]
        DetalleNotaResponse guardarDetalleNota(DetalleNotaRequest request);
        [OperationContract]
        coleccionDetalleNotaResponse listarDetalleNota(DetalleNotaRequest request);
        [OperationContract]
        DetalleNotaResponse cargarDetalleNota(DetalleNotaRequest request);
        [OperationContract]
        DetalleNotaResponse bajaDetalleNota(DetalleNotaRequest request);

        [OperationContract]
        NotaComentarioResponse guardarComentarioNota(NotaComentarioRequest request);
        [OperationContract]
        coleccionNotaComentarioResponse listarComentarioNota(NotaComentarioRequest request);
        [OperationContract]
        NotaComentarioResponse cargarComentarioNota(NotaComentarioRequest request);
        [OperationContract]
        NotaComentarioResponse bajaComentarioNota(NotaComentarioRequest request);

        [OperationContract]
        NotaTicketResponse guardarTicketNota(NotaTicketRequest request);
        [OperationContract]
        coleccionNotaTicketResponse listarTicketNota(NotaTicketRequest request);
        [OperationContract]
        NotaTicketResponse cargarTicketNota(NotaTicketRequest request);
        [OperationContract]
        NotaTicketResponse bajaTicketNota(NotaTicketRequest request);

        [OperationContract]
        GuiaResponse generarGuias(GuiaRequest request);
        [OperationContract]
        BaseResponse enviarRecordatorios(BaseRequest request);
        [OperationContract]
        BaseResponse cambiarEstatusPagina(BaseRequest request);
    }
}
