using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    public class Estatus
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoEstatus { get; set; }
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
    }

    public class TipoCatalogo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class TipoEstatus
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
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
    }
}
