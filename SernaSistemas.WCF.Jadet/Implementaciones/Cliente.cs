using SernaSisitemas.Jadet.WCF.Contratos;
using System.ServiceModel;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    [ServiceContract]
    public class Cliente : ICliente
    {
        public object agregarACarrito(object request)
        {
            throw new System.NotImplementedException();
        }

        public object generarPedido(object request)
        {
            throw new System.NotImplementedException();
        }

        public object guardarPedido(object request)
        {
            throw new System.NotImplementedException();
        }

        public object listarPedidos(object request)
        {
            throw new System.NotImplementedException();
        }

        public object quitarDelCarrito(object request)
        {
            throw new System.NotImplementedException();
        }

        public object subirFoto(object request)
        {
            throw new System.NotImplementedException();
        }

        public object vaciarCarrito(object request)
        {
            throw new System.NotImplementedException();
        }

        public object verPedido(object request)
        {
            throw new System.NotImplementedException();
        }
    }
}
