using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class ProductoDto
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

        public static ProductoDto ToDTO(dynamic producto)
        {
            return new ProductoDto
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

    public class ProductosDto : List<ProductoDto>
    {
        public static List<ProductoDto> ToDTO(List<Producto> productos) =>
            productos.Select(p => ProductoDto.ToDTO(p)).ToList();
    }
}
