using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class DetalleDTO
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public static DetalleDTO ToDTO(dynamic detalle)
        {
            return new DetalleDTO
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

    public class DetallesDTO : List<DetalleDTO>
    {
        public static List<DetalleDTO> ToDTO(List<Detalle> detalles) =>
            (List<DetalleDTO>)detalles.Select(d => DetalleDTO.ToDTO(d));
    }
}
