using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.DataAccess;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SernaSisitemas.Jadet.WCF.Implementaciones
{
    public class Administrador : IAdministrador
    {
        public BaseResponse bajaCatalogo(CatalogoRequest request)
        {
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.borrarCatalogo(request.Id);
            return new BaseResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse bajaCliente(ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public BaseResponse bajaEstatus(EstatusRequest request)
        {
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.borrarEstatus(request.Id);
            return new BaseResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
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
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.guardarCatalogo(new Catalogo
            {
                Id = request.Id,
                IdTipoCatalogo = request.IdTipoCatalogo,
                Nombre = request.Nombre
            });
            return new CatalogoResponse
            {
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                IdTipoCatalogo = resultado.IdTipoCatalogo,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public ClienteResponse guardarCliente(ClienteRequest request)
        {
            throw new NotImplementedException();
        }

        public EstatusResponse guardarEstatus(EstatusRequest request)
        {
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.guardarEstatus(new Estatus
            {
                Id = request.Id,
                IdTipoEstatus = request.IdTipoEstatus,
                Nombre = request.Nombre
            });
            return new EstatusResponse
            {
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                IdTipoEstatus = resultado.IdTipoEstatus,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
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
            ColeccionCatalogoResponse response = new ColeccionCatalogoResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.listarCatalogo(new Catalogo
            {
                Id = request.Id,
                IdTipoCatalogo = request.IdTipoCatalogo
            });
            response.Items.AddRange(
                resultado.Select(i => new CatalogoResponse
                {
                    Id = i.Id,
                    IdTipoCatalogo = i.IdTipoCatalogo,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public coleccionClientesResponse listarClientes(ClienteRequest request)
        {
            coleccionClientesResponse response = new coleccionClientesResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            return response;
        }

        public ColeccionEstatusResponse listarEstatus(EstatusRequest request)
        {
            ColeccionEstatusResponse response = new ColeccionEstatusResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.listarEstatus(new Estatus
            {
                Id = request.Id,
                IdTipoEstatus = request.IdTipoEstatus
            });
            response.Items.AddRange(
                resultado.Select(i => new EstatusResponse
                {
                    Id = i.Id,
                    IdTipoEstatus = i.IdTipoEstatus,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public coleccionNotasResponse listarNotas(BaseRequest request)
        {
            throw new NotImplementedException();
        }

        public coleccionProductoResponse listarProductos(ProductoRequest request)
        {
            coleccionProductoResponse response = new coleccionProductoResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.listarProductos(request.Id);
            response.Items.AddRange(
                resultado.Select(i => new ProductoResponse
                {
                    Id = i.Id,
                    Nombre = i.Nombre,
                    AplicaExistencias = i.AplicaExistencias,
                    Descripcion = i.Descripcion,
                    Existencias = i.Existencias,
                    Foto = i.Foto,
                    IdCategoria = i.IdCatalogo,
                    PrecioMXN = i.PrecioMXN,
                    PrecioUSD = i.PrecioUSD,
                    SKU = i.SKU
                }
                ));
            return response;
        }

        public ColeccionTipoCatalogoResponse listarTipoCatalogo(TipoCatalogoRequest request)
        {
            ColeccionTipoCatalogoResponse response = new ColeccionTipoCatalogoResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.listarTipoCatalogo(request.Id);
            response.Items.AddRange(
                resultado.Select(i => new TipoCatalogoResponse
                {
                    Id = i.Id,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public ColeccionTipoEstatusResponse listarTipoEstatus(TipoEstatusRequest request)
        {
            ColeccionTipoEstatusResponse response = new ColeccionTipoEstatusResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\efsern\source\repos\SernaSistemas.Jadet\SernaSistemas.Jadet.DataAccess\JadetBD.mdf;Integrated Security=True"
            };
            var resultado = da.listarTipoEstatus(request.Id);
            response.Items.AddRange(
                resultado.Select(i => new TipoEstatusResponse
                {
                    Id = i.Id,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public ArchivoResponse subirFotos(ArchivoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
