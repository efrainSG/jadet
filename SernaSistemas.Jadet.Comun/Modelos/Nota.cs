using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Nota
    {
        public int Folio { get; set; }
        public int IdTipo { get; set; }
        public int IdEstatus { get; set; }
        public int IdPaqueteria { get; set; }
        public Guid IdCliente { get; set; }
        public string Guia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEnvio { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }
        public decimal SaldoMXN { get; set; }
        public decimal SaldoUSD { get; set; }

        public static Nota ToModel(dynamic notaDto)
        {
            return new Nota
            {
                Fecha = notaDto.Fecha,
                FechaEnvio = notaDto.FechaEnvio,
                Folio = notaDto.Folio,
                IdTipo = notaDto.IdTipo,
                IdEstatus = notaDto.IdEstatus,
                IdPaqueteria = notaDto.IdPaqueteria,
                IdCliente = notaDto.IdCliente,
                Guia = notaDto.Guia,
                MontoMXN = notaDto.MontoMXN,
                MontoUSD = notaDto.MontoUSD,
                SaldoMXN = notaDto.SaldoMXN,
                SaldoUSD = notaDto.SaldoUSD
            };
        }
    }
}
