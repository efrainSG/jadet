using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.DataAccess;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarUsuario(request.IdCliente);
            return new BaseResponse
            {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse bajaEstatus(EstatusRequest request)
        {
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarCatalogo(new Catalogo
            {
                Id = request.Id,
                IdTipoCatalogo = request.IdTipoCatalogo
            }).FirstOrDefault();
            return new CatalogoResponse
            {
                Id = resultado.Id,
                IdTipoCatalogo = resultado.IdTipoCatalogo,
                Nombre = resultado.Nombre,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public ClienteResponse cargarCliente(ClienteRequest request)
        {
            ClienteResponse response;
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarUsuario(new Usuario
            {
                Id = request.IdCliente,

            }).FirstOrDefault();
            response = new ClienteResponse
            {
                IdCliente = resultado.Id,
                Foto = resultado.Foto,
                Nombre = resultado.Nombre,
                Password = resultado.Password,
                Direccion = resultado.Direccion,
                IdEstatus = resultado.IdEstatus,
                IdRol = resultado.IdRol,
                Telefono = resultado.Telefono,
                UserName = resultado.UserName,
                ZonaPaqueteria = resultado.ZonaPaqueteria
            };
            return response;
        }

        public EstatusResponse cargarEstatus(EstatusRequest request)
        {
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarEstatus(new Estatus
            {
                Id = request.Id,
                IdTipoEstatus = request.IdTipoEstatus
            }).FirstOrDefault();
            return new EstatusResponse
            {
                Id = resultado.Id,
                IdTipoEstatus = resultado.IdTipoEstatus,
                Nombre = resultado.Nombre,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
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
            ProductoResponse response = new ProductoResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarProductos(request.Id).FirstOrDefault();
            response = new ProductoResponse
            {
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                AplicaExistencias = resultado.AplicaExistencias,
                Descripcion = resultado.Descripcion,
                Existencias = resultado.Existencias,
                Foto = resultado.Foto,
                IdCategoria = resultado.IdCatalogo,
                PrecioMXN = resultado.PrecioMXN,
                PrecioUSD = resultado.PrecioUSD,
                SKU = resultado.SKU
            };
            return response;
        }

        public TipoEstatusResponse cargarTipoEstatus(TipoEstatusRequest request)
        {
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarTipoEstatus(request.Id).FirstOrDefault();
            return new TipoEstatusResponse
            {
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
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
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
            ProductoResponse response = new ProductoResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarProducto(new Producto
            {
                Id = request.Id,
                AplicaExistencias = request.AplicaExistencias,
                Descripcion = request.Descripcion,
                Existencias = request.Existencias,
                Foto = request.Foto,
                IdCatalogo = request.IdCategoria,
                Nombre = request.Nombre,
                PrecioMXN = request.PrecioMXN,
                PrecioUSD = request.PrecioUSD,
                SKU = request.SKU
            });

            response = new ProductoResponse
            {
                AplicaExistencias = resultado.AplicaExistencias,
                Descripcion = resultado.Descripcion,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Existencias = resultado.Existencias,
                SKU = resultado.SKU,
                Foto = resultado.Foto,
                Id = resultado.Id,
                IdCategoria = resultado.IdCatalogo,
                Nombre = resultado.Nombre,
                PrecioMXN = resultado.PrecioMXN,
                PrecioUSD = resultado.PrecioUSD
            };

            return response;
        }

        public ColeccionCatalogoResponse listarCatalogo(CatalogoRequest request)
        {
            ColeccionCatalogoResponse response = new ColeccionCatalogoResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarUsuario(new Usuario
            {
                Id = request.IdCliente,
                IdRol = request.IdRol
            });
            response.Items.AddRange(
                resultado.Select(i => new ClienteResponse
                {
                    Direccion = i.Direccion,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Foto = i.Foto,
                    IdCliente = i.Id,
                    IdEstatus = i.IdEstatus,
                    IdRol = i.IdRol,
                    Nombre = i.Nombre,
                    Password = i.Password,
                    Telefono = i.Telefono,
                    UserName = i.UserName,
                    ZonaPaqueteria = i.ZonaPaqueteria
                }
                ));
            return response;
        }

        public ColeccionEstatusResponse listarEstatus(EstatusRequest request)
        {
            ColeccionEstatusResponse response = new ColeccionEstatusResponse();
            DataAccess da = new DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
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
