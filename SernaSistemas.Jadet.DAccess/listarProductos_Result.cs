//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SernaSistemas.Jadet.DAccess
{
    using System;
    
    public partial class listarProductos_Result
    {
        public int Id { get; set; }
        public string sku { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public int Existencias { get; set; }
        public bool APlicaExistencias { get; set; }
        public byte[] Foto { get; set; }
        public int IdCatalogo { get; set; }
        public int IdEstatus { get; set; }
        public string Categoria { get; set; }
        public string Estatus { get; set; }
        public int IdTipoNota { get; set; }
        public string TipoNota { get; set; }
    }
}
