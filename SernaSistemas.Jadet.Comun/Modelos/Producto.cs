using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Producto
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

        public static Producto ToModel(dynamic productoDto)
        {
            return new Producto
            {
                Id = productoDto.Id,
                IdCatalogo = productoDto.IdCatalogo,
                IdEstatus = productoDto.IdEstatus,
                IdTipoNota = productoDto.IdTipoNota,
                Sku = productoDto.Sku,
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion,
                AplicaExistencias = productoDto.AplicaExistencias,
                Foto = productoDto.Foto,
                PrecioMXN = productoDto.PrecioMXN,
                PrecioUSD = productoDto.PrecioUSD,
                Existencias = productoDto.Existencias
            };
        }
    }
}
