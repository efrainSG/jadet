using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System.Collections.Generic;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Cliente : ICliente
    {
        public ItemCarritoResponse agregarACarrito(ItemCarritoRequest request)
        {
            return new ItemCarritoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public BaseResponse generarPedido(CarritoRequest request)
        {
            return new BaseResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public BaseResponse guardarPedido(CarritoRequest request)
        {
            return new BaseResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public ColeccionCarritoResponse listarPedidos(BaseRequest request)
        {
            return new ColeccionCarritoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1,
                Items = new List<CarritoResponse>()
            };
        }

        public BaseResponse quitarDelCarrito(ItemCarritoRequest request)
        {
            return new BaseResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
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

        public CarritoResponse vaciarCarrito(BaseRequest request)
        {
            return new CarritoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public CarritoResponse verPedido(CarritoRequest request)
        {
            return new CarritoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }
    }
}
