using System;

namespace SernaSistemas.Jadet.DataAccess
{
    public class ResultadoBorrado
    {
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }
    }
    public class Catalogo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCatalogo { get; set; }
        public static Catalogo ToModel(dynamic catalogo)
        {
            if (catalogo == null)
            {
                return new Catalogo();
            }
            return new Catalogo
            {
                Id = catalogo.Id,
                IdTipoCatalogo = catalogo.IdTipoCatalogo,
                Nombre = catalogo.Nombre
            };
        }
    }
    public class Estatus
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoEstatus { get; set; }

        public static Estatus ToModel(dynamic estatus)
        {
            if (estatus == null)
            {
                return new Estatus();
            }
            return new Estatus
            {
                Nombre = estatus.Nombre,
                Id = estatus.Id,
                IdTipoEstatus = estatus.IdTipoEstatus
            };
        }
    }
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public int IdRol { get; set; }
        public int ZonaPaqueteria { get; set; }
        public int IdEstatus { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }

        public static Usuario ToModel(dynamic usuario)
        {
            if (usuario == null)
            {
                return new Usuario();
            }
            return new Usuario
            {
                Id = usuario.Id,
                Direccion = usuario.Direccion,
                ErrorMensaje = usuario.ErrorMensaje,
                ErrorNumero = usuario.ErrorNumero,
                Foto = usuario.Foto,
                IdEstatus = usuario.IdEstatus,
                IdRol = usuario.IdRol,
                Nombre = usuario.Nombre,
                Password = usuario.Password,
                Telefono = usuario.Telefono,
                UserName = usuario.UserName,
                ZonaPaqueteria = usuario.ZonaPaqueteria
            };
        }
    }
    public class TipoCatalogo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoCatalogo ToModel(dynamic catalogo)
        {
            if (catalogo == null)
            {
                return new TipoCatalogo();
            }
            return new TipoCatalogo
            {
                Id = catalogo.Id,
                Nombre = catalogo.Nombre
            };
        }
    }
    public class TipoEstatus
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoEstatus ToModel(dynamic tipoEstatus)
        {
            if (tipoEstatus == null)
            {
                return new TipoEstatus();
            }
            return new TipoEstatus
            {
                Id = tipoEstatus.Id,
                Nombre = tipoEstatus.Nombre
            };
        }
    }
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static Rol ToModel(dynamic rol)
        {
            if (rol == null)
            {
                return new Rol();
            }
            return new Rol
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }
    }
    public class Producto
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public int Existencias { get; set; }
        public bool AplicaExistencias { get; set; }
        public byte[] Foto { get; set; }
        public int IdCatalogo { get; set; }
        public int IdEstatus { get; set; }
        public int IdTipoNota { get; set; }

        public static Producto ToModel(dynamic producto)
        {
            if (producto == null)
            {
                return new Producto();
            }
            return new Producto
            {
                Nombre = producto.Nombre,
                Id = producto.Id,
                AplicaExistencias = producto.AplicaExistencias,
                Foto = producto.Foto,
                Descripcion = producto.Descripcion,
                Existencias = producto.Existencias,
                IdCatalogo = producto.IdCatalogo,
                IdEstatus = producto.IdEstatus,
                IdTipoNota = producto.IdTipoNota,
                PrecioMXN = producto.PrecioMXN,
                PrecioUSD = producto.PrecioUSD,
                SKU = producto.SKU
            };
        }
    }
    public class Nota
    {
        public int Folio { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdTipo { get; set; }
        public int IdEstatus { get; set; }
        public int IdPaqueteria { get; set; }
        public Guid IdCliente { get; set; }
        public string Guia { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }
        public decimal SaldoMXN { get; set; }
        public decimal SaldoUSD { get; set; }

        public static Nota ToModel(dynamic nota)
        {
            if (nota == null)
            {
                return new Nota();
            }
            return new Nota
            {
                Fecha = nota.Fecha,
                FechaEnvio = nota.FechaEnvio,
                Folio = nota.Folio,
                Guia = nota.Guia,
                MontoMXN = nota.MontoMXN,
                IdCliente = nota.IdCliente,
                IdEstatus = nota.IdEstatus,
                IdPaqueteria = nota.IdPaqueteria,
                IdTipo = nota.IdTipo,
                MontoUSD = nota.MontoUSD,
                SaldoMXN = nota.SaldoMXN,
                SaldoUSD = nota.SaldoUSD
            };
        }
    }
    public class DetalleNota
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }

        public static DetalleNota ToModel(dynamic detalleNota)
        {
            if (detalleNota == null)
            {
                return new DetalleNota();
            }
            return new DetalleNota
            {
                Cantidad = detalleNota.Cantidad,
                Id = detalleNota.Id,
                IdNota = detalleNota.IdNota,
                IdProducto = detalleNota.IdProducto,
                PrecioMXN = detalleNota.PrecioMXN,
                PrecioUSD = detalleNota.PrecioUSD
            };
        }
    }
    public class TicketNota
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public byte[] Ticket { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }

        public static TicketNota ToModel(dynamic ticketNota)
        {
            if (ticketNota == null)
            {
                return new TicketNota();
            }
            return new TicketNota
            {
                Fecha = ticketNota.Fecha,
                Id = ticketNota.Id,
                IdNota = ticketNota.IdNota,
                Ticket = ticketNota.Ticket,
                MontoMXN = ticketNota.MontoMXN,
                MontoUSD = ticketNota.MontoUSD
            };
        }
    }
    public class ComentarioNota
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdComentarioAnterior { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public static ComentarioNota ToModel(dynamic comentarioNota)
        {
            if (comentarioNota == null)
            {
                return new ComentarioNota();
            }
            return new ComentarioNota
            {
                Id = comentarioNota.Id,
                Comentario = comentarioNota.Comentario,
                Fecha = comentarioNota.Fecha,
                IdComentarioAnterior = comentarioNota.IdComentarioAnterior,
                IdNota = comentarioNota.IdNota
            };
        }
    }
}
