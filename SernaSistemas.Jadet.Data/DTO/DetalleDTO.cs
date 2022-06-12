using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class DetalleDto
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public static DetalleDto ToDTO(dynamic detalle)
        {
            return new DetalleDto
            {
                Id = detalle.Id,
                IdNota = detalle.IdNota,
                IdProducto = detalle.IdProducto,
                Cantidad = detalle.Cantidad,
                PrecioMXN = detalle.PrecioMXN,
                PrecioUSD = detalle.PrecioUSD
            };
        }
    }

    public class DetallesDto : List<DetalleDto>
    {
        public static List<DetalleDto> ToDTO(List<Detalle> detalles) =>
            detalles.Select(d => DetalleDto.ToDTO(d)).ToList();
    }
}
