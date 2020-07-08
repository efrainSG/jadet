using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace SernaSisitemas.Jadet.WCF.Contratos
{
    [ServiceContract]
    public interface ICliente
    {
        [OperationContract]
        object subirFoto(object request);

        [OperationContract]
        object agregarACarrito(object request);
        [OperationContract]
        object quitarDelCarrito(object request);
        [OperationContract]
        object vaciarCarrito(object request);

        [OperationContract]
        object generarPedido(object request);
        [OperationContract]
        object verPedido(object request);
        [OperationContract]
        object listarPedidos(object request);
        [OperationContract]
        object guardarPedido(object request);

    }
}
