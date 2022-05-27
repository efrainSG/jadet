using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Detalle
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioMXN { get; set; }
        public decimal PrecioUSD { get; set; }
        public static Detalle ToModel(dynamic detalleDto)
        {
            return new Detalle
            {
                Id = detalleDto.Id,
                IdNota = detalleDto.IdNota,
                IdProducto = detalleDto.IdProducto,
                Cantidad = detalleDto.Cantidad,
                PrecioMXN = detalleDto.PrecioMXN,
                PrecioUSD = detalleDto.PrecioUSD
            };
        }
    }
}
