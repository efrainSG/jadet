using SernaSisitemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.DataAccess;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;

namespace SernaSisitemas.Jadet.WCF.Implementaciones {
    public class Administrador : IAdministrador {
        public BaseResponse bajaCatalogo(CatalogoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarCatalogo(request.Id);
            return new BaseResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse bajaCliente(ClienteRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarUsuario(request.IdCliente);
            return new BaseResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public NotaComentarioResponse bajaComentarioNota(NotaComentarioRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarComentario(request.Id);
            return new NotaComentarioResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public DetalleNotaResponse bajaDetalleNota(DetalleNotaRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarDetalle(request.Id);
            return new DetalleNotaResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse bajaEstatus(EstatusRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarEstatus(request.Id);
            return new BaseResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public NotaResponse bajaNota(NotaRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarNota(request.Folio);
            return new NotaResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public ProductoResponse bajaProducto(ProductoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarProducto(request.Id);
            return new ProductoResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public NotaTicketResponse bajaTicketNota(NotaTicketRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.borrarTicket(request.Id);
            return new NotaTicketResponse {
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero
            };
        }

        public BaseResponse cambiarEstatusPagina(BaseRequest request) {
            throw new NotImplementedException();
        }

        public CatalogoResponse cargarCatalogo(CatalogoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarCatalogo(new Catalogo {
                Id = request.Id,
                IdTipoCatalogo = request.IdTipoCatalogo
            }).FirstOrDefault();
            return new CatalogoResponse {
                Id = resultado.Id,
                IdTipoCatalogo = resultado.IdTipoCatalogo,
                Nombre = resultado.Nombre,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public ClienteResponse cargarCliente(ClienteRequest request) {
            ClienteResponse response;
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarUsuario(new Usuario {
                Id = request.IdCliente,

            }).FirstOrDefault();
            response = new ClienteResponse {
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

        public NotaComentarioResponse cargarComentarioNota(NotaComentarioRequest request) {
            NotaComentarioResponse response;
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarComentario(new ComentarioNota { Id = request.Id, IdNota = request.IdNota, Comentario = request.Comentario, Fecha = request.Fecha }).FirstOrDefault();
            response = new NotaComentarioResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                IdNota = resultado.IdNota,
                Id = resultado.Id,
                Comentario = resultado.Comentario,
                Fecha = resultado.Fecha
            };
            return response;
        }

        public DetalleNotaResponse cargarDetalleNota(DetalleNotaRequest request) {
            DetalleNotaResponse response;
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarDetalle(request.Id, request.IdNota, request.IdProducto).FirstOrDefault();
            response = new DetalleNotaResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Cantidad = resultado.Cantidad,
                IdProducto = resultado.IdProducto,
                IdNota = resultado.IdNota,
                Id = resultado.Id,
                PrecioMXN = resultado.PrecioMXN,
                PrecioUSD = resultado.PrecioUSD
            };
            return response;
        }

        public EstatusResponse cargarEstatus(EstatusRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarEstatus(new Estatus {
                Id = request.Id,
                IdTipoEstatus = request.IdTipoEstatus
            }).FirstOrDefault();
            return new EstatusResponse {
                Id = resultado.Id,
                IdTipoEstatus = resultado.IdTipoEstatus,
                Nombre = resultado.Nombre,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public HistorialClienteResponse cargarHistorialCliente(ClienteRequest request) {
            throw new NotImplementedException();
        }

        public NotaResponse cargarNota(NotaRequest request) {
            NotaResponse response;
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarNota(new Nota { Folio = request.Folio }).FirstOrDefault();
            response = new NotaResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Fecha = resultado.Fecha,
                FechaEnvio = resultado.FechaEnvio,
                Folio = resultado.Folio,
                Guia = resultado.Guia,
                IdCliente = resultado.IdCliente,
                IdEstatus = resultado.IdEstatus,
                IdPaqueteria = resultado.IdPaqueteria,
                IdTipo = resultado.IdTipo,
                MontoMXN = resultado.MontoMXN,
                MontoUSD = resultado.MontoUSD,
                SaldoMXN = resultado.SaldoMXN,
                SaldoUSD = resultado.SaldoUSD
            };
            return response;
        }

        public ProductoResponse cargarProducto(ProductoRequest request) {
            ProductoResponse response = new ProductoResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarProductos(request.Id).FirstOrDefault();
            response = new ProductoResponse {
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

        public NotaTicketResponse cargarTicketNota(NotaTicketRequest request) {
            NotaTicketResponse response;
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarTicket(new TicketNota { Id = request.Id }).FirstOrDefault();
            response = new NotaTicketResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                IdNota = resultado.IdNota,
                Id = resultado.Id,
                Fecha = resultado.Fecha,
                Ticket = resultado.Ticket
            };
            return response;
        }

        public TipoEstatusResponse cargarTipoEstatus(TipoEstatusRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarTipoEstatus(request.Id).FirstOrDefault();
            return new TipoEstatusResponse {
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public BaseResponse enviarRecordatorios(BaseRequest request) {
            throw new NotImplementedException();
        }

        public GuiaResponse generarGuias(GuiaRequest request) {
            throw new NotImplementedException();
        }

        public CatalogoResponse guardarCatalogo(CatalogoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarCatalogo(new Catalogo {
                Id = request.Id,
                IdTipoCatalogo = request.IdTipoCatalogo,
                Nombre = request.Nombre
            });
            return new CatalogoResponse {
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                IdTipoCatalogo = resultado.IdTipoCatalogo,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public ClienteResponse guardarCliente(ClienteRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarUsuario(new Usuario {
                Id = request.IdCliente,
                Direccion = request.Direccion,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Foto = request.Foto,
                IdEstatus = request.IdEstatus,
                IdRol = request.IdRol,
                Nombre = request.Nombre,
                Password = request.Password,
                Telefono = request.Telefono,
                UserName = request.UserName,
                ZonaPaqueteria = request.ZonaPaqueteria
            });
            return new ClienteResponse {
                IdCliente = resultado.Id,
                Direccion = resultado.Direccion,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Foto = resultado.Foto,
                IdEstatus = resultado.IdEstatus,
                IdRol = resultado.IdRol,
                Nombre = resultado.Nombre,
                Password = resultado.Password,
                Telefono = resultado.Telefono,
                UserName = resultado.UserName,
                ZonaPaqueteria = resultado.ZonaPaqueteria
            };
        }

        public NotaComentarioResponse guardarComentarioNota(NotaComentarioRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarComentario(new ComentarioNota {
                Id = request.Id,
                Comentario = request.Comentario,
                Fecha = request.Fecha,
                IdNota = request.IdNota
            });
            return new NotaComentarioResponse {
                Id = resultado.Id,
                Comentario = resultado.Comentario,
                Fecha = resultado.Fecha,
                IdNota = resultado.IdNota,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public DetalleNotaResponse guardarDetalleNota(DetalleNotaRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarDetalle(new DetalleNota {
                Id = request.Id,
                Cantidad = request.Cantidad,
                IdNota = request.IdNota,
                IdProducto = request.IdProducto,
                PrecioMXN = request.PrecioMXN,
                PrecioUSD = request.PrecioUSD
            });
            return new DetalleNotaResponse {
                Cantidad = resultado.Cantidad,
                PrecioUSD = resultado.PrecioUSD,
                PrecioMXN = resultado.PrecioMXN,
                IdProducto = resultado.IdProducto,
                IdNota = resultado.IdNota,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Id = resultado.Id
            };
        }

        public EstatusResponse guardarEstatus(EstatusRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarEstatus(new Estatus {
                Id = request.Id,
                IdTipoEstatus = request.IdTipoEstatus,
                Nombre = request.Nombre
            });
            return new EstatusResponse {
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                IdTipoEstatus = resultado.IdTipoEstatus,
                ErrorMensaje = string.Empty,
                ErrorNumero = 0
            };
        }

        public NotaResponse guardarNota(NotaRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarNota(new Nota {
                Folio = request.Folio,
                Fecha = request.Fecha,
                FechaEnvio = request.FechaEnvio,
                Guia = request.Guia,
                IdCliente = request.IdCliente,
                IdEstatus = request.IdEstatus,
                IdPaqueteria = request.IdPaqueteria,
                IdTipo = request.IdTipo,
                MontoMXN = request.MontoMXN,
                MontoUSD = request.MontoUSD,
                SaldoMXN = request.SaldoMXN,
                SaldoUSD = request.SaldoUSD
            });
            return new NotaResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Fecha = resultado.Fecha.HasValue ? resultado.Fecha.Value : DateTime.Today,
                FechaEnvio = resultado.FechaEnvio.HasValue ? resultado.FechaEnvio.Value : DateTime.Today,
                Folio = resultado.Folio,
                Guia = resultado.Guia,
                IdCliente = resultado.IdCliente,
                IdEstatus = resultado.IdEstatus,
                IdPaqueteria = resultado.IdPaqueteria,
                IdTipo = resultado.IdTipo,
                MontoMXN = resultado.MontoMXN,
                MontoUSD = resultado.MontoUSD,
                SaldoMXN = resultado.SaldoMXN,
                SaldoUSD = resultado.SaldoUSD
            };
        }

        public ProductoResponse guardarProducto(ProductoRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarProducto(new Producto {
                Id = request.Id,
                AplicaExistencias = request.AplicaExistencias,
                Descripcion = request.Descripcion,
                Existencias = request.Existencias,
                Foto = request.Foto,
                IdCatalogo = request.IdCategoria,
                IdEstatus = request.IdEstatus,
                Nombre = request.Nombre,
                PrecioMXN = request.PrecioMXN,
                PrecioUSD = request.PrecioUSD,
                SKU = request.SKU
            });
            return new ProductoResponse {
                Id = resultado.Id,
                AplicaExistencias = resultado.AplicaExistencias,
                Descripcion = resultado.Descripcion,
                Existencias = resultado.Existencias,
                Foto = resultado.Foto,
                IdCategoria = resultado.IdCatalogo,
                IdEstatus = resultado.IdEstatus,
                Nombre = resultado.Nombre,
                PrecioMXN = resultado.PrecioMXN,
                PrecioUSD = resultado.PrecioUSD,
                SKU = resultado.SKU
            };

        }

        public NotaTicketResponse guardarTicketNota(NotaTicketRequest request) {
            throw new NotImplementedException();
        }

        public ColeccionCatalogoResponse listarCatalogo(CatalogoRequest request) {
            ColeccionCatalogoResponse response = new ColeccionCatalogoResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarCatalogo(new Catalogo {
                Id = request.Id,
                IdTipoCatalogo = request.IdTipoCatalogo
            });
            response.Items.AddRange(
                resultado.Select(i => new CatalogoResponse {
                    Id = i.Id,
                    IdTipoCatalogo = i.IdTipoCatalogo,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public coleccionClientesResponse listarClientes(ClienteRequest request) {
            coleccionClientesResponse response = new coleccionClientesResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarUsuario(new Usuario {
                Id = request.IdCliente,
                IdRol = request.IdRol
            });
            response.Items.AddRange(
                resultado.Select(i => new ClienteResponse {
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

        public coleccionNotaComentarioResponse listarComentarioNota(NotaComentarioRequest request) {
            coleccionNotaComentarioResponse response = new coleccionNotaComentarioResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarComentario(new ComentarioNota { 
                Id = request.Id,
                IdNota = request.IdNota
            });
            response.Items.AddRange(
                resultado.Select(i => new NotaComentarioResponse {
                    Id = i.Id,
                    IdNota = i.IdNota,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Comentario = i.Comentario,
                    Fecha = i.Fecha
                }));
            return response;
        }

        public coleccionDetalleNotaResponse listarDetalleNota(DetalleNotaRequest request) {
            coleccionDetalleNotaResponse response = new coleccionDetalleNotaResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarDetalle(id: request.Id, idNota: request.IdNota, IdProducto: request.IdProducto);
            response.Items.AddRange(
                resultado.Select(i => new DetalleNotaResponse {
                    Id = i.Id,
                    Cantidad = i.Cantidad,
                    IdProducto = i.IdProducto,
                    IdNota = i.IdNota,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    PrecioMXN = i.PrecioMXN,
                    PrecioUSD = i.PrecioUSD
                }));
            return response;
        }

        public ColeccionEstatusResponse listarEstatus(EstatusRequest request) {
            ColeccionEstatusResponse response = new ColeccionEstatusResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarEstatus(new Estatus {
                Id = request.Id,
                IdTipoEstatus = request.IdTipoEstatus
            });
            response.Items.AddRange(
                resultado.Select(i => new EstatusResponse {
                    Id = i.Id,
                    IdTipoEstatus = i.IdTipoEstatus,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public coleccionNotasResponse listarNotas(NotaRequest request) {
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarNota(new Nota {
                Folio = request.Folio,
                Fecha = request.Fecha,
                IdEstatus = request.IdEstatus
            });
            var response = new coleccionNotasResponse();
            response.Items.AddRange(resultado.Select(i => new NotaResponse {
                ErrorMensaje = string.Empty,
                ErrorNumero = 0,
                Fecha = i.Fecha,
                FechaEnvio = i.FechaEnvio,
                Folio = i.Folio,
                Guia = i.Guia,
                IdCliente = i.IdCliente,
                IdEstatus = i.IdEstatus
            }));
            return response;
        }

        public coleccionProductoResponse listarProductos(ProductoRequest request) {
            coleccionProductoResponse response = new coleccionProductoResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarProductos(request.Id);
            response.Items.AddRange(
                resultado.Select(i => new ProductoResponse {
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

        public coleccionNotaTicketResponse listarTicketNota(NotaTicketRequest request) {
            throw new NotImplementedException();
        }

        public ColeccionTipoCatalogoResponse listarTipoCatalogo(TipoCatalogoRequest request) {
            ColeccionTipoCatalogoResponse response = new ColeccionTipoCatalogoResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarTipoCatalogo(request.Id);
            response.Items.AddRange(
                resultado.Select(i => new TipoCatalogoResponse {
                    Id = i.Id,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public ColeccionTipoEstatusResponse listarTipoEstatus(TipoEstatusRequest request) {
            ColeccionTipoEstatusResponse response = new ColeccionTipoEstatusResponse();
            DataAccess da = new DataAccess {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.listarTipoEstatus(request.Id);
            response.Items.AddRange(
                resultado.Select(i => new TipoEstatusResponse {
                    Id = i.Id,
                    Nombre = i.Nombre
                }
                ));
            return response;
        }

        public ArchivoResponse subirFotos(ArchivoRequest request) {
            throw new NotImplementedException();
        }
    }
}
