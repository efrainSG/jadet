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
        ClienteResponse guardarCliente(ClienteRequest request);
        [OperationContract]
        BaseResponse bajaCliente(ClienteRequest request);
        [OperationContract]
        ClienteResponse cargarCliente(ClienteRequest request);

        [OperationContract]
        ArchivoResponse subirFotos(ArchivoRequest request);
        [OperationContract]
        HistorialClienteResponse cargarHistorialCliente(ClienteRequest request);

        [OperationContract]
        ProductoResponse guardarProducto(ProductoRequest request);
        [OperationContract]
        BaseResponse bajaProducto(ProductoRequest request);
        [OperationContract]
        ProductoResponse cargarProducto(ProductoRequest request);
        [OperationContract]
        coleccionProductoResponse listarProductos(BaseRequest request);

        [OperationContract]
        coleccionNotasResponse listarNotas(BaseRequest request);
        [OperationContract]
        NotaResponse verNota(NotaRequest request);
        [OperationContract]
        NotaResponse borrarNota(NotaRequest request);


        [OperationContract]
        GuiaResponse generarGuias(GuiaRequest request);
        [OperationContract]
        BaseResponse enviarRecordatorios(BaseRequest request);
        [OperationContract]
        BaseResponse cambiarEstatusPagina(BaseRequest request);
    }
}
