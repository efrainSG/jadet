using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
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
            coleccionClientesResponse response = new coleccionClientesResponse();
            for (int i = 0; i < 10; i++)
            {
                response.Items.Add(new ClienteResponse
                {
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Foto = string.Format("{0}.jpg",i),
                    IdCliente=i,
                    Nombre = string.Format("Cliente #{0}", i)
                });
            }
            return response;
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
            
            coleccionProductoResponse response = new coleccionProductoResponse();
            for (int i = 0; i < 10; i++)
            {
                response.Items.Add(new ProductoResponse
                {
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Nombre = string.Format("Producto #{0}", i),
                    Existencias = (new Random(100)).Next(300),
                    Id = i,
                    Descripcion = string.Format("Descripción de Producto #{0}", i),
                    RutaImagen = string.Format("{0}.jpg", i),
                    PrecioMXN = (new Random(100)).Next(250),
                    PrecioUSD = (new Random(100)).Next(250),
                    Categoria = new categoriaResponse
                    {
                        Id = i % 4,
                        Nombre = string.Format("Categoría #{0}", i)
                    }
                });
            }
            return response;
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
