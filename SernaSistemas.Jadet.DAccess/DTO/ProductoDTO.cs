using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public int IdCatalogo { get; set; }
        public int IdEstatus { get; set; }
        public int IdTipoNota { get; set; }
        public string Sku { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public int Existencias { get; set; }
        public bool AplicaExistencias { get; set; }
        public byte[] Foto { get; set; }

        public static ProductoDTO ToDTO(dynamic producto)
        {
            return new ProductoDTO
            {
                Id = producto.Id,
                IdCatalogo = producto.IdCatalogo,
                IdEstatus = producto.IdEstatus,
                IdTipoNota = producto.IdTipoNota,
                Sku = producto.Sku,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                AplicaExistencias = producto.AplicaExistencias,
                Foto = producto.Foto,
                PrecioMXN = producto.PrecioMXN,
                PrecioUSD = producto.PrecioUSD,
                Existencias = producto.Existencias
            };
        }
    }

    public class ProductosDTO : List<ProductoDTO>
    {
        public static List<ProductoDTO> ToDTO(List<Producto> productos) =>
            (List<ProductoDTO>)productos.Select(p => ProductoDTO.ToDTO(p));
    }
}
