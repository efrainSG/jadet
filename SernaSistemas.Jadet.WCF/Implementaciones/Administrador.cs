using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System.Collections.Generic;
using System.ServiceModel;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Administrador : IAdministrador
    {
        public BaseResponse bajaCliente(ClienteRequest request)
        {
            return new BaseResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public BaseResponse bajaProducto(ProductoRequest request)
        {
            return new BaseResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public NotaResponse borrarNota(NotaRequest request)
        {
            return new NotaResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public BaseResponse cambiarEstatusPagina(BaseRequest request)
        {
            return new BaseResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public ClienteResponse cargarCliente(ClienteRequest request)
        {
            return new ClienteResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public HistorialClienteResponse cargarHistorialCliente(ClienteRequest request)
        {
            return new HistorialClienteResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public ProductoResponse cargarProducto(ProductoRequest request)
        {
            return new ProductoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public BaseResponse enviarRecordatorios(BaseRequest request)
        {
            return new BaseResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public GuiaResponse generarGuias(GuiaRequest request)
        {
            return new GuiaResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public ClienteResponse guardarCliente(ClienteRequest request)
        {
            return new ClienteResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public ProductoResponse guardarProducto(ProductoRequest request)
        {
            return new ProductoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public coleccionClientesResponse listarClientes(ClienteRequest request)
        {
            return new coleccionClientesResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1,
                Items = new List<ClienteResponse>()
            };
        }

        public coleccionNotasResponse listarNotas(BaseRequest request)
        {
            return new coleccionNotasResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1,
                Items = new List<NotaResponse>()
            };
        }

        public coleccionProductoResponse listarProductos(BaseRequest request)
        {
            return new coleccionProductoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1,
                Items = new List<ProductoResponse>()
            };
        }

        public ArchivoResponse subirFotos(ArchivoRequest request)
        {
            return new ArchivoResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }

        public NotaResponse verNota(NotaRequest request)
        {
            return new NotaResponse
            {
                ErrorMensaje = "No implementado",
                ErrorNumero = 1
            };
        }
    }
}
