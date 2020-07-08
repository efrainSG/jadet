using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System.ServiceModel;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Administrador : IAdministrador
    {
        public BaseResponse bajaCliente(ClienteRequest request)
        {
            throw new System.NotImplementedException();
        }

        public BaseResponse bajaProducto(ProductoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public NotaResponse borrarNota(NotaRequest request)
        {
            throw new System.NotImplementedException();
        }

        public BaseResponse cambiarEstatusPagina(BaseRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ClienteResponse cargarCliente(ClienteRequest request)
        {
            throw new System.NotImplementedException();
        }

        public HistorialClienteResponse cargarHistorialCliente(ClienteRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ProductoResponse cargarProducto(ProductoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public BaseResponse enviarRecordatorios(BaseRequest request)
        {
            throw new System.NotImplementedException();
        }

        public GuiaResponse generarGuias(GuiaRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ClienteResponse guardarCliente(ClienteRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ProductoResponse guardarProducto(ProductoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public coleccionNotasResponse listarNotas(BaseRequest request)
        {
            throw new System.NotImplementedException();
        }

        public coleccionProductoResponse listarProductos(BaseRequest request)
        {
            throw new System.NotImplementedException();
        }

        public ArchivoResponse subirFotos(ArchivoRequest request)
        {
            throw new System.NotImplementedException();
        }

        public NotaResponse verNota(NotaRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
