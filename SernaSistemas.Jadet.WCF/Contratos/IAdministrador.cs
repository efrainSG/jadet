using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace SernaSisitemas.Jadet.WCF.Contratos
{
    [ServiceContract]
    public interface IAdministrador
    {
        [OperationContract]
        CatalogoResponse guardarCatalogo(CatalogoRequest request);
        [OperationContract]
        BaseResponse bajaCatalogo(CatalogoRequest request);
        [OperationContract]
        CatalogoResponse cargarCatalogo(CatalogoRequest request);
        [OperationContract]
        ColeccionCatalogoResponse listarCatalogo(CatalogoRequest request);

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
        EstatusResponse cargarTipoEstatus(EstatusRequest request);

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
        BaseResponse bajaProducto(ProductoRequest request);
        [OperationContract]
        ProductoResponse cargarProducto(ProductoRequest request);
        [OperationContract]
        coleccionProductoResponse listarProductos(BaseRequest request);

        [OperationContract]
        NotaResponse guardarNota(NotaRequest request);
        [OperationContract]
        coleccionNotasResponse listarNotas(BaseRequest request);
        [OperationContract]
        NotaResponse cargarNota(NotaRequest request);
        [OperationContract]
        NotaResponse bajaNota(NotaRequest request);


        [OperationContract]
        GuiaResponse generarGuias(GuiaRequest request);
        [OperationContract]
        BaseResponse enviarRecordatorios(BaseRequest request);
        [OperationContract]
        BaseResponse cambiarEstatusPagina(BaseRequest request);
    }
}
