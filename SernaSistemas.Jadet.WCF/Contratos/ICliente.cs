using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace SernaSisitemas.Jadet.WCF.Contratos {
    [ServiceContract]
    public interface ICliente {
        [OperationContract]
        ArchivoResponse subirFoto(ArchivoRequest request);

        [OperationContract]
        CarritoResponse nuevoCarrito(CarritoRequest request);

        [OperationContract]
        ItemCarritoResponse agregarACarrito(ItemCarritoRequest request);
        [OperationContract]
        BaseResponse quitarDelCarrito(ItemCarritoRequest request);
        [OperationContract]
        CarritoResponse vaciarCarrito(CarritoRequest request);

        [OperationContract]
        BaseResponse generarPedido(CarritoRequest request);
        [OperationContract]
        CarritoResponse verPedido(CarritoRequest request);
        [OperationContract]
        ColeccionCarritoResponse listarPedidos(BaseRequest request);
        [OperationContract]
        BaseResponse guardarPedido(CarritoRequest request);

    }
}
