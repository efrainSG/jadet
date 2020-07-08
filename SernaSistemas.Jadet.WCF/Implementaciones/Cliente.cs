using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System.ServiceModel;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Cliente : ICliente
    {
        public ItemCarritoResponse agregarACarrito(ItemCarritoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public BaseResponse generarPedido(CarritoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public BaseResponse guardarPedido(CarritoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ColeccionCarritoResponse listarPedidos(BaseRequest request)
        {
            throw new System.NotImplementedException();
        }

        public object quitarDelCarrito(ItemCarritoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ArchivoResponse subirFoto(ArchivoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public CarritoResponse vaciarCarrito(BaseRequest request)
        {
            throw new System.NotImplementedException();
        }

        public CarritoResponse verPedido(CarritoRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
