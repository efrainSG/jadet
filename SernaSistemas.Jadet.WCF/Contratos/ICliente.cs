using SernaSistemas.Jadet.WCF.Modelos;
using System.ServiceModel;

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
        ColeccionCarritoResponse listarPedidos(CarritoRequest request);

        [OperationContract]
        NotaTicketResponse guardarTicket(NotaTicketRequest request);
        [OperationContract]
        ColeccionNotaTicketResponse listarTickets(NotaTicketRequest request);

        [OperationContract]
        NotaComentarioResponse guardarComentario(NotaComentarioRequest request);
        [OperationContract]
        ColeccionNotaComentarioResponse listarComentarios(NotaComentarioRequest request);
    }
}
