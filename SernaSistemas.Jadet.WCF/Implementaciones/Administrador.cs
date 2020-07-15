using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Administrador : IAdministrador
    {
        public BaseResponse bajaCatalogo(CatalogoRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse bajaCliente(ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse bajaEstatus(EstatusRequest request)
        {
            throw new NotImplementedException();
        }

        public NotaResponse bajaNota(NotaRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse bajaProducto(ProductoRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse cambiarEstatusPagina(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public CatalogoResponse cargarCatalogo(CatalogoRequest request)
        {
            throw new NotImplementedException();
        }

        public ClienteResponse cargarCliente(ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public EstatusResponse cargarEstatus(EstatusRequest request)
        {
            throw new NotImplementedException();
        }

        public HistorialClienteResponse cargarHistorialCliente(ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public NotaResponse cargarNota(NotaRequest request)
        {
            throw new NotImplementedException();
        }

        public ProductoResponse cargarProducto(ProductoRequest request)
        {
            throw new NotImplementedException();
        }

        public EstatusResponse cargarTipoEstatus(EstatusRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse enviarRecordatorios(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public GuiaResponse generarGuias(GuiaRequest request)
        {
            throw new NotImplementedException();
        }

        public CatalogoResponse guardarCatalogo(CatalogoRequest request)
        {
            throw new NotImplementedException();
        }

        public ClienteResponse guardarCliente(ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public EstatusResponse guardarEstatus(EstatusRequest request)
        {
            throw new NotImplementedException();
        }

        public NotaResponse guardarNota(NotaRequest request)
        {
            throw new NotImplementedException();
        }

        public ProductoResponse guardarProducto(ProductoRequest request)
        {
            throw new NotImplementedException();
        }

        public ColeccionCatalogoResponse listarCatalogo(CatalogoRequest request)
        {
            throw new NotImplementedException();
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

        public ColeccionEstatusResponse listarEstatus(EstatusRequest request)
        {
            throw new NotImplementedException();
        }

        public coleccionNotasResponse listarNotas(BaseRequest request)
        {
            throw new NotImplementedException();
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

        public ColeccionTipoEstatusResponse listarTipoEstatus(TipoEstatusRequest request)
        {
            throw new NotImplementedException();
        }

        public ArchivoResponse subirFotos(ArchivoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
